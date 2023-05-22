﻿using Microsoft.EntityFrameworkCore;

namespace MedApp.Models.Data
{
    internal partial class ApplicationContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }

        
    }
}
