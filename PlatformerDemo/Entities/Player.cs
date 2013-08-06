using Protogame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System;

namespace PlatformerDemo
{
    public class Player : Entity
    {
        private IPlatforming m_Platforming;
        private IAssetManager m_AssetManager;
        private I2DRenderUtilities m_RenderUtilities;
        private IAudioUtilities m_AudioUtilities;
        private TextureAsset m_Texture;
        private AudioAsset m_JumpSound;
        private IAudioHandle m_JumpHandle;
    
        public Player(
            IPlatforming platforming,
            IAssetManager assetManager,
            I2DRenderUtilities renderUtilities,
            IAudioUtilities audioUtilities)
        {
            this.m_Platforming = platforming;
            this.m_AssetManager = assetManager;
            this.m_RenderUtilities = renderUtilities;
            this.m_AudioUtilities = audioUtilities;
            
            this.m_Texture = this.m_AssetManager.Get<TextureAsset>("texture.Player");
            this.m_JumpSound = this.m_AssetManager.Get<AudioAsset>("audio.Jump");
            
            this.m_JumpHandle = this.m_AudioUtilities.Play(this.m_JumpSound);
            
            this.Width = 32;
            this.Height = 32;
        }
        
        private bool OnGround(IGameContext gameContext)
        {
            return this.m_Platforming.IsOnGround(
                this,
                gameContext.World.Entities.Cast<IBoundingBox>(),
                x => x is Solid);
        }
        
        public override void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
            base.Update(gameContext, updateContext);
            
            var mouse = Mouse.GetState();
            var keyboard = Keyboard.GetState();
            if (mouse.LeftPressed(this))
            {
                this.X = mouse.X;
                this.Y = mouse.Y;
                this.XSpeed = 0;
                this.YSpeed = 0;
                this.m_JumpHandle.Play();
            }
            if (keyboard.IsKeyDown(Keys.Left))
                this.m_Platforming.ApplyMovement(this, -4, 0, gameContext.World.Entities.Cast<IBoundingBox>(), x => x is Solid);
            if (keyboard.IsKeyDown(Keys.Right))
                this.m_Platforming.ApplyMovement(this, 4, 0, gameContext.World.Entities.Cast<IBoundingBox>(), x => x is Solid);
            
            if (!this.OnGround(gameContext))
                this.m_Platforming.ApplyGravity(this, 0, 0.5f);
            else if (this.YSpeed > 0)
            {
                this.YSpeed = 0;
                this.m_Platforming.ApplyActionUntil(this, a => a.Y += 1, a => this.OnGround(gameContext), 12);
            }
            this.m_Platforming.ClampSpeed(this, null, 12);
            
            if (keyboard.IsKeyPressed(Keys.Up) && this.OnGround(gameContext))
                this.YSpeed = -6;
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

