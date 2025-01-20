using System;
using System.Collections.Generic;
using System.Linq;

namespace TopDrawer.DomainEvents.Abstractions
{
    internal sealed class DomainEventServiceContainer
    {
        private readonly Dictionary<Type, HashSet<Type>> _handlerTypesByEventType =
            new Dictionary<Type, HashSet<Type>>();

        internal IEnumerable<Type> GetAllHandlerTypes()
        {
            return _handlerTypesByEventType.SelectMany(keyValuePair => keyValuePair.Value);
        }
        
        internal IEnumerable<Type> GetHandlerTypesForDomainEvent(IDomainEvent domainEvent)
        {
            _handlerTypesByEventType.TryGetValue(domainEvent.GetType(), out var handlerTypes);
            return handlerTypes ?? Enumerable.Empty<Type>();
        }
        
        internal void Add(Type eventType, Type handlerType)
        {
            if (!_handlerTypesByEventType.ContainsKey(eventType))
            {
                _handlerTypesByEventType.Add(eventType, new HashSet<Type>());
            }
            
            _handlerTypesByEventType[eventType].Add(handlerType);
        }
    }
}
