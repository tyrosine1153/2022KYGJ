using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable]
public class ExampleType
{
    public int intValue;
}

public class DataManager : Singleton<DataManager>
{
    public string dataPath;

    public List<ExampleType> example;
    
    protected override void Awake()
    {
        base.Awake();
        dataPath = Path.Combine(Application.dataPath, "Resources/Data");

        example = LoadByCsv<ExampleType>("Data", "example").ToList();
    }
    
    #region File IO
    public static void SaveByCsv<T>(string filePath, string fileName, IEnumerable<T> records)
    {
        
    }
    
    public static IEnumerable<T> LoadByCsv<T>(string filePath, string fileName)
    {
        var textAsset = Resources.Load<TextAsset>($"{filePath}/{fileName}");
        return CSVSerializer.Deserialize<T>(textAsset.text);
    }
    #endregion
}