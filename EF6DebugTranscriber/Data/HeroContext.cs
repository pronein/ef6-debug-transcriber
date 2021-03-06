﻿using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Reflection;
using EF6DebugTranscriber.Data.Entities;

namespace EF6DebugTranscriber.Data {
    public class HeroContext : DbContext {
        public DbSet<HeroEntity> Heros { get; set; }
        public DbSet<GearEntity> Gear { get; set; }

        public HeroContext() : base("name=HerosDbConnectionString") {
            Database.Log = log => Trace.WriteLine($"<ctx>{log.Substring(0, log.Length - 2)}</ctx>\n", nameof(HeroContext));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
