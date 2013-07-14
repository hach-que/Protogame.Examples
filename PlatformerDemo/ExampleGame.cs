using System;
using Protogame;
using Ninject;

namespace PlatformerDemo
{
    public class ExampleGame : CoreGame<ExampleWorld, DefaultWorldManager>
    {
        public ExampleGame(IKernel kernel) : base(kernel)
        {
            this.IsMouseVisible = true;
        }
    }
}

