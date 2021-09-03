using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBMap
{
    public class GreenButton : MonoBehaviour
    {
        public GameObject GreenShop;
        private bool isVisible = true;

        // ボタンが押された場合、今回呼び出される関数
        public void OnClick()
        {
            GreenShop.SetActive(isVisible);
            isVisible = !isVisible;
        }
    }
}
