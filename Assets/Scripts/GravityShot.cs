using UnityEngine;
using System;
using System.Collections.Generic;

public class GravityShot : MonoBehaviour
{
    private static string ReflectorTag = "Reflector";
    private static float ShotSpeed = 20f;

    private Vector3 m_shotDirection;
    private GravityDirection m_gravityDirection;

    private float m_timeAlive;
    private float killTime = -1;
    public ParticleSystem reflect;

    void Awake()
    {
        //ParticleSystem ps = GetComponent<ParticleSystem>();
        //var trails = ps.trails;
        //trails.enabled = true;
        //trails.ratio = 0.5f;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            Collider2D c = obj.GetComponent<Collider2D>();
            if (c != null)
                Physics2D.IgnoreCollision(c, GetComponent<Collider2D>());
        }
    }

    void FixedUpdate()
    {
        m_timeAlive += Time.deltaTime;
        if (m_timeAlive > 5f || (killTime > 0 && m_timeAlive >= killTime + 0.1f))
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
            // reflect.Play();
            reflect.GetComponent<reflect_particle>().play();
            Debug.Log("shoot" + "   :  " + reflect.isPlaying);


            InanimateObject obj = contact.collider.gameObject.GetComponent<InanimateObject>();
            if (obj)
            {
                obj.ApplyGravity(m_gravityDirection);
            }
            killTime = m_timeAlive;
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
