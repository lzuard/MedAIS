using MedData.Data;
using MedData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MedApp.Data
{
    internal class DbInitializer
    {
        private readonly ApplicationContext _context;

        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(ApplicationContext context, ILogger<DbInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация БД...");

            _logger.LogInformation("\tУдаление БД...");
            await _context.Database.EnsureDeletedAsync().ConfigureAwait(false); //Debug delete db
            _logger.LogInformation("\tУдаление БД выполнена за {0} мс", timer.ElapsedMilliseconds);

            _logger.LogInformation("\tМиграция БД...");
            await _context.Database.MigrateAsync(); //ensure created and make up migrations
            _logger.LogInformation("\tМиграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);


            if (await _context.Users.AnyAsync(u => u.Position.Category == MedData.PostionCategory.Admin)) return;
            await CreateAdminAsync();

            _logger.LogInformation("Инициализация БД выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }

        private async Task CreateAdminAsync()
        {
            if (!await _context.Positions.AnyAsync(u => u.Category == MedData.PostionCategory.Admin))
                await CreateAdminPositionAsync();

            if(!await _context.Departments.AnyAsync())
                await CreateAdminDepartmentAsync();

            var position = _context.Positions.First(u => u.Category == MedData.PostionCategory.Admin);
            var department = (Department)_context.Departments.First(u => u.Name == "Отдел IT");

            var user = new User
            {
                Id = 0,
                Name = "Админ",
                Surname = "Админ",
                Patronymic = "Админ",
                Login = "adminUser",
                Password = "adminUser",
                Phone = "NONE",
                Position = position,
                Department = department
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        private async Task CreateAdminPositionAsync()
        {
            var adminPosition = new Position
            {
                Id = 0,
                Name = "Администратор",
                Category = MedData.PostionCategory.Admin
            };

            await _context.Positions.AddAsync(adminPosition);
            await _context.SaveChangesAsync();
        }

        private async Task CreateAdminDepartmentAsync()
        {
            var department1 = new Department
            {
                Id = 0,
                Name = "Отдел IT"
            };
            await _context.Departments.AddAsync(department1);
            await _context.SaveChangesAsync();
        }
    }
}
