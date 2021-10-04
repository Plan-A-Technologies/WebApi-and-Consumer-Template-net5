using System;

namespace PlayerSoft.Template.Bll.Models
{
    public class PlayerPhone
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public bool CallToPhone { get; set; }
        public bool PrimaryPhone { get; set; }
        public bool SendTextMessage { get; set; }
    }
}
