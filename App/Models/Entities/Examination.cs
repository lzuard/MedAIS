using System;

namespace MedApp.Models.Entities
{
    public class Examination
    {
        /// <summary>
        /// Id of the examination
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// id of the hospitalization
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Id of the cabinet
        /// </summary>
        public int CabinetId { get; set; }

        /// <summary>
        /// Id of th doctor
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Date of examination
        /// </summary>
        public DateTime Date { get;set; }

        /// <summary>
        /// The result of the examination
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Cabinet Cabinet { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public User User { get; set; } 
    }
}
