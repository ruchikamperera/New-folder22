using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    public class StudentPointForm
    {
        public int Id { get; set; }
        public int Attempt { get; set; }    
        public int StudentUserId { get; set; }
        public int? CreateLawyerId { get; set; }
        public List<Criteria> Criterias { get; set; }
        public int FormTypeId { get; set; }   
        public string? SummaryPlan { get; set; }

    }
}
