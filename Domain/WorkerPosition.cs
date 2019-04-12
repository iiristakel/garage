using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class WorkerPosition : BaseEntity
    {
        public ICollection<WorkerInPosition> WorkersInPosition { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string WorkerPositionValue { get; set; }
    }
}