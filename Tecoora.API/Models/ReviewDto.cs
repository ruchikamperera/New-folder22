using System;

namespace Tecoora.API.Models
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int LawyerId { get; set; }
    }
}
