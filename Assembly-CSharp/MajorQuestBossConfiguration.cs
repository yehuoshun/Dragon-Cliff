using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000AD0 RID: 2768
public abstract class MajorQuestBossConfiguration : BossUnitConfigurationBase
{
	// Token: 0x06004A98 RID: 19096 RVA: 0x001E8602 File Offset: 0x001E6A02
	protected MajorQuestBossConfiguration()
	{
	}

	// Token: 0x06004A99 RID: 19097 RVA: 0x001E860C File Offset: 0x001E6A0C
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateDropableGears(1, new QualityGrade?(QualityGrade.Ancient), false));
		list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateDropableGems(1));
		return list;
	}

	// Token: 0x06004A9A RID: 19098 RVA: 0x001E8650 File Offset: 0x001E6A50
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 2)
		{
			if (measurement.DifficultyValue <= 15.0)
			{
				originalGrowthProfile.SetValue(AttributeType.Resilience, 10000.0, false);
				originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 60.0, false);
				originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
				where v.AttributeType == AttributeType.Vitality
				select v).Sum((UnitGrowthValue v) => v.Potential) * 6.5, false);
				originalGrowthProfile.SetValue(AttributeType.Allresistances, 3500.0, false);
			}
			else if (measurement.DifficultyValue <= 30.0)
			{
				originalGrowthProfile.SetValue(AttributeType.Resilience, 12000.0, false);
				originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 60.0, false);
				originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
				where v.AttributeType == AttributeType.Vitality
				select v).Sum((UnitGrowthValue v) => v.Potential) * 8.5, false);
				originalGrowthProfile.SetValue(AttributeType.Allresistances, 5000.0, false);
			}
			else if (measurement.DifficultyValue <= 55.0)
			{
				originalGrowthProfile.SetValue(AttributeType.Resilience, 12000.0, false);
				originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 60.0, false);
				originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
				where v.AttributeType == AttributeType.Vitality
				select v).Sum((UnitGrowthValue v) => v.Potential) * 10.0, false);
				originalGrowthProfile.SetValue(AttributeType.Allresistances, 7000.0, false);
			}
			else if (measurement.DifficultyValue <= 100.0)
			{
				originalGrowthProfile.SetValue(AttributeType.Resilience, 12000.0, false);
				originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 70.0, false);
				originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
				where v.AttributeType == AttributeType.Vitality
				select v).Sum((UnitGrowthValue v) => v.Potential) * 10.5, false);
				originalGrowthProfile.SetValue(AttributeType.Allresistances, 8000.0, false);
			}
			else
			{
				originalGrowthProfile.SetValue(AttributeType.Resilience, 12000.0, false);
				originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 70.0, false);
				originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
				where v.AttributeType == AttributeType.Vitality
				select v).Sum((UnitGrowthValue v) => v.Potential) * 11.5, false);
				originalGrowthProfile.SetValue(AttributeType.Allresistances, 10000.0, false);
			}
		}
		else if (measurement.DifficultyValue <= 15.0)
		{
			originalGrowthProfile.SetValue(AttributeType.Resilience, 0.0, false);
			originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
			where v.AttributeType == AttributeType.Vitality
			select v).Sum((UnitGrowthValue v) => v.Potential) * 1.5, false);
		}
		else if (measurement.DifficultyValue <= 30.0)
		{
			originalGrowthProfile.SetValue(AttributeType.Resilience, 1000.0, false);
			originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 50.0, false);
			originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
			where v.AttributeType == AttributeType.Vitality
			select v).Sum((UnitGrowthValue v) => v.Potential) * 3.5, false);
		}
		else if (measurement.DifficultyValue <= 55.0)
		{
			originalGrowthProfile.SetValue(AttributeType.Resilience, 1000.0, false);
			originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 50.0, false);
			originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
			where v.AttributeType == AttributeType.Vitality
			select v).Sum((UnitGrowthValue v) => v.Potential) * 5.0, false);
			originalGrowthProfile.SetValue(AttributeType.Allresistances, 1000.0, false);
		}
		else if (measurement.DifficultyValue <= 100.0)
		{
			originalGrowthProfile.SetValue(AttributeType.Resilience, 2000.0, false);
			originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 80.0, false);
			originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
			where v.AttributeType == AttributeType.Vitality
			select v).Sum((UnitGrowthValue v) => v.Potential) * 6.5, false);
			originalGrowthProfile.SetValue(AttributeType.Allresistances, 2000.0, false);
		}
		else
		{
			originalGrowthProfile.SetValue(AttributeType.Resilience, 2500.0, false);
			originalGrowthProfile.SetValue(AttributeType.EffectResistanceRating, 80.0, false);
			originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
			where v.AttributeType == AttributeType.Vitality
			select v).Sum((UnitGrowthValue v) => v.Potential) * 6.5, false);
			originalGrowthProfile.SetValue(AttributeType.Allresistances, 2500.0, false);
		}
		return originalGrowthProfile;
	}

	// Token: 0x06004A9B RID: 19099 RVA: 0x001E8D13 File Offset: 0x001E7113
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__0(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004A9C RID: 19100 RVA: 0x001E8D1E File Offset: 0x001E711E
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__1(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004A9D RID: 19101 RVA: 0x001E8D26 File Offset: 0x001E7126
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__2(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004A9E RID: 19102 RVA: 0x001E8D31 File Offset: 0x001E7131
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__3(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004A9F RID: 19103 RVA: 0x001E8D39 File Offset: 0x001E7139
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__4(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004AA0 RID: 19104 RVA: 0x001E8D44 File Offset: 0x001E7144
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__5(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004AA1 RID: 19105 RVA: 0x001E8D4C File Offset: 0x001E714C
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__6(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004AA2 RID: 19106 RVA: 0x001E8D57 File Offset: 0x001E7157
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__7(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004AA3 RID: 19107 RVA: 0x001E8D5F File Offset: 0x001E715F
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__8(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004AA4 RID: 19108 RVA: 0x001E8D6A File Offset: 0x001E716A
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__9(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004AA5 RID: 19109 RVA: 0x001E8D72 File Offset: 0x001E7172
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__A(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004AA6 RID: 19110 RVA: 0x001E8D7D File Offset: 0x001E717D
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__B(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004AA7 RID: 19111 RVA: 0x001E8D85 File Offset: 0x001E7185
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__C(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004AA8 RID: 19112 RVA: 0x001E8D90 File Offset: 0x001E7190
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__D(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004AA9 RID: 19113 RVA: 0x001E8D98 File Offset: 0x001E7198
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__E(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004AAA RID: 19114 RVA: 0x001E8DA3 File Offset: 0x001E71A3
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__F(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004AAB RID: 19115 RVA: 0x001E8DAB File Offset: 0x001E71AB
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__10(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004AAC RID: 19116 RVA: 0x001E8DB6 File Offset: 0x001E71B6
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__11(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004AAD RID: 19117 RVA: 0x001E8DBE File Offset: 0x001E71BE
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__12(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004AAE RID: 19118 RVA: 0x001E8DC9 File Offset: 0x001E71C9
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__13(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x04003A94 RID: 14996
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache0;

	// Token: 0x04003A95 RID: 14997
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache1;

	// Token: 0x04003A96 RID: 14998
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache2;

	// Token: 0x04003A97 RID: 14999
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache3;

	// Token: 0x04003A98 RID: 15000
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache4;

	// Token: 0x04003A99 RID: 15001
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache5;

	// Token: 0x04003A9A RID: 15002
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache6;

	// Token: 0x04003A9B RID: 15003
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache7;

	// Token: 0x04003A9C RID: 15004
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache8;

	// Token: 0x04003A9D RID: 15005
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache9;

	// Token: 0x04003A9E RID: 15006
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cacheA;

	// Token: 0x04003A9F RID: 15007
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cacheB;

	// Token: 0x04003AA0 RID: 15008
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cacheC;

	// Token: 0x04003AA1 RID: 15009
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cacheD;

	// Token: 0x04003AA2 RID: 15010
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cacheE;

	// Token: 0x04003AA3 RID: 15011
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cacheF;

	// Token: 0x04003AA4 RID: 15012
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache10;

	// Token: 0x04003AA5 RID: 15013
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache11;

	// Token: 0x04003AA6 RID: 15014
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache12;

	// Token: 0x04003AA7 RID: 15015
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache13;
}
