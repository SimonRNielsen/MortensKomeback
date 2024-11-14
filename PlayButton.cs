using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    internal class PlayButton : Button
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for placing PlayButton
        /// </summary>
        /// <param name="sprite">Gets sprite externally</param>
        /// <param name="pos">Gets position externally</param>
        /// <param name="font">Gets font externally</param>
        public PlayButton(Texture2D sprite, Vector2 pos, SpriteFont font)
        {
            this.sprite = sprite;
            this.position = pos;
            this.health = 9999;
            this.layer = 0.998f;
            spriteFont = font;
            this.buttonText = "Play";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines interaction with MousePointer/Mouse
        /// </summary>
        /// <param name="gameObject">MousePointer CollisionBox</param>
        public override void OnCollision(GameObject gameObject)
        {
            if (gameObject is MousePointer)
                collision = true;
            if (gameObject is MousePointer && GameWorld.leftMouseButtonClick == true)
                GameWorld.removeScreen = true;
        }

        #endregion
    }
}