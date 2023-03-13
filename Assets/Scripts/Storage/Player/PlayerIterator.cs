namespace Storage.Player
{
    public class PlayerIterator : Iterator
    {
        private PlayerRepository _repository;
        public float MoveSpeed => _repository.MoveSpeed;
        
        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<PlayerRepository>();
        }

        public override void Initialize()
        {
            Player.Initialize(this);
        }

        public void IncreaseInSpeed(object sender, int value)
        {
            _repository.MoveSpeed += value;
            _repository.Save();
        }
        
        public void SpeedReduction(object sender, int value)
        {
            _repository.MoveSpeed -= value;
            _repository.Save();
        }
    }
}