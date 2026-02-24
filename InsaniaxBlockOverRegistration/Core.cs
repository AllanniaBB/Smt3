using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using Il2Cppnewdata_H;

[assembly: MelonInfo(typeof(InsaniaxBlockOverRegistration.Core), "InsaniaxBlockOverRegistration", "1.0.0", "Allannia", null)]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace InsaniaxBlockOverRegistration
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Insaniax BlockOverRegistration Initialized.");
        }
    }

    // Block specific demons from being registered in the compendium
    [HarmonyPatch(typeof(fclEncyc), "fclEncycRegist")]
    public static class BlockNewDemonsRegistration
    {
        private static readonly Dictionary<int, string> BlockedNewDemons = new()
        {
            {179, "OseHallel"},
            {180, "FlaurosHallel"},
            {181, "Urthona"},
            {182, "Urizen"},
            {183, "Luvah"},
            {184, "Tharmus"},
            {185, "Specter"},
            {186, "Mara"},
            {224, "TamLin"},
            {225, "Doppelganger"},
            {226, "Nightmare"},
            {227, "Gdon"},
            {228, "Vritra"},
            {229, "Demeeho"},
            {230, "Seth"}
        };

        public static bool Prefix(ref int __result, datUnitWork_t __0, int __1, bool __2)
        {
            int demonId = (int)__0.id;
            int currentCount = fclEncyc.fclEncycGetNum();
            int existingIndex = fclEncyc.fclEncycSearch(demonId);

            //MelonLogger.Msg($"[DEBUG] Compendium search: {existingIndex}");
            
            if (existingIndex != -1)
            {
                // Already in compendium → allow updates
                return true;
            }

            // Block new demons
            if (BlockedNewDemons.ContainsKey(demonId))
            {
                MelonLogger.Msg($"[DEBUG] Skipping compendium registration for {BlockedNewDemons[demonId]} (ID {demonId})");
                __result = -1;
                return false;
            }

            // Block if compendium at vanilla limit
            if (currentCount == 185)
            {
                MelonLogger.Msg($"[DEBUG] Compendium limit reached, skipping registration for demon ID {demonId}");
                __result = -1;
                return false;
            }

            return true; // Allow registration
        }
    }
}