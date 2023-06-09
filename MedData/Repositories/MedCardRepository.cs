﻿using MedData.Data;
using MedData.Entities;
using MedData.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MedData.Repositories
{
    internal class MedCardRepository : DbRepository<MedCard>
    {
        public override IQueryable<MedCard> Items => base.Items
            .Include(i => i.Address);

        public MedCardRepository(ApplicationContext context) : base(context) { }
    }
}
