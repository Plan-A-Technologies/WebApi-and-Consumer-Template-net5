using System;
using Template.Shared.DtoContracts;
using Template.Shared.DtoContracts.Base;

namespace Template.Bll.Dto
{
    /// <inheritdoc/>
    public class PlayerPhoneDto : IPlayerPhoneDto
    {
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
        /// <inheritdoc/>
        public Guid Id { get; set; }
        /// <inheritdoc/>
        public int CreatedBy { get; set; }
        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }
        /// <inheritdoc/>
        public int? UpdatedBy { get; set; }
        /// <inheritdoc/>
        public DateTime? UpdatedAt { get; set; }
    }
}
