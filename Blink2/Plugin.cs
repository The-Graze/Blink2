using BepInEx;
using System;
using System.Collections;
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

        void Start() => OnEnable();

        void OnEnable()
        {
            RandomChance();
        }

        IEnumerator Blonk()
        {
            yield return new WaitForSeconds(5);
            RandomChance();
        }

        void RandomChance()
        {
            if (Random.Range(1, 6) == 3)
            {
                BlinkEyeEffect();
            }
            else
            {
                StartCoroutine(Blonk());
            }
        }

        void BlinkEyeEffect()
        {
            eye.overrideDuration = eye.screamDuration;
            eye.overrideUV = new Vector2(0.25f, 0);
            eye.IsEyeExpressionOverriden = true;
            StartCoroutine(Blonk());
        }
    }
}
