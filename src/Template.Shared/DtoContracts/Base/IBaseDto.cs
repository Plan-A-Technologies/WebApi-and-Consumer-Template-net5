using System;

namespace Template.Shared.DtoContracts.Base
{
    /// <summary>
    /// Base dto.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDto<T> : IAuditableDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public T Id { get; set; }
    }
}