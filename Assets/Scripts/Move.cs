using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [HideInInspector] private Vector3 target;
    private float speed = 5.0f;
    [HideInInspector] private Vector3 direction;
    private Vector3 original_pos;

    [HideInInspector] private bool jump = false;
    private float jump_accel = 10.0f;
    private float jump_curr_time = 0f;

    // Use this for initialization
    void Start () {

        direction = new Vector3(0, 0, 1);
        target = new Vector3(0, 0, 0);
        original_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("right"))
        {
            direction.Set(1, 0, 1);
        }

        else if (Input.GetKey("left"))
        {
            direction.Set(-1, 0, 1);
        }

        else
        {
                direction.Set(0, 0, 1);
        }

        if (Input.GetKey("up") && !jump)
        {
            jump = true;
        }

        if (jump)
        {
            jump_curr_time += Time.deltaTime;
            
            // v = v0 + at
            // v cos60 = 1
            // v sin60 = y ====> y = tg60 = 1.7
           
            direction.Set(direction.x, 1.7f - ((jump_accel/speed) * jump_curr_time), direction.z);
          
        }

        target = transform.TransformDirection(direction);

        transform.Translate(speed * target * Time.deltaTime);


        if ((transform.position.y < original_pos.y) && jump)
        {
            jump = false;
            jump_curr_time = 0.0f;
            transform.position = new Vector3(transform.position.x, original_pos.y, transform.position.z);

        }

    }
}
