using Microsoft.EntityFrameworkCore;
using BandWebApi.Entity;
using System;

namespace BandWebApi.DbContexts
{
    public class BandAlbumContext:DbContext
    {
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options):base(options)
        {

        }
        
        public DbSet<Band> Bands{ get; set; }
        public DbSet<Album>Albums { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Band>().HasData(
             new Band()
            {
            Id=Guid.Parse("a791d1e5-9ec5-427c-b1da-5152fe3b2798"),
            Name="Metallica",
            Founded=new DateTime(1980,1,1),
            MainGenre="Heavy Metal" 
            },
             new Band {
                Id = Guid.Parse("4035ab45-7b8e-41ff-a181-d8f81b6ca633"),
                Name = "Gnus N Roses",
                Founded = new DateTime(1985, 2, 1),
                MainGenre = "Rock"
            } ,
             new Band
             {
                 Id = Guid.Parse("515f0e4b-ec42-476d-b408-e28579352088"),
                 Name = "ABBA",
                 Founded = new DateTime(1965, 7, 1),
                 MainGenre = "Disco"
             },
             new Band
             {
                 Id = Guid.Parse("f51e023d-97de-44ec-bbfb-ff24ef39bdf0"),
                 Name = "Oasis",
                 Founded = new DateTime(1991, 12, 1),
                 MainGenre = "Alternative"
             },
             new Band
             {
                 Id = Guid.Parse("68ffce07-ae53-43cb-a8a8-260f95ca4743"),
                 Name = "A-ha",
                 Founded = new DateTime(1981, 6, 1),
                 MainGenre = "Pop"
             }
            );
            modelBuilder.Entity<Album>().HasData(
           new Album() 
           {
               Id=Guid.Parse("664e3727-fe08-4bba-84a0-918b522443b3"),
               Title="Master Of Poppets",
               Description="One of the best heavy metal album ever",
               BandId=Guid.Parse("a791d1e5-9ec5-427c-b1da-5152fe3b2798")
           },
           new Album {
               Id = Guid.Parse("381aa698-3a67-4322-8c4f-e8fa472fdf9d"),
               Title = "Appetite for Destruction",
               Description = "Amazing Rock album with raw sound",
               BandId = Guid.Parse("4035ab45-7b8e-41ff-a181-d8f81b6ca633")
           },
           new Album
           {
               Id = Guid.Parse("f4393aad-4c77-4a05-8b47-8f84d8841822"),
               Title = "Waterloo",
               Description = "Very groovy album",
               BandId = Guid.Parse("515f0e4b-ec42-476d-b408-e28579352088")
           },
           new Album
           {
               Id = Guid.Parse("5945a30d-0c8e-4c19-b51f-6375f0b56b46"),
               Title = "Be Here Now",
               Description = "Arguably one of the best albums bu Oasis",
               BandId = Guid.Parse("f51e023d-97de-44ec-bbfb-ff24ef39bdf0")
           },
           new Album
           {
               Id = Guid.Parse("1754795b-b366-4e24-abc9-ab10bb60455d"),
               Title = "Huning High and Low ",
               Description = "Awesome Debut album by A-ha",
               BandId = Guid.Parse("68ffce07-ae53-43cb-a8a8-260f95ca4743")
           }
           );
            base.OnModelCreating(modelBuilder);
        }

    }
}
