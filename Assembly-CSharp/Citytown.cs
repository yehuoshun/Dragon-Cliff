using System;

// Token: 0x0200046C RID: 1132
[Serializable]
public class Citytown : IBuildingProfile
{
	// Token: 0x06002017 RID: 8215 RVA: 0x000E02F9 File Offset: 0x000DE6F9
	public Citytown()
	{
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06002018 RID: 8216 RVA: 0x000E0301 File Offset: 0x000DE701
	public BuildingType BuildingType
	{
		get
		{
			return BuildingType.CityTown;
		}
	}

	// Token: 0x06002019 RID: 8217 RVA: 0x000E0304 File Offset: 0x000DE704
	public void Process(float timeDelta)
	{
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x0600201A RID: 8218 RVA: 0x000E0306 File Offset: 0x000DE706
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x0600201B RID: 8219 RVA: 0x000E030E File Offset: 0x000DE70E
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
	}

	// Token: 0x04001CAE RID: 7342
	public string _id;
}
