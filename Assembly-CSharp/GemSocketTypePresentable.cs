using System;

// Token: 0x02000535 RID: 1333
public class GemSocketTypePresentable : IPresentable
{
	// Token: 0x060026F7 RID: 9975 RVA: 0x001165E3 File Offset: 0x001149E3
	public GemSocketTypePresentable(int presence, SocketType socketType)
	{
		this.Presence = presence;
		this.SocketType = socketType;
	}

	// Token: 0x060026F8 RID: 9976 RVA: 0x001165F9 File Offset: 0x001149F9
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04002169 RID: 8553
	public int Presence;

	// Token: 0x0400216A RID: 8554
	public SocketType SocketType;
}
