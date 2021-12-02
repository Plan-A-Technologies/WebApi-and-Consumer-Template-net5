using System;
using System.Collections.Generic;
using Template.Shared.DtoContracts;

namespace Template.Bll.Dto
{
    /// <inheritdoc/>
    public class PlayerDto : IPlayerDto
    {
        /// <inheritdoc/>
        public string Title { get; set; }
        /// <inheritdoc/>
        public string FirstName { get; set; }
        /// <inheritdoc/>
        public string LastName { get; set; }
        /// <inheritdoc/>
        public string MiddleName { get; set; }
        /// <inheritdoc/>
        public string FullName { get; set; }
        /// <inheritdoc/>
        public string PreferredName { get; set; }
        /// <inheritdoc/>
        public bool Gender { get; set; }
        /// <inheritdoc/>
        public DateTime BirthDate { get; set; }
        /// <inheritdoc/>
        public DateTime RegisteredDate { get; set; }
        /// <inheritdoc/>
        public int PlayerHeight { get; set; }
        /// <inheritdoc/>
        public int PlayerWeight { get; set; }
        /// <inheritdoc/>
        public string HairColor { get; set; }
        /// <inheritdoc/>
        public string EyeColor { get; set; }
        /// <inheritdoc/>
        public string PlayerNationality { get; set; }
        /// <inheritdoc/>
        public bool PlayerVip { get; set; }
        /// <inheritdoc/>
        public bool PlayerActive { get; set; }
        /// <inheritdoc/>
        public IEnumerable<IPlayerPhoneDto> Phones { get; set; }
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
