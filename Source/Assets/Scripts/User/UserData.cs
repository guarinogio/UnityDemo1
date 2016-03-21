using UnityEngine;
using Constants;
using System.Collections;

public class UserData : MonoBehaviour
{
    [Header("States"), Space(10)]
    [Space(10)]
    #region States
    public MOVESTATE moveState;
    public BATTLESTATE battleState;
    public float HP;
    public float AP;
    #endregion States

    [Header("Stats"), Space(10)]
    #region Stats
    public float detectionRange;
    public float maxHP;
    public float maxAP;
    public float manaReplenishRatio;
    public float armor;
    public float attackSpeed;  // Delta betwen animator attacks
    public float damage;
    public float jumpForce;
    public float maxSpeed;
    public float moveForce;
    #endregion Stats

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
