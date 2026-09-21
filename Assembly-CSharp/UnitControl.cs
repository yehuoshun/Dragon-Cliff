using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200012F RID: 303
public class UnitControl : MonoBehaviour
{
	// Token: 0x06000888 RID: 2184 RVA: 0x00076D3C File Offset: 0x0007513C
	public UnitControl()
	{
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x00076D44 File Offset: 0x00075144
	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x00076D54 File Offset: 0x00075154
	private void Update()
	{
		int num = (int)Input.GetAxisRaw("Horizontal");
		Vector3 localScale = base.transform.localScale;
		Vector3 zero = Vector3.zero;
		Vector3 target = Vector3.zero;
		if (num != 0)
		{
			if (this.walkStartTime == 0f)
			{
				this.walkStartTime = Time.time;
			}
			float smoothTime = 0.05f;
			float num2 = 0.1f;
			if (Time.time - this.walkStartTime > 2f)
			{
				smoothTime = 0.03f;
				this.animator.SetTrigger("run");
			}
			else
			{
				this.animator.SetTrigger("walk");
			}
			if (this.isEvade)
			{
				smoothTime = 0.01f;
				num2 = 0.2f;
			}
			if (num < 0)
			{
				localScale.x = -Math.Abs(localScale.x);
				target = base.transform.position + new Vector3(-num2, 0f, 0f);
			}
			else if (num > 0)
			{
				localScale.x = Math.Abs(localScale.x);
				target = base.transform.position + new Vector3(num2, 0f, 0f);
			}
			base.transform.localScale = localScale;
			base.transform.position = Vector3.SmoothDamp(base.transform.position, target, ref zero, smoothTime);
		}
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			this.walkStartTime = 0f;
			this.animator.ResetTrigger("idle_1");
			this.animator.ResetTrigger("walk");
			this.animator.ResetTrigger("run");
			this.animator.SetTrigger("idle_1");
		}
		if (Input.anyKeyDown)
		{
			IEnumerator enumerator = Enum.GetValues(typeof(KeyCode)).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					KeyCode keyCode = (KeyCode)obj;
					if (Input.GetKeyDown(keyCode))
					{
						if (keyCode == KeyCode.H)
						{
							this.animator.SetTrigger("skill_1");
						}
						else if (keyCode == KeyCode.J)
						{
							this.animator.SetTrigger("skill_2");
						}
						else if (keyCode == KeyCode.K)
						{
							this.animator.SetTrigger("hit_1");
						}
						else if (keyCode == KeyCode.L)
						{
							this.animator.SetTrigger("hit_2");
						}
						else if (keyCode == KeyCode.Y)
						{
							this.animator.SetTrigger("hit_2");
							this.animator.SetTrigger("death");
						}
						else if (keyCode == KeyCode.Space)
						{
							this.animator.SetTrigger("idle_2");
							base.StartCoroutine(this.Evade());
						}
					}
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
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x00077080 File Offset: 0x00075480
	public IEnumerator Evade()
	{
		yield return new WaitForSeconds(0.2f);
		this.isEvade = true;
		yield return new WaitForSeconds(0.2f);
		this.isEvade = false;
		yield break;
	}

	// Token: 0x04000B11 RID: 2833
	private Animator animator;

	// Token: 0x04000B12 RID: 2834
	private float walkStartTime;

	// Token: 0x04000B13 RID: 2835
	private bool isEvade;

	// Token: 0x02000C0D RID: 3085
	[CompilerGenerated]
	private sealed class <Evade>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051B8 RID: 20920 RVA: 0x0007709B File Offset: 0x0007549B
		[DebuggerHidden]
		public <Evade>c__Iterator0()
		{
		}

		// Token: 0x060051B9 RID: 20921 RVA: 0x000770A4 File Offset: 0x000754A4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(0.2f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.isEvade = true;
				this.$current = new WaitForSeconds(0.2f);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			case 2u:
				this.isEvade = false;
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001170 RID: 4464
		// (get) Token: 0x060051BA RID: 20922 RVA: 0x00077140 File Offset: 0x00075540
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001171 RID: 4465
		// (get) Token: 0x060051BB RID: 20923 RVA: 0x00077148 File Offset: 0x00075548
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051BC RID: 20924 RVA: 0x00077150 File Offset: 0x00075550
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051BD RID: 20925 RVA: 0x00077160 File Offset: 0x00075560
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003FD4 RID: 16340
		internal UnitControl $this;

		// Token: 0x04003FD5 RID: 16341
		internal object $current;

		// Token: 0x04003FD6 RID: 16342
		internal bool $disposing;

		// Token: 0x04003FD7 RID: 16343
		internal int $PC;
	}
}
