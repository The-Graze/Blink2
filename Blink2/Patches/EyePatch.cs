using HarmonyLib;
using GorillaExtensions;
using Random = UnityEngine.Random;

namespace Blink2.Patches
{
    //yarrrg
    [HarmonyPatch(typeof(GorillaEyeExpressions))]
    [HarmonyPatch("CheckEyeEffects", MethodType.Normal)]
    static class EyePatch
    {
        private static void Postfix(GorillaEyeExpressions __instance)
        {
            __instance.gameObject.GetOrAddComponent<BlinkManager>();
        }
    }
}
