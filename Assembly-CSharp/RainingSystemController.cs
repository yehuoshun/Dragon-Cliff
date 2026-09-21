using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x0200014B RID: 331
public class RainingSystemController : MonoBehaviour
{
	// Token: 0x0600090E RID: 2318 RVA: 0x000796C7 File Offset: 0x00077AC7
	public RainingSystemController()
	{
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x000796E4 File Offset: 0x00077AE4
	private void Update()
	{
		this._t += Time.deltaTime;
		if (this._t > this.RainDropSecond)
		{
			float x = UnityEngine.Random.Range(this.MinX, this.MaxX);
			float y = UnityEngine.Random.Range(this.MinY, this.MaxY);
			int num = UnityEngine.Random.Range(0, 4);
			for (int i = 0; i < num; i++)
			{
				GameObject raindrop = ObjectPoolManager.Instance.Spawn(PoolType.RainDrop, new Vector3(x, y, 0f));
				base.StartCoroutine(this.DestroyRainDrop(raindrop));
			}
			this._t = 0f;
		}
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x00079788 File Offset: 0x00077B88
	private IEnumerator DestroyRainDrop(GameObject raindrop)
	{
		yield return new WaitForSeconds(0.5f);
		ObjectPoolManager.Instance.Destroy(PoolType.RainDrop, raindrop);
		yield break;
	}

	// Token: 0x04000BB5 RID: 2997
	public float RainDropSecond = 0.1f;

	// Token: 0x04000BB6 RID: 2998
	public int MaxRainDropAtATime = 5;

	// Token: 0x04000BB7 RID: 2999
	[Header("Screen Size")]
	public float MinX;

	// Token: 0x04000BB8 RID: 3000
	[Header("Screen Size")]
	public float MinY;

	// Token: 0x04000BB9 RID: 3001
	[Header("Screen Size")]
	public float MaxX;

	// Token: 0x04000BBA RID: 3002
	[Header("Screen Size")]
	public float MaxY;

	// Token: 0x04000BBB RID: 3003
	private float _t;

	// Token: 0x02000C1B RID: 3099
	[CompilerGenerated]
	private sealed class <DestroyRainDrop>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051F4 RID: 20980 RVA: 0x000797A3 File Offset: 0x00077BA3
		[DebuggerHidden]
		public <DestroyRainDrop>c__Iterator0()
		{
		}

		// Token: 0x060051F5 RID: 20981 RVA: 0x000797AC File Offset: 0x00077BAC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(0.5f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				ObjectPoolManager.Instance.Destroy(PoolType.RainDrop, raindrop);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001180 RID: 4480
		// (get) Token: 0x060051F6 RID: 20982 RVA: 0x00079819 File Offset: 0x00077C19
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001181 RID: 4481
		// (get) Token: 0x060051F7 RID: 20983 RVA: 0x00079821 File Offset: 0x00077C21
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051F8 RID: 20984 RVA: 0x00079829 File Offset: 0x00077C29
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051F9 RID: 20985 RVA: 0x00079839 File Offset: 0x00077C39
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004007 RID: 16391
		internal GameObject raindrop;

		// Token: 0x04004008 RID: 16392
		internal object $current;

		// Token: 0x04004009 RID: 16393
		internal bool $disposing;

		// Token: 0x0400400A RID: 16394
		internal int $PC;
	}
}
