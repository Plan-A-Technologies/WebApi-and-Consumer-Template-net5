using System;
using System.Collections.Generic;

namespace Template.Dal.Entities
{
    /// <summary>
    /// The player model.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The user identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Player’s title. For example, Mr, Mrs, etc.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Player’s first or given name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Player’s surname name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Player's middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Player's full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Preferred name or nick name of player.
        /// </summary>
        public string PreferredName { get; set; }

        /// <summary>
        /// Player's gender.
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// Player's date of birth.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Date player was registered.
        /// </summary>
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Player’s height in the associated unit of measure.
        /// </summary>
        public int PlayerHeight { get; set; }

        /// <summary>
        /// Player’s weight in the associated unit of measure.
        /// </summary>
        public int PlayerWeight { get; set; }

        /// <summary>
        /// Player’s hair color.
        /// </summary>
        public string HairColor { get; set; }

        /// <summary>
        /// Player’s eye color.
        /// </summary>
        public string EyeColor { get; set; }

        /// <summary>
        /// The player’s nationality.
        /// </summary>
        public string PlayerNationality { get; set; }

        /// <summary>
        /// VIP indicator.
        /// </summary>
        public bool PlayerVip { get; set; }

        /// <summary>
        /// Indicates whether the player is an active (valid) player.
        /// </summary>
        public bool PlayerActive { get; set; }

        /// <summary>
        /// The collection of player's phones.
        /// </summary>
        public virtual ICollection<PlayerPhone> Phones { get; set; }
    }
}
