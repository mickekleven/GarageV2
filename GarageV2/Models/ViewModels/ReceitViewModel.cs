namespace GarageV2.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class ReceitViewModel
    {



        [Display(Name = "Registrerings nummer")]
        public string Reg { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        [Display(Name = "Parkeringsdatum")]
        public DateTime Arrival { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        [Display(Name = "Utcheckningsdatum")]
        public DateTime CheckOut { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\:hh\:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Parkerad tid")]
        public TimeSpan ParkTime { get; set; }

        [Display(Name = "Parkeringsavgift")]
        public float ParkingPrice { get; set; }
    }
}
