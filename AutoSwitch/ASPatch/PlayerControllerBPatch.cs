using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoSwitch.ASPatch
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("DiscardHeldObject")]
        [HarmonyPostfix]
        private static void autoSwitchPatch(PlayerControllerB __instance, ref GrabbableObject[] ___ItemSlots, ref bool ___isHoldingObject)
        {
            MethodInfo method = typeof(PlayerControllerB).GetMethod("NextItemSlot", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo method2 = typeof(PlayerControllerB).GetMethod("SwitchToItemSlot", BindingFlags.Instance | BindingFlags.NonPublic);
            if (!(method != null) || !(method2 != null))
            {
                return;
            }
            int currentItemSlot = __instance.currentItemSlot;
            for (int num = (int)method.Invoke(__instance, new object[1] { true }); num != currentItemSlot; num = (num + 1) % ___ItemSlots.Length)
            {
                if ((Object)(object)___ItemSlots[num] != null)
                {
                    method2.Invoke(__instance, new object[2] { num, null });
                    break;
                }
            }
        }

    }
}
