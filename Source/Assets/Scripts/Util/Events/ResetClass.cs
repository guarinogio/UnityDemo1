using UnityEngine;
using System;
using System.Collections;

namespace GameScripts.GameElementSystem
{

    
    public class ResetClass : MonoBehaviour
    {

        public Callback events = null;

        public void Reset()
        {
            if (events != null)
                events();
        }
    }
}