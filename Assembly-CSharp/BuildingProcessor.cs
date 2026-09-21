using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class BuildingProcessor : CoreProcessorBase
{
	// Token: 0x060020CC RID: 8396 RVA: 0x000E2F08 File Offset: 0x000E1308
	public BuildingProcessor()
	{
	}

	// Token: 0x060020CD RID: 8397 RVA: 0x000E2F10 File Offset: 0x000E1310
	public override void Process()
	{
		if (GameWorld.instance != null && GameWorld.instance.PlayerProfile != null && GameWorld.instance.PlayerProfile.Buildings != null)
		{
			foreach (KeyValuePair<TownSlot, IBuildingProfile> keyValuePair in GameWorld.instance.PlayerProfile.Buildings)
			{
				if (keyValuePair.Value != null)
				{
					keyValuePair.Value.Process(Time.deltaTime);
				}
			}
		}
	}
}
