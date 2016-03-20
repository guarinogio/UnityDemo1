using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class OnWillRenderCallbackClass : MonoBehaviour
    {

        public Callback events = null;

        public void OnWillRenderCallback()
        {
            if (events != null)
                events();
        }
    }
}