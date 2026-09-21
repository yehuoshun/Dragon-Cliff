using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000AE2 RID: 2786
public class BlueDemon : BossUnitConfigurationBase
{
	// Token: 0x06004B16 RID: 19222 RVA: 0x001EB63C File Offset: 0x001E9A3C
	public BlueDemon()
	{
	}

	// Token: 0x17000FCD RID: 4045
	// (get) Token: 0x06004B17 RID: 19223 RVA: 0x001EB644 File Offset: 0x001E9A44
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueDemonDragon;
		}
	}

	// Token: 0x17000FCE RID: 4046
	// (get) Token: 0x06004B18 RID: 19224 RVA: 0x001EB64B File Offset: 0x001E9A4B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004B19 RID: 19225 RVA: 0x001EB650 File Offset: 0x001E9A50
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = new List<ResourceUpdate>();
		if (HeresyQuestHandler.CanDropFinal())
		{
			list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateDropableGears(UnityEngine.Random.Range(1, 3), new QualityGrade?(QualityGrade.Ancient), true));
			HeresyQuestHandler.SetDropFinal();
		}
		return list;
	}

	// Token: 0x06004B1A RID: 19226 RVA: 0x001EB692 File Offset: 0x001E9A92
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Ice;
	}

	// Token: 0x06004B1B RID: 19227 RVA: 0x001EB698 File Offset: 0x001E9A98
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ShieldBurn,
			SkillType.LightFire,
			SkillType.FleshToStone,
			SkillType.BloodThirst
		};
	}

	// Token: 0x06004B1C RID: 19228 RVA: 0x001EB6D8 File Offset: 0x001E9AD8
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		double num = (from u in originalGrowthProfile.UnitGrowthValues
		where u.AttributeType == AttributeType.Vitality
		select u).Sum((UnitGrowthValue u) => u.Potential);
		originalGrowthProfile.SetValue(AttributeType.Vitality, num * 2.5, false);
		originalGrowthProfile.SetValue(AttributeType.EffectMastery, 4.0, false);
		return originalGrowthProfile;
	}

	// Token: 0x06004B1D RID: 19229 RVA: 0x001EB75C File Offset: 0x001E9B5C
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>
		{
			new MonksEyesData
			{
				IsStarEf = new bool?(false),
				MaxLoss = 0.2
			},
			new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				Extra = 4,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			},
			new HydraSpiritData
			{
				IsStarEf = new bool?(false),
				HealRate = 0.08,
				TickCounter = 0,
				MaxFireySoulCap = 5,
				TickCap = 3
			},
			new ReviveDamageData
			{
				IsStar = false,
				DamageType = OutputType.Shadow,
				DamageRate = 2.5
			},
			new ElementalMasterData
			{
				IsStar = false,
				ImmuneTypes = new List<List<OutputType>>
				{
					new List<OutputType>
					{
						OutputType.Fire,
						OutputType.Divine,
						OutputType.Shadow,
						OutputType.Poison,
						OutputType.Physical,
						OutputType.Ice,
						OutputType.Lightening
					}
				}
			}
		};
		if (relevantDifficultyLevelMeasurement.StarRating == 2)
		{
			list.Add(new AgilityData
			{
				IsStar = false,
				IncreaseRate = 0.05
			});
			List<ISpecialEffectDataLoad> list2 = new List<ISpecialEffectDataLoad>
			{
				new CourageBlessingData
				{
					IsStar = false,
					StunRate = 1.0,
					OutputReductionRate = 0.15
				},
				new RageBoostData
				{
					IsStar = false,
					SuctionValue = 10.0
				},
				new IceHeartData
				{
					IsStar = false
				}
			};
			list.Add(list2[UnityEngine.Random.Range(0, list2.Count)]);
			List<ISpecialEffectDataLoad> list3 = new List<ISpecialEffectDataLoad>
			{
				new ClearUpData
				{
					IsStar = false
				},
				new SwallowData
				{
					IsStar = false,
					LastingTurns = 3,
					DamagePercentage = 0.4,
					SwallowCounts = 1
				},
				new FearData
				{
					IsStar = false,
					Chance = 0.2,
					NumberOfSeconds = 1
				},
				new ShadowOfGhostData
				{
					IsStar = false,
					DamageRate = 0.2,
					Seconds = 5
				}
			};
			list.Add(list3[UnityEngine.Random.Range(0, list3.Count)]);
		}
		return list;
	}

	// Token: 0x06004B1E RID: 19230 RVA: 0x001EBA4D File Offset: 0x001E9E4D
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__0(UnitGrowthValue u)
	{
		return u.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004B1F RID: 19231 RVA: 0x001EBA58 File Offset: 0x001E9E58
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__1(UnitGrowthValue u)
	{
		return u.Potential;
	}

	// Token: 0x04003AB0 RID: 15024
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache0;

	// Token: 0x04003AB1 RID: 15025
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache1;
}
