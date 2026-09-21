using System;
using System.Collections.Generic;

// Token: 0x02000B3E RID: 2878
[Serializable]
public class CardUpgrade
{
	// Token: 0x06004C96 RID: 19606 RVA: 0x001F22CF File Offset: 0x001F06CF
	public CardUpgrade()
	{
	}

	// Token: 0x04003AF5 RID: 15093
	public int UpgradeLevelIndex;

	// Token: 0x04003AF6 RID: 15094
	public List<AttributeModifier> Modifiers;

	// Token: 0x04003AF7 RID: 15095
	public List<ISpecialEffectDataLoad> Effects;

	// Token: 0x04003AF8 RID: 15096
	public UpgradeCardType CorrespondingCardType;
}
