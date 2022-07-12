namespace GarageV2.Models.ViewModels
{

#nullable disable
    public class VehicleViewModel
    {
        public string RegNr { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public DateTime ArrivalTime { get; set; } = DateTime.MinValue;

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
