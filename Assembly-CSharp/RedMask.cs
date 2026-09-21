using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000AD8 RID: 2776
public class RedMask : MinionUnitConfigurationBase
{
	// Token: 0x06004AD6 RID: 19158 RVA: 0x001EA831 File Offset: 0x001E8C31
	public RedMask()
	{
	}

	// Token: 0x17000FBB RID: 4027
	// (get) Token: 0x06004AD7 RID: 19159 RVA: 0x001EA839 File Offset: 0x001E8C39
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedMask;
		}
	}

	// Token: 0x17000FBC RID: 4028
	// (get) Token: 0x06004AD8 RID: 19160 RVA: 0x001EA840 File Offset: 0x001E8C40
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004AD9 RID: 19161 RVA: 0x001EA843 File Offset: 0x001E8C43
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Fire;
	}

	// Token: 0x06004ADA RID: 19162 RVA: 0x001EA848 File Offset: 0x001E8C48
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ReturningSoul
		};
	}

	// Token: 0x06004ADB RID: 19163 RVA: 0x001EA868 File Offset: 0x001E8C68
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		originalGrowthProfile.SetValue(AttributeType.Vitality, (from a in originalGrowthProfile.UnitGrowthValues
		where a.AttributeType == AttributeType.Vitality
		select a).Sum((UnitGrowthValue v) => v.Potential) * 2.5, false);
		return originalGrowthProfile;
	}

	// Token: 0x06004ADC RID: 19164 RVA: 0x001EA8D3 File Offset: 0x001E8CD3
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__0(UnitGrowthValue a)
	{
		return a.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004ADD RID: 19165 RVA: 0x001EA8DE File Offset: 0x001E8CDE
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__1(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x04003AA8 RID: 15016
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache0;

	// Token: 0x04003AA9 RID: 15017
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache1;
}
