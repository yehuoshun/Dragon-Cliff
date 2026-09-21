using System;
using System.Collections.Generic;

// Token: 0x02000AD3 RID: 2771
public class Pharmacist : MajorQuestBossConfiguration
{
	// Token: 0x06004ABA RID: 19130 RVA: 0x001EA46F File Offset: 0x001E886F
	public Pharmacist()
	{
	}

	// Token: 0x17000FB1 RID: 4017
	// (get) Token: 0x06004ABB RID: 19131 RVA: 0x001EA477 File Offset: 0x001E8877
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Pharmacist;
		}
	}

	// Token: 0x17000FB2 RID: 4018
	// (get) Token: 0x06004ABC RID: 19132 RVA: 0x001EA47E File Offset: 0x001E887E
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004ABD RID: 19133 RVA: 0x001EA481 File Offset: 0x001E8881
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Lightening;
	}

	// Token: 0x06004ABE RID: 19134 RVA: 0x001EA484 File Offset: 0x001E8884
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new InversedMandateData
			{
				DamageType = OutputType.Fire,
				DamageRate = 0.2,
				LastingSeconds = 2f,
				Charged = 0.0,
				ChargeRate = 0.4
			}
		};
	}

	// Token: 0x06004ABF RID: 19135 RVA: 0x001EA4E4 File Offset: 0x001E88E4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Shock,
			SkillType.Swift
		};
	}

	// Token: 0x06004AC0 RID: 19136 RVA: 0x001EA510 File Offset: 0x001E8910
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.SwiftBook.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.SwiftBook,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
