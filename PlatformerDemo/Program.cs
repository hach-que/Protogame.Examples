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
            kernel.Load<IoCModule>();
            kernel.Load<AssetIoCModule>();
            kernel.Load<PlatformingIoCModule>();
            AssetManagerClient.AcceptArgumentsAndSetup<LocalAssetManagerProvider>(kernel, args);
        
            using (var game = new ExampleGame(kernel))
            {
                game.Run();
            }
        }
    }
}