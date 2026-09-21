using System;

// Token: 0x020004FB RID: 1275
public interface IResidentEffect
{
	// Token: 0x170002A2 RID: 674
	// (get) Token: 0x060025CE RID: 9678
	ResidentEffectType CorrespondingEffectType { get; }

	// Token: 0x060025CF RID: 9679
	bool IsUnique();

	// Token: 0x060025D0 RID: 9680
	void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data);
}
