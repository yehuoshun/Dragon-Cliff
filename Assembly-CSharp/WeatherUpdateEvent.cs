using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004BF RID: 1215
public class WeatherUpdateEvent
{
	// Token: 0x060023D8 RID: 9176 RVA: 0x0010324B File Offset: 0x0010164B
	public WeatherUpdateEvent()
	{
	}

	// Token: 0x17000270 RID: 624
	// (get) Token: 0x060023D9 RID: 9177 RVA: 0x00103253 File Offset: 0x00101653
	// (set) Token: 0x060023DA RID: 9178 RVA: 0x0010325B File Offset: 0x0010165B
	public Weather PreviousWeather
	{
		[CompilerGenerated]
		get
		{
			return this.<PreviousWeather>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PreviousWeather>k__BackingField = value;
		}
	}

	// Token: 0x17000271 RID: 625
	// (get) Token: 0x060023DB RID: 9179 RVA: 0x00103264 File Offset: 0x00101664
	// (set) Token: 0x060023DC RID: 9180 RVA: 0x0010326C File Offset: 0x0010166C
	public Weather NewWeather
	{
		[CompilerGenerated]
		get
		{
			return this.<NewWeather>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NewWeather>k__BackingField = value;
		}
	}

	// Token: 0x04001EFF RID: 7935
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Weather <PreviousWeather>k__BackingField;

	// Token: 0x04001F00 RID: 7936
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Weather <NewWeather>k__BackingField;
}
