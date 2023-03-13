using Unity.VisualScripting;
using UnityEngine;

namespace Storage.Player
{
    public class PlayerIterator : Iterator
    {
        private PlayerRepository _repository;
        public float MoveSpeed => _repository.MoveSpeed;
        public GameObject player;

        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<PlayerRepository>();   
        }

        public override void Initialize()
        {
            base.Initialize();
            var playerPrefab = Resources.Load<GameObject>("PlayerPrefab");
            player = GameObject.Instantiate(playerPrefab);
            PlayerFacade.Initialize(this);
        }

        public void IncreaseInSpeed(object sender, float value)
        {
            _repository.MoveSpeed += value;
            _repository.Save();
        }
        
        public void SpeedReduction(object sender, float value)
        {
            _repository.MoveSpeed -= value;
            _repository.Save();
        }
    }
}