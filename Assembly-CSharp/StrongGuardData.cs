using System;

// Token: 0x0200088A RID: 2186
[Serializable]
public class StrongGuardData : ISpecialEffectDataLoad
{
	// Token: 0x06003E18 RID: 15896 RVA: 0x00181D0E File Offset: 0x0018010E
	public StrongGuardData()
	{
	}

	// Token: 0x06003E19 RID: 15897 RVA: 0x00181D16 File Offset: 0x00180116
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.StrongGuard;
	}

	// Token: 0x06003E1A RID: 15898 RVA: 0x00181D1C File Offset: 0x0018011C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003E1B RID: 15899 RVA: 0x00181D5D File Offset: 0x0018015D
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E1C RID: 15900 RVA: 0x00181D65 File Offset: 0x00180165
	public double GetEffectPowerValue()
	{
		return (double)this.Seconds;
	}

	// Token: 0x04002F09 RID: 12041
	public int Seconds;

	// Token: 0x04002F0A RID: 12042
	public bool IsStar;
}
