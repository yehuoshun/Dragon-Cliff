using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200034F RID: 847
public class AnaimatedUIImage : MonoBehaviour
{
	// Token: 0x060016A1 RID: 5793 RVA: 0x000B2153 File Offset: 0x000B0553
	public AnaimatedUIImage()
	{
	}

	// Token: 0x060016A2 RID: 5794 RVA: 0x000B215B File Offset: 0x000B055B
	private void Start()
	{
		base.transform.position = this.StartPoint.transform.position;
		this._particleSystem = base.GetComponent<ParticleSystem>();
		this._particleSystem.Stop();
	}

	// Token: 0x060016A3 RID: 5795 RVA: 0x000B218F File Offset: 0x000B058F
	public void StartAnimate()
	{
		this._particleSystem.Play();
		base.transform.position = this.StartPoint.transform.position;
		base.StartCoroutine(this.StartAniamte());
	}

	// Token: 0x060016A4 RID: 5796 RVA: 0x000B21C4 File Offset: 0x000B05C4
	private IEnumerator StartAniamte()
	{
		Vector3 currentPos = base.transform.position;
		Vector3 targetPos = this.MoveTo.transform.position;
		float t = 0f;
		while (t < 1f)
		{
			t += Time.deltaTime / 0.5f;
			base.transform.position = Vector3.Lerp(currentPos, targetPos, t);
			yield return null;
		}
		yield return new WaitForSeconds(1f);
		ParticleSystem par = base.GetComponent<ParticleSystem>();
		if (par != null)
		{
			par.Stop();
		}
		else
		{
			GameObjectUtil.RecycleDestroy(base.gameObject);
		}
		yield break;
	}

	// Token: 0x040016AF RID: 5807
	public GameObject StartPoint;

	// Token: 0x040016B0 RID: 5808
	public GameObject MoveTo;

	// Token: 0x040016B1 RID: 5809
	private ParticleSystem _particleSystem;

	// Token: 0x02000CAC RID: 3244
	[CompilerGenerated]
	private sealed class <StartAniamte>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053EF RID: 21487 RVA: 0x000B21DF File Offset: 0x000B05DF
		[DebuggerHidden]
		public <StartAniamte>c__Iterator0()
		{
		}

		// Token: 0x060053F0 RID: 21488 RVA: 0x000B21E8 File Offset: 0x000B05E8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				currentPos = base.transform.position;
				targetPos = this.MoveTo.transform.position;
				t = 0f;
				break;
			case 1u:
				break;
			case 2u:
				par = base.GetComponent<ParticleSystem>();
				if (par != null)
				{
					par.Stop();
				}
				else
				{
					GameObjectUtil.RecycleDestroy(base.gameObject);
				}
				this.$PC = -1;
				return false;
			default:
				return false;
			}
			if (t >= 1f)
			{
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
			}
			else
			{
				t += Time.deltaTime / 0.5f;
				base.transform.position = Vector3.Lerp(currentPos, targetPos, t);
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
			}
			return true;
		}

		// Token: 0x170011CC RID: 4556
		// (get) Token: 0x060053F1 RID: 21489 RVA: 0x000B2335 File Offset: 0x000B0735
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011CD RID: 4557
		// (get) Token: 0x060053F2 RID: 21490 RVA: 0x000B233D File Offset: 0x000B073D
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053F3 RID: 21491 RVA: 0x000B2345 File Offset: 0x000B0745
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060053F4 RID: 21492 RVA: 0x000B2355 File Offset: 0x000B0755
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004170 RID: 16752
		internal Vector3 <currentPos>__0;

		// Token: 0x04004171 RID: 16753
		internal Vector3 <targetPos>__0;

		// Token: 0x04004172 RID: 16754
		internal float <t>__0;

		// Token: 0x04004173 RID: 16755
		internal ParticleSystem <par>__0;

		// Token: 0x04004174 RID: 16756
		internal AnaimatedUIImage $this;

		// Token: 0x04004175 RID: 16757
		internal object $current;

		// Token: 0x04004176 RID: 16758
		internal bool $disposing;

		// Token: 0x04004177 RID: 16759
		internal int $PC;
	}
}
