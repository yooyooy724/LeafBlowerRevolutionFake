using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBMap
{
    public class PSButton : MonoBehaviour
    {
        public ScoreScript ScoreScriptInstance;

        // ボタンが押された場合、今回呼び出される関数
        public void OnClick()
        {
            Debug.Log("increased");
            ScoreScriptInstance.UpdateScore(ScoreScript.Score.aboutPlayerSize, true);
        }
    }
}
