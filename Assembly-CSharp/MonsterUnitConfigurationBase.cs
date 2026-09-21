using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B14 RID: 2836
public abstract class MonsterUnitConfigurationBase : UnitConfigurationBase
{
	// Token: 0x06004BE7 RID: 19431 RVA: 0x001DC839 File Offset: 0x001DAC39
	protected MonsterUnitConfigurationBase()
	{
	}

	// Token: 0x06004BE8 RID: 19432 RVA: 0x001DC841 File Offset: 0x001DAC41
	protected virtual List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>();
	}

	// Token: 0x06004BE9 RID: 19433 RVA: 0x001DC848 File Offset: 0x001DAC48
	public List<Skill> GenerateSkills(DifficultyLevelMeasurement measurement, int level)
	{
		return (from s in this.MonsterSkills(measurement).Distinct<SkillType>()
		select s.CreateMonsterSkill(level)).ToList<Skill>();
	}

	// Token: 0x06004BEA RID: 19434 RVA: 0x001DC884 File Offset: 0x001DAC84
	public virtual List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		return new List<ResourceUpdate>();
	}

	// Token: 0x06004BEB RID: 19435
	public abstract List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement relevantDifficultyLevelMeasurement);

	// Token: 0x06004BEC RID: 19436 RVA: 0x001DC88C File Offset: 0x001DAC8C
	public virtual OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		if (difficultyLevelMeasurement.DifficultyValue <= 10.0 && difficultyLevelMeasurement.StarRating == 1)
		{
			return OutputType.Physical;
		}
		Dictionary<AdventureType, List<OutputTypePresences>> dictionary = new Dictionary<AdventureType, List<OutputTypePresences>>
		{
			{
				AdventureType.WoodenForest,
				new List<OutputTypePresences>
				{
					new OutputTypePresences(200, OutputType.Physical),
					new OutputTypePresences(300, OutputType.Poison)
				}
			},
			{
				AdventureType.MistForest,
				new List<OutputTypePresences>
				{
					new OutputTypePresences(300, OutputType.Shadow),
					new OutputTypePresences(200, OutputType.Poison),
					new OutputTypePresences(100, OutputType.Physical)
				}
			},
			{
				AdventureType.BuriedTemple,
				new List<OutputTypePresences>
				{
					new OutputTypePresences(300, OutputType.Lightening),
					new OutputTypePresences(200, OutputType.Shadow),
					new OutputTypePresences(100, OutputType.Poison)
				}
			},
			{
				AdventureType.SnowMountain,
				new List<OutputTypePresences>
				{
					new OutputTypePresences(300, OutputType.Ice),
					new OutputTypePresences(200, OutputType.Lightening),
					new OutputTypePresences(100, OutputType.Shadow)
				}
			},
			{
				AdventureType.HellishPath,
				new List<OutputTypePresences>
				{
					new OutputTypePresences(300, OutputType.Fire),
					new OutputTypePresences(200, OutputType.Divine),
					new OutputTypePresences(100, OutputType.Ice)
				}
			}
		};
		if (dictionary.ContainsKey(adventureType))
		{
			return dictionary[adventureType].WeightedRandomSelect<OutputTypePresences>().OutputType;
		}
		List<OutputTypePresences> presences = new List<OutputTypePresences>
		{
			new OutputTypePresences(100, OutputType.Physical),
			new OutputTypePresences(100, OutputType.Poison),
			new OutputTypePresences(100, OutputType.Fire),
			new OutputTypePresences(100, OutputType.Ice),
			new OutputTypePresences(100, OutputType.Shadow),
			new OutputTypePresences(100, OutputType.Lightening),
			new OutputTypePresences(100, OutputType.Divine)
		};
		return presences.WeightedRandomSelect<OutputTypePresences>().OutputType;
	}

	// Token: 0x06004BED RID: 19437
	public abstract UnitGrowthProfile GetMonsterGrowthProfile(DifficultyLevelMeasurement measurement);

	// Token: 0x06004BEE RID: 19438 RVA: 0x001DCA84 File Offset: 0x001DAE84
	protected void SetProfileResistanceToValue(double value, UnitGrowthProfile original)
	{
		original.SetValue(AttributeType.PhysicalResistance, value, true).SetValue(AttributeType.FireResistanceResistance, value, true).SetValue(AttributeType.PoisonResistance, value, true).SetValue(AttributeType.IceResistance, value, true).SetValue(AttributeType.LightningResistance, value, true).SetValue(AttributeType.DivineResistance, value, true).SetValue(AttributeType.ShadowResistance, value, true);
	}

	// Token: 0x0200107D RID: 4221
	[CompilerGenerated]
	private sealed class <GenerateSkills>c__AnonStorey0
	{
		// Token: 0x06006978 RID: 27000 RVA: 0x001DCAD0 File Offset: 0x001DAED0
		public <GenerateSkills>c__AnonStorey0()
		{
		}

		// Token: 0x06006979 RID: 27001 RVA: 0x001DCAD8 File Offset: 0x001DAED8
		internal Skill <>m__0(SkillType s)
		{
			return s.CreateMonsterSkill(this.level);
		}

		// Token: 0x040063FE RID: 25598
		internal int level;
	}
}
