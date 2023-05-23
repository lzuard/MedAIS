﻿using MedData.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace MedData.Entities
{
    public class Allergy : Entity
    {
        /// <summary>
        /// Medical card ID
        /// </summary>
        public int MedCardId { get; set; }

        /// <summary>
        /// Allergen ID
        /// </summary>
        public int AllergenId { get; set; }

        /// <summary>
        /// EF Navigation property
        /// </summary>
        public MedCard MedCard { get; set; }

        /// <summary>
        /// ED Navigation property
        /// </summary>
        public Allergen Allergen { get; set; }
    }
}