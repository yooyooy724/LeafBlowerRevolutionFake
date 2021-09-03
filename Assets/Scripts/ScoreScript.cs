using UnityEngine;
using UnityEngine.UI;
using System;

namespace WBMap
{
    public class ScoreScript : MonoBehaviour
    {
        public enum Score //enum: 複数の定数をひとつにまとめておくことができる型
        {
            aboutNumOfLeaves, aboutDropAmount, aboutDropSpan, aboutPlayerSize ,aboutAi
        }

        public Text NOLText;
        public Text DAText;
        public Text DSText;
        public Text PSText;
        public Text AiText;

        public Transform Player;
        public GameObject AI;

        public double dropAmount;
        public double dropSpan;
        public float playerSize;

        // Initialize ScoreText
        private void Start()
        {
            UpdateScore(ScoreScript.Score.aboutNumOfLeaves, false);
            UpdateScore(ScoreScript.Score.aboutDropAmount, false);
            UpdateScore(ScoreScript.Score.aboutDropSpan, false);
            UpdateScore(ScoreScript.Score.aboutPlayerSize, false);
            UpdateScore(ScoreScript.Score.aboutAi, false);

        }

        public void UpdateScore(Score whichScore, bool increase)
        {
            if (whichScore == Score.aboutNumOfLeaves)
            {
                if (increase)
                    SaveSystem.Instance.UserData.NumOfLeaves++;
                NOLText.text = (SaveSystem.Instance.UserData.NumOfLeaves).ToString();
            }

            if (whichScore == Score.aboutDropAmount)
            {
                if (increase &&
                    SaveSystem.Instance.UserData.DropAmountLevel < 30 &&
                    SaveSystem.Instance.UserData.NumOfLeaves > 100)
                {
                    SaveSystem.Instance.UserData.DropAmountLevel++;
                    SaveSystem.Instance.UserData.NumOfLeaves -= 100;
                    NOLText.text = (SaveSystem.Instance.UserData.NumOfLeaves).ToString();
                }

                DAText.text = "Tree(" + SaveSystem.Instance.UserData.DropAmountLevel + "/30)";

                dropAmount = Exponentiation(4, 1.2f, SaveSystem.Instance.UserData.DropAmountLevel);
            }

            if (whichScore == Score.aboutDropSpan)
            {
                if (increase &&
                    SaveSystem.Instance.UserData.DropSpanLevel < 15 &&
                    SaveSystem.Instance.UserData.NumOfLeaves > 500)
                { 
                    SaveSystem.Instance.UserData.DropSpanLevel++;
                    SaveSystem.Instance.UserData.NumOfLeaves -= 500;
                    NOLText.text = (SaveSystem.Instance.UserData.NumOfLeaves).ToString();
                }
                DSText.text = "Fuel (" + SaveSystem.Instance.UserData.DropSpanLevel + "/15)";
                dropSpan = Exponentiation(5, 0.9f, SaveSystem.Instance.UserData.DropSpanLevel);
            }

            if (whichScore == Score.aboutPlayerSize)
            {
                if (increase &&
                    SaveSystem.Instance.UserData.PlayerSizeLevel < 3 &&
                    SaveSystem.Instance.UserData.NumOfLeaves > 10000)
                { 
                    SaveSystem.Instance.UserData.PlayerSizeLevel++;
                    SaveSystem.Instance.UserData.NumOfLeaves -= 10000;
                    NOLText.text = (SaveSystem.Instance.UserData.NumOfLeaves).ToString();
                }
                PSText.text = "Size of Me (" + SaveSystem.Instance.UserData.PlayerSizeLevel + "/3)";

                playerSize = Linear(2.0f, 5, SaveSystem.Instance.UserData.PlayerSizeLevel);
                Player.gameObject.transform.localScale = new Vector3(playerSize, playerSize, 1.0f);

            }

            if (whichScore == Score.aboutAi)
            {
                if (increase &&
                    SaveSystem.Instance.UserData.AiLevel < 1 &&
                    SaveSystem.Instance.UserData.NumOfLeaves > 100000) //100k
                {
                    SaveSystem.Instance.UserData.AiLevel++;
                    SaveSystem.Instance.UserData.NumOfLeaves -= 100000;
                    NOLText.text = (SaveSystem.Instance.UserData.NumOfLeaves).ToString();
                }
                AiText.text = "AI (" + SaveSystem.Instance.UserData.AiLevel + "/1)";

                if (SaveSystem.Instance.UserData.AiLevel == 0) 
                    AI.SetActive(false);
                else
                    AI.SetActive(true);
            }
        }

        //Calcuration
        private float Linear(float a, float b, int level)
        {
            return a * level + b;
        }

        private double Exponentiation(double initialTerm, float baseNum, int level)
        {
            return initialTerm * Math.Pow(baseNum, level);
        }

    }
}