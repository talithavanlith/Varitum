using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class GravityShot : MonoBehaviour
{
    private static int MaxReflections = 5;
    private static int LayerMask = 1 << 8;
    private static string ReflectorTag = "Reflector";
    private static float ShotSpeed = 5f;
    private static float TrailOffset = 1f;

    private Vector3 m_shotStart, m_shotDirection;
    private GravityDirection m_gravityDirection;
    private float m_tValue; // distance of shot along ray

    private float m_startWidth = 0.2f;
    private float m_endWidth = 0.05f;
    private float m_opacity = 0.3f;
    private bool m_hit = false;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = Color.red;
        //Color c1 = Color.white;
        //Color c2 = new Color(1, 1, 1, 0);
        //lineRenderer.SetColors(Color.red, Color.black);
        //lineRenderer.SetColors(c1, c2);

    }

    void Update()
    {

        //if (m_hit && m_endWidth > 0)
        //m_endWidth -= Time.deltaTime * 0.2f;
        //else
        //m_endWidth = 0;

        //if (m_opacity > 0 && m_hit)
        {
            //m_opacity -= 0.1f * Time.deltaTime;
        }
        //else
            //Destroy(gameObject);

        m_hit = false;
        ConstructLines();

        m_tValue += ShotSpeed * Time.deltaTime;

        TempKill();
    }

    float timeAlive;
    void TempKill()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 10f)
            Destroy(gameObject);
    }


    private void ConstructLines()
    {
        List<Vector3> linePoints = new List<Vector3>();
        //float trailTValue = Ma

        Vector2 point = m_shotStart;
        Vector2 direction = m_shotDirection;
        RaycastHit2D hit;

        int reflectionCount = 0;
        float headTValueCount = 0;

        while (reflectionCount <= MaxReflections)
        {
            direction.Normalize();
            hit = Physics2D.Raycast(point, direction, 100, LayerMask);

            if (reflectionCount == 0)
            {
                //if (hit.collider)
                //{
                    //point = point + Mathf.Max(0, m_tValue - TrailOffset + 0.01f) * direction;
                //}

                //if (m_tValue - TrailOffset < (hit.point - point).magnitude)
                    linePoints.Add(point);
                //else
                    //direction = Vector2.Reflect(direction, hit.normal);
            }

            // Nothing hit
            if (!hit.collider)
            {
                linePoints.Add(point + (m_tValue - headTValueCount) * direction);
                m_hit = true;
                break;
            }

            float magnitude = (hit.point - point).magnitude;
            linePoints.Add(point + direction * Mathf.Min((m_tValue - headTValueCount), magnitude));
            headTValueCount += Mathf.Min((m_tValue - headTValueCount), magnitude);
            // Inanimate object hit
            /*InanimateObject obj = hit.collider.gameObject.GetComponent<InanimateObject>();
            if (obj)
            {
                // TODO: Store object to affect it after animation is complete
                obj.ApplyGravity(gravityDirection);
                break;
            }*/

            // Reflector hit
            /*else*/ if (hit.collider.gameObject.CompareTag(ReflectorTag) && headTValueCount < m_tValue)
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


        lineRenderer.endWidth = m_startWidth;
        lineRenderer.startWidth = m_endWidth;
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
