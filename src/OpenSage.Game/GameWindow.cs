﻿using System;
using OpenSage.Input;
using OpenSage.Mathematics;

namespace OpenSage
{
    public abstract class GameWindow : DisposableBase
    {
        public event EventHandler ClientSizeChanged;

        protected void RaiseClientSizeChanged()
        {
            ClientSizeChanged?.Invoke(this, EventArgs.Empty);
        }

        public abstract Rectangle ClientBounds { get; }

        public event EventHandler<InputMessageEventArgs> InputMessageReceived;

        protected void RaiseInputMessageReceived(InputMessageEventArgs args)
        {
            InputMessageReceived?.Invoke(this, args);
        }

        public abstract bool IsMouseVisible { get; set; }

        // TODO: Remove this once we switch to Veldrid.
        public abstract IntPtr NativeWindowHandle { get; }

        public abstract void SetCursor(Cursor cursor);

        public abstract bool PumpEvents();
    }
}
