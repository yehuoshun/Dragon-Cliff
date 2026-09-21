using System;

// Token: 0x0200046E RID: 1134
[Serializable]
public class ForgingFacility : IBuildingProfile
{
	// Token: 0x0600201D RID: 8221 RVA: 0x000E0318 File Offset: 0x000DE718
	public ForgingFacility()
	{
	}

	// Token: 0x17000206 RID: 518
	// (get) Token: 0x0600201E RID: 8222 RVA: 0x000E0320 File Offset: 0x000DE720
	public BuildingType BuildingType
	{
		get
		{
			return BuildingType.ForgingFacility;
		}
	}

	// Token: 0x0600201F RID: 8223 RVA: 0x000E0324 File Offset: 0x000DE724
	public void Process(float timeDelta)
	{
	}

	// Token: 0x06002020 RID: 8224 RVA: 0x000E0326 File Offset: 0x000DE726
	public int GetLevel()
	{
		if (ResourceType.DragonBloodStone.HasObtained())
		{
			return 2;
		}
		return 1;
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06002021 RID: 8225 RVA: 0x000E033A File Offset: 0x000DE73A
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x06002022 RID: 8226 RVA: 0x000E0344 File Offset: 0x000DE744
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.ResourceUpdated && data is ResourceUpdateEvent)
		{
			ResourceUpdateEvent resourceUpdateEvent = data as ResourceUpdateEvent;
			if (resourceUpdateEvent.ResourceType == ResourceType.DragonBloodStone && this.Level == 1)
			{
				this.Level++;
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ForgeUpgraded, this.Level);
			}
		}
		if (evt == GameWorldEvent.BuildingConstructed && data is BuildingBuiltEvent && ResourceType.DragonBloodStone.HasObtained())
		{
			BuildingBuiltEvent buildingBuiltEvent = data as BuildingBuiltEvent;
			if (buildingBuiltEvent.Building is ForgingFacility)
			{
				ForgingFacility forgingFacility = buildingBuiltEvent.Building as ForgingFacility;
				if (forgingFacility.Level < 2)
				{
					forgingFacility.Level = 2;
					GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ForgeUpgraded, 2);
				}
			}
		}
	}

	// Token: 0x04001CB0 RID: 7344
	public int Level;

	// Token: 0x04001CB1 RID: 7345
	public string _id;
}
