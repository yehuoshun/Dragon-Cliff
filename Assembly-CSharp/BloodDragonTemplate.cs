using System;
using System.Collections.Generic;

// Token: 0x0200057B RID: 1403
public class BloodDragonTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002843 RID: 10307 RVA: 0x0011A9B9 File Offset: 0x00118DB9
	public BloodDragonTemplate()
	{
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x06002844 RID: 10308 RVA: 0x0011A9C1 File Offset: 0x00118DC1
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.BloodDragon;
		}
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06002845 RID: 10309 RVA: 0x0011A9C8 File Offset: 0x00118DC8
	public override int ItemTierNumber
	{
		get
		{
			return 29;
		}
	}

	// Token: 0x06002846 RID: 10310 RVA: 0x0011A9CC File Offset: 0x00118DCC
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DodgeRateAdjustment
		};
	}
}
