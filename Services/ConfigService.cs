namespace WebApplication1.Services
{
    public class ConfigService
    {
        private static ConfigService _instance;
        private readonly IConfiguration _config;

        private ConfigService(IConfiguration config)
        {
            _config = config;
        }

        public static ConfigService GetInstance(IConfiguration config)
        {
            if (_instance == null)
                _instance = new ConfigService(config);

            return _instance;
        }

        public string GetConfigValue(string key)
        {
            return _config[key];
        }
    }
}
