using System.Collections.Generic;

namespace MedData.Entities
{
    public class Address
    {
        /// <summary>
        /// Id of the Address
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Country 
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Region, for example Moscow oblast'
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// City of the region
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Building, house
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Room, office
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<MedCard> Cards { get; set; }

    }
}
