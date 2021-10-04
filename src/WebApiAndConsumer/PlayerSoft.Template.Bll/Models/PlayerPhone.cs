using System;
using PlayerSoft.Contracts.Contracts;

namespace PlayerSoft.Template.Bll.Models
{
    public class PlayerPhone : IPlayerPhone
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
