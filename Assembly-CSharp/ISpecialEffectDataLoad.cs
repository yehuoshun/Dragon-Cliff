using System;

// Token: 0x020008F8 RID: 2296
public interface ISpecialEffectDataLoad
{
	// Token: 0x0600400E RID: 16398
	SpecialEffectType GetSpecialEffectType();

	// Token: 0x0600400F RID: 16399
	Description GetDescription();

	// Token: 0x06004010 RID: 16400
	bool IsStarEffect();

	// Token: 0x06004011 RID: 16401
	double GetEffectPowerValue();
}
