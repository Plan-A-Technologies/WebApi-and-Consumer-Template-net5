using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.EFCore.Auditable;

namespace Template.Shared.EFCore.Entities
{
    /// <summary>
    /// Base Entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="Template.Shared.EFCore.Auditable.IAuditableEntity" />
    public class BaseEntity<TKey> : IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public TKey Id { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc/>
        public int CreatedBy { get; set; }

        /// <inheritdoc/>
        public DateTime UpdatedAt { get; set; }

        /// <inheritdoc/>
        public int UpdatedBy { get; set; }
    }
}
