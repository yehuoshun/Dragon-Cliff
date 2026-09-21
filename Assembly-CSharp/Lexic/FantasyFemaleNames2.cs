using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000D9 RID: 217
	public class FantasyFemaleNames2 : BaseNames
	{
		// Token: 0x06000665 RID: 1637 RVA: 0x000654A8 File Offset: 0x000638A8
		public FantasyFemaleNames2()
		{
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x000654B0 File Offset: 0x000638B0
		public new static List<string> GetSyllableSet(string key)
		{
			return FantasyFemaleNames2.syllableSets[key];
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x000654BD File Offset: 0x000638BD
		public new static List<string> GetRules()
		{
			return FantasyFemaleNames2.rules;
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000654C4 File Offset: 0x000638C4
		// Note: this type is marked as 'beforefieldinit'.
		static FantasyFemaleNames2()
		{
		}

		// Token: 0x0400096B RID: 2411
		private static Dictionary<string, List<string>> syllableSets = new Dictionary<string, List<string>>
		{
			{
				"vowels",
				new List<string>
				{
					"a",
					"e",
					"i",
					"o",
					"u",
					"y"
				}
			},
			{
				"consonants",
				new List<string>
				{
					"b",
					"c",
					"ch",
					"ck",
					"cz",
					"d",
					"dh",
					"f",
					"g",
					"gh",
					"h",
					"j",
					"k",
					"kh",
					"l",
					"m",
					"n",
					"p",
					"ph",
					"q",
					"r",
					"rh",
					"s",
					"sh",
					"t",
					"th",
					"ts",
					"tz",
					"v",
					"w",
					"x",
					"z",
					"zh"
				}
			},
			{
				"start",
				new List<string>
				{
					"Ad",
					"Aer",
					"Ar",
					"Bel",
					"Bet",
					"Beth",
					"Ce'N",
					"Cyr",
					"Eilin",
					"El",
					"Em",
					"Emel",
					"G",
					"Gl",
					"Glor",
					"Is",
					"Isl",
					"Iv",
					"Lay",
					"Lis",
					"May",
					"Ner",
					"Pol",
					"Por",
					"Sal",
					"Sil",
					"Vel",
					"Vor",
					"X",
					"Xan",
					"Xer",
					"Yv",
					"Zub"
				}
			},
			{
				"middle",
				new List<string>
				{
					"bre",
					"da",
					"dhe",
					"ga",
					"lda",
					"le",
					"lra",
					"mi",
					"ra",
					"ri",
					"ria",
					"re",
					"se",
					"ya"
				}
			},
			{
				"end",
				new List<string>
				{
					"ba",
					"beth",
					"da",
					"kira",
					"laith",
					"lle",
					"ma",
					"mina",
					"mira",
					"na",
					"nn",
					"nne",
					"nor",
					"ra",
					"rin",
					"ssra",
					"ta",
					"th",
					"tha",
					"thra",
					"tira",
					"tta",
					"vea",
					"vena",
					"we",
					"wen",
					"wyn"
				}
			}
		};

		// Token: 0x0400096C RID: 2412
		private static List<string> rules = new List<string>
		{
			"%100start%100vowels%35middle%10middle%100end"
		};
	}
}
