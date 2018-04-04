using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BestRank : MonoBehaviour {
	public static float BestScore=0;
    public static float bestscore;
    public Text bestscore_text;
    public Text Result_text;

    public bool end;
	void Awake() {
        bestscore_text.gameObject.SetActive(false);
        Result_text.gameObject.SetActive(false);
        end = false;
	}
	void Update () {

         if (Move.instance.is_stop)
         {
             if (!end)
             {
                 if (BestScore > Distance.instance.distance || BestScore.Equals(0))
                 {
                     BestScore = Distance.instance.distance;
                     bestscore = BestScore;
                     Result_text.text = "기록경신 성공!";
                 }
                 else
                 {
                     Result_text.text = "기록경신에 실패하셨습니다!";
                 }
                 bestscore_text.text = "최고기록:" + bestscore.ToString("F2");
                 bestscore_text.gameObject.SetActive(true);
                 Result_text.gameObject.SetActive(true);
                 end = true;
             }  
         }
	}
}
