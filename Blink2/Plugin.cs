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
        public bool running;
        void OnEnable()
        {
            RandomChance();
        }

        IEnumerator Blonk()
        {
            yield return new WaitForSeconds(5);
            RandomChance();
        }

        void OnDisable()
        {
            running = false;
        }

        public void RandomChance()
        {
            running = true;
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
            if (eye == null)
            { 
                eye = gameObject.GetComponent<GorillaEyeExpressions>();
            }
            eye.overrideDuration = eye.screamDuration;
            eye.overrideUV = new Vector2(0.25f, 0);
            eye.IsEyeExpressionOverriden = true;
            StartCoroutine(Blonk());
        }
    }
}
