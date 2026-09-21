using System;

// Token: 0x02000A21 RID: 2593
public class ShakeCameraHandler_Anim : ShakeCameraHandler
{
	// Token: 0x060046B4 RID: 18100 RVA: 0x001CF902 File Offset: 0x001CDD02
	public ShakeCameraHandler_Anim()
	{
	}

	// Token: 0x060046B5 RID: 18101 RVA: 0x001CF90A File Offset: 0x001CDD0A
	private void OnEnable()
	{
		this.cameraToShake = TownManager.Instance.Ui.BattleCamera;
	}
}
