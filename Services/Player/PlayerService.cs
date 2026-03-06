/*
    Date 4 Mar 2026
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

        public async Task<ResponseModel<List<PlayerModel>>> GetPlayerList()
        {
            ResponseModel<List<PlayerModel>> response = new ResponseModel<List<PlayerModel>>();
            try
            {
                var PlayerList = await _context.PlayerPlayer.ToListAsync();
                response.Dados = PlayerList;
                response.Message = "Todos os players foram coletados!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<PlayerModel>> GetPlayerById(int PlayerId)
        {
            ResponseModel<PlayerModel> response = new ResponseModel<PlayerModel>();
            try
            {
                var Player = await _context.PlayerPlayer.FirstOrDefaultAsync(x => x.Id == PlayerId);

                if ( Player == null )
                {
                    response.Message = "Player não encontrado!";
                    return response;           
                }

                response.Dados = Player;
                response.Message = "Player encontrado!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<PlayerModel>> CreatePlayer(CreatePlayerDTO PlayerDTO)
        {
            ResponseModel<PlayerModel> response = new ResponseModel<PlayerModel>();
            try
            {
               var player = new PlayerModel()
               {
                   Nickname = PlayerDTO.Nickname
               };

                _context.Add(player);
                await _context.SaveChangesAsync();
        
                response.Message = "Jogador criado com sucesso!";
                response.Dados = player;

                //var playerResult = await _context.PlayerPlayer.

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        
    }
}