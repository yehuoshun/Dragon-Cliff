using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200032E RID: 814
public class GameCounter : MonoBehaviour
{
	// Token: 0x060015A6 RID: 5542 RVA: 0x000AC1F2 File Offset: 0x000AA5F2
	public GameCounter()
	{
	}

	// Token: 0x060015A7 RID: 5543 RVA: 0x000AC214 File Offset: 0x000AA614
	private void Awake()
	{
		if (GameCounter.instance == null)
		{
			GameCounter.instance = this;
		}
		else if (GameCounter.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060015A8 RID: 5544 RVA: 0x000AC24C File Offset: 0x000AA64C
	private void Start()
	{
		this.HighlightIndex = 0;
		if (base.isActiveAndEnabled)
		{
			base.StartCoroutine(this.Counter());
		}
	}

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x060015A9 RID: 5545 RVA: 0x000AC26D File Offset: 0x000AA66D
	// (set) Token: 0x060015AA RID: 5546 RVA: 0x000AC275 File Offset: 0x000AA675
	public int HighlightIndex
	{
		[CompilerGenerated]
		get
		{
			return this.<HighlightIndex>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<HighlightIndex>k__BackingField = value;
		}
	}

	// Token: 0x060015AB RID: 5547 RVA: 0x000AC280 File Offset: 0x000AA680
	private IEnumerator Counter()
	{
		for (;;)
		{
			IEnumerator enumerator = this.StartCount().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x060015AC RID: 5548 RVA: 0x000AC29C File Offset: 0x000AA69C
	private IEnumerable StartCount()
	{
		if (this.HighlightIndex == 4)
		{
			this.HighlightIndex = 0;
		}
		else
		{
			this.HighlightIndex++;
		}
		yield return new WaitForSeconds(0.1f);
		yield break;
	}

	// Token: 0x060015AD RID: 5549 RVA: 0x000AC2BF File Offset: 0x000AA6BF
	private void Update()
	{
		base.transform.Rotate(this.RotationPerSecond * Time.deltaTime);
	}

	// Token: 0x060015AE RID: 5550 RVA: 0x000AC2DC File Offset: 0x000AA6DC
	public Transform GetCurrent()
	{
		return base.transform;
	}

	// Token: 0x040015C6 RID: 5574
	public static GameCounter instance;

	// Token: 0x040015C7 RID: 5575
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <HighlightIndex>k__BackingField;

	// Token: 0x040015C8 RID: 5576
	public Vector3 RotationPerSecond = new Vector3(0f, 0f, -180f);

	// Token: 0x02000C93 RID: 3219
	[CompilerGenerated]
	private sealed class <Counter>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600534B RID: 21323 RVA: 0x000AC2E4 File Offset: 0x000AA6E4
		[DebuggerHidden]
		public <Counter>c__Iterator0()
		{
		}

		// Token: 0x0600534C RID: 21324 RVA: 0x000AC2EC File Offset: 0x000AA6EC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				break;
			case 1u:
				goto IL_3C;
			default:
				return false;
			}
			IL_23:
			enumerator = base.StartCount().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_3C:
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			goto IL_23;
		}

		// Token: 0x170011A4 RID: 4516
		// (get) Token: 0x0600534D RID: 21325 RVA: 0x000AC3D8 File Offset: 0x000AA7D8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011A5 RID: 4517
		// (get) Token: 0x0600534E RID: 21326 RVA: 0x000AC3E0 File Offset: 0x000AA7E0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600534F RID: 21327 RVA: 0x000AC3E8 File Offset: 0x000AA7E8
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005350 RID: 21328 RVA: 0x000AC458 File Offset: 0x000AA858
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040040D9 RID: 16601
		internal IEnumerator $locvar0;

		// Token: 0x040040DA RID: 16602
		internal object <_>__1;

		// Token: 0x040040DB RID: 16603
		internal IDisposable $locvar1;

		// Token: 0x040040DC RID: 16604
		internal GameCounter $this;

		// Token: 0x040040DD RID: 16605
		internal object $current;

		// Token: 0x040040DE RID: 16606
		internal bool $disposing;

		// Token: 0x040040DF RID: 16607
		internal int $PC;
	}

	// Token: 0x02000C94 RID: 3220
	[CompilerGenerated]
	private sealed class <StartCount>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005351 RID: 21329 RVA: 0x000AC45F File Offset: 0x000AA85F
		[DebuggerHidden]
		public <StartCount>c__Iterator1()
		{
		}

		// Token: 0x06005352 RID: 21330 RVA: 0x000AC468 File Offset: 0x000AA868
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				if (base.HighlightIndex == 4)
				{
					base.HighlightIndex = 0;
				}
				else
				{
					base.HighlightIndex++;
				}
				this.$current = new WaitForSeconds(0.1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011A6 RID: 4518
		// (get) Token: 0x06005353 RID: 21331 RVA: 0x000AC4F9 File Offset: 0x000AA8F9
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011A7 RID: 4519
		// (get) Token: 0x06005354 RID: 21332 RVA: 0x000AC501 File Offset: 0x000AA901
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005355 RID: 21333 RVA: 0x000AC509 File Offset: 0x000AA909
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005356 RID: 21334 RVA: 0x000AC519 File Offset: 0x000AA919
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005357 RID: 21335 RVA: 0x000AC520 File Offset: 0x000AA920
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005358 RID: 21336 RVA: 0x000AC528 File Offset: 0x000AA928
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GameCounter.<StartCount>c__Iterator1 <StartCount>c__Iterator = new GameCounter.<StartCount>c__Iterator1();
			<StartCount>c__Iterator.$this = this;
			return <StartCount>c__Iterator;
		}

		// Token: 0x040040E0 RID: 16608
		internal GameCounter $this;

		// Token: 0x040040E1 RID: 16609
		internal object $current;

		// Token: 0x040040E2 RID: 16610
		internal bool $disposing;

		// Token: 0x040040E3 RID: 16611
		internal int $PC;
	}
}
