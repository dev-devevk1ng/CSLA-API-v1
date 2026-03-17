/*
    17 Mar 2026
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSTV_v1.DTO.Player
{
    public class PlayerResponseDTO
    {
        public Guid Id { get; set; }
        public required string Nickname { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}