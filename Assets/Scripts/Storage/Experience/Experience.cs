using System;
using UnityEngine;

namespace Storage.Experience
{
    public static class Experience
    {
        public static event Action OnExperienceInitializedEvent;
        public static int Exp
        {
            get
            {
                CheckClass();
                return _iterator.Exp;
            }
        }

        private static ExperienceIterator _iterator;
        
        public static bool isInitialized { get; private set; }
        
        public static void Initialize(ExperienceIterator iterator)
        {
            _iterator = iterator;
            isInitialized = true;
            
            OnExperienceInitializedEvent?.Invoke();
        }
        
        public static bool IsEnoughExp(int value)
        {
            CheckClass();
            return _iterator.IsEnoughExp(value);
        }

        public static void AddExp(object sender, int value)
        {
            CheckClass();
            _iterator.AddExp(sender, value);
        }
        
        public static void SpendExp(object sender, int value)
        {
            CheckClass();
            _iterator.SpendExp(sender, value);
        }

        private static void CheckClass()
        {
            if (!isInitialized)
                throw new Exception("Experience is not initialized yet");
        }
    }
}