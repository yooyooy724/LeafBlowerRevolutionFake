using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBMap
{
    public class SaveManager : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            // save
            if(Input.GetKeyDown(KeyCode.S))
            {
                SaveSystem.Instance.Save();
                Debug.Log("save successful");
            }

            // load
            if (Input.GetKeyDown(KeyCode.L))
            {
                SaveSystem.Instance.Load();
                Debug.Log("load successful");
            }

            // log
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("User Name = " + SaveSystem.Instance.UserData.NumOfLeaves);
                Debug.Log("Number of Leaves = " + SaveSystem.Instance.UserData.NumOfLeaves);
                Debug.Log("Leaves per step = " + SaveSystem.Instance.UserData.DropAmountLevel);
                Debug.Log("Leaves drop span = " + SaveSystem.Instance.UserData.DropSpanLevel);
                Debug.Log("Player Size = " + SaveSystem.Instance.UserData.PlayerSizeLevel);
                Debug.Log("AI = " + SaveSystem.Instance.UserData.AiLevel);

            }
        }
    }
}
