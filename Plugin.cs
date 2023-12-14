using BepInEx;
using HarmonyLib;
using UnityEngine;

[BepInPlugin("org.bepinex.plugins.GreydwarfAI", "Greydwarf AI", "1.0.0.0")]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo("Greydwarf AI is loaded!");

        // Apply Harmony patches
        var harmony = new Harmony("org.bepinex.plugins.GreydwarfAI");
        harmony.PatchAll();
    }
}

// Ensure the namespace matches your plugin's namespace
namespace MyFirstPlugin
{
    [HarmonyPatch(typeof(MonsterAI))]
    public static class MonsterAIPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        public static void AwakePostfix(MonsterAI __instance)
        {
            var monsterName = __instance.gameObject.name;

            // Check if the instance is one of the specified monsters
            if (monsterName == "Greydwarf" || monsterName == "Greyling" || 
                monsterName == "Greydwarf_Elite" || monsterName == "Greydwarf_Shaman")
            {
                __instance.m_circleTargetInterval = 0f;
                __instance.m_circleTargetDuration = 0f;
                __instance.m_circleTargetDistance = 0f;
            }
        }
    }
}
