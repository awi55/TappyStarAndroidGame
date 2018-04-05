using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : MonoBehaviour {
    Rigidbody2D rb;
    public float speed;
    public float upDownSpeed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        MoveStatue();
        InvokeRepeating("SwitchUpDown", 0.1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SwitchUpDown()
    {
        upDownSpeed = -upDownSpeed;
        rb.velocity = new Vector2(speed, upDownSpeed);
    }

    void MoveStatue()
    {
        rb.velocity = new Vector2(-speed, upDownSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "StatueRemover")
        {
            Destroy(gameObject);
        }
    }
}
