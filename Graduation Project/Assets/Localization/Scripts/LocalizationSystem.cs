using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem : MonoBehaviour
{
    public enum Language
    {
        English,Türkçe
    }

    public static Language language = Language.Türkçe;

    public static Dictionary<string, string> dictionary;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();
        dictionary = csvLoader.GetDictionaryValues();
        isInit = true;
    }

    public static string GetLocalizedValue(string enWord)
    {
        if (!isInit) Init();
        string trWord = enWord;
        switch (language)
        {
            case Language.Türkçe:
                dictionary.TryGetValue(enWord, out trWord);
                break;
        }
        return trWord;
    }
}