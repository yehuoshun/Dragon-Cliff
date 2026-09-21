using System;

// Token: 0x02000596 RID: 1430
public class ToughLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600289F RID: 10399 RVA: 0x0011AF3D File Offset: 0x0011933D
	public ToughLeatherTemplate()
	{
	}

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x060028A0 RID: 10400 RVA: 0x0011AF45 File Offset: 0x00119345
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ToughLeather;
		}
	}

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x060028A1 RID: 10401 RVA: 0x0011AF4C File Offset: 0x0011934C
	public override int ItemTierNumber
	{
		get
		{
			return 8;
		}
	}
}
