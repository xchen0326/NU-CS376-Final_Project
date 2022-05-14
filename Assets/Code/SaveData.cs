using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
   public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayData data = new PlayData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayData data = formatter.Deserialize(stream) as PlayData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found " + path);
            return null;
        }
    }

    public static void SaveOnFireHint(OnFireHint ofh)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/onFireHint.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayData data = new PlayData(ofh);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayData LoadOnFireHint()
    {
        string path = Application.persistentDataPath + "/onFireHint.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayData data = formatter.Deserialize(stream) as PlayData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found " + path);
            return null;
        }
    }

    public static void SaveScoreManager()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scoreManager.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayData data = new PlayData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayData LoadScoreManager()
    {
        string path = Application.persistentDataPath + "/scoreManager.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayData data = formatter.Deserialize(stream) as PlayData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found " + path);
            return null;
        }
    }
}
