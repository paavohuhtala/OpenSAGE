﻿using OpenSage.Graphics;
using OpenSage.Gui.Apt;
using OpenSage.Gui.Wnd;

namespace OpenSage
{
    public sealed class Scene2D
    {
        public WndWindowManager WndWindowManager { get; }
        public AptWindowManager AptWindowManager { get; }

        public Scene2D(Game game)
        {
            WndWindowManager = new WndWindowManager(game);
            AptWindowManager = new AptWindowManager(game);
        }

        internal void Update(GameTime gameTime)
        {
            WndWindowManager.Update(gameTime);
            AptWindowManager.Update(gameTime);
        }

        internal void Render(SpriteBatch spriteBatch)
        {
            WndWindowManager.Render(spriteBatch);
            AptWindowManager.Render(spriteBatch);
        }
    }
}
