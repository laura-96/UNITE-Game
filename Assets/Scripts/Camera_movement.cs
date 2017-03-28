using UnityEngine;
using System.Collections;

public class Camera_movement : MonoBehaviour {

    private GameObject player;
    private Vector3 distance;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");

        distance = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 new_distance = (player.transform.position - transform.position) - distance;

        Vector3 translate = new Vector3(transform.InverseTransformVector(new_distance).x - new_distance.x, transform.InverseTransformVector(new_distance).y - new_distance.y, transform.InverseTransformVector(new_distance).z);
        
        transform.Translate(translate * Time.deltaTime);

    }
}
