using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000328 RID: 808
public abstract class MovingPlayer : MonoBehaviour
{
	// Token: 0x0600158E RID: 5518 RVA: 0x000AB759 File Offset: 0x000A9B59
	protected MovingPlayer()
	{
	}

	// Token: 0x0600158F RID: 5519 RVA: 0x000AB76C File Offset: 0x000A9B6C
	protected virtual void Start()
	{
		this.boxCollider = base.GetComponent<BoxCollider2D>();
		this.rb2D = base.GetComponent<Rigidbody2D>();
		this.inverseMoveTime = 1f / this.movingTime;
	}

	// Token: 0x06001590 RID: 5520 RVA: 0x000AB798 File Offset: 0x000A9B98
	protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
	{
		Vector2 vector = base.transform.position;
		Vector2 vector2 = vector + new Vector2((float)xDir, (float)yDir);
		this.boxCollider.enabled = false;
		hit = Physics2D.Linecast(vector, vector2, this.blockingLayer);
		this.boxCollider.enabled = true;
		if (hit.transform == null)
		{
			base.StartCoroutine(this.SmoothMovement(vector2));
			return true;
		}
		return false;
	}

	// Token: 0x06001591 RID: 5521 RVA: 0x000AB820 File Offset: 0x000A9C20
	protected IEnumerator SmoothMovement(Vector3 end)
	{
		float sqrRemaininDistance = (base.transform.position - end).sqrMagnitude;
		while (sqrRemaininDistance > 1.401298E-45f)
		{
			Vector3 newPos = Vector3.MoveTowards(this.rb2D.position, end, this.inverseMoveTime * Time.deltaTime);
			this.rb2D.MovePosition(newPos);
			sqrRemaininDistance = (base.transform.position - end).sqrMagnitude;
			yield return null;
		}
		yield break;
	}

	// Token: 0x06001592 RID: 5522 RVA: 0x000AB844 File Offset: 0x000A9C44
	protected virtual void AttemptMove<T>(int xDir, int yDir) where T : Component
	{
		RaycastHit2D raycastHit2D;
		bool flag = this.Move(xDir, yDir, out raycastHit2D);
		if (raycastHit2D.transform == null)
		{
			return;
		}
		T component = raycastHit2D.transform.GetComponent<T>();
		if (!flag && component != null)
		{
			this.OnCantMove<T>(component);
		}
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x000AB89A File Offset: 0x000A9C9A
	protected virtual void OnCantMove<T>(T component) where T : Component
	{
	}

	// Token: 0x0400159B RID: 5531
	public float movingTime = 0.1f;

	// Token: 0x0400159C RID: 5532
	public LayerMask blockingLayer;

	// Token: 0x0400159D RID: 5533
	private BoxCollider2D boxCollider;

	// Token: 0x0400159E RID: 5534
	private Rigidbody2D rb2D;

	// Token: 0x0400159F RID: 5535
	private float inverseMoveTime;

	// Token: 0x02000C91 RID: 3217
	[CompilerGenerated]
	private sealed class <SmoothMovement>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005343 RID: 21315 RVA: 0x000AB89C File Offset: 0x000A9C9C
		[DebuggerHidden]
		public <SmoothMovement>c__Iterator0()
		{
		}

		// Token: 0x06005344 RID: 21316 RVA: 0x000AB8A4 File Offset: 0x000A9CA4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				sqrRemaininDistance = (base.transform.position - end).sqrMagnitude;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			if (sqrRemaininDistance > 1.401298E-45f)
			{
				newPos = Vector3.MoveTowards(this.rb2D.position, end, this.inverseMoveTime * Time.deltaTime);
				this.rb2D.MovePosition(newPos);
				sqrRemaininDistance = (base.transform.position - end).sqrMagnitude;
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011A2 RID: 4514
		// (get) Token: 0x06005345 RID: 21317 RVA: 0x000AB9B0 File Offset: 0x000A9DB0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011A3 RID: 4515
		// (get) Token: 0x06005346 RID: 21318 RVA: 0x000AB9B8 File Offset: 0x000A9DB8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005347 RID: 21319 RVA: 0x000AB9C0 File Offset: 0x000A9DC0
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005348 RID: 21320 RVA: 0x000AB9D0 File Offset: 0x000A9DD0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040040D1 RID: 16593
		internal Vector3 end;

		// Token: 0x040040D2 RID: 16594
		internal float <sqrRemaininDistance>__0;

		// Token: 0x040040D3 RID: 16595
		internal Vector3 <newPos>__1;

		// Token: 0x040040D4 RID: 16596
		internal MovingPlayer $this;

		// Token: 0x040040D5 RID: 16597
		internal object $current;

		// Token: 0x040040D6 RID: 16598
		internal bool $disposing;

		// Token: 0x040040D7 RID: 16599
		internal int $PC;
	}
}
