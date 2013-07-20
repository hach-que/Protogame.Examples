using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Protogame;

namespace PlatformerDemo
{
    public class ExampleWorld : IWorld
    {
        private IRenderUtilities m_RenderUtilities;
        private IAssetManager m_AssetManager;

        public List<IEntity> Entities { get; private set; }
    
        public ExampleWorld(
            IRenderUtilities renderUtilities,
            IAssetManagerProvider assetManagerProvider)
        {
            this.m_RenderUtilities = renderUtilities;
            this.m_AssetManager = assetManagerProvider.GetAssetManager(false);
            this.Entities = new List<IEntity>();
        }

        public void RenderBelow(IGameContext gameContext, IRenderContext renderContext)
        {
            gameContext.ResizeWindow(800, 600);
            gameContext.Graphics.GraphicsDevice.Clear(Color.Black);
        }

        public void RenderAbove(IGameContext gameContext, IRenderContext renderContext)
        {
            this.m_RenderUtilities.RenderText(
                renderContext,
                new Vector2(10, 10),
                "Testing World " + gameContext.FPS + " " + gameContext.FrameCount,
                this.m_AssetManager.Get<FontAsset>("font.Arial"));
        }

        public void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
        }
    }
}
