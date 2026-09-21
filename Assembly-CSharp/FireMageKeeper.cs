using System;
using System.Collections.Generic;

// Token: 0x02000ACA RID: 2762
public class FireMageKeeper : MajorQuestBossConfiguration
{
	// Token: 0x06004A73 RID: 19059 RVA: 0x001E9B21 File Offset: 0x001E7F21
	public FireMageKeeper()
	{
	}

	// Token: 0x17000FA1 RID: 4001
	// (get) Token: 0x06004A74 RID: 19060 RVA: 0x001E9B29 File Offset: 0x001E7F29
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.FireMage;
		}
	}

	// Token: 0x17000FA2 RID: 4002
	// (get) Token: 0x06004A75 RID: 19061 RVA: 0x001E9B30 File Offset: 0x001E7F30
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A76 RID: 19062 RVA: 0x001E9B34 File Offset: 0x001E7F34
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.FireBreath,
			SkillType.Flame
		};
	}

	// Token: 0x06004A77 RID: 19063 RVA: 0x001E9B60 File Offset: 0x001E7F60
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new MonksEyesData
			{
				IsStarEf = new bool?(false),
				MaxLoss = 0.2
			},
			new DemonicFireData
			{
				IsStarEf = new bool?(false)
			},
			new FieryTaleEffectData
			{
				IsStarEf = new bool?(false),
				FiresPerHit = 2,
				StartFires = 2
			}
		};
	}

	// Token: 0x06004A78 RID: 19064 RVA: 0x001E9BDC File Offset: 0x001E7FDC
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.PortBlueprint.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.PortBlueprint,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
