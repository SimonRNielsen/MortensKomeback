using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    internal class IntroScreen : GameObject
    {
        #region Fields

        private Texture2D buttonSprite;
        private SpriteFont spriteFont;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public IntroScreen()
        {
            this.position = Vector2.Zero;
            this.health = 9999;
            this.layer = 0.99f;
            this.scale = 1.7f;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads sprites and font for buttons and itself
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            this.sprite = content.Load<Texture2D>("introScreen");
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

        #endregion
    }
}