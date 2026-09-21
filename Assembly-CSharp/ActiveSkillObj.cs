using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000361 RID: 865
public class ActiveSkillObj : InBattleSkillObj, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x0600174E RID: 5966 RVA: 0x000B5321 File Offset: 0x000B3721
	public ActiveSkillObj()
	{
	}

	// Token: 0x0600174F RID: 5967 RVA: 0x000B532C File Offset: 0x000B372C
	public override void Update()
	{
		if (this._activeLogic == null)
		{
			return;
		}
		if (this._activeLogic.IsCastable(base._battleSkill))
		{
			this.CoolingDownText.gameObject.SetActive(false);
			this.ActiveEffects.ForEach(delegate(GameObject a)
			{
				a.SetActive(true);
			});
			if (this.BattleUnit != null)
			{
				bool flag = this.BattleUnit.BattleEffects.Any((BattleEffectBase b) => b is FreeCastEffect);
				this.GlowImage.color = ((!flag) ? this.NormalColor : this.FreeCastColor);
				this.GlowParticle.main.startColor = ((!flag) ? this.NormalColor : this.FreeCastColor);
			}
		}
		else
		{
			this.ActiveEffects.ForEach(delegate(GameObject a)
			{
				a.SetActive(false);
			});
			float coolingDownRemainingSeconds = this._activeLogic.GetCoolingDownRemainingSeconds(base._battleSkill);
			this.CoolingDownText.text = Math.Round((double)coolingDownRemainingSeconds, 1) + string.Empty;
			this.CoolingDownText.gameObject.SetActive(coolingDownRemainingSeconds > 0f);
		}
		base.Update();
	}

	// Token: 0x06001750 RID: 5968 RVA: 0x000B54A0 File Offset: 0x000B38A0
	public override void SetUnitBattleSkill(AdventureUnitSkill unitSkill, IBattleUnit battleUnit)
	{
		this._logic = unitSkill.Skill.SkillType.GetSkillLogic();
		if (this._logic is ActiveSkillLogicBase)
		{
			this._activeLogic = (this._logic as ActiveSkillLogicBase);
			this._totalCoolingDownSeconds = this._activeLogic.CoolingDownSeconds(unitSkill.Skill);
			if (this._totalCoolingDownSeconds != null)
			{
				this.CoolingDownText.text = this._totalCoolingDownSeconds.Value.ToString("0.0") + string.Empty;
			}
			else
			{
				this.CoolingDownText.gameObject.SetActive(false);
			}
		}
		this.SkillAvailable(true);
		base.SetUnitBattleSkill(unitSkill, battleUnit);
	}

	// Token: 0x17000136 RID: 310
	// (get) Token: 0x06001751 RID: 5969 RVA: 0x000B555D File Offset: 0x000B395D
	// (set) Token: 0x06001752 RID: 5970 RVA: 0x000B5565 File Offset: 0x000B3965
	public bool ActiveSkillCastable
	{
		[CompilerGenerated]
		get
		{
			return this.<ActiveSkillCastable>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<ActiveSkillCastable>k__BackingField = value;
		}
	}

	// Token: 0x06001753 RID: 5971 RVA: 0x000B556E File Offset: 0x000B396E
	public void SettingUnitActiveSkillCanBeCasted(bool castable)
	{
		this.ActiveSkillCastable = castable;
	}

	// Token: 0x06001754 RID: 5972 RVA: 0x000B5577 File Offset: 0x000B3977
	public void SkillAvailable(bool isUnavailable)
	{
		this.SkillUnavailableObj.gameObject.SetActive(isUnavailable);
	}

	// Token: 0x06001755 RID: 5973 RVA: 0x000B558A File Offset: 0x000B398A
	public void OnEnable()
	{
		this._isInProcess = false;
	}

	// Token: 0x06001756 RID: 5974 RVA: 0x000B5593 File Offset: 0x000B3993
	public void OnPointerClick(PointerEventData eventData)
	{
		this.TrigerActiveSkill();
	}

	// Token: 0x06001757 RID: 5975 RVA: 0x000B559C File Offset: 0x000B399C
	public void TrigerActiveSkill()
	{
		if (this._activeLogic == null)
		{
			return;
		}
		if (!this._isInProcess && this._activeLogic.IsCastable(base._battleSkill) && !TimeController.Instance.GetPauseStatus())
		{
			base.StartCoroutine(this.CastSkill());
		}
	}

	// Token: 0x06001758 RID: 5976 RVA: 0x000B55F4 File Offset: 0x000B39F4
	private IEnumerator CastSkill()
	{
		if (this._activeLogic == null)
		{
			yield break;
		}
		if (!this.ActiveSkillCastable)
		{
			yield break;
		}
		if (this._activeLogic.IsCastable(base._battleSkill) && !this._isInProcess)
		{
			ActiveSkillTargetingStrategyBase targetingStrategy = this._activeLogic.InitiatingTargetingStrategy(base._battleSkill);
			if (targetingStrategy.IsResolved)
			{
				base.GetComponentInParent<AdventureUIController>().HideChooseTargetNotifyText();
				this._isInProcess = true;
				IEnumerator enumerator = this._activeLogic.Cast(base._battleSkill, targetingStrategy, false).GetEnumerator();
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
				this._isInProcess = false;
			}
			else
			{
				base.GetComponentInParent<AdventureUIController>().ShowChooseTargetNotifyText();
				List<IBattleUnit> candidates = targetingStrategy.GetCandidates();
				BattleManager.instance.ActiveSkillSelectionState(candidates, targetingStrategy);
			}
			this.ClickAnim.SetTrigger("Clicked");
		}
		yield break;
	}

	// Token: 0x06001759 RID: 5977 RVA: 0x000B560F File Offset: 0x000B3A0F
	[CompilerGenerated]
	private static void <Update>m__0(GameObject a)
	{
		a.SetActive(true);
	}

	// Token: 0x0600175A RID: 5978 RVA: 0x000B5618 File Offset: 0x000B3A18
	[CompilerGenerated]
	private static bool <Update>m__1(BattleEffectBase b)
	{
		return b is FreeCastEffect;
	}

	// Token: 0x0600175B RID: 5979 RVA: 0x000B5623 File Offset: 0x000B3A23
	[CompilerGenerated]
	private static void <Update>m__2(GameObject a)
	{
		a.SetActive(false);
	}

	// Token: 0x04001743 RID: 5955
	public Image CoolingProgressImage;

	// Token: 0x04001744 RID: 5956
	public GameObject SkillUnavailableObj;

	// Token: 0x04001745 RID: 5957
	private SkillLogicBase _logic;

	// Token: 0x04001746 RID: 5958
	private ActiveSkillLogicBase _activeLogic;

	// Token: 0x04001747 RID: 5959
	public TextMeshProUGUI CoolingDownText;

	// Token: 0x04001748 RID: 5960
	public List<GameObject> ActiveEffects;

	// Token: 0x04001749 RID: 5961
	public Animator ClickAnim;

	// Token: 0x0400174A RID: 5962
	public Color NormalColor;

	// Token: 0x0400174B RID: 5963
	public Color FreeCastColor;

	// Token: 0x0400174C RID: 5964
	public Image GlowImage;

	// Token: 0x0400174D RID: 5965
	public ParticleSystem GlowParticle;

	// Token: 0x0400174E RID: 5966
	private float? _totalCoolingDownSeconds;

	// Token: 0x0400174F RID: 5967
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <ActiveSkillCastable>k__BackingField;

	// Token: 0x04001750 RID: 5968
	private bool _isInProcess;

	// Token: 0x04001751 RID: 5969
	[CompilerGenerated]
	private static Action<GameObject> <>f__am$cache0;

	// Token: 0x04001752 RID: 5970
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache1;

	// Token: 0x04001753 RID: 5971
	[CompilerGenerated]
	private static Action<GameObject> <>f__am$cache2;

	// Token: 0x02000CB9 RID: 3257
	[CompilerGenerated]
	private sealed class <CastSkill>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005432 RID: 21554 RVA: 0x000B562C File Offset: 0x000B3A2C
		[DebuggerHidden]
		public <CastSkill>c__Iterator0()
		{
		}

		// Token: 0x06005433 RID: 21555 RVA: 0x000B5634 File Offset: 0x000B3A34
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (this._activeLogic == null)
				{
					return false;
				}
				if (!base.ActiveSkillCastable)
				{
					return false;
				}
				if (!this._activeLogic.IsCastable(base._battleSkill) || this._isInProcess)
				{
					goto IL_1CF;
				}
				targetingStrategy = this._activeLogic.InitiatingTargetingStrategy(base._battleSkill);
				if (!targetingStrategy.IsResolved)
				{
					base.GetComponentInParent<AdventureUIController>().ShowChooseTargetNotifyText();
					List<IBattleUnit> candidates = targetingStrategy.GetCandidates();
					BattleManager.instance.ActiveSkillSelectionState(candidates, targetingStrategy);
					goto IL_1BA;
				}
				base.GetComponentInParent<AdventureUIController>().HideChooseTargetNotifyText();
				this._isInProcess = true;
				enumerator = this._activeLogic.Cast(base._battleSkill, targetingStrategy, false).GetEnumerator();
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
			this._isInProcess = false;
			IL_1BA:
			this.ClickAnim.SetTrigger("Clicked");
			IL_1CF:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011DC RID: 4572
		// (get) Token: 0x06005434 RID: 21556 RVA: 0x000B582C File Offset: 0x000B3C2C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011DD RID: 4573
		// (get) Token: 0x06005435 RID: 21557 RVA: 0x000B5834 File Offset: 0x000B3C34
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005436 RID: 21558 RVA: 0x000B583C File Offset: 0x000B3C3C
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

		// Token: 0x06005437 RID: 21559 RVA: 0x000B58AC File Offset: 0x000B3CAC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040041B0 RID: 16816
		internal ActiveSkillTargetingStrategyBase <targetingStrategy>__1;

		// Token: 0x040041B1 RID: 16817
		internal IEnumerator $locvar0;

		// Token: 0x040041B2 RID: 16818
		internal object <_>__2;

		// Token: 0x040041B3 RID: 16819
		internal IDisposable $locvar1;

		// Token: 0x040041B4 RID: 16820
		internal ActiveSkillObj $this;

		// Token: 0x040041B5 RID: 16821
		internal object $current;

		// Token: 0x040041B6 RID: 16822
		internal bool $disposing;

		// Token: 0x040041B7 RID: 16823
		internal int $PC;
	}
}
