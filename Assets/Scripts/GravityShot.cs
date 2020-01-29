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

        transform.position += m_shotDirection.normalized * ShotSpeed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        ContactPoint2D contact = collision.GetContact(0);
        if (contact.collider.gameObject.CompareTag(ReflectorTag))
        {
            m_shotDirection = Vector2.Reflect(m_shotDirection, contact.normal);
            m_shotDirection.Normalize();
        }
        else
        {
            InanimateObject obj = contact.collider.gameObject.GetComponent<InanimateObject>();
            if (obj)
            {
                obj.ApplyGravity(m_gravityDirection);
            }

            m_shotDirection = Vector3.zero;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    internal void InitShot(Vector3 shotDirection, GravityDirection gravityDirection)
    {
        m_shotDirection = shotDirection;
        m_shotDirection.z = 0;

        m_gravityDirection = gravityDirection;
    }
}
