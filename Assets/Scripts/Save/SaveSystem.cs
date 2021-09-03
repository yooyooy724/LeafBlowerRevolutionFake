using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace WBMap
{

    public class SaveSystem
    {
        #region Singleton
        //↑region: コードの折り畳み
        //Singleton: そのクラスのインスタンスが1つしか生成されないことを保証する
        private static SaveSystem instance = new SaveSystem();
        public static SaveSystem Instance => instance;
        #endregion

        private SaveSystem(){ Load();  }

        public string Path => Application.dataPath + "/data.json";
        //private UserData userData = new UserData(); //UserDataのインスタンス
        //public UserData UserData => userData;
        public UserData UserData { get; private set; }

        public void Save()
        {
            string jsonData = JsonUtility.ToJson(UserData); //インスタンスを文字列化
            StreamWriter writer = new StreamWriter(Path, false); //書き込み（trueで追記，falseで上書き）
            writer.WriteLine(jsonData);
            writer.Flush();
            writer.Close();
        }

        public void Load()
        {
            if(!File.Exists(Path))
            {
                Debug.Log("file not found");
                UserData = new UserData();
                Save();
                return;
            }

            StreamReader reader = new StreamReader(Path);
            string jsonDate = reader.ReadToEnd(); //読み取り
            UserData = JsonUtility.FromJson<UserData>(jsonDate); //インスタンスを作成
            reader.Close();
        }
    }
}
