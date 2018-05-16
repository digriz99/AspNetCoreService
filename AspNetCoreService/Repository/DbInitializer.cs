using System;
using System.Linq;

namespace AspNetCoreService.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(UsersContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            context.Users.Add(new Models.UserModel
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Surname = "User",
                Telephone = "123-123-123",
                Address = "Neverland"
            });

            context.SaveChanges();
        }
    }
}
