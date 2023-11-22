using System;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Interactables.Interobjects.DoorUtils;
using PluginAPI.Core;

namespace KeycardLess
{
    public class EventHandler
    {
        public void OnDoorInteract(InteractingDoorEventArgs ev)
        {
            Log.Debug("Entering method OnDoorInteract");
            
            try
            {
                if (!KeycardLess.Instance.Config.AffectDoors)
                {
                    return;
                }
                
                Log.Debug($"IsAllowed {ev.IsAllowed}, Has permission: {PlayerHandler.HasPermission(ev.Player, ev.Door.RequiredPermissions.RequiredPermissions)}, Current Item: {ev.Player.CurrentItem}");

                if (!ev.IsAllowed && PlayerHandler.HasPermission(ev.Player, ev.Door.RequiredPermissions.RequiredPermissions) && !ev.Door.IsLocked)
                {
                    ev.IsAllowed = true;
                }
            }
            catch (Exception e)
            {
                var text = $"Error detected. Reason: {e}";
                Log.Error(text);
                throw;
            }
        }
        
        public void OnLockerInteract(InteractingLockerEventArgs ev)
        {
            Log.Debug("Entering method OnLockerInteract");

            try
            {
                if (!KeycardLess.Instance.Config.AffectScpLockers)
                {
                    return;
                }
                
                Log.Debug($"IsAllowed {ev.IsAllowed}, Did player have permissions {PlayerHandler.HasPermission(ev.Player, ev.Chamber.RequiredPermissions)}, Current Item: {ev.Player.CurrentItem}");

                if (!ev.IsAllowed && ev.Chamber != null && PlayerHandler.HasPermission(ev.Player, ev.Chamber.RequiredPermissions))
                {
                    ev.IsAllowed = true;
                }
            }
            catch (Exception e)
            {
                var text = $"Error detected. Reason: {e}";
                Log.Error(text);
                throw;
            }
        }
        
        public void OnWarheadPannelInteract(ActivatingWarheadPanelEventArgs ev)
        {
            Log.Debug("Entering method OnWarheadPannelInteract");

            try
            {
                if (!KeycardLess.Instance.Config.AffectWarheadPanel)
                {
                    return;
                }
                
                Log.Debug($"IsAllowed {ev.IsAllowed}, Did player have permissions {PlayerHandler.HasPermission(ev.Player, KeycardPermissions.AlphaWarhead)}, Current Item: {ev.Player.CurrentItem}");

                if (!ev.IsAllowed && PlayerHandler.HasPermission(ev.Player, KeycardPermissions.AlphaWarhead))
                {
                    ev.IsAllowed = true;
                }
            }
            catch (Exception e)
            {
                var text = $"Error detected. Reason: {e}";
                Log.Error(text);
                throw;
            }
        }
        
        public void OnGeneratorUnlock(UnlockingGeneratorEventArgs ev)
        {
            Log.Debug("Entering method OnGeneratorUnlock");

            try
            {
                if (!KeycardLess.Instance.Config.AffectGenerators)
                {
                    return;
                }

                Log.Debug($"IsAllowed {ev.IsAllowed}, Did player have permissions {PlayerHandler.HasPermission(ev.Player, ev.Generator.Base._requiredPermission)}, Current Item: {ev.Player.CurrentItem}");

                if (!ev.IsAllowed && PlayerHandler.HasPermission(ev.Player, ev.Generator.Base._requiredPermission))
                {
                    ev.IsAllowed = true;
                }
            }
            catch (Exception e)
            {
                var text = $"Error detected. Reason: {e}";
                Log.Error(text);
                throw;
            }
        }
    }
}

