using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.EFCore.Auditable
{
    /// <summary>
    /// Entity Audit Provider.
    /// </summary>
    public interface IEntityAuditProvider
    {
        /// <summary>
        /// Gets the audit author key.
        /// </summary>
        int GetAuditAuthorKey();

        /// <summary>
        /// Gets the audit date.
        /// </summary>
        DateTime GetAuditDate();
    }
}
