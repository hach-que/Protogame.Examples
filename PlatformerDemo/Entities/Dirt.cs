using Protogame;

namespace PlatformerDemo
{
    public class Dirt : Entity, ITileEntity
    {
        private ITileUtilities m_TileUtilities;
    
        public int TX { get; set; }
        public int TY { get; set; }
    
        public Dirt(ITileUtilities tileUtilities, float x, float y, int tx, int ty)
        {
            this.m_TileUtilities = tileUtilities;
            
            this.X = x;
            this.Y = y;
            this.TX = tx;
            this.TY = ty;
            
            this.m_TileUtilities.AdjustTileBounds(this, 16, 16);
        }
        
        public override void Render(IGameContext gameContext, IRenderContext renderContext)
        {
            base.Render(gameContext, renderContext);
            
            this.m_TileUtilities.RenderTile(this, renderContext);
        }
    }
}

