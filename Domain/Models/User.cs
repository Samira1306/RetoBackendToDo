using Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace Domain.Models
{
    public class User
    {
        [Key]
        public string IdUser { get; set; }
        public string Name {  get; set; }  
        public string Password { get; set; }
        public string Email { get; set; }
        public Preference Preference { get; set; }

    }
}
