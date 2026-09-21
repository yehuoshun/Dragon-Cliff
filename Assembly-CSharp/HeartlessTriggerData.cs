using System;

// Token: 0x0200081F RID: 2079
[Serializable]
public class HeartlessTriggerData : ISpecialEffectDataLoad
{
	// Token: 0x06003BDC RID: 15324 RVA: 0x0017A48F File Offset: 0x0017888F
	public HeartlessTriggerData()
	{
	}

	// Token: 0x06003BDD RID: 15325 RVA: 0x0017A497 File Offset: 0x00178897
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HeartlessTrigger;
	}

	// Token: 0x06003BDE RID: 15326 RVA: 0x0017A49E File Offset: 0x0017889E
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003BDF RID: 15327 RVA: 0x0017A4AB File Offset: 0x001788AB
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BE0 RID: 15328 RVA: 0x0017A4B3 File Offset: 0x001788B3
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002DEA RID: 11754
	public bool IsStar;
}
