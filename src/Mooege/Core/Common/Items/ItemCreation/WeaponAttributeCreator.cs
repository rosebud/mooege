/*
 * Copyright (C) 2011 mooege project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using Mooege.Common.Helpers;
using Mooege.Net.GS.Message.Fields;
using Mooege.Net.GS.Message;

namespace Mooege.Core.Common.Items.ItemCreation
{
    class WeaponAttributeCreator : IItemAttributeCreator
    {
        public void CreateAttributes(Item item)
        {
            item.Attributes[GameAttribute.Skill, 0x7780] = 1;
            item.Attributes[GameAttribute.IdentifyCost] = 1;
       
            const float heroAttackspeed = 1f; // musst be calculated by Skills + passives + affixes  + ...
            const float heroMaxDmg = 0f; // musst be calculated by Skills + passives + affixes  + ...
            const float heroMinDmg = 0f; // musst be calculated by Skills + passives + affixes  + ...
            const float offhandMultiplier = 0.8f;

            var weaponDmg = RandomHelper.Next(5) + 5;
            var attackspeed = 1f;
            var minWeaponDmg = weaponDmg - RandomHelper.Next(5) + 1;

            item.Attributes[GameAttribute.Attacks_Per_Second_Total] = attackspeed * heroAttackspeed;
            item.Attributes[GameAttribute.Attacks_Per_Second_Item] = attackspeed;
            item.Attributes[GameAttribute.Attacks_Per_Second_Item_Subtotal] = attackspeed;
            item.Attributes[GameAttribute.Attacks_Per_Second_Item_Total] = attackspeed;
            item.Attributes[GameAttribute.Attacks_Per_Second_Item_MainHand] = attackspeed;
            item.Attributes[GameAttribute.Attacks_Per_Second_Item_OffHand] = attackspeed + 1;
            item.Attributes[GameAttribute.Attacks_Per_Second_Item_Total_MainHand] = attackspeed;
            item.Attributes[GameAttribute.Attacks_Per_Second_Item_Total_OffHand] = attackspeed + 1;

            item.Attributes[GameAttribute.Damage_Weapon_Min, 0] = minWeaponDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Min_Total, 0] = minWeaponDmg + heroMinDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Min_Total, 0xFFFFF] = minWeaponDmg + heroMinDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Min_Total_All] = minWeaponDmg + heroMinDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Min_Total_MainHand, 0] = minWeaponDmg + heroMinDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Min_Total_MainHand, 0xFFFFF] = minWeaponDmg + heroMinDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Min_Total_OffHand, 0] = (minWeaponDmg + heroMinDmg) * offhandMultiplier;
            item.Attributes[GameAttribute.Damage_Weapon_Min_Total_OffHand, 0xFFFFF] = (minWeaponDmg + heroMinDmg) * offhandMultiplier;

            item.Attributes[GameAttribute.Damage_Weapon_Max, 0] = weaponDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Max, 0xFFFFF] = weaponDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Max_Total, 0] = weaponDmg + heroMaxDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Max_Total, 0xFFFFF] = weaponDmg + heroMaxDmg;
            
            item.Attributes[GameAttribute.Damage_Weapon_Delta, 0] = weaponDmg - minWeaponDmg;
            item.Attributes[GameAttribute.Damage_Weapon_Delta_SubTotal, 0] = (weaponDmg + heroMaxDmg) - (minWeaponDmg + heroMinDmg);
            item.Attributes[GameAttribute.Damage_Weapon_Delta_Total, 0] = (weaponDmg + heroMaxDmg) - (minWeaponDmg + heroMinDmg);
            item.Attributes[GameAttribute.Damage_Weapon_Delta_Total_All] = (weaponDmg + heroMaxDmg) - (minWeaponDmg + heroMinDmg);
            item.Attributes[GameAttribute.Damage_Weapon_Delta_Total_MainHand, 0] = (weaponDmg + heroMaxDmg) - (minWeaponDmg + heroMinDmg);
            item.Attributes[GameAttribute.Damage_Weapon_Delta_Total_OffHand, 0] = 3.051758E-05f;

            bool equipped = false; // (item.InvLoc.x + item.InvLoc.y == 0) ? 0 : 1;

            item.Attributes[GameAttribute.Item_Equipped] = equipped;

            item.Attributes[GameAttribute.Durability_Max] = 400;
            item.Attributes[GameAttribute.Durability_Cur] = 400;
        }
    }
}
