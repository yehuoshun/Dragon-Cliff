using System;
using System.Collections.Generic;

// Token: 0x02000AC4 RID: 2756
public class CorruptedHorn : MajorQuestBossConfiguration
{
	// Token: 0x06004A4F RID: 19023 RVA: 0x001E921A File Offset: 0x001E761A
	public CorruptedHorn()
	{
	}

	// Token: 0x17000F95 RID: 3989
	// (get) Token: 0x06004A50 RID: 19024 RVA: 0x001E9222 File Offset: 0x001E7622
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.CorruptedHorn;
		}
	}

	// Token: 0x17000F96 RID: 3990
	// (get) Token: 0x06004A51 RID: 19025 RVA: 0x001E9229 File Offset: 0x001E7629
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A52 RID: 19026 RVA: 0x001E922C File Offset: 0x001E762C
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new UndeadAshData
			{
				PerLossRate = 0.1,
				PerIncreaseRate = 0.5,
				PreviousLossLayers = 0,
				DamageSoFar = 0.0
			}
		};
	}

	// Token: 0x06004A53 RID: 19027 RVA: 0x001E9284 File Offset: 0x001E7684
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.DragonBloodStone.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.DragonBloodStone,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004A54 RID: 19028 RVA: 0x001E92DC File Offset: 0x001E76DC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.CorruptedPower,
			SkillType.Flame
		};
	}
}
