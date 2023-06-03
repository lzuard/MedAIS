using CsvHelper.Configuration;
using MedData.Entities;

namespace MedApp.Services.Instruments
{
    public sealed class CsvToMkbMapper : ClassMap<Mkb>
    {
        public CsvToMkbMapper()
        {
            Map(mkb => mkb.Code).Index(2);
            Map(mkb => mkb.Description).Index(3);
        }
    }
}
