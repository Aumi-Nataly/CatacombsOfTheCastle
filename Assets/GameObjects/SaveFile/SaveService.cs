using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

public class SaveService : ISaveService
{
    private Dictionary<SaveType,string> NameFile = new Dictionary<SaveType,string>();

    public SaveService()
    {
        NameFile[SaveType.Inventory] = "inventory.json";
       
    }

    public SaveData LoadData(SaveType type)
    {
        string path = Path.Combine(Application.persistentDataPath, NameFile[type]);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);

            return loadedData;
        }
        else
        {
            Debug.LogWarning($"Файл сохранения {type.ToString()} не найден!");
            return null;
        }

    }

    public void SaveData(SaveData data)
    {
        string path = Path.Combine(Application.persistentDataPath, NameFile[data.Type]);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);

        Debug.Log($"Данные {data.Type.ToString()} сохранены! {path}");

    }

}
