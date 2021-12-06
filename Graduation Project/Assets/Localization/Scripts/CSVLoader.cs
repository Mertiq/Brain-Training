using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVLoader: MonoBehaviour
{
    TextAsset csvFile;
    char lineSeperator = '\n';
    char surround = ';';

    public void LoadCSV()
    {
        csvFile = Resources.Load<TextAsset>("Localization/Localization");
    }

    public Dictionary<string, string> GetDictionaryValues()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = csvFile.text.Split(lineSeperator);
        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            Debug.Log(line);
            string[] fields = line.Split(';'); //CSVParser.Split(line);
            Debug.Log(fields);
            for (int j = 0; j < fields.Length; j++)
            {
                fields[j] = fields[j].TrimStart(' ', surround);
                fields[j] = fields[j].TrimEnd(surround);
            }
            if (dictionary.ContainsKey(fields[0])) continue;
            dictionary.Add(fields[0], fields[1]);
        }
        return dictionary;
    }

}
