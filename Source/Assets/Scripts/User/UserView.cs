using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        HP.maxValue = maxAP;
        AP.maxValue = maxAP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
