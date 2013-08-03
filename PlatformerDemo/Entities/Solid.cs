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
    
        public Solid(IRenderUtilities renderUtilities, float x, float y, float width, float height)
        {
            this.m_RenderUtilities = renderUtilities;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}

