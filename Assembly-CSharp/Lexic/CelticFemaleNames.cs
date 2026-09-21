using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000D3 RID: 211
	public class CelticFemaleNames : BaseNames
	{
		// Token: 0x0600064D RID: 1613 RVA: 0x000634D8 File Offset: 0x000618D8
		public CelticFemaleNames()
		{
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x000634E0 File Offset: 0x000618E0
		public new static List<string> GetSyllableSet(string key)
		{
			return CelticFemaleNames.syllableSets[key];
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x000634ED File Offset: 0x000618ED
		public new static List<string> GetRules()
		{
			return CelticFemaleNames.rules;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x000634F4 File Offset: 0x000618F4
		// Note: this type is marked as 'beforefieldinit'.
		static CelticFemaleNames()
		{
		}

		// Token: 0x0400095F RID: 2399
		private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>
		{
			{
				"start",
				new List<string>
				{
					"Aen",
					"Agno",
					"All",
					"Ba",
					"Beo",
					"Brig",
					"Ci",
					"Cre",
					"Dan",
					"Del",
					"Ela",
					"Eo",
					"En",
					"Er",
					"Et",
					"In",
					"Io",
					"Morr",
					"Nem",
					"Nu",
					"Og",
					"Or",
					"Ta"
				}
			},
			{
				"middle",
				new List<string>
				{
					"a",
					"ar",
					"ba",
					"bo",
					"ch",
					"d",
					"ig"
				}
			},
			{
				"end",
				new List<string>
				{
					"ai",
					"an",
					"da",
					"id",
					"iu",
					"ma",
					"me",
					"na",
					"ne",
					"tha"
				}
			}
		};

		// Token: 0x04000960 RID: 2400
		private static List<string> rules = new List<string>
		{
			"%100start%100end",
			"%100start%100middle%100end"
		};
	}
}
