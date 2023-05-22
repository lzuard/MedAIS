using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace MedApp.Models.Entities
{
    public class Transaction
    {
        /// <summary>
        /// Id of the transaction
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hospitalization id
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Transaction type
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// Date of the transaction
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Chamber from
        /// </summary>
        public int OldChamberId { get; set; }

        /// <summary>
        /// Chamber to
        /// </summary>
        public int NewChamberId { get; set; }

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
        public Chamber OldChamber { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Chamber NewChamber { get; set; }
    }
}
