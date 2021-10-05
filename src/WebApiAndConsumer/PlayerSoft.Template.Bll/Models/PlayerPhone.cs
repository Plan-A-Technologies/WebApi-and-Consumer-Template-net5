using System;
using PlayerSoft.Contracts.Contracts;

namespace PlayerSoft.Template.Bll.Models
{
    /// <inheritdoc/>
    public class PlayerPhone : IPlayerPhone
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
        /// <inheritdoc/>
        public string Type { get; set; }
        /// <inheritdoc/>
        public string Number { get; set; }
        /// <inheritdoc/>
        public string Extension { get; set; }
        /// <inheritdoc/>
        public bool CallToPhone { get; set; }
        /// <inheritdoc/>
        public bool PrimaryPhone { get; set; }
        /// <inheritdoc/>
        public bool SendTextMessage { get; set; }
    }
}
