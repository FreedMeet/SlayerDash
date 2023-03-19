using System;
using System.Collections.Generic;
using Assets;
using UnityEngine;

namespace Storage.Dash
{
    public class DashIterator : Iterator
    {
        private DashRepository _repository;

        public float DashDistance => _repository.DashDistance;
        public float DashCooldown => _repository.DashCooldown;
        public int MaxDashCount => _repository.MaxDashCount;
        public int CurrentDashCount => _repository.CurrentDashCount;
        public bool CanDash => _repository.CanDash;
        
        private readonly List<IDashObserver> _observers = new List<IDashObserver>();

        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<DashRepository>();
        }
        

        public override void Initialize()
        {
            DashFacade.Initialize(this);
        }
        
        public void AddObserver(IDashObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IDashObserver observer)
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

        public void IncreaseDashDistance(object sender, float value)
        {
            _repository.DashDistance += value;
            _repository.Save();
            NotifyListeners();
        }
        public void DashDistanceReduction(object sender, float value)
        {
            _repository.DashDistance -= value;
            _repository.Save();
            NotifyListeners();
        }
        public void IncreaseDashCooldown(object sender, float value)
        {
            _repository.DashCooldown += value;
            _repository.Save();
            NotifyListeners();
        }
        public void DashCooldownReduction(object sender, float value)
        {
            _repository.DashCooldown -= value;
            _repository.Save();
            NotifyListeners();
        }
        public void IncreaseMaxDashCount(object sender, int value)
        {
            _repository.MaxDashCount += value;
            _repository.Save();
            NotifyListeners();
        }
        public void MaxDashCountReduction(object sender, int value)
        {
            _repository.MaxDashCount -= value;
            _repository.Save();
            NotifyListeners();
        }
        public void SetCurrentDashCount(object sender, int value)
        {
            _repository.CurrentDashCount = value;
            NotifyListeners();
        }
        public void CurrentDashCountReduction(object sender, int value)
        {
            _repository.CurrentDashCount -= value;
            NotifyListeners();
        }
        public void IsCanDash(object sender, bool value)
        {
            _repository.CanDash = value;
            NotifyListeners();
        }
    }
}