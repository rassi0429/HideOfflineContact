using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;
using SkyFrost.Base;

namespace HideOfflineContact
{
    public class HideOfflineContact : ResoniteMod
    {
        public override string Name => "HideOfflineContact";
        public override string Author => "kka429";
        public override string Version => "0.0.2";
        public override string Link => "https://github.com/rassi0429/HideOfflineContact";

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("dev.kokoa.srdmod");
            harmony.PatchAll();
        }

        [HarmonyPatch]
        class ContactPatch
        {
            [HarmonyPatch(typeof(ContactsDialog), "UpdateContactItem")]
            [HarmonyPrefix]
            static bool Prefix(ContactData data)
            {
                if (data.CurrentStatus.OnlineStatus == OnlineStatus.Offline || data.Contact.IsPartiallyMigrated)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
