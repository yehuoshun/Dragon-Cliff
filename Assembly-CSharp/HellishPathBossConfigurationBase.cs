using System;
using System.Collections.Generic;

// Token: 0x02000A98 RID: 2712
public abstract class HellishPathBossConfigurationBase : BossUnitConfigurationBase
{
	// Token: 0x06004998 RID: 18840 RVA: 0x001E3710 File Offset: 0x001E1B10
	protected HellishPathBossConfigurationBase()
	{
	}

	// Token: 0x06004999 RID: 18841 RVA: 0x001E3718 File Offset: 0x001E1B18
	public sealed override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		list.AddRange(base.GenerateScrollMats(ResourceType.StoneOfHellishPath, fromAdventure.CorrespondingDifficultyMeasurement));
		return this.FurtherModifyGeneratedDrops(list, fromAdventure);
	}

	// Token: 0x0600499A RID: 18842 RVA: 0x001E374C File Offset: 0x001E1B4C
	public virtual List<ResourceUpdate> FurtherModifyGeneratedDrops(List<ResourceUpdate> originalUpdates, Adventure fromAdventure)
	{
		return originalUpdates;
	}
}
