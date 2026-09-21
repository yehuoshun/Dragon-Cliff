using System;

// Token: 0x0200037C RID: 892
public static class Tuple
{
	// Token: 0x06001808 RID: 6152 RVA: 0x000B9463 File Offset: 0x000B7863
	public static Tuple<T, U> Create<T, U>(T first, U second)
	{
		return new Tuple<T, U>(first, second);
	}
}
