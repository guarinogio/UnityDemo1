using UnityEngine;
using System.Collections;
using System;

public class BasicShield : ItemElement
{

    public bool isDisable;
    public bool isEquiped;
    public GameObject gameObject;
    public SensorController sensor;

    [HideInInspector]
    public override bool _isDisable { get { return isDisable; } set { isDisable = value; } }

    [HideInInspector]
    public override bool _isEquiped { get { return isEquiped; } set { isEquiped = value; } }

    [HideInInspector]
    public override GameObject _gameObject { get { return gameObject; } set { gameObject = value; } }


    // Use this for initialization
    void Start()
    {
        ActivateFloorSensor(true);
    }

    void ActivateFloorSensor(bool activate)
    {
        if (activate)
        {
            sensor.TriggerEnter += TriggerEnter;
        }
        else
        {
            sensor.TriggerEnter -= TriggerEnter;
        }
    }

    private void TriggerEnter(Collider2D arg1)
    {
        Debug.Log("Bloqueo");
    }

    public override void Do(bool flag)
    {
        if (flag)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public override void Special(bool flag) { }
    public override void Charge(bool flag) { }


   
}
