using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnMouseUpClass : MonoBehaviour
    {

        public Callback events = null;

        public void OnMouseUp()
        {
            if (events != null)
                events();
        }
    }
}