using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.EFCore.Auditable
{
    /// <summary>
    /// Auditable Entity
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        DateTime UpdatedAt { get; set; }
    }
}
