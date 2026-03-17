/*
    Date 3 Mar 2026
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSTV_v1.Data;
using Microsoft.AspNetCore.Mvc;

using CSTV_v1.Models;
using CSTV_v1.Models.Player;
using CSTV_v1.Services.Player;
using CSTV_v1.DTO.Player;


namespace CSTV_v1.Controllers.Player
{
    [ApiController]
    [Route("api/player/[controller]")]
    [Tags("Player")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerInterface _playerInterface;
        public PlayerController(IPlayerInterface playerInterface)
        {
            _playerInterface = playerInterface;
        }

        // Player.Player

        [HttpGet("PlayerList")]
        public async Task<ActionResult<ResponseModel<List<PlayerResponseDTO>>>> PlayerPlayerList()
        {
            var players = await _playerInterface.GetPlayerList();
            return Ok(players);
        }

        [HttpGet("GetPlayerById/{PlayerId}")]
        public async Task<ActionResult<ResponseModel<PlayerResponseDTO>>> GetPlayerById(Guid PlayerId)
        {
            var player = await _playerInterface.GetPlayerById(PlayerId);
            return Ok(player);
        }

        [HttpGet("GetPlayersByNickname/{Nickname}")]
        public async Task<ActionResult<ResponseModel<List<PlayerResponseDTO>>>> GetPlayerById(string Nickname)
        {
            var Players = await _playerInterface.GetPlayersByNickname(Nickname);
            return Ok(Players);
        }

        [HttpPost("AddPlayer")]
        public async Task<ActionResult<ResponseModel<PlayerResponseDTO>>> CreatePlayer(PlayerCreateDTO playerDTO)
        {
            var response = await _playerInterface.CreatePlayer(playerDTO);
            return Ok(response);
        }

        [HttpPut("EditPlayer")]
        public async Task<ActionResult<ResponseModel<PlayerResponseDTO>>> EditPlayer(PlayerEditDTO PlayerId)
        {
            var response = await _playerInterface.EditPlayer(PlayerId);
            return Ok(response);
        }

        [HttpDelete("RemovePlayer/{PlayerId}")]
        public async Task<ActionResult<ResponseModel<PlayerModel>>> RemovePlayer(Guid PlayerId)
        {
            var response = await _playerInterface.RemovePlayer(PlayerId);
            return Ok(response);
        }

        // Player.Profile
        /*
        [HttpGet("ProfileList")] 
        public async Task<ActionResult<ResponseModel<List<ProfileModel>>>> GetProfileList()
        {
            var response = await _playerInterface.GetProfileList();
            return Ok(response);
        }

        [HttpGet("GetProfileById/{ProfileId}")]
        public async Task<ActionResult<ResponseModel<ProfileModel>>> GetProfileById(int ProfileId)
        {
            var Profile = await _playerInterface.GetProfileById(ProfileId);
            return Ok(Profile);
        }

        [HttpGet("GetProfileByName")]
        public async Task<ActionResult<ResponseModel<List<ProfileModel>>>> GetProfileByName(string FirstName=null, string LastName=null)
        {
            var Profile = await _playerInterface.GetProfileByName(FirstName, LastName);
            return Ok(Profile);
        }

        [HttpPost("AddProfile")]
        public async Task<ActionResult<ResponseModel<ProfileModel>>> CreateProfile(ProfileCreateDTO CreateDTO)
        {
            var Profile = await _playerInterface.CreateProfile(CreateDTO);
            return Ok(Profile);
        }
        */
    }
}