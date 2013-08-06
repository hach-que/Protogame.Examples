using System;
using Protogame;
using Ninject;

namespace PlatformerDemo
{
    public class ExampleGame : CoreGame<ExampleWorld, Default2DWorldManager>
    {
        public ExampleGame(IKernel kernel) : base(kernel)
        {
            this.IsMouseVisible = true;
        }
    }
}

