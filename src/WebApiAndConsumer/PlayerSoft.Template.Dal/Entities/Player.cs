using System;
using System.Collections.Generic;

namespace PlayerSoft.Template.Dal.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int PlayerHeight { get; set; }
        public int PlayerWeight { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PlayerNationality { get; set; }
        public bool PlayerVip { get; set; }
        public bool PlayerActive { get; set; }

        public virtual ICollection<PlayerPhone> Phones { get; set; }
    }
}
