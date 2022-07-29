using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var costumers = new Costumer[]{
            new Costumer{
                BirthDate=DateTime.Parse("1997-12-21"),
                Email="dalmaasiof@gmail.com",
                Id=1,
                Name="Dalmasio Fernandes"
            },
            new Costumer{
                BirthDate = DateTime.Parse("2007-05-13"),
                Email = "joaosao@gmail.com",
                Id = 2,
                Name = "Joao Pedro"
                }
            };

            modelBuilder.Entity<Costumer>().HasData(costumers);


            base.OnModelCreating(modelBuilder);
        }

        DbSet<Costumer> costumers { get; set; }
    }
}
