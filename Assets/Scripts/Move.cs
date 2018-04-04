using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    Vector3 fisrt_pos;
    Vector3 second_pos;
    public float distance;
    public float speed;
    public GameObject Car;

    public bool is_move=false;
    public static Move instance;
	public bool is_stop=false;
    // Update is called once per frame

	public float x;
	public float y;
	public float z;
    public void Awake()
    {
		speed = 0;
        instance = this;
		x = Car.transform.position.x;
		y = Car.transform.position.y;
		z = Car.transform.position.z;
    }
    void Update () {
		if (!is_stop) {
			if (!is_move) {
				if (Input.GetMouseButtonDown (0)) {
					fisrt_pos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
				}
				if (Input.GetMouseButtonUp (0)) {
					second_pos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
					distance = Vector3.Distance (fisrt_pos, second_pos);
					speed = 0.5f * distance;
					is_move = true;
				}
			} else {
				Car.transform.Translate (new Vector3 (0, 0, 1) * speed * Time.deltaTime);
				speed *= 0.98f;
			}
		}
		if (speed <= 0.005&&speed>0&&!Distance.instance.over)
        {
            speed = 0;
            is_move = false;
			is_stop = true;
        }



		if (Car.transform.position.y < 0) {
			speed = 0;
			Car.transform.position = new Vector3 (x, y, z);
		}
    }
}
