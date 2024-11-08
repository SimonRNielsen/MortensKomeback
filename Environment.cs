using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MortensKomeback
{
    public class Environment
    {
        //Environment is the layout for the level and not a GameObject 
        #region field
        private GraphicsDeviceManager _graphics;
        private List<GameObject> surfaces = new List<GameObject>();

        private int tileHeight = 195 - 1;
        private int tileWidth = 206 - 1;


        #endregion

        #region properties
        public List<GameObject> Surfaces { get => surfaces; set => surfaces = value; }

        #endregion

        #region constructor
        /// <summary>
        /// Construction the Environment of all the surfaces and backgroud
        /// </summary>
        /// <param name="graphics"></param>
        public Environment(GraphicsDeviceManager graphics)
        {
            surfaces.Add(new Background(_graphics));

            #region button
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + tileHeight , 2, 1, 31); // Græstop på jorden (Morten spawner på den rigtige overflade)
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + (tileHeight * 2), 5, 1, 31); // Jordbund
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + tileHeight, 2, 34, 49); // Græstop på jorden (Morten spawner på den rigtige overflade)
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + (tileHeight * 2), 5, 34, 49); // Jordbund
            #endregion

            #region first hill
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight, 2, 13, 14);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight, 5, 15, 17);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - tileHeight, 2, 15, 17);
            #endregion

            #region first stairs
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight, 2, 26, 27);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight, 5, 28, 29);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - tileHeight, 2, 28, 28);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - tileHeight, 5, 29, 29);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 2), 2, 29, 29);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 2), 5, 30, 30);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 3), 2, 30, 30);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 3), 5, 31, 31);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 4), 2, 31, 32);
            AddSurface((tileWidth * 34), graphics.PreferredBackBufferHeight - (tileHeight * 5), 2); //Tile 34

            AddSurface((tileWidth * 35), graphics.PreferredBackBufferHeight - (tileHeight * 6), 2); //Tile 35
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 7), 2, 39, 41);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 9), 2, 36, 38);
            #endregion

            #region first platform
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 10), 2, 26, 27);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 10), 5, 28, 31);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 10), 2, 32, 33);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 11), 2, 28, 31);
            #endregion

            #region pillar

            #endregion
        }
        #endregion

        #region method
        /// <summary>
        /// Adding one Surface
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="spriteId">The sprite of the Surface</param>
        private void AddSurface(float x, float y, int spriteId)
        {
            surfaces.Add(Surface.Create(_graphics, x, y, spriteId));
        }

        /// <summary>
        /// Adding multipel Surfac
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="spriteId">The sprite of the Surface</param>
        /// <param name="times">The number of time the Surface is added</param>
        private void AddSurfaces(float x, float y, int spriteId, int start, int times) /// Lav ændring
        {
            for (int i = start-1; i < times; i++)
            {
                AddSurface(x * i, y, spriteId);
            }
        }

        /// <summary>
        /// Adding one AvSurface
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="spriteId">The sprite of the AvSurface</param>
        private void AddAvSurface(float x, float y, int spriteId)
        {
            surfaces.Add(AvSurface.Create(_graphics, x, y));
        }
        #endregion
    }

}

