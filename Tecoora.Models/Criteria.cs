using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    public class Criteria
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswersId { get; set; }
        public string? Comment { get; set; }
        public DateTime? Alert { get; set; }
        public StudentPointForm StudentForm { get; set; }
        public int StudentFormId { get; set; }
    }
}
