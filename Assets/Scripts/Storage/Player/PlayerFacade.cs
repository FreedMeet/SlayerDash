using System;

namespace Storage.Player
{
    public static class PlayerFacade
    {
        public static event Action OnPlayerInitializedEvent;

        public static float MoveSpeed
        {
            get
            {
                CheckClass();
                return _iterator.MoveSpeed;
            }
        }

        private static PlayerIterator _iterator;
        private static bool IsInitialized { get; set; }
        
        public static void Initialize(PlayerIterator iterator)
        {
            _iterator = iterator;
            IsInitialized = true;
            
            OnPlayerInitializedEvent?.Invoke();
        }
        
        public static void AddObserver(IPlayerObserver observer)
        {
            CheckClass();
            _iterator.AddObserver(observer);
            
        }
        
        public static void RemoveObserver(IPlayerObserver observer)
        {
            CheckClass();
            _iterator.RemoveObserver(observer);
        }

        public static void IncreaseInSpeed(object sender, float value)
        {
            CheckClass();
            _iterator.IncreaseInSpeed(sender, value);
        }
        
        public static void SpeedReduction(object sender, float value)
        {
            CheckClass();
            _iterator.SpeedReduction(sender, value);
        }

        private static void CheckClass()
        {
            if (!IsInitialized)
                throw new Exception("Player is not initialized yet");
        }
    }
}
