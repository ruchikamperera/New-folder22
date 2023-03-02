using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecoora.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? DOB { get; set; }
        public string? StudentType { get; set; }
        public string? State { get; set; }
        public int? noOfReviews { get; set; }
        public int? yearsOfExperience { get; set; }
        [NotMapped]
        public string sortBy { get; set; }
        [NotMapped]
        public string search { get; set; }
        public int? ConsultationFeeForOneHour { get; set; }
        public int? ConsultationFeeForHalfAndHour { get; set; }
        public Boolean? ChargingForExtraMin { get; set; }
        public int? ChargeForExtraMinutes { get; set; }
        [NotMapped]
        public List<string>? AccessArea { get; set; }
        public string? AccessAreas { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? ShortDescription { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ProfileImageUrl { get; set; }
        public double? Rating { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? OTP { get; set; }
        [NotMapped]
        public List<Review> Reviews { get; set; }
    }
}
