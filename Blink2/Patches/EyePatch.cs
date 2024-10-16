using HarmonyLib;
using GorillaExtensions;
using Random = UnityEngine.Random;

namespace Blink2.Patches
{
    [HarmonyPatch(typeof(GorillaEyeExpressions))]
    [HarmonyPatch("CheckEyeEffects", MethodType.Normal)]
    static class EyePatch
    {
        private static void Postfix(GorillaEyeExpressions __instance)
        {
            if (!__instance.gameObject.GetOrAddComponent<BlinkManager>().running)
            {
                __instance.gameObject.GetOrAddComponent<BlinkManager>().RandomChance();
            }
        }
    }
}
