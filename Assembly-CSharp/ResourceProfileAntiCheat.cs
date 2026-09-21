using System;
using CodeStage.AntiCheat.ObscuredTypes;

// Token: 0x02000684 RID: 1668
public class ResourceProfileAntiCheat
{
	// Token: 0x06002C8C RID: 11404 RVA: 0x00123C82 File Offset: 0x00122082
	public ResourceProfileAntiCheat()
	{
	}

	// Token: 0x06002C8D RID: 11405 RVA: 0x00123C8A File Offset: 0x0012208A
	public ObscuredDouble GetValue()
	{
		return this.Amount / PlayerProfile.CurrentKey;
	}

	// Token: 0x06002C8E RID: 11406 RVA: 0x00123CA2 File Offset: 0x001220A2
	public void ChangeValue(double change)
	{
		this.Amount += change * PlayerProfile.CurrentKey;
	}

	// Token: 0x06002C8F RID: 11407 RVA: 0x00123CC2 File Offset: 0x001220C2
	public void SetValue(double value)
	{
		this.Amount = value * PlayerProfile.CurrentKey;
	}

	// Token: 0x0400236B RID: 9067
	public ResourceType ResourceType;

	// Token: 0x0400236C RID: 9068
	public ObscuredDouble Amount;
}
