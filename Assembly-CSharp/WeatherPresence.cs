using System;

// Token: 0x020004BE RID: 1214
public class WeatherPresence : IPresentable
{
	// Token: 0x060023D6 RID: 9174 RVA: 0x0010323B File Offset: 0x0010163B
	public WeatherPresence()
	{
	}

	// Token: 0x060023D7 RID: 9175 RVA: 0x00103243 File Offset: 0x00101643
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04001EFD RID: 7933
	public int Presence;

	// Token: 0x04001EFE RID: 7934
	public Weather Weather;
}
