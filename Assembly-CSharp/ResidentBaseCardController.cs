using System;

// Token: 0x02000246 RID: 582
public class ResidentBaseCardController : ResidentViewCardController
{
	// Token: 0x06000F11 RID: 3857 RVA: 0x000932F0 File Offset: 0x000916F0
	public ResidentBaseCardController()
	{
	}

	// Token: 0x06000F12 RID: 3858 RVA: 0x000932F8 File Offset: 0x000916F8
	private void Start()
	{
		this.ResidentPanel = base.GetComponentInParent<ResidentPanelController>();
	}

	// Token: 0x0400107D RID: 4221
	protected ResidentPanelController ResidentPanel;
}
