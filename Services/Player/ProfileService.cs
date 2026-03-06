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

namespace CSTV_v1.Services.Player
{
    public class ProfileService : IProfileInterface
    {
        private readonly AppDbContext _context;
        public ProfileService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ProfileModel>>> GetProfileList()
        {
            ResponseModel<List<ProfileModel>> response = new ResponseModel<List<ProfileModel>>();
            try
            {
                var profileList = await _context.PlayeProfile.ToListAsync();
                response.Dados = profileList;
                response.Message = "Todos os profiles foram coletados!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<ProfileModel>> GetProfileById(int ProfileId)
        {
            ResponseModel<ProfileModel> response = new ResponseModel<ProfileModel>();
            try
            {
                var profile = await _context.PlayeProfile.FirstOrDefaultAsync(x => x.Id == ProfileId);

                if ( profile == null )
                {
                    response.Message = "Profile não encontrado!";
                    return response;           
                }

                response.Dados = profile;
                response.Message = "Todos os profiles foram coletados!";

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