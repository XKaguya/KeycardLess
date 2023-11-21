using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Interactables.Interobjects.DoorUtils;

namespace KeycardLess
{
    public class PlayerHandler
    {
        public static bool HasPermission(Player player, KeycardPermissions permissions)
        {
            return player.Items.Any(item => item is Keycard keycard && DoorPermissionUtils.HasFlagFast(keycard.Base.Permissions, permissions));
        }
    }
}

