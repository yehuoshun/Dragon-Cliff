using System;

// Token: 0x0200057D RID: 1405
public class CursedFireTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600284A RID: 10314 RVA: 0x0011AA15 File Offset: 0x00118E15
	public CursedFireTemplate()
	{
	}

	// Token: 0x1700038E RID: 910
	// (get) Token: 0x0600284B RID: 10315 RVA: 0x0011AA1D File Offset: 0x00118E1D
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.CursedFire;
		}
	}

	// Token: 0x1700038F RID: 911
	// (get) Token: 0x0600284C RID: 10316 RVA: 0x0011AA24 File Offset: 0x00118E24
	public override int ItemTierNumber
	{
		get
		{
			return 26;
		}
	}
}
