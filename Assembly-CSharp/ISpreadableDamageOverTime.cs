using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200075E RID: 1886
public interface ISpreadableDamageOverTime
{
	// Token: 0x060036B3 RID: 14003
	IEnumerable Spread(IBattleUnit fromUnit, List<IBattleUnit> tounits);
}
