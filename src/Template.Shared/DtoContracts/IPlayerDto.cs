using System;
using System.Collections.Generic;
using Template.Shared.DtoContracts.Base;

namespace Template.Shared.DtoContracts
{
    /// <summary>
    /// The player contract.
    /// </summary>
    public interface IPlayerDto : IBaseDto<Guid>
    {
        /// <summary>
        /// Player’s title. For example, Mr, Mrs, etc.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Player’s first or given name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Player’s surname name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Player's middle name.
        /// </summary>
        string MiddleName { get; set; }

        /// <summary>
        /// Player's full name.
        /// </summary>
        string FullName { get; set; }

        /// <summary>
        /// Preferred name or nick name of player.
        /// </summary>
        string PreferredName { get; set; }

        /// <summary>
        /// Player's gender.
        /// </summary>
        bool Gender { get; set; }

        /// <summary>
        /// Player's date of birth.
        /// </summary>
        DateTime BirthDate { get; set; }

        /// <summary>
        /// Date player was registered.
        /// </summary>
        DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Player’s height in the associated unit of measure.
        /// </summary>
        int PlayerHeight { get; set; }

        /// <summary>
        /// Player’s weight in the associated unit of measure.
        /// </summary>
        int PlayerWeight { get; set; }

        /// <summary>
        /// Player’s hair color.
        /// </summary>
        string HairColor { get; set; }

        /// <summary>
        /// Player’s eye color.
        /// </summary>
        string EyeColor { get; set; }

        /// <summary>
        /// The player’s nationality.
        /// </summary>
        string PlayerNationality { get; set; }

        /// <summary>
        /// VIP indicator.
        /// </summary>
        bool PlayerVip { get; set; }

        /// <summary>
        /// Indicates whether the player is an active (valid) player.
        /// </summary>
        bool PlayerActive { get; set; }

        /// <summary>
        /// The collection of player's phones.
        /// </summary>
        IEnumerable<IPlayerPhoneDto> Phones { get; set; }
    }
}
