using System.ComponentModel.DataAnnotations.Schema;
using MedData.Entities.Base;

namespace MedData.Entities
{
    public class Transaction : Entity
    {
        /// <summary>
        /// Hospitalization id
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Chamber from
        /// </summary>
        public int OldChamberId { get; set; }

        /// <summary>
        /// Chamber to
        /// </summary>
        public int NewChamberId { get; set; }

        /// <summary>
        /// Transaction type
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// Date of the transaction
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// SPOR string
        /// </summary>
        public string Spor { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        [ForeignKey("OldChamberId")]
        public Chamber OldChamber { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        [ForeignKey("NewChamberId")]
        public Chamber NewChamber { get; set; }
    }
}
