using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Ball ball;
    public Actor actor;




    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Use this for initialization
    void Start () {


        //Convert screen's pixel coordinate into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate(ball);

        Actor one = Instantiate(actor) as Actor;
        Actor two = Instantiate(actor) as Actor;

        one.Init(true);
        two.Init(false);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
