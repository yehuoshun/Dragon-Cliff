using System;
using System.Collections.Generic;

// Token: 0x020005E5 RID: 1509
public class MagicBreadOneTemplate : ConsumableTemplateBase
{
	// Token: 0x060029B4 RID: 10676 RVA: 0x0011C309 File Offset: 0x0011A709
	public MagicBreadOneTemplate()
	{
	}

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x060029B5 RID: 10677 RVA: 0x0011C311 File Offset: 0x0011A711
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MagicBreadOne;
		}
	}

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x060029B6 RID: 10678 RVA: 0x0011C318 File Offset: 0x0011A718
	public override int ItemTierNumber
	{
		get
		{
			return 35;
		}
	}

	// Token: 0x060029B7 RID: 10679 RVA: 0x0011C31C File Offset: 0x0011A71C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new MagicBreadEffectdata
			{
				RageOnStart = 30.0,
				IsStarEf = new bool?(false),
				CoolingDownReductionOnStart = 0.3
			}
		};
	}
}
