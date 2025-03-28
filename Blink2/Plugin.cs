using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace Blink2
{
    [BepInPlugin("com.graze.gorillatag.blink2", "Blink2", "1.1.1")]
    public class Plugin : BaseUnityPlugin
    {
        Plugin()
        {
            new Harmony("com.graze.gorillatag.blink2").PatchAll(Assembly.GetExecutingAssembly());
        }
        void Start()
        {
            Destroy(this);
        }
    }
}
