using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.TelefonRehberi.Models.Concrete
{
    public class Rehber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(40)]
        public string Ad { get; set; }
        [Required, MaxLength(40)]
        public string Soyad { get; set; }
        [Required, MinLength(11), DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
    }
}