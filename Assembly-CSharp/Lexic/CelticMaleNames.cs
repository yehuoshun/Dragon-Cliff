using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000D4 RID: 212
	public class CelticMaleNames : BaseNames
	{
		// Token: 0x06000651 RID: 1617 RVA: 0x0006371D File Offset: 0x00061B1D
		public CelticMaleNames()
		{
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x00063725 File Offset: 0x00061B25
		public new static List<string> GetSyllableSet(string key)
		{
			return CelticMaleNames.syllableSets[key];
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x00063732 File Offset: 0x00061B32
		public new static List<string> GetRules()
		{
			return CelticMaleNames.rules;
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0006373C File Offset: 0x00061B3C
		// Note: this type is marked as 'beforefieldinit'.
		static CelticMaleNames()
		{
		}

		// Token: 0x04000961 RID: 2401
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
					"aid",
					"ain",
					"an",
					"and",
					"th",
					"ed",
					"eth",
					"gus",
					"lam",
					"lor",
					"man",
					"od",
					"t",
					"thach"
				}
			}
		};

		// Token: 0x04000962 RID: 2402
		private static List<string> rules = new List<string>
		{
			"%100start%100end",
			"%100start%100middle%100end"
		};
	}
}
