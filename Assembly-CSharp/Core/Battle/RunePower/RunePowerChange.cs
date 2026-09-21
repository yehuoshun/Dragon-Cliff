using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Core.Battle.RunePower
{
	// Token: 0x02000462 RID: 1122
	public class RunePowerChange
	{
		// Token: 0x06001FE7 RID: 8167 RVA: 0x000DF2F0 File Offset: 0x000DD6F0
		public RunePowerChange()
		{
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06001FE8 RID: 8168 RVA: 0x000DF2F8 File Offset: 0x000DD6F8
		// (set) Token: 0x06001FE9 RID: 8169 RVA: 0x000DF300 File Offset: 0x000DD700
		public RunePowerType Type
		{
			[CompilerGenerated]
			get
			{
				return this.<Type>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Type>k__BackingField = value;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06001FEA RID: 8170 RVA: 0x000DF309 File Offset: 0x000DD709
		// (set) Token: 0x06001FEB RID: 8171 RVA: 0x000DF311 File Offset: 0x000DD711
		public int Amount
		{
			[CompilerGenerated]
			get
			{
				return this.<Amount>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Amount>k__BackingField = value;
			}
		}

		// Token: 0x04001C82 RID: 7298
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private RunePowerType <Type>k__BackingField;

		// Token: 0x04001C83 RID: 7299
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int <Amount>k__BackingField;
	}
}
