using MedData.Entities;
using MedData.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MedData.Repositories.Base
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Address>, DbRepository<Address>>()                    //Address      
            .AddTransient<IRepository<AnamnesisVitae>, DbRepository<AnamnesisVitae>>()      //Anamnesis Vitae
            .AddTransient<IRepository<Cabinet>, DbRepository<Cabinet>>()                    //Cabinet
            .AddTransient<IRepository<Chamber>, DbRepository<Chamber>>()                    //Chamber
            .AddTransient<IRepository<Checkup>, DbRepository<Checkup>>()                    //Checkup
            .AddTransient<IRepository<Department>, DbRepository<Department>>()              //Department
            .AddTransient<IRepository<Diagnosis>, DbRepository<Diagnosis>>()                //Diagnosis
            .AddTransient<IRepository<ExaminationType>, DbRepository<ExaminationType>>()    //ExaminationType
            .AddTransient<IRepository<Mkb>, DbRepository<Mkb>>()                            //Mkb
            .AddTransient<IRepository<Position>, DbRepository<Position>>()                  //Position
            .AddTransient<IRepository<Transaction>, DbRepository<Transaction>>()            //Transaction

            .AddTransient<IRepository<User>, UserRepository>()                              //User
            .AddTransient<IRepository<Hospitalization>, HospitalizationRepository>()        //Hospitalization
            .AddTransient<IRepository<Examination>, ExaminationRepository>()                //Examination
            .AddTransient<IRepository<MedCard>, MedCardRepository>()                        //MedCard
        ;
    }
}
