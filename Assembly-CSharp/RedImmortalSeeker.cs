using System;
using System.Collections.Generic;

// Token: 0x02000AE8 RID: 2792
public class RedImmortalSeeker : BossUnitConfigurationBase
{
	// Token: 0x06004B39 RID: 19257 RVA: 0x001EBD63 File Offset: 0x001EA163
	public RedImmortalSeeker()
	{
	}

	// Token: 0x17000FD9 RID: 4057
	// (get) Token: 0x06004B3A RID: 19258 RVA: 0x001EBD6B File Offset: 0x001EA16B
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedImmortalSeeker;
		}
	}

	// Token: 0x17000FDA RID: 4058
	// (get) Token: 0x06004B3B RID: 19259 RVA: 0x001EBD72 File Offset: 0x001EA172
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004B3C RID: 19260 RVA: 0x001EBD78 File Offset: 0x001EA178
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		return new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.YoungWarlockInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			}
		};
	}

	// Token: 0x06004B3D RID: 19261 RVA: 0x001EBDC0 File Offset: 0x001EA1C0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SeedsOfSin
		};
	}

	// Token: 0x06004B3E RID: 19262 RVA: 0x001EBDE0 File Offset: 0x001EA1E0
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TranscendenceEffectData
			{
				Rate = 0.5
			}
		};
	}
}
