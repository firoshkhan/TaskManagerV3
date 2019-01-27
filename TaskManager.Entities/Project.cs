using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entities
{
    [Table("Tbl_Project")]
    public class Project
    {

        [Key]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }

        public int? Priority { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? Startdate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? Enddate { get; set; }

        //  [Display(Name= "User")]
        public int? ProjectManagerId { get; set; }
        [ForeignKey("ProjectManagerId")]
        public User ProjectManager { get; set; }
        //    [NotMapped]
        //    public string FirstName { get; set; }
        //  [NotMapped]
        // public string LastName { get; set; }



        [NotMapped]
        public int? TotNoofTasks { get; set; }

        [NotMapped]
        public int? NoofTasksCompleted { get; set; }


    }
}
