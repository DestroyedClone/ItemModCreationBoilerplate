using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using RoR2;
using static ItemModCreationBoilerplate.Main;

namespace ItemModCreationBoilerplate.Artifact
{
    class ExampleArtifact : ArtifactBase<ExampleArtifact>
    {
        public override string ArtifactName => "Artifact of the Print Message";

        public override string ArtifactLangTokenName => "PRINTMESSAGEARTIFACT";

        public override Sprite ArtifactEnabledIcon => LoadSprite(true);

        public override Sprite ArtifactDisabledIcon => LoadSprite(false);

        public override void Init(ConfigFile config)
        {
            CreateLang();
            CreateArtifact();
        }

        public override void OnArtifactEnabled()
        {
            CharacterMaster.onStartGlobal += PrintMessage;
        }

        public override void OnArtifactDisabled()
        {
            CharacterMaster.onStartGlobal -= PrintMessage;
        }

        private void PrintMessage(CharacterMaster characterMaster)
        {
            Chat.AddMessage("oy");
        }
    }
}
