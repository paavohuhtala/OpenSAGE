﻿using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    [AddedIn(SageGame.BattleForMiddleEarth)]
    public sealed class TemporarilyDefectUpdateModuleData : UpdateModuleData
    {
        internal static TemporarilyDefectUpdateModuleData Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        private static readonly IniParseTable<TemporarilyDefectUpdateModuleData> FieldParseTable = new IniParseTable<TemporarilyDefectUpdateModuleData>
        {
            { "DefectDuration", (parser, x) => x.DefectDuration = parser.ParseInteger() }
        };

        public int DefectDuration { get; private set; }
    }
}
