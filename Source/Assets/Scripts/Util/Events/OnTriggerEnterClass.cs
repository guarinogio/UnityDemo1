using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnTriggerEnterClass : MonoBehaviour
    {

        public Callback<Collider> events = null;

        public void OnTriggerEnter(Collider collision)
        {
            if (events != null)
                events(collision);
        }
    }
}