﻿using System.Numerics;
using OpenSage.Data.Map;

namespace OpenSage.Terrain.Util
{
    internal static class ConversionExtensions
    {
        public static Vector3 ToVector3(this MapVector3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static Vector2 ToVector2(this MapTexCoord value)
        {
            return new Vector2(value.U, value.V);
        }
    }
}