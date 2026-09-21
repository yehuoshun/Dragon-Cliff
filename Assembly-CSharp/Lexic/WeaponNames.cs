using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000DE RID: 222
	public class WeaponNames : BaseNames
	{
		// Token: 0x06000679 RID: 1657 RVA: 0x0006766F File Offset: 0x00065A6F
		public WeaponNames()
		{
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00067677 File Offset: 0x00065A77
		public new static List<string> GetSyllableSet(string key)
		{
			return WeaponNames.syllableSets[key];
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00067684 File Offset: 0x00065A84
		public new static List<string> GetRules()
		{
			return WeaponNames.rules;
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0006768C File Offset: 0x00065A8C
		// Note: this type is marked as 'beforefieldinit'.
		static WeaponNames()
		{
		}

		// Token: 0x04000975 RID: 2421
		private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>
		{
			{
				"adj",
				new List<string>
				{
					"Flaming_",
					"Burning_",
					"Electric_",
					"Freezing_",
					"Ice_",
					"Dark_",
					"Healing_",
					"Light_",
					"Heavy_",
					"Poisoned_",
					"Toxic_",
					"Druid's_",
					"Priest's_",
					"Warrior's_",
					"Archer's_",
					"Wizard's_",
					"Dragon_",
					"Occult_",
					"Divine_",
					"Enchanted_",
					"Magic_",
					"Barbarian_",
					"Gladiator_",
					"Unholy_",
					"Holy_",
					"Cursed_",
					"Blessed_",
					"Silver_",
					"Iron_",
					"Steel_",
					"Golden_",
					"Bronze_",
					"Skeletal_",
					"Bone_",
					"Soul_",
					"Masterwork_",
					"Frost_",
					"Storm_",
					"Thunder_",
					"Fierce_",
					"Lucky_"
				}
			},
			{
				"items",
				new List<string>
				{
					"Axe_",
					"Sword_",
					"Bow_",
					"Polearm_",
					"Spear_",
					"Greataxe_",
					"Dagger_",
					"Shortsword_",
					"Broadsword_",
					"Shield_",
					"Greatshield_",
					"Zweihander_",
					"Claymore_",
					"Crossbow_",
					"Blade_",
					"Mace_",
					"Hammer_",
					"Lucerne_",
					"Katana_",
					"Hatchet_",
					"Scythe_",
					"Bludgeon_",
					"Morningstar_",
					"Flail_",
					"Spellblade_",
					"Knife_",
					"Reaver_",
					"Swiftblade_",
					"Saber_",
					"Rapier_",
					"Longsword_",
					"Maul_",
					"War_Axe_",
					"Warhammer_",
					"Mallet_",
					"Cleaver_",
					"Shiv_",
					"Dirk_",
					"Stiletto_",
					"Halberd_",
					"Spike_",
					"Trident_",
					"Lance_",
					"Javelin_"
				}
			},
			{
				"mods",
				new List<string>
				{
					"+1",
					"+2",
					"+3",
					"+4",
					"+5",
					"of_Slaying",
					"of Burning",
					"of_Freezing",
					"of_Poisoning",
					"of_Dragon",
					"of_Magic",
					"of_Killing",
					"of_Flaying",
					"of_Crushing",
					"of_Destruction",
					"of_Healing",
					"of_Repairing",
					"of_Indigestion",
					"of_Flying",
					"of_Striking",
					"of_Punishment",
					"of_Lightning",
					"of_Thunder",
					"of_Venom",
					"of_Pain",
					"of_Acid",
					"of_Poison",
					"of_Dreams",
					"of_Nightmares",
					"of_Stars",
					"of_the_Kings",
					"of_Legend",
					"of_Death",
					"of_Life",
					"of_Luck",
					"of_the_Night",
					"of_Darkness"
				}
			}
		};

		// Token: 0x04000976 RID: 2422
		private static List<string> rules = new List<string>
		{
			"%100items",
			"%75adj%100items%75mods",
			"%33adj%100items%100mods",
			"%100adj%100items%33mods"
		};
	}
}
