
namespace MedApp.Models.Entities
{
    public class PatientInChamber
    {
        /// <summary>
        /// Id of the medical card (patient)
        /// </summary>
        public int MedCardId { get; set; }

        /// <summary>
        /// Id of the chamber
        /// </summary>
        public int ChamberId { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public MedCard MedCard { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Chamber Chamber { get; set; }
    }
}
