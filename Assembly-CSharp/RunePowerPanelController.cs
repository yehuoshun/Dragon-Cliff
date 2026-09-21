using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Battle.RunePower;
using UnityEngine;

// Token: 0x0200015D RID: 349
public class RunePowerPanelController : MonoBehaviour
{
	// Token: 0x06000957 RID: 2391 RVA: 0x0007A7C4 File Offset: 0x00078BC4
	public RunePowerPanelController()
	{
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x0007A7CC File Offset: 0x00078BCC
	public void Init(Adventure adventure)
	{
		this.PrismLight.UpdateAmount(0);
		this.GhostBreaths.UpdateAmount(0);
		this.VitalEnergy.UpdateAmount(0);
		this.ChaoticSpirit.UpdateAmount(0);
		this.Container.gameObject.SetActive(adventure.Adventurers.Any((AdventurerBattleUnit a) => a.AdventurerProfile.GetEquipments().Any((Item e) => e.Type.GetResourceCategory() == ResourceCategory.Device)));
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x0007A841 File Offset: 0x00078C41
	public void Hide()
	{
		this.Container.gameObject.SetActive(false);
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x0007A854 File Offset: 0x00078C54
	public void UpdateRuneValues(RunePowerDetails runePower)
	{
		foreach (KeyValuePair<RunePowerType, int> keyValuePair in runePower.RunePowers)
		{
			switch (keyValuePair.Key)
			{
			case RunePowerType.PrismLight:
				this.PrismLight.UpdateAmount(keyValuePair.Value);
				break;
			case RunePowerType.GhostBreaths:
				this.GhostBreaths.UpdateAmount(keyValuePair.Value);
				break;
			case RunePowerType.VitalEnergy:
				this.VitalEnergy.UpdateAmount(keyValuePair.Value);
				break;
			case RunePowerType.ChaoticSpirit:
				this.ChaoticSpirit.UpdateAmount(keyValuePair.Value);
				break;
			}
		}
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x0007A92C File Offset: 0x00078D2C
	[CompilerGenerated]
	private static bool <Init>m__0(AdventurerBattleUnit a)
	{
		return a.AdventurerProfile.GetEquipments().Any((Item e) => e.Type.GetResourceCategory() == ResourceCategory.Device);
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x0007A95B File Offset: 0x00078D5B
	[CompilerGenerated]
	private static bool <Init>m__1(Item e)
	{
		return e.Type.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x04000C05 RID: 3077
	public Transform Container;

	// Token: 0x04000C06 RID: 3078
	public RuneItemController PrismLight;

	// Token: 0x04000C07 RID: 3079
	public RuneItemController GhostBreaths;

	// Token: 0x04000C08 RID: 3080
	public RuneItemController VitalEnergy;

	// Token: 0x04000C09 RID: 3081
	public RuneItemController ChaoticSpirit;

	// Token: 0x04000C0A RID: 3082
	[CompilerGenerated]
	private static Func<AdventurerBattleUnit, bool> <>f__am$cache0;

	// Token: 0x04000C0B RID: 3083
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache1;
}
