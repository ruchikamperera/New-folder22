using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int LawyerId { get; set; }
    }
}
