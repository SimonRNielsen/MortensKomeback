using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    /// <summary>
    /// A class for the special GameObject CharacterGenerator. It is used, to make the player choose a sprite for the player
    /// character, and then to instantiate a player GameObject, with the chosen sprite. 
    /// </summary>
    internal class CharacterGenerator : GameObject
    {
        public override void LoadContent(ContentManager content)
        {
            content.Load<Texture2D>("morten_sprite");
        }

        public override void OnCollision(GameObject gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        private void AddPlayer()
        {
            GameWorld.newGameObjects.Add(new Player());
        }

        private void HandleInput()
        {

        }
    }
}
