/*
    Date 4 Mar 2026
*/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSTV_v1.Models.Player
{
    [Table("Player", Schema = "Player")]
    public class PlayerModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public required string Nickname { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
