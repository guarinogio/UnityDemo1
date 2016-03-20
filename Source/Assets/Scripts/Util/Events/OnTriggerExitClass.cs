using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnTriggerExitClass : MonoBehaviour
    {

        public Callback<Collider> events = null;

        public void OnTriggerExit(Collider collision)
        {
            if (events != null)
                events(collision);
        }
    }
}