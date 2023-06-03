using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using MedApp.Services.Instruments;
using MedApp.Services.Interfaces;
using MedData.Entities;
using MedData.Interfaces;
using MedData.Repositories;

namespace MedApp.Services
{
    public class CsvImporterService: ICsvImporterService
    {
        private readonly IRepository<Mkb> _mkbRepo;

        public bool LoadMkb(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader,config);
            csv.Context.RegisterClassMap<CsvToMkbMapper>();
            var records = csv.GetRecords<Mkb>()
                .Where(r => !string.IsNullOrEmpty(r.Code) && !string.IsNullOrEmpty(r.Description)).ToList();

            _mkbRepo.AddRange(records);
            _mkbRepo.SaveChanges();
            return false;
        }

        public CsvImporterService(IRepository<Mkb> mkbRepo)
        {
            _mkbRepo = mkbRepo;
        }
    }
}
