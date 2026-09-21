using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200045D RID: 1117
[Serializable]
public class MonsterAppearance : IPresentable
{
	// Token: 0x06001FB9 RID: 8121 RVA: 0x000DEB4E File Offset: 0x000DCF4E
	public MonsterAppearance(int presence, UnitClass unitClass)
	{
		this.Presence = presence;
		this.UnitClass = unitClass;
	}

	// Token: 0x06001FBA RID: 8122 RVA: 0x000DEB64 File Offset: 0x000DCF64
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x06001FBB RID: 8123 RVA: 0x000DEB6C File Offset: 0x000DCF6C
	// (set) Token: 0x06001FBC RID: 8124 RVA: 0x000DEB74 File Offset: 0x000DCF74
	public UnitClass UnitClass
	{
		[CompilerGenerated]
		get
		{
			return this.<UnitClass>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UnitClass>k__BackingField = value;
		}
	}

	// Token: 0x04001C63 RID: 7267
	public int Presence;

	// Token: 0x04001C64 RID: 7268
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitClass <UnitClass>k__BackingField;
}
