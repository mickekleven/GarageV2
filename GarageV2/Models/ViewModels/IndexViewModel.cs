namespace GarageV2.Models.ViewModels
{

    using System.ComponentModel.DataAnnotations;
    public class IndexViewModel
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


    }
}