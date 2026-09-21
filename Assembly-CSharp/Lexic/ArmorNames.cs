using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000D1 RID: 209
	public class ArmorNames : BaseNames
	{
		// Token: 0x06000646 RID: 1606 RVA: 0x00062F6E File Offset: 0x0006136E
		public ArmorNames()
		{
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x00062F76 File Offset: 0x00061376
		public new static List<string> GetSyllableSet(string key)
		{
			return ArmorNames.syllableSets[key];
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00062F83 File Offset: 0x00061383
		public new static List<string> GetRules()
		{
			return ArmorNames.rules;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00062F8C File Offset: 0x0006138C
		// Note: this type is marked as 'beforefieldinit'.
		static ArmorNames()
		{
		}

		// Token: 0x0400095D RID: 2397
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
					"Chestplate_",
					"Bevor_",
					"Chainmail_",
					"Gambeson_",
					"Gousset_",
					"Greaves_",
					"Chausses_",
					"Hauberk_",
					"Lamellar_Armor_",
					"Laminar_Armor_",
					"Plackart_",
					"Breastplate_",
					"Platemail_",
					"Plate_Armor_",
					"Ring_Armor_",
					"Sabaton_",
					"Scale_Armor",
					"Pauldrons_",
					"Vambrace_",
					"Leather_Armor_",
					"Chestguard_",
					"Chestpiece_",
					"Cuirass_",
					"Helmet_",
					"Headguard_",
					"Faceguard_",
					"Mask_",
					"Leggings_",
					"Legguards_",
					"Platelegs_",
					"Mantle_",
					"Shoulderguards_",
					"Warboots_"
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

		// Token: 0x0400095E RID: 2398
		private static List<string> rules = new List<string>
		{
			"%100items",
			"%75adj%100items%75mods",
			"%33adj%100items%100mods",
			"%100adj%100items%33mods"
		};
	}
}
