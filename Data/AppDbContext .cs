/*
    Date 3 Mar 2026
*/

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using CSLA.Models.Player;

namespace CSLA.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Player.Player → Player.Profile (1:1)
            modelBuilder.Entity<ProfileModel>()
                .HasOne(p => p.Player)
                .WithOne(p => p.Profile)
                .HasForeignKey<ProfileModel>(p => p.PlayerId);

            // 🔹 Player.Player → Player.NativeName (1:1)
            modelBuilder.Entity<NativeNameModel>()
                .HasOne(n => n.Player)
                .WithOne(p => p.NativeName)
                .HasForeignKey<NativeNameModel>(n => n.PlayerId);    

            // 🔹 Player.Player → Player.AlternateID (1:N)
            modelBuilder.Entity<AlternateIDModel>()
                .HasOne(a => a.Player)
                .WithMany(p => p.AlternateIDs)
                .HasForeignKey(a => a.PlayerId);
            
            // 🔹 PlayerRole (N:N via tabela de junção)
            modelBuilder.Entity<RolesModel>()
                .HasKey(pr => new { pr.PlayerId, pr.RoleId });

            // 🔹 Player → PlayerRole (1:N)
            modelBuilder.Entity<RolesModel>()
                .HasOne(pr => pr.Player)
                .WithMany(p => p.Roles)
                .HasForeignKey(pr => pr.PlayerId);

            // 🔹 Role → PlayerRole (1:N)
            modelBuilder.Entity<RolesModel>()
                .HasOne(pr => pr.Role)
                .WithMany(r => r.Roles)
                .HasForeignKey(pr => pr.RoleId);

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<PlayerModel> PlayerPlayer { get; set; }
        public virtual DbSet<ProfileModel> PlayerProfile { get; set; }
        public virtual DbSet<NativeNameModel> PlayerNativeName { get; set; }
        public virtual DbSet<AlternateIDModel> PlayerAlternateID { get; set; }
        public virtual DbSet<RolesModel> PlayerRoles { get; set; }
    }
}

