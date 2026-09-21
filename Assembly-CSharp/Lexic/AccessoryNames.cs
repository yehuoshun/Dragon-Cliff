using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000D0 RID: 208
	public class AccessoryNames : BaseNames
	{
		// Token: 0x06000642 RID: 1602 RVA: 0x00062A48 File Offset: 0x00060E48
		public AccessoryNames()
		{
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00062A50 File Offset: 0x00060E50
		public new static List<string> GetSyllableSet(string key)
		{
			return AccessoryNames.syllableSets[key];
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x00062A5D File Offset: 0x00060E5D
		public new static List<string> GetRules()
		{
			return AccessoryNames.rules;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00062A64 File Offset: 0x00060E64
		// Note: this type is marked as 'beforefieldinit'.
		static AccessoryNames()
		{
		}

		// Token: 0x0400095B RID: 2395
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
					"Belt_",
					"Girdle_",
					"Band_",
					"Waistband_",
					"Ring_",
					"Crown_",
					"Tiara_",
					"Talisman_",
					"Amulet_",
					"Pendant_",
					"Bracelet_",
					"Bangle_",
					"Wristband_",
					"Gloves_",
					"Armlet_",
					"Buckle_",
					"Orb_",
					"Medallion_",
					"Anklet_",
					"Brooch_",
					"Earrings_",
					"Scarf_",
					"Gem_",
					"Necklace_",
					"Beads_",
					"Locket_",
					"Emblem_"
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

		// Token: 0x0400095C RID: 2396
		private static List<string> rules = new List<string>
		{
			"%100items",
			"%75adj%100items%75mods",
			"%33adj%100items%100mods",
			"%100adj%100items%33mods"
		};
	}
}
