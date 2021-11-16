using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.EFCore.Auditable
{
    public interface IEntityAuditProvider
    {
        int GetAuditAuthorKey();
        DateTime GetAuditDate();
    }
}
