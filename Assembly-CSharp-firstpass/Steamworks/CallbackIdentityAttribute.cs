using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Steamworks
{
	// Token: 0x0200003A RID: 58
	[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
	internal class CallbackIdentityAttribute : Attribute
	{
		// Token: 0x06000334 RID: 820 RVA: 0x0000FA3F File Offset: 0x0000DE3F
		public CallbackIdentityAttribute(int callbackNum)
		{
			this.Identity = callbackNum;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0000FA4E File Offset: 0x0000DE4E
		// (set) Token: 0x06000336 RID: 822 RVA: 0x0000FA56 File Offset: 0x0000DE56
		public int Identity
		{
			[CompilerGenerated]
			get
			{
				return this.<Identity>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Identity>k__BackingField = value;
			}
		}

		// Token: 0x0400019A RID: 410
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int <Identity>k__BackingField;
	}
}
