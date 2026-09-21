using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000DC RID: 220
	public class KingNames : BaseNames
	{
		// Token: 0x06000671 RID: 1649 RVA: 0x00066725 File Offset: 0x00064B25
		public KingNames()
		{
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0006672D File Offset: 0x00064B2D
		public new static List<string> GetSyllableSet(string key)
		{
			return KingNames.syllableSets[key];
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0006673A File Offset: 0x00064B3A
		public new static List<string> GetRules()
		{
			return KingNames.rules;
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00066744 File Offset: 0x00064B44
		// Note: this type is marked as 'beforefieldinit'.
		static KingNames()
		{
		}

		// Token: 0x04000971 RID: 2417
		private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>
		{
			{
				"firstnames",
				new List<string>
				{
					"Alexander_",
					"Augustus_",
					"Casimir_",
					"Henry_",
					"John_",
					"Louis_",
					"Sigismund_",
					"Stanislaw_",
					"Stephen_",
					"Wenceslaus_",
					"Edward_",
					"Alfred_",
					"Charles_",
					"Edgar_",
					"Harold_",
					"William_",
					"Richard_",
					"Philip_",
					"James_",
					"Dagobert_",
					"Theuderic_",
					"Robert_",
					"Rudolf_",
					"Lothar_",
					"Hugo_",
					"Francis_",
					"Edmund_",
					"Ragnvald_",
					"Magnus_",
					"Albert_",
					"Sigmund_",
					"Gustav_",
					"Frederick_",
					"Oscar_",
					"Lech_",
					"Boleslaw_"
				}
			},
			{
				"numbers",
				new List<string>
				{
					"I_",
					"II_",
					"III_",
					"IV_",
					"V_",
					"VI_",
					"VII_",
					"VIII_",
					"IX_",
					"X_",
					"XI_",
					"XII_",
					"XIII_",
					"XIV_",
					"XV_",
					"XVI_"
				}
			},
			{
				"titles",
				new List<string>
				{
					"Bathory",
					"Herman",
					"Jogaila",
					"Lambert",
					"of_Bohemia",
					"of_France",
					"of_Hungary",
					"of_Masovia",
					"of_Poland",
					"of_Valois",
					"of_Varna",
					"Probus",
					"Spindleshanks",
					"Tanglefoot",
					"the_Bearded",
					"the_Black",
					"the_Bold",
					"the_Brave",
					"the_Chaste",
					"the_Curly",
					"the_Elbow-high",
					"the_Exile",
					"the_Great",
					"the_Jagiellonian",
					"the_Just",
					"the_Old",
					"the_Pious",
					"the_Restorer",
					"the_Saxon",
					"the_Strong",
					"the_Wheelwright",
					"the_White",
					"Vasa",
					"Wrymouth",
					"the_Elder",
					"the_Peaceful",
					"the_Martyr",
					"the_Unready",
					"Forkbeard",
					"Ironside",
					"Harefoot",
					"the_Confessor",
					"the_Young",
					"the_Victorious",
					"the_Old",
					"the_Red",
					"the_Younger",
					"the_Lame",
					"Barnlock",
					"of_Sweden",
					"of_Lithuania",
					"the_Tyrant",
					"Bourbon",
					"Savoy",
					"Habsburg"
				}
			}
		};

		// Token: 0x04000972 RID: 2418
		private static List<string> rules = new List<string>
		{
			"%100firstnames%100numbers",
			"%100firstnames%50numbers%100titles",
			"%100firstnames%100titles"
		};
	}
}
