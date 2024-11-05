using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Drawing;

namespace MortensKomeback
{
    public abstract class Environment : GameObject
    {
        #region field
        private GraphicsDeviceManager _graphics;

        private List<Surface> tiles = new List<Surface>();

        #endregion

        #region properties

        #endregion


        #region method
        //public void AddTile(Vector2 position, int numberSprite)
        //{
        //    tiles.Add(new Surface(_graphics, position, numberSprite));
        //}

        public override void OnCollision(GameObject gameObject)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            tiles.Add(new Surface(_graphics,  new Vector2(90f, 90f), 3));
        }

        public override void Update(GameTime gameTime)
        {

        }

        //public List<Surface> GetTiles()
        //{
        //    tiles.Add(new Surface(_graphics, new Vector2(90f, 90f), 3));


        //    return tiles;
        //}

        #endregion


    }
}
