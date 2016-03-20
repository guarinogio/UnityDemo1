using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnTriggerStayClass : MonoBehaviour
    {

        public Callback<Collider> events = null;

        public void OnTriggerStay(Collider collision)
        {
            if (events != null)
                events(collision);
        }
    }
}