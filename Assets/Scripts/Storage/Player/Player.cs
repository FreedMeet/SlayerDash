using System;
using UnityEngine;

namespace Storage.Player
{
    public static class Player
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
        public static bool isInitialized { get; private set; }
        
        public static void Initialize(PlayerIterator iterator)
        {
            _iterator = iterator;
            isInitialized = true;
            
            OnPlayerInitializedEvent?.Invoke();
        }
        
        
        public static void IncreaseInSpeed(object sender, int value)
        {
            CheckClass();
            _iterator.IncreaseInSpeed(sender, value);
        }
        
        public static void SpeedReduction(object sender, int value)
        {
            CheckClass();
            _iterator.SpeedReduction(sender, value);
        }

        private static void CheckClass()
        {
            if (!isInitialized)
                throw new Exception("Player is not initialized yet");
        }
    }
}
