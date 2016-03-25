using UnityEngine;
using System.Collections;
using Constants;

public class SensorController : MonoBehaviour {

    [HideInInspector]
    public Callback<Collider2D> TriggerEnter = null;
    [HideInInspector]
    public Callback<Collider2D> TriggerExit = null;
    [HideInInspector]
    public Callback<Collider2D> TriggerStay = null;
    [HideInInspector]
    public Callback<Collision2D> CollisionEnter = null;
    [HideInInspector]
    public Callback<Collision2D> CollisionExit = null;
    [HideInInspector]
    public Callback<Collision2D> CollisionStay = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (TriggerEnter != null)
        {
            TriggerEnter(other);
        }
    }

        void OnTriggerExit2D(Collider2D other)
    {
        if (TriggerExit != null)
        {
            TriggerExit(other);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (TriggerStay != null)
        {
            TriggerStay(other);
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (CollisionEnter != null)
        {
            CollisionEnter(other);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (CollisionExit != null)
        {
            CollisionExit(other);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (CollisionStay != null)
        {
            CollisionStay(other);
        }
    }

}
