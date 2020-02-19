
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavingSystem
{
    public static void SaveData(PlayerController playerCtrl, GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/trauma.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData dataLvl = new SaveData(playerCtrl,gameManager);

        formatter.Serialize(stream, dataLvl);
        stream.Close();
    }
    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/trauma.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData dataLvl = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return dataLvl;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
