using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDMagnus.Models
{
    public class User
    {
        
          public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        
        public bool AWS { get; set; }
        public bool DevOps { get; set; }
        public bool FullStackDeveloper { get; set; }
        public bool Middleware { get; set; }
        public bool QAautomation { get; set; }
        public bool WebServices { get; set; }
        [NotMapped]

        public string place { get; set; }

    }
}
