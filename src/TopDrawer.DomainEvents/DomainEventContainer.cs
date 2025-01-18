using System;
using System.Collections.Generic;
using System.Linq;

namespace TopDrawer.DomainEvents
{
    public sealed class DomainEventContainer
    {
        private readonly Dictionary<Type, HashSet<Type>> _handlerTypesByEventType =
            new Dictionary<Type, HashSet<Type>>();

        public IEnumerable<Type> GetAllHandlerTypes()
        {
            return _handlerTypesByEventType.SelectMany(keyValuePair => keyValuePair.Value);
        }
        
        public IEnumerable<Type> GetHandlerTypesForDomainEvent(IDomainEvent domainEvent)
        {
            _handlerTypesByEventType.TryGetValue(domainEvent.GetType(), out var handlerTypes);
            return handlerTypes ?? Enumerable.Empty<Type>();
        }
        
        public void Add<TDomainEvent, TDomainEventHandler>()
            where TDomainEvent : IDomainEvent
            where TDomainEventHandler : IDomainEventHandler<TDomainEvent>
        {
            if (!_handlerTypesByEventType.ContainsKey(typeof(TDomainEvent)))
            {
                _handlerTypesByEventType.Add(typeof(TDomainEvent), new HashSet<Type>());
            }
            
            _handlerTypesByEventType[typeof(TDomainEvent)].Add(typeof(TDomainEventHandler));
        }
    }
}
