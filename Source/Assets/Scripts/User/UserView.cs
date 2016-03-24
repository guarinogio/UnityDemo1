using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Constants;

public class UserView : MonoBehaviour {

    public Text enemyName;
    public Slider HP;
    public Slider AP;
    public Image attackStateImage;
    public Text attackStateText;
    public Image moveStateImage;
    public Text moveStateText;

    public Collider2D colider;
    public Collider2D floorColider;
    public Rigidbody2D rigid;

    void Awake()
    {
        HP.minValue = 0;
        AP.minValue = 0;
    }

	// Use this for initialization
	public void Init(string name, int maxHP, int maxAP) {
        enemyName.text = name;
        HP.maxValue = maxHP;
        AP.maxValue = maxAP;
        HP.value = maxHP;
        AP.value = maxAP;
    }
	
    public void MoveState(MOVESTATE state)
    {
        switch (state)
        {
            case MOVESTATE.IDLE:
                moveStateText.text = "IDLE";
                moveStateImage.color = Color.white;
                break;
            case MOVESTATE.FORWARD:
                moveStateText.text = "FORWRD";
                moveStateImage.color = Color.blue;
                break;
            case MOVESTATE.BACK:
                moveStateText.text = "BACK";
                moveStateImage.color = Color.blue;
                break;
            case MOVESTATE.RUN:
                moveStateText.text = "RUN";
                moveStateImage.color = Color.red;
                break;
            case MOVESTATE.JUMP:
                break;
            case MOVESTATE.STOOP:
                break;
            case MOVESTATE.DIE:
                break;
            default:
                break;
        }
    }

    public void BattleState(BATTLESTATE state)
    {
        switch (state)
        {
            case BATTLESTATE.IDLE:
                attackStateText.text = "IDLE";
                attackStateImage.color = Color.white;
                break;
            case BATTLESTATE.ATTACK:
                break;
            case BATTLESTATE.BLOCK:
                break;
            case BATTLESTATE.PARRY:
                break;
            case BATTLESTATE.EVADE:
                attackStateText.text = "EVADE";
                attackStateImage.color = Color.green;
                break;
            default:
                break;
        }
    }


        // Update is called once per frame
        void Update () {
	
	}
}
