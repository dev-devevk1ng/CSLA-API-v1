/*
    Date 4 Mar 2026
*/
/*
    SQLServer services, IPlayerInterface -> PlayerService -> PlayerController
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSTV_v1.Data;
using Microsoft.EntityFrameworkCore;

using CSTV_v1.Models;
using CSTV_v1.Models.Player;
using CSTV_v1.DTO.Player;


namespace CSTV_v1.Services.Player
{
    public class PlayerService : IPlayerInterface
    {
        private readonly AppDbContext _context;
        public PlayerService(AppDbContext context)
        {
            _context = context;
        }

        // Player.Player
        public async Task<ResponseModel<List<PlayerResponseDTO>>> GetPlayerList()
        {
            ResponseModel<List<PlayerResponseDTO>> response = new ResponseModel<List<PlayerResponseDTO>>();
            try
            {
                var playerList = await _context.PlayerPlayer
                .AsNoTracking()
                .Select( player => new PlayerResponseDTO
                {
                    Id = player.Id,
                    Nickname = player.Nickname,
                    CreatedAt = player.CreatedAt
                })
                .ToListAsync();

                if (playerList == null || playerList.Count == 0)
                {
                    response.Message = "Nenhum Player.Player encontrado!";
                    response.Dados = playerList;
                    return response;
                }

                response.Dados = playerList;
                response.Message = "Todos os Player.Player foram coletados!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<PlayerResponseDTO>> GetPlayerById(Guid PlayerId)
        {
            ResponseModel<PlayerResponseDTO> response = new ResponseModel<PlayerResponseDTO>();
            try
            {
               // var Player = await _context.Players.FirstOrDefaultAsync(x => x.Id == PlayerId);
                
                var Player = await _context.PlayerPlayer
                .AsNoTracking()
                .Select( player => new PlayerResponseDTO
                {
                    Id = player.Id,
                    Nickname = player.Nickname,
                    CreatedAt = player.CreatedAt
                })
                .FirstOrDefaultAsync(x => x.Id == PlayerId);

                if ( Player == null )
                {
                    response.Message = "Player.Player não encontrado!";
                    return response;           
                }

                response.Dados = Player;
                response.Message = "Player.Player encontrado!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<PlayerResponseDTO>>> GetPlayersByNickname(string nickname)
        {
            ResponseModel<List<PlayerResponseDTO>> response = new ResponseModel<List<PlayerResponseDTO>>();
            try
            {
                var Players = await _context.PlayerPlayer
                .AsNoTracking()
                .Select( player => new PlayerResponseDTO
                {
                    Id = player.Id,
                    Nickname = player.Nickname,
                    CreatedAt = player.CreatedAt
                })
                .Where(x => x.Nickname == nickname)
                .ToListAsync();

                if ( Players == null || Players.Count == 0 )
                {
                    response.Message = "Player.Player não encontrado!";
                    return response;
                }

                response.Message = Players.Count() + "Player.Player coletado(s)!";
                response.Dados = Players;

                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<PlayerResponseDTO>> CreatePlayer(PlayerCreateDTO PlayerDTO)
        {
            ResponseModel<PlayerResponseDTO> response = new ResponseModel<PlayerResponseDTO>();
            try
            {
               var Player = new PlayerModel()
               {
                   Nickname = PlayerDTO.Nickname
               };

                _context.PlayerPlayer.Add(Player);
                await _context.SaveChangesAsync();

                var PlayerResponse = new PlayerResponseDTO
                {
                    Id = Player.Id,
                    Nickname = Player.Nickname,
                    CreatedAt = Player.CreatedAt
                };
        
                response.Message = "Player.Player criado com sucesso!";
                response.Dados = PlayerResponse;

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
   
        public async Task<ResponseModel<PlayerResponseDTO>> EditPlayer(PlayerEditDTO PlayerEditDTO)
        {
            // user envia Id, que sera usado para proucurar o player, e Nickname, que sera usado como novo Nickname.

            ResponseModel<PlayerResponseDTO> response = new ResponseModel<PlayerResponseDTO>();
            try
            {
                var Player = await _context.PlayerPlayer
                .FirstOrDefaultAsync( Player => Player.Id == PlayerEditDTO.Id);
                
                if ( Player == null )
                {
                    response.Message = "Player.Player not found!";
                    return response;
                }

                Player.Nickname = PlayerEditDTO.Nickname;
                //_context.Update(player);
                await _context.SaveChangesAsync();

                PlayerResponseDTO PlayerResponse = new PlayerResponseDTO
                {
                    Id = Player.Id,
                    Nickname = Player.Nickname,
                    CreatedAt = Player.CreatedAt,
                };

                response.Dados = PlayerResponse;
                response.Message = "Player edited";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        
        public async Task<ResponseModel<PlayerResponseDTO>> RemovePlayer(Guid PlayerId)
        {
            ResponseModel<PlayerResponseDTO> response = new ResponseModel<PlayerResponseDTO>();
            try
            {
                var Player = await _context.PlayerPlayer
                .FirstOrDefaultAsync( Player => Player.Id == PlayerId );

                if ( Player == null )
                {
                    response.Message = "Player not found!";
                    return response;
                }

                PlayerResponseDTO PlayerResponse = new PlayerResponseDTO
                {
                    Id = Player.Id,
                    Nickname = Player.Nickname,
                    CreatedAt = Player.CreatedAt,
                };

                _context.Remove(Player);
                await _context.SaveChangesAsync();

                response.Dados = PlayerResponse;
                response.Message = "Player deleted";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        // Player.Profile
        /*
        public async Task<ResponseModel<List<ProfileResponseDTO>>> GetProfileList()
        {
            ResponseModel<List<ProfileResponseDTO>> response = new ResponseModel<List<ProfileResponseDTO>>();
            try
            {
            
                var profiles = await _context.Profiles
                .AsNoTracking()
                .Select(p => new ProfileResponseDTO
                {
                    Id = p.Id,
                    PlayerId = p.PlayerId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Born = p.Born,
                    Status = p.Status,
                    ApproxTotalWinnings = p.ApproxTotalWinnings,
                    YearCareerStart = p.YearCareerStart,
                    YearCareerEnd = p.YearCareerEnd,
                    CreatedAt = p.CreatedAt,
                    PlayerNickname = p.Player!.Nickname
                }).ToListAsync();

                if (profiles == null)
                {
                    response.Message = "Player.Profile não encontrados!";
                    return response;
                }

                response.Dados = profiles;
                response.Message = "Player.Profile foram coletados!";
                
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<ProfileResponseDTO>> GetProfileById(int ProfileId)
        {
            ResponseModel<ProfileResponseDTO> response = new ResponseModel<ProfileResponseDTO>();
            try
            {
                //var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.Id == ProfileId);
                
                var profile = await _context.Profiles
                .AsNoTracking()
                .Select(p => new ProfileResponseDTO
                {
                    Id = p.Id,
                    PlayerId = p.PlayerId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Born = p.Born,
                    Status = p.Status,
                    ApproxTotalWinnings = p.ApproxTotalWinnings,
                    YearCareerStart = p.YearCareerStart,
                    YearCareerEnd = p.YearCareerEnd,
                    CreatedAt = p.CreatedAt,
                    PlayerNickname = p.Player!.Nickname
                })
                .FirstOrDefaultAsync(x => x.Id == ProfileId);      
                
                if (profile == null)
                {
                    response.Message = "Player.Profile não encontrado!";
                    return response;
                }

                response.Dados = profile;
                response.Message = "Player.Profile coletado!";
                
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ProfileResponseDTO>>> GetProfileByName(string FirstName, string LastName)
        {
            ResponseModel<List<ProfileResponseDTO>> response = new ResponseModel<List<ProfileResponseDTO>>();
            try
            {
                var query = _context.Profiles.AsQueryable();

                if (!string.IsNullOrEmpty(FirstName))
                {
                    query = query.Where(x => x.FirstName == FirstName);
                }

                if (!string.IsNullOrEmpty(LastName))
                {
                    query = query.Where(x => x.LastName == LastName);
                }

                var profiles = await query
                .AsNoTracking()
                .Select(p => new ProfileResponseDTO
                {
                    Id = p.Id,
                    PlayerId = p.PlayerId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Born = p.Born,
                    Status = p.Status,
                    ApproxTotalWinnings = p.ApproxTotalWinnings,
                    YearCareerStart = p.YearCareerStart,
                    YearCareerEnd = p.YearCareerEnd,
                    CreatedAt = p.CreatedAt,
                    PlayerNickname = p.Player!.Nickname
                })
                .ToListAsync();

                if (profiles == null)
                {
                    response.Message = "Player.Profile não encontrado!";
                    return response;
                }
                response.Dados = profiles;
                response.Message = "Player.Profile coletado(s)!";
                
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<ProfileResponseDTO>> CreateProfile(ProfileCreateDTO CreateDTO)
        {
            ResponseModel<ProfileResponseDTO> response = new ResponseModel<ProfileResponseDTO>();
            try
            {
               var Profile = new ProfileModel()
               {
                    PlayerId = CreateDTO.PlayerId,
                    FirstName = CreateDTO.FirstName,
                    LastName = CreateDTO.LastName,
                    Born = CreateDTO.Born,
                    Status = CreateDTO.Status,
                    ApproxTotalWinnings = CreateDTO.ApproxTotalWinnings,
                    YearCareerStart = CreateDTO.YearCareerStart,
                    YearCareerEnd = CreateDTO.YearCareerEnd,
                    CreatedAt = DateTime.UtcNow
               };

                _context.Profiles.Add(Profile);
                await _context.SaveChangesAsync();

                var ProfileResponse = await _context.Profiles
                .AsNoTracking()
                .Where(p => p.Id == Profile.Id)
                .Select(p => new ProfileResponseDTO
                {
                    Id = p.Id,
                    PlayerId = p.PlayerId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Born = p.Born,
                    Status = p.Status,
                    ApproxTotalWinnings = p.ApproxTotalWinnings,
                    YearCareerStart = p.YearCareerStart,
                    YearCareerEnd = p.YearCareerEnd,
                    CreatedAt = p.CreatedAt,
                    PlayerNickname = p.Player!.Nickname
                })
                .FirstOrDefaultAsync();
        
                response.Message = "Player.Profile criado com sucesso!";
                response.Dados = ProfileResponse;

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        */

    }
}