using BepInEx.Configuration;
using ItemModCreationBoilerplate.Utils;
using R2API;
using RoR2;
using System;
using UnityEngine;
using static ItemModCreationBoilerplate.Main;

namespace ItemModCreationBoilerplate.Items
{
    public class ExampleItem : ItemBase<ExampleItem>
    {
        public override string ItemName => "Deprecate Me Item";

        public override string ItemLangTokenName => "DEPRECATE_ME_ITEM";

        public override string[] ItemFullDescriptionParams => new string[]
        {
            (0.5f*100).ToString(),
            100.ToString()
        };
        public override string[] ItemPickupDescParams => new string[]
        {
            112345f.ToString()
        };

        public override ItemTier Tier => ItemTier.Tier1;

        public override GameObject ItemModel => LoadModel();

        public override Sprite ItemIcon => LoadSprite();

        public override void Init(ConfigFile config)
        {
            CreateConfig(config);
            CreateLang();
            CreateItem();
            Hooks();
        }

        public override void CreateConfig(ConfigFile config)
        {

        }

        public override ItemDisplayRuleDict CreateItemDisplayRules()
        {
            return new ItemDisplayRuleDict();
        }

        public override void Hooks()
        {

        }

    }
}
