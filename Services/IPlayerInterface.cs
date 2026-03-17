/*
    Date 4 Mar 2026
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CSTV_v1.Models;
using CSTV_v1.Models.Player;
using CSTV_v1.DTO.Player;

namespace CSTV_v1.Services.Player
{
    public interface IPlayerInterface
    {
        // Player.Player
        Task<ResponseModel<List<PlayerResponseDTO>>> GetPlayerList();
        Task<ResponseModel<PlayerResponseDTO>> GetPlayerById(Guid PlayerId);
        Task<ResponseModel<List<PlayerResponseDTO>>> GetPlayersByNickname(string Nickname);
        Task<ResponseModel<PlayerResponseDTO>> CreatePlayer(PlayerCreateDTO PlayerDTO);
        Task<ResponseModel<PlayerResponseDTO>> EditPlayer(PlayerEditDTO PlayerEditDTO);
        Task<ResponseModel<PlayerResponseDTO>> RemovePlayer(Guid PlayerId);
        
        // Player.Profile
        /*
        Task<ResponseModel<List<ProfileResponseDTO>>> GetProfileList();
        Task<ResponseModel<ProfileResponseDTO>> GetProfileById(int ProfileId);
        Task<ResponseModel<List<ProfileResponseDTO>>> GetProfileByName(string FirstName, string LastName);
        Task<ResponseModel<ProfileResponseDTO>> CreateProfile(ProfileCreateDTO CreateDTO);
        */
    }
}