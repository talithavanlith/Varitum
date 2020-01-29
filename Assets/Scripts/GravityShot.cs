using UnityEngine;
using System;
using System.Collections.Generic;

public class GravityShot : MonoBehaviour
{
    private static int LayerMask = 1 << 8;
    private static string ReflectorTag = "Reflector";
    private static float ShotSpeed = 20f;

    private Vector3 m_shotDirection;
    private GravityDirection m_gravityDirection;

    private float m_timeAlive;


    void Start()
    {
        //ParticleSystem ps = GetComponent<ParticleSystem>();
        //var trails = ps.trails;
        //trails.enabled = true;
        //trails.ratio = 0.5f;
    }

    void FixedUpdate()
    {
        m_timeAlive += Time.deltaTime;
        if (m_timeAlive > 5f)
            Destroy(gameObject);

        //m_shotDirection.Normalize();

        //Vector3 prevPos = transform.position;

        transform.position += m_shotDirection.normalized * ShotSpeed * Time.deltaTime;

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, m_shotDirection, 2, LayerMask);

        //RaycastHit2D checkHit = Physics2D.Raycast(transform.position, -m_shotDirection, (prevPos - transform.position).magnitude);
        //if (checkHit.collider)
        //    hit = checkHit;

        //if (hit.collider)
        //{
        //    Debug.Log(((Vector2)transform.position - hit.point).magnitude);
        //    if (hit.collider.gameObject.CompareTag(ReflectorTag))
        //    {
        //        m_shotDirection = Vector2.Reflect(m_shotDirection, hit.normal);

        //        transform.position = (Vector3)hit.point + 0.2f * m_shotDirection;
        //    }
        //    else
        //    {
        //        GetComponent<Renderer>().enabled = false;
        //        m_shotDirection = Vector2.zero;
        //    }
        //}
        //Debug.DrawRay(transform.position, m_shotDirection, Color.green);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        if(contact.collider.gameObject.CompareTag(ReflectorTag))
        {
            m_shotDirection = Vector2.Reflect(m_shotDirection, contact.normal);
            m_shotDirection.Normalize();
        }
        else
        {
            m_shotDirection = Vector3.zero;
        }
    }

    internal void InitShot(Vector3 shotDirection, GravityDirection gravityDirection)
    {
        m_shotDirection = shotDirection;
        m_shotDirection.z = 0;

        m_gravityDirection = gravityDirection;
    }
}
