using System;
using System.Collections.Generic;

// Token: 0x02000633 RID: 1587
public class FireyWavesApprenticeWandTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B1A RID: 11034 RVA: 0x0012019F File Offset: 0x0011E59F
	public FireyWavesApprenticeWandTemplate()
	{
	}

	// Token: 0x170004FB RID: 1275
	// (get) Token: 0x06002B1B RID: 11035 RVA: 0x001201A7 File Offset: 0x0011E5A7
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FireyWavesApprenticeWand;
		}
	}

	// Token: 0x170004FC RID: 1276
	// (get) Token: 0x06002B1C RID: 11036 RVA: 0x001201AE File Offset: 0x0011E5AE
	public override int ItemTierNumber
	{
		get
		{
			return 8;
		}
	}

	// Token: 0x06002B1D RID: 11037 RVA: 0x001201B4 File Offset: 0x0011E5B4
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.SkillRageEfficiencyRate
		};
	}
}
