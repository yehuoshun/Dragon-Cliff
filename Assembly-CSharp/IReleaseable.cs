using System;
using System.Collections;

// Token: 0x0200072A RID: 1834
public interface IReleaseable
{
	// Token: 0x170007FB RID: 2043
	// (get) Token: 0x06003385 RID: 13189
	ReleaseStatus Status { get; }

	// Token: 0x06003386 RID: 13190
	IEnumerable Release();
}
