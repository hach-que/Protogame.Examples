using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Protogame;

namespace PlatformerDemo
{
    public class ExampleWorld : IWorld
    {
        private IRenderUtilities m_RenderUtilities;
        private IAssetManager m_AssetManager;
        private IProfiler m_Profiler;

        public List<IEntity> Entities { get; private set; }
    
        public ExampleWorld(
            IPlatforming platforming,
            IRenderUtilities renderUtilities,
            IAssetManagerProvider assetManagerProvider,
            IAudioUtilities audioUtilities,
            IProfiler profiler)
        {
            this.m_RenderUtilities = renderUtilities;
            this.m_Profiler = profiler;
            this.m_AssetManager = assetManagerProvider.GetAssetManager(false);
            this.Entities = new List<IEntity>();
            
            this.Entities.Add(new Player(
                platforming,
                this.m_AssetManager,
                this.m_RenderUtilities,
                audioUtilities));
        }

        public void RenderBelow(IGameContext gameContext, IRenderContext renderContext)
        {
            using (this.m_Profiler.Measure("resize_window"))
            {
                gameContext.ResizeWindow(800, 600);
            }
            using (this.m_Profiler.Measure("clear"))
            {
                gameContext.Graphics.GraphicsDevice.Clear(Color.Black);
            }
        }

        public void RenderAbove(IGameContext gameContext, IRenderContext renderContext)
        {
            this.m_RenderUtilities.RenderText(
                renderContext,
                new Vector2(10, 10),
                "Testing World " + gameContext.FPS + " " + gameContext.FrameCount,
                this.m_AssetManager.Get<FontAsset>("font.Main"));
        }

        public void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
        }
    }
}

