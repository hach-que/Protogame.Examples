using Ninject;
using Protogame;
using ProtogameAssetManager;

namespace PlatformerDemo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load<ProtogameIoCModule>();
            kernel.Load<ProtogameAssetIoCModule>();
            kernel.Load<ProtogamePlatformingIoCModule>();
            AssetManagerClient.AcceptArgumentsAndSetup<LocalAssetManagerProvider>(kernel, args);
        
            using (var game = new ExampleGame(kernel))
            {
                game.Run();
            }
        }
    }
}