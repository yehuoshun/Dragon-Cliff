using System;

// Token: 0x02000975 RID: 2421
public class DialogPresence : IPresentable
{
	// Token: 0x0600428D RID: 17037 RVA: 0x001B2EDF File Offset: 0x001B12DF
	public DialogPresence()
	{
	}

	// Token: 0x0600428E RID: 17038 RVA: 0x001B2EE7 File Offset: 0x001B12E7
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x040032C7 RID: 12999
	public DialogIdentifier DialogIdentifier;

	// Token: 0x040032C8 RID: 13000
	public UnitClass? SpecificUnit;

	// Token: 0x040032C9 RID: 13001
	public int Presence;
}
