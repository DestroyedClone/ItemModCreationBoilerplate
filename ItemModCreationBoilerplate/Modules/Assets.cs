﻿using RoR2;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ItemModCreationBoilerplate.Modules
{
    internal class Assets
    {
        internal const string unlockableDefPrefix = "ItemMod.";
        internal const string unlockableDefItemPrefix = "ItemMod.";
        internal const string unlockableDefEquipmentPrefix = "ItemMod.";

        internal static GameObject NullModel = LoadAsset<GameObject>("RoR2/Base/Core/NullModel.prefab");
        internal static Sprite NullSprite = LoadAsset<Sprite>("RoR2/Base/Core/texNullIcon.png");

        internal static ItemTierDef itemLunarTierDef = LoadAsset<ItemTierDef>("RoR2/Base/Common/LunarTierDef.asset");
        internal static ItemTierDef itemBossTierDef = LoadAsset<ItemTierDef>("RoR2/Base/Common/BossTierDef.asset");
        internal static ItemTierDef itemTier1Def = LoadAsset<ItemTierDef>("RoR2/Base/Common/Tier1Def.asset");
        internal static ItemTierDef itemTier2Def = LoadAsset<ItemTierDef>("RoR2/Base/Common/Tier2Def.asset");
        internal static ItemTierDef itemTier3Def = LoadAsset<ItemTierDef>("RoR2/Base/Common/Tier3Def.asset");
        internal static ItemTierDef itemVoidBossTierDef = LoadAsset<ItemTierDef>("RoR2/DLC1/Common/VoidBossDef.asset");
        internal static ItemTierDef itemVoidTier1Def = LoadAsset<ItemTierDef>("RoR2/DLC1/Common/VoidTier1Def.asset");
        internal static ItemTierDef itemVoidTier2Def = LoadAsset<ItemTierDef>("RoR2/DLC1/Common/VoidTier2Def.asset");
        internal static ItemTierDef itemVoidTier3Def = LoadAsset<ItemTierDef>("RoR2/DLC1/Common/VoidTier3Def.asset");

        public static ItemTierDef ResolveTierDef(ItemTier itemTier)
        {
            switch (itemTier)
            {
                case ItemTier.AssignedAtRuntime:
                    return null;

                case ItemTier.Boss:
                    return itemBossTierDef;

                case ItemTier.Lunar:
                    return itemLunarTierDef;

                case ItemTier.NoTier:
                    return null;

                case ItemTier.Tier1:
                    return itemTier1Def;

                case ItemTier.Tier2:
                    return itemTier2Def;

                case ItemTier.Tier3:
                    return itemTier3Def;

                case ItemTier.VoidBoss:
                    return itemVoidBossTierDef;

                case ItemTier.VoidTier1:
                    return itemVoidTier1Def;

                case ItemTier.VoidTier2:
                    return itemVoidTier2Def;

                case ItemTier.VoidTier3:
                    return itemVoidTier3Def;
            }
            return null;
        }

        public static AssetBundle mainAssetBundle;

        public static T LoadAsset<T>(string path)
        {
            return Addressables.LoadAssetAsync<T>(path).WaitForCompletion();
        }

        public static UnlockableDef CreateUnlockableDef(string name, Sprite icon = null)
        {
            UnlockableDef unlockableDef = ScriptableObject.CreateInstance<UnlockableDef>();
            unlockableDef.achievementIcon = icon;
            unlockableDef.cachedName = unlockableDefPrefix + name;
            return unlockableDef;
        }

        public static void Init()
        {
            PopulateAssets();
        }

        public static void PopulateAssets()
        {
            // Don't know how to create/use an asset bundle, or don't have a unity project set up?
            // Look here for info on how to set these up: https://github.com/KomradeSpectre/AetheriumMod/blob/rewrite-master/Tutorials/Item%20Mod%20Creation.md#unity-project
            // (This is a bit old now, but the information on setting the unity asset bundle should be the same.)
            if (mainAssetBundle == null)
            {
                try
                {
                    using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RiskOfBulletstormRewrite.riskofbulletstormbundle"))
                    {
                        mainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                    }
                }
                catch
                {
                    Main.ModLogger.LogError($"Assets.PopulateAssets failed to load assetbundle!");
                }
            }
        }

        public static Sprite LoadSprite(string path)
        {
            try
            {
                return mainAssetBundle.LoadAsset<Sprite>(path);
            }
            catch
            {
                Main.ModLogger.LogError($"Assets.LoadSprite failed to load path \"{path}\", defaulting to Assets.NullSprite.");
                return Assets.NullSprite;
            }
        }

        public static GameObject LoadObject(string path)
        {
            try
            {
                return mainAssetBundle.LoadAsset<GameObject>(path);
            }
            catch
            {
                Main.ModLogger.LogError($"Assets.LoadObject failed to load path \"{path}\", defaulting to Assets.NullModel.");
                return Assets.NullModel;
            }
        }
    }
}