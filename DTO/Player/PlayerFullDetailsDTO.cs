/*
    Date 28 Mar 2026
    Gaules
        The Forest Ep.8 at 9

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSLA.DTO.Player
{
    public class PlayerFullDetailsDTO
    {
        // Player.Player
        public Guid PlayerId { get; set; }
        public string Nickname { get; set; } = null!;
        public DateTime PlayerCreatedAt { get; set; } 

        public ProfileResponseDTO? Profile { get; set; }
        public NativeNameResponseDTO? NativeName { get; set; }
        
        public List<RolesResponseDTO> Roles { get; set; } = null!;
        public List<AlternateIDResponseDTO> AlternateIDs { get; set; } = null!;
        

        /*
        // Player.Profile
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Born { get; set; }
        public string Status { get; set; } = null!;
        public decimal ApproxTotalWinnings { get; set; }
        public int YearCareerStart { get; set; }
        public int YearCareerEnd { get; set; }
        public DateTime ProfileCreatedAt { get; set; }
        // Player.NativeName
        public string NativeFirstName { get; set; } = null!;
        public string NativeLastName { get; set; } = null!;
        // Player.AlternateID
        public List<string> AlternateIDs { get; set; } = null!;
        // Player.Roles
        public List<string> Roles { get; set; } = null!;
        */
    }
}