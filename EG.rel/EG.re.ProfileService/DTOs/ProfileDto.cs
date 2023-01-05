using System.ComponentModel.DataAnnotations;

namespace EG.rel.ProfileService.DTOs
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? Patronymic { get; set; }
        public int? AddressId { get; set; }
        /// <summary>
        /// Адрес пользователя
        /// </summary>
        public virtual AddressDto Address { get; set; }
        public virtual ICollection<HobbyDto> Hobbies { get; set; }
    }
    public class InsertProfileDto
    {
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? Patronymic { get; set; }
        public int? AddressId { get; set; }
        /// <summary>
        /// Адрес пользователя
        /// </summary>
        public virtual InsertAddressDto Address { get; set; }
        public virtual ICollection<InsertHobbyDto> Hobbies { get; set; }
    }
}
