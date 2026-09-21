using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200035F RID: 863
public class IndividualSpeedObj : MonoBehaviour
{
	// Token: 0x06001737 RID: 5943 RVA: 0x000B4F80 File Offset: 0x000B3380
	public IndividualSpeedObj()
	{
	}

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000B4F93 File Offset: 0x000B3393
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000B4F9B File Offset: 0x000B339B
	public IBattleUnit BattleUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleUnit>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BattleUnit>k__BackingField = value;
		}
	}

	// Token: 0x0600173A RID: 5946 RVA: 0x000B4FA4 File Offset: 0x000B33A4
	public void Init(IBattleUnit unit)
	{
		this.BattleUnit = unit;
		if (unit is AdventurerBattleUnit)
		{
			this.HeroAvatar.sprite = FilePath.GetCharacterBasicAppearance(unit.GetUnitType(), false).GetStandSprite();
		}
		if (unit is EnemyBattleUnit)
		{
			EnemyBattleUnit enemyBattleUnit = unit as EnemyBattleUnit;
			this.HeroAvatar.sprite = FilePath.GetSpeedBarAvatar(enemyBattleUnit.SlotSelection);
			if (enemyBattleUnit.SlotSelection == AdventureEncounterSlotType.Boss)
			{
				this.HeroAvatar.transform.localScale = Vector3.one * 1.2f;
			}
			else if (enemyBattleUnit.SlotSelection == AdventureEncounterSlotType.MiniBoss)
			{
				this.HeroAvatar.transform.localScale = Vector3.one * 1.2f;
			}
			else
			{
				this.HeroAvatar.transform.localScale = Vector3.one;
			}
		}
	}

	// Token: 0x0600173B RID: 5947 RVA: 0x000B507C File Offset: 0x000B347C
	private void Update()
	{
		if (this.BattleUnit != null && this.BattleUnit.Status == BattleUnitStatus.Active && this.BattleUnit.IsTurnRelevant())
		{
			base.gameObject.SetActive(true);
			this.silderControl.value = (float)this.BattleUnit.TurnProgress;
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600173C RID: 5948 RVA: 0x000B50E9 File Offset: 0x000B34E9
	public void UnitDead()
	{
		this.HeroAvatar.gameObject.SetActive(false);
	}

	// Token: 0x0600173D RID: 5949 RVA: 0x000B50FC File Offset: 0x000B34FC
	public void EncouterFinished()
	{
		this._currentValue = 0f;
		GameObjectUtil.RecycleDestroy(base.gameObject);
	}

	// Token: 0x0600173E RID: 5950 RVA: 0x000B5114 File Offset: 0x000B3514
	public IEnumerator MoveToTarget(Vector3 WalkTo, bool isInNext = false)
	{
		Vector3 currentPos = base.transform.position;
		float t = 0f;
		while (t < 1f)
		{
			t += Time.deltaTime / 0.5f;
			base.transform.position = Vector3.Lerp(currentPos, WalkTo, t);
			yield return null;
		}
		yield break;
	}

	// Token: 0x0600173F RID: 5951 RVA: 0x000B5138 File Offset: 0x000B3538
	public IEnumerator MoveToFirstPos()
	{
		yield return new WaitForSeconds(this.waitTime);
		yield break;
	}

	// Token: 0x06001740 RID: 5952 RVA: 0x000B5153 File Offset: 0x000B3553
	public void CompleteTurn()
	{
		this.HeroAvatar.transform.localScale = Vector3.one;
	}

	// Token: 0x06001741 RID: 5953 RVA: 0x000B516A File Offset: 0x000B356A
	public void EnterTurn()
	{
		this.HeroAvatar.transform.localScale = Vector3.one * 2f;
	}

	// Token: 0x04001735 RID: 5941
	public Slider silderControl;

	// Token: 0x04001736 RID: 5942
	public Image HeroAvatar;

	// Token: 0x04001737 RID: 5943
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <BattleUnit>k__BackingField;

	// Token: 0x04001738 RID: 5944
	public float _currentValue;

	// Token: 0x04001739 RID: 5945
	private InBattleUnitPanelObj _battleUnitObj;

	// Token: 0x0400173A RID: 5946
	private float waitTime = 0.5f;

	// Token: 0x0400173B RID: 5947
	private bool _largeHead;

	// Token: 0x02000CB7 RID: 3255
	[CompilerGenerated]
	private sealed class <MoveToTarget>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005426 RID: 21542 RVA: 0x000B518B File Offset: 0x000B358B
		[DebuggerHidden]
		public <MoveToTarget>c__Iterator0()
		{
		}

		// Token: 0x06005427 RID: 21543 RVA: 0x000B5194 File Offset: 0x000B3594
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			Vector3 targetPos;
			switch (num)
			{
			case 0u:
				currentPos = base.transform.position;
				targetPos = WalkTo;
				t = 0f;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			if (t < 1f)
			{
				t += Time.deltaTime / 0.5f;
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

		// Token: 0x170011D8 RID: 4568
		// (get) Token: 0x06005428 RID: 21544 RVA: 0x000B5268 File Offset: 0x000B3668
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011D9 RID: 4569
		// (get) Token: 0x06005429 RID: 21545 RVA: 0x000B5270 File Offset: 0x000B3670
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600542A RID: 21546 RVA: 0x000B5278 File Offset: 0x000B3678
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600542B RID: 21547 RVA: 0x000B5288 File Offset: 0x000B3688
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040041A4 RID: 16804
		internal Vector3 <currentPos>__0;

		// Token: 0x040041A5 RID: 16805
		internal Vector3 WalkTo;

		// Token: 0x040041A6 RID: 16806
		internal Vector3 <targetPos>__0;

		// Token: 0x040041A7 RID: 16807
		internal float <t>__0;

		// Token: 0x040041A8 RID: 16808
		internal IndividualSpeedObj $this;

		// Token: 0x040041A9 RID: 16809
		internal object $current;

		// Token: 0x040041AA RID: 16810
		internal bool $disposing;

		// Token: 0x040041AB RID: 16811
		internal int $PC;
	}

	// Token: 0x02000CB8 RID: 3256
	[CompilerGenerated]
	private sealed class <MoveToFirstPos>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600542C RID: 21548 RVA: 0x000B528F File Offset: 0x000B368F
		[DebuggerHidden]
		public <MoveToFirstPos>c__Iterator1()
		{
		}

		// Token: 0x0600542D RID: 21549 RVA: 0x000B5298 File Offset: 0x000B3698
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(this.waitTime);
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

		// Token: 0x170011DA RID: 4570
		// (get) Token: 0x0600542E RID: 21550 RVA: 0x000B52FA File Offset: 0x000B36FA
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011DB RID: 4571
		// (get) Token: 0x0600542F RID: 21551 RVA: 0x000B5302 File Offset: 0x000B3702
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005430 RID: 21552 RVA: 0x000B530A File Offset: 0x000B370A
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005431 RID: 21553 RVA: 0x000B531A File Offset: 0x000B371A
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040041AC RID: 16812
		internal IndividualSpeedObj $this;

		// Token: 0x040041AD RID: 16813
		internal object $current;

		// Token: 0x040041AE RID: 16814
		internal bool $disposing;

		// Token: 0x040041AF RID: 16815
		internal int $PC;
	}
}
