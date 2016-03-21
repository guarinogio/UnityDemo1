using UnityEngine;
using System.Collections;
using System;

public class UserController : MonoBehaviour {

    [SerializeField]
    private UserData data;

    [SerializeField]
    private UserView view;

    [SerializeField]
    private ControllerBeahaviour controller;

    [SerializeField]
    private SensorController floorSensor;

    // Use this for initialization
    void Start () {
        view.Init("Gio",100,100);
        ActivateInput(true);
        ActivateFloorSensor(true);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void ActivateInput (bool activate){
        if (activate)
        {
            controller.PressUP += PressUP;
            controller.PressDOWN += PressDOWN;
            controller.PressLEFT += PressLEFT;
            controller.PressRIGHT += PressRIGHT;
            controller.PressJUMP += PressJUMP;
        }
        else
        {
            controller.PressUP -= PressUP;
            controller.PressDOWN -= PressDOWN;
            controller.PressLEFT -= PressLEFT;
            controller.PressRIGHT -= PressRIGHT;
            controller.PressJUMP -= PressJUMP;
        }
    }

    void ActivateFloorSensor(bool activate)
    {
        if (activate)
        {
            floorSensor.TriggerStay += TriggerStay;
            floorSensor.TriggerExit += TriggerExit;
        }
        else
        {
            floorSensor.TriggerStay -= TriggerStay;
            floorSensor.TriggerExit -= TriggerExit;
        }
    }

    private void TriggerExit(Collider2D arg1)
    {
        if (arg1.gameObject.tag == "floor")
        {
            controller.isJumping = true;
        }
    }

    private void TriggerStay(Collider2D arg1)
    {
        if (arg1.gameObject.tag == "floor")
        {
            controller.isJumping = false;
        }
    }

    void PressUP(){

    }

    void PressDOWN()
    {

    }

    void PressLEFT()
    {

    }

    void PressRIGHT()
    {

    }

    void PressJUMP()
    {
        if (!controller.isJumping)
        {
            controller.isJumping = true;
            Debug.Log("Hola");
            view.rigid.AddForce(new Vector2(0f, data.jumpForce));
        }
    }
}
