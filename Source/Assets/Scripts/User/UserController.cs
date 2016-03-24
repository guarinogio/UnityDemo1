using UnityEngine;
using System.Collections;
using System;
using Constants;

public class UserController : MonoBehaviour {

    [SerializeField]
    private UserData data;

    [SerializeField]
    private UserView view;

    [SerializeField]
    private ControllerBeahaviour controller;

    [SerializeField]
    private SensorController floorSensor;

    private bool canJumpAgain = true;
    private DIRECTION lastDirection;

    // Use this for initialization
    void Start () {
        view.Init("Gio",100,100);
        ActivateInput(true);
        ActivateFloorSensor(true);
    }
	
	// Update is called once per frame


	void FixedUpdate () {
        if (!controller.HorizontalAxisPressed && !data.isEvading)
        {
            data.isRuning = false;
            data.isMoving = false;
            view.MoveState(MOVESTATE.IDLE);
            view.rigid.velocity = new Vector2(0, view.rigid.velocity.y);
        }

        Debug.Log(view.rigid.velocity.x);
    }

    void ActivateInput (bool activate){
        if (activate)
        {
            controller.PressUP += PressUP;
            controller.PressDOWN += PressDOWN;
            controller.PressLEFT += PressLEFT;
            controller.PressRIGHT += PressRIGHT;
            //controller.PressA += PressJUMP;
            controller.PressA += PressEVADE;
            controller.PressB += PressRUN;
        }
        else
        {
            controller.PressUP -= PressUP;
            controller.PressDOWN -= PressDOWN;
            controller.PressLEFT -= PressLEFT;
            controller.PressRIGHT -= PressRIGHT;
            //controller.PressA -= PressJUMP;
            controller.PressA -= PressEVADE;
            controller.PressB -= PressRUN;
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
        lastDirection = DIRECTION.LEFT;
        if (!data.isEvading)
        {
            if (data.isRuning)
            {
                view.MoveState(MOVESTATE.RUN);
                if (view.rigid.velocity.x >= data.maxSpeed * -1)
                {
                    view.rigid.velocity = new Vector2((view.rigid.velocity.x + (data.aceleration * Time.fixedDeltaTime * -1)), view.rigid.velocity.y);

                }
                else
                {
                    view.rigid.velocity = new Vector2(data.maxSpeed * -1, view.rigid.velocity.y);
                }
            }
            else
            {
                view.MoveState(MOVESTATE.BACK);
                data.isMoving = true;
                view.rigid.velocity = new Vector2(data.moveSpeed * -1, view.rigid.velocity.y);
            }
        }

    }

    void PressRIGHT()
    {
        lastDirection = DIRECTION.RIGHT;
        if (!data.isEvading)
        {
            if (data.isRuning)
            {
                view.MoveState(MOVESTATE.RUN);
                if (view.rigid.velocity.x <= data.maxSpeed)
                {
                    view.rigid.velocity = new Vector2(view.rigid.velocity.x + (data.aceleration * Time.fixedDeltaTime), view.rigid.velocity.y);

                }
                else
                {
                    view.rigid.velocity = new Vector2(data.maxSpeed, view.rigid.velocity.y);
                }
            }
            else
            {
                view.MoveState(MOVESTATE.FORWARD);
                data.isMoving = true;
                view.rigid.velocity = new Vector2(data.moveSpeed, view.rigid.velocity.y);
            }
        }
    }

    void PressJUMP()
    {
        if (canJumpAgain && !data.isEvading)
        {
            StartCoroutine(WaitToJumpAgain(0.1f));
            if (!data.isJumping)
            {
                data.isJumping = true;
                view.rigid.AddForce(new Vector2(0f, data.jumpForce));
            }
        }
    }

    void PressRUN(bool isRuning)
    {
            if (!data.isJumping && data.isMoving) 
            {
                data.isRuning = isRuning;
            }
    }

    void PressEVADE()
    {
        if (!data.isJumping)
        {
            StartCoroutine(DoEvade(data.evadeTime));
        }
    }


    private IEnumerator WaitToJumpAgain(float v)
    {
        canJumpAgain = false;
        yield return new WaitForSeconds(v);
        canJumpAgain = true;
    }

    private IEnumerator DoEvade(float v)
    {
        data.isEvading = true;
        view.BattleState(BATTLESTATE.EVADE);
        if (lastDirection == DIRECTION.RIGHT)
        {
            if (!data.isMoving)
            {
                view.rigid.velocity = new Vector2(data.evadeSpeed * -1, view.rigid.velocity.y);
            }
            else
            {
                view.rigid.velocity = new Vector2(data.evadeSpeed, view.rigid.velocity.y);
            }
        }
        else
        {
            if (!data.isMoving)
            {
                view.rigid.velocity = new Vector2(data.evadeSpeed, view.rigid.velocity.y);
            }
            else
            {
                view.rigid.velocity = new Vector2(data.evadeSpeed*-1, view.rigid.velocity.y);
            }
        }
        yield return new WaitForSeconds(v);

        data.isEvading = false;
        view.BattleState(BATTLESTATE.IDLE);
        view.rigid.velocity = new Vector2(0, view.rigid.velocity.y);
    }
}
