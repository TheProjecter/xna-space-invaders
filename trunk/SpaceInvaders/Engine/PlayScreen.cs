using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace SpaceInvaders.Engine
{
        internal class PlayScreen : GameState
        {
                public PlayScreen(GameStateManager stateManager) : base(stateManager)
                {
                }



                public override void Update(GameTime gameTime)
                {
                        base.Update(gameTime);


                        if(InputHandler.HasBeenPressed(Keys.Escape))
                        {
                                Game.Exit();
                        }
                }



                public override void Draw(GameTime gameTime)
                {
                        int r = Game.RandomNumberGenerator.Next(0, 256);
                        int g = Game.RandomNumberGenerator.Next(0, 256);
                        int b = Game.RandomNumberGenerator.Next(0, 256);
                        Color randomColor = new Color(r, g, b);


                        StateManager.Game.GraphicsDevice.Clear(randomColor);
                }
        }
}