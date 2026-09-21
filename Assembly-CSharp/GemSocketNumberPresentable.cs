using System;

// Token: 0x02000534 RID: 1332
public class GemSocketNumberPresentable : IPresentable
{
	// Token: 0x060026F5 RID: 9973 RVA: 0x001165C5 File Offset: 0x001149C5
	public GemSocketNumberPresentable(int presence, int numberOfSockets)
	{
		this.Presence = presence;
		this.NumberOfSockets = numberOfSockets;
	}

	// Token: 0x060026F6 RID: 9974 RVA: 0x001165DB File Offset: 0x001149DB
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04002167 RID: 8551
	public int Presence;

	// Token: 0x04002168 RID: 8552
	public int NumberOfSockets;
}
