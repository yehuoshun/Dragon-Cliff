using System;

// Token: 0x02000247 RID: 583
public class ResidentCardController : ResidentBaseCardController
{
	// Token: 0x06000F13 RID: 3859 RVA: 0x000933A1 File Offset: 0x000917A1
	public ResidentCardController()
	{
	}

	// Token: 0x06000F14 RID: 3860 RVA: 0x000933A9 File Offset: 0x000917A9
	public void Remove()
	{
		base.GetComponentInParent<ResidentMenuController>().Kickout(base.Resident);
	}
}
