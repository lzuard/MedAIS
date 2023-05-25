using MedApp.Services.Interfaces;
using MedData.Entities;
using MedData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedApp.Services
{
    public class DepartmentProvider : IDepartmentProvider
    {
        private readonly IRepository<Department> _departmentsRepo;

        public DepartmentProvider(IRepository<Department> departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }

        public IEnumerable<Department> GetValues() => 
            _departmentsRepo.Items.ToList();

        public bool WriteValues(IEnumerable<Department> value)
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
