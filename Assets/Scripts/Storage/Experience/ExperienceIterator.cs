namespace Storage.Experience
{
    public class ExperienceIterator : Iterator
    {
        private ExperienceRepository _repository;

        public int Exp => _repository.Exp;

        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<ExperienceRepository>();
        }

        public override void Initialize()
        {
            Experience.Initialize(this);
        }

        public bool IsEnoughExp(int value)
        {
            return Exp >= value;
        }

        public void AddExp(object sender, int value)
        {
            _repository.Exp += value;
            _repository.Save();
        }
        
        public void SpendExp(object sender, int value)
        {
            _repository.Exp -= value;
            _repository.Save();
        }
    }
}