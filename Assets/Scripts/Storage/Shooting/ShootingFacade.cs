using System;

namespace Storage.Shooting
{
    public class ShootingFacade
    {
        public static event Action OnShootingInitializedEvent;

        public static float FireRate
        {
            get
            {
                CheckClass();
                return _iterator.FireRate;
            }
        }
        public static int CountOfAmmo
        {
            get
            {
                CheckClass();
                return _iterator.CountOgAmmo;
            }
        }
        public static float ReloadTime
        {
            get
            {
                CheckClass();
                return _iterator.ReloadTime;
            }
        }
        public static int CurrentCountOfAmmo
        {
            get
            {
                CheckClass();
                return _iterator.CurrentCountOfAmmo;
            }
        }
        public static bool CanShoot
        {
            get
            {
                CheckClass();
                return _iterator.CanShoot;
            }
        }

        private static ShootingIterator _iterator;
        private static bool IsInitialized { get; set; }
        
        public static void Initialize(ShootingIterator iterator)
        {
            _iterator = iterator;
            IsInitialized = true;
            
            OnShootingInitializedEvent?.Invoke();
        }
        
        public static void AddObserver(IShootingObserver observer)
        {
            CheckClass();
            _iterator.AddObserver(observer);
            
        }
        public static void RemoveObserver(IShootingObserver observer)
        {
            CheckClass();
            _iterator.RemoveObserver(observer);
        }
        
        public static void IncreaseInFireRate(object sender, float value)
        {
            CheckClass();
            _iterator.IncreaseInFireRate(sender, value);
        }
        public static void FireRateReduction(object sender, float value)
        {
            CheckClass();
            _iterator.FireRateReduction(sender, value);
        }
        public static void IncreaseInCountOfAmmo(object sender, int value)
        {
            CheckClass();
            _iterator.IncreaseInCountOfAmmo(sender, value);
        }
        public static void CountOfAmmoReduction(object sender, int value)
        {
            CheckClass();
            _iterator.CountOfAmmoReduction(sender, value);
        }
        public static void IncreaseInReloadTime(object sender, float value)
        {
            CheckClass();
            _iterator.IncreaseInReloadTime(sender, value);
        }
        public static void ReloadTimeReduction(object sender, float value)
        {
            CheckClass();
            _iterator.ReloadTimeReduction(sender, value);
        }
        public static void IsCanShoot(object sender, bool value)
        {
            CheckClass();
            _iterator.IsCanShoot(sender, value);
        }
        public static void SetCurrentCountOfAmmo(object sender, int value)
        {
            CheckClass();
            _iterator.SetCurrentCountOfAmmo(sender, value);
        }
        public static void CurrentCountOfAmmoReduction(object sender, int value)
        {
            CheckClass();
            _iterator.CurrentCountOfAmmoReduction(sender, value);
        }

        private static void CheckClass()
        {
            if (!IsInitialized)
                throw new Exception("Shooting is not initialized yet");
        }
    }
}