using Assets.Pixelation.Scripts;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine.TextCore;

namespace FilterRemover
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        public static ManualLogSource StaticLogger; // I'm lazy

        public Plugin()
        {
            StaticLogger = Logger;

        } // end constructor

        private void Awake()
        {
            _harmony.PatchAll(typeof(Patch));

        } // end Awake

    } // end class Plugin

} // end namespace