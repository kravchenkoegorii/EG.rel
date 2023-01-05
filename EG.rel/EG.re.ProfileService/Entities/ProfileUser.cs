using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EG.rel.ProfileService.Entities
{
    public class ProfileUser
    {
        public int Id { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        [MaxLength(50)]
        public string? Patronymic { get; set; }

        public int? AddressId { get; set; }
        /// <summary>
        /// Адрес пользователя
        /// </summary>
        public virtual Address Address { get; set; }
        /// <summary>
        /// Увлечения пользователя
        /// </summary>
        public virtual ICollection<Hobby> Hobbies { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Concat(Surname, ' ', Name, !string.IsNullOrWhiteSpace(Patronymic) ? string.Concat(' ', Patronymic) : string.Empty);
            }
        }
    }
}
