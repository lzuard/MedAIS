using MedApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCore.Collections.Interfaces;
using MedData.Entities;

namespace MedApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Department> _departmentRepo;
        private readonly IRepository<Chamber> _chamberRepo;
        private readonly IRepository<Hospitalization> _hospitalizationRepo;


        public Department GetUserDepartment(int userId) => 
            _userRepo.Items.Where(u =>u.Id==userId)
                            .Select(u => u.Department)
                            .First();

        //public Chamber GetPatientChamber(int medcardId) =>_chamberRepo.Items.Where(c=>)

        public TransactionService(
            IRepository<User> userRepo, 
            IRepository<Department> departmentRepo, 
            IRepository<Chamber> chamberRepo, 
            IRepository<Hospitalization> hospitalizationRepo)
        {
            _userRepo = userRepo;
            _departmentRepo = departmentRepo;
            _chamberRepo = chamberRepo;
            _hospitalizationRepo = hospitalizationRepo;
        }

    }
}
