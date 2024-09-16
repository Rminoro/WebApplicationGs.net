namespace WebApplication1.Singleton
{
    public class SingletonUser
    {
        // Construtor público para o DI instanciad a classe
        public SingletonUser()
        {
            // Inicialização do Singleton
        }

        public string GetSetting(string key)
        {
            return "configValue";
        }
    }
}
