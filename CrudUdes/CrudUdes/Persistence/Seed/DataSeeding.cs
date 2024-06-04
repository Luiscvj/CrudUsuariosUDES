using CrudUdes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudUdes.Persistence.Seed
{
    public class DataSeeding
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
               .HasData
               (
                   new Role { RoleId = 1, RoleName = "Administrador" },
                   new Role { RoleId = 2, RoleName = "Empleado" },
                   new Role { RoleId = 3, RoleName = "Gerente" }
               );

            modelBuilder.Entity<DocumentType>()
                .HasData
                (
                    new DocumentType { DocumentTypeId = 1, type = "Cedula" },
                    new DocumentType { DocumentTypeId = 2, type = "Pasaporte" }
                );

            modelBuilder.Entity<User>()
                .HasData
                (
                    new User { UserId = 1, Name = "Jose", LastName= "Villegas" ,DocumentTypeId = 1, DocumentNumber = "1231", Email = "try@try.com", UserName = "Jose_", Password = "jose2yw&IU" }
                );
            modelBuilder.Entity<UserRoles>()
                .HasData
                (
                     new UserRoles { Id = 1, RoleId = 1, UserId = 1 }
                );
        }
    }
}
