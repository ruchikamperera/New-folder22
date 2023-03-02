using System;
using System.Collections.Generic;

namespace Tecoora.API.Models
{
    public class CriteriaDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswersId { get; set; }
        public string? Comment { get; set; }
        public DateTime? Alert { get; set; }

    }
}
