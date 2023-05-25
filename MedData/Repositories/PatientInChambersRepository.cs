using MedData.Data;
using MedData.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedData.Repositories
{
    internal class PatientInChambersRepository : DbRepository<PatientInChamber>
    {
        public override IQueryable<PatientInChamber> Items => base.Items
            .Include(i => i.Chamber);

        public PatientInChambersRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
