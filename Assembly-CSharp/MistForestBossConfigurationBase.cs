using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000ABF RID: 2751
public abstract class MistForestBossConfigurationBase : BossUnitConfigurationBase
{
	// Token: 0x06004A34 RID: 18996 RVA: 0x001E31C9 File Offset: 0x001E15C9
	protected MistForestBossConfigurationBase()
	{
	}

	// Token: 0x06004A35 RID: 18997 RVA: 0x001E31D4 File Offset: 0x001E15D4
	public sealed override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		list.AddRange(base.GenerateScrollMats(ResourceType.InkOfMistForest, fromAdventure.CorrespondingDifficultyMeasurement));
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetRareInvitationDropRate() && !ResourceType.RedHornInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.RedHornInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetRareInvitationDropRate() && !ResourceType.FireAssassinInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.FireAssassinInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetRareInvitationDropRate() && !ResourceType.DuelistInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.DuelistInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetEpicInvitationDropRate() && GameWorld.instance.PlayerProfile.CurrentSeason == Season.Spring && !ResourceType.GoldenShamanInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.GoldenShamanInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= 0.03 && fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue >= 15.0 && !ResourceType.FleshToStoneBook.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.FleshToStoneBook,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return this.FurtherModifyGeneratedDrops(list, fromAdventure);
	}

	// Token: 0x06004A36 RID: 18998 RVA: 0x001E33CE File Offset: 0x001E17CE
	public virtual List<ResourceUpdate> FurtherModifyGeneratedDrops(List<ResourceUpdate> originalUpdates, Adventure fromAdventure)
	{
		return originalUpdates;
	}

	// Token: 0x06004A37 RID: 18999 RVA: 0x001E33D1 File Offset: 0x001E17D1
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>();
	}
}
