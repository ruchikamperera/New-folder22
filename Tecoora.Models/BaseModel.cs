using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    public class BaseModel
    {
        public BaseModel() 
        { 
        this.CreatedDate = DateTime.Now;
        }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
