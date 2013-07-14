using Ninject;
using Protogame;

namespace PlatformerDemo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load<AssetIoCModule>();
            kernel.Load<IoCModule>();
            kernel.Load<Protogame.Platforming.IoCModule>();
            kernel.Bind<IAssetManagerProvider>().To<LocalAssetManagerProvider>();
        
            using (var game = new ExampleGame(kernel))
            {
                game.Run();
            }
        }
    }
}