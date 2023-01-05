namespace EG.rel.ProfileService.Entities
{
    public class Address
    {
        public int Id { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public string? Street { get; set; }
        /// <summary>
        /// Дом
        /// </summary>
        public string? House { get; set; }
        /// <summary>
        /// Широта
        /// </summary>
        public double? Lat { get; set; }
        /// <summary>
        /// Долгота 
        /// </summary>
        public double? Lon { get; set; }
    }
}
