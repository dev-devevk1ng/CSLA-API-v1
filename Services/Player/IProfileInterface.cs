/*
    Date 4 Mar 2026
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CSTV_v1.Models;
using CSTV_v1.Models.Player;

namespace CSTV_v1.Services.Player
{
    public interface IProfileInterface
    {
        Task<ResponseModel<List<ProfileModel>>> GetProfileList();
        Task<ResponseModel<ProfileModel>> GetProfileById(int ProfileId);
    }
}