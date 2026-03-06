/*
    Date 3 Mar 2026
*/

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using CSTV_v1.Models.Player;

namespace CSTV_v1.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<PlayerModel> PlayerPlayer { get; set; }
        public virtual DbSet<ProfileModel> PlayeProfile { get; set; }
        
    }
}

