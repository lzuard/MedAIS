using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedData.Data;
using MedData.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedData.Repositories
{
    internal class HospitalizationRepository: DbRepository<Hospitalization>
    {
        public override IQueryable<Hospitalization> Items => base.Items
            .Include(i => i.Examinations);

        public HospitalizationRepository(ApplicationContext context) : base(context){}
    }
}
