using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000D8 RID: 216
	public class FantasyFemaleNames : BaseNames
	{
		// Token: 0x06000661 RID: 1633 RVA: 0x000651A7 File Offset: 0x000635A7
		public FantasyFemaleNames()
		{
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x000651AF File Offset: 0x000635AF
		public new static List<string> GetSyllableSet(string key)
		{
			return FantasyFemaleNames.syllableSets[key];
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x000651BC File Offset: 0x000635BC
		public new static List<string> GetRules()
		{
			return FantasyFemaleNames.rules;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x000651C4 File Offset: 0x000635C4
		// Note: this type is marked as 'beforefieldinit'.
		static FantasyFemaleNames()
		{
		}

		// Token: 0x04000969 RID: 2409
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
					"a",
					"ae",
					"aelle",
					"ai",
					"ea",
					"i",
					"ia",
					"u",
					"wen",
					"wyn"
				}
			}
		};

		// Token: 0x0400096A RID: 2410
		private static List<string> rules = new List<string>
		{
			"%100start%100end",
			"%100start%100middle%100end"
		};
	}
}
