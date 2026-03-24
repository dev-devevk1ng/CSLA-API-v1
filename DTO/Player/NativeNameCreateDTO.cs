/*
    Date 24 Mar 2026
    Gaules
        Sons of The Forest Ep.1
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSLA.DTO.Player
{
    public class NativeNameCreateDTO
    {
        public required Guid PlayerId { get; set; }
        public required string NativeFirstName { get; set; }
        public required string NativeLastName { get; set; }
    }
}