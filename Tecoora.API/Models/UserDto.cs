using System;
using System.Collections.Generic;

namespace Tecoora.API.Models
{
    public class UserDto
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
        public string sortBy { get; set; }
        public string search { get; set; }
        public int? ConsultationFeeForOneHour { get; set; }
        public int? ConsultationFeeForHalfAndHour { get; set; }
        public Boolean? ChargingForExtraMin { get; set; }
        public int? ChargeForExtraMinutes { get; set; }
        public List<string>? accessArea { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? ShortDescription { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ProfileImageUrl { get; set; }
        public double? Rating { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<ReviewDto> Reviews { get; set; }
    }
}
