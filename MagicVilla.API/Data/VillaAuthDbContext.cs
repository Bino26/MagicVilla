﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.API.Data
{
    public class VillaAuthDbContext:IdentityDbContext
    {
        public VillaAuthDbContext(DbContextOptions <VillaAuthDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "d3537521-1f1b-4d0c-89f3-15de5ec27670";
            var writerRoleId = "3a54b3a9-173a-470a-b6f4-008fb4443dd2";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName="Writer".ToUpper()
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

        

         
    }
}
