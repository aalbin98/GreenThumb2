using GreenThumb2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb2.Database
{
    internal class GreenThumb2DbContext :DbContext
    {
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumb2;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlantModel>()
                .HasData(
                new PlantModel()
                {
                    PlantId = 1,
                    PlantName = "Rose"
                });
            modelBuilder.Entity<InstructionModel>()
                .HasData(
                new InstructionModel()
                {
                    InstructionId = 1,
                    Instruction = "Water frequently",
                    PlantId = 1
                },
                new InstructionModel()
                {
                    InstructionId = 2,
                    Instruction = "Beware of the pointy thorns ",
                    PlantId = 1
                });


        }
    }
}
