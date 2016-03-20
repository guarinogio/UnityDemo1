using UnityEngine;
using System.Collections;

public class DisableMe : MonoBehaviour
{

    /// <summary>
    /// The destroy time.
    /// </summary>
    //version 2.0
    //Modified the default time from 5 secs to 2 secs.
    public float disableTimeTime = 1f;


    public void OnEnable()
    {
        Invoke("DoDisable", disableTimeTime);
    }


    public void OnDisable()
    {

    }

    public void DoDisable()
    {
        this.gameObject.SetActive(false);
    }







}
