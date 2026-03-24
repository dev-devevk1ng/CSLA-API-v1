/*
    Date 24 Mar 2026
    Gaules
        Sons of The Forest Ep.1
*/

using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSLA.Models.Player
{
    [Table("NativeName", Schema = "Player")]
    public class NativeNameModel
    {
        [Key]
        public required Guid PlayerId { get; set; }
        [MaxLength(40)]
        public required string NativeFirstName { get; set; }
        [MaxLength(40)]
        public required string NativeLastName { get; set; }
    }
}