using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextHelper
{
    public static string ShortNumber(long number)
    {
        string result = number.ToString();
        if(number >= 10000)
        {
            result = (number/1000).ToString() + "Ê";
        }
        if (number >= 1_000_000)
        {
            result = (number / 1_000_000).ToString() + "M";
        }
        if (number >= 1_000_000_000)
        {
            result = (number / 1_000_000_000).ToString() + "B";
        }
        if (number >= 1_000_000_000_000)
        {
            result = (number / 1_000_000_000_000).ToString() + "T";
        }
        return result;
    } 

}
