namespace Views
{
    public abstract class View
    {
        public virtual void OnCreate() { }
        public virtual void Initialize() { }
        public virtual void OnStart() { }
        public virtual void OnChange() { }
    }
}