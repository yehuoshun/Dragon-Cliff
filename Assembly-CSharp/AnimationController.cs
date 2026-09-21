using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000133 RID: 307
public class AnimationController : MonoBehaviour
{
	// Token: 0x0600089D RID: 2205 RVA: 0x000776D2 File Offset: 0x00075AD2
	public AnimationController()
	{
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x000776F0 File Offset: 0x00075AF0
	private void Start()
	{
		this.maxAnimation = this.GetMaxLengthAnimation();
		for (int i = 0; i < this.animations.Count; i++)
		{
			if (this.animations[i].delay > 0f)
			{
				this.animations[i].animationObject.SetActive(false);
				base.StartCoroutine(this.DelayPlay(this.animations[i], this.animations[i].delay));
			}
			else
			{
				this.animations[i].animationObject.SetActive(true);
				Animator component = this.animations[i].animationObject.GetComponent<Animator>();
				component.Play("appear");
				base.StartCoroutine(this.Disappear(this.animations[i]));
			}
		}
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x000777D8 File Offset: 0x00075BD8
	protected IEnumerator DelayPlay(global::Animation animation, float times)
	{
		yield return new WaitForSeconds(times);
		animation.animationObject.SetActive(true);
		Animator animator = animation.animationObject.GetComponent<Animator>();
		animator.Play("appear");
		base.StartCoroutine(this.Disappear(animation));
		yield break;
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x00077804 File Offset: 0x00075C04
	protected IEnumerator Disappear(global::Animation animation)
	{
		Animator animator = animation.animationObject.GetComponent<Animator>();
		yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
		animation.animationObject.SetActive(false);
		if (this.maxAnimation == animation)
		{
			UnityEngine.Object.DestroyImmediate(base.transform.gameObject);
		}
		yield break;
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x00077828 File Offset: 0x00075C28
	protected global::Animation GetMaxLengthAnimation()
	{
		global::Animation result = new global::Animation();
		float num = -1f;
		for (int i = 0; i < this.animations.Count; i++)
		{
			Animator component = this.animations[i].animationObject.GetComponent<Animator>();
			float num2 = component.GetCurrentAnimatorStateInfo(0).length + this.animations[i].delay;
			if (num2 > num)
			{
				num = num2;
				result = this.animations[i];
			}
		}
		return result;
	}

	// Token: 0x04000B30 RID: 2864
	public List<global::Animation> animations = new List<global::Animation>();

	// Token: 0x04000B31 RID: 2865
	private List<Animator> playAnimators = new List<Animator>();

	// Token: 0x04000B32 RID: 2866
	private global::Animation maxAnimation;

	// Token: 0x02000C0E RID: 3086
	[CompilerGenerated]
	private sealed class <DelayPlay>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051BE RID: 20926 RVA: 0x000778B1 File Offset: 0x00075CB1
		[DebuggerHidden]
		public <DelayPlay>c__Iterator0()
		{
		}

		// Token: 0x060051BF RID: 20927 RVA: 0x000778BC File Offset: 0x00075CBC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(times);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				animation.animationObject.SetActive(true);
				animator = animation.animationObject.GetComponent<Animator>();
				animator.Play("appear");
				base.StartCoroutine(base.Disappear(animation));
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001172 RID: 4466
		// (get) Token: 0x060051C0 RID: 20928 RVA: 0x0007796D File Offset: 0x00075D6D
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001173 RID: 4467
		// (get) Token: 0x060051C1 RID: 20929 RVA: 0x00077975 File Offset: 0x00075D75
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051C2 RID: 20930 RVA: 0x0007797D File Offset: 0x00075D7D
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051C3 RID: 20931 RVA: 0x0007798D File Offset: 0x00075D8D
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003FD8 RID: 16344
		internal float times;

		// Token: 0x04003FD9 RID: 16345
		internal global::Animation animation;

		// Token: 0x04003FDA RID: 16346
		internal Animator <animator>__0;

		// Token: 0x04003FDB RID: 16347
		internal AnimationController $this;

		// Token: 0x04003FDC RID: 16348
		internal object $current;

		// Token: 0x04003FDD RID: 16349
		internal bool $disposing;

		// Token: 0x04003FDE RID: 16350
		internal int $PC;
	}

	// Token: 0x02000C0F RID: 3087
	[CompilerGenerated]
	private sealed class <Disappear>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051C4 RID: 20932 RVA: 0x00077994 File Offset: 0x00075D94
		[DebuggerHidden]
		public <Disappear>c__Iterator1()
		{
		}

		// Token: 0x060051C5 RID: 20933 RVA: 0x0007799C File Offset: 0x00075D9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
			{
				animator = animation.animationObject.GetComponent<Animator>();
				AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
				this.$current = new WaitForSeconds(info.length);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}
			case 1u:
				animation.animationObject.SetActive(false);
				if (this.maxAnimation == animation)
				{
					UnityEngine.Object.DestroyImmediate(base.transform.gameObject);
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001174 RID: 4468
		// (get) Token: 0x060051C6 RID: 20934 RVA: 0x00077A62 File Offset: 0x00075E62
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001175 RID: 4469
		// (get) Token: 0x060051C7 RID: 20935 RVA: 0x00077A6A File Offset: 0x00075E6A
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051C8 RID: 20936 RVA: 0x00077A72 File Offset: 0x00075E72
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051C9 RID: 20937 RVA: 0x00077A82 File Offset: 0x00075E82
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003FDF RID: 16351
		internal global::Animation animation;

		// Token: 0x04003FE0 RID: 16352
		internal Animator <animator>__0;

		// Token: 0x04003FE1 RID: 16353
		internal AnimatorStateInfo <info>__0;

		// Token: 0x04003FE2 RID: 16354
		internal AnimationController $this;

		// Token: 0x04003FE3 RID: 16355
		internal object $current;

		// Token: 0x04003FE4 RID: 16356
		internal bool $disposing;

		// Token: 0x04003FE5 RID: 16357
		internal int $PC;
	}
}
