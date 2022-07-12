namespace GarageV2.Models.ViewModels
{

    using System.ComponentModel.DataAnnotations;

#nullable disable
    public class VehicleViewModel
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Registrerings nummer")]
        public string RegNr { get; set; }


        [Display(Name = "Fordonstyp")]
        public string VehicleType { get; set; }


        [Display(Name = "Parkeringsdatum")]
        [DataType(DataType.Date)]
        public DateTime ArrivalTime { get; init; }


        /// <summary>
        /// HeadLine
        /// </summary>
        public string headLine { get; set; }

        /// <summary>
        /// Message shown to the parking user - CRUD operations
        /// </summary>
        public string UserMessage { get; set; }

        /// <summary>
        /// Flag indicating error or success - CRUD Operations
        /// </summary>
        public bool IsSucceed { get; set; } = true;

    }
}