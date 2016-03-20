using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnValidateClass : MonoBehaviour
    {

        public Callback events = null;

        public void OnValidate()
        {
            if (events != null)
                events();
        }
    }
}