using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBMap //namespace: スクリプト名の衝突を解消する（正直今回は必要なさそう）
{
    [System.Serializable] //このクラスのインスタンスを保存できるようになる

    public class UserData //MonoBehaviourを消すことで，Scene遷移時にインスタンスが消えないようにする
    {
        public string UserName = "Default Name";
        public int NumOfLeaves = 0;
        public int DropAmountLevel = 0;
        public int DropSpanLevel = 0;
        public int PlayerSizeLevel = 0;
        public int AiLevel = 0;
    }
}
