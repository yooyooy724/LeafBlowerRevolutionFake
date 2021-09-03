using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WBMap
{
    public class GenerateLeaf : MonoBehaviour
    {
        public GameObject leaf;
        public ScoreScript ScoreScriptInstance;

        private double timeleft;

        void Update()
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0.0)
            {
                timeleft = ScoreScriptInstance.dropSpan; // n秒おきに処理

                for (int i = 0; i < ScoreScriptInstance.dropAmount; i++)
                {
                    float posX = Random.Range(-32.0f, 32.0f);
                    float posY = Random.Range(-18.0f, 18.0f);
                    float rotZ = Random.Range(-180.0f, 180.0f);

                    //Instantiate( 生成するオブジェクト,  場所, 回転 )
                    Instantiate(leaf, new Vector3(posX, posY, 0.0f), Quaternion.Euler(0.0f, 0.0f, rotZ));
                }
            }

            //increament test
            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("increased !!!");
                ScoreScriptInstance.UpdateScore(ScoreScript.Score.aboutDropAmount, true);
                //ScoreScriptInstance.Increment(ScoreScript.Score.aboutDropSpan);
                //ScoreScriptInstance.Increment(ScoreScript.Score.aboutPlayerSize);

            }
        }
    }
}
