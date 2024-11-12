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

        private int tileHeight = 199;
        private int tileWidth = 199;


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
            #region button
            //First buttom
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + tileHeight , 2, 1, 31); // Græstop på jorden (Morten spawner på den rigtige overflade)
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + (tileHeight * 2), 1, 1, 31); // Jordbund

            //Second buttom
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + tileHeight, 2, 34, 49);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + (tileHeight * 2), 1, 34, 49);

            //Third buttom
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + tileHeight, 2, 52, 91);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + (tileHeight * 2), 1, 52, 91);

            //Forth buttom
            for (int i = -1; i < 3; i++)
            {
                AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight + (tileHeight * i), 1, 109, 110);
            }
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 2), 2, 109, 110);

            //Fifth buttom
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + tileHeight, 2, 124, 180);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight + (tileHeight * 2), 1, 124, 180);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight + tileHeight, 1, 181, 182);
            #endregion

            #region hill
            //First hill
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight, 2, 13, 14);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight, 1, 15, 17);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - tileHeight, 2, 15, 17);

            //Secong hill
            AddSurface(tileWidth * 86, graphics.PreferredBackBufferHeight, 2);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight, 1, 88, 91);
            AddSurface(tileWidth * 87, graphics.PreferredBackBufferHeight - tileHeight, 2);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - tileHeight, 1, 89, 91);
            AddSurface(tileWidth * 88, graphics.PreferredBackBufferHeight - (tileHeight * 2), 2);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 2), 1, 90, 91);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 3), 2, 90, 92);

            //Third hill
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight, 1, 124, 128); //
            for (int i = 1; i < 5; i++)
            {
                AddSurface(tileWidth * 127, graphics.PreferredBackBufferHeight - (tileHeight * i), 1);
            }
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 5), 1, 125, 127);
            AddSurface(tileWidth * 127, graphics.PreferredBackBufferHeight - (tileHeight * 5), 2);
            AddSurface(tileWidth * 123, graphics.PreferredBackBufferHeight - (tileHeight * 6), 2);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 6), 1, 125, 127);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 7), 2, 125, 127);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 2), 2, 131, 133);

            #endregion

            #region stairs
            //First stairs
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight, 2, 26, 27);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight, 1, 28, 29);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - tileHeight, 2, 28, 28);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - tileHeight, 1, 29, 29);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 2), 2, 29, 29);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 2), 1, 30, 30);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 3), 2, 30, 31);
            AddSurface(tileWidth * 33, graphics.PreferredBackBufferHeight - (tileHeight * 5), 4);

            AddSurface((tileWidth * 35), graphics.PreferredBackBufferHeight - (tileHeight * 6), 2); 
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 7), 2, 39, 41);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 9), 2, 36, 38);

            //Second stairs
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight, 2, 60 ,66);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight, 1, 67, 70);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - tileHeight, 2, 67, 69);
            AddSurface(tileWidth * 69, graphics.PreferredBackBufferHeight - tileHeight, 1);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 2), 2, 70, 71);

            AddSurface(tileWidth * 73, graphics.PreferredBackBufferHeight - (tileHeight * 3), 2);

            AddSurface(tileWidth * 76, graphics.PreferredBackBufferHeight - (tileHeight * 5), 4);
            AddSurface(tileWidth * 79, graphics.PreferredBackBufferHeight - (tileHeight * 6), 2);
            AddSurface(tileWidth * 82, graphics.PreferredBackBufferHeight - (tileHeight * 7), 2);

            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 3), 2, 84, 85);

            AddSurface(tileWidth * 84, graphics.PreferredBackBufferHeight - (tileHeight * 9), 4);
            for (int i = 0; i < 12; i++)
            {
                AddSurface(tileWidth * (87 + i * 3), graphics.PreferredBackBufferHeight - (tileHeight * 9), 3);
            }

            #endregion

            #region platform
            //First platform
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 10), 2, 26, 27);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 10), 1, 28, 31);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 10), 2, 32, 33);
            AddSurfaces((tileWidth), graphics.PreferredBackBufferHeight - (tileHeight * 11), 2, 28, 31);

            //Second platform
            AddSurface(tileWidth * 54, graphics.PreferredBackBufferHeight - (tileHeight * 5), 4);

            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 5), 1, 59, 66);
            AddSurface(tileWidth * 66, graphics.PreferredBackBufferHeight - (tileHeight * 5), 2);
            AddSurface(tileWidth * 58, graphics.PreferredBackBufferHeight - (tileHeight * 6), 2);
            AddSurface(tileWidth * 59, graphics.PreferredBackBufferHeight - (tileHeight * 6), 1);
            AddSurface(tileWidth * 59, graphics.PreferredBackBufferHeight - (tileHeight * 6), 1);
            AddSurface(tileWidth * 65, graphics.PreferredBackBufferHeight - (tileHeight * 6), 1);
            AddSurface(tileWidth * 59, graphics.PreferredBackBufferHeight - (tileHeight * 7), 2);
            AddSurface(tileWidth * 65, graphics.PreferredBackBufferHeight - (tileHeight * 7), 2);

            //Third platforms
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 3), 2, 95, 99);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 2), 2, 102, 103);
            AddSurface(tileWidth * 105, graphics.PreferredBackBufferHeight - tileHeight, 2);

            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileWidth * (111 + i * 3), graphics.PreferredBackBufferHeight - tileHeight, 2);
            }
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 4), 2, 113, 114);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 5), 2, 116, 117);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 6), 2, 120, 121);


            #endregion

            #region pillar
            //1
            AddSurface(tileWidth * 40, graphics.PreferredBackBufferHeight, 1);
            AddSurface(tileWidth * 40, graphics.PreferredBackBufferHeight - tileHeight, 2);

            //2
            AddSurface(tileWidth * 44, graphics.PreferredBackBufferHeight - (tileHeight * 2), 1);
            AddSurface(tileWidth * 44, graphics.PreferredBackBufferHeight - (tileHeight * 3), 2);

            //3
            for (int i = 0; i < 4; i++)
            {
                AddSurface(tileWidth * 48, graphics.PreferredBackBufferHeight - (tileHeight * i), 1);
            }
            AddSurface(tileWidth * 48, graphics.PreferredBackBufferHeight - (tileHeight * 4), 2);

            //4
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight, 1, 52, 53);
            AddSurface(tileWidth * 51, graphics.PreferredBackBufferHeight - tileHeight, 1);
            AddSurface(tileWidth * 52, graphics.PreferredBackBufferHeight - tileHeight, 2);
            AddSurface(tileWidth * 51, graphics.PreferredBackBufferHeight - (tileHeight * 2), 2);
            #endregion

            #region obstacles
            //Mitre
            AddSurface(tileWidth * 34, graphics.PreferredBackBufferHeight, 5);
            AddSurface(tileWidth * 139, graphics.PreferredBackBufferHeight, 5);
            AddSurface(tileWidth * 170, graphics.PreferredBackBufferHeight, 5);


            #endregion

            #region stairways to heaven
            int n = 45;
            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileWidth * (225 + i - n), graphics.PreferredBackBufferHeight - (tileHeight * i), 2);
                AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * i), 1, 227 + i - n, 229 + i - n);
            }
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 5), 2, 231 - n, 232 - n);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 6), 2, 233 - n, 237 - n);

            for (int i = 0; i < 5; i++)
            {
                AddSurface(tileWidth * (237 + i - n), graphics.PreferredBackBufferHeight - (tileHeight * (i + 6)), 2);
                AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * (i + 6)), 1, 239 + i - n, 241 + i - n);
            }
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 11), 2, 198, 200);
            AddSurfaces(tileWidth, graphics.PreferredBackBufferHeight - (tileHeight * 12), 2, 201, 203);

            #endregion

            #region AvSurface
            AddAvSurface(tileWidth * 99, graphics.PreferredBackBufferHeight + (tileHeight * 1.5f), 1);
            AddAvSurface(tileWidth * 115, graphics.PreferredBackBufferHeight + (tileHeight * 1.5f), 1);


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
        /// <param name="startIndex"></param>
        /// <param name="endIndex">The number of time the Surface is added</param>
        private void AddSurfaces(float x, float y, int spriteId, int startIndex, int endIndex) /// Lav ændring
        {
            for (int i = startIndex-1; i < endIndex; i++)
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

