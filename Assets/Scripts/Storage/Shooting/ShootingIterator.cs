using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Storage.Shooting
{
    public class ShootingIterator : Iterator
    {
        private ShootingRepository _repository;
        public float FireRate => _repository.FireRate;
        public int CountOgAmmo => _repository.CountOfAmmo;
        public float ReloadTime => _repository.ReloadTime;
        public int CurrentCountOfAmmo => _repository.CurrentCountOfAmmo;
        public bool CanShoot => _repository.CanShoot;
        
        private readonly List<IShootingObserver> _observers = new List<IShootingObserver>();

        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<ShootingRepository>();   
        }

        public override void Initialize()
        {
            ShootingFacade.Initialize(this);
        }
        
        public void AddObserver(IShootingObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IShootingObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }
        
        private void NotifyListeners()
        {
            foreach (var observer in _observers)
            {
                observer.OnChange();
            }
        }

        public void IncreaseInFireRate(object sender, float value)
        {
            _repository.FireRate += value;
            _repository.Save();
            NotifyListeners();
        }
        public void FireRateReduction(object sender, float value)
        {
            _repository.FireRate -= value;
            _repository.Save();
            NotifyListeners();
        }
        public void IncreaseInCountOfAmmo(object sender, int value)
        {
            _repository.CountOfAmmo += value;
            _repository.Save();
            NotifyListeners();
        }
        public void CountOfAmmoReduction(object sender, int value)
        {
            _repository.CountOfAmmo -= value;
            _repository.Save();
            NotifyListeners();
        }
        public void IncreaseInReloadTime(object sender, float value)
        {
            _repository.ReloadTime += value;
            _repository.Save();
            NotifyListeners();
        }
        public void ReloadTimeReduction(object sender, float value)
        {
            _repository.ReloadTime -= value;
            _repository.Save();
            NotifyListeners();
        }
        public void IsCanShoot(object sender, bool value)
        {
            _repository.CanShoot = value;
            NotifyListeners();
        }
        public void SetCurrentCountOfAmmo(object sender, int value)
        {
            _repository.CurrentCountOfAmmo = value;
            NotifyListeners();
        }
        public void CurrentCountOfAmmoReduction(object sender, int value)
        {
            _repository.CurrentCountOfAmmo -= value;
            NotifyListeners();
        }
    }
}