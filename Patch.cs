using Assets.Pixelation.Scripts;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace FilterRemover
{
    public class Patch
    {
        private static float _blockCount;

        static Patch()
        {
            _blockCount = Config.ReadBlockCount();

        } // end constructor

        [HarmonyPatch(typeof(CameraPixelationAmountUpdater), "OnPixelationAmountOptionChange")]
        [HarmonyPostfix]
        private static void Postfix(CameraPixelationAmountUpdater __instance)
        {
            Plugin.StaticLogger.LogInfo($"Setting pixelation block count to \"{_blockCount}\"");
            __instance.GetComponent<Pixelation>().BlockCount = _blockCount;

        } // end OnPixelationAmountOptionChange

    } // end class Patch

} // end namespace