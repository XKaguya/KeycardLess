using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.CustomRoles.Events;
using Exiled.Events.EventArgs.Player;
using HarmonyLib;

namespace KeycardLess
{
    public class KeycardLess : Plugin<Config>
    {
        public override string Author => "Akizuki Kaguya";
        public override string Name => "KeycardLess";

        public override Version Version { get; } = new(1, 0, 1);
        public override Version RequiredExiledVersion { get; } = new(8, 3, 9);

        public static KeycardLess Instance;
        
        public EventHandler EventHandler { get; set; }
        
        public PlayerHandler PlayerHandler { get; set; }

        public override void OnEnabled()
        {
            Instance = this;

            EventHandler = new EventHandler();
            PlayerHandler = new PlayerHandler();

            Exiled.Events.Handlers.Player.InteractingDoor += EventHandler.OnDoorInteract;
            Exiled.Events.Handlers.Player.InteractingLocker += EventHandler.OnLockerInteract;
            Exiled.Events.Handlers.Player.UnlockingGenerator += EventHandler.OnGeneratorUnlock;
            Exiled.Events.Handlers.Player.ActivatingWarheadPanel += EventHandler.OnWarheadPannelInteract;


            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;

            Exiled.Events.Handlers.Player.InteractingDoor -= EventHandler.OnDoorInteract;
            Exiled.Events.Handlers.Player.InteractingLocker -= EventHandler.OnLockerInteract;
            Exiled.Events.Handlers.Player.UnlockingGenerator -= EventHandler.OnGeneratorUnlock;
            Exiled.Events.Handlers.Player.ActivatingWarheadPanel -= EventHandler.OnWarheadPannelInteract;

            EventHandler = null;
            PlayerHandler = null;
            
            base.OnDisabled();
        }
    }
}