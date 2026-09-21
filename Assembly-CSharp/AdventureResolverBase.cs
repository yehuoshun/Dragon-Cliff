using System;
using System.Collections.Generic;

// Token: 0x0200044E RID: 1102
public abstract class AdventureResolverBase
{
	// Token: 0x06001F42 RID: 8002 RVA: 0x000DBF52 File Offset: 0x000DA352
	protected AdventureResolverBase()
	{
	}

	// Token: 0x06001F43 RID: 8003
	public abstract bool CanBeResolved(AdventureStartParameter parameter);

	// Token: 0x06001F44 RID: 8004
	protected abstract Adventure ResolveLogic(AdventureStartParameter parameter);

	// Token: 0x06001F45 RID: 8005
	public abstract List<ISpecialEffectDataLoad> GetDungeonSpecialEffects(AdventureStartParameter parameter);

	// Token: 0x06001F46 RID: 8006 RVA: 0x000DBF5A File Offset: 0x000DA35A
	public Adventure Resolve(AdventureStartParameter parameter)
	{
		if (this.CanBeResolved(parameter))
		{
			return this.ResolveLogic(parameter);
		}
		throw new Exception("Cannot resolve, check canberesolved first");
	}

	// Token: 0x06001F47 RID: 8007
	public abstract int ResolverPrecedenceValue();
}
