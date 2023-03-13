namespace Storage
{
    public abstract class Iterator
    {
        public virtual void OnCreate() { }
        public virtual void Initialize() { }
        public virtual void OnStart() { }
    }
}