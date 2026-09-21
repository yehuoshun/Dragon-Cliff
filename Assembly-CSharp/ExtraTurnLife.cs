using System;
using System.Collections.Generic;

// Token: 0x02000A39 RID: 2617
public class ExtraTurnLife : AffixAttachmentRuleBase
{
	// Token: 0x06004748 RID: 18248 RVA: 0x001D19DB File Offset: 0x001CFDDB
	public ExtraTurnLife()
	{
	}

	// Token: 0x17000DE1 RID: 3553
	// (get) Token: 0x06004749 RID: 18249 RVA: 0x001D19E3 File Offset: 0x001CFDE3
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraTurnRecovery;
		}
	}

	// Token: 0x0600474A RID: 18250 RVA: 0x001D19E8 File Offset: 0x001CFDE8
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.TurnStartHeal,
				Value = 0.070000000298023224
			}
		};
	}
}
