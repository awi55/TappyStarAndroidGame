using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    Rigidbody2D rb;
    public float upForce;
    bool started;
    bool gameOver;
    public float rotation;

    private int hitScoreChecker = 0;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.isKinematic = false;
                GameManager.instance.GameStart();
            }
        }
        else if (started && !gameOver)
        {
            transform.Rotate(0, 0, rotation);
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        gameOver = true;
        GameManager.instance.GameOver();
        GetComponent<Animator>().Play("star");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Other Collider:" + col.name);

        if (col.gameObject.tag == "Statue" && !gameOver)
        {
            gameOver = true;
            GameManager.instance.GameOver();
            GetComponent<Animator>().Play("star");
        }
        
        if(col.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            if (hitScoreChecker == 0)
            {
                ScoreManager.instance.IncrementScore();
                hitScoreChecker = 1;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (hitScoreChecker == 1)
        {
            hitScoreChecker = 0;
        }
    }
}