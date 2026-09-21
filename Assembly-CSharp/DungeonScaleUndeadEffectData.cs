using System;
using System.Collections.Generic;

// Token: 0x020007EC RID: 2028
[Serializable]
public class DungeonScaleUndeadEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003AE0 RID: 15072 RVA: 0x00178BFF File Offset: 0x00176FFF
	public DungeonScaleUndeadEffectData()
	{
	}

	// Token: 0x06003AE1 RID: 15073 RVA: 0x00178C07 File Offset: 0x00177007
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003AE2 RID: 15074 RVA: 0x00178C27 File Offset: 0x00177027
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003AE3 RID: 15075 RVA: 0x00178C32 File Offset: 0x00177032
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DungeonScaleUndeadEffect;
	}

	// Token: 0x06003AE4 RID: 15076 RVA: 0x00178C38 File Offset: 0x00177038
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{reviverate}", this.ReviveRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002D6C RID: 11628
	public double ReviveRate;

	// Token: 0x04002D6D RID: 11629
	[NonSerialized]
	public List<IBattleUnit> RevivedUnitsInCurrentEncounter;

	// Token: 0x04002D6E RID: 11630
	public bool? IsStarEf;
}
