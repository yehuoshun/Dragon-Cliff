using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000DD RID: 221
	public class TownNames : BaseNames
	{
		// Token: 0x06000675 RID: 1653 RVA: 0x00066C59 File Offset: 0x00065059
		public TownNames()
		{
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x00066C61 File Offset: 0x00065061
		public new static List<string> GetSyllableSet(string key)
		{
			return TownNames.syllableSets[key];
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00066C6E File Offset: 0x0006506E
		public new static List<string> GetRules()
		{
			return TownNames.rules;
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00066C78 File Offset: 0x00065078
		// Note: this type is marked as 'beforefieldinit'.
		static TownNames()
		{
		}

		// Token: 0x04000973 RID: 2419
		private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>
		{
			{
				"pre",
				new List<string>
				{
					"East_",
					"Fort_",
					"Great_",
					"High_",
					"Lower_",
					"Middle_",
					"Mount_",
					"New_",
					"North_",
					"Old_",
					"Royal_",
					"Saint_",
					"South_",
					"Upper_",
					"West"
				}
			},
			{
				"start",
				new List<string>
				{
					"Ales",
					"Apple",
					"Ash",
					"Bald",
					"Bay",
					"Bed",
					"Bell",
					"Birdling",
					"Black",
					"Blue",
					"Bow",
					"Bran",
					"Brass",
					"Bright",
					"Brown",
					"Bruns",
					"Bulls",
					"Camp",
					"Cherry",
					"Clark",
					"Clarks",
					"Clay",
					"Clear",
					"Copper",
					"Corn",
					"Cross",
					"Crystal",
					"Dark",
					"Deep",
					"Deer",
					"Drac",
					"Eagle",
					"Earth",
					"Elk",
					"Elles",
					"Elm",
					"Ester",
					"Ewes",
					"Fair",
					"Falcon",
					"Ferry",
					"Fire",
					"Fleet",
					"Fox",
					"Gold",
					"Grand",
					"Green",
					"Grey",
					"Guild",
					"Hammer",
					"Hart",
					"Hawks",
					"Hay",
					"Haze",
					"Hazel",
					"Hemlock",
					"Ice",
					"Iron",
					"Kent",
					"Kings",
					"Knox",
					"Layne",
					"Lint",
					"Lor",
					"Mable",
					"Maple",
					"Marble",
					"Mare",
					"Marsh",
					"Mist",
					"Mor",
					"Mud",
					"Nor",
					"Oak",
					"Orms",
					"Ox",
					"Oxen",
					"Pear",
					"Pine",
					"Pitts",
					"Port",
					"Purple",
					"Red",
					"Rich",
					"Roch",
					"Rock",
					"Rose",
					"Ross",
					"Rye",
					"Salis",
					"Salt",
					"Shadow",
					"Silver",
					"Skeg",
					"Smith",
					"Snow",
					"Sows",
					"Spring",
					"Spruce",
					"Staff",
					"Star",
					"Steel",
					"Still",
					"Stock",
					"Stone",
					"Strong",
					"Summer",
					"Swan",
					"Swine",
					"Sword",
					"Yellow",
					"Val",
					"Wart",
					"Water",
					"Well",
					"Wheat",
					"White",
					"Wild",
					"Winter",
					"Wolf",
					"Wool",
					"Wor"
				}
			},
			{
				"end",
				new List<string>
				{
					"bank",
					"borne",
					"borough",
					"brook",
					"burg",
					"burgh",
					"bury",
					"castle",
					"cester",
					"cliff",
					"crest",
					"croft",
					"dale",
					"dam",
					"dorf",
					"edge",
					"field",
					"ford",
					"gate",
					"grad",
					"hall",
					"ham",
					"hollow",
					"holm",
					"hurst",
					"keep",
					"kirk",
					"land",
					"ley",
					"lyn",
					"mere",
					"mill",
					"minster",
					"mont",
					"moor",
					"mouth",
					"ness",
					"pool",
					"river",
					"shire",
					"shore",
					"side",
					"stead",
					"stoke",
					"ston",
					"thorpe",
					"ton",
					"town",
					"vale",
					"ville",
					"way",
					"wich",
					"wick",
					"wood",
					"worth"
				}
			},
			{
				"post",
				new List<string>
				{
					"_Annex",
					"_Barrens",
					"_Barrow",
					"_Corner",
					"_Cove",
					"_Crossing",
					"_Dell",
					"_Dales",
					"_Estates",
					"_Forest",
					"_Furnace",
					"_Grove",
					"_Haven",
					"_Heath",
					"_Hill",
					"_Junction",
					"_Landing",
					"_Meadow",
					"_Park",
					"_Plain",
					"_Point",
					"_Reserve",
					"_Retreat",
					"_Ridge",
					"_Springs",
					"_View",
					"_Village",
					"_Wells",
					"_Woods"
				}
			}
		};

		// Token: 0x04000974 RID: 2420
		private static List<string> rules = new List<string>
		{
			"%15pre%100start%100end%15post"
		};
	}
}
