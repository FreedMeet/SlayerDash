using System;
using Assets;
using Views.PlayerView.DashUI;

namespace Storage.Dash
{
    public static class DashFacade
    {
        public static event Action OnDashInitializedEvent;

        public static float DashDistance
        {
            get
            {
                CheckClass();
                return _iterator.DashDistance;
            }
        }

        public static float DashCooldown
        {
            get
            {
                CheckClass();
                return _iterator.DashCooldown;
            }
        }

        public static int MaxDashCount
        {
            get
            {
                CheckClass();
                return _iterator.MaxDashCount;
            }
        }

        public static int CurrentDashCount
        {
            get
            {
                CheckClass();
                return _iterator.CurrentDashCount;
            }
        }

        public static bool CanDash
        {
            get
            {
                CheckClass();
                return _iterator.CanDash;
            }
        }

        private static DashIterator _iterator;

        private static bool IsInitialized { get; set; }

        public static void Initialize(DashIterator iterator)
        {
            _iterator = iterator;
            IsInitialized = true;

            OnDashInitializedEvent?.Invoke();
        }

        public static void AddObserver(IDashObserver observer)
        {
            CheckClass();
            _iterator.AddObserver(observer);
            
        }
        
        public static void RemoveObserver(IDashObserver observer)
        {
            CheckClass();
            _iterator.RemoveObserver(observer);
        }

        public static void IncreaseDashDistance(object sender, float value)
        {
            CheckClass();
            _iterator.IncreaseDashDistance(sender, value);
        }

        public static void DashDistanceReduction(object sender, float value)
        {
            CheckClass();
            _iterator.DashDistanceReduction(sender, value);
        }

        public static void IncreaseDashCooldown(object sender, float value)
        {
            CheckClass();
            _iterator.IncreaseDashCooldown(sender, value);
        }

        public static void DashCooldownReduction(object sender, float value)
        {
            CheckClass();
            _iterator.DashCooldownReduction(sender, value);
        }

        public static void IncreaseMaxDashCount(object sender, int value)
        {
            CheckClass();
            _iterator.IncreaseMaxDashCount(sender, value);
        }

        public static void MaxDashCountReduction(object sender, int value)
        {
            CheckClass();
            _iterator.MaxDashCountReduction(sender, value);
        }

        public static void SetCurrentDashCount(object sender, int value)
        {
            CheckClass();
            _iterator.SetCurrentDashCount(sender, value);
        }

        public static void CurrentDashCountReduction(object sender, int value)
        {
            CheckClass();
            _iterator.CurrentDashCountReduction(sender, value);
        }

        public static void IsCanDash(object sender, bool value)
        {
            CheckClass();
            _iterator.IsCanDash(sender, value);
        }

        private static void CheckClass()
        {
            if (!IsInitialized)
                throw new Exception("Dash is not initialized yet");
        }
    }
}