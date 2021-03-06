﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BitmaskHelper
{
   public static bool IsSet<T>(this T flags, T flag) where T : struct
    {
        int flagsValue = (int)(object)flags;
        int flagValue = (int)(object)flag;
        return (flagsValue & flagValue) != 0;
    }

    public static void Set<T>(this ref T flags, T flag) where T : struct
    {
        int flagsValue = (int)(object)flags;
        int flagValue = (int)(object)flag;
        flags = (T)(object)(flagsValue | flagValue);
    }


    public static void Unset<T>(this ref T flags, T flag) where T : struct
    {
        int flagsValue = (int)(object)flags;
        int flagValue = (int)(object)flag;
        flags = (T)(object)(flagsValue & (~flagValue));
    }
}
