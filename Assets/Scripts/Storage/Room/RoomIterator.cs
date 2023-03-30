using System.Collections.Generic;
using UnityEngine;

namespace Storage.Room
{
    public class RoomIterator : Iterator
    {
        private RoomRepository _repository;
        
        public List<List<char>> MiniatureRoom => _repository.MiniatureRoom;
        public Dictionary<string, List<Vector2Int>> ChunkCoords => _repository.ChunkCoords;

        private readonly List<IRoomObserver> _observers = new ();

        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<RoomRepository>();   
        }

        public override void Initialize()
        {
            RoomFacade.Initialize(this);
        }
        
        public void AddObserver(IRoomObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IRoomObserver observer)
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

        public void SetNewMiniature(object sender, List<List<char>> value)
        {
            _repository.MiniatureRoom = value;
            _repository.Save();
            NotifyListeners();
        }
        
        public void SetNewChunkCoords(object sender, Dictionary<string, List<Vector2Int>> value)
        {
            _repository.ChunkCoords = value;
            _repository.Save();
            NotifyListeners();
        }
    }
}