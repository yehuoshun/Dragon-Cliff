using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020001BF RID: 447
public class HeroManagementController : MonoBehaviour
{
	// Token: 0x06000BA3 RID: 2979 RVA: 0x0007F381 File Offset: 0x0007D781
	public HeroManagementController()
	{
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x06000BA4 RID: 2980 RVA: 0x0007F389 File Offset: 0x0007D789
	// (set) Token: 0x06000BA5 RID: 2981 RVA: 0x0007F391 File Offset: 0x0007D791
	public PageHero SelectedHero
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedHero>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedHero>k__BackingField = value;
		}
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0007F39A File Offset: 0x0007D79A
	public virtual void Init()
	{
		this.UpdateHeroList(GameWorld.instance.PlayerProfile.AdventurerProfiles);
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0007F3B1 File Offset: 0x0007D7B1
	public virtual void UpdateHeroList(List<AdventurerProfile> adventurers)
	{
		this.HeroPage.UpdateItems((from a in adventurers
		select new PageHero
		{
			Id = a.Id,
			AdventurerProfile = a
		}).Cast<PageElement>().ToList<PageElement>());
		this.DeselectHero();
	}

	// Token: 0x06000BA8 RID: 2984 RVA: 0x0007F3F4 File Offset: 0x0007D7F4
	protected List<AdventurerProfile> OrderHeroList(List<AdventurerProfile> heros)
	{
		switch (GameWorld.instance.PlayerProfile.AdventurerOrderType)
		{
		case AdventurerOrderType.OrderByLevel:
			heros = (from h in heros
			orderby h.GetLevel() descending, h.IsStar() descending, h.Grade descending
			select h).ToList<AdventurerProfile>();
			break;
		case AdventurerOrderType.OrderByGrade:
			heros = (from h in heros
			orderby h.IsStar() descending, h.Grade descending, h.GetLevel() descending
			select h).ToList<AdventurerProfile>();
			break;
		case AdventurerOrderType.ChosenAdventurersFirst:
		{
			heros = (from h in heros
			orderby h.GetLevel() descending, h.IsStar() descending, h.Grade descending
			select h).ToList<AdventurerProfile>();
			List<AdventurerProfile> list = new List<AdventurerProfile>();
			foreach (BattleTeam battleTeam in GameWorld.instance.PlayerProfile.GetBattleTeams())
			{
				list.AddRange(battleTeam.Adventurers);
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				int num = heros.IndexOf(list[i]);
				if (num >= 0)
				{
					heros.MoveItemAtIndexToFront(heros.IndexOf(list[i]));
				}
			}
			break;
		}
		case AdventurerOrderType.OrderByAdventurerType:
			heros = (from h in heros
			orderby h.UnitClass, h.GetLevel() descending, h.IsStar() descending, h.Grade descending
			select h).ToList<AdventurerProfile>();
			break;
		case AdventurerOrderType.OrderByClass:
			heros = (from h in heros
			orderby h.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory() == ClassCategory.CasterSupport || h.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory() == ClassCategory.MeleeSupport, h.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory(), h.UnitClass, h.GetLevel() descending, h.IsStar() descending, h.Grade descending
			select h).ToList<AdventurerProfile>();
			break;
		case AdventurerOrderType.OrderByIsEquiped:
			heros = (from h in heros
			orderby h.GetEquipments().Count descending, h.GetLevel() descending, h.IsStar() descending, h.Grade descending
			select h).ToList<AdventurerProfile>();
			break;
		case AdventurerOrderType.OrderByRating:
			heros = (from h in heros
			orderby h.GetRating() descending, h.GetLevel() descending, h.IsStar() descending, h.Grade descending
			select h).ToList<AdventurerProfile>();
			break;
		case AdventurerOrderType.OrderByIntelligenct:
			heros = (from h in heros
			orderby h.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Gear) descending, h.GetLevel() descending, h.IsStar() descending, h.Grade descending
			select h).ToList<AdventurerProfile>();
			break;
		case AdventurerOrderType.OrderByStrength:
			heros = (from h in heros
			orderby h.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Gear) descending, h.GetLevel() descending, h.IsStar() descending, h.Grade descending
			select h).ToList<AdventurerProfile>();
			break;
		}
		return heros;
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x0007FA08 File Offset: 0x0007DE08
	public virtual void SelectHero(PageHero hero)
	{
		this.SelectedHero = hero;
		this.HeroPage.SelectElement(this.SelectedHero);
		if (this.HeroInfo != null)
		{
			this.HeroInfo.UpdateInfo(hero.AdventurerProfile, null);
		}
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x0007FA45 File Offset: 0x0007DE45
	public void UpdateCurrentHeroInfo()
	{
		if (this.SelectedHero != null)
		{
			this.HeroInfo.UpdateInfo(this.SelectedHero.AdventurerProfile, null);
		}
	}

	// Token: 0x06000BAB RID: 2987 RVA: 0x0007FA69 File Offset: 0x0007DE69
	public void UpdateLevelUpedHeroInfo(ALUTextItem item)
	{
		this.HeroInfo.UpdateInfo(item.Adventurer, item);
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x0007FA80 File Offset: 0x0007DE80
	public void UpdateHeroInfoWithNewEquipment(Item equipment)
	{
		List<LevelUpChangeValue> list = new List<LevelUpChangeValue>();
		AdventurerProfile adventurerProfile = this.SelectedHero.AdventurerProfile;
		using (List<AttributeModifier>.Enumerator enumerator = equipment.AdditionalAttributeModifiers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				AttributeModifier modifier = enumerator.Current;
				AttributeModifier attributeModifier = adventurerProfile.Attributes.FirstOrDefault((AttributeModifier a) => a.AttributeModifierType == modifier.AttributeModifierType);
				if (attributeModifier != null)
				{
					list.Add(new LevelUpChangeValue
					{
						AttributeType = modifier.AttributeType,
						Value = (modifier.Value - attributeModifier.Value).RoundDouble(0)
					});
				}
				else
				{
					list.Add(new LevelUpChangeValue
					{
						AttributeType = modifier.AttributeType,
						Value = modifier.Value.RoundDouble(0)
					});
				}
			}
		}
		this.UpdateLevelUpedHeroInfo(new ALUTextItem
		{
			Adventurer = this.SelectedHero.AdventurerProfile,
			Change = new UnitLevelUpChange
			{
				ChangedValues = list
			}
		});
	}

	// Token: 0x06000BAD RID: 2989 RVA: 0x0007FBCC File Offset: 0x0007DFCC
	public void DeselectHero()
	{
		this.SelectedHero = null;
		this.HeroPage.DiselectAllElement();
		if (this.HeroInfo != null)
		{
			this.HeroInfo.InactivateInfoPanel();
		}
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x0007FBFC File Offset: 0x0007DFFC
	[CompilerGenerated]
	private static PageHero <UpdateHeroList>m__0(AdventurerProfile a)
	{
		return new PageHero
		{
			Id = a.Id,
			AdventurerProfile = a
		};
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x0007FC23 File Offset: 0x0007E023
	[CompilerGenerated]
	private static int <OrderHeroList>m__1(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x0007FC2B File Offset: 0x0007E02B
	[CompilerGenerated]
	private static bool <OrderHeroList>m__2(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x0007FC33 File Offset: 0x0007E033
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__3(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x0007FC3B File Offset: 0x0007E03B
	[CompilerGenerated]
	private static bool <OrderHeroList>m__4(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x0007FC43 File Offset: 0x0007E043
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__5(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x06000BB4 RID: 2996 RVA: 0x0007FC4B File Offset: 0x0007E04B
	[CompilerGenerated]
	private static int <OrderHeroList>m__6(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0007FC53 File Offset: 0x0007E053
	[CompilerGenerated]
	private static int <OrderHeroList>m__7(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0007FC5B File Offset: 0x0007E05B
	[CompilerGenerated]
	private static bool <OrderHeroList>m__8(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x0007FC63 File Offset: 0x0007E063
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__9(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x0007FC6B File Offset: 0x0007E06B
	[CompilerGenerated]
	private static int <OrderHeroList>m__A(AdventurerProfile h)
	{
		return h.GetEquipments().Count;
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0007FC78 File Offset: 0x0007E078
	[CompilerGenerated]
	private static int <OrderHeroList>m__B(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x0007FC80 File Offset: 0x0007E080
	[CompilerGenerated]
	private static bool <OrderHeroList>m__C(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x0007FC88 File Offset: 0x0007E088
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__D(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x0007FC90 File Offset: 0x0007E090
	[CompilerGenerated]
	private static double <OrderHeroList>m__E(AdventurerProfile h)
	{
		return h.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Gear);
	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x0007FC9A File Offset: 0x0007E09A
	[CompilerGenerated]
	private static int <OrderHeroList>m__F(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x0007FCA2 File Offset: 0x0007E0A2
	[CompilerGenerated]
	private static bool <OrderHeroList>m__10(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0007FCAA File Offset: 0x0007E0AA
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__11(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x0007FCB2 File Offset: 0x0007E0B2
	[CompilerGenerated]
	private static double <OrderHeroList>m__12(AdventurerProfile h)
	{
		return h.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Gear);
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x0007FCBC File Offset: 0x0007E0BC
	[CompilerGenerated]
	private static int <OrderHeroList>m__13(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x0007FCC4 File Offset: 0x0007E0C4
	[CompilerGenerated]
	private static bool <OrderHeroList>m__14(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BC3 RID: 3011 RVA: 0x0007FCCC File Offset: 0x0007E0CC
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__15(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x06000BC4 RID: 3012 RVA: 0x0007FCD4 File Offset: 0x0007E0D4
	[CompilerGenerated]
	private static UnitClass <OrderHeroList>m__16(AdventurerProfile h)
	{
		return h.UnitClass;
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0007FCDC File Offset: 0x0007E0DC
	[CompilerGenerated]
	private static int <OrderHeroList>m__17(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x0007FCE4 File Offset: 0x0007E0E4
	[CompilerGenerated]
	private static bool <OrderHeroList>m__18(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x0007FCEC File Offset: 0x0007E0EC
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__19(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x0007FCF4 File Offset: 0x0007E0F4
	[CompilerGenerated]
	private static bool <OrderHeroList>m__1A(AdventurerProfile h)
	{
		return h.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory() == ClassCategory.CasterSupport || h.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory() == ClassCategory.MeleeSupport;
	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x0007FD2C File Offset: 0x0007E12C
	[CompilerGenerated]
	private static ClassCategory <OrderHeroList>m__1B(AdventurerProfile h)
	{
		return h.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory();
	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x0007FD43 File Offset: 0x0007E143
	[CompilerGenerated]
	private static UnitClass <OrderHeroList>m__1C(AdventurerProfile h)
	{
		return h.UnitClass;
	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x0007FD4B File Offset: 0x0007E14B
	[CompilerGenerated]
	private static int <OrderHeroList>m__1D(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BCC RID: 3020 RVA: 0x0007FD53 File Offset: 0x0007E153
	[CompilerGenerated]
	private static bool <OrderHeroList>m__1E(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BCD RID: 3021 RVA: 0x0007FD5B File Offset: 0x0007E15B
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__1F(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x0007FD63 File Offset: 0x0007E163
	[CompilerGenerated]
	private static double <OrderHeroList>m__20(AdventurerProfile h)
	{
		return h.GetRating();
	}

	// Token: 0x06000BCF RID: 3023 RVA: 0x0007FD6B File Offset: 0x0007E16B
	[CompilerGenerated]
	private static int <OrderHeroList>m__21(AdventurerProfile h)
	{
		return h.GetLevel();
	}

	// Token: 0x06000BD0 RID: 3024 RVA: 0x0007FD73 File Offset: 0x0007E173
	[CompilerGenerated]
	private static bool <OrderHeroList>m__22(AdventurerProfile h)
	{
		return h.IsStar();
	}

	// Token: 0x06000BD1 RID: 3025 RVA: 0x0007FD7B File Offset: 0x0007E17B
	[CompilerGenerated]
	private static QualityGrade <OrderHeroList>m__23(AdventurerProfile h)
	{
		return h.Grade;
	}

	// Token: 0x04000E1D RID: 3613
	public HeroPaginationController HeroPage;

	// Token: 0x04000E1E RID: 3614
	public HeroInfoController HeroInfo;

	// Token: 0x04000E1F RID: 3615
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageHero <SelectedHero>k__BackingField;

	// Token: 0x04000E20 RID: 3616
	[CompilerGenerated]
	private static Func<AdventurerProfile, PageHero> <>f__am$cache0;

	// Token: 0x04000E21 RID: 3617
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cache1;

	// Token: 0x04000E22 RID: 3618
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache2;

	// Token: 0x04000E23 RID: 3619
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cache3;

	// Token: 0x04000E24 RID: 3620
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache4;

	// Token: 0x04000E25 RID: 3621
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cache5;

	// Token: 0x04000E26 RID: 3622
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cache6;

	// Token: 0x04000E27 RID: 3623
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cache7;

	// Token: 0x04000E28 RID: 3624
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache8;

	// Token: 0x04000E29 RID: 3625
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cache9;

	// Token: 0x04000E2A RID: 3626
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cacheA;

	// Token: 0x04000E2B RID: 3627
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cacheB;

	// Token: 0x04000E2C RID: 3628
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cacheC;

	// Token: 0x04000E2D RID: 3629
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cacheD;

	// Token: 0x04000E2E RID: 3630
	[CompilerGenerated]
	private static Func<AdventurerProfile, double> <>f__am$cacheE;

	// Token: 0x04000E2F RID: 3631
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cacheF;

	// Token: 0x04000E30 RID: 3632
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache10;

	// Token: 0x04000E31 RID: 3633
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cache11;

	// Token: 0x04000E32 RID: 3634
	[CompilerGenerated]
	private static Func<AdventurerProfile, double> <>f__am$cache12;

	// Token: 0x04000E33 RID: 3635
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cache13;

	// Token: 0x04000E34 RID: 3636
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache14;

	// Token: 0x04000E35 RID: 3637
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cache15;

	// Token: 0x04000E36 RID: 3638
	[CompilerGenerated]
	private static Func<AdventurerProfile, UnitClass> <>f__am$cache16;

	// Token: 0x04000E37 RID: 3639
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cache17;

	// Token: 0x04000E38 RID: 3640
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache18;

	// Token: 0x04000E39 RID: 3641
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cache19;

	// Token: 0x04000E3A RID: 3642
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache1A;

	// Token: 0x04000E3B RID: 3643
	[CompilerGenerated]
	private static Func<AdventurerProfile, ClassCategory> <>f__am$cache1B;

	// Token: 0x04000E3C RID: 3644
	[CompilerGenerated]
	private static Func<AdventurerProfile, UnitClass> <>f__am$cache1C;

	// Token: 0x04000E3D RID: 3645
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cache1D;

	// Token: 0x04000E3E RID: 3646
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache1E;

	// Token: 0x04000E3F RID: 3647
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cache1F;

	// Token: 0x04000E40 RID: 3648
	[CompilerGenerated]
	private static Func<AdventurerProfile, double> <>f__am$cache20;

	// Token: 0x04000E41 RID: 3649
	[CompilerGenerated]
	private static Func<AdventurerProfile, int> <>f__am$cache21;

	// Token: 0x04000E42 RID: 3650
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache22;

	// Token: 0x04000E43 RID: 3651
	[CompilerGenerated]
	private static Func<AdventurerProfile, QualityGrade> <>f__am$cache23;

	// Token: 0x02000C30 RID: 3120
	[CompilerGenerated]
	private sealed class <UpdateHeroInfoWithNewEquipment>c__AnonStorey0
	{
		// Token: 0x06005238 RID: 21048 RVA: 0x0007FD83 File Offset: 0x0007E183
		public <UpdateHeroInfoWithNewEquipment>c__AnonStorey0()
		{
		}

		// Token: 0x06005239 RID: 21049 RVA: 0x0007FD8B File Offset: 0x0007E18B
		internal bool <>m__0(AttributeModifier a)
		{
			return a.AttributeModifierType == this.modifier.AttributeModifierType;
		}

		// Token: 0x04004038 RID: 16440
		internal AttributeModifier modifier;
	}
}
