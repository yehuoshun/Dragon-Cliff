using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000339 RID: 825
public class AdventruerInBattle : MonoBehaviour
{
	// Token: 0x060015E5 RID: 5605 RVA: 0x000AD1E5 File Offset: 0x000AB5E5
	public AdventruerInBattle()
	{
	}

	// Token: 0x060015E6 RID: 5606 RVA: 0x000AD1ED File Offset: 0x000AB5ED
	private void Awake()
	{
		this._combatController = base.GetComponent<AdventurerCombatController>();
		this.Animator = base.GetComponent<AdventurerCombatAnimator>();
	}

	// Token: 0x060015E7 RID: 5607 RVA: 0x000AD207 File Offset: 0x000AB607
	public void SetSpawner(Spawner spawner)
	{
		this._spawner = spawner;
	}

	// Token: 0x060015E8 RID: 5608 RVA: 0x000AD210 File Offset: 0x000AB610
	public void SetWalkTo(GameObject walkTot)
	{
		this.WalkTo = walkTot;
		this.MoveToNextTarget();
		base.StartCoroutine(this.WalkInBattle());
		this.SetHealthBarActiveStatus(false);
	}

	// Token: 0x060015E9 RID: 5609 RVA: 0x000AD233 File Offset: 0x000AB633
	private void SetHealthBarActiveStatus(bool status)
	{
		if (status)
		{
			this._combatController.ShowHealthBar();
		}
		else
		{
			this._combatController.HideHealthBar();
		}
	}

	// Token: 0x060015EA RID: 5610 RVA: 0x000AD258 File Offset: 0x000AB658
	private IEnumerator WalkInBattle()
	{
		Vector3 currentPos = base.transform.position;
		Vector3 targetPos = this.WalkTo.transform.position;
		float t = 0f;
		while (t < 1f)
		{
			t += Time.deltaTime / 2f;
			base.transform.position = Vector3.Lerp(currentPos, targetPos, t);
			yield return null;
		}
		yield break;
	}

	// Token: 0x060015EB RID: 5611 RVA: 0x000AD273 File Offset: 0x000AB673
	public void MoveToNextTarget()
	{
		this.Animator.WalkEastWithWeapon();
		this.SetHealthBarActiveStatus(false);
	}

	// Token: 0x060015EC RID: 5612 RVA: 0x000AD287 File Offset: 0x000AB687
	public void Encountered()
	{
		this.Animator.IdleInCombat();
		this.SetHealthBarActiveStatus(true);
	}

	// Token: 0x060015ED RID: 5613 RVA: 0x000AD29B File Offset: 0x000AB69B
	public void DestorySelf()
	{
		GameObjectUtil.RecycleDestroy(base.gameObject);
	}

	// Token: 0x040015FF RID: 5631
	private AdventurerCombatAnimator Animator;

	// Token: 0x04001600 RID: 5632
	public BattleEncounter BattleEncounter;

	// Token: 0x04001601 RID: 5633
	public AdventurerBattleUnit BattleUnit;

	// Token: 0x04001602 RID: 5634
	public GameObject WalkTo;

	// Token: 0x04001603 RID: 5635
	public GameObject StatusWidget;

	// Token: 0x04001604 RID: 5636
	public List<IEncounter> Encounters;

	// Token: 0x04001605 RID: 5637
	private Spawner _spawner;

	// Token: 0x04001606 RID: 5638
	private AdventurerCombatController _combatController;

	// Token: 0x02000C96 RID: 3222
	[CompilerGenerated]
	private sealed class <WalkInBattle>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600535B RID: 21339 RVA: 0x000AD2A8 File Offset: 0x000AB6A8
		[DebuggerHidden]
		public <WalkInBattle>c__Iterator0()
		{
		}

		// Token: 0x0600535C RID: 21340 RVA: 0x000AD2B0 File Offset: 0x000AB6B0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				currentPos = base.transform.position;
				targetPos = this.WalkTo.transform.position;
				t = 0f;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			if (t < 1f)
			{
				t += Time.deltaTime / 2f;
				base.transform.position = Vector3.Lerp(currentPos, targetPos, t);
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

		// Token: 0x170011A8 RID: 4520
		// (get) Token: 0x0600535D RID: 21341 RVA: 0x000AD393 File Offset: 0x000AB793
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011A9 RID: 4521
		// (get) Token: 0x0600535E RID: 21342 RVA: 0x000AD39B File Offset: 0x000AB79B
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600535F RID: 21343 RVA: 0x000AD3A3 File Offset: 0x000AB7A3
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005360 RID: 21344 RVA: 0x000AD3B3 File Offset: 0x000AB7B3
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040040E5 RID: 16613
		internal Vector3 <currentPos>__0;

		// Token: 0x040040E6 RID: 16614
		internal Vector3 <targetPos>__0;

		// Token: 0x040040E7 RID: 16615
		internal float <t>__0;

		// Token: 0x040040E8 RID: 16616
		internal AdventruerInBattle $this;

		// Token: 0x040040E9 RID: 16617
		internal object $current;

		// Token: 0x040040EA RID: 16618
		internal bool $disposing;

		// Token: 0x040040EB RID: 16619
		internal int $PC;
	}
}
