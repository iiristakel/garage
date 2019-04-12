using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class WorkerInPosition : BaseEntity
    {
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int WorkerPositionId { get; set; }
        public WorkerPosition WorkerPosition { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Until { get; set; }
    }
}