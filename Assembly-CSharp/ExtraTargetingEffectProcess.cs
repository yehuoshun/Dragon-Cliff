using System;
using System.Collections.Generic;

// Token: 0x020008E2 RID: 2274
public class ExtraTargetingEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FB2 RID: 16306 RVA: 0x00193FE6 File Offset: 0x001923E6
	public ExtraTargetingEffectProcess()
	{
	}

	// Token: 0x17000B86 RID: 2950
	// (get) Token: 0x06003FB3 RID: 16307 RVA: 0x00193FF6 File Offset: 0x001923F6
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B87 RID: 2951
	// (get) Token: 0x06003FB4 RID: 16308 RVA: 0x00193FFE File Offset: 0x001923FE
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x04002F88 RID: 12168
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.ExtraTargetting;
}
