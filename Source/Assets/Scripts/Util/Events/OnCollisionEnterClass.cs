using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{


    public class OnCollisionEnterClass : MonoBehaviour
    {

        public Callback<Collision> events = null;

        public void OnCollisionEnter(Collision collision)
        {
            if (events != null)
                events(collision);
        }
    }
}