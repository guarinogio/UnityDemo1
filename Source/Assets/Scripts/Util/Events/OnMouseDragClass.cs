using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnMouseDragClass : MonoBehaviour
    {

        public Callback events = null;

        public void OnMouseDrag()
        {
            if (events != null)
                events();
        }
    }
}