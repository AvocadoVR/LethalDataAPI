using HarmonyLib;

namespace LethalDataAPI.Patches;

[HarmonyPatch(typeof(StartOfRound))]
public class StartOfRoundPatch
{
    [HarmonyPostfix, HarmonyPatch("Start")]
    static void Start(StartOfRound __instance)
    {
        if (__instance.IsServer)
        {
            Plugin.currentSave = GameNetworkManager.Instance.currentSaveFileName;
        }
    }
}