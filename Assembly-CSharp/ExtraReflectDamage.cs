using System;
using System.Collections.Generic;

// Token: 0x02000A36 RID: 2614
public class ExtraReflectDamage : AffixAttachmentRuleBase
{
	// Token: 0x0600473F RID: 18239 RVA: 0x001D190C File Offset: 0x001CFD0C
	public ExtraReflectDamage()
	{
	}

	// Token: 0x17000DDE RID: 3550
	// (get) Token: 0x06004740 RID: 18240 RVA: 0x001D1914 File Offset: 0x001CFD14
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraReflectDamage;
		}
	}

	// Token: 0x06004741 RID: 18241 RVA: 0x001D1918 File Offset: 0x001CFD18
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.ReflectiveDamage,
				Value = 0.20000000298023224
			}
		};
	}
}
