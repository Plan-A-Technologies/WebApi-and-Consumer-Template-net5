using System;

namespace PlayerSoft.Contracts.Contracts
{
    public interface IPlayerPhone
    {
        Guid Id { get; set; }
        string Type { get; set; }
        string Number { get; set; }
        string Extension { get; set; }
        bool CallToPhone { get; set; }
        bool PrimaryPhone { get; set; }
        bool SendTextMessage { get; set; }
    }
}
