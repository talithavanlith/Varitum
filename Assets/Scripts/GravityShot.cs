using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class GravityShot : MonoBehaviour
{
    private static int MaxReflections = 5;
    private static int LayerMask = 1 << 8;
    private static string ReflectorTag = "Reflector";
    private static float ShotSpeed = 70f;

    private Vector3 m_shotStart, m_shotDirection;
    private GravityDirection m_gravityDirection;
    private float m_tValue; // distance of shot along ray

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        ConstructLines();

        m_tValue += ShotSpeed * Time.deltaTime;

        TempKill();
    }

    float timeAlive;
    void TempKill()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 1f)
            Destroy(gameObject);
    }


    private void ConstructLines()
    {
        List<Vector3> linePoints = new List<Vector3>();
        linePoints.Add(m_shotStart);

        Vector2 point = m_shotStart;
        Vector2 direction = m_shotDirection;
        RaycastHit2D hit;

        int reflectionCount = 0;
        float tValueCount = 0;

        while (reflectionCount <= MaxReflections)
        {
            direction.Normalize();
            hit = Physics2D.Raycast(point, direction, 100, LayerMask);

            // Nothing hit
            if (!hit.collider)
            {
                linePoints.Add(point + (m_tValue - tValueCount) * direction);
                break;
            }

            float magnitude = (hit.point - point).magnitude;
            linePoints.Add(point + direction * Mathf.Min((m_tValue - tValueCount), magnitude));
            tValueCount += Mathf.Min((m_tValue - tValueCount), magnitude);
            // Inanimate object hit
            /*InanimateObject obj = hit.collider.gameObject.GetComponent<InanimateObject>();
            if (obj)
            {
                // TODO: Store object to affect it after animation is complete
                obj.ApplyGravity(gravityDirection);
                break;
            }*/

            // Reflector hit
            /*else*/ if (hit.collider.gameObject.CompareTag(ReflectorTag) && tValueCount < m_tValue)
            {
                reflectionCount++;

                direction = Vector2.Reflect(direction, hit.normal);
                point = hit.point + 0.01f * direction;
                //tValueCount += magnitude;
            }
            else break; // Object hit unaffected
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());


        lineRenderer.endWidth = 0.05f;
        lineRenderer.startWidth = 0.2f;
        //Gradient gradient = new Gradient();
        //gradient.SetKeys(new GradientColorKey[]
        //{
        //    new GradientColorKey(new Color(0x72, 0xD9, 0xEC), 0.9f),
        //    //new GradientColorKey(new Color(0xEC, 0x85, 0x72), 0.1f)
        //},
        //new GradientAlphaKey[]
        //{
        //    new GradientAlphaKey(1.0f, 0.5f),
        //});
        //lineRenderer.colorGradient = gradient;
        //lineRenderer.material = new Material(Shader.Find("Standard"));
        //lineRenderer.material.color = new Color(0x72, 0xD9, 0xEC);
    }

    internal void InitShot(Vector3 shotStart, Vector3 shotDirection, GravityDirection gravityDirection)
    {
        m_shotStart = shotStart;
        m_shotStart.z = 0;

        m_shotDirection = shotDirection.normalized;
        m_shotDirection.z = 0;

        m_gravityDirection = gravityDirection;
        m_tValue = 0;
    }
}
