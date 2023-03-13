namespace Storage
{
    public abstract class Repository
    {
        public virtual void OnCreate() { }
        public virtual void Initialize() { }
        public virtual void OnStart() { }
        public abstract void Save();
    }
}