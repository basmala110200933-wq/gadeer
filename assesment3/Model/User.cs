using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assesment3.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UName { get; set; }
        public string UEmail { get; set; }
        [Required]
        public string UPassword { get; set; }
        public string URole { get; set; }
        public ICollection<Tasked> taskeds { get; set; }
    }
}
