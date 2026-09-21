using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020004C7 RID: 1223
public class Possibility<T> where T : IPresentable
{
	// Token: 0x060024B3 RID: 9395 RVA: 0x0010AE94 File Offset: 0x00109294
	public Possibility()
	{
	}

	// Token: 0x17000273 RID: 627
	// (get) Token: 0x060024B4 RID: 9396 RVA: 0x0010AE9C File Offset: 0x0010929C
	// (set) Token: 0x060024B5 RID: 9397 RVA: 0x0010AEA4 File Offset: 0x001092A4
	public int InclusiveFrom
	{
		[CompilerGenerated]
		get
		{
			return this.<InclusiveFrom>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<InclusiveFrom>k__BackingField = value;
		}
	}

	// Token: 0x17000274 RID: 628
	// (get) Token: 0x060024B6 RID: 9398 RVA: 0x0010AEAD File Offset: 0x001092AD
	// (set) Token: 0x060024B7 RID: 9399 RVA: 0x0010AEB5 File Offset: 0x001092B5
	public int ExclusiveTo
	{
		[CompilerGenerated]
		get
		{
			return this.<ExclusiveTo>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ExclusiveTo>k__BackingField = value;
		}
	}

	// Token: 0x17000275 RID: 629
	// (get) Token: 0x060024B8 RID: 9400 RVA: 0x0010AEBE File Offset: 0x001092BE
	// (set) Token: 0x060024B9 RID: 9401 RVA: 0x0010AEC6 File Offset: 0x001092C6
	public T PossiblityParameter
	{
		[CompilerGenerated]
		get
		{
			return this.<PossiblityParameter>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PossiblityParameter>k__BackingField = value;
		}
	}

	// Token: 0x060024BA RID: 9402 RVA: 0x0010AED0 File Offset: 0x001092D0
	public static T Select(List<T> possibilities)
	{
		if (possibilities.Any((T p) => p.GetPresence() > 0))
		{
			List<Possibility<T>> list = new List<Possibility<T>>();
			int num = 0;
			foreach (T possiblityParameter in possibilities)
			{
				list.Add(new Possibility<T>
				{
					InclusiveFrom = num,
					ExclusiveTo = num + possiblityParameter.GetPresence(),
					PossiblityParameter = possiblityParameter
				});
				num += possiblityParameter.GetPresence();
			}
			int exclusiveTo = list.Last<Possibility<T>>().ExclusiveTo;
			int roll = UnityEngine.Random.Range(0, exclusiveTo);
			return list.First((Possibility<T> p) => p.InclusiveFrom <= roll && roll < p.ExclusiveTo).PossiblityParameter;
		}
		throw new Exception("Invalid list: 0 items");
	}

	// Token: 0x060024BB RID: 9403 RVA: 0x0010AFDC File Offset: 0x001093DC
	[CompilerGenerated]
	private static bool <Select>m__0(T p)
	{
		return p.GetPresence() > 0;
	}

	// Token: 0x04001FA5 RID: 8101
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <InclusiveFrom>k__BackingField;

	// Token: 0x04001FA6 RID: 8102
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <ExclusiveTo>k__BackingField;

	// Token: 0x04001FA7 RID: 8103
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private T <PossiblityParameter>k__BackingField;

	// Token: 0x04001FA8 RID: 8104
	[CompilerGenerated]
	private static Func<T, bool> <>f__am$cache0;

	// Token: 0x02000DAE RID: 3502
	[CompilerGenerated]
	private sealed class <Select>c__AnonStorey0
	{
		// Token: 0x06005869 RID: 22633 RVA: 0x0010AFEE File Offset: 0x001093EE
		public <Select>c__AnonStorey0()
		{
		}

		// Token: 0x0600586A RID: 22634 RVA: 0x0010AFF6 File Offset: 0x001093F6
		internal bool <>m__0(Possibility<T> p)
		{
			return p.InclusiveFrom <= this.roll && this.roll < p.ExclusiveTo;
		}

		// Token: 0x04004855 RID: 18517
		internal int roll;
	}
}
