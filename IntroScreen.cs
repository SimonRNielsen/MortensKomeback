using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    internal class IntroScreen : GameObject
    {
        private Texture2D buttonSprite;
        private SpriteFont spriteFont;

        public IntroScreen(Vector2 placement)
        {
            this.position = placement;
            this.health = 9999;
            this.layer = 0.99f;
            this.scale = 1.7f;
        }


        public override void LoadContent(ContentManager content)
        {
            this.sprite = content.Load<Texture2D>("udkast");
            spriteFont = content.Load<SpriteFont>("mortalKombatFont");
            buttonSprite = content.Load<Texture2D>("button");
            GameWorld.newGameObjects.Add(new PlayButton(buttonSprite, new Vector2(position.X - 400, position.Y + 300), spriteFont));
            GameWorld.newGameObjects.Add(new ExitButton(buttonSprite, new Vector2(position.X + 400, position.Y + 300), spriteFont));
        }

        public override void OnCollision(GameObject gameObject)
        {
            //
        }

        public override void Update(GameTime gameTime)
        {
            //
        }

        
    }
}