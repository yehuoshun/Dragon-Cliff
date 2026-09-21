using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000104 RID: 260
public class AdventurerCombatController : UnitCombatController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x0600073F RID: 1855 RVA: 0x0006FE84 File Offset: 0x0006E284
	public AdventurerCombatController()
	{
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000740 RID: 1856 RVA: 0x0006FE8C File Offset: 0x0006E28C
	// (set) Token: 0x06000741 RID: 1857 RVA: 0x0006FE94 File Offset: 0x0006E294
	public AdventurerBattleUnit Adventurer
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurer>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurer>k__BackingField = value;
		}
	}

	// Token: 0x06000742 RID: 1858 RVA: 0x0006FEA0 File Offset: 0x0006E2A0
	public override void Init(IBattleUnit battleUnit, Vector3 attackMoveToDestination, bool reverseHealthbar = false)
	{
		base.Init(battleUnit, attackMoveToDestination, false);
		this._effectColorController = base.GetComponentInChildren<AdventurerEffectColorController>();
		this._combatAnimator = base.GetComponent<AdventurerCombatAnimator>();
		this._targertGameObject = GameObjectUtil.GetComponentInChildren<UnitTargetObj>(this._combatAnimator.transform.GetChild(0).gameObject);
		this._targertGameObject.SetIsFriendlyUnit(true);
		if (battleUnit is AdventurerBattleUnit)
		{
			this.Adventurer = (battleUnit as AdventurerBattleUnit);
			base.GetComponentInChildren<GenericAdventurer>().Init(this.Adventurer.AdventurerProfile);
			this._combatAnimator.IdleInCombat();
		}
	}

	// Token: 0x06000743 RID: 1859 RVA: 0x0006FF33 File Offset: 0x0006E333
	public Transform GetTargetedParenTransform()
	{
		return this._combatAnimator.transform;
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x0006FF40 File Offset: 0x0006E340
	public void ShowHealthBar()
	{
		base.HealthController.gameObject.SetActive(true);
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x0006FF53 File Offset: 0x0006E353
	public void HideHealthBar()
	{
		base.HealthController.gameObject.SetActive(false);
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x0006FF68 File Offset: 0x0006E368
	public override IEnumerable UnitCastsSkill(SkillCastBattleEvent skillEvent, float animationWaitTime = 0.5f)
	{
		this.PopupSkillNameWhenCastsSkill(skillEvent.Skill.Skill.SkillType);
		if (skillEvent.SkillLogic is ActiveSkillLogicBase)
		{
			yield break;
		}
		yield return base.MoveForward();
		this._combatAnimator.Attack();
		yield return new WaitForSeconds(0.4f);
		UnityEngine.Object prefab = Resources.Load(FilePath.GetPreSkillEffect(skillEvent.Skill.Skill.SkillType));
		if (prefab != null && base.isActiveAndEnabled)
		{
			Transform casTransform = CombatManager.Instance.GetAdventureSkillCastPonit();
			SkillEffectController effectController = UnityEngine.Object.Instantiate<GameObject>(prefab as GameObject).GetComponent<SkillEffectController>();
			IEnumerator enumerator = effectController.Cast(casTransform, null).GetEnumerator();
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
		}
		yield return base.MoveBack();
		yield break;
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x0006FF94 File Offset: 0x0006E394
	public override IEnumerable UnitNormalAttack(IBattleUnit unit, float animationWaitTime = 0.5f)
	{
		yield return base.MoveForward();
		this._combatAnimator.Attack();
		yield return new WaitForSeconds(0.4f);
		yield return base.MoveBack();
		yield break;
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x0006FFB8 File Offset: 0x0006E3B8
	public override IEnumerable UnitCastsActiveSkill(ActiveSkillCastBattleEvent activeSkillEvent)
	{
		if (base.isActiveAndEnabled)
		{
			if (activeSkillEvent.Skill.SourceUnit.GetId() == base.BattleUnit.GetId())
			{
				IEnumerator enumerator = CombatManager.Instance.ActiveSkillCast(activeSkillEvent).GetEnumerator();
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
			}
			if (activeSkillEvent.SkillLogic is SpiritOfDemon)
			{
			}
		}
		yield break;
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x0006FFE4 File Offset: 0x0006E3E4
	public override IEnumerable UnitReceivesHeal(BattleHeal healEvent)
	{
		if (healEvent.Heals.Count == 0)
		{
			yield break;
		}
		bool showEffect = true;
		if (healEvent.HealSource is AdventureUnitSkill)
		{
			AdventureUnitSkill skill = healEvent.HealSource as AdventureUnitSkill;
			if (skill.GetSkillLogic() is DivineHammer)
			{
				showEffect = false;
			}
		}
		if (showEffect)
		{
			yield return this.DisplayEffect(healEvent.HealSource, healEvent.HealSource.SourceUnit.IsPlayer, true, true);
		}
		IEnumerator enumerator = base.UnitReceivesHeal(healEvent).GetEnumerator();
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

	// Token: 0x0600074A RID: 1866 RVA: 0x00070010 File Offset: 0x0006E410
	public override IEnumerable UnitReceivesDamage(BattleDamage damageEvent)
	{
		if (base.isActiveAndEnabled)
		{
			yield return this.DisplayEffect(damageEvent.DamageSource, true, true, true);
			this._effectColorController.PlayHurt();
			this._combatAnimator.Hurt();
			IEnumerator enumerator = base.UnitReceivesDamage(damageEvent).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x0007003A File Offset: 0x0006E43A
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left && this._isInTargetCandidates)
		{
			BattleManager.instance.SettingTarget(this);
		}
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x00070060 File Offset: 0x0006E460
	public virtual void HighlightCorresponseUnit(List<IBattleUnit> units)
	{
		foreach (IBattleUnit battleUnit in units)
		{
			if (battleUnit.GetId() == base.BattleUnit.GetId())
			{
				this.SetTargetObjStatus(true);
			}
		}
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x000700D4 File Offset: 0x0006E4D4
	private void SetTargetObjStatus(bool isActive)
	{
		this._isInTargetCandidates = isActive;
		if (this._targertGameObject != null)
		{
			this._targertGameObject.gameObject.SetActive(isActive);
		}
		this._combatAnimator.SetTargetSelectionState(isActive);
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x0007010B File Offset: 0x0006E50B
	public void ActiveSkillReleased()
	{
		this.SetTargetObjStatus(false);
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00070114 File Offset: 0x0006E514
	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable <UnitReceivesHeal>__BaseCallProxy0(BattleHeal heal)
	{
		return base.UnitReceivesHeal(heal);
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x0007011D File Offset: 0x0006E51D
	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable <UnitReceivesDamage>__BaseCallProxy1(BattleDamage damageEvent)
	{
		return base.UnitReceivesDamage(damageEvent);
	}

	// Token: 0x04000A19 RID: 2585
	private AdventurerEffectColorController _effectColorController;

	// Token: 0x04000A1A RID: 2586
	private AdventurerCombatAnimator _combatAnimator;

	// Token: 0x04000A1B RID: 2587
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerBattleUnit <Adventurer>k__BackingField;

	// Token: 0x04000A1C RID: 2588
	private UnitTargetObj _targertGameObject;

	// Token: 0x04000A1D RID: 2589
	private bool _isInTargetCandidates;

	// Token: 0x02000BD3 RID: 3027
	[CompilerGenerated]
	private sealed class <UnitCastsSkill>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005036 RID: 20534 RVA: 0x00070126 File Offset: 0x0006E526
		[DebuggerHidden]
		public <UnitCastsSkill>c__Iterator0()
		{
		}

		// Token: 0x06005037 RID: 20535 RVA: 0x00070130 File Offset: 0x0006E530
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this.PopupSkillNameWhenCastsSkill(skillEvent.Skill.Skill.SkillType);
				if (skillEvent.SkillLogic is ActiveSkillLogicBase)
				{
					return false;
				}
				this.$current = base.MoveForward();
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this._combatAnimator.Attack();
				this.$current = new WaitForSeconds(0.4f);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			case 2u:
				prefab = Resources.Load(FilePath.GetPreSkillEffect(skillEvent.Skill.Skill.SkillType));
				if (!(prefab != null) || !base.isActiveAndEnabled)
				{
					goto IL_1D5;
				}
				casTransform = CombatManager.Instance.GetAdventureSkillCastPonit();
				effectController = UnityEngine.Object.Instantiate<GameObject>(prefab as GameObject).GetComponent<SkillEffectController>();
				enumerator = effectController.Cast(casTransform, null).GetEnumerator();
				num = 4294967293u;
				break;
			case 3u:
				break;
			case 4u:
				this.$PC = -1;
				return false;
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
						this.$PC = 3;
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
			IL_1D5:
			this.$current = base.MoveBack();
			if (!this.$disposing)
			{
				this.$PC = 4;
			}
			return true;
		}

		// Token: 0x17001110 RID: 4368
		// (get) Token: 0x06005038 RID: 20536 RVA: 0x00070354 File Offset: 0x0006E754
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001111 RID: 4369
		// (get) Token: 0x06005039 RID: 20537 RVA: 0x0007035C File Offset: 0x0006E75C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600503A RID: 20538 RVA: 0x00070364 File Offset: 0x0006E764
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 3u:
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

		// Token: 0x0600503B RID: 20539 RVA: 0x000703E0 File Offset: 0x0006E7E0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600503C RID: 20540 RVA: 0x000703E7 File Offset: 0x0006E7E7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600503D RID: 20541 RVA: 0x000703F0 File Offset: 0x0006E7F0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventurerCombatController.<UnitCastsSkill>c__Iterator0 <UnitCastsSkill>c__Iterator = new AdventurerCombatController.<UnitCastsSkill>c__Iterator0();
			<UnitCastsSkill>c__Iterator.$this = this;
			<UnitCastsSkill>c__Iterator.skillEvent = skillEvent;
			return <UnitCastsSkill>c__Iterator;
		}

		// Token: 0x04003E38 RID: 15928
		internal SkillCastBattleEvent skillEvent;

		// Token: 0x04003E39 RID: 15929
		internal UnityEngine.Object <prefab>__0;

		// Token: 0x04003E3A RID: 15930
		internal Transform <casTransform>__1;

		// Token: 0x04003E3B RID: 15931
		internal SkillEffectController <effectController>__1;

		// Token: 0x04003E3C RID: 15932
		internal IEnumerator $locvar0;

		// Token: 0x04003E3D RID: 15933
		internal object <_>__2;

		// Token: 0x04003E3E RID: 15934
		internal IDisposable $locvar1;

		// Token: 0x04003E3F RID: 15935
		internal AdventurerCombatController $this;

		// Token: 0x04003E40 RID: 15936
		internal object $current;

		// Token: 0x04003E41 RID: 15937
		internal bool $disposing;

		// Token: 0x04003E42 RID: 15938
		internal int $PC;
	}

	// Token: 0x02000BD4 RID: 3028
	[CompilerGenerated]
	private sealed class <UnitNormalAttack>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600503E RID: 20542 RVA: 0x00070430 File Offset: 0x0006E830
		[DebuggerHidden]
		public <UnitNormalAttack>c__Iterator1()
		{
		}

		// Token: 0x0600503F RID: 20543 RVA: 0x00070438 File Offset: 0x0006E838
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = base.MoveForward();
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this._combatAnimator.Attack();
				this.$current = new WaitForSeconds(0.4f);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			case 2u:
				this.$current = base.MoveBack();
				if (!this.$disposing)
				{
					this.$PC = 3;
				}
				return true;
			case 3u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001112 RID: 4370
		// (get) Token: 0x06005040 RID: 20544 RVA: 0x000704F6 File Offset: 0x0006E8F6
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001113 RID: 4371
		// (get) Token: 0x06005041 RID: 20545 RVA: 0x000704FE File Offset: 0x0006E8FE
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005042 RID: 20546 RVA: 0x00070506 File Offset: 0x0006E906
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005043 RID: 20547 RVA: 0x00070516 File Offset: 0x0006E916
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005044 RID: 20548 RVA: 0x0007051D File Offset: 0x0006E91D
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005045 RID: 20549 RVA: 0x00070528 File Offset: 0x0006E928
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventurerCombatController.<UnitNormalAttack>c__Iterator1 <UnitNormalAttack>c__Iterator = new AdventurerCombatController.<UnitNormalAttack>c__Iterator1();
			<UnitNormalAttack>c__Iterator.$this = this;
			return <UnitNormalAttack>c__Iterator;
		}

		// Token: 0x04003E43 RID: 15939
		internal AdventurerCombatController $this;

		// Token: 0x04003E44 RID: 15940
		internal object $current;

		// Token: 0x04003E45 RID: 15941
		internal bool $disposing;

		// Token: 0x04003E46 RID: 15942
		internal int $PC;
	}

	// Token: 0x02000BD5 RID: 3029
	[CompilerGenerated]
	private sealed class <UnitCastsActiveSkill>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005046 RID: 20550 RVA: 0x0007055C File Offset: 0x0006E95C
		[DebuggerHidden]
		public <UnitCastsActiveSkill>c__Iterator2()
		{
		}

		// Token: 0x06005047 RID: 20551 RVA: 0x00070564 File Offset: 0x0006E964
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!base.isActiveAndEnabled)
				{
					goto IL_117;
				}
				if (!(activeSkillEvent.Skill.SourceUnit.GetId() == base.BattleUnit.GetId()))
				{
					goto IL_102;
				}
				enumerator = CombatManager.Instance.ActiveSkillCast(activeSkillEvent).GetEnumerator();
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
			IL_102:
			if (activeSkillEvent.SkillLogic is SpiritOfDemon)
			{
			}
			IL_117:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001114 RID: 4372
		// (get) Token: 0x06005048 RID: 20552 RVA: 0x000706A4 File Offset: 0x0006EAA4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001115 RID: 4373
		// (get) Token: 0x06005049 RID: 20553 RVA: 0x000706AC File Offset: 0x0006EAAC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600504A RID: 20554 RVA: 0x000706B4 File Offset: 0x0006EAB4
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

		// Token: 0x0600504B RID: 20555 RVA: 0x00070724 File Offset: 0x0006EB24
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600504C RID: 20556 RVA: 0x0007072B File Offset: 0x0006EB2B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600504D RID: 20557 RVA: 0x00070734 File Offset: 0x0006EB34
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventurerCombatController.<UnitCastsActiveSkill>c__Iterator2 <UnitCastsActiveSkill>c__Iterator = new AdventurerCombatController.<UnitCastsActiveSkill>c__Iterator2();
			<UnitCastsActiveSkill>c__Iterator.$this = this;
			<UnitCastsActiveSkill>c__Iterator.activeSkillEvent = activeSkillEvent;
			return <UnitCastsActiveSkill>c__Iterator;
		}

		// Token: 0x04003E47 RID: 15943
		internal ActiveSkillCastBattleEvent activeSkillEvent;

		// Token: 0x04003E48 RID: 15944
		internal IEnumerator $locvar0;

		// Token: 0x04003E49 RID: 15945
		internal object <_>__1;

		// Token: 0x04003E4A RID: 15946
		internal IDisposable $locvar1;

		// Token: 0x04003E4B RID: 15947
		internal AdventurerCombatController $this;

		// Token: 0x04003E4C RID: 15948
		internal object $current;

		// Token: 0x04003E4D RID: 15949
		internal bool $disposing;

		// Token: 0x04003E4E RID: 15950
		internal int $PC;
	}

	// Token: 0x02000BD6 RID: 3030
	[CompilerGenerated]
	private sealed class <UnitReceivesHeal>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600504E RID: 20558 RVA: 0x00070774 File Offset: 0x0006EB74
		[DebuggerHidden]
		public <UnitReceivesHeal>c__Iterator3()
		{
		}

		// Token: 0x0600504F RID: 20559 RVA: 0x0007077C File Offset: 0x0006EB7C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (healEvent.Heals.Count == 0)
				{
					return false;
				}
				showEffect = true;
				if (healEvent.HealSource is AdventureUnitSkill)
				{
					AdventureUnitSkill skill = healEvent.HealSource as AdventureUnitSkill;
					if (skill.GetSkillLogic() is DivineHammer)
					{
						showEffect = false;
					}
				}
				if (showEffect)
				{
					this.$current = this.DisplayEffect(healEvent.HealSource, healEvent.HealSource.SourceUnit.IsPlayer, true, true);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				break;
			case 1u:
				break;
			case 2u:
				goto IL_F6;
			default:
				return false;
			}
			enumerator = base.<UnitReceivesHeal>__BaseCallProxy0(healEvent).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_F6:
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 2;
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

		// Token: 0x17001116 RID: 4374
		// (get) Token: 0x06005050 RID: 20560 RVA: 0x0007091C File Offset: 0x0006ED1C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001117 RID: 4375
		// (get) Token: 0x06005051 RID: 20561 RVA: 0x00070924 File Offset: 0x0006ED24
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005052 RID: 20562 RVA: 0x0007092C File Offset: 0x0006ED2C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 2u:
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

		// Token: 0x06005053 RID: 20563 RVA: 0x000709A0 File Offset: 0x0006EDA0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005054 RID: 20564 RVA: 0x000709A7 File Offset: 0x0006EDA7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005055 RID: 20565 RVA: 0x000709B0 File Offset: 0x0006EDB0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventurerCombatController.<UnitReceivesHeal>c__Iterator3 <UnitReceivesHeal>c__Iterator = new AdventurerCombatController.<UnitReceivesHeal>c__Iterator3();
			<UnitReceivesHeal>c__Iterator.$this = this;
			<UnitReceivesHeal>c__Iterator.healEvent = healEvent;
			return <UnitReceivesHeal>c__Iterator;
		}

		// Token: 0x04003E4F RID: 15951
		internal BattleHeal healEvent;

		// Token: 0x04003E50 RID: 15952
		internal bool <showEffect>__0;

		// Token: 0x04003E51 RID: 15953
		internal IEnumerator $locvar0;

		// Token: 0x04003E52 RID: 15954
		internal object <_>__1;

		// Token: 0x04003E53 RID: 15955
		internal IDisposable $locvar1;

		// Token: 0x04003E54 RID: 15956
		internal AdventurerCombatController $this;

		// Token: 0x04003E55 RID: 15957
		internal object $current;

		// Token: 0x04003E56 RID: 15958
		internal bool $disposing;

		// Token: 0x04003E57 RID: 15959
		internal int $PC;
	}

	// Token: 0x02000BD7 RID: 3031
	[CompilerGenerated]
	private sealed class <UnitReceivesDamage>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005056 RID: 20566 RVA: 0x000709F0 File Offset: 0x0006EDF0
		[DebuggerHidden]
		public <UnitReceivesDamage>c__Iterator4()
		{
		}

		// Token: 0x06005057 RID: 20567 RVA: 0x000709F8 File Offset: 0x0006EDF8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (base.isActiveAndEnabled)
				{
					this.$current = this.DisplayEffect(damageEvent.DamageSource, true, true, true);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				goto IL_12B;
			case 1u:
				this._effectColorController.PlayHurt();
				this._combatAnimator.Hurt();
				enumerator = base.<UnitReceivesDamage>__BaseCallProxy1(damageEvent).GetEnumerator();
				num = 4294967293u;
				break;
			case 2u:
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
						this.$PC = 2;
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
			IL_12B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001118 RID: 4376
		// (get) Token: 0x06005058 RID: 20568 RVA: 0x00070B4C File Offset: 0x0006EF4C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001119 RID: 4377
		// (get) Token: 0x06005059 RID: 20569 RVA: 0x00070B54 File Offset: 0x0006EF54
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600505A RID: 20570 RVA: 0x00070B5C File Offset: 0x0006EF5C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 2u:
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

		// Token: 0x0600505B RID: 20571 RVA: 0x00070BD0 File Offset: 0x0006EFD0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600505C RID: 20572 RVA: 0x00070BD7 File Offset: 0x0006EFD7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600505D RID: 20573 RVA: 0x00070BE0 File Offset: 0x0006EFE0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventurerCombatController.<UnitReceivesDamage>c__Iterator4 <UnitReceivesDamage>c__Iterator = new AdventurerCombatController.<UnitReceivesDamage>c__Iterator4();
			<UnitReceivesDamage>c__Iterator.$this = this;
			<UnitReceivesDamage>c__Iterator.damageEvent = damageEvent;
			return <UnitReceivesDamage>c__Iterator;
		}

		// Token: 0x04003E58 RID: 15960
		internal BattleDamage damageEvent;

		// Token: 0x04003E59 RID: 15961
		internal IEnumerator $locvar0;

		// Token: 0x04003E5A RID: 15962
		internal object <_>__1;

		// Token: 0x04003E5B RID: 15963
		internal IDisposable $locvar1;

		// Token: 0x04003E5C RID: 15964
		internal AdventurerCombatController $this;

		// Token: 0x04003E5D RID: 15965
		internal object $current;

		// Token: 0x04003E5E RID: 15966
		internal bool $disposing;

		// Token: 0x04003E5F RID: 15967
		internal int $PC;
	}
}
