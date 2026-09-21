using System;
using System.Collections.Generic;

namespace Lexic
{
	// Token: 0x020000DB RID: 219
	public class FantasyMaleNames2 : BaseNames
	{
		// Token: 0x0600066D RID: 1645 RVA: 0x00065D2C File Offset: 0x0006412C
		public FantasyMaleNames2()
		{
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00065D34 File Offset: 0x00064134
		public new static List<string> GetSyllableSet(string key)
		{
			return FantasyMaleNames2.syllableSets[key];
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x00065D41 File Offset: 0x00064141
		public new static List<string> GetRules()
		{
			return FantasyMaleNames2.rules;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x00065D48 File Offset: 0x00064148
		// Note: this type is marked as 'beforefieldinit'.
		static FantasyMaleNames2()
		{
		}

		// Token: 0x0400096F RID: 2415
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
					"Aer",
					"Al",
					"Am",
					"An",
					"Ar",
					"Arm",
					"Arth",
					"B",
					"Bal",
					"Bar",
					"Be",
					"Bel",
					"Ber",
					"Bok",
					"Bor",
					"Bran",
					"Breg",
					"Bren",
					"Brod",
					"Cam",
					"Chal",
					"Cham",
					"Ch",
					"Cuth",
					"Dag",
					"Daim",
					"Dair",
					"Del",
					"Dr",
					"Dur",
					"Duv",
					"Ear",
					"Elen",
					"Er",
					"Erel",
					"Erem",
					"Fal",
					"Ful",
					"Gal",
					"G",
					"Get",
					"Gil",
					"Gor",
					"Grin",
					"Gun",
					"H",
					"Hal",
					"Han",
					"Har",
					"Hath",
					"Hett",
					"Hur",
					"Iss",
					"Khel",
					"K",
					"Kor",
					"Lel",
					"Lor",
					"M",
					"Mal",
					"Man",
					"Mard",
					"N",
					"Ol",
					"Radh",
					"Rag",
					"Relg",
					"Rh",
					"Run",
					"Sam",
					"Tarr",
					"T",
					"Tor",
					"Tul",
					"Tur",
					"Ul",
					"Ulf",
					"Unr",
					"Ur",
					"Urth",
					"Yar",
					"Z",
					"Zan",
					"Zer"
				}
			},
			{
				"middle",
				new List<string>
				{
					"de",
					"do",
					"dra",
					"du",
					"duna",
					"ga",
					"go",
					"hara",
					"kaltho",
					"la",
					"latha",
					"le",
					"ma",
					"nari",
					"ra",
					"re",
					"rego",
					"ro",
					"rodda",
					"romi",
					"rui",
					"sa",
					"to",
					"ya",
					"zila"
				}
			},
			{
				"end",
				new List<string>
				{
					"bar",
					"bers",
					"blek",
					"chak",
					"chik",
					"dan",
					"dar",
					"das",
					"dig",
					"dil",
					"din",
					"dir",
					"dor",
					"dur",
					"fang",
					"fast",
					"gar",
					"gas",
					"gen",
					"gorn",
					"grim",
					"gund",
					"had",
					"hek",
					"hell",
					"hir",
					"hor",
					"kan",
					"kath",
					"khad",
					"kor",
					"lach",
					"lar",
					"ldil",
					"ldir",
					"leg",
					"len",
					"lin",
					"mas",
					"mnir",
					"ndil",
					"ndur",
					"neg",
					"nik",
					"ntir",
					"rab",
					"rach",
					"rain",
					"rak",
					"ran",
					"rand",
					"rath",
					"rek",
					"rig",
					"rim",
					"rin",
					"rion",
					"sin",
					"sta",
					"stir",
					"sus",
					"tar",
					"thad",
					"thel",
					"tir",
					"von",
					"vor",
					"yon",
					"zor"
				}
			}
		};

		// Token: 0x04000970 RID: 2416
		private static List<string> rules = new List<string>
		{
			"%100start%100vowels%35middle%10middle%100end"
		};
	}
}
