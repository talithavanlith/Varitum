using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GravityShot : MonoBehaviour
{
    private static int MaxReflections = 5;
    private static int LayerMask = 1 << 8;
    private static string ReflectorTag = "Reflector";

    private Vector3 shotStart;
    private Vector3 shotDirection;
    private GravityDirection gravityDirection;

    private LineRenderer lineRenderer;


    private List<Ray2D> rays = new List<Ray2D>();

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ConstructLine();
    }

    private void Update()
    {
        foreach (Ray2D ray in rays)
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }

    void FixedUpdate()
    {
        TempKill();
    }

    float timeAlive;
    void TempKill()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 0.5f)
            Destroy(gameObject);
    }

    private Vector2 GetHitReflectionVector(RaycastHit2D hit, Vector2 incidentDirection)
    {
        return incidentDirection - (2 * Vector2.Dot(incidentDirection, hit.normal) * hit.normal);
    }

    private void ConstructLine()
    {
        List<Vector3> linePoints = new List<Vector3>();
        linePoints.Add(shotStart);
        int reflectCount = 0;

        Vector2 point = shotStart;
        Vector2 direction = shotDirection;

        RaycastHit2D hit;

        while (reflectCount <= MaxReflections)
        {
            rays.Add(new Ray2D(point, direction));
            hit = Physics2D.Raycast(point, direction, 100, LayerMask);
            // Nothing hit
            if (!hit.collider)
            {
                linePoints.Add(point + 100 * direction);
                break;
            }

            linePoints.Add(hit.point);

            // Inanimate object hit
            InanimateObject obj = hit.collider.gameObject.GetComponent<InanimateObject>();
            if (obj)
            {
                // TODO: Store object to affect it after animation is complete
                obj.ApplyGravity(gravityDirection);
                break;
            }

            // Reflector hit
            if (hit.collider.gameObject.CompareTag(ReflectorTag))
            {
                reflectCount++;

                direction = GetHitReflectionVector(hit, direction);
                point = hit.point + 0.01f * direction;
            }
            else break; // Object hit unaffected
        }

        Debug.Log(reflectCount + " Reflections");
        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
        lineRenderer.endWidth = 0.08f;
        lineRenderer.startWidth = 0.05f;
    }

    public void SetShotStartAndDirection(Vector3 start, Vector3 shotDirection, GravityDirection gravityDirection)
    {
        this.shotStart = start;
        this.shotDirection = shotDirection.normalized;
        this.gravityDirection = gravityDirection;
    }
}
