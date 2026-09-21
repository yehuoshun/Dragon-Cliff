using System;
using UnityEngine;

// Token: 0x020009D5 RID: 2517
[Serializable]
public class StoryDetails
{
	// Token: 0x06004510 RID: 17680 RVA: 0x001BEE38 File Offset: 0x001BD238
	public StoryDetails()
	{
	}

	// Token: 0x04003424 RID: 13348
	public StoryIdentifier Identifier;

	// Token: 0x04003425 RID: 13349
	[TextArea]
	public string Details;
}
