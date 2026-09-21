using System;

// Token: 0x02000537 RID: 1335
[Serializable]
public class ItemSocket
{
	// Token: 0x06002700 RID: 9984 RVA: 0x00116672 File Offset: 0x00114A72
	public ItemSocket()
	{
	}

	// Token: 0x06002701 RID: 9985 RVA: 0x0011667A File Offset: 0x00114A7A
	public bool IsEmptySocket()
	{
		return this.Gem is NullObject;
	}

	// Token: 0x0400216D RID: 8557
	public NullableObject Gem;

	// Token: 0x0400216E RID: 8558
	public SocketType SocketType;

	// Token: 0x0400216F RID: 8559
	public SocketSourceType SourceType;
}
