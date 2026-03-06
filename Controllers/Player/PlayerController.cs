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

        [HttpGet("PlayerList")]
        public async Task<ActionResult<ResponseModel<List<PlayerModel>>>> PlayerPlayerList()
        {
            var players = await _playerInterface.GetPlayerList();
            return Ok(players);
        }

        [HttpGet("GetPlayerById/{PlayerId}")]
        public async Task<ActionResult<ResponseModel<PlayerModel>>> GetPlayerById(int PlayerId)
        {
            var player = await _playerInterface.GetPlayerById(PlayerId);
            return Ok(player);
        }

        [HttpPost("AddPlayer")]
        public async Task<ActionResult<ResponseModel<PlayerModel>>> CreatePlayer(CreatePlayerDTO playerDTO)
        {
            var response = await _playerInterface.CreatePlayer(playerDTO);
            return Ok(response);
        }
    }
}