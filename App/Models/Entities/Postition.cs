﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Models.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PostionCategory Category { get; set; }
    }
}
