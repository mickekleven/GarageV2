namespace GarageV2.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class TicketViewModel
    {
        [Display(Name = "Registrerings nummer")]
        public String RegNr { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        [Display(Name = "Parkeringsdatum")]
        public DateTime ArrivalTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        [Display(Name = "Utcheckningsdatum")]
        public DateTime CheckOutTime { get; set; }


        [Display(Name = "Parkerad tid")]
        public TimeSpan Ptime { get; set; }

        [Display(Name = "Parkeringsavgift")]
        public float Price { get; set; }


    }
}
