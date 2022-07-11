using System.ComponentModel.DataAnnotations;

#nullable disable
public class Vehicle
{
    [Key]
    [StringLength(10)]
    public string RegNr { get; set; }

    [Required]
    [StringLength(15)]
    public string Color { get; set; }

    [Range(0, 6)]
    public int Wheels { get; set; }

    [Required]
    [StringLength(10)]
    public string Brand { get; set; }

    [Required]
    public string Model { get; set; }

    [Required]
    public string VehicleType { get; set; }
    public DateTime ArrivalTime { get; set; } = DateTime.MinValue;

}