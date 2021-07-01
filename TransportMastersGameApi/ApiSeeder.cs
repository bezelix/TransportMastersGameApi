using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportMastersGameApi.Entities;

namespace TransportMastersGameApi
{
    public class ApiSeeder
    {
        private readonly TransportMastersGameDbContext _dbContext;

        public ApiSeeder(TransportMastersGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                Name = "Manager"
            },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }
    }
}
