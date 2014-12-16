using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Engine;
using SpaceInvaders.Engine.UserInterface;



namespace SpaceInvaders
{
        internal class TitleScreen : GameState
        {
                private Texture2D _TitleTexture;

                private SpriteFont _TitleFont;
                private ControlManager _ControlManager;

                private SmallInvader _SmallInvader;



                public TitleScreen(GameStateManager manager) : base(manager)
                {
                }



                public override void Initialize()
                {
                        _SmallInvader = new SmallInvader(Game);
                        _SmallInvader.Initialize();

                        GameComponents.Add(_SmallInvader);

                        base.Initialize();
                }
              


                protected override void LoadContent()
                {
                        base.LoadContent();

                        _TitleTexture = StateManager.Game.Content.Load<Texture2D>(@"TitleScreen");

                        _TitleFont = StateManager.Game.Content.Load<SpriteFont>(@"TitleFont");

                        _ControlManager = new ControlManager(InputHandler);

                        TextRenderingSettings playLabelRenderingSettings = TextRenderingHelper.CreateTextRenderingSettings(_TitleFont, "Play", Game.ScreenRectangle, TextAlignment.Center, false);
                        playLabelRenderingSettings.Position = playLabelRenderingSettings.Position + new Vector2(0, playLabelRenderingSettings.Size.Y);
                        
                        LinkLabel playLabel = new LinkLabel("Play Label", InputHandler, _TitleFont, playLabelRenderingSettings.Text);
                        playLabel.Position = playLabelRenderingSettings.Position;
                        playLabel.Color = Color.White;
                        playLabel.SelectedColor = Color.GreenYellow;
                        playLabel.HasFocus = true;
                        playLabel.Selected += OnPlayLabelSelected;
                        _ControlManager.Add(playLabel);

                        TextRenderingSettings exitLabelRenderingSettings = TextRenderingHelper.CreateTextRenderingSettings(_TitleFont, "Exit", Game.ScreenRectangle, TextAlignment.Center, false);
                        exitLabelRenderingSettings.Position = new Vector2(exitLabelRenderingSettings.Position.X, playLabelRenderingSettings.Position.Y + playLabelRenderingSettings.Size.Y);

                        LinkLabel exitLabel = new LinkLabel("Exit Label", InputHandler, _TitleFont, exitLabelRenderingSettings.Text);
                        exitLabel.Position = exitLabelRenderingSettings.Position;
                        exitLabel.Color = Color.White;
                        exitLabel.SelectedColor = Color.GreenYellow;
                        exitLabel.HasFocus = false;
                        exitLabel.Selected += OnExitLabelSelected;
                        _ControlManager.Add(exitLabel);
                }



                private void OnPlayLabelSelected(object sender, System.EventArgs e)
                {
                        StateManager.ChangeState(new PlayScreen(StateManager));
                }



                private void OnExitLabelSelected(object sender, System.EventArgs e)
                {
                        Game.Exit();
                }



                public override void Update(GameTime gameTime)
                {
                        _ControlManager.Update(gameTime, PlayerIndex.One);

                        base.Update(gameTime);
                }



                public override void Draw(GameTime gameTime)
                {
                        SpriteBatch spriteBatch = StateManager.Game.SpriteBatch;
                        
                        spriteBatch.Begin();
                        
                        spriteBatch.Draw(_TitleTexture, Vector2.Zero, Color.AntiqueWhite);

                        _ControlManager.Draw(spriteBatch);

                        base.Draw(gameTime);

                        spriteBatch.End();
                }
        }
}