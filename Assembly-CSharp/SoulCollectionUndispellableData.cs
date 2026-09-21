using System;

// Token: 0x0200087A RID: 2170
[Serializable]
public class SoulCollectionUndispellableData : ISpecialEffectDataLoad
{
	// Token: 0x06003DC8 RID: 15816 RVA: 0x0018148F File Offset: 0x0017F88F
	public SoulCollectionUndispellableData()
	{
	}

	// Token: 0x06003DC9 RID: 15817 RVA: 0x00181497 File Offset: 0x0017F897
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SoulCollectionUnDispellable;
	}

	// Token: 0x06003DCA RID: 15818 RVA: 0x0018149B File Offset: 0x0017F89B
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003DCB RID: 15819 RVA: 0x001814A8 File Offset: 0x0017F8A8
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DCC RID: 15820 RVA: 0x001814B0 File Offset: 0x0017F8B0
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002EDA RID: 11994
	public bool IsStar;
}
