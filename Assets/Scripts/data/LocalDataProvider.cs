using System;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

public class LocalDataProvider
{
    private const string _fileName = "/playerData.json";  // Remember about extension!
    private PersistantData _persistantData;
    public LocalDataProvider(PersistantData persistantData) => _persistantData = persistantData; // Передаем ссылку!

    private string SavePath = Application.persistentDataPath;
    private string FullPath => SavePath +_fileName;
    public bool TryLoad()
    {
        Debug.Log(FullPath);
        if(IsFileExists() == false)
            return false;
        try
        {
            string jsonString = File.ReadAllText(FullPath);
            Debug.Log(jsonString);
            _persistantData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(jsonString);
            return true;
        }
        catch(Exception e)
        {
            Debug.LogException(e);
            Debug.Log("Its me, hi");
            Debug.Log(FullPath);
            return false;
        }
    }
    public void Save()
    {
        File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistantData.PlayerData, Formatting.Indented));
    }
    private bool IsFileExists() => File.Exists(FullPath);
}
