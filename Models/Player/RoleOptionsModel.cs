/*
    Date 27 Mar 2026 05:10
    CS
        FERJEE IN HOUSE 2026
            Gaimin Gladiators vs MIBR,
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Player.Player (1) ────< Roles >──── (1) Player.RoleOptions

using CSLA.Models.Player;

namespace CSLA.Models.Player
{
    [Table("RoleOptions", Schema = "Player")]
    public class RoleOptionsModel
    {
        [Key]
        public int Id { get; set; }
        public required string Role { get; set; }

        public ICollection<RolesModel> Roles { get; set; } = null!;
    }
}