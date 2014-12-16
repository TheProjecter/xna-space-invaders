using Microsoft.Xna.Framework.Input;


namespace SpaceInvaders.Engine
{
        /// <summary>
        /// Represents a particular button on a mouse. 
        /// </summary>
        public class MouseButton
        {
                private MouseButton()
                {
                }


                protected internal virtual bool HasState(MouseState mouseState, ButtonState state)
                {
                        return false;
                }


                private sealed class LeftMouseButton : MouseButton
                {
                        protected internal override bool HasState(MouseState mouseState, ButtonState buttonState)
                        {
                                return mouseState.LeftButton == buttonState;
                        }
                }

                private sealed class MiddleMouseButton : MouseButton
                {
                        protected internal override bool HasState(MouseState mouseState, ButtonState buttonState)
                        {
                                return mouseState.MiddleButton == buttonState;
                        }
                }

                private sealed class RightMouseButton : MouseButton
                {
                        protected internal override bool HasState(MouseState mouseState, ButtonState buttonState)
                        {
                                return mouseState.RightButton == buttonState;
                        }
                }

                private sealed class XButton1MouseButton : MouseButton
                {
                        protected internal override bool HasState(MouseState mouseState, ButtonState buttonState)
                        {
                                return mouseState.XButton1 == buttonState;
                        }
                }

                private sealed class XButton2MouseButton : MouseButton
                {
                        protected internal override bool HasState(MouseState mouseState, ButtonState buttonState)
                        {
                                return mouseState.XButton2 == buttonState;
                        }
                }

                public static MouseButton Left = new LeftMouseButton();
                public static MouseButton Middle = new MiddleMouseButton();
                public static MouseButton Right = new RightMouseButton();
                public static MouseButton XButton1 = new XButton1MouseButton();
                public static MouseButton XButton2 = new XButton2MouseButton();
        }
}