using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringOperations : MonoBehaviour
{
    public enum StringType{
        Heading,  // Benim Adım Mert
        Sentence, // Benim adım mert
        Upper,    // BENİM 
        Capital,  // Benim
        Lower,    // benim 
    }

    StringType DecideWordType(string word)
    {
        if (word[0] > 95)
            return StringType.Lower;
        else
        {
            if (word[1] > 95)
                return StringType.Capital;
            else
                return StringType.Upper;
        }
    }

    public StringType DecideStringType(string sentence)
    {
        if (!sentence.Contains(" "))
        {
            return DecideWordType(sentence);
        }
        else
        {
            var words = sentence.Split(' ');
            StringType stringType = DecideWordType(words[0]);

            if (stringType == StringType.Capital)
            {
                if(DecideWordType(words[1]) == StringType.Capital)
                    return StringType.Heading;
                else
                    return StringType.Sentence;
            }
            else
            {
                return stringType;
            }
        }
    }

    public string ConvertStringToLower(string sentence)
    {
        return sentence.ToLower();
    }

    public string ConvertString(string sentence, StringType stringType)
    {
        switch (stringType)
        {
            case StringType.Lower:
                return sentence.ToLower();
            case StringType.Upper:
                return sentence.ToUpper();
            case StringType.Capital:
                return char.ToUpper(sentence[0]) + sentence.Substring(1);
            case StringType.Heading:
                return ConvertHeading(sentence);
            case StringType.Sentence:
                return char.ToUpper(sentence[0]) + sentence.Substring(1);
            default:
                return "";
        }
    }

    string ConvertHeading(string sentence)
    {
        var words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
        }
        return string.Join(" ", words);
    }

    


}
