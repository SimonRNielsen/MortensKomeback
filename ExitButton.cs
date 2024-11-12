using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MortensKomeback
{
    internal class ExitButton : Button
    {
        SpriteFont spriteFont;
        private bool collision = false;

        public ExitButton(Texture2D sprite, Vector2 pos, SpriteFont font)
        {
            this.sprite = sprite;
            this.position = pos;
            this.health = 9999;
            this.layer = 0.998f;
            spriteFont = font;
        }

        public override void LoadContent(ContentManager content)
        {
            //throw new NotImplementedException();
        }

        public override void OnCollision(GameObject gameObject)
        {
            if (gameObject is MousePointer)
                collision = true;
            if (gameObject is MousePointer && GameWorld.leftMouseButtonClick == true)
                GameWorld.exitGame = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (collision)
                this.colorIndex = 1;
            else
                this.colorIndex = 0;
            collision = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, null, Color.White, rotation, new Vector2(Sprite.Width / 2, Sprite.Height / 2), scale, SpriteEffects.None, layer);
            spriteBatch.DrawString(spriteFont, "Exit", Position, buttonColor[colorIndex], 0f, new Vector2(18, 8), 2f, SpriteEffects.None, 0.999f);
        }
    }
}
