using AutoSwitch.ASPatch;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSwitch
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class AutoSwitchMain : BaseUnityPlugin
    {
        private const string modGUID = "Slam.AutoSwitch";
        private const string modName = "Auto Switch";
        private const string modVersion = "0.1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static AutoSwitchMain instance;

        internal ManualLogSource mls;


        void Awake()
        {
            if (instance == null) { instance = this; }

            mls = BepInEx.Logging.Logger.CreateLogSource("Slam.AutoSwitch");
            mls.LogInfo("Auto Switch Mod has loaded!");
            harmony.PatchAll(typeof(PlayerControllerBPatch));

            harmony.PatchAll(typeof(AutoSwitchMain));
        }


    }
}
