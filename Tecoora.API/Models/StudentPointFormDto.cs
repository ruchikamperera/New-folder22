using System.Collections.Generic;

namespace Tecoora.API.Models
{
    public class StudentPointFormDto
    {
        public int Id { get; set; }
        public int? Attempt { get; set; }
        public int StudentUserId { get; set; }
        public int? CreateLawyerId { get; set; }
        public List<CriteriaDto> criterias { get; set; }
        public int formTypeId { get; set; }
        public string? SummaryPlan { get; set; }
    }
}
