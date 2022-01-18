using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem : MonoBehaviour
{
    public enum Language
    {
        English, Turkce, NULL
    }

    public static Language language = Language.English;

    public static Dictionary<string, string> dictionary;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV("Localization/Localization");
        dictionary = csvLoader.GetDictionaryValues();
        isInit = true;
    }

    public static string GetKeyByValue(string value)
    {
        foreach (KeyValuePair<string,string> keyValuePair in dictionary)
        {
            if (keyValuePair.Value == value)
                return keyValuePair.Key;
        }
        return "";
    }

    public static string GetValueByKey(string key)
    {
        foreach (KeyValuePair<string, string> keyValuePair in dictionary)
        {
            if (keyValuePair.Key == key)
                return keyValuePair.Value;
        }
        return "";
    }

    public static Language DecideLanguage(string word)
    {
        foreach (KeyValuePair<string, string> keyValuePair in dictionary)
        {
            if (keyValuePair.Key == word)
                return Language.English;
            else if (keyValuePair.Value == word)
                return Language.Turkce;
        }
        return Language.NULL;
    }

    public static string GetLocalizedValue(string word)
    {
        if (!isInit) Init();

        if (DecideLanguage(word) == Language.NULL)
            return "not found in csv";
        if (DecideLanguage(word) == language)
            return word;

        switch (language)
        {
            case Language.Turkce:
                return GetValueByKey(word); 
            case Language.English:
                return GetKeyByValue(word);
        }
        return "";
    }
}