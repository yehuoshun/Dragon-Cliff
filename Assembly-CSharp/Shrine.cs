using System;

// Token: 0x0200047C RID: 1148
[Serializable]
public class Shrine : IBuildingProfile
{
	// Token: 0x060020B9 RID: 8377 RVA: 0x000E2DAD File Offset: 0x000E11AD
	public Shrine()
	{
	}

	// Token: 0x17000220 RID: 544
	// (get) Token: 0x060020BA RID: 8378 RVA: 0x000E2DB5 File Offset: 0x000E11B5
	public BuildingType BuildingType
	{
		get
		{
			return BuildingType.Shrine;
		}
	}

	// Token: 0x060020BB RID: 8379 RVA: 0x000E2DB8 File Offset: 0x000E11B8
	public void Process(float timeDelta)
	{
	}

	// Token: 0x17000221 RID: 545
	// (get) Token: 0x060020BC RID: 8380 RVA: 0x000E2DBA File Offset: 0x000E11BA
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x060020BD RID: 8381 RVA: 0x000E2DC2 File Offset: 0x000E11C2
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
	}

	// Token: 0x04001D04 RID: 7428
	public string _id;
}
