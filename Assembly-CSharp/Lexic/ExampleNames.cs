using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000D7 RID: 215
	public class ExampleNames : BaseNames
	{
		// Token: 0x0600065D RID: 1629 RVA: 0x000650A9 File Offset: 0x000634A9
		public ExampleNames()
		{
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x000650B1 File Offset: 0x000634B1
		public new static List<string> GetSyllableSet(string key)
		{
			return ExampleNames.syllableSets[key];
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x000650BE File Offset: 0x000634BE
		public new static List<string> GetRules()
		{
			return ExampleNames.rules;
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x000650C8 File Offset: 0x000634C8
		// Note: this type is marked as 'beforefieldinit'.
		static ExampleNames()
		{
		}

		// Token: 0x04000967 RID: 2407
		private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>
		{
			{
				"start",
				new List<string>
				{
					"a",
					"ab",
					"abc"
				}
			},
			{
				"middle",
				new List<string>
				{
					"b",
					"bc",
					"bcd"
				}
			},
			{
				"end",
				new List<string>
				{
					"c",
					"cd",
					"cde"
				}
			}
		};

		// Token: 0x04000968 RID: 2408
		private static List<string> rules = new List<string>
		{
			"%100start%100middle%100end",
			"%100start%100end",
			"%100start%50middle%75end"
		};
	}
}
