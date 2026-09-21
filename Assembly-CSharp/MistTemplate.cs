using System;

// Token: 0x0200058C RID: 1420
public class MistTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600287E RID: 10366 RVA: 0x0011ADC3 File Offset: 0x001191C3
	public MistTemplate()
	{
	}

	// Token: 0x170003AC RID: 940
	// (get) Token: 0x0600287F RID: 10367 RVA: 0x0011ADCB File Offset: 0x001191CB
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Mist;
		}
	}

	// Token: 0x170003AD RID: 941
	// (get) Token: 0x06002880 RID: 10368 RVA: 0x0011ADD2 File Offset: 0x001191D2
	public override int ItemTierNumber
	{
		get
		{
			return 17;
		}
	}
}
