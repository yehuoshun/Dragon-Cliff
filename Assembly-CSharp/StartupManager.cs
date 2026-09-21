using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020009FB RID: 2555
public class StartupManager : MonoBehaviour
{
	// Token: 0x0600457C RID: 17788 RVA: 0x001C1B21 File Offset: 0x001BFF21
	public StartupManager()
	{
	}

	// Token: 0x0600457D RID: 17789 RVA: 0x001C1B2C File Offset: 0x001BFF2C
	private IEnumerator Start()
	{
		yield break;
	}

	// Token: 0x02001039 RID: 4153
	[CompilerGenerated]
	private sealed class <Start>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600683A RID: 26682 RVA: 0x001C1B40 File Offset: 0x001BFF40
		[DebuggerHidden]
		public <Start>c__Iterator0()
		{
		}

		// Token: 0x0600683B RID: 26683 RVA: 0x001C1B48 File Offset: 0x001BFF48
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170015C7 RID: 5575
		// (get) Token: 0x0600683C RID: 26684 RVA: 0x001C1B62 File Offset: 0x001BFF62
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015C8 RID: 5576
		// (get) Token: 0x0600683D RID: 26685 RVA: 0x001C1B6A File Offset: 0x001BFF6A
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600683E RID: 26686 RVA: 0x001C1B72 File Offset: 0x001BFF72
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600683F RID: 26687 RVA: 0x001C1B74 File Offset: 0x001BFF74
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04006204 RID: 25092
		internal object $current;

		// Token: 0x04006205 RID: 25093
		internal bool $disposing;

		// Token: 0x04006206 RID: 25094
		internal int $PC;
	}
}
