using Protogame;
using Microsoft.Xna.Framework;

namespace PlatformerDemo
{
    /// <summary>
    /// This entity is mapped to the solid layer in the Ogmo Editor.
    /// Generally you don't want this class to do any work as it'll be
    /// used quite heavily in the system.
    /// </summary>
    public class Solid : Entity, ISolidEntity
    {
        private IRenderUtilities m_RenderUtilities;
    
        public Solid(IRenderUtilities renderUtilities)
        {
            this.m_RenderUtilities = renderUtilities;
        }
    
        public override void Render(IGameContext gameContext, IRenderContext renderContext)
        {
            base.Render(gameContext, renderContext);
            
            this.m_RenderUtilities.RenderRectangle(
                renderContext,
                this.ToRectangle(),
                Color.Black);
        }
    }
}

