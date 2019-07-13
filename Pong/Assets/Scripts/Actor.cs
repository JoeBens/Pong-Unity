using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {




    [SerializeField]
    float speedPlayer;

    [SerializeField]
    float speedEnemy;

    float height;

    string input;
    public bool isRight;

    Ball ball;


    // Use this for initialization
    void Start () {
        height = transform.localScale.y;

        ball = FindObjectOfType<Ball>();

    }


    public void Init( bool isRightPaddle) {

        isRight = isRightPaddle;


        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            //place the paddle on the right of the screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            GetComponent<SpriteRenderer>().color = Color.blue;

            input = "PaddleRight";
        }
        else
        {
            //place the paddle on the left of the screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            GetComponent<SpriteRenderer>().color = Color.red;

            input = "PaddleLeft";
        }

        transform.position = pos;

        transform.name = input;

    }



    // Update is called once per frame
    void Update () {


        if (isRight)
        {
            float move = Input.GetAxis(input) * Time.deltaTime * speedPlayer;
            if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
                move = 0;

            if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
                move = 0;

            transform.Translate(move * Vector2.up);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, ball.transform.position.y), speedEnemy * Time.deltaTime);
        }
        

    



        
		
	}
}
