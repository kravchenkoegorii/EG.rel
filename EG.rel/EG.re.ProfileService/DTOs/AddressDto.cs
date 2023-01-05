namespace EG.rel.ProfileService.DTOs
{
    public class InsertAddressDto
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
    }
    public class AddressDto
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
    }
}
