using System;
using System.Collections.Generic;

// Token: 0x0200068E RID: 1678
public class EvilHeartGenerator : GemGeneratorBase
{
	// Token: 0x06002CB4 RID: 11444 RVA: 0x001261AB File Offset: 0x001245AB
	public EvilHeartGenerator()
	{
	}

	// Token: 0x17000596 RID: 1430
	// (get) Token: 0x06002CB5 RID: 11445 RVA: 0x001261B3 File Offset: 0x001245B3
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return ResourceType.EvilHeart;
		}
	}

	// Token: 0x06002CB6 RID: 11446 RVA: 0x001261BC File Offset: 0x001245BC
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Strength),
			new AttributePresentable(100, AttributeType.Intelligience),
			new AttributePresentable(100, AttributeType.CritDamage),
			new AttributePresentable(100, AttributeType.DealIceDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealLightningDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealPhysicalDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.Allresistances),
			new AttributePresentable(100, AttributeType.EffectMastery),
			new AttributePresentable(100, AttributeType.EffectResistanceRating)
		};
	}
}
