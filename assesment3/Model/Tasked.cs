using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assesment3.Model
{
    public class Tasked
    {
        [Key]
        public int TaskID { get; set; }
        public int Projectid { get; set; }
        [ForeignKey("Projectid")]
        public Project project { get; set; }
        public int AssignedToUserID {  get; set; }
        [ForeignKey("AssignedToUserID")]
        public User assignedUser { get; set; }
        [Required]
        public string Title { get; set; }
        public string TStatus { get; set; }
        public DateTime DueDate { get; set; }

    }
}
