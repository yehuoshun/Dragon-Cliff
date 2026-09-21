using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000AC0 RID: 2752
public abstract class NorthernTerritoryBossConfiguration : BossUnitConfigurationBase
{
	// Token: 0x06004A38 RID: 19000 RVA: 0x001E4CAA File Offset: 0x001E30AA
	protected NorthernTerritoryBossConfiguration()
	{
	}

	// Token: 0x06004A39 RID: 19001 RVA: 0x001E4CB4 File Offset: 0x001E30B4
	public sealed override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		list.AddRange(base.GenerateScrollMats(ResourceType.SandOfNorthernTerritory, fromAdventure.CorrespondingDifficultyMeasurement));
		if (!ResourceType.ConjurerInvitation.HasObtained() && (double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetEpicInvitationDropRate())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.ConjurerInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return this.FurtherModifyGeneratedDrops(list, fromAdventure);
	}

	// Token: 0x06004A3A RID: 19002 RVA: 0x001E4D39 File Offset: 0x001E3139
	public virtual List<ResourceUpdate> FurtherModifyGeneratedDrops(List<ResourceUpdate> originalUpdates, Adventure fromAdventure)
	{
		return originalUpdates;
	}

	// Token: 0x06004A3B RID: 19003 RVA: 0x001E4D3C File Offset: 0x001E313C
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ThugPowerData
			{
				IsStar = false
			},
			new TimeLockResistanceData
			{
				IsStar = false,
				Chance = 1.0
			},
			new TurnResistanceData
			{
				IsStar = false,
				Rate = 1.0
			}
		};
	}
}
