using UnityEngine;
using System.Collections;
using System;

public class ControllerBeahaviour : MonoBehaviour {

    [Header("Control"), Space(10)]
    public bool isPressed = false;
    public bool isMoving = false;
    public bool isJumping = false;
    public bool isAttacking = false;
    public bool isSuperMoving = false;
    public bool isBlocking = false;
    public bool isParrying = false;


    [Header("ControlButtom"), Space(10)]
    public bool canJumpAgain = false;
    public bool canAttackAgain = false;
    public bool canSuperMoveAgain = false;




    public KeyCode jump {
        get { return KeyCode.Joystick1Button0; }
    }

    public KeyCode attack;
    public KeyCode superMove;
    public KeyCode block;
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
    public Callback PressJUMP;
    [HideInInspector]
    public Callback PressATTACK;
    [HideInInspector]
    public Callback PressSUPERMOVE;
    [HideInInspector]
    public Callback PressBLOCK;
    [HideInInspector]
    public Callback PressPARRY;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKeyDown) { }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if(PressUP != null)
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

        if (Input.GetKeyDown(jump) && !canJumpAgain)
        {
            StartCoroutine(WaitToJumpAgain(0.3f));
            if (PressJUMP != null)
            {
                StartCoroutine(SetJump());
            }
        }

        isPressed = (Input.anyKey || Input.anyKeyDown);
        isMoving = Input.GetAxis("Horizontal") != 0;
    }

    private IEnumerator WaitToJumpAgain(float v)
    {
        canJumpAgain = true;
        yield return new WaitForSeconds(v);
        canJumpAgain = false;
    }

    IEnumerator SetJump()
    {
        PressJUMP();
        yield return null;
    }
}
