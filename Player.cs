using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MortensKomeback
{
    /// <summary>
    /// Class for the player. Is the players avatar in the game, and can be moved etc. by the player. 
    /// </summary>
    internal class Player : Character
    {
        #region Fields
        private Texture2D[] ammoSprites;
        private Texture2D mitre;
        private SoundEffect shootSound;
        private SoundEffect takeDamageSound;
        private bool canShoot = true;
        private bool canJump = false;
        private bool flipped = false;
        private bool mitreOn = false;
        private int ammoHealth = 1;
        private int ammoSprite = 0;
        private int ammoCount = 0;
        private int mortenSkinType;
        private float spriteXDisplacement;
        private float spriteYDisplacement;
        private float mitretimer;
        private float mitreOnTime = 15f;
        private float smoothJump = 0.21f;
        private float jumpingTime = 0.2f;
        private float invincibleCooldown = 2f; //Used to make player invincible after damaging collison
        private float invincibleTimer; //Used with invincible timer, and set when Update() is called, and reset upon damagin collision
        private bool invincible = false; //Used to make player invincible after damaging collison
        private SoundEffect avSound;
        private SoundEffect[] walkSounds;
        private SoundEffect walkSound;
        private float walkCooldown = 0.4f;
        private float walkTimer;
        private SoundEffect ammoSound;



        #endregion

        #region Properties
        /// <summary>
        /// Property to access the sprites upon constructing "Ammo"
        /// </summary>
        public Texture2D[] AmmoSprites { get => ammoSprites; set => ammoSprites = value; }

        /// <summary>
        /// Property to access which direction Morten is facing upon constructing "Ammo"
        /// </summary>
        public bool Flipped { get => flipped; set => flipped = value; }
        public SoundEffect AmmoSound { get => ammoSound; private set => ammoSound = value; }

        #endregion


        #region Constructor
        /// <summary>
        /// The players constructor. All relevant fields are set, for a normal running gaming-experience. 
        /// The Player constructor, should only be used by the CharacterGenerator, as character creation at hte start of the game, is the only
        /// case in which a new Player should be spawned.
        /// </summary>
        /// <param name="sprite">The sprite of the player character, as chosen in character generator.</param>
        public Player(Texture2D sprite, Texture2D[] sprites, int mortenSkin)
        {
            this.position.X = 0;
            this.position.Y = 0;
            this.speed = 650f; //Husk at ændre tilbage til 300f
            this.fps = 15f;
            this.Health = 3;
            this.layer = 0.9f;
            this.scale = 1;
            this.sprite = sprite;
            this.sprites = sprites;
            Overlay.HealthCount = this.Health;
            this.mortenSkinType = mortenSkin;
        }


        #endregion

        #region Methods
        public override void LoadContent(ContentManager content)
        {

            //Sprites for the Ammo class to pull upon being "constructed" by Morten
            AmmoSprites = new Texture2D[5];
            AmmoSprites[0] = content.Load<Texture2D>("egg1");
            AmmoSprites[1] = content.Load<Texture2D>("egg2");
            AmmoSprites[2] = content.Load<Texture2D>("groundegg0");
            AmmoSprites[3] = content.Load<Texture2D>("groundegg1");
            AmmoSprites[4] = content.Load<Texture2D>("groundegg2");
            avSound = content.Load<SoundEffect>("morten_Av");
            shootSound = content.Load<SoundEffect>("shootSound");
            walkSounds = new SoundEffect[2];
            walkSounds[0] = content.Load<SoundEffect>("walkSound");
            walkSounds[1] = content.Load<SoundEffect>("walkSound2");
            walkSound = walkSounds[0];
            AmmoSound = content.Load<SoundEffect>("eggSmash_Sound");

            mitre = content.Load<Texture2D>("Sprite\\mitre");
        }

        public override void OnCollision(GameObject gameObject)
        {
            base.OnCollision(gameObject);
            if (gameObject is Enemy && !invincible)
            {
                TakeDamage();
                avSound.Play();
            }
            if (gameObject is AvSurface && !invincible)
            {
                TakeDamage();
                avSound.Play();
                Jump();
            }
            Overlay.HealthCount = this.Health;
        }

        public override void Update(GameTime gameTime)
        {
            invincibleTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            walkTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            mitretimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            smoothJump += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (mitretimer >= mitreOnTime)
                mitreOn = false;

            if (this.position.X > 40100)
            {
                GameWorld.win = true;
                this.health = 0;
            }

            if (invincibleTimer > invincibleCooldown)
            {
                invincible = false;
            }
            if (ammoCount <= 0)
            {
                this.ammoCount = 0;
                this.ammoHealth = 1;
                this.ammoSprite = 0;
            }
            HandleInput();
            if (smoothJump < jumpingTime)
                velocity -= new Vector2(0, +4);

            if (surfaceContact)
                canJump = true;
            base.Update(gameTime);
            Move(gameTime);


            GameWorld.Camera.Position = this.Position; //"Attaches" The viewport to Morten'
            if (velocity.X > 0 || velocity.X < 0)
            {
                Animate(gameTime);
            }

            Enemy.PlayerPosition = this.position;
        }

        /// <summary>
        /// A method, that handles player input. AD moves the player, space makes it jump and enter makes it shoot. 
        /// </summary>
        private void HandleInput()
        {
            velocity = Vector2.Zero; //Resets the velocity, so move stops when no keys are pressed

            KeyboardState keyState = Keyboard.GetState();//Get the current keyboard state
            /* (Successful experiment to use mouse position on screen to determine which way player is facing
            if (GameWorld.mouseX < this.position.X)
            {
                spriteEffectIndex = 1;
                flipped = true;
            }

            if (GameWorld.mouseX > this.position.X)
            {
                spriteEffectIndex = 0;
                flipped = false;
            }
            */
            //If a is pressed the player moves left, and the sprite is flipped so it faces left
            if (keyState.IsKeyDown(Keys.A))
            {
                Flipped = true;
                spriteEffectIndex = 1;
                WalkSound();
                //Move left
                velocity += new Vector2(-1, 0);
            }
            //If d is pressed the player moves right and the sprite is flipped so it faces right.
            if (keyState.IsKeyDown(Keys.D))
            {
                spriteEffectIndex = 0;
                Flipped = false;
                WalkSound();
                //Move right
                velocity += new Vector2(+1, 0);
            }
            //Normalises the velocity
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            //If enter is pressed, the player will shoot
            if (keyState.IsKeyDown(Keys.Enter) && canShoot)
            {
                //Makes sure that you can only fire ones per click on enter
                canShoot = false;
                Shoot();
            }
            if (keyState.IsKeyUp(Keys.Enter))
            {
                canShoot = true;
            }

            //If space is pressed, the player will jump.
            if (keyState.IsKeyDown(Keys.Space) && canJump)
            {
                //Makes sure the player only jumps once per click on space. 
                canJump = false;
                Jump();
            }
            /*
            if (keyState.IsKeyUp(Keys.Space))
            {
                canJump = true;
            }
            */
#if DEBUG
            if (keyState.IsKeyDown(Keys.K))
                this.health = 0;

            if (keyState.IsKeyDown(Keys.T))
            {
                this.position = new Vector2(38000, -1000);
            }
#endif
        }

        /// <summary>
        /// Shoots, by creating a new instance of Ammo. 
        /// </summary>
        private void Shoot()
        {
            shootSound.Play();
            //If ammo count (special ammo) is available it will be used, and therefore one subtracted from the count here. 
            if (ammoCount > 0)
            {
                ammoCount--;
                Overlay.PlayerAmmoCount = this.ammoCount;
            }
            GameWorld.newGameObjects.Add(new Ammo(this, ammoHealth, ammoSprite));
        }
        /// <summary>
        /// Makes the player jump
        /// </summary>
        private void Jump()
        {
            smoothJump = 0f;
            //velocity -= new Vector2(0, +20);
        }

        /// <summary>
        /// Sets changed parameters for when Morten picks up an Ammo PowerUp
        /// </summary>
        public void OverPowered()
        {
            this.ammoSprite = 1;
            this.ammoHealth = 3;
            this.ammoCount += 10;
            Overlay.PlayerAmmoCount = this.ammoCount;
        }

        /// <summary>
        /// Handles the players damage taken and sets and resets an invulnerabilty timer so time has to pass until player can take damage again
        /// </summary>
        public void TakeDamage()
        {
            this.Health--;
            invincibleTimer = 0;
            invincible = true;
        }

        /// <summary>
        /// Plays a walking sound for the player. Uses a timer, and switches between two sounds, for a natural sounding walk. 
        /// </summary>
        private void WalkSound()
        {
            if (walkTimer > walkCooldown && surfaceContact)
            {
                walkSound.Play();
                walkTimer = 0;
                if (walkSound == walkSounds[0])
                {
                    walkSound = walkSounds[1];
                }
                else if (walkSound == walkSounds[1])
                {
                    walkSound = walkSounds[0];
                }
            }
        }

        /// <summary>
        /// Makes player invulnerable for a set duration of time (invincibleTimer*-1 + invincibleCooldown seconds) and enables player character to draw the mitre sprite on its "head"
        /// </summary>
        public void InvulnerablePowerUp()
        {
            this.invincible = true;
            this.invincibleTimer = -13f;
            mitreOn = true;
            mitretimer = 0f;
        }

        /// <summary>
        /// Overrides draw to enable player to draw the "mitre" while invulnerable
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, null, Color.White, rotation, new Vector2(Sprite.Width / 2, Sprite.Height / 2), scale, objectSpriteEffects[spriteEffectIndex], layer);

            if (mitreOn)
            {

                switch (mortenSkinType)
                {
                    case 0:
                        spriteYDisplacement = 95;
                        if (flipped)
                        {
                            spriteXDisplacement = 73;
                        }
                        else
                        {
                            spriteXDisplacement = 23;
                        }
                        break;
                    case 1:
                        spriteYDisplacement = 100;
                        if (flipped)
                        {
                            spriteXDisplacement = 63;
                        }
                        else
                        {
                            spriteXDisplacement = 3;
                        }
                        break;
                }

                spriteBatch.Draw(mitre, new Vector2(position.X + spriteXDisplacement, position.Y - spriteYDisplacement), null, Color.White, rotation, new Vector2(Sprite.Width / 2, Sprite.Height / 2), scale, objectSpriteEffects[spriteEffectIndex], layer);
            }
        }
        #endregion

    }
}
