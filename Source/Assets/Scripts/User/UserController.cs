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

    [SerializeField]
    private SensorController colliderSensor;

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
            controller.PressR1 += PressAttack;
            controller.PressL1 += PressBlock;
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
            controller.PressR1 -= PressAttack;
            controller.PressL1 += PressBlock;
        }
    }

    void ActivateFloorSensor(bool activate)
    {
        if (activate)
        {
            floorSensor.TriggerStay += FloorTriggerStay;
            floorSensor.TriggerExit += FloorTriggerExit;
            colliderSensor.CollisionEnter += CollisionEnter;
        }
        else
        {
            floorSensor.TriggerStay -= FloorTriggerStay;
            floorSensor.TriggerExit -= FloorTriggerExit;
            colliderSensor.CollisionEnter += CollisionEnter;
        }
    }

    private void CollisionEnter(Collision2D arg1)
    {
        if (arg1.gameObject.layer == 9)
        {
            if (!data.isEvading)
            {
                StartCoroutine(Repel(data.evadeTime));
            }
        }
    }

    private void FloorTriggerExit(Collider2D arg1)
    {
        if (arg1.gameObject.tag == "floor")
        {
            data.isJumping = true;
        }
    }

    private void FloorTriggerStay(Collider2D arg1)
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
        //view.element.transform.Rotate(new Vector3(0,180));
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

    void PressAttack()
    {
        data.sword.Do();
        view.BattleState(BATTLESTATE.ATTACK);
    }

    void PressBlock(bool isPressed)
    {
        if (isPressed)
        {
            view.BattleState(BATTLESTATE.BLOCK);
        }
        else
        {
            view.BattleState(BATTLESTATE.IDLE);
        }
    }


    private IEnumerator WaitToJumpAgain(float v)
    {
        canJumpAgain = false;
        yield return new WaitForSeconds(v);
        canJumpAgain = true;
    }

    private IEnumerator Repel(float v)
    {
        if (lastDirection == DIRECTION.RIGHT)
        {
            //view.rigid.velocity = new Vector2(data.evadeSpeed * -1, view.rigid.velocity.y);
            controller.PressLEFT -= PressLEFT;
            controller.PressRIGHT -= PressRIGHT;
            view.rigid.AddForce(new Vector2(-350f, 0));
        }
        else
        {
            //view.rigid.velocity = new Vector2(data.evadeSpeed, view.rigid.velocity.y);
            controller.PressLEFT -= PressLEFT;
            controller.PressRIGHT -= PressRIGHT;
            view.rigid.AddForce(new Vector2(350f, 0));
        }

        yield return new WaitForSeconds(v);
        controller.PressLEFT += PressLEFT;
        controller.PressRIGHT += PressRIGHT;
        //view.rigid.velocity = new Vector2(0, view.rigid.velocity.y);
    }

    private IEnumerator DoEvade(float v)
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
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
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
