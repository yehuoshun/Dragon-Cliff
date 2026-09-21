using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class AutoDialogProcessor : CoreProcessorBase
{
	// Token: 0x060020CA RID: 8394 RVA: 0x000E2E91 File Offset: 0x000E1291
	public AutoDialogProcessor()
	{
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x000E2EA4 File Offset: 0x000E12A4
	public override void Process()
	{
		this.timePassed += Time.deltaTime;
		if (this.timePassed >= this.dialogRate)
		{
			this.dialogRate = UnityEngine.Random.value * 5f + 25f;
			this.timePassed = 0f;
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.TownAutoDialogTriggers, null);
		}
	}

	// Token: 0x04001D0B RID: 7435
	private float dialogRate = 3f;

	// Token: 0x04001D0C RID: 7436
	private float timePassed;
}
