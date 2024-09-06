using Modding;
using System.Collections.Generic;
using UnityEngine;
using Satchel;

namespace CastlessFocus
{
    public class CastlessFocus : Mod
    {
        new public string GetName() => "CastlessFocus";
        public override string GetVersion() => "1.0.0.0";

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            On.PlayMakerFSM.OnEnable += RemoveCast;
        }

        private static void RemoveCast(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);
            if ((self != null) && (self.gameObject.name == "Knight") && (self.FsmName == "Spell Control"))
            {
                self.GetState("Button Down").RemoveAction(0);
            }
        }
    }
}