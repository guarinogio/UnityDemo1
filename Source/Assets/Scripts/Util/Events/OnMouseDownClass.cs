using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnMouseDownClass : MonoBehaviour
    {

        public Callback events = null;

        public void OnMouseDown()
        {
            if (events != null)
                events();
        }
    }
}