using System;

// Token: 0x0200046F RID: 1135
public interface IBuildingProfile
{
	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06002023 RID: 8227
	BuildingType BuildingType { get; }

	// Token: 0x06002024 RID: 8228
	void Process(float timeDelta);

	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06002025 RID: 8229
	string Id { get; }

	// Token: 0x06002026 RID: 8230
	void ProcessEvent(GameWorldEvent evt, object data);
}
