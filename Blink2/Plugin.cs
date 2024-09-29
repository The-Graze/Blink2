using BepInEx;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Blink2
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        Plugin()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Destroy(this);
        }
    }

    class BlinkManager : MonoBehaviour
    {
        public GorillaEyeExpressions eye;
        void Start()
        {
            InvokeRepeating(nameof(RandomChance), 5f, 5f);
        }

        void RandomChance()
        {
            if (Random.Range(1, 6) == 3)
            {
                BlinkEyeEffect();
            }
        }

        void BlinkEyeEffect()
        {
            eye.overrideDuration = eye.screamDuration;
            eye.overrideUV = new Vector2(0.25f, 0);
            eye.IsEyeExpressionOverriden = true;
        }
    }
}
