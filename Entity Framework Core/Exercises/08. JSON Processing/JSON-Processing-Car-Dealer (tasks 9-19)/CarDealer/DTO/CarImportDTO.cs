namespace CarDealer.DTO
{
    public class CarImportDTO
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public int[] PartsId { get; set; }

    }
}
