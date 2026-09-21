using System;
using System.Collections.Generic;

// Token: 0x02000AC5 RID: 2757
public class DarkKnight : MajorQuestBossConfiguration
{
	// Token: 0x06004A55 RID: 19029 RVA: 0x001E9306 File Offset: 0x001E7706
	public DarkKnight()
	{
	}

	// Token: 0x17000F97 RID: 3991
	// (get) Token: 0x06004A56 RID: 19030 RVA: 0x001E930E File Offset: 0x001E770E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.DarkKnight;
		}
	}

	// Token: 0x17000F98 RID: 3992
	// (get) Token: 0x06004A57 RID: 19031 RVA: 0x001E9315 File Offset: 0x001E7715
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A58 RID: 19032 RVA: 0x001E9318 File Offset: 0x001E7718
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.SchoolPermit.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.SchoolPermit,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004A59 RID: 19033 RVA: 0x001E9370 File Offset: 0x001E7770
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new DarkRageData
			{
				ChargeRate = 0.3,
				ChargeAttributeTypes = new List<AttributeType>
				{
					AttributeType.Strength,
					AttributeType.Agility
				}
			}
		};
	}
}
