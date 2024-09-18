using System.ComponentModel.DataAnnotations;
using WebAPI_Projeto01.Enums;

namespace WebAPI_Projeto01.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DepartamentEnum Departament { get; set; }
        public bool Status { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime Updated_at { get; set; } = DateTime.Now.ToLocalTime();
    }
}
