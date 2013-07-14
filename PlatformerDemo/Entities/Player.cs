using Protogame;
using Protogame.Platforming;
using Microsoft.Xna.Framework;

namespace PlatformerDemo
{
    public class Player : Entity
    {
        private IPlatforming m_Platforming;
        private IAssetManager m_AssetManager;
        private IRenderUtilities m_RenderUtilities;
        private TextureAsset m_Texture;
    
        public Player(
            IPlatforming platforming,
            IAssetManager assetManager,
            IRenderUtilities renderUtilities)
        {
            this.m_Platforming = platforming;
            this.m_AssetManager = assetManager;
            this.m_RenderUtilities = renderUtilities;
            this.m_Texture = this.m_AssetManager.Get<TextureAsset>("texture.Player");
        }
        
        public override void Render(IRenderContext context)
        {
            base.Render(context);
            
            this.m_RenderUtilities.RenderTexture(
                context,
                new Vector2(this.X, this.Y),
                this.m_Texture);
        }
    }
}

