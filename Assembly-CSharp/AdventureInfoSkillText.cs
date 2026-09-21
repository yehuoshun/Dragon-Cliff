using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;

// Token: 0x0200033E RID: 830
public class AdventureInfoSkillText : MonoBehaviour
{
	// Token: 0x0600160C RID: 5644 RVA: 0x000ADEB4 File Offset: 0x000AC2B4
	public AdventureInfoSkillText()
	{
	}

	// Token: 0x0600160D RID: 5645 RVA: 0x000ADED2 File Offset: 0x000AC2D2
	public void ShowSkillName(string skillName)
	{
		this.SkillNameTextMesh.text = skillName;
		this.Aniamtor.SetTrigger("Show");
	}

	// Token: 0x0600160E RID: 5646 RVA: 0x000ADEF0 File Offset: 0x000AC2F0
	public IEnumerator ResetTimerAndText(string skillName)
	{
		this.SkillNameTextMesh.text = skillName;
		Color c = this.SkillNameTextMesh.color;
		c.a = 1f;
		this.SkillNameTextMesh.color = c;
		IEnumerator enumerator = this.FadeText().GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600160F RID: 5647 RVA: 0x000ADF14 File Offset: 0x000AC314
	private IEnumerable FadeText()
	{
		for (float f = 0f; f < this._fadeSecond; f += this._textOnFadeTimeFrameLength)
		{
			Color c = this.SkillNameTextMesh.color;
			c.a -= this._textOnFadeTimeFrameLength;
			this.SkillNameTextMesh.color = c;
			yield return new WaitForSeconds(this._textOnFadeTimeFrameLength);
		}
		yield break;
	}

	// Token: 0x04001636 RID: 5686
	public TextMeshProUGUI SkillNameTextMesh;

	// Token: 0x04001637 RID: 5687
	public Animator Aniamtor;

	// Token: 0x04001638 RID: 5688
	private float _fadeSecond = 2f;

	// Token: 0x04001639 RID: 5689
	private float _textOnFadeTimeFrameLength = 0.1f;

	// Token: 0x02000C98 RID: 3224
	[CompilerGenerated]
	private sealed class <ResetTimerAndText>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005363 RID: 21347 RVA: 0x000ADF37 File Offset: 0x000AC337
		[DebuggerHidden]
		public <ResetTimerAndText>c__Iterator0()
		{
		}

		// Token: 0x06005364 RID: 21348 RVA: 0x000ADF40 File Offset: 0x000AC340
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this.SkillNameTextMesh.text = skillName;
				c = this.SkillNameTextMesh.color;
				c.a = 1f;
				this.SkillNameTextMesh.color = c;
				enumerator = base.FadeText().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011AA RID: 4522
		// (get) Token: 0x06005365 RID: 21349 RVA: 0x000AE078 File Offset: 0x000AC478
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011AB RID: 4523
		// (get) Token: 0x06005366 RID: 21350 RVA: 0x000AE080 File Offset: 0x000AC480
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005367 RID: 21351 RVA: 0x000AE088 File Offset: 0x000AC488
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

		// Token: 0x06005368 RID: 21352 RVA: 0x000AE0F8 File Offset: 0x000AC4F8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040040ED RID: 16621
		internal string skillName;

		// Token: 0x040040EE RID: 16622
		internal Color <c>__0;

		// Token: 0x040040EF RID: 16623
		internal IEnumerator $locvar0;

		// Token: 0x040040F0 RID: 16624
		internal object <_>__1;

		// Token: 0x040040F1 RID: 16625
		internal IDisposable $locvar1;

		// Token: 0x040040F2 RID: 16626
		internal AdventureInfoSkillText $this;

		// Token: 0x040040F3 RID: 16627
		internal object $current;

		// Token: 0x040040F4 RID: 16628
		internal bool $disposing;

		// Token: 0x040040F5 RID: 16629
		internal int $PC;
	}

	// Token: 0x02000C99 RID: 3225
	[CompilerGenerated]
	private sealed class <FadeText>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005369 RID: 21353 RVA: 0x000AE0FF File Offset: 0x000AC4FF
		[DebuggerHidden]
		public <FadeText>c__Iterator1()
		{
		}

		// Token: 0x0600536A RID: 21354 RVA: 0x000AE108 File Offset: 0x000AC508
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				f = 0f;
				break;
			case 1u:
				f += this._textOnFadeTimeFrameLength;
				break;
			default:
				return false;
			}
			if (f < this._fadeSecond)
			{
				c = this.SkillNameTextMesh.color;
				c.a -= this._textOnFadeTimeFrameLength;
				this.SkillNameTextMesh.color = c;
				this.$current = new WaitForSeconds(this._textOnFadeTimeFrameLength);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011AC RID: 4524
		// (get) Token: 0x0600536B RID: 21355 RVA: 0x000AE1F1 File Offset: 0x000AC5F1
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011AD RID: 4525
		// (get) Token: 0x0600536C RID: 21356 RVA: 0x000AE1F9 File Offset: 0x000AC5F9
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600536D RID: 21357 RVA: 0x000AE201 File Offset: 0x000AC601
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600536E RID: 21358 RVA: 0x000AE211 File Offset: 0x000AC611
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600536F RID: 21359 RVA: 0x000AE218 File Offset: 0x000AC618
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005370 RID: 21360 RVA: 0x000AE220 File Offset: 0x000AC620
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventureInfoSkillText.<FadeText>c__Iterator1 <FadeText>c__Iterator = new AdventureInfoSkillText.<FadeText>c__Iterator1();
			<FadeText>c__Iterator.$this = this;
			return <FadeText>c__Iterator;
		}

		// Token: 0x040040F6 RID: 16630
		internal float <f>__1;

		// Token: 0x040040F7 RID: 16631
		internal Color <c>__2;

		// Token: 0x040040F8 RID: 16632
		internal AdventureInfoSkillText $this;

		// Token: 0x040040F9 RID: 16633
		internal object $current;

		// Token: 0x040040FA RID: 16634
		internal bool $disposing;

		// Token: 0x040040FB RID: 16635
		internal int $PC;
	}
}
