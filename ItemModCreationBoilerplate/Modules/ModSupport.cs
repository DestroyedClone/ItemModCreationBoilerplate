using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ItemModCreationBoilerplate
{
    internal class ModSupport
    {
        internal static bool betterUILoaded = false;
        internal static void CheckForModSupport()
        {
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(ModCompatBetterUI.guid))
            {
                betterUILoaded = true;
                ModCompatBetterUI.Init();
            }
        }
        internal class ModCompatBetterUI
        {
            public const string guid = "com.xoxfaby.BetterUI";

            internal static void Init()
            {
                BetterUICompat_ItemStats();
                BetterUICompat_Buffs();
            }

            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
            internal static void BetterUICompat_Buffs()
            {
                var prefix = "RISKOFBULLETSTORM_BUFF_";
                void RegisterBuffInfo(RoR2.BuffDef buffDef, string baseToken, string[] descTokenParams = null)
                {
                    if (descTokenParams != null && descTokenParams.Length > 0)
                    {
                        Modules.LanguageOverrides.DeferToken(prefix + baseToken + "_DESC", descTokenParams);
                    }
                    BetterUI.Buffs.RegisterBuffInfo(buffDef, prefix + baseToken + "_NAME", prefix + baseToken + "_DESC");
                }
            }


            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
            internal static void BetterUICompat_ItemStats()
            {

            }
        }
    }
}