using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Distance : MonoBehaviour {
    public GameObject flag;
    public GameObject Car;
    public float distance;
    public Text distext;
    public Text resulttext;

	public float abs=7.0f;
    public Button button;

	public static Distance instance;

    public bool over;
	// Use this for initialization
	void Awake() {
		instance = this;
        over = false;
	}
	void Start () {
        distance = Vector3.Distance(Car.transform.position, flag.transform.position);
		float start_distance = distance - abs;
		distext.text = "현재 남은 거리는:" + start_distance.ToString ("F2");
        resulttext.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
        if (Move.instance.is_move)
        {
            if (Car.transform.position.x < flag.transform.position.x)
            {
				distance = -1 * Vector3.Distance(Car.transform.position, flag.transform.position)+abs;
                resulttext.gameObject.SetActive(true);
                over = true;
                resulttext.text = "Failed!";
            }
            else
                distance = Vector3.Distance(Car.transform.position, flag.transform.position)-abs;
			distext.text = "현재 남은 거리는:" + distance.ToString ("F2");
        }
		if (Move.instance.is_stop||Car.transform.position.x < flag.transform.position.x) {
			button.gameObject.SetActive(true);
		}
	}
   
}
