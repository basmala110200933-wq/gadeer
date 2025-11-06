using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assesment3.Model
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [Required]
        public string PName {  get; set; }
        [Required]
        public string PDescription {  get; set; }
        public DateTime EndDate {  get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<Tasked> taskeds { get; set; }
    }
}
