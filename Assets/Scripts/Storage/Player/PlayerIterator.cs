using System.Collections.Generic;
using UnityEngine;

namespace Storage.Player
{
    public class PlayerIterator : Iterator
    {
        private PlayerRepository _repository;
        public float MoveSpeed => _repository.MoveSpeed;
        
        private readonly List<IPlayerObserver> _observers = new List<IPlayerObserver>();

        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<PlayerRepository>();   
        }

        public override void Initialize()
        {
            PlayerFacade.Initialize(this);
        }
        
        public void AddObserver(IPlayerObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IPlayerObserver observer)
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

        public void IncreaseInSpeed(object sender, float value)
        {
            _repository.MoveSpeed += value;
            _repository.Save();
            NotifyListeners();
        }
        
        public void SpeedReduction(object sender, float value)
        {
            _repository.MoveSpeed -= value;
            _repository.Save();
            NotifyListeners();
        }
    }
}