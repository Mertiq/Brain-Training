using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVLoader: MonoBehaviour
{
    TextAsset csvFile;
    char lineSeperator = '\n';
    char surround = ';';

    public void LoadCSV(string path)
    {
        csvFile = Resources.Load<TextAsset>(path);
    }

    public Dictionary<string, string> GetDictionaryValues()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = csvFile.text.Split(lineSeperator);
        //Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            if(line.Length <= 0) break;
            string[] fields = line.Split(';'); //CSVParser.Split(line);
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
