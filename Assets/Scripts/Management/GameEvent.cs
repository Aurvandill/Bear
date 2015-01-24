using UnityEngine;
using System.Collections;


public enum GameEvent : int
{
    //Creatures
    cr_Player_Died = 101,
    cr_Enemy_Killed = 102,
    cr_Bandit_Killed = 103,
    cr_BanditBoss_Killed = 104,
    cr_Witch_Killed = 105,
    cr_Knight_Killed = 106,
    cr_Gollum_Killed = 107,
    cr_Captain_Killed = 108,
    cr_Captain_TalkedTo = 109,
    cr_Princess_TalkedTo = 110,
    cr_Spider_Killed = 111,
    cr_Wizard_Killed = 112,

    //Weapons
    wa_Weapon_Changed = 301,
    wa_Weapon_Equipped = 302,
    wa_Staff_Equipped = 303,
    wa_Bow_Equipped = 304,
    wa_Sword_Equipped = 305,

    //Wearables
    we_Wearable_Changed = 501,
    we_Wearable_Equipped = 502,
    we_WarlockRobe_Equipped = 503,
    we_KnightsArmor_Equipped = 504,

    //Objects
    ob_TheOneRing_Obtained = 701,
    ob_MagicBook_Obtained = 702,
    ob_Alcohol_Obtained = 703,

    //Places
    pl_Place_Changed = 901,
    pl_Cave_Entered = 902,
    pl_Port_Entered = 903,
    pl_Woods_Entered = 904,
    pl_Town_Entered = 905,
    pl_GraveYard_Entered = 906,
    pl_WizardTower_Entered = 907
}
