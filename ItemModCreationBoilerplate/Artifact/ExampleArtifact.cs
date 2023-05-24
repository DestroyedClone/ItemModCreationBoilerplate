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
            Hooks();
        }

        public override void Hooks()
        {
            RunArtifactManager.onArtifactEnabledGlobal += RunArtifactManager_onArtifactEnabledGlobal;
            RunArtifactManager.onArtifactDisabledGlobal += RunArtifactManager_onArtifactDisabledGlobal;
        }

        private void RunArtifactManager_onArtifactDisabledGlobal([JetBrains.Annotations.NotNull] RunArtifactManager runArtifactManager, [JetBrains.Annotations.NotNull] ArtifactDef artifactDef)
        {
            if (artifactDef != ArtifactDef)
            {
                return;
            }
            CharacterMaster.onStartGlobal -= PrintMessage;
        }

        private void RunArtifactManager_onArtifactEnabledGlobal([JetBrains.Annotations.NotNull] RunArtifactManager runArtifactManager, [JetBrains.Annotations.NotNull] ArtifactDef artifactDef)
        {
            if (artifactDef != ArtifactDef)
            {
                return;
            }
            CharacterMaster.onStartGlobal += PrintMessage;
        }

        private void PrintMessage(CharacterMaster characterMaster)
        {
            Chat.AddMessage("oy");
        }
    }
}
