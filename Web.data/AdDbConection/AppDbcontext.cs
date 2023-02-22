using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.data.model;

namespace Web.data.AdDbConection
{
    public class AppDbcontext : IdentityDbContext<ApiUser, Role, long>
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) { }

        public DbSet<Kompaniya> Kompaniyalar { get; set; }
        public  DbSet<Mashina> Mashinalar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.Entity<Kompaniya>(p => p
            .HasMany(p => p.mashinalar)
            .WithOne(p => p.Kompaniya)
            .HasForeignKey(p => p.Kompaniya_Id));

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

        }

        public class RoleConfiguration : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "User",
                        NormalizedName = "USER"
                    }
                );
            }
        }
        
        public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
        {
            public void Configure(EntityTypeBuilder<ApiUser> builder)
            {
                var hasher = new PasswordHasher<ApiUser>();
                builder.HasData(
                    new ApiUser
                    {
                        Id = 1,
                        FirstName = "Mansur",
                        LastName = "Xamrayev",
                        UserName = "Khmansur",
                        NormalizedUserName = "KHMANSUR",
                        PasswordHash = hasher.HashPassword(null, "Khmansur8#")
                    },
                    new ApiUser
                    {
                        Id = 2,
                        FirstName = "Aziz",
                        LastName = "A'zamjonov",
                        UserName = "Aziz",
                        NormalizedUserName = "AZIZ",
                        PasswordHash = hasher.HashPassword(null, "8888")
                    },
                    new ApiUser
                    {
                        Id = 3,
                        FirstName = "Jaloliddin",
                        LastName = "Axmedov",
                        UserName = "Jaloliddin",
                        NormalizedUserName = "JALOLIDDIN",
                        PasswordHash = hasher.HashPassword(null, "3008")
                    },
                    new ApiUser
                    {
                        Id = 4,
                        FirstName = "Murod",
                        LastName = "Abdullayev",
                        UserName = "Markroft",
                        NormalizedUserName = "MARKROFT",
                        PasswordHash = hasher.HashPassword(null, "1012")
                    },
                    new ApiUser
                    {
                        Id = 5,
                        FirstName = "Samandar",
                        LastName = "Bekmurodov",
                        UserName = "Samandar",
                        NormalizedUserName = "SAMANDAR",
                        PasswordHash = hasher.HashPassword(null, "1202")
                    },
                    new ApiUser
                    {
                        Id = 6,
                        FirstName = "Saidakbar",
                        LastName = "Abdimajidov",
                        UserName = "Saidakbar",
                        NormalizedUserName = "SAIDAKBAR",
                        PasswordHash = hasher.HashPassword(null, "7777")
                    },
                    new ApiUser
                    {
                        Id = 7,
                        FirstName = "Shohjahon",
                        LastName = "Normuminov",
                        UserName = "Shoh",
                        NormalizedUserName = "SHOH",
                        PasswordHash = hasher.HashPassword(null, "1080")
                    }
                );
            }
        }

        public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<long>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
            {
                var hasher = new PasswordHasher<ApiUser>();
                builder.HasData(
                    new IdentityUserRole<long>
                    {
                        UserId = 1,
                        RoleId = 1
                    },
                    new IdentityUserRole<long>
                    {
                        UserId = 2,
                        RoleId = 2
                    },
                    new IdentityUserRole<long>
                    {
                        UserId = 3,
                        RoleId = 2
                    },
                    new IdentityUserRole<long>
                    {
                        UserId = 4,
                        RoleId = 1
                    },
                    new IdentityUserRole<long>
                    {
                        UserId = 5,
                        RoleId = 2
                    },
                    new IdentityUserRole<long>
                    {
                        UserId = 6,
                        RoleId = 1
                    },
                    new IdentityUserRole<long>
                    {
                        UserId = 7,
                        RoleId = 2
                    }
                );
            }
        }


    }
}
