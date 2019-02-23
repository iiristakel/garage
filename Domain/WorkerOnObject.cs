using System;

namespace Domain
{
    public class WorkerOnObject : BaseEntity
    {
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        public DateTime From { get; set; }
        public DateTime? Until { get; set; }
    }
}