using System.ComponentModel.DataAnnotations;

#nullable disable
public class Vehicle
{
    [Key]
    [Required]
    [StringLength(10)]
    [Display(Name = "Regnr")]
    [RegularExpression(@"^[a-zA-Z-0-9 ]+$", ErrorMessage = "Endast siffror och text är tillåtet")]
    public string RegNr { get; set; }

    [Required]
    [StringLength(15)]
    [Display(Name = "Färg")]
    public string Color { get; set; }

    [Range(0, 6)]
    [Display(Name = "Antal Hjul")]
    public int Wheels { get; set; }

    [Required]
    [StringLength(10)]
    [Display(Name = "Märke")]
    public string Brand { get; set; }

    [Required]
    [Display(Name = "Modell")]
    public string Model { get; set; }

    [Required]
    [Display(Name = "Fordonstyp")]
    public string VehicleType { get; set; }

    [Display(Name = "Ankomsttid")]
    public DateTime ArrivalTime { get; set; } = DateTime.MinValue;

}