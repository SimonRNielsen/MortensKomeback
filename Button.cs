using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    public abstract class Button : GameObject
    {
        protected Color[] buttonColor = new Color[2] {Color.DarkRed, Color.Yellow};
        protected int colorIndex;
        protected SpriteFont spriteFont;
        protected bool collision = false;
        protected string buttonText;
        protected float textXDisplacement;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, null, Color.White, rotation, new Vector2(Sprite.Width / 2, Sprite.Height / 2), scale, SpriteEffects.None, layer);
            spriteBatch.DrawString(spriteFont, buttonText, new Vector2 (Position.X + textXDisplacement, Position.Y), buttonColor[colorIndex], 0f, new Vector2(18, 8), 2f, SpriteEffects.None, 0.999f);
        }

        public override void LoadContent(ContentManager content) { }

        public override void Update(GameTime gameTime)
        {
            if (collision)
                this.colorIndex = 1;
            else
                this.colorIndex = 0;
            collision = false;
        }
    }
}
