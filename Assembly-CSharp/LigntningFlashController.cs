using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200014A RID: 330
public class LigntningFlashController : MonoBehaviour
{
	// Token: 0x0600090A RID: 2314 RVA: 0x000794AF File Offset: 0x000778AF
	public LigntningFlashController()
	{
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x000794DF File Offset: 0x000778DF
	private void Start()
	{
		this._renderer = base.GetComponent<SpriteRenderer>();
		this._orignialColor = this._renderer.color;
		this._thunderSound = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x0007950C File Offset: 0x0007790C
	private void Update()
	{
		if (Time.time - this._lastTime > this.MinTime)
		{
			if (UnityEngine.Random.value < this.Threshold)
			{
				base.StartCoroutine(this.Flash());
			}
			this._lastTime = Time.time;
		}
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x00079558 File Offset: 0x00077958
	private IEnumerator Flash()
	{
		int numberOfFlash = UnityEngine.Random.Range(0, this.MaxNumberOfFlash);
		for (int i = 0; i < numberOfFlash; i++)
		{
			this._renderer.color = this.FlashColor;
			yield return new WaitForSeconds(this.FlashRate);
			this._renderer.color = this._orignialColor;
			yield return new WaitForSeconds(this.FlashRate);
		}
		if (numberOfFlash > 0)
		{
			this._thunderSound.Play();
		}
		yield break;
	}

	// Token: 0x04000BAC RID: 2988
	public Color FlashColor;

	// Token: 0x04000BAD RID: 2989
	public float MinTime = 0.5f;

	// Token: 0x04000BAE RID: 2990
	public float Threshold = 0.5f;

	// Token: 0x04000BAF RID: 2991
	public int MaxNumberOfFlash = 3;

	// Token: 0x04000BB0 RID: 2992
	public float FlashRate = 0.03f;

	// Token: 0x04000BB1 RID: 2993
	private float _lastTime;

	// Token: 0x04000BB2 RID: 2994
	private Color _orignialColor;

	// Token: 0x04000BB3 RID: 2995
	private SpriteRenderer _renderer;

	// Token: 0x04000BB4 RID: 2996
	private AudioSource _thunderSound;

	// Token: 0x02000C1A RID: 3098
	[CompilerGenerated]
	private sealed class <Flash>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051EE RID: 20974 RVA: 0x00079573 File Offset: 0x00077973
		[DebuggerHidden]
		public <Flash>c__Iterator0()
		{
		}

		// Token: 0x060051EF RID: 20975 RVA: 0x0007957C File Offset: 0x0007797C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				numberOfFlash = UnityEngine.Random.Range(0, this.MaxNumberOfFlash);
				i = 0;
				break;
			case 1u:
				this._renderer.color = this._orignialColor;
				this.$current = new WaitForSeconds(this.FlashRate);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			case 2u:
				i++;
				break;
			default:
				return false;
			}
			if (i < numberOfFlash)
			{
				this._renderer.color = this.FlashColor;
				this.$current = new WaitForSeconds(this.FlashRate);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}
			if (numberOfFlash > 0)
			{
				this._thunderSound.Play();
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700117E RID: 4478
		// (get) Token: 0x060051F0 RID: 20976 RVA: 0x000796A0 File Offset: 0x00077AA0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700117F RID: 4479
		// (get) Token: 0x060051F1 RID: 20977 RVA: 0x000796A8 File Offset: 0x00077AA8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051F2 RID: 20978 RVA: 0x000796B0 File Offset: 0x00077AB0
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051F3 RID: 20979 RVA: 0x000796C0 File Offset: 0x00077AC0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004001 RID: 16385
		internal int <numberOfFlash>__0;

		// Token: 0x04004002 RID: 16386
		internal int <i>__1;

		// Token: 0x04004003 RID: 16387
		internal LigntningFlashController $this;

		// Token: 0x04004004 RID: 16388
		internal object $current;

		// Token: 0x04004005 RID: 16389
		internal bool $disposing;

		// Token: 0x04004006 RID: 16390
		internal int $PC;
	}
}
