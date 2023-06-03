using MedData.Data;
using MedData.Entities;
using MedData.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedData.Repositories
{
    internal class UserRepository : DbRepository<User>
    {
        public override IQueryable<User> Items => base.Items
            .Include(i => i.Department)
            .Include(i => i.Position)
            .Include(i=>i.Chambers);

        public UserRepository(ApplicationContext context) : base(context) { }
    }
}
