using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerSoft.Template.Dal.Entities
{
    [Table("PlayerPhones", Schema = "dbo")]
    public class PlayerPhone
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public bool CallToPhone { get; set; }
        public bool PrimaryPhone { get; set; }
        public bool SendTextMessage { get; set; }

        public virtual Player Player { get; set; }
    }
}
