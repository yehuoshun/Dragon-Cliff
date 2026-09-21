using System;

// Token: 0x0200082D RID: 2093
[Serializable]
public class LifeRegenData : ISpecialEffectDataLoad
{
	// Token: 0x06003C1F RID: 15391 RVA: 0x0017AB47 File Offset: 0x00178F47
	public LifeRegenData()
	{
	}

	// Token: 0x06003C20 RID: 15392 RVA: 0x0017AB4F File Offset: 0x00178F4F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.LifeRegen;
	}

	// Token: 0x06003C21 RID: 15393 RVA: 0x0017AB53 File Offset: 0x00178F53
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003C22 RID: 15394 RVA: 0x0017AB60 File Offset: 0x00178F60
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003C23 RID: 15395 RVA: 0x0017AB63 File Offset: 0x00178F63
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002E14 RID: 11796
	public bool TriggeredInBattle;
}
