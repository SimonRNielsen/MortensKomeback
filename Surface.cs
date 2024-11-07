using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortensKomeback
{
    internal class Surface : GameObject
    {

        public Rectangle LeftSideCollisionBox
        {
            get { return new Rectangle((int)Position.X - ((Sprite.Width / 2) + 2), (int)Position.Y - ((Sprite.Height / 2) + 2), 2, (Sprite.Height) - 4); }
        }

        public Rectangle RightSideCollisionBox
        {
            get { return new Rectangle((int)Position.X + ((Sprite.Width / 2) + 2), (int)Position.Y - ((Sprite.Height / 2) + 2), 2, (Sprite.Height) - 4); }
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
            //throw new NotImplementedException();
        }
    }
}
