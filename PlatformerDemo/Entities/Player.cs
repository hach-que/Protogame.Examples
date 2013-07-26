using Protogame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PlatformerDemo
{
    public class Player : Entity
    {
        private IPlatforming m_Platforming;
        private IAssetManager m_AssetManager;
        private IRenderUtilities m_RenderUtilities;
        private IAudioUtilities m_AudioUtilities;
        private TextureAsset m_Texture;
        private AudioAsset m_JumpSound;
        private IAudioHandle m_JumpHandle;
    
        public Player(
            IPlatforming platforming,
            IAssetManager assetManager,
            IRenderUtilities renderUtilities,
            IAudioUtilities audioUtilities)
        {
            this.m_Platforming = platforming;
            this.m_AssetManager = assetManager;
            this.m_RenderUtilities = renderUtilities;
            this.m_AudioUtilities = audioUtilities;
            
            this.m_Texture = this.m_AssetManager.Get<TextureAsset>("texture.Player");
            this.m_JumpSound = this.m_AssetManager.Get<AudioAsset>("audio.Jump");
            
            this.m_JumpHandle = this.m_AudioUtilities.Play(this.m_JumpSound);
        }
        
        public override void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
            base.Update(gameContext, updateContext);
            
            var mouse = Mouse.GetState();
            if (mouse.LeftPressed(this))
                this.m_JumpHandle.Play();
        }
        
        public override void Render(IGameContext gameContext, IRenderContext renderContext)
        {
            base.Render(gameContext, renderContext);
            
            this.m_RenderUtilities.RenderTexture(
                renderContext,
                new Vector2(this.X, this.Y),
                this.m_Texture);
        }
    }
}

