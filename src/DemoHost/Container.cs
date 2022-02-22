namespace DemoHost
{
    public class Container
    {
        private readonly Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public Container Register<T>(T obj)
        {
            this.instances.Add(typeof(T), obj!);
            return this;
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            return (T)this.instances[type];
        }
    }
}
