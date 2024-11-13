using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MortensKomeback
{
    internal class MousePointer : GameObject
    {
        private GraphicsDeviceManager _graphics;

        public MousePointer(GraphicsDeviceManager graphics)
        {
            this.health = 9999999;
            this.scale = 1;
            this.layer = 0;
            _graphics = graphics;
        }

        public override Rectangle CollisionBox
        {
            get { return new Rectangle(((int)(GameWorld.mousePosition.X / GameWorld.Camera.Zoom) - (int)((float)_graphics.PreferredBackBufferWidth / 2 / GameWorld.Camera.Zoom) + (int)GameWorld.Camera.Position.X), ((int)(GameWorld.mousePosition.Y / GameWorld.Camera.Zoom) - (int)((float)_graphics.PreferredBackBufferHeight / 2 / GameWorld.Camera.Zoom) + 20 + (int)GameWorld.Camera.Position.Y), 1, 1); }
            
        }

        public override void LoadContent(ContentManager content)
        {
            //throw new NotImplementedException();
        }

        public override void OnCollision(GameObject gameObject)
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            GameWorld.mouseX = (int)(GameWorld.mousePosition.X / GameWorld.Camera.Zoom) - (int)((float)_graphics.PreferredBackBufferWidth / 2 / GameWorld.Camera.Zoom) + (int)GameWorld.Camera.Position.X;
            GameWorld.mouseY = (int)(GameWorld.mousePosition.Y / GameWorld.Camera.Zoom) - (int)((float)_graphics.PreferredBackBufferHeight / 2 / GameWorld.Camera.Zoom) + 20 + (int)GameWorld.Camera.Position.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Don't draw
        }
    }
}
