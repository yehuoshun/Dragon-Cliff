using System;
using System.Collections.Generic;

// Token: 0x02000AE4 RID: 2788
public class ImmortalSeeker : BossUnitConfigurationBase
{
	// Token: 0x06004B26 RID: 19238 RVA: 0x001EBB76 File Offset: 0x001E9F76
	public ImmortalSeeker()
	{
	}

	// Token: 0x17000FD1 RID: 4049
	// (get) Token: 0x06004B27 RID: 19239 RVA: 0x001EBB7E File Offset: 0x001E9F7E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ImmortalSeeker;
		}
	}

	// Token: 0x17000FD2 RID: 4050
	// (get) Token: 0x06004B28 RID: 19240 RVA: 0x001EBB85 File Offset: 0x001E9F85
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellDefender;
		}
	}

	// Token: 0x06004B29 RID: 19241 RVA: 0x001EBB88 File Offset: 0x001E9F88
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		return new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.BlackBead,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			}
		};
	}

	// Token: 0x06004B2A RID: 19242 RVA: 0x001EBBD0 File Offset: 0x001E9FD0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SeedsOfSin,
			SkillType.Rage
		};
	}

	// Token: 0x06004B2B RID: 19243 RVA: 0x001EBBFC File Offset: 0x001E9FFC
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TranscendenceEffectData
			{
				Rate = 1.0
			}
		};
	}
}
