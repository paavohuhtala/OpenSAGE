﻿using System;
using OpenSage.Data.Ini;

namespace OpenSage.Logic.Object
{
    [Flags]
    public enum WeaponSetConditions
    {
        [IniEnum("None")]
        None = 0,

        [IniEnum("PLAYER_UPGRADE")]
        PlayerUpgrade = 1 << 0,

        [IniEnum("CARBOMB")]
        CarBomb = 1 << 1,

        [IniEnum("MINE_CLEARING_DETAIL")]
        MineClearingDetail = 1 << 2,

        [IniEnum("CRATEUPGRADE_ONE")]
        CrateUpgradeOne = 1 << 3,

        [IniEnum("CRATEUPGRADE_TWO")]
        CrateUpgradeTwo = 1 << 4,

        [IniEnum("WEAPON_RIDER1")]
        WeaponRider1 = 1 << 5,

        [IniEnum("WEAPON_RIDER2")]
        WeaponRider2 = 1 << 6,

        [IniEnum("WEAPON_RIDER3")]
        WeaponRider3 = 1 << 7,

        [IniEnum("WEAPON_RIDER4")]
        WeaponRider4 = 1 << 8,

        [IniEnum("WEAPON_RIDER5")]
        WeaponRider5 = 1 << 9,

        [IniEnum("WEAPON_RIDER6")]
        WeaponRider6 = 1 << 10,

        [IniEnum("WEAPON_RIDER7")]
        WeaponRider7 = 1 << 11,
    }
}
