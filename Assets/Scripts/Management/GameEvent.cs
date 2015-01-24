using UnityEngine;
using System.Collections;


public enum GameEvent
{
    //Creatures
    cr_PlayerDied,
    cr_EnemyKilled,
    cr_BanditKilled,
    cr_BanditBossKilled,
    cr_WitchKilled,
    cr_KnightKilled,
    cr_GollumKilled,
    cr_CaptainKilled,
    cr_CaptainTalkedTo,
    cr_PrincessTalkedTo,

    //Weapons
    wa_WeaponChanged,
    wa_WeaponObtained,
    wa_StaffObtained,
    wa_BowObtained,
    wa_SwordObtained,

    //Wearables
    we_WearableChanged,
    we_WearableObtained,
    we_WarlockRobeObtained,
    we_KnightsArmorObtained,

    //Objects
    ob_TheOneRingObtained,
    ob_MagicBookObtained,
    ob_AlcoholObtained,

    //Places
    pl_PlaceChanged,
    pl_CaveEnter,
    pl_PortEnter,
    pl_WoodsEnter,
    pl_TownEnter,
    pl_GraveYardEnter
}
