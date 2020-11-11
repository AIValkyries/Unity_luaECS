using System;
using System.Collections.Generic;

namespace Entitas {

    /// Systems provide a convenient way to group systems.
    /// You can add IInitializeSystem, IExecuteSystem, ICleanupSystem,
    /// ITearDownSystem, ReactiveS
    /// ystem and other nested Systems instances.
    /// All systems will be initialized and executed based on the order
    /// you added them.
    public class Systems : 
        IInitializeSystem, 
        IExecuteSystem, 
        ICleanupSystem,
        ITearDownSystem
    {
        protected readonly Dictionary<Type, IInitializeSystem> _initializeSystems;
        protected readonly Dictionary<Type, IExecuteSystem> _executeSystems;
        protected readonly Dictionary<Type, ICleanupSystem> _cleanupSystems;
        protected readonly Dictionary<Type, ITearDownSystem> _tearDownSystems;

        /// Creates a new Systems instance.
        public Systems() 
        {
            _initializeSystems = new Dictionary<Type, IInitializeSystem>();
            _executeSystems = new Dictionary<Type, IExecuteSystem>();
            _cleanupSystems = new Dictionary<Type, ICleanupSystem>();
            _tearDownSystems = new Dictionary<Type, ITearDownSystem>();
        }

        /// Adds the system instance to the systems list.
        public virtual Systems Add(ISystem system)
        {
            var initializeSystem = system as IInitializeSystem;
            if (initializeSystem != null)
            {
                if (!_initializeSystems.ContainsKey(system.GetType()))
                    _initializeSystems.Add(system.GetType(), initializeSystem);
            }

            var executeSystem = system as IExecuteSystem;
            if(executeSystem != null) 
            {
                if (!_executeSystems.ContainsKey(system.GetType()))
                    _executeSystems.Add(system.GetType(), executeSystem);
            }

            var cleanupSystem = system as ICleanupSystem;
            if(cleanupSystem != null) 
            {
                if (!_cleanupSystems.ContainsKey(system.GetType()))
                    _cleanupSystems.Add(system.GetType(), cleanupSystem);
            }

            var tearDownSystem = system as ITearDownSystem;
            if(tearDownSystem != null)
            {
                if (!_tearDownSystems.ContainsKey(system.GetType()))
                    _tearDownSystems.Add(system.GetType(), tearDownSystem);
            }

            return this;
        }

        public virtual void Remove(ISystem system)
        {
            var initializeSystem = system as IInitializeSystem;
            if (initializeSystem != null)
            {
                if (_initializeSystems.ContainsKey(system.GetType()))
                    _initializeSystems.Remove(system.GetType());
            }

            var executeSystem = system as IExecuteSystem;
            if (executeSystem != null)
            {
                if (_executeSystems.ContainsKey(system.GetType()))
                    _executeSystems.Remove(system.GetType());
            }

            var cleanupSystem = system as ICleanupSystem;
            if (cleanupSystem != null)
            {
                if (_cleanupSystems.ContainsKey(system.GetType()))
                    _cleanupSystems.Remove(system.GetType());
            }

            var tearDownSystem = system as ITearDownSystem;
            if (tearDownSystem != null)
            {
                if (_tearDownSystems.ContainsKey(system.GetType()))
                    _tearDownSystems.Remove(system.GetType());
            }
        }

        public virtual ISystem Get<T>() where T : ISystem
        {
            Type type = typeof(T);

            if (_initializeSystems.ContainsKey(type))
            {
                return _initializeSystems[type];
            }
            if (_executeSystems.ContainsKey(type))
            {
                return _executeSystems[type];
            }
            if (_cleanupSystems.ContainsKey(type))
            {
                return _cleanupSystems[type];
            }
            if (_tearDownSystems.ContainsKey(type))
            {
                return _tearDownSystems[type];
            }

            return default(T);
        }

        /// Calls Initialize() on all IInitializeSystem and other
        /// nested Systems instances in the order you added them.
        public virtual void Initialize(System.Object param = null)
        {
            var itr = _initializeSystems.Values.GetEnumerator();
            while(itr.MoveNext())
            {
                itr.Current.Initialize(param);
            }
            itr.Dispose();
        }

        /// Calls Execute() on all IExecuteSystem and other
        /// nested Systems instances in the order you added them.
        public virtual void Execute() 
        {
            var itr = _executeSystems.Values.GetEnumerator();
            while (itr.MoveNext())
            {
                itr.Current.Execute();
            }
            itr.Dispose();
        }

        /// Calls Cleanup() on all ICleanupSystem and other
        /// nested Systems instances in the order you added them.
        public virtual void Cleanup() 
        {
            var itr = _cleanupSystems.Values.GetEnumerator();
            while (itr.MoveNext())
            {
                itr.Current.Cleanup();
            }
            itr.Dispose();
        }

        /// Calls TearDown() on all ITearDownSystem  and other
        /// nested Systems instances in the order you added them.
        public virtual void TearDown()
        {
            var itr = _tearDownSystems.Values.GetEnumerator();
            while (itr.MoveNext())
            {
                itr.Current.TearDown();
            }
            itr.Dispose();
        }

        /// Activates all ReactiveSystems in the systems list.
        public void ActivateReactiveSystems() 
        {
            var itr = _executeSystems.Values.GetEnumerator();
            while (itr.MoveNext())
            {
                var system = itr.Current;
                var reactiveSystem = system as IReactiveSystem;
                if (reactiveSystem != null)
                {
                    reactiveSystem.Activate();
                }

                var nestedSystems = system as Systems;
                if (nestedSystems != null)
                {
                    nestedSystems.ActivateReactiveSystems();
                }
            }
            itr.Dispose();
        }

        /// Deactivates all ReactiveSystems in the systems list.
        /// This will also clear all ReactiveSystems.
        /// This is useful when you want to soft-restart your application and
        /// want to reuse your existing system instances.
        public void DeactivateReactiveSystems()
        {
            var itr = _executeSystems.Values.GetEnumerator();
            while (itr.MoveNext())
            {
                var system = itr.Current;
                var reactiveSystem = system as IReactiveSystem;
                if (reactiveSystem != null)
                {
                    reactiveSystem.Deactivate();
                }

                var nestedSystems = system as Systems;
                if (nestedSystems != null)
                {
                    nestedSystems.DeactivateReactiveSystems();
                }
            }
            itr.Dispose();
        }

        /// Clears all ReactiveSystems in the systems list.
        public void ClearReactiveSystems()
        {
            var itr = _executeSystems.Values.GetEnumerator();
            while (itr.MoveNext())
            {
                var system = itr.Current;
                var reactiveSystem = system as IReactiveSystem;
                if (reactiveSystem != null)
                {
                    reactiveSystem.Clear();
                }

                var nestedSystems = system as Systems;
                if (nestedSystems != null)
                {
                    nestedSystems.ClearReactiveSystems();
                }
            }
            itr.Dispose();
        }

 
    }
}
