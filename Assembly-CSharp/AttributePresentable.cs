using System;

// Token: 0x02000689 RID: 1673
public class AttributePresentable : IPresentable
{
	// Token: 0x06002CA6 RID: 11430 RVA: 0x00125EC2 File Offset: 0x001242C2
	public AttributePresentable(int presence, AttributeType attributeType)
	{
		this.Presence = presence;
		this.AttributeType = attributeType;
	}

	// Token: 0x06002CA7 RID: 11431 RVA: 0x00125ED8 File Offset: 0x001242D8
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04002686 RID: 9862
	public int Presence;

	// Token: 0x04002687 RID: 9863
	public AttributeType AttributeType;
}
