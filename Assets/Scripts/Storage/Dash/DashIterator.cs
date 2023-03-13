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

        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<DashRepository>();
        }

        public override void Initialize()
        {
            DashFacade.Initialize(this);
        }

        public void IncreaseDashDistance(object sender, float value)
        {
            _repository.DashDistance += value;
            _repository.Save();
        }

        public void DashDistanceReduction(object sender, float value)
        {
            _repository.DashDistance -= value;
            _repository.Save();
        }

        public void IncreaseDashCooldown(object sender, float value)
        {
            _repository.DashCooldown += value;
            _repository.Save();
        }

        public void DashCooldownReduction(object sender, float value)
        {
            _repository.DashCooldown -= value;
            _repository.Save();
        }

        public void IncreaseMaxDashCount(object sender, int value)
        {
            _repository.MaxDashCount += value;
            _repository.Save();
        }

        public void MaxDashCountReduction(object sender, int value)
        {
            _repository.MaxDashCount -= value;
            _repository.Save();
        }

        public void SetCurrentDashCount(object sender, int value)
        {
            _repository.CurrentDashCount = value;
            _repository.Save();
        }

        public void CurrentDashCountReduction(object sender, int value)
        {
            _repository.CurrentDashCount -= value;
            _repository.Save();
        }
        
        public void IsCanDash(object sender, bool value)
        {
            _repository.CanDash = value;
            _repository.Save();
        }

    }
}