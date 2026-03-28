/*
    Date 27 Mar 2026 07:04
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

using CSLA.Models.Player;

// tabela que junta player + role (N:N), ela nao tem id propria, sua id é composta.
// Player.Player (1) ────< RolesModel >──── (1) Player.RoleOptions

namespace CSLA.Models.Player
{
    [Table("Roles", Schema = "Player")]
    public class RolesModel
    {
        public Guid PlayerId { get; set; }
        public int RoleId { get; set; }
        public int OrderIndex { get; set; }
        
        // 🔹 Relacionamento N:1
        public PlayerModel Player { get; set; } = null!;
        // 🔹 Relacionamento N:1
        public RoleOptionsModel Role { get; set; } = null!; 
    }
}