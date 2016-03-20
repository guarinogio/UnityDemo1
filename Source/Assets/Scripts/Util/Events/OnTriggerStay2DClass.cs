using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnTriggerStay2DClass : MonoBehaviour
    {

        public Callback<Collider2D> events = null;

        public void OnTriggerStay2D(Collider2D collision)
        {
            if (events != null)
                events(collision);
        }
    }
}