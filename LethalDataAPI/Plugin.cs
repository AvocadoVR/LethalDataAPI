using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalDataAPI.Patches;
using UnityEngine;
using PluginInfo = LethalDataAPI.PluginInfo;

namespace LethalDataAPI
{
    [BepInPlugin(PluginInfo.modGUID, PluginInfo.modName, PluginInfo.modVersion)]
    public class Plugin : BaseUnityPlugin
    {

        private static Harmony harmony = new Harmony(PluginInfo.modGUID);
        public static ManualLogSource logger = new ManualLogSource(PluginInfo.modGUID);

        private Plugin Instance;
        public static string currentSave;

        void Awake()
        {
            Instance = this;
            logger.LogWarning("LethalDataAPI Loaded!");
            
            harmony.PatchAll(typeof(StartOfRoundPatch));
        }
    }
}