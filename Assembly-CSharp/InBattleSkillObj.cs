using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200035D RID: 861
public class InBattleSkillObj : GenericHoverController, ISkillItemController
{
	// Token: 0x06001712 RID: 5906 RVA: 0x000B4C6A File Offset: 0x000B306A
	public InBattleSkillObj()
	{
	}

	// Token: 0x17000131 RID: 305
	// (get) Token: 0x06001713 RID: 5907 RVA: 0x000B4C72 File Offset: 0x000B3072
	// (set) Token: 0x06001714 RID: 5908 RVA: 0x000B4C7A File Offset: 0x000B307A
	public AdventureUnitSkill _battleSkill
	{
		[CompilerGenerated]
		get
		{
			return this.<_battleSkill>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<_battleSkill>k__BackingField = value;
		}
	}

	// Token: 0x06001715 RID: 5909 RVA: 0x000B4C83 File Offset: 0x000B3083
	public AdventureUnitSkill GetAdventureUnitSkill()
	{
		return this._battleSkill;
	}

	// Token: 0x06001716 RID: 5910 RVA: 0x000B4C8B File Offset: 0x000B308B
	public void SkillSelected()
	{
		if (this.SkillAnimator == null)
		{
			return;
		}
		this.SkillAnimator.SetTrigger("PerformSkill");
	}

	// Token: 0x06001717 RID: 5911 RVA: 0x000B4CAF File Offset: 0x000B30AF
	public override void Start()
	{
		if (base.gameObject.activeSelf)
		{
			this.SkillAnimator = base.GetComponentInChildren<Animator>();
			this.SkillAnimationImage = this.SkillAnimator.GetComponent<Image>();
		}
		base.Start();
	}

	// Token: 0x06001718 RID: 5912 RVA: 0x000B4CE4 File Offset: 0x000B30E4
	public virtual void Update()
	{
		if (this._pointerIn && this._battleSkill != null)
		{
			this.UpdateSkillInfo();
		}
	}

	// Token: 0x06001719 RID: 5913 RVA: 0x000B4D04 File Offset: 0x000B3104
	public virtual void UpdateSkillInfo()
	{
		if (this._battleSkill == null)
		{
			return;
		}
		TooltipItem skillItemTooltip = this.GetSkillItemTooltip(this._battleSkill.Skill, true, this._battleSkill);
		if (this._battleSkill.Skill.CommandType == SkillCommandType.Active)
		{
			ActiveSkillLogicBase activeSkillLogicBase = this._battleSkill.Skill.SkillType.GetSkillLogic() as ActiveSkillLogicBase;
			if (activeSkillLogicBase != null)
			{
				skillItemTooltip.Type = string.Concat(new object[]
				{
					UIComponentType.SkillIconGaugeCostTitle.GetName(),
					"： ",
					activeSkillLogicBase.GetGaugeCost(this._battleSkill.Skill, base.GetComponentInParent<InBattleUnitCardLayout>().BattleUnit).DoubleToString(),
					"\n",
					UIComponentType.SkillIconCoolingDownSecondesTitle.GetName(),
					"：",
					activeSkillLogicBase.CoolingDownSeconds(this._battleSkill.Skill)
				});
			}
			TooltipItem tooltipItem = skillItemTooltip;
			tooltipItem.Type = tooltipItem.Type + "\n<size=11>" + ("*" + UIComponentType.ActiveSkillShortCutText.GetName().ReplaceToBuilder(UIComponentKey.Number, this.KeyboradShortcut).ToString()).ToColor(ColorPicker.Yellow) + "</size>";
		}
		this.OpenTooltip(skillItemTooltip, null, TooltipPosition.BottomRight, -287f, 98f);
	}

	// Token: 0x0600171A RID: 5914 RVA: 0x000B4E4E File Offset: 0x000B324E
	public void SetSprite(Sprite SkillIcontobe)
	{
		this.SkillImage.sprite = SkillIcontobe;
		this.SkillAnimationImage.sprite = this.SkillImage.sprite;
	}

	// Token: 0x0600171B RID: 5915 RVA: 0x000B4E72 File Offset: 0x000B3272
	public virtual void SetUnitBattleSkill(AdventureUnitSkill unitSkill, IBattleUnit battleUnit)
	{
		this._battleSkill = unitSkill;
		this.BattleUnit = battleUnit;
	}

	// Token: 0x0600171C RID: 5916 RVA: 0x000B4E84 File Offset: 0x000B3284
	private IEnumerable Highlight()
	{
		yield return new WaitForSeconds(1f);
		this.DeHighlightSkill();
		yield break;
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x000B4EA7 File Offset: 0x000B32A7
	public void DeHighlightSkill()
	{
	}

	// Token: 0x0400171C RID: 5916
	public Image SkillImage;

	// Token: 0x0400171D RID: 5917
	public Image SkillAnimationImage;

	// Token: 0x0400171E RID: 5918
	public Animator SkillAnimator;

	// Token: 0x0400171F RID: 5919
	public string KeyboradShortcut;

	// Token: 0x04001720 RID: 5920
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureUnitSkill <_battleSkill>k__BackingField;

	// Token: 0x04001721 RID: 5921
	protected IBattleUnit BattleUnit;

	// Token: 0x02000CB2 RID: 3250
	[CompilerGenerated]
	private sealed class <Highlight>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600540A RID: 21514 RVA: 0x000B4EA9 File Offset: 0x000B32A9
		[DebuggerHidden]
		public <Highlight>c__Iterator0()
		{
		}

		// Token: 0x0600540B RID: 21515 RVA: 0x000B4EB4 File Offset: 0x000B32B4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				base.DeHighlightSkill();
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011D2 RID: 4562
		// (get) Token: 0x0600540C RID: 21516 RVA: 0x000B4F1B File Offset: 0x000B331B
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011D3 RID: 4563
		// (get) Token: 0x0600540D RID: 21517 RVA: 0x000B4F23 File Offset: 0x000B3323
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600540E RID: 21518 RVA: 0x000B4F2B File Offset: 0x000B332B
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600540F RID: 21519 RVA: 0x000B4F3B File Offset: 0x000B333B
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005410 RID: 21520 RVA: 0x000B4F42 File Offset: 0x000B3342
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005411 RID: 21521 RVA: 0x000B4F4C File Offset: 0x000B334C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InBattleSkillObj.<Highlight>c__Iterator0 <Highlight>c__Iterator = new InBattleSkillObj.<Highlight>c__Iterator0();
			<Highlight>c__Iterator.$this = this;
			return <Highlight>c__Iterator;
		}

		// Token: 0x04004188 RID: 16776
		internal InBattleSkillObj $this;

		// Token: 0x04004189 RID: 16777
		internal object $current;

		// Token: 0x0400418A RID: 16778
		internal bool $disposing;

		// Token: 0x0400418B RID: 16779
		internal int $PC;
	}
}
