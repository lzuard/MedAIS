using MedData.Entities.Base;

namespace MedData.Entities
{

    public class AnamnesisVitae : Entity
    {
        /// <summary>
        /// Anamesis ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// HospitalizationID
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Patient's work period description
        /// </summary>
        public string WorkPeriod { get; set; }

        /// <summary>
        /// Patient's life description
        /// </summary>
        public string LifeAnamnesis { get; set; }

        /// <summary>
        /// Patient's family heredity
        /// </summary>
        public string Heredity { get; set; }

        /// <summary>
        /// Patient's past diseases
        /// </summary>
        public string PastDiseases { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }
    }
}
