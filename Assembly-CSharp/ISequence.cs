using System;
using System.Collections;

// Token: 0x0200096B RID: 2411
public interface ISequence
{
	// Token: 0x06004260 RID: 16992
	IEnumerable RunSequence(BroadcastEvent evt, GenericBattleSequenceBase sequenceRunner);
}
