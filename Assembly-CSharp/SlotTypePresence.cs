using System;

// Token: 0x0200045E RID: 1118
public class SlotTypePresence : IPresentable
{
	// Token: 0x06001FBD RID: 8125 RVA: 0x000DEB7D File Offset: 0x000DCF7D
	public SlotTypePresence()
	{
	}

	// Token: 0x06001FBE RID: 8126 RVA: 0x000DEB85 File Offset: 0x000DCF85
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04001C65 RID: 7269
	public int Presence;

	// Token: 0x04001C66 RID: 7270
	public AdventureEncounterSlotType AdventureEncounterSlotType;
}
