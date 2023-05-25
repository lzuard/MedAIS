using MedData.Data;
using MedData.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedData.Repositories
{
    internal class MedCardRepository : DbRepository<MedCard>
    {
        public override IQueryable<MedCard> Items => base.Items
            .Include(i => i.Address)
            .Include(i => i.PatientInChambers);

        public MedCardRepository(ApplicationContext context) : base(context) { }
    }
}
