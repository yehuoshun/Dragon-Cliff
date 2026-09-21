using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000AE9 RID: 2793
public abstract class SnowMountainBossConfiguration : BossUnitConfigurationBase
{
	// Token: 0x06004B3F RID: 19263 RVA: 0x001E4876 File Offset: 0x001E2C76
	protected SnowMountainBossConfiguration()
	{
	}

	// Token: 0x06004B40 RID: 19264 RVA: 0x001E4880 File Offset: 0x001E2C80
	public sealed override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		list.AddRange(base.GenerateScrollMats(ResourceType.IceOfSnowMountain, fromAdventure.CorrespondingDifficultyMeasurement));
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetEpicInvitationDropRate() && !ResourceType.SnowMaidenInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.SnowMaidenInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetRareInvitationDropRate() && !ResourceType.BunSisterInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.BunSisterInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetEpicInvitationDropRate() && !ResourceType.CubeInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.CubeInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetEpicInvitationDropRate() && !ResourceType.FashionBoyInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.FashionBoyInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return this.FurtherModifyGeneratedDrops(list, fromAdventure);
	}

	// Token: 0x06004B41 RID: 19265 RVA: 0x001E49F8 File Offset: 0x001E2DF8
	public virtual List<ResourceUpdate> FurtherModifyGeneratedDrops(List<ResourceUpdate> originalUpdates, Adventure fromAdventure)
	{
		return originalUpdates;
	}

	// Token: 0x06004B42 RID: 19266 RVA: 0x001E49FB File Offset: 0x001E2DFB
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>();
	}
}
