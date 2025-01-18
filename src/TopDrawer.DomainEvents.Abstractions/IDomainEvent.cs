using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TopDrawer.DomainEvents.AspNetCore")]
[assembly: InternalsVisibleTo("TopDrawer.DomainEvents.EntityFrameworkCore")]

namespace TopDrawer.DomainEvents.Abstractions
{
    public interface IDomainEvent { }
}
