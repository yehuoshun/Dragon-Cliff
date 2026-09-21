using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000A99 RID: 2713
public abstract class ImperialMausoleumBossConfigurationBase : BossUnitConfigurationBase
{
	// Token: 0x0600499B RID: 18843 RVA: 0x001E34CF File Offset: 0x001E18CF
	protected ImperialMausoleumBossConfigurationBase()
	{
	}

	// Token: 0x0600499C RID: 18844 RVA: 0x001E34D8 File Offset: 0x001E18D8
	public sealed override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		list.AddRange(base.GenerateScrollMats(ResourceType.LeafOfImperialM, fromAdventure.CorrespondingDifficultyMeasurement));
		if (fromAdventure.LevelNumber > 30 && !ResourceType.TacticianInvitation.HasObtained() && (double)UnityEngine.Random.value <= BossUnitConfigurationBase.GetCommonInvitationDropRate())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.TacticianInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return this.FurtherModifyGeneratedDrops(list, fromAdventure);
	}

	// Token: 0x0600499D RID: 18845 RVA: 0x001E356A File Offset: 0x001E196A
	public virtual List<ResourceUpdate> FurtherModifyGeneratedDrops(List<ResourceUpdate> originalUpdates, Adventure fromAdventure)
	{
		return originalUpdates;
	}
}
