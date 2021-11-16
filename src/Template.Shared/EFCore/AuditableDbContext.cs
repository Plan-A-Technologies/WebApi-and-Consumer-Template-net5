using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using Template.Shared.EFCore.Auditable;

namespace Template.Shared.EFCore
{
    public class AuditableDbContext : DbContext
    {
        /// <summary>
        /// The user authentication service.
        /// </summary>
        private readonly IEntityAuditProvider _entityAuditProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedDbContext"/> class.
        /// </summary>
        public AuditableDbContext() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditableDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="entityAuditProvider">The entity audit provider.</param>
        /// <exception cref="System.ArgumentNullException">entityAuditProvider</exception>
        public AuditableDbContext(DbContextOptions options, IEntityAuditProvider entityAuditProvider) : base(options)
        {
            _entityAuditProvider = entityAuditProvider ?? throw new ArgumentNullException(nameof(entityAuditProvider));
            ChangeTracker.Tracked += ChangeTrackerHandler;
            ChangeTracker.StateChanged += ChangeTrackerHandler;
        }

        /// <summary>
        /// Changes tracker handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The entity entry event arguments.</param>
        private void ChangeTrackerHandler(object sender, EntityEntryEventArgs e)
        {
            switch (e.Entry.State)
            {
                case EntityState.Added when e.Entry.Entity is IAuditableEntity auditable:
                    auditable.CreatedAt = _entityAuditProvider.GetAuditDate();
                    auditable.CreatedBy = _entityAuditProvider.GetAuditAuthorKey();
                    break;
                case EntityState.Modified when e.Entry.Entity is IAuditableEntity auditable:
                    auditable.UpdatedAt = _entityAuditProvider.GetAuditDate();
                    auditable.UpdatedBy = _entityAuditProvider.GetAuditAuthorKey();
                    break;
            }
        }
    }
}