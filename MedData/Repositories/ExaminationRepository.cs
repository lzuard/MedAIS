using MedData.Data;
using MedData.Entities;
using MedData.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedData.Repositories
{
    internal class ExaminationRepository : DbRepository<Examination>
    {
        public override IQueryable<Examination> Items => base.Items
            .Include(i=>i.Hospitalization)
            .Include(i=> i.Cabinet)
            .Include(i=> i.ExaminationType)
            .Include(i=> i.User)
        ;

        public ExaminationRepository(ApplicationContext context) : base(context) { }
    }
}
