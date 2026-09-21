using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200012C RID: 300
public class EnemyCombatController : UnitCombatController, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler, IEventSystemHandler
{
	// Token: 0x06000869 RID: 2153 RVA: 0x000754D6 File Offset: 0x000738D6
	public EnemyCombatController()
	{
	}

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x0600086A RID: 2154 RVA: 0x000754F4 File Offset: 0x000738F4
	// (set) Token: 0x0600086B RID: 2155 RVA: 0x000754FC File Offset: 0x000738FC
	public Animator Animator
	{
		[CompilerGenerated]
		get
		{
			return this.<Animator>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Animator>k__BackingField = value;
		}
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x00075508 File Offset: 0x00073908
	public override IEnumerable UnitCastsActiveSkill(ActiveSkillCastBattleEvent activeSkillEvent)
	{
		yield break;
	}

	// Token: 0x0600086D RID: 2157 RVA: 0x00075524 File Offset: 0x00073924
	public Transform GetTargetedParenTransform()
	{
		return this.Animator.transform;
	}

	// Token: 0x0600086E RID: 2158 RVA: 0x00075534 File Offset: 0x00073934
	public override IEnumerable UnitNormalAttack(IBattleUnit unit, float animationWaitTime = 0.5f)
	{
		yield return base.MoveForward();
		try
		{
			this.Animator.Play("Attack");
		}
		catch (Exception innerException)
		{
			SteamExceptionHandle.Handle(new Exception("Unit normal attack.", innerException), 0u);
		}
		yield return new WaitForSeconds(animationWaitTime);
		yield return base.MoveBack();
		yield break;
	}

	// Token: 0x0600086F RID: 2159 RVA: 0x00075560 File Offset: 0x00073960
	public override void Init(IBattleUnit enemyBattle, Vector3 attackMoveToDestination, bool reverseHealthBar = false)
	{
		this.MovingSpeed = this.EnemyMovingSpeed;
		BoxCollider2D componentInChildren = base.GetComponentInChildren<BoxCollider2D>();
		if (componentInChildren == null)
		{
			UnityEngine.Debug.LogError("This error can be ignored  : Eric please attach BoxCollider2D to " + enemyBattle.GetUnitType() + " other wise click won't work");
		}
		this.Animator = base.GetComponentInChildren<Animator>();
		this.Animator.updateMode = AnimatorUpdateMode.Normal;
		bool reverseHealthbar = false;
		GenericAdventurer componentInChildren2 = base.GetComponentInChildren<GenericAdventurer>();
		if (componentInChildren2 != null)
		{
			componentInChildren2.InitAppearanceBaseOnUnitClass(enemyBattle.GetUnitType());
			base.GetComponent<AdventurerCombatAnimator>().IdleInCombat();
			reverseHealthbar = true;
		}
		base.Init(enemyBattle, attackMoveToDestination, reverseHealthbar);
	}

	// Token: 0x06000870 RID: 2160 RVA: 0x000755FA File Offset: 0x000739FA
	public void FirstInit(IBattleUnit battleUnit)
	{
		base.BattleUnit = battleUnit;
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x00075604 File Offset: 0x00073A04
	public override IEnumerable UnitReceivesHeal(BattleHeal healEvent)
	{
		yield return this.DisplayEffect(healEvent.HealSource, healEvent.HealSource.SourceUnit.IsPlayer, true, true);
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

	// Token: 0x06000872 RID: 2162 RVA: 0x00075630 File Offset: 0x00073A30
	public override IEnumerable UnitReceivesDamage(BattleDamage damageEvent)
	{
		if (damageEvent.Target.GetId() != base.BattleUnit.GetId())
		{
			yield break;
		}
		bool isDirectDamage = true;
		if (damageEvent.Damages.Count > 0)
		{
			isDirectDamage = damageEvent.Damages[0].IsDirectDamage;
		}
		if (base.isActiveAndEnabled)
		{
			yield return this.DisplayEffect(damageEvent.DamageSource, false, isDirectDamage, true);
		}
		try
		{
			this.Animator.Play("Hurt");
		}
		catch (Exception innerException)
		{
			SteamExceptionHandle.Handle(new Exception("Unit normal hurt.", innerException), 0u);
		}
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
		yield break;
	}

	// Token: 0x06000873 RID: 2163 RVA: 0x0007565C File Offset: 0x00073A5C
	public override IEnumerable UnitCastsSkill(SkillCastBattleEvent skillEvent, float animationWaitTime = 0.5f)
	{
		yield return base.MoveForward();
		try
		{
			this.Animator.Play("Attack");
		}
		catch (Exception innerException)
		{
			SteamExceptionHandle.Handle(new Exception("Unit cast skill.", innerException), 0u);
		}
		yield return new WaitForSeconds(animationWaitTime);
		IEnumerator enumerator = this.PlayCastSkillEffect(skillEvent).GetEnumerator();
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
		yield return base.MoveBack();
		yield break;
	}

	// Token: 0x06000874 RID: 2164 RVA: 0x00075690 File Offset: 0x00073A90
	protected IEnumerable PlayCastSkillEffect(SkillCastBattleEvent skillEvent)
	{
		this.PopupSkillNameWhenCastsSkill(skillEvent.Skill.Skill.SkillType);
		UnityEngine.Object prefab = Resources.Load(FilePath.GetPreSkillEffect(skillEvent.Skill.Skill.SkillType));
		if (prefab != null && base.isActiveAndEnabled)
		{
			SkillEffectController effectController = UnityEngine.Object.Instantiate<GameObject>(prefab as GameObject).GetComponent<SkillEffectController>();
			effectController.transform.localScale = new Vector3(-1f, 1f, 1f);
			Transform casTransform = CombatManager.Instance.GetAdventureSkillCastPonit();
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
		yield break;
	}

	// Token: 0x06000875 RID: 2165 RVA: 0x000756BC File Offset: 0x00073ABC
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left && base.IsBoxColliderEnabled && this._isInTargetCandidates)
		{
			if (BattleManager.instance._targetingStrategy == null)
			{
				BattleManager.instance.AdventureUi.HideChooseTargetNotifyText();
				BattleManager.instance.ActiveSkillReleased();
			}
			BattleManager.instance.SettingTarget(this);
		}
	}

	// Token: 0x06000876 RID: 2166 RVA: 0x00075720 File Offset: 0x00073B20
	public virtual void HighlightCorresponseUnit(List<IBattleUnit> units)
	{
		foreach (IBattleUnit battleUnit in units)
		{
			if (battleUnit.GetId() == base.BattleUnit.GetId())
			{
				BoxCollider2D componentInChildren = base.GetComponentInChildren<BoxCollider2D>();
				Vector2 offset = componentInChildren.offset;
				Vector3 localScale = this.Animator.transform.localScale;
				float num = this._targetsScaleFactor / localScale.x;
				if (this._targertGameObject == null)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(FilePath.GetTargetingGameObject);
					gameObject.transform.SetParent(this.Animator.transform, false);
					this._targertGameObject = gameObject.GetComponent<UnitTargetObj>();
					this._targertGameObject.SetIsFriendlyUnit(false);
				}
				else
				{
					this._targertGameObject.gameObject.SetActive(true);
				}
				this._targertGameObject.transform.localScale = new Vector3(num, num, num);
				this._targertGameObject.transform.SetSiblingIndex(0);
				this._targertGameObject.transform.localPosition = offset;
				this.SetActiveStatus(true);
			}
		}
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x00075874 File Offset: 0x00073C74
	public void ActiveSkillReleased()
	{
		this.SetActiveStatus(false);
		if (this._targertGameObject != null)
		{
			this._targertGameObject.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000878 RID: 2168 RVA: 0x0007589F File Offset: 0x00073C9F
	private void SetActiveStatus(bool status)
	{
		this._isInTargetCandidates = status;
		if (this._targertGameObject != null)
		{
			this._targertGameObject.gameObject.SetActive(status);
		}
	}

	// Token: 0x06000879 RID: 2169 RVA: 0x000758CA File Offset: 0x00073CCA
	public void OnPointerExit(PointerEventData eventData)
	{
		if (base.IsBoxColliderEnabled && this._targertGameObject != null)
		{
			base.GetComponentInChildren<CombatUnitHealthController>().Diselect();
			this._targertGameObject.IsHovering(false);
		}
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x000758FF File Offset: 0x00073CFF
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (base.IsBoxColliderEnabled && this._isInTargetCandidates)
		{
			base.GetComponentInChildren<CombatUnitHealthController>().Select();
			this._targertGameObject.IsHovering(true);
		}
	}

	// Token: 0x0600087B RID: 2171 RVA: 0x0007592E File Offset: 0x00073D2E
	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable <UnitReceivesHeal>__BaseCallProxy0(BattleHeal heal)
	{
		return base.UnitReceivesHeal(heal);
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x00075937 File Offset: 0x00073D37
	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable <UnitReceivesDamage>__BaseCallProxy1(BattleDamage damageEvent)
	{
		return base.UnitReceivesDamage(damageEvent);
	}

	// Token: 0x04000B08 RID: 2824
	public float EnemyMovingSpeed = 120f;

	// Token: 0x04000B09 RID: 2825
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Animator <Animator>k__BackingField;

	// Token: 0x04000B0A RID: 2826
	private UnitTargetObj _targertGameObject;

	// Token: 0x04000B0B RID: 2827
	private float _targetsScaleFactor = 1.75f;

	// Token: 0x04000B0C RID: 2828
	private bool _isInTargetCandidates;

	// Token: 0x02000C04 RID: 3076
	[CompilerGenerated]
	private sealed class <UnitCastsActiveSkill>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005170 RID: 20848 RVA: 0x00075940 File Offset: 0x00073D40
		[DebuggerHidden]
		public <UnitCastsActiveSkill>c__Iterator0()
		{
		}

		// Token: 0x06005171 RID: 20849 RVA: 0x00075948 File Offset: 0x00073D48
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700115E RID: 4446
		// (get) Token: 0x06005172 RID: 20850 RVA: 0x00075962 File Offset: 0x00073D62
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700115F RID: 4447
		// (get) Token: 0x06005173 RID: 20851 RVA: 0x0007596A File Offset: 0x00073D6A
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005174 RID: 20852 RVA: 0x00075972 File Offset: 0x00073D72
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005175 RID: 20853 RVA: 0x00075974 File Offset: 0x00073D74
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005176 RID: 20854 RVA: 0x0007597B File Offset: 0x00073D7B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005177 RID: 20855 RVA: 0x00075983 File Offset: 0x00073D83
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new EnemyCombatController.<UnitCastsActiveSkill>c__Iterator0();
		}

		// Token: 0x04003F8C RID: 16268
		internal object $current;

		// Token: 0x04003F8D RID: 16269
		internal bool $disposing;

		// Token: 0x04003F8E RID: 16270
		internal int $PC;
	}

	// Token: 0x02000C05 RID: 3077
	[CompilerGenerated]
	private sealed class <UnitNormalAttack>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005178 RID: 20856 RVA: 0x0007599E File Offset: 0x00073D9E
		[DebuggerHidden]
		public <UnitNormalAttack>c__Iterator1()
		{
		}

		// Token: 0x06005179 RID: 20857 RVA: 0x000759A8 File Offset: 0x00073DA8
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
				try
				{
					base.Animator.Play("Attack");
				}
				catch (Exception innerException)
				{
					SteamExceptionHandle.Handle(new Exception("Unit normal attack.", innerException), 0u);
				}
				this.$current = new WaitForSeconds(animationWaitTime);
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

		// Token: 0x17001160 RID: 4448
		// (get) Token: 0x0600517A RID: 20858 RVA: 0x00075A98 File Offset: 0x00073E98
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001161 RID: 4449
		// (get) Token: 0x0600517B RID: 20859 RVA: 0x00075AA0 File Offset: 0x00073EA0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600517C RID: 20860 RVA: 0x00075AA8 File Offset: 0x00073EA8
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600517D RID: 20861 RVA: 0x00075AB8 File Offset: 0x00073EB8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600517E RID: 20862 RVA: 0x00075ABF File Offset: 0x00073EBF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600517F RID: 20863 RVA: 0x00075AC8 File Offset: 0x00073EC8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnemyCombatController.<UnitNormalAttack>c__Iterator1 <UnitNormalAttack>c__Iterator = new EnemyCombatController.<UnitNormalAttack>c__Iterator1();
			<UnitNormalAttack>c__Iterator.$this = this;
			<UnitNormalAttack>c__Iterator.animationWaitTime = animationWaitTime;
			return <UnitNormalAttack>c__Iterator;
		}

		// Token: 0x04003F8F RID: 16271
		internal float animationWaitTime;

		// Token: 0x04003F90 RID: 16272
		internal EnemyCombatController $this;

		// Token: 0x04003F91 RID: 16273
		internal object $current;

		// Token: 0x04003F92 RID: 16274
		internal bool $disposing;

		// Token: 0x04003F93 RID: 16275
		internal int $PC;
	}

	// Token: 0x02000C06 RID: 3078
	[CompilerGenerated]
	private sealed class <UnitReceivesHeal>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005180 RID: 20864 RVA: 0x00075B08 File Offset: 0x00073F08
		[DebuggerHidden]
		public <UnitReceivesHeal>c__Iterator2()
		{
		}

		// Token: 0x06005181 RID: 20865 RVA: 0x00075B10 File Offset: 0x00073F10
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this.$current = this.DisplayEffect(healEvent.HealSource, healEvent.HealSource.SourceUnit.IsPlayer, true, true);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				enumerator = base.<UnitReceivesHeal>__BaseCallProxy0(healEvent).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001162 RID: 4450
		// (get) Token: 0x06005182 RID: 20866 RVA: 0x00075C48 File Offset: 0x00074048
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001163 RID: 4451
		// (get) Token: 0x06005183 RID: 20867 RVA: 0x00075C50 File Offset: 0x00074050
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005184 RID: 20868 RVA: 0x00075C58 File Offset: 0x00074058
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

		// Token: 0x06005185 RID: 20869 RVA: 0x00075CCC File Offset: 0x000740CC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005186 RID: 20870 RVA: 0x00075CD3 File Offset: 0x000740D3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005187 RID: 20871 RVA: 0x00075CDC File Offset: 0x000740DC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnemyCombatController.<UnitReceivesHeal>c__Iterator2 <UnitReceivesHeal>c__Iterator = new EnemyCombatController.<UnitReceivesHeal>c__Iterator2();
			<UnitReceivesHeal>c__Iterator.$this = this;
			<UnitReceivesHeal>c__Iterator.healEvent = healEvent;
			return <UnitReceivesHeal>c__Iterator;
		}

		// Token: 0x04003F94 RID: 16276
		internal BattleHeal healEvent;

		// Token: 0x04003F95 RID: 16277
		internal IEnumerator $locvar0;

		// Token: 0x04003F96 RID: 16278
		internal object <_>__1;

		// Token: 0x04003F97 RID: 16279
		internal IDisposable $locvar1;

		// Token: 0x04003F98 RID: 16280
		internal EnemyCombatController $this;

		// Token: 0x04003F99 RID: 16281
		internal object $current;

		// Token: 0x04003F9A RID: 16282
		internal bool $disposing;

		// Token: 0x04003F9B RID: 16283
		internal int $PC;
	}

	// Token: 0x02000C07 RID: 3079
	[CompilerGenerated]
	private sealed class <UnitReceivesDamage>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005188 RID: 20872 RVA: 0x00075D1C File Offset: 0x0007411C
		[DebuggerHidden]
		public <UnitReceivesDamage>c__Iterator3()
		{
		}

		// Token: 0x06005189 RID: 20873 RVA: 0x00075D24 File Offset: 0x00074124
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (damageEvent.Target.GetId() != base.BattleUnit.GetId())
				{
					return false;
				}
				isDirectDamage = true;
				if (damageEvent.Damages.Count > 0)
				{
					isDirectDamage = damageEvent.Damages[0].IsDirectDamage;
				}
				if (base.isActiveAndEnabled)
				{
					this.$current = this.DisplayEffect(damageEvent.DamageSource, false, isDirectDamage, true);
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
				goto IL_127;
			default:
				return false;
			}
			try
			{
				base.Animator.Play("Hurt");
			}
			catch (Exception innerException)
			{
				SteamExceptionHandle.Handle(new Exception("Unit normal hurt.", innerException), 0u);
			}
			enumerator = base.<UnitReceivesDamage>__BaseCallProxy1(damageEvent).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_127:
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

		// Token: 0x17001164 RID: 4452
		// (get) Token: 0x0600518A RID: 20874 RVA: 0x00075F00 File Offset: 0x00074300
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001165 RID: 4453
		// (get) Token: 0x0600518B RID: 20875 RVA: 0x00075F08 File Offset: 0x00074308
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600518C RID: 20876 RVA: 0x00075F10 File Offset: 0x00074310
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

		// Token: 0x0600518D RID: 20877 RVA: 0x00075F84 File Offset: 0x00074384
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600518E RID: 20878 RVA: 0x00075F8B File Offset: 0x0007438B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600518F RID: 20879 RVA: 0x00075F94 File Offset: 0x00074394
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnemyCombatController.<UnitReceivesDamage>c__Iterator3 <UnitReceivesDamage>c__Iterator = new EnemyCombatController.<UnitReceivesDamage>c__Iterator3();
			<UnitReceivesDamage>c__Iterator.$this = this;
			<UnitReceivesDamage>c__Iterator.damageEvent = damageEvent;
			return <UnitReceivesDamage>c__Iterator;
		}

		// Token: 0x04003F9C RID: 16284
		internal BattleDamage damageEvent;

		// Token: 0x04003F9D RID: 16285
		internal bool <isDirectDamage>__0;

		// Token: 0x04003F9E RID: 16286
		internal IEnumerator $locvar0;

		// Token: 0x04003F9F RID: 16287
		internal object <_>__1;

		// Token: 0x04003FA0 RID: 16288
		internal IDisposable $locvar1;

		// Token: 0x04003FA1 RID: 16289
		internal EnemyCombatController $this;

		// Token: 0x04003FA2 RID: 16290
		internal object $current;

		// Token: 0x04003FA3 RID: 16291
		internal bool $disposing;

		// Token: 0x04003FA4 RID: 16292
		internal int $PC;
	}

	// Token: 0x02000C08 RID: 3080
	[CompilerGenerated]
	private sealed class <UnitCastsSkill>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005190 RID: 20880 RVA: 0x00075FD4 File Offset: 0x000743D4
		[DebuggerHidden]
		public <UnitCastsSkill>c__Iterator4()
		{
		}

		// Token: 0x06005191 RID: 20881 RVA: 0x00075FDC File Offset: 0x000743DC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
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
				try
				{
					base.Animator.Play("Attack");
				}
				catch (Exception innerException)
				{
					SteamExceptionHandle.Handle(new Exception("Unit cast skill.", innerException), 0u);
				}
				this.$current = new WaitForSeconds(animationWaitTime);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			case 2u:
				enumerator = base.PlayCastSkillEffect(skillEvent).GetEnumerator();
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
			this.$current = base.MoveBack();
			if (!this.$disposing)
			{
				this.$PC = 4;
			}
			return true;
		}

		// Token: 0x17001166 RID: 4454
		// (get) Token: 0x06005192 RID: 20882 RVA: 0x00076180 File Offset: 0x00074580
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001167 RID: 4455
		// (get) Token: 0x06005193 RID: 20883 RVA: 0x00076188 File Offset: 0x00074588
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005194 RID: 20884 RVA: 0x00076190 File Offset: 0x00074590
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

		// Token: 0x06005195 RID: 20885 RVA: 0x0007620C File Offset: 0x0007460C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005196 RID: 20886 RVA: 0x00076213 File Offset: 0x00074613
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005197 RID: 20887 RVA: 0x0007621C File Offset: 0x0007461C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnemyCombatController.<UnitCastsSkill>c__Iterator4 <UnitCastsSkill>c__Iterator = new EnemyCombatController.<UnitCastsSkill>c__Iterator4();
			<UnitCastsSkill>c__Iterator.$this = this;
			<UnitCastsSkill>c__Iterator.animationWaitTime = animationWaitTime;
			<UnitCastsSkill>c__Iterator.skillEvent = skillEvent;
			return <UnitCastsSkill>c__Iterator;
		}

		// Token: 0x04003FA5 RID: 16293
		internal float animationWaitTime;

		// Token: 0x04003FA6 RID: 16294
		internal SkillCastBattleEvent skillEvent;

		// Token: 0x04003FA7 RID: 16295
		internal IEnumerator $locvar0;

		// Token: 0x04003FA8 RID: 16296
		internal object <_>__1;

		// Token: 0x04003FA9 RID: 16297
		internal IDisposable $locvar1;

		// Token: 0x04003FAA RID: 16298
		internal EnemyCombatController $this;

		// Token: 0x04003FAB RID: 16299
		internal object $current;

		// Token: 0x04003FAC RID: 16300
		internal bool $disposing;

		// Token: 0x04003FAD RID: 16301
		internal int $PC;
	}

	// Token: 0x02000C09 RID: 3081
	[CompilerGenerated]
	private sealed class <PlayCastSkillEffect>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005198 RID: 20888 RVA: 0x00076268 File Offset: 0x00074668
		[DebuggerHidden]
		public <PlayCastSkillEffect>c__Iterator5()
		{
		}

		// Token: 0x06005199 RID: 20889 RVA: 0x00076270 File Offset: 0x00074670
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this.PopupSkillNameWhenCastsSkill(skillEvent.Skill.Skill.SkillType);
				prefab = Resources.Load(FilePath.GetPreSkillEffect(skillEvent.Skill.Skill.SkillType));
				if (!(prefab != null) || !base.isActiveAndEnabled)
				{
					goto IL_17A;
				}
				effectController = UnityEngine.Object.Instantiate<GameObject>(prefab as GameObject).GetComponent<SkillEffectController>();
				effectController.transform.localScale = new Vector3(-1f, 1f, 1f);
				casTransform = CombatManager.Instance.GetAdventureSkillCastPonit();
				enumerator = effectController.Cast(casTransform, null).GetEnumerator();
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
			IL_17A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001168 RID: 4456
		// (get) Token: 0x0600519A RID: 20890 RVA: 0x00076414 File Offset: 0x00074814
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001169 RID: 4457
		// (get) Token: 0x0600519B RID: 20891 RVA: 0x0007641C File Offset: 0x0007481C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600519C RID: 20892 RVA: 0x00076424 File Offset: 0x00074824
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

		// Token: 0x0600519D RID: 20893 RVA: 0x00076494 File Offset: 0x00074894
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600519E RID: 20894 RVA: 0x0007649B File Offset: 0x0007489B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600519F RID: 20895 RVA: 0x000764A4 File Offset: 0x000748A4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnemyCombatController.<PlayCastSkillEffect>c__Iterator5 <PlayCastSkillEffect>c__Iterator = new EnemyCombatController.<PlayCastSkillEffect>c__Iterator5();
			<PlayCastSkillEffect>c__Iterator.$this = this;
			<PlayCastSkillEffect>c__Iterator.skillEvent = skillEvent;
			return <PlayCastSkillEffect>c__Iterator;
		}

		// Token: 0x04003FAE RID: 16302
		internal SkillCastBattleEvent skillEvent;

		// Token: 0x04003FAF RID: 16303
		internal UnityEngine.Object <prefab>__0;

		// Token: 0x04003FB0 RID: 16304
		internal SkillEffectController <effectController>__1;

		// Token: 0x04003FB1 RID: 16305
		internal Transform <casTransform>__1;

		// Token: 0x04003FB2 RID: 16306
		internal IEnumerator $locvar0;

		// Token: 0x04003FB3 RID: 16307
		internal object <_>__2;

		// Token: 0x04003FB4 RID: 16308
		internal IDisposable $locvar1;

		// Token: 0x04003FB5 RID: 16309
		internal EnemyCombatController $this;

		// Token: 0x04003FB6 RID: 16310
		internal object $current;

		// Token: 0x04003FB7 RID: 16311
		internal bool $disposing;

		// Token: 0x04003FB8 RID: 16312
		internal int $PC;
	}
}
