using UnityEngine;
using System.Collections;
using System;

public class ControllerBeahaviour : MonoBehaviour {

    [Header("Control"), Space(10)]
    public bool isAnyPressed = false;
    public bool HorizontalAxisPressed = false;
    public bool VerticalAxisPressed = false;
    public bool leftPressed = false;
    public bool rightPressed = false;
    public bool APressed = false;
    public bool BPressed = false;
    public bool R1Pressed = false;
    public bool R2Pressed = false;
    public bool L1Pressed = false;
    public bool L2Pressed = false;

    [HideInInspector]
    public KeyCode A {
        get { return KeyCode.Joystick1Button0; }
    }

    [HideInInspector]
    public KeyCode B
    {
        get { return KeyCode.Joystick1Button1; }
    }
    [HideInInspector]
    public KeyCode L1
    {
        get { return KeyCode.Joystick1Button4; }
    }

    [HideInInspector]
    public KeyCode R1
    {
        get { return KeyCode.Joystick1Button5; }
    }



    [HideInInspector]
    public KeyCode attack;
    [HideInInspector]
    public KeyCode superMove;
    [HideInInspector]
    public KeyCode block;
    [HideInInspector]
    public KeyCode parry;

    [HideInInspector]
    public Callback PressUP;
    [HideInInspector]
    public Callback PressDOWN;
    [HideInInspector]
    public Callback PressLEFT;
    [HideInInspector]
    public Callback PressRIGHT;
    [HideInInspector]
    public Callback PressA;
    [HideInInspector]
    public Callback<bool> PressB;
    [HideInInspector]
    public Callback PressR1;
    [HideInInspector]
    public Callback PressR2;
    [HideInInspector]
    public Callback PressL1;
    [HideInInspector]
    public Callback PressL2;


    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) { }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (PressUP != null)
            {
                PressUP();
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (PressDOWN != null)
            {
                PressDOWN();
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (PressLEFT != null)
            {
                PressLEFT();
            }
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (PressRIGHT != null)
            {
                PressRIGHT();
            }
        }

        if (Input.GetKeyDown(A))
        {
            if (PressA != null)
            {
                PressA();
            }
        }

        if (Input.GetKeyDown(L1))
        {
            if (PressL1 != null)
            {
                PressL1();
            }
        }

        if (Input.GetKeyDown(R1))
        {
            if (PressR1 != null)
            {
                PressR1();
            }
        }

        if (Input.GetKey(B))
        {
            if (PressB != null)
            {
                PressB(true);
            }
        }

        if (Input.GetKeyUp(B))
        {
            PressB(false);
        }


        isAnyPressed = (Input.anyKey || Input.anyKeyDown);
        HorizontalAxisPressed = Input.GetAxis("Horizontal") != 0;
        VerticalAxisPressed = Input.GetAxis("Vertical") != 0;
        leftPressed = Input.GetAxisRaw("Horizontal") < 0;
        rightPressed = Input.GetAxisRaw("Horizontal") > 0;
        APressed = Input.GetKey(A);
        BPressed = Input.GetKey(B);
        R1Pressed = false;
        R2Pressed = false;
        L1Pressed = false;
        L2Pressed = false;
    }
}
