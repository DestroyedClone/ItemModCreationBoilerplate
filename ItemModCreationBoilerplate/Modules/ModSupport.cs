using ItemModCreationBoilerplate.Modules;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ItemModCreationBoilerplate
{
    internal class ModSupport
    {
        internal static void CheckForModSupport()
        {
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(ModCompatBetterUI.guid))
            {
                ModCompatBetterUI.Init();
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(ModCompatRiskOfOptions.guid))
            {
                ModCompatRiskOfOptions.Init();
            }
        }
        internal class ModCompatBetterUI
        {
            public const string guid = "com.xoxfaby.BetterUI";
            internal static bool loaded = false;

            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
            internal static void Init()
            {
                loaded = true;
                BetterUICompat_ItemStats();
                BetterUICompat_Buffs();
            }

            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
            internal static void BetterUICompat_Buffs()
            {
                var prefix = LanguageOverrides.LanguageTokenPrefixBuffs;
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
        internal class ModCompatRiskOfOptions
        {
            internal const string guid = "com.rune580.riskofoptions";
            internal static bool loaded = false;

            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
            internal static void Init()
            {
                loaded = true;

                RiskOfOptions.ModSettingsManager.SetModDescription(Main.ModDescription, Main.ModGuid, Main.ModName);
            }
        }
    }
}