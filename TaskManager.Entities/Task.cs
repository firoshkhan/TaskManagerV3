using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TaskManager.Entities
{
    [Table("Tbl_Task")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [StringLength(20)]
        public string TaskName { get; set; }
        public int? Priority { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? Startdate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public bool IsParentTask { get; set; }
        public int? TaskProjectId { get; set; }
        [ForeignKey("TaskProjectId")]
        public virtual Project TaskProject { get; set; }

        public int? TaskUserId { get; set; }
        [ForeignKey("TaskUserId")]
        public virtual User TaskUser { get; set; }

        public int? TaskParentId { get; set; }
        [ForeignKey("TaskParentId")]
        public Task TaskParent { get; set; }
    }


}
