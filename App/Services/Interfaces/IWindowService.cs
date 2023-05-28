﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedData.Entities;

namespace MedApp.Services.Interfaces
{
    interface IWindowService
    {
        public void OpenExistingCheckupWindow(Checkup checkup);

        public void OpenNewCheckupWindow(int hospitalizationId);

        public void OpenExistingExamination(Examination examination);

        public void OpenNewExaminationWindow(int  hospitalizationId);
    }
}
