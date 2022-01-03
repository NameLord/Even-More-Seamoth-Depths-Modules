#if SN1
namespace EvenMoreSeamothDepth
{
    using HarmonyLib;
    using QModManager.API.ModLoading;
    using SMLHelper.V2.Handlers;
    using System;
    using System.Reflection;

    [QModCore]
    public static class Main
    {
        internal static Modules.SeamothHullModule6 moduleMK6 = new();
        internal static Modules.SeamothHullModule7 moduleMK7 = new();

        [QModPatch]
        public static void Load()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                new Harmony($"NGeorge_{assembly.GetName().Name}").PatchAll(assembly);

                LanguageHandler.SetLanguageLine("Tooltip_VehicleHullModule3", "Enhances diving depth. Does not stack"); // To update conflicts about the maximity.

                moduleMK6.Patch();
                moduleMK7.Patch();

                Console.WriteLine("[EvenMoreSeamothDepth] Succesfully patched!");
            }

            catch(Exception e)
            {
                Console.WriteLine("[EvenMoreSeamothDepth] Caught exception! " + e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
        }
    }
}
#endif