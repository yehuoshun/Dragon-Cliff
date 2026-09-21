using System;

// Token: 0x02000876 RID: 2166
[Serializable]
public class ShiftShieldData : ISpecialEffectDataLoad
{
	// Token: 0x06003DB8 RID: 15800 RVA: 0x001812D3 File Offset: 0x0017F6D3
	public ShiftShieldData()
	{
	}

	// Token: 0x06003DB9 RID: 15801 RVA: 0x001812DB File Offset: 0x0017F6DB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ShiftShield;
	}

	// Token: 0x06003DBA RID: 15802 RVA: 0x001812E0 File Offset: 0x0017F6E0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", this.NumberOfSecondsPerShift.ToString()).Replace("{elements}", this.NumberOfElements.ToString());
		return description;
	}

	// Token: 0x06003DBB RID: 15803 RVA: 0x0018133C File Offset: 0x0017F73C
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DBC RID: 15804 RVA: 0x00181344 File Offset: 0x0017F744
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfElements;
	}

	// Token: 0x04002ECD RID: 11981
	public int NumberOfSecondsPerShift;

	// Token: 0x04002ECE RID: 11982
	public int Counter;

	// Token: 0x04002ECF RID: 11983
	public int NumberOfElements;

	// Token: 0x04002ED0 RID: 11984
	public bool IsStar;
}
