using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {


    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        int i = Random.Range(0, 1);

        if(i == 0)
            direction = Vector2.one.normalized;
        else
            direction = -Vector2.one.normalized;

        radius = transform.localScale.x / 2;
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0 )
            direction.y = -direction.y;

        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
            direction.y = -direction.y;


        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Right Player wins");
            
            enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            

        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left Player wins");
            
            enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "paddle")
        {
            bool isRight = collision.GetComponent<Actor>().isRight;

            speed += 2;

            //if hitting right paddle then go left
            if(isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            //if hitting right paddle then go right
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }


}
