using UnityEngine;
using System.Collections;
using System;

public class ControllerBeahaviour : MonoBehaviour {

    [Header("Control"), Space(10)]
    public bool isAnyPressed = false;
    public bool HorizontalAxisPressed = false;
    public bool VerticalAxisPressed = false;
    public bool XPressed = false;
    public bool R1Pressed = false;
    public bool R2Pressed = false;
    public bool L1Pressed = false;
    public bool L2Pressed = false;


    [Header("ControlButtom"), Space(10)]
    public bool canXAgain = true;
    public bool canR1Again = true;
    public bool canR2Again = true;

    [Header("ControlButtom"), Space(10)]
    public float waitToPressX = 0.1f;

    [HideInInspector]
    public KeyCode X {
        get { return KeyCode.Joystick1Button0; }
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
    public Callback PressX;
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

        if (Input.GetKeyDown(X) && canXAgain)
        {
            if (PressX != null)
            {
                PressX();
                //StartCoroutine(SetX());
                StartCoroutine(WaitToXAgain(waitToPressX));
            }
        }

        isAnyPressed = (Input.anyKey || Input.anyKeyDown);
        HorizontalAxisPressed = Input.GetAxis("Horizontal") != 0;
        VerticalAxisPressed = Input.GetAxis("Vertical") != 0;
        XPressed = Input.GetKeyDown(X);
        R1Pressed = false;
        R2Pressed = false;
        L1Pressed = false;
        L2Pressed = false;
    }

    private IEnumerator WaitToXAgain(float v)
    {
        canXAgain = false;
        yield return new WaitForSeconds(v);
        canXAgain = true;
    }

    IEnumerator SetX()
    {
        PressX();
        yield return null;
    }
}
