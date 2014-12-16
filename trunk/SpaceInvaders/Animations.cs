using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Engine;



namespace SpaceInvaders
{
    internal class Animations : IDisposable
    {
        private Animations()
        {
        }



        private IList<IDisposable> Disposables
        {
            get
            {
                if (_Disposables == null)
                {
                    _Disposables = new List<IDisposable>();
                }

                return _Disposables;
            }
        }
        private List<IDisposable> _Disposables;



        public void Dispose()
        {
            foreach (IDisposable disposable in Disposables)
            {
                disposable.Dispose();
            }

            _Disposables.Clear();
        }







        public static Animations Create(ContentManager contentManager, short defaultNumberOfMillisecondsToDisplayEachFrame)
        {
            if (contentManager == null)
            {
                throw new ArgumentNullException("contentManager");
            }

            Texture2D spriteSheet = contentManager.Load<Texture2D>("SpriteSheet");

            Animations animations = new Animations();
            animations.Disposables.Add(spriteSheet);

            animations._IntellivisionSpaceArmada = new Theme();
            animations._IntellivisionSpaceArmada.CreateMovements(
                defaultNumberOfMillisecondsToDisplayEachFrame,
                new AnimationFrame[]
                {
                    new AnimationFrame(spriteSheet, new Rectangle(8, 603, 26, 16), null),
                    new AnimationFrame(spriteSheet, new Rectangle(48, 603, 26, 16), null),
                },
                new AnimationFrame[]
                {
                    new AnimationFrame(spriteSheet, new Rectangle(87, 606, 24, 16), null),
                    new AnimationFrame(spriteSheet, new Rectangle(127, 606, 24, 16), null),
                },
                new AnimationFrame[]
                {
                    new AnimationFrame(spriteSheet, new Rectangle(9, 633, 24, 16), null),
                    new AnimationFrame(spriteSheet, new Rectangle(49, 633, 24, 16), null),
                },
                new AnimationFrame[]
                {
                    new AnimationFrame(spriteSheet, new Rectangle(84, 632, 28, 16), null),
                    new AnimationFrame(spriteSheet, new Rectangle(126, 632, 28, 16), null),
                });
            return animations;
        }

        

        public Theme IntellivisionSpaceArmada
        {
            get { return _IntellivisionSpaceArmada; }
        }

        private Theme _IntellivisionSpaceArmada;




        



        public class Theme
        {
            public Movements Movement { get; private set; }


            public void CreateMovements(short defaultNumberOfMillisecondsToDisplayEachFrame, IEnumerable<AnimationFrame> smallInvader, IEnumerable<AnimationFrame> mediumInvader, IEnumerable<AnimationFrame> largeInvader, IEnumerable<AnimationFrame> bossInvader)
            {
                Movement = Movements.Create(defaultNumberOfMillisecondsToDisplayEachFrame, smallInvader, mediumInvader, largeInvader, bossInvader);
            }


            
            public class Movements
            {
                private Movements() { }


                public Animation SmallInvader { get; private set; }
                public Animation MediumInvader { get; private set; }
                public Animation LargeInvader { get; private set; }
                public Animation BossInvader { get; private set; }


                public static Movements Create(short defaultNumberOfMillisecondsToDisplayEachFrame, IEnumerable<AnimationFrame> smallInvader, IEnumerable<AnimationFrame> mediumInvader, IEnumerable<AnimationFrame> largeInvader, IEnumerable<AnimationFrame> bossInvader)
                {
                    Movements movements = new Movements();
                    movements.SmallInvader = new Animation(defaultNumberOfMillisecondsToDisplayEachFrame, smallInvader);
                    movements.MediumInvader = new Animation(defaultNumberOfMillisecondsToDisplayEachFrame, mediumInvader);
                    movements.LargeInvader = new Animation(defaultNumberOfMillisecondsToDisplayEachFrame, largeInvader);
                    movements.BossInvader = new Animation(defaultNumberOfMillisecondsToDisplayEachFrame, bossInvader);

                    return movements;
                }
            }
        }
    }
}