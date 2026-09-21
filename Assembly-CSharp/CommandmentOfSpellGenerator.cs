using System;
using System.Collections.Generic;

// Token: 0x0200068B RID: 1675
public class CommandmentOfSpellGenerator : GemGeneratorBase
{
	// Token: 0x06002CAB RID: 11435 RVA: 0x00125F89 File Offset: 0x00124389
	public CommandmentOfSpellGenerator()
	{
	}

	// Token: 0x17000593 RID: 1427
	// (get) Token: 0x06002CAC RID: 11436 RVA: 0x00125F91 File Offset: 0x00124391
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return ResourceType.CommandmentOfSpell;
		}
	}

	// Token: 0x06002CAD RID: 11437 RVA: 0x00125F98 File Offset: 0x00124398
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Intelligience),
			new AttributePresentable(100, AttributeType.CritDamage),
			new AttributePresentable(100, AttributeType.Agility),
			new AttributePresentable(100, AttributeType.DealDivineDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealFireDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealShadowDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealIceDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealLightningDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.EffectResistanceRating)
		};
	}
}
