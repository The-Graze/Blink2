using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Blink2.Patches
{
    [HarmonyPatch(typeof(GorillaEyeExpressions))]
    [HarmonyPatch("Awake", MethodType.Normal)]
    static class EyePatch
    {
        private static void Postfix(GorillaEyeExpressions __instance)
        {
            __instance.gameObject.AddComponent<BlinkManager>().eye = __instance;
        }
    }
}
