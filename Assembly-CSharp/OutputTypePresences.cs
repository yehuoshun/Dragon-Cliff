using System;

// Token: 0x02000B15 RID: 2837
public class OutputTypePresences : IPresentable
{
	// Token: 0x06004BEF RID: 19439 RVA: 0x001F16F8 File Offset: 0x001EFAF8
	public OutputTypePresences(int presence, OutputType outputType)
	{
		this.Presence = presence;
		this.OutputType = outputType;
	}

	// Token: 0x06004BF0 RID: 19440 RVA: 0x001F170E File Offset: 0x001EFB0E
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04003ADF RID: 15071
	public int Presence;

	// Token: 0x04003AE0 RID: 15072
	public OutputType OutputType;
}
