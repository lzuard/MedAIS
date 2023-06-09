﻿using MedData.Entities.Base;
using System.Collections.Generic;

namespace MedData.Entities
{
    public class User : Entity
    {
        /// <summary>
        /// Id of the department
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Id of the position
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// User Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// user patronymic
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Examination> Examinations { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Checkup> Checkup { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Chamber> Chambers { get; set; }


        public override string ToString() => Surname+ " " + Name+" "+Patronymic;

        public string GetNameAndPosition() => ToString() + " - " + Position.Name;

        public string GetNamePositionAndPhone() => GetNameAndPosition() + " - " + Phone;
    }
}
