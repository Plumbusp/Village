using System;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

public class LocalDataProvider
{
    private PersistantData _persistantData;
    public LocalDataProvider(PersistantData persistantData) => _persistantData = persistantData; // Передаем ссылку!

    private string FullPath => $"{Application.persistentDataPath}/PlayerData.json";
    public bool TryLoad()
    { 
        if(IsDataAlreadyExists() == false)
            return false;
        try
        {
            _persistantData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(FullPath);
            return true;
        }
        catch(Exception e)
        {
            Debug.LogException(e);
            return false;
        }
    }
    public void Save()
    {
        File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistantData.PlayerData, Formatting.Indented));
    }
    private bool IsDataAlreadyExists() => File.Exists( FullPath ) ;
}
