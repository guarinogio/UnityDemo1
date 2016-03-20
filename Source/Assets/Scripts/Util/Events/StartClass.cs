using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class StartClass : MonoBehaviour
    {

        public Callback events = null;

        public void Start()
        {
            if (events != null)
                events();
        }
    }
}