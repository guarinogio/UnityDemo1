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


	void FixedUpdate () {
        if (!controller.HorizontalAxisPressed)
        {
            view.rigid.velocity = new Vector2(0, view.rigid.velocity.y);
        }
    }

    void ActivateInput (bool activate){
        if (activate)
        {
            controller.PressUP += PressUP;
            controller.PressDOWN += PressDOWN;
            controller.PressLEFT += PressLEFT;
            controller.PressRIGHT += PressRIGHT;
            controller.PressX += PressJUMP;
        }
        else
        {
            controller.PressUP -= PressUP;
            controller.PressDOWN -= PressDOWN;
            controller.PressLEFT -= PressLEFT;
            controller.PressRIGHT -= PressRIGHT;
            controller.PressX -= PressJUMP;
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
            data.isJumping = true;
        }
    }

    private void TriggerStay(Collider2D arg1)
    {
        if (arg1.gameObject.tag == "floor")
        {
            data.isJumping = false;
        }
    }

    void PressUP(){

    }

    void PressDOWN()
    {

    }

    void PressLEFT()
    {
        view.rigid.velocity = new Vector2(-1* data.moveSpeed, view.rigid.velocity.y);
    }

    void PressRIGHT()
    {
        view.rigid.velocity = new Vector2(data.moveSpeed, view.rigid.velocity.y);
    }

    void PressJUMP()
    {
        if (!data.isJumping)
        {
            data.isJumping = true;
            view.rigid.AddForce(new Vector2(0f, data.jumpForce));
        }
    }
}
