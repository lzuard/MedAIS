using MedApp.Services.Interfaces;
using MedData.Entities;
using MedData.Entities.Base;
using MedData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedApp.Services
{
    public class EntityCollectionProvider<T> : IEntitiesCollectionProvider<T> where T : Entity, new()
    {
        private readonly IRepository<T> _departmentsRepo;

        public EntityCollectionProvider(IRepository<T> departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }

        public IEnumerable<T> GetValues() => 
            _departmentsRepo.Items.ToList();

        public bool WriteValues(IEnumerable<T> value)
        {
            try
            {
                foreach (var department in value)
                {
                    if (department.Id == 0)
                    {
                        if (department != _departmentsRepo.Add(department))
                            throw new Exception();
                    }
                }
                _departmentsRepo.SaveChanges();
                return true;
            }
            catch 
            {
                return false; 
            }
        }
    }
}
