using System;

// Token: 0x020007E8 RID: 2024
[Serializable]
public class DomineeringData : ISpecialEffectDataLoad
{
	// Token: 0x06003ACC RID: 15052 RVA: 0x00178A4B File Offset: 0x00176E4B
	public DomineeringData()
	{
	}

	// Token: 0x06003ACD RID: 15053 RVA: 0x00178A53 File Offset: 0x00176E53
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Domineering;
	}

	// Token: 0x06003ACE RID: 15054 RVA: 0x00178A5C File Offset: 0x00176E5C
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003ACF RID: 15055 RVA: 0x00178A76 File Offset: 0x00176E76
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003AD0 RID: 15056 RVA: 0x00178A79 File Offset: 0x00176E79
	public double GetEffectPowerValue()
	{
		return 1.0;
	}
}
