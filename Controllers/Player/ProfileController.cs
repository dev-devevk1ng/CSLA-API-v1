/*
    Date 4 Mar 2026
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using CSTV_v1.Services.Player;
using CSTV_v1.Models;
using CSTV_v1.Models.Player;

namespace CSTV_v1.Controllers.Player
{
    [ApiController]
    [Route("api/player/[controller]")]
    [Tags("Player")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileInterface _profileInterface;
        public ProfileController(IProfileInterface profileInterface)
        {
            _profileInterface = profileInterface;
        }

        [HttpGet("ProfileList")]
        public async Task<ActionResult<ResponseModel<List<ProfileModel>>>> ProfileList()
        {
            var players = await _profileInterface.GetProfileList();
            return Ok(players);
        }
    }
}