using System;

// Token: 0x02000469 RID: 1129
[Serializable]
public class BarrackYard : IBuildingProfile
{
	// Token: 0x06002012 RID: 8210 RVA: 0x000E02E1 File Offset: 0x000DE6E1
	public BarrackYard()
	{
	}

	// Token: 0x17000202 RID: 514
	// (get) Token: 0x06002013 RID: 8211 RVA: 0x000E02E9 File Offset: 0x000DE6E9
	public BuildingType BuildingType
	{
		get
		{
			return BuildingType.BarrackYard;
		}
	}

	// Token: 0x06002014 RID: 8212 RVA: 0x000E02ED File Offset: 0x000DE6ED
	public void Process(float timeDelta)
	{
	}

	// Token: 0x17000203 RID: 515
	// (get) Token: 0x06002015 RID: 8213 RVA: 0x000E02EF File Offset: 0x000DE6EF
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x06002016 RID: 8214 RVA: 0x000E02F7 File Offset: 0x000DE6F7
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
	}

	// Token: 0x04001C9E RID: 7326
	public string _id;
}
