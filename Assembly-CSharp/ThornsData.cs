using System;

// Token: 0x02000898 RID: 2200
[Serializable]
public class ThornsData : ISpecialEffectDataLoad
{
	// Token: 0x06003E5E RID: 15966 RVA: 0x0018237D File Offset: 0x0018077D
	public ThornsData()
	{
	}

	// Token: 0x06003E5F RID: 15967 RVA: 0x00182385 File Offset: 0x00180785
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Thorns;
	}

	// Token: 0x06003E60 RID: 15968 RVA: 0x0018238C File Offset: 0x0018078C
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003E61 RID: 15969 RVA: 0x00182399 File Offset: 0x00180799
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003E62 RID: 15970 RVA: 0x0018239C File Offset: 0x0018079C
	public double GetEffectPowerValue()
	{
		return 1.0;
	}
}
