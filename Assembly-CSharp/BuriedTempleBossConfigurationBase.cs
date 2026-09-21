using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000A78 RID: 2680
public abstract class BuriedTempleBossConfigurationBase : BossUnitConfigurationBase
{
	// Token: 0x060048FA RID: 18682 RVA: 0x001E308F File Offset: 0x001E148F
	protected BuriedTempleBossConfigurationBase()
	{
	}

	// Token: 0x060048FB RID: 18683 RVA: 0x001E3098 File Offset: 0x001E1498
	public sealed override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		list.AddRange(base.GenerateScrollMats(ResourceType.SealOfBuriedTemple, fromAdventure.CorrespondingDifficultyMeasurement));
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetEpicInvitationDropRate() && !ResourceType.FireSpiritInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.FireSpiritInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetRareInvitationDropRate() && !ResourceType.IronSoliderInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.IronSoliderInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if ((double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetRareInvitationDropRate() && !ResourceType.ElementalWizardInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.ElementalWizardInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return this.FurtherModifyGeneratedDrops(list, fromAdventure);
	}

	// Token: 0x060048FC RID: 18684 RVA: 0x001E31BF File Offset: 0x001E15BF
	public virtual List<ResourceUpdate> FurtherModifyGeneratedDrops(List<ResourceUpdate> originalUpdates, Adventure fromAdventure)
	{
		return originalUpdates;
	}

	// Token: 0x060048FD RID: 18685 RVA: 0x001E31C2 File Offset: 0x001E15C2
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>();
	}
}
