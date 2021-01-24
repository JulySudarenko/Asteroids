using System.Collections.Generic;

namespace Asteroids
{
    public sealed class Controllers : IIinitialize, IFixedExecute, IExecute, ICleanup
    {
        private readonly List<IIinitialize> _initializeControllers;
        private readonly List<IFixedExecute> _fixedControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal Controllers()
        {
            _initializeControllers = new List<IIinitialize>();
            _fixedControllers = new List<IFixedExecute>();
            _executeControllers = new List<IExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IIinitialize initializeController)
            {
                _initializeControllers.Add(initializeController);
            }
            
            if (controller is IFixedExecute fixedController)
            {
                _fixedControllers.Add(fixedController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }

        public void Initialize()
        {
            for (var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Initialize();
            }
        }

        public void FixedExecute(float deltaTime)
        {
            for (var index = 0; index < _fixedControllers.Count; ++index)
            {
                _fixedControllers[index].FixedExecute(deltaTime);
            }
        }

        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }

        public void Cleanup()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }
    }
}
