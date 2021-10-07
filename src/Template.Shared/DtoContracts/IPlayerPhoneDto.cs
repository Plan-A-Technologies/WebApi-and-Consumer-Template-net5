using System;

namespace Template.Shared.DtoContracts
{
    /// <summary>
    /// Player phone contract.
    /// </summary>
    public interface IPlayerPhoneDto : IBaseDto<Guid>
    {
        /// <summary>
        /// Phone number type.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        string Number { get; set; }

        /// <summary>
        /// Phone extension number.
        /// </summary>
        string Extension { get; set; }

        /// <summary>
        /// Indicates whether phone calls should be placed to the phone number(player’s preference).
        /// </summary>
        bool CallToPhone { get; set; }

        /// <summary>
        /// Indicates whether the phone number is the primary phone number for the player.
        /// </summary>
        bool PrimaryPhone { get; set; }

        /// <summary>
        /// SendTextMessage.
        /// </summary>
        bool SendTextMessage { get; set; }
    }
}
