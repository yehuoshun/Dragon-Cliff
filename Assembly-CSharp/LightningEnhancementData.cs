using System;

// Token: 0x0200082E RID: 2094
[Serializable]
public class LightningEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003C24 RID: 15396 RVA: 0x0017AB6E File Offset: 0x00178F6E
	public LightningEnhancementData()
	{
	}

	// Token: 0x06003C25 RID: 15397 RVA: 0x0017AB76 File Offset: 0x00178F76
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.LightningEnhancement;
	}

	// Token: 0x06003C26 RID: 15398 RVA: 0x0017AB80 File Offset: 0x00178F80
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.SpreadNumber.ToString());
		return description;
	}

	// Token: 0x06003C27 RID: 15399 RVA: 0x0017ABC1 File Offset: 0x00178FC1
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C28 RID: 15400 RVA: 0x0017ABC9 File Offset: 0x00178FC9
	public double GetEffectPowerValue()
	{
		return (double)this.SpreadNumber;
	}

	// Token: 0x04002E15 RID: 11797
	public int SpreadNumber;

	// Token: 0x04002E16 RID: 11798
	public bool IsStar;
}
