using MedData.Entities;
using MedData.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MedData.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepostoriesInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Address>, DbRepository<Address>>()
            .AddTransient<IRepository<Allergen>, DbRepository<Allergen>>()
            .AddTransient<IRepository<Allergy>, DbRepository<Allergy>>()
            .AddTransient<IRepository<AnamnesisVitae>, DbRepository<AnamnesisVitae>>()
            .AddTransient<IRepository<Cabinet>, DbRepository<Cabinet>>()
            .AddTransient<IRepository<Chamber>, DbRepository<Chamber>>()
            .AddTransient<IRepository<Checkups>, DbRepository<Checkups>>()
            .AddTransient<IRepository<Department>, DbRepository<Department>>()
            .AddTransient<IRepository<Diagnoses>, DbRepository<Diagnoses>>()
            .AddTransient<IRepository<Diagnosis>, DbRepository<Diagnosis>>()
            .AddTransient<IRepository<Examination>, DbRepository<Examination>>()
            .AddTransient<IRepository<MedCard>, DbRepository<MedCard>>()
            .AddTransient<IRepository<Mkb>, DbRepository<Mkb>>()
            .AddTransient<IRepository<PatientInChamber>, DbRepository<PatientInChamber>>()
            .AddTransient<IRepository<Position>, DbRepository<Position>>()
            .AddTransient<IRepository<Transaction>, DbRepository<Transaction>>()
            .AddTransient<IRepository<User>, UserRepository>()
            .AddTransient<IRepository<Checkups>, DbRepository<Checkups>>()
            ;
    }
}
