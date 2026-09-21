using System;

// Token: 0x0200052F RID: 1327
public class DropTypePresence : IPresentable
{
	// Token: 0x060026DD RID: 9949 RVA: 0x001164FC File Offset: 0x001148FC
	public DropTypePresence()
	{
	}

	// Token: 0x060026DE RID: 9950 RVA: 0x00116504 File Offset: 0x00114904
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x0400215C RID: 8540
	public int Presence;

	// Token: 0x0400215D RID: 8541
	public DropType DropType;
}
