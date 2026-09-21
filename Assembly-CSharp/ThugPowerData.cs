using System;

// Token: 0x0200089D RID: 2205
[Serializable]
public class ThugPowerData : ISpecialEffectDataLoad
{
	// Token: 0x06003E77 RID: 15991 RVA: 0x00182617 File Offset: 0x00180A17
	public ThugPowerData()
	{
	}

	// Token: 0x06003E78 RID: 15992 RVA: 0x0018261F File Offset: 0x00180A1F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ThugPower;
	}

	// Token: 0x06003E79 RID: 15993 RVA: 0x00182623 File Offset: 0x00180A23
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003E7A RID: 15994 RVA: 0x00182630 File Offset: 0x00180A30
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E7B RID: 15995 RVA: 0x00182638 File Offset: 0x00180A38
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002F3F RID: 12095
	public bool IsStar;
}
