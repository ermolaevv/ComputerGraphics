#version 430
const float EPSILON = 0.001;
const float BIG = 1000000.0;
const int DIFFUSE = 1;
const int REFLECTION = 2;
const int REFRACTION = 3;
const int DIFFUSE_REFLECTION = 1;
const int MIRROR_REFLECTION = 2;
const int MAX_STACK_SIZE = 10;
const vec3 Unit = vec3 ( 1.0, 1.0, 1.0 );

const int CUBE_COUNT = 3;
const int PANE_COUNT = 6;
const int TRIANGLE_COUNT = 1;
const int SPHERE_COUNT = 2;
const int TETRAHEDRON_COUNT = 1;
const int MATERIAL_COUNT = 8;

uniform vec2 iResolution;
uniform vec3 iCamPos;
uniform vec2 iMouseDir;
uniform vec2 iScope;

uniform int uMaxTraceDepth;

uniform vec3 uMaterialColor;
uniform float uMaterialTransparency;
uniform float uMaterialReflectivity;

/*** DATA STRUCTURES ***/
struct SSphere
{
    vec3 Center;
    float Radius;
    int MaterialIdx;
};

struct STriangle
{
    vec3 v1;
    vec3 v2;
    vec3 v3;
    int MaterialIdx;
};

struct STetrahedron {
    STriangle triangles[4];
    int size;
    int MaterialIdx;
};

struct SPane {
    STriangle triangles[2];
    int a;
    int b;
    int MaterialIdx;
};

struct SCube {
    SPane panes[6];
    int a;
    int MaterialIdx;
};

struct SCamera
{
    vec3 Position;
    vec3 Direction;
    vec2 Scope;
};

struct SRay
{
    vec3 Origin;
    vec3 Direction;
};

struct STracingRay {
    SRay ray;
    float contribution;
    int depth;
};

struct SIntersection
{
    float Time;
    vec3 Point;
    vec3 Normal;
    vec3 Color;
    // ambient, diffuse and specular coeffs
    vec4 LightCoeffs;
    // 0 - non-reflection, 1 - mirror
    float ReflectionCoef;
    float RefractionCoef;
    int MaterialType;
};

struct SLight
{
    vec3 Position;
};

struct SMaterial
{
    //diffuse color
    vec3 Color;
    // ambient, diffuse and specular coeffs
    vec4 LightCoeffs;
    // 0 - non-reflection, 1 - mirror
    float ReflectionCoef;
    float RefractionCoef;
    int MaterialType;
};

struct Stack
{
	int count;
	STracingRay arr[MAX_STACK_SIZE];
};
/*** END STRUCTURES ***/

vec2 uv;
SLight uLight;
SLight uLight2;
SPane panes[PANE_COUNT]; // ROOM
SMaterial materials[MATERIAL_COUNT];
Stack stack;
SCamera uCamera;

STriangle triangles[TRIANGLE_COUNT];
SCube cubes[CUBE_COUNT];
STetrahedron tetrahedrons[TETRAHEDRON_COUNT];
SSphere spheres[SPHERE_COUNT];

vec3 rotate3D(vec3 pos, vec3 angle) {
    angle = radians(angle);

    mat3 rotateMatrix;
    rotateMatrix[0] = vec3(cos(angle.y)*cos(angle.z), -sin(angle.z)*cos(angle.y), sin(angle.y));
    rotateMatrix[1] = vec3(sin(angle.x)*sin(angle.y)*cos(angle.z) + sin(angle.z)*cos(angle.x),
                            -sin(angle.x)*sin(angle.y)*sin(angle.z) + cos(angle.x)*cos(angle.z),
                            -sin(angle.x)*cos(angle.y));
    rotateMatrix[2] = vec3(sin(angle.x)*sin(angle.z) - sin(angle.y)*cos(angle.x)*cos(angle.z),
                            sin(angle.x)*cos(angle.z) + sin(angle.y)*sin(angle.z)*cos(angle.x),
                            cos(angle.x)*cos(angle.y));

    return pos * rotateMatrix;
}

mat2 rotate2D(float angle) {
    angle = radians(angle);
    return mat2(cos(angle), -sin(angle), sin(angle), cos(angle));
}

bool isEmpty()
{
    return (stack.count <= 0);
}

bool isFull()
{
    return (stack.count  == MAX_STACK_SIZE - 1);
}

bool pushRay(STracingRay secondaryRay)
{
    if(!isFull() && secondaryRay.depth < uMaxTraceDepth)
    {
        stack.arr[stack.count++] = secondaryRay;
        return true;
    }
    return false;
}

STracingRay popRay()
{
    return stack.arr[--stack.count];
}

SRay GenerateRay ( SCamera uCamera )
{
    return SRay ( uCamera.Position, normalize( uCamera.Direction) );
}

bool IntersectSphere ( SSphere sphere, SRay ray, float start, float final, out float time )
{
    ray.Origin -= sphere.Center;
    float A = dot ( ray.Direction, ray.Direction );
    float B = dot ( ray.Direction, ray.Origin );
    float C = dot ( ray.Origin, ray.Origin ) - sphere.Radius * sphere.Radius;
    float D = B * B - A * C;
    if ( D > 0.0 )
    {
        D = sqrt ( D );
        //time = min ( max ( 0.0, ( -B - D ) / A ), ( -B + D ) / A );
        float t1 = ( -B - D ) / A;
        float t2 = ( -B + D ) / A;
        if(t1 < 0.0 && t2 < 0.0)
            return false;

        if(min(t1, t2) < 0.0)
        {
            time = max(t1,t2);
            return true;
        }
        time = min(t1, t2);
        return true;
    }
    return false;
}

bool IntersectTriangle (SRay ray, vec3 v1, vec3 v2, vec3 v3, out float time )
{
    time = -1.0;
    vec3 A = v2 - v1;
    vec3 B = v3 - v1;
    // no need to normalize vector
    vec3 N = cross(A, B);
    // N
    // // Step 1: finding P
    // // check if ray and plane are parallel ?
    float NdotRayDirection = dot(N, ray.Direction);
    if (abs(NdotRayDirection) < EPSILON)
        return false;
    // they are parallel so they don't intersect !
    // compute d parameter using equation 2
    float d = dot(N, v1);
    // compute t (equation 3)
    float t = -(dot(N, ray.Origin) - d) / NdotRayDirection;
    // check if the triangle is in behind the ray
    if (t < 0.0)
        return false;
    // the triangle is behind
    // compute the intersection point using equation 1
    vec3 P = ray.Origin + t * ray.Direction;
    // // Step 2: inside-outside test //
    vec3 C;
    // vector perpendicular to triangle's plane
    // edge 0
    vec3 edge1 = v2 - v1;
    vec3 VP1 = P - v1;
    C = cross(edge1, VP1);
    if (dot(N, C) < 0.0)
        return false;
    // P is on the right side
    // edge 1
    vec3 edge2 = v3 - v2;
    vec3 VP2 = P - v2;
    C = cross(edge2, VP2);
    if (dot(N, C) < 0.0)
        return false;
    // P is on the right side
    // edge 2
    vec3 edge3 = v1 - v3;
    vec3 VP3 = P - v3;
    C = cross(edge3, VP3);
    if (dot(N, C) < 0.0)
        return false;
    // P is on the right side;
    time = t;
    return true;
    // this ray hits the triangle
}

void HitTriangle(SRay ray, STriangle triangle, float test, inout SIntersection intersect, inout bool result) {
    intersect.Time = test;
    intersect.Point = ray.Origin + ray.Direction * test;
    vec3 edge1 = triangle.v2 - triangle.v1;
    vec3 edge2 = triangle.v3 - triangle.v1;
    intersect.Normal = normalize(cross(edge1, edge2));
    if (dot(intersect.Normal, ray.Direction) > 0.0) { intersect.Normal = -intersect.Normal; }
    intersect.Color = materials[triangle.MaterialIdx].Color;
    intersect.LightCoeffs = materials[triangle.MaterialIdx].LightCoeffs;
    intersect.ReflectionCoef = materials[triangle.MaterialIdx].ReflectionCoef;
    intersect.RefractionCoef = materials[triangle.MaterialIdx].RefractionCoef;
    intersect.MaterialType = materials[triangle.MaterialIdx].MaterialType;
    result = true;
}

bool Raytrace ( SRay ray, float start, float final, inout SIntersection intersect )
{
    bool result = false;
    float test = start;
    intersect.Time = final;
    //calculate intersect with spheres
    for(int i = 0; i < SPHERE_COUNT; i++)
    {
        SSphere sphere = spheres[i];
        if( IntersectSphere (sphere, ray, start, final, test ) && test < intersect.Time )
        {
            intersect.Time = test;
            intersect.Point = ray.Origin + ray.Direction * test;
            intersect.Normal = normalize ( intersect.Point - spheres[i].Center );
            intersect.Color = materials[sphere.MaterialIdx].Color;
            intersect.LightCoeffs = materials[sphere.MaterialIdx].LightCoeffs;
            intersect.ReflectionCoef = materials[sphere.MaterialIdx].ReflectionCoef;
            intersect.RefractionCoef = materials[sphere.MaterialIdx].RefractionCoef;
            intersect.MaterialType = materials[sphere.MaterialIdx].MaterialType;
            result = true;
        }
	}
    //calculate intersect with tetrahedron
    for(int i = 0; i < TETRAHEDRON_COUNT; i++)
    {
        STetrahedron tetrahedron = tetrahedrons[i];
        for (int j = 0; j < 4; j++ ) {
            STriangle triangle = tetrahedron.triangles[j];
            if(IntersectTriangle(ray, triangle.v1, triangle.v2, triangle.v3, test)
            && test < intersect.Time)
            {
                HitTriangle(ray, triangle, test, intersect, result);
            }
        }
    }
    //calculate intersect with panes
    for(int i = 0; i < PANE_COUNT; i++)
    {
        SPane pane = panes[i];
        for (int j = 0; j < 2; j++) {
            STriangle triangle = pane.triangles[j];
            if(IntersectTriangle(ray, triangle.v1, triangle.v2, triangle.v3, test)
            && test < intersect.Time)
            {
                HitTriangle(ray, triangle, test, intersect, result);
            }
        }
    }

    //calculate intersect with cubes
    for (int i = 0; i < CUBE_COUNT; i++) {
        SCube cube = cubes[i];
        for(int j = 0; j < 6; j++)
        {
            SPane pane = cube.panes[j];
            for (int k = 0; k < 2; k++) {
                STriangle triangle = pane.triangles[k];
                if(IntersectTriangle(ray, triangle.v1, triangle.v2, triangle.v3, test)
                && test < intersect.Time)
                {
                    HitTriangle(ray, triangle, test, intersect, result);
                }
            }
        }
    }
    //calculate intersect with triangles
    for(int i = 0; i < TRIANGLE_COUNT; i++)
    {
        STriangle triangle = triangles[i];
        if(IntersectTriangle(ray, triangle.v1, triangle.v2, triangle.v3, test)
           && test < intersect.Time)
        {
            HitTriangle(ray, triangle, test, intersect, result);
        }
    }
    return result;
}

vec3 Phong ( SIntersection intersect, SLight currLight, float shadow)
{
    vec3 light = normalize ( currLight.Position - intersect.Point );
    float diffuse = max(dot(light, intersect.Normal), 0.0);
    vec3 view = normalize(uCamera.Position - intersect.Point);
    vec3 reflected= reflect( -view, intersect.Normal );
    float specular = pow(max(dot(reflected, light), 0.0), intersect.LightCoeffs.w);
    return intersect.LightCoeffs.x * intersect.Color +
        intersect.LightCoeffs.y * diffuse * intersect.Color * shadow +
        intersect.LightCoeffs.z * specular * Unit;
}

float Shadow(SLight currLight, SIntersection intersect)
{
    float shadowing = 1.0;
    vec3 direction = normalize(currLight.Position - intersect.Point);
    float distanceLight = distance(currLight.Position, intersect.Point);
    SRay shadowRay = SRay(intersect.Point + direction * EPSILON, direction);

    SIntersection shadowIntersect;

    if (Raytrace(shadowRay, 0.0, distanceLight, shadowIntersect)) {
        shadowing = 0.0;
    }

    return shadowing;
}

STriangle initTriangle(vec3 pos1, vec3 pos2, vec3 pos3, int MaterialIdx) {
    STriangle triangle;
    triangle.v1 = pos1;
    triangle.v2 = pos2;
    triangle.v3 = pos3;
    triangle.MaterialIdx = MaterialIdx;
    return triangle;
}

SPane initPane(vec3 v1, vec3 v2, vec3 v3, vec3 v4, int MaterialIdx) {
    SPane pane;
    pane.triangles[0] = initTriangle(v1, v2, v3, MaterialIdx);
    pane.triangles[1] = initTriangle(v1, v2, v4, MaterialIdx);
    return pane;
}

SCube initCube(vec3 pos, vec3 angle, int size, int MaterialIdx) {
    SCube cube;

    vec3 v1 = rotate3D(vec3(0,0,0), angle) * size + pos; // A
    vec3 v2 = rotate3D(vec3(0,1,0), angle) * size + pos; // B
    vec3 v3 = rotate3D(vec3(1,0,0), angle) * size + pos; // C
    vec3 v4 = rotate3D(vec3(1,1,0), angle) * size + pos; // D

    vec3 v5 = rotate3D(vec3(0,0,1), angle) * size + pos; // H
    vec3 v6 = rotate3D(vec3(0,1,1), angle) * size + pos; // E
    vec3 v7 = rotate3D(vec3(1,0,1), angle) * size + pos; // G
    vec3 v8 = rotate3D(vec3(1,1,1), angle) * size + pos; // F

    cube.panes[0] = initPane(v2, v3, v1,  v4, MaterialIdx); // ABCD
    cube.panes[1] = initPane(v6, v7, v5,  v8, MaterialIdx); // HEGF
    cube.panes[2] = initPane(v2, v5, v1, v6, MaterialIdx); // ABHE
    cube.panes[3] = initPane(v4, v7, v3, v8, MaterialIdx); // CDGF
    cube.panes[4] = initPane(v3, v5, v1, v7, MaterialIdx); // ACHG
    cube.panes[5] = initPane(v4, v6, v2, v8, MaterialIdx); // BDEF

    return cube;
}

STetrahedron initTetrahedron(vec3 pos, vec3 angle, int size, int MaterialIdx) {
    STetrahedron tetrahedron;

    vec3 v1 = rotate3D(vec3(0, 0, 0), angle) * size + pos;
    vec3 v2 = rotate3D(vec3(1, 0, 0), angle) * size + pos;
    vec3 v3 = rotate3D(vec3(0.5, 1, 0), angle) * size + pos;
    vec3 v4 = rotate3D(vec3(0.5, 0.5, 1), angle) * size + pos;

    tetrahedron.triangles[0] = initTriangle(v1, v2, v3, MaterialIdx);
    tetrahedron.triangles[1] = initTriangle(v1, v2, v4, MaterialIdx);
    tetrahedron.triangles[2] = initTriangle(v1, v3, v4, MaterialIdx);
    tetrahedron.triangles[3] = initTriangle(v2, v3, v4, MaterialIdx);
    tetrahedron.MaterialIdx = MaterialIdx;
    return tetrahedron;
}

SCamera initializeCamera(vec3 pos, vec3 dir, vec2 scope)
{
    dir.xz *= rotate2D(iMouseDir.y);
    dir.yz *= rotate2D(iMouseDir.x);

    SCamera camera;
	camera.Position = pos;
    camera.Direction = dir;
	camera.Scope = scope;
    return camera;
}

void initRoom(vec3 offset, int size) {
    vec3 v1 = vec3(0, 0, 0) * size + offset;
    vec3 v2 = vec3(0, 1, 1) * size + offset;
    vec3 v3 = vec3(0, 1, 0) * size + offset;
    vec3 v4 = vec3(0, 0, 1) * size + offset;
    vec3 v5 = vec3(1, 1, 1) * size + offset;
    vec3 v6 = vec3(1, 0, 1) * size + offset;
    vec3 v7 = vec3(1, 1, 0) * size + offset;
    vec3 v8 = vec3(1, 0, 0) * size + offset;

    // left wall
    panes[0] = initPane(v1, v2, v3, v4, 1);
    // front wall
    panes[1] = initPane(v4, v5, v2, v6, 3);
    // right wall
    panes[2] = initPane(v6, v7, v5, v8, 2);
    // floor
    panes[3] = initPane(v1, v6, v4, v8, 0);
    // ceiling
    panes[4] = initPane(v3, v5, v2, v7, 0);
    // back wall
    panes[5] = initPane(v1, v7, v3, v8, 0);
}

void initializeDefaultScene()
{
    initRoom(vec3(-15.0, -15.0, -15.0), 50);

    /** TRIANGLES **/
    // Stub
    triangles[0] = initTriangle(vec3(-100.0, -100.0, -100.0),vec3(-100.0, -100.0, -100.0),vec3(-100.0, -100.0, -100.0),0);

    /** SPHERES **/
    spheres[0].Center = vec3(2.0,1.0,2.0);
    spheres[0].Radius = 2.0;
    spheres[0].MaterialIdx = 4;

    spheres[1].Center = vec3(-3.0,-2.0,-4.0);
    spheres[1].Radius = 1.0;
    spheres[1].MaterialIdx = 5;

    /** CUBES **/
    cubes[0] = initCube(vec3( 6.0, -1.0,  -4.0), vec3(-10.0, -15.0, 40.0), 1, 7);
    cubes[1] = initCube(vec3(-8.0,  -2.0, -14.0), vec3(0), 5, 4);
    cubes[2] = initCube(vec3( 8.0,  -2.0, -14.0), vec3(0), 5, 4);

    /** TETRAHEDRONS **/
    tetrahedrons[0] = initTetrahedron(vec3(-7.0, 3.0, 1.0), vec3(0,25,-30), 4, 7);
}

void initializeDefaultLightMaterials() {
    //** LIGHT **//
    uLight.Position = vec3(4.0, 15.0, -4.0f);
    uLight2.Position = vec3(4.1, 15.1, -4.0f);
    /** MATERIALS **/
    vec4 lightCoefs = vec4(0.4, 0.9, 0.0, 512.0);
    materials[0].Color = vec3(1.0, 1.0, 1.0);
    materials[0].LightCoeffs = vec4(lightCoefs);
    materials[0].ReflectionCoef = 0.7;
    materials[0].RefractionCoef = 1.0;
    materials[0].MaterialType = DIFFUSE_REFLECTION;

    materials[1].Color = vec3(1.0, 0.0, 0.0);
    materials[1].LightCoeffs = vec4(lightCoefs);
    materials[1].ReflectionCoef = 0.2;
    materials[1].RefractionCoef = .3;
    materials[1].MaterialType = DIFFUSE_REFLECTION;

    materials[2].Color = vec3(0.0, 1.0, 0.0);
    materials[2].LightCoeffs = vec4(lightCoefs);
    materials[2].ReflectionCoef = 1;
    materials[2].RefractionCoef = 1;
    materials[2].MaterialType = DIFFUSE_REFLECTION;

    materials[3].Color = normalize(vec3(35, 255, 254));
    materials[3].LightCoeffs = vec4(lightCoefs);
    materials[3].ReflectionCoef = 0.001;
    materials[3].RefractionCoef = 1;
    materials[3].MaterialType = DIFFUSE_REFLECTION;

    materials[4].Color = normalize(vec3(176, 174, 242));
    materials[4].LightCoeffs = vec4(lightCoefs);
    materials[4].ReflectionCoef = 0.5;
    materials[4].RefractionCoef = 1;
    materials[4].MaterialType = MIRROR_REFLECTION;

	materials[5].Color = normalize(vec3(251, 255, 0));
	materials[5].LightCoeffs = vec4(lightCoefs);
	materials[5].ReflectionCoef = 0.3;
	materials[5].RefractionCoef = 1;
	materials[5].MaterialType = DIFFUSE_REFLECTION;

	materials[6].Color = uMaterialColor;
	materials[6].LightCoeffs = vec4(lightCoefs);
	materials[6].ReflectionCoef = uMaterialReflectivity;
	materials[6].RefractionCoef = uMaterialTransparency;
	materials[6].MaterialType = DIFFUSE_REFLECTION;

	materials[7].Color = normalize(vec3(255, 255, 255));
	materials[7].LightCoeffs = vec4(lightCoefs);
	materials[7].ReflectionCoef = 0.04;
	materials[7].RefractionCoef = 1.5;
	materials[7].MaterialType = REFRACTION;
}

void main(void)
{
    uv = (gl_FragCoord.xy - 0.5 * iResolution.xy) / iResolution.y;

    float start = 0.0;
    float final = BIG;

    uCamera = initializeCamera(iCamPos, normalize(vec3(uv, 1.0)), iScope);
    initializeDefaultScene();
    initializeDefaultLightMaterials();
    SRay ray = GenerateRay( uCamera);

    SIntersection intersect;
    intersect.Time = BIG;
    vec3 resultColor = vec3(0,0,0);

    STracingRay trRay = STracingRay(ray, 1, 0);
    pushRay(trRay);
    while(!isEmpty())
    {
        STracingRay trRay = popRay();
        ray = trRay.ray;
        SIntersection intersect;
        intersect.Time = BIG;
        start = 0;
        final = BIG;
        if (Raytrace(ray, start, final, intersect))
        {
            switch(intersect.MaterialType)
            {
                case DIFFUSE_REFLECTION:
                {
                    float shadowing = Shadow(uLight, intersect);
                    float shadowing2 = Shadow(uLight2, intersect);
                    resultColor += trRay.contribution * Phong ( intersect, uLight, (shadowing + shadowing2)/2 );
                    break;
                }
                case MIRROR_REFLECTION:
                {
                    if(intersect.ReflectionCoef < 1)
                    {
                        float contribution = trRay.contribution * (1 - intersect.ReflectionCoef);
                        float shadowing = Shadow(uLight, intersect);
                        float shadowing2 = Shadow(uLight2, intersect);
                        resultColor +=  contribution * Phong(intersect, uLight, (shadowing + shadowing2)/2 );
                    }
                    vec3 reflectDirection = reflect(ray.Direction, intersect.Normal); // creare reflection ray
                    float contribution = trRay.contribution * intersect.ReflectionCoef;
                    STracingRay reflectRay = STracingRay(SRay(intersect.Point + reflectDirection * EPSILON, reflectDirection),
                                                         contribution, trRay.depth + 1);
                    pushRay(reflectRay);
                    break;
                }
                case REFRACTION:
                {
                    bool outside = dot(ray.Direction, intersect.Normal) < 0;
                    vec3 refractionNormal = outside ? intersect.Normal : -intersect.Normal;
                    float ior = outside ? intersect.RefractionCoef : 1.0 / intersect.RefractionCoef;
                    float cosi = -dot(refractionNormal, ray.Direction);
                    float k = 1.0 - ior * ior * (1.0 - cosi * cosi);
                    vec3 refracted = vec3(0.0);

                    if (k >= 0.0) {
                        vec3 refractionDirection = normalize(ior * ray.Direction + (ior * cosi - sqrt(k)) * refractionNormal);
                        vec3 refractionOrigin = intersect.Point + refractionNormal * EPSILON;
                        SRay refractedRay = SRay(refractionOrigin, refractionDirection);

                        if (Raytrace(refractedRay, EPSILON, BIG, intersect)) {
                            refracted = intersect.Color; 
                        }
                    }
    
                    vec3 reflected = vec3(0.0);
                    if (intersect.ReflectionCoef > 0.0) {
                        vec3 reflectionDirection = reflect(ray.Direction, intersect.Normal);
                        vec3 reflectionOrigin = intersect.Point + intersect.Normal * EPSILON;
                        SRay reflectedRay = SRay(reflectionOrigin, reflectionDirection);
                        if (Raytrace(reflectedRay, EPSILON, BIG, intersect)) {
                            reflected = intersect.Color; 
                        }
                    }

                    float reflectivity = pow(1.0 - cosi, 3) * intersect.ReflectionCoef;
                    float transparency = 1.0 - reflectivity;
                    vec3 color = Phong(intersect, uLight, Shadow(uLight, intersect));
                    resultColor += trRay.contribution * (color * transparency + reflected * reflectivity + refracted * transparency);
                }
                break;

            } // switch
        } //  if
    } // while

    float r = pow(resultColor.r, 0.45);
    float g = pow(resultColor.g, 0.45);
    float b = pow(resultColor.b, 0.45);
    gl_FragColor = vec4 (resultColor, 1.0);
}
