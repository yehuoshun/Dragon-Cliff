using System;

// Token: 0x020007B3 RID: 1971
[Serializable]
public class ArmorOfWindNumberEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x060039BA RID: 14778 RVA: 0x00176B9F File Offset: 0x00174F9F
	public ArmorOfWindNumberEnhancementData()
	{
	}

	// Token: 0x060039BB RID: 14779 RVA: 0x00176BA7 File Offset: 0x00174FA7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ArmorOfWindNumberEnhancement;
	}

	// Token: 0x060039BC RID: 14780 RVA: 0x00176BB0 File Offset: 0x00174FB0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{extra}", this.Extra.ToString());
		return description;
	}

	// Token: 0x060039BD RID: 14781 RVA: 0x00176BF1 File Offset: 0x00174FF1
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039BE RID: 14782 RVA: 0x00176BF9 File Offset: 0x00174FF9
	public double GetEffectPowerValue()
	{
		return (double)this.Extra;
	}

	// Token: 0x04002CA6 RID: 11430
	public int Extra;

	// Token: 0x04002CA7 RID: 11431
	public bool IsStar;
}
