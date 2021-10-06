using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Dal.Entities
{
    /// <summary>
    /// The player phone entity.
    /// </summary>
    [Table("PlayerPhones", Schema = "dbo")]
    public class PlayerPhone
    {
        /// <summary>
        /// Player phone number identifier; unique to the player only; identifies a specific phone record for the player.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Phone number type.
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Phone number type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Phone extension number.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Indicates whether phone calls should be placed to the phone number(player’s preference).
        /// </summary>
        public bool CallToPhone { get; set; }

        /// <summary>
        /// Indicates whether the phone number is the primary phone number for the player.
        /// </summary>
        public bool PrimaryPhone { get; set; }

        /// <summary>
        /// SendTextMessage.
        /// </summary>
        public bool SendTextMessage { get; set; }

        /// <summary>
        /// The player property.
        /// </summary>
        public virtual Player Player { get; set; }
    }
}
