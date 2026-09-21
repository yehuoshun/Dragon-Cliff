using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000533 RID: 1331
public class EssenceUsability
{
	// Token: 0x060026F0 RID: 9968 RVA: 0x0011659B File Offset: 0x0011499B
	public EssenceUsability()
	{
	}

	// Token: 0x17000301 RID: 769
	// (get) Token: 0x060026F1 RID: 9969 RVA: 0x001165A3 File Offset: 0x001149A3
	// (set) Token: 0x060026F2 RID: 9970 RVA: 0x001165AB File Offset: 0x001149AB
	public AdventurerProfile AdventurerProfile
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerProfile>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventurerProfile>k__BackingField = value;
		}
	}

	// Token: 0x17000302 RID: 770
	// (get) Token: 0x060026F3 RID: 9971 RVA: 0x001165B4 File Offset: 0x001149B4
	// (set) Token: 0x060026F4 RID: 9972 RVA: 0x001165BC File Offset: 0x001149BC
	public bool Usable
	{
		[CompilerGenerated]
		get
		{
			return this.<Usable>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Usable>k__BackingField = value;
		}
	}

	// Token: 0x04002165 RID: 8549
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <AdventurerProfile>k__BackingField;

	// Token: 0x04002166 RID: 8550
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <Usable>k__BackingField;
}
