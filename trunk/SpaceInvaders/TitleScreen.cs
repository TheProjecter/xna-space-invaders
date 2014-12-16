using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Engine;
using SpaceInvaders.Engine.UserInterface;



namespace SpaceInvaders
{
    internal class TitleScreen : GameState<SpaceInvaders>
    {
        private Texture2D _TitleTexture;

        private SpriteFont _TitleFont;
        private ControlManager _ControlManager;

        private Invader[] _Invaders;



        public TitleScreen(GameStateManager<SpaceInvaders> manager) : base(manager)
        {
        }



        public override void Initialize()
        {
            _Invaders = new Invader[10];
            for (int invaderIndex = 0; invaderIndex < _Invaders.Length; invaderIndex += 1)
            {
                Invader invader = new Invader(Game);
                invader.Position = new Vector2(Game.RandomNumberGenerator.Next(0,800), Game.RandomNumberGenerator.Next(0,800));
                _Invaders[invaderIndex] = invader;

                GameComponents.Add(invader);
            }
            

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


            foreach (Invader invader in _Invaders)
            {
                Animation movingAnimation;

                switch (Game.RandomNumberGenerator.Next(0,4))
                {
                    case 0:
                        movingAnimation = Game.Animations.IntellivisionSpaceArmada.Movement.MediumInvader;
                        break;
                    case 1:
                        movingAnimation = Game.Animations.IntellivisionSpaceArmada.Movement.LargeInvader;
                        break;
                    case 2:
                        movingAnimation = Game.Animations.IntellivisionSpaceArmada.Movement.BossInvader;
                        break;
                    default:
                        movingAnimation = Game.Animations.IntellivisionSpaceArmada.Movement.SmallInvader;
                        break;
                }

                invader.MovementAnimation = movingAnimation;
            }
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