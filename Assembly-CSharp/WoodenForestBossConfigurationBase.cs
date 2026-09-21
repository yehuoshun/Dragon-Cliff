using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000AEA RID: 2794
public abstract class WoodenForestBossConfigurationBase : BossUnitConfigurationBase
{
	// Token: 0x06004B43 RID: 19267 RVA: 0x001E38F4 File Offset: 0x001E1CF4
	protected WoodenForestBossConfigurationBase()
	{
	}

	// Token: 0x06004B44 RID: 19268 RVA: 0x001E38FC File Offset: 0x001E1CFC
	public sealed override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		list.AddRange(base.GenerateScrollMats(ResourceType.CrystalOfWoodenForest, fromAdventure.CorrespondingDifficultyMeasurement));
		if (fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue >= 7.0 && (double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetEpicInvitationDropRate() && !ResourceType.SoulThiefInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.SoulThiefInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if (fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue >= 10.0 && (double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetEpicInvitationDropRate() && !ResourceType.WarriorInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.WarriorInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if (fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue >= 15.0)
		{
			if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetRareInvitationDropRate() && !ResourceType.ToughWomanInvitation.HasObtained())
			{
				list.Add(new ResourceUpdate
				{
					ResourceType = ResourceType.ToughWomanInvitation,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>()
				});
			}
			if ((double)UnityEngine.Random.value <= 0.05 && !ResourceType.StrayBook.HasObtained())
			{
				list.Add(new ResourceUpdate
				{
					ResourceType = ResourceType.StrayBook,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>()
				});
			}
		}
		return this.FurtherModifyGeneratedDrops(list, fromAdventure);
	}

	// Token: 0x06004B45 RID: 19269 RVA: 0x001E3AC3 File Offset: 0x001E1EC3
	public virtual List<ResourceUpdate> FurtherModifyGeneratedDrops(List<ResourceUpdate> originalUpdates, Adventure fromAdventure)
	{
		return originalUpdates;
	}

	// Token: 0x06004B46 RID: 19270 RVA: 0x001E3AC6 File Offset: 0x001E1EC6
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>();
	}
}
