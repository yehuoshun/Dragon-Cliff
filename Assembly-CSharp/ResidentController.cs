using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class ResidentController : MovingCharacterController
{
	// Token: 0x060014F6 RID: 5366 RVA: 0x000A90C7 File Offset: 0x000A74C7
	public ResidentController()
	{
	}

	// Token: 0x060014F7 RID: 5367 RVA: 0x000A90D0 File Offset: 0x000A74D0
	public void Init(ResidentAtrb atrb)
	{
		this.TownEffect.gameObject.SetActive(false);
		this.Expression.SetActive(false);
		this.ResidentAtrb = atrb;
		base.UpdateSprites(FilePath.GetResidentAppearence(this.ResidentAtrb.Resident.Type));
		this._currentSpeed = UnityEngine.Random.Range(this.MinSpeed, this.MaxSpeed);
		this.Appear(true);
		base.StartToMove(PathPointsManager.Instance.GetPath(this.ResidentAtrb.StartPoint, this.ResidentAtrb.EndPoint));
	}

	// Token: 0x060014F8 RID: 5368 RVA: 0x000A9160 File Offset: 0x000A7560
	public override IEnumerator ArrivedDestination()
	{
		yield return this.NormalResidentArrived();
		yield break;
	}

	// Token: 0x060014F9 RID: 5369 RVA: 0x000A917B File Offset: 0x000A757B
	public void HappyTriggerred()
	{
		this.Expression.SetActive(true);
	}

	// Token: 0x060014FA RID: 5370 RVA: 0x000A918C File Offset: 0x000A758C
	public IEnumerator NormalResidentArrived()
	{
		this.Appear(false);
		base.FollowPath = false;
		if (this.ResidentAtrb.EndPoint.Type == NodeType.EntranceAndExit)
		{
			TownManager.Instance.ResidentManager.RemoveInTownResident(this);
			ObjectPoolManager.Instance.Destroy(PoolType.Resident, base.gameObject);
			yield return null;
		}
		else
		{
			NodeController startPoint = this.ResidentAtrb.EndPoint;
			this.ResidentAtrb.EndPoint = this.ResidentAtrb.StartPoint;
			this.ResidentAtrb.StartPoint = startPoint;
			base.transform.position = startPoint.transform.position;
			yield return new WaitForSeconds(this.ResidentAtrb.HalfwayWaitTime);
			this.Appear(true);
			base.StartToMove(PathPointsManager.Instance.GetPath(this.ResidentAtrb.StartPoint, this.ResidentAtrb.EndPoint));
		}
		yield break;
	}

	// Token: 0x060014FB RID: 5371 RVA: 0x000A91A7 File Offset: 0x000A75A7
	private void Visitor_PurchaseCompleted(Resident arg1, List<ResourceUpdate> arg2)
	{
		base.StartCoroutine(base.Wait());
	}

	// Token: 0x060014FC RID: 5372 RVA: 0x000A91B6 File Offset: 0x000A75B6
	private void VisitorDispears()
	{
		this.Appear(false);
		ObjectPoolManager.Instance.Destroy(PoolType.Resident, base.gameObject);
	}

	// Token: 0x060014FD RID: 5373 RVA: 0x000A91D0 File Offset: 0x000A75D0
	private void Appear(bool appear)
	{
		this.IsDead = !appear;
		this.Animator.enabled = appear;
		this.VisitorObj.SetActive(appear);
	}

	// Token: 0x060014FE RID: 5374 RVA: 0x000A91F4 File Offset: 0x000A75F4
	private void FixedUpdate()
	{
		if (this.IsDead)
		{
			return;
		}
		if (base.FollowPath)
		{
			if (this.Path.Count == 0)
			{
				return;
			}
			base.Moving();
		}
	}

	// Token: 0x0400150A RID: 5386
	public GameObject VisitorObj;

	// Token: 0x0400150B RID: 5387
	public GameObject Expression;

	// Token: 0x0400150C RID: 5388
	public ResidentTownEffectController TownEffect;

	// Token: 0x0400150D RID: 5389
	public SpriteRenderer Emoji;

	// Token: 0x0400150E RID: 5390
	public ResidentAtrb ResidentAtrb;

	// Token: 0x02000C89 RID: 3209
	[CompilerGenerated]
	private sealed class <ArrivedDestination>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600532B RID: 21291 RVA: 0x000A9224 File Offset: 0x000A7624
		[DebuggerHidden]
		public <ArrivedDestination>c__Iterator0()
		{
		}

		// Token: 0x0600532C RID: 21292 RVA: 0x000A922C File Offset: 0x000A762C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = base.NormalResidentArrived();
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

		// Token: 0x1700119E RID: 4510
		// (get) Token: 0x0600532D RID: 21293 RVA: 0x000A9289 File Offset: 0x000A7689
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700119F RID: 4511
		// (get) Token: 0x0600532E RID: 21294 RVA: 0x000A9291 File Offset: 0x000A7691
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600532F RID: 21295 RVA: 0x000A9299 File Offset: 0x000A7699
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005330 RID: 21296 RVA: 0x000A92A9 File Offset: 0x000A76A9
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040040C1 RID: 16577
		internal ResidentController $this;

		// Token: 0x040040C2 RID: 16578
		internal object $current;

		// Token: 0x040040C3 RID: 16579
		internal bool $disposing;

		// Token: 0x040040C4 RID: 16580
		internal int $PC;
	}

	// Token: 0x02000C8A RID: 3210
	[CompilerGenerated]
	private sealed class <NormalResidentArrived>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005331 RID: 21297 RVA: 0x000A92B0 File Offset: 0x000A76B0
		[DebuggerHidden]
		public <NormalResidentArrived>c__Iterator1()
		{
		}

		// Token: 0x06005332 RID: 21298 RVA: 0x000A92B8 File Offset: 0x000A76B8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				base.Appear(false);
				base.FollowPath = false;
				if (this.ResidentAtrb.EndPoint.Type == NodeType.EntranceAndExit)
				{
					TownManager.Instance.ResidentManager.RemoveInTownResident(this);
					ObjectPoolManager.Instance.Destroy(PoolType.Resident, base.gameObject);
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
				}
				else
				{
					startPoint = this.ResidentAtrb.EndPoint;
					this.ResidentAtrb.EndPoint = this.ResidentAtrb.StartPoint;
					this.ResidentAtrb.StartPoint = startPoint;
					base.transform.position = startPoint.transform.position;
					this.$current = new WaitForSeconds(this.ResidentAtrb.HalfwayWaitTime);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
				}
				return true;
			case 1u:
				break;
			case 2u:
				base.Appear(true);
				base.StartToMove(PathPointsManager.Instance.GetPath(this.ResidentAtrb.StartPoint, this.ResidentAtrb.EndPoint));
				break;
			default:
				return false;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011A0 RID: 4512
		// (get) Token: 0x06005333 RID: 21299 RVA: 0x000A944F File Offset: 0x000A784F
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011A1 RID: 4513
		// (get) Token: 0x06005334 RID: 21300 RVA: 0x000A9457 File Offset: 0x000A7857
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005335 RID: 21301 RVA: 0x000A945F File Offset: 0x000A785F
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005336 RID: 21302 RVA: 0x000A946F File Offset: 0x000A786F
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040040C5 RID: 16581
		internal NodeController <startPoint>__1;

		// Token: 0x040040C6 RID: 16582
		internal ResidentController $this;

		// Token: 0x040040C7 RID: 16583
		internal object $current;

		// Token: 0x040040C8 RID: 16584
		internal bool $disposing;

		// Token: 0x040040C9 RID: 16585
		internal int $PC;
	}
}
