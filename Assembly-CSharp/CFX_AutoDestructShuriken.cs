using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000C3 RID: 195
[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
	// Token: 0x06000607 RID: 1543 RVA: 0x000611B9 File Offset: 0x0005F5B9
	public CFX_AutoDestructShuriken()
	{
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x000611C1 File Offset: 0x0005F5C1
	private void OnEnable()
	{
		base.StartCoroutine("CheckIfAlive");
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x000611D0 File Offset: 0x0005F5D0
	private IEnumerator CheckIfAlive()
	{
		ParticleSystem ps = base.GetComponent<ParticleSystem>();
		while (true && ps != null)
		{
			yield return new WaitForSeconds(0.5f);
			if (!ps.IsAlive(true))
			{
				if (this.OnlyDeactivate)
				{
					base.gameObject.SetActive(false);
				}
				else
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			}
		}
		yield break;
	}

	// Token: 0x0400090B RID: 2315
	public bool OnlyDeactivate;

	// Token: 0x02000BCF RID: 3023
	[CompilerGenerated]
	private sealed class <CheckIfAlive>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600501E RID: 20510 RVA: 0x000611EB File Offset: 0x0005F5EB
		[DebuggerHidden]
		public <CheckIfAlive>c__Iterator0()
		{
		}

		// Token: 0x0600501F RID: 20511 RVA: 0x000611F4 File Offset: 0x0005F5F4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				ps = base.GetComponent<ParticleSystem>();
				break;
			case 1u:
				if (!ps.IsAlive(true))
				{
					if (this.OnlyDeactivate)
					{
						base.gameObject.SetActive(false);
					}
					else
					{
						UnityEngine.Object.Destroy(base.gameObject);
					}
					goto IL_BE;
				}
				break;
			default:
				return false;
			}
			if (true && ps != null)
			{
				this.$current = new WaitForSeconds(0.5f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}
			IL_BE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001108 RID: 4360
		// (get) Token: 0x06005020 RID: 20512 RVA: 0x000612C9 File Offset: 0x0005F6C9
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001109 RID: 4361
		// (get) Token: 0x06005021 RID: 20513 RVA: 0x000612D1 File Offset: 0x0005F6D1
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005022 RID: 20514 RVA: 0x000612D9 File Offset: 0x0005F6D9
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005023 RID: 20515 RVA: 0x000612E9 File Offset: 0x0005F6E9
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E20 RID: 15904
		internal ParticleSystem <ps>__0;

		// Token: 0x04003E21 RID: 15905
		internal CFX_AutoDestructShuriken $this;

		// Token: 0x04003E22 RID: 15906
		internal object $current;

		// Token: 0x04003E23 RID: 15907
		internal bool $disposing;

		// Token: 0x04003E24 RID: 15908
		internal int $PC;
	}
}
