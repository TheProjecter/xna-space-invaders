using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Engine;



namespace SpaceInvaders
{
        internal class CollisionDetectionScreen : GameState<SpaceInvaders>
        {
                private Invader _Invader1;
                private Invader _Invader2;



                public CollisionDetectionScreen(GameStateManager<SpaceInvaders> stateManager) : base(stateManager)
                {
                }



                public override void Initialize()
                {
                        _Invader1 = new Invader(Game);
                        _Invader1.Position = new Vector2(100, 200);
                        GameComponents.Add(_Invader1);

                        _Invader2 = new Invader(Game);
                        _Invader2.Position = new Vector2(100, 300);
                        GameComponents.Add(_Invader2);


                        base.Initialize();
                }



                protected override void LoadContent()
                {
                        base.LoadContent();

                        _Invader1.MovementAnimation = Game.Animations.IntellivisionSpaceArmada.Movement.SmallInvader;
                        _Invader2.MovementAnimation = Game.Animations.IntellivisionSpaceArmada.Movement.MediumInvader;
                }



                public override void Update(GameTime gameTime)
                {
                        Vector2 velocity = Vector2.Zero;
                        if (InputHandler.IsCurrentlyPressed(Keys.Left))
                        {
                                velocity.X -= 1;
                        }
                        if (InputHandler.IsCurrentlyPressed(Keys.Right))
                        {
                                velocity.X += 1;
                        }
                        if (InputHandler.IsCurrentlyPressed(Keys.Up))
                        {
                                velocity.Y -= 1;
                        }
                        if (InputHandler.IsCurrentlyPressed(Keys.Down))
                        {
                                velocity.Y += 1;
                        }
                        _Invader2.Velocity = velocity;
                        

                        _Invader1.Position = InputHandler.MouseLocation;

                        base.Update(gameTime);

                        _Invader2.Velocity = Vector2.Zero;


                        CollisionDetection.CollisionResult collisionResult =
                                CollisionDetection.AxisAlignedBoundingBoxes.CheckForCollision(_Invader1, _Invader2, _Invader1.Velocity);
                        if (collisionResult.HaveCollided == true)
                        {
                                _Invader1.MovementAnimation = Game.Animations.IntellivisionSpaceArmada.Movement.BossInvader;
                        }
                        else
                        {
                                _Invader1.MovementAnimation = Game.Animations.IntellivisionSpaceArmada.Movement.SmallInvader;
                        }
                        

                        if (InputHandler.HasBeenPressed(Keys.Escape))
                        {
                                StateManager.PopState();
                        }
                }



                public override void Draw(GameTime gameTime)
                {
                        Game.GraphicsDevice.Clear(Color.Black);

                        Game.SpriteBatch.Begin();

                        base.Draw(gameTime);

                        Game.SpriteBatch.End();
                }
        }
}