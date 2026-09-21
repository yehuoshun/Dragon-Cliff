using System;

// Token: 0x020007F5 RID: 2037
[Serializable]
public class EmbracedShieldStunEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003B0E RID: 15118 RVA: 0x00179176 File Offset: 0x00177576
	public EmbracedShieldStunEnhancementData()
	{
	}

	// Token: 0x06003B0F RID: 15119 RVA: 0x0017917E File Offset: 0x0017757E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EmbracedShieldStunEnhancement;
	}

	// Token: 0x06003B10 RID: 15120 RVA: 0x00179188 File Offset: 0x00177588
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", this.StunSeconds.ToString());
		return description;
	}

	// Token: 0x06003B11 RID: 15121 RVA: 0x001791C9 File Offset: 0x001775C9
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B12 RID: 15122 RVA: 0x001791D1 File Offset: 0x001775D1
	public double GetEffectPowerValue()
	{
		return (double)this.StunSeconds;
	}

	// Token: 0x04002D7E RID: 11646
	public int StunSeconds;

	// Token: 0x04002D7F RID: 11647
	public bool IsStar;
}
