using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000DA RID: 218
	public class FantasyMaleNames : BaseNames
	{
		// Token: 0x06000669 RID: 1641 RVA: 0x00065A29 File Offset: 0x00063E29
		public FantasyMaleNames()
		{
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x00065A31 File Offset: 0x00063E31
		public new static List<string> GetSyllableSet(string key)
		{
			return FantasyMaleNames.syllableSets[key];
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x00065A3E File Offset: 0x00063E3E
		public new static List<string> GetRules()
		{
			return FantasyMaleNames.rules;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00065A48 File Offset: 0x00063E48
		// Note: this type is marked as 'beforefieldinit'.
		static FantasyMaleNames()
		{
		}

		// Token: 0x0400096D RID: 2413
		private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>
		{
			{
				"start",
				new List<string>
				{
					"Aer",
					"An",
					"Ar",
					"Ban",
					"Bar",
					"Ber",
					"Beth",
					"Bett",
					"Cut",
					"Dan",
					"Dar",
					"Dell",
					"Der",
					"Edr",
					"Er",
					"Eth",
					"Ett",
					"Fin",
					"Ian",
					"Iarr",
					"Ill",
					"Jed",
					"Kan",
					"Kar",
					"Ker",
					"Kurr",
					"Kyr",
					"Man",
					"Mar",
					"Mer",
					"Mir",
					"Tsal",
					"Tser",
					"Tsir",
					"Van",
					"Var",
					"Yur",
					"Yyr"
				}
			},
			{
				"middle",
				new List<string>
				{
					"al",
					"an",
					"ar",
					"el",
					"en",
					"ess",
					"ian",
					"onn",
					"or"
				}
			},
			{
				"end",
				new List<string>
				{
					"ai",
					"an",
					"ar",
					"ath",
					"en",
					"eo",
					"ian",
					"is",
					"u",
					"or"
				}
			}
		};

		// Token: 0x0400096E RID: 2414
		private static List<string> rules = new List<string>
		{
			"%100start%100end",
			"%100start%100middle%100end"
		};
	}
}
