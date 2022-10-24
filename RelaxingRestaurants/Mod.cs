using KitchenLib;
using HarmonyLib;
using UnityEngine;
using MelonLoader;
using Kitchen;
using KitchenData;
using Unity.Collections;

namespace RelaxingRestaurants
{
    public class Mod : BaseMod
    {
        public Mod() : base("relaxingrestaurants", "1.0.5") {}

        public override void OnInitializeMelon()
        {
        }

        [HarmonyPatch(typeof(UpdateQueuePatience), "OnUpdate")]
        class UpdateQueuePatience_Patch
        {
            public static bool Prefix()
            {
                return false;
		    }
        }

        [HarmonyPatch(typeof(CCustomerSettings), "AddPatience")]
        class CCustomerSettings_Patch
        {
            public static void Postfix(ref CPatience patience)
            {
                patience.StartTime = 999999999f;
                patience.RemainingTime = 999999999f;
		    }
        }
    }
}
