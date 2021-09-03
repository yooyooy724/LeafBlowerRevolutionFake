using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBMap
{
    public class LeafScript : MonoBehaviour
    {
        public ScoreScript ScoreScriptInstance;
        public Transform EdgeBoundary;
        private bool isFirstLeaf = true;

        private void Start()
        {
            Transform myTransform = this.transform;
            Vector2 pos = myTransform.position;

            if (EdgeBoundary.GetChild(0).position.y > pos.y &&
                EdgeBoundary.GetChild(1).position.x > pos.x &&
                EdgeBoundary.GetChild(2).position.y < pos.y &&
                EdgeBoundary.GetChild(3).position.x < pos.x)
            {
                isFirstLeaf = false;
            }
        }

        private void Update()
        {
            if (!isFirstLeaf)
            {
                Transform myTransform = this.transform;
                Vector2 pos = myTransform.position;

                if (EdgeBoundary.GetChild(0).position.y < pos.y ||
                    EdgeBoundary.GetChild(1).position.x < pos.x ||
                    EdgeBoundary.GetChild(2).position.y > pos.y ||
                    EdgeBoundary.GetChild(3).position.x > pos.x)
                {
                    ScoreScriptInstance.UpdateScore(ScoreScript.Score.aboutNumOfLeaves, true);
                    DestroyLeaf();
                }
            }
        }

        private void DestroyLeaf()
        {
            GameObject myObj = this.gameObject;
            Destroy(myObj);
        }
    }
}
