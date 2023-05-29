using MedData.Data;
using MedData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedData.Repositories
{
    internal class CheckupsRepository : DbRepository<Checkups>
    {
        public override IQueryable<Checkups> Items => base.Items
            .Include(i => i.Checkup)
            .Include(i => i.Hospitalization);

        public CheckupsRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
