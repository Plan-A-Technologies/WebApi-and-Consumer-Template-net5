using System;
using System.Collections.Generic;

namespace PlayerSoft.Contracts.Contracts
{
    public interface IPlayer
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string FullName { get; set; }
        string PreferredName { get; set; }
        bool Gender { get; set; }
        DateTime BirthDate { get; set; }
        DateTime RegisteredDate { get; set; }
        int PlayerHeight { get; set; }
        int PlayerWeight { get; set; }
        string HairColor { get; set; }
        string EyeColor { get; set; }
        string PlayerNationality { get; set; }
        bool PlayerVip { get; set; }
        bool PlayerActive { get; set; }

        IEnumerable<IPlayerPhone> Phones { get; set; }
    }
}
