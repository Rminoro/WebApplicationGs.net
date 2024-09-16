namespace WebApplication1.Singleton
{
    public class Singleton
    {
        private static readonly Lazy<Singleton> _instance =
       new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance => _instance.Value;

        private Singleton()
        {
         
        }

        public string GetSetting(string key)
        {
            return "configValue";
        }
    }
}