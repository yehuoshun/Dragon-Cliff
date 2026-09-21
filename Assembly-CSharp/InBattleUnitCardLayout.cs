using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200034D RID: 845
public abstract class InBattleUnitCardLayout : MonoBehaviour
{
	// Token: 0x06001686 RID: 5766 RVA: 0x000B08DB File Offset: 0x000AECDB
	protected InBattleUnitCardLayout()
	{
	}

	// Token: 0x17000130 RID: 304
	// (get) Token: 0x06001687 RID: 5767 RVA: 0x000B08EE File Offset: 0x000AECEE
	// (set) Token: 0x06001688 RID: 5768 RVA: 0x000B08F6 File Offset: 0x000AECF6
	public IBattleUnit BattleUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleUnit>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<BattleUnit>k__BackingField = value;
		}
	}

	// Token: 0x06001689 RID: 5769 RVA: 0x000B0900 File Offset: 0x000AED00
	public virtual void SetBattleUnit(IBattleUnit IbattleUnit, Sprite normalStandingSprite)
	{
		this.BattleUnit = IbattleUnit;
		if (this.AdventurerName != null)
		{
			if (this.BattleUnit is AdventurerBattleUnit)
			{
				this.AdventurerName.text = (this.BattleUnit as AdventurerBattleUnit).AdventurerProfile.GetUnitName();
			}
			else
			{
				this.AdventurerName.text = IbattleUnit.GetUnitType().GetDescription().Title;
			}
		}
		if (this.BattleUnit.GetUnitType().IsAdventurerLayout() || normalStandingSprite == null)
		{
			this.AdventurerImage.sprite = FilePath.GetCharaterNormalStandSpriteBasedOnCharacterBasicAppearance(FilePath.GetCharacterBasicAppearance(IbattleUnit.GetUnitType(), false));
		}
		else
		{
			this.AdventurerImage.sprite = normalStandingSprite;
		}
		this._originalSprite = this.AdventurerImage.sprite;
		this.BindListener(IbattleUnit);
		this.SetSkillImages((from en in IbattleUnit.Skills
		where en.Skill.CommandType != SkillCommandType.Active
		select en).ToList<AdventureUnitSkill>());
		this.SetActiveSkillImage(IbattleUnit.Skills.FirstOrDefault((AdventureUnitSkill en) => en.Skill.CommandType == SkillCommandType.Active));
		this.SetOutputCapacity(this.BattleUnit.GetOutputCapacity(AttributeRetrievalLevel.Gear), IbattleUnit);
	}

	// Token: 0x0600168A RID: 5770 RVA: 0x000B0A50 File Offset: 0x000AEE50
	private void SetActiveSkillImage(AdventureUnitSkill unitActiveSkill)
	{
		if (unitActiveSkill != null)
		{
			Sprite skillIconImage = FilePath.GetSkillIconImage(unitActiveSkill.Skill.SkillType);
			this.ActiveSkillObj.SetSprite(skillIconImage);
			this.ActiveSkillObj.SetUnitBattleSkill(unitActiveSkill, this.BattleUnit);
			this.ActiveSkillObj.SettingUnitActiveSkillCanBeCasted(this is AdventurerInBattleAsCardController);
			this.ActiveSkillObj.gameObject.SetActive(true);
		}
		else
		{
			this.ActiveSkillObj.SkillAvailable(false);
		}
	}

	// Token: 0x0600168B RID: 5771 RVA: 0x000B0AC8 File Offset: 0x000AEEC8
	public void BindListener(IBattleUnit adventurerBattleUnit)
	{
		if (adventurerBattleUnit.GetId() == this.BattleUnit.GetId())
		{
			this.BattleUnit.RegisterEventCallbackFromUiLayer(new Func<IBattleUnit, AdventureEventType, object, IEnumerable>(this.AdventurerBattleUnitOnReceivesEventCallBack));
		}
	}

	// Token: 0x0600168C RID: 5772 RVA: 0x000B0B00 File Offset: 0x000AEF00
	public virtual IEnumerable AdventurerBattleUnitOnReceivesEventCallBack(IBattleUnit battleUnit, AdventureEventType adventureEventType, object arg3)
	{
		if (base.isActiveAndEnabled)
		{
			switch (adventureEventType)
			{
			case AdventureEventType.UnitPostReceivesDamage:
			case AdventureEventType.UnitPostReceivesHeal:
				break;
			case AdventureEventType.UnitKilled:
				base.StartCoroutine(this.UnitDead(battleUnit));
				break;
			default:
				switch (adventureEventType)
				{
				case AdventureEventType.UnitEntersTurn:
					break;
				default:
					if (adventureEventType != AdventureEventType.UnitEffectTriggered)
					{
						if (adventureEventType != AdventureEventType.AttributeCheckup)
						{
							if (adventureEventType != AdventureEventType.ChargeUpdated)
							{
							}
						}
						else
						{
							base.StartCoroutine(this.CheckOutputAndDEFMDEFStatus().GetEnumerator());
						}
					}
					break;
				case AdventureEventType.UnitSelectedSkill:
				{
					AdventureUnitSkill adventureUnitSkill = arg3 as AdventureUnitSkill;
					if (adventureUnitSkill != null)
					{
						base.StartCoroutine(this.UnitSelectedSkill(battleUnit, adventureUnitSkill).GetEnumerator());
					}
					break;
				}
				case AdventureEventType.UnitCompletesTurn:
					break;
				}
				break;
			case AdventureEventType.UnitRevived:
				base.StartCoroutine(this.UnitRevived().GetEnumerator());
				break;
			case AdventureEventType.UnitLoosesEffect:
				break;
			case AdventureEventType.BattleEffectDispersed:
				break;
			case AdventureEventType.UnitReadyInBattle:
				base.StartCoroutine(this.CheckOutputAndDEFMDEFStatus().GetEnumerator());
				break;
			case AdventureEventType.UnitTurnProgressAlterred:
				break;
			}
		}
		yield break;
	}

	// Token: 0x0600168D RID: 5773 RVA: 0x000B0B38 File Offset: 0x000AEF38
	private IEnumerable UnitRevived()
	{
		yield return null;
		if (this._originalSprite != null)
		{
			this.AdventurerImage.sprite = this._originalSprite;
		}
		yield break;
	}

	// Token: 0x0600168E RID: 5774 RVA: 0x000B0B5C File Offset: 0x000AEF5C
	public IEnumerable RountineCheck()
	{
		while (this.BattleUnit != null && this.BattleUnit.IsAliveInBattle())
		{
			BattleUnitAttributeBriefSet brief = this.BattleUnit.GetAttributeBrief();
			this.AttackOutputText.SetLableText(brief.WithBattleEffects.OutputValue);
			this.MDEFText.SetLableText(brief.WithBattleEffects.Toughness);
			this.SpeedText.SetLableText(brief.WithBattleEffects.Agility);
			yield return new WaitForSeconds(1f);
		}
		yield break;
	}

	// Token: 0x0600168F RID: 5775 RVA: 0x000B0B80 File Offset: 0x000AEF80
	public IEnumerable CheckOutputAndDEFMDEFStatus()
	{
		yield return null;
		BattleUnitAttributeBriefSet brief = this.BattleUnit.GetAttributeBrief();
		this.AttackOutputText.SetLableText(brief.WithBattleEffects.OutputValue);
		this.MDEFText.SetLableText(brief.WithBattleEffects.Toughness);
		this.SpeedText.SetLableText(brief.WithBattleEffects.Agility);
		yield break;
	}

	// Token: 0x06001690 RID: 5776 RVA: 0x000B0BA4 File Offset: 0x000AEFA4
	public virtual void CheckCurrentBattleEffectsStatus()
	{
		List<IGrouping<BattleEffectType, BattleEffectBase>> list = (from b in this.BattleUnit.BattleEffects
		group b by b.BattleEffectType).ToList<IGrouping<BattleEffectType, BattleEffectBase>>();
		List<BattleEffectType> keys = new List<BattleEffectType>();
		using (List<IGrouping<BattleEffectType, BattleEffectBase>>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IGrouping<BattleEffectType, BattleEffectBase> groupByEffect = enumerator.Current;
				InBattleEffetGameObject inBattleEffetGameObject = this._inBattleEffetGameObjects.FirstOrDefault((InBattleEffetGameObject i) => i.GetBattleEffect().BattleEffectType == groupByEffect.Key);
				if (inBattleEffetGameObject != null)
				{
					int count = groupByEffect.ToList<BattleEffectBase>().Count;
					if (count != 0)
					{
						inBattleEffetGameObject.EffectCountLable.text = count.ToString();
					}
				}
				else
				{
					InBattleEffetGameObject inBattleEffetGameObject2 = this.InitNewBattleEffect(groupByEffect.FirstOrDefault<BattleEffectBase>());
					int count2 = groupByEffect.ToList<BattleEffectBase>().Count;
					if (count2 != 0)
					{
						inBattleEffetGameObject2.EffectCountLable.text = count2.ToString();
					}
				}
				BattleEffectType key = groupByEffect.Key;
				keys.Add(key);
			}
		}
		IEnumerable<InBattleEffetGameObject> second = from i in this._inBattleEffetGameObjects
		where keys.Contains(i.GetBattleEffect().BattleEffectType)
		select i;
		IEnumerable<InBattleEffetGameObject> enumerable = this._inBattleEffetGameObjects.Except(second);
		List<InBattleEffetGameObject> list2 = new List<InBattleEffetGameObject>();
		foreach (InBattleEffetGameObject inBattleEffetGameObject3 in enumerable)
		{
			list2.Add(inBattleEffetGameObject3);
			inBattleEffetGameObject3.EffectExpired();
		}
		foreach (InBattleEffetGameObject item in list2)
		{
			this._inBattleEffetGameObjects.Remove(item);
		}
	}

	// Token: 0x06001691 RID: 5777 RVA: 0x000B0DD4 File Offset: 0x000AF1D4
	private InBattleEffetGameObject InitNewBattleEffect(BattleEffectBase battleEffect)
	{
		GameObject gameObject = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/Battle/PanelRelatedPrefabs/New/NewEffect") as GameObject, base.transform.position, this.EffectsPanel);
		gameObject.transform.SetParent(this.EffectsPanel.transform);
		gameObject.transform.localScale = Vector3.one;
		InBattleEffetGameObject component = gameObject.GetComponent<InBattleEffetGameObject>();
		if (component != null)
		{
			component.SetBattleEffect(battleEffect);
			this._inBattleEffetGameObjects.Add(component);
			return component;
		}
		throw new Exception("script null");
	}

	// Token: 0x06001692 RID: 5778 RVA: 0x000B0E60 File Offset: 0x000AF260
	public virtual void SetOutputCapacity(UnitOutputCapacity capacity, IBattleUnit battleUnit)
	{
		this.AttackOutputTypeImage.sprite = FilePath.GetAttackTypeIconByOutputType(capacity.OutputAttribute);
		this.AttackOutputText.SetOriginalValue(capacity.Value, false, UIBattleUnitRelatedValueType.AttackOutput, battleUnit);
		this.MDEFText.SetOriginalValue(0.0, true, UIBattleUnitRelatedValueType.MagicDefense, battleUnit);
		this.SpeedText.SetOriginalValue(battleUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Gear), false, UIBattleUnitRelatedValueType.Speed, battleUnit);
	}

	// Token: 0x06001693 RID: 5779 RVA: 0x000B0EC4 File Offset: 0x000AF2C4
	public virtual void SetSkillImages(List<AdventureUnitSkill> SkillsToSetup)
	{
		for (int i = 0; i < this.SkillImages.Length; i++)
		{
			if (i < SkillsToSetup.Count)
			{
				Sprite skillIconImage = FilePath.GetSkillIconImage(SkillsToSetup[i].Skill.SkillType);
				this.SkillImages[i].SetSprite(skillIconImage);
				this.SkillImages[i].SetUnitBattleSkill(SkillsToSetup[i], this.BattleUnit);
				this.SkillImages[i].gameObject.SetActive(true);
			}
			else
			{
				this.SkillImages[i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001694 RID: 5780 RVA: 0x000B0F60 File Offset: 0x000AF360
	public void ResetAvatar()
	{
		if (this._originalSprite != null)
		{
			this.AdventurerImage.sprite = this._originalSprite;
		}
	}

	// Token: 0x06001695 RID: 5781 RVA: 0x000B0F84 File Offset: 0x000AF384
	public IEnumerator UnitDead(IBattleUnit adventurerBattleUnit)
	{
		yield return null;
		if (adventurerBattleUnit.GetId() == this.BattleUnit.GetId())
		{
			this.AdventurerImage.sprite = FilePath.GetDeadAvatarImage();
		}
		yield break;
	}

	// Token: 0x06001696 RID: 5782 RVA: 0x000B0FA8 File Offset: 0x000AF3A8
	public IEnumerable UnitSelectedSkill(IBattleUnit ActionUnit, AdventureUnitSkill Skill)
	{
		yield return null;
		if (this.BattleUnit.GetId() == ActionUnit.GetId())
		{
			foreach (InBattleSkillObj inBattleSkillObj in this.SkillImages)
			{
				if (inBattleSkillObj.GetAdventureUnitSkill() != null && Skill.Skill == inBattleSkillObj.GetAdventureUnitSkill().Skill && inBattleSkillObj.gameObject.activeSelf)
				{
					inBattleSkillObj.SkillSelected();
				}
			}
		}
		yield break;
	}

	// Token: 0x06001697 RID: 5783 RVA: 0x000B0FD9 File Offset: 0x000AF3D9
	public virtual void LeavesEncounter()
	{
		this.AttackOutputText.LeavesEncounter();
		this.DEFText.LeavesEncounter();
		this.MDEFText.LeavesEncounter();
	}

	// Token: 0x06001698 RID: 5784 RVA: 0x000B0FFC File Offset: 0x000AF3FC
	[CompilerGenerated]
	private static bool <SetBattleUnit>m__0(AdventureUnitSkill en)
	{
		return en.Skill.CommandType != SkillCommandType.Active;
	}

	// Token: 0x06001699 RID: 5785 RVA: 0x000B100F File Offset: 0x000AF40F
	[CompilerGenerated]
	private static bool <SetBattleUnit>m__1(AdventureUnitSkill en)
	{
		return en.Skill.CommandType == SkillCommandType.Active;
	}

	// Token: 0x0600169A RID: 5786 RVA: 0x000B101F File Offset: 0x000AF41F
	[CompilerGenerated]
	private static BattleEffectType <CheckCurrentBattleEffectsStatus>m__2(BattleEffectBase b)
	{
		return b.BattleEffectType;
	}

	// Token: 0x0400169C RID: 5788
	public Image AdventurerImage;

	// Token: 0x0400169D RID: 5789
	public Image AttackOutputTypeImage;

	// Token: 0x0400169E RID: 5790
	public AttackOutputInCardView AttackOutputText;

	// Token: 0x0400169F RID: 5791
	public AttackOutputInCardView DEFText;

	// Token: 0x040016A0 RID: 5792
	public AttackOutputInCardView MDEFText;

	// Token: 0x040016A1 RID: 5793
	public AttackOutputInCardView SpeedText;

	// Token: 0x040016A2 RID: 5794
	public TextMeshProUGUI AdventurerName;

	// Token: 0x040016A3 RID: 5795
	public InBattleSkillObj[] SkillImages;

	// Token: 0x040016A4 RID: 5796
	public ActiveSkillObj ActiveSkillObj;

	// Token: 0x040016A5 RID: 5797
	public GameObject EffectsPanel;

	// Token: 0x040016A6 RID: 5798
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <BattleUnit>k__BackingField;

	// Token: 0x040016A7 RID: 5799
	private List<InBattleEffetGameObject> _inBattleEffetGameObjects = new List<InBattleEffetGameObject>();

	// Token: 0x040016A8 RID: 5800
	private Sprite _originalSprite;

	// Token: 0x040016A9 RID: 5801
	[CompilerGenerated]
	private static Func<AdventureUnitSkill, bool> <>f__am$cache0;

	// Token: 0x040016AA RID: 5802
	[CompilerGenerated]
	private static Func<AdventureUnitSkill, bool> <>f__am$cache1;

	// Token: 0x040016AB RID: 5803
	[CompilerGenerated]
	private static Func<BattleEffectBase, BattleEffectType> <>f__am$cache2;

	// Token: 0x02000CA4 RID: 3236
	[CompilerGenerated]
	private sealed class <AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053BD RID: 21437 RVA: 0x000B1027 File Offset: 0x000AF427
		[DebuggerHidden]
		public <AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator0()
		{
		}

		// Token: 0x060053BE RID: 21438 RVA: 0x000B1030 File Offset: 0x000AF430
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (base.isActiveAndEnabled)
				{
					switch (adventureEventType)
					{
					case AdventureEventType.UnitPostReceivesDamage:
					case AdventureEventType.UnitPostReceivesHeal:
						break;
					case AdventureEventType.UnitKilled:
						base.StartCoroutine(base.UnitDead(battleUnit));
						break;
					default:
						switch (adventureEventType)
						{
						case AdventureEventType.UnitEntersTurn:
							break;
						default:
							if (adventureEventType != AdventureEventType.UnitEffectTriggered)
							{
								if (adventureEventType != AdventureEventType.AttributeCheckup)
								{
									if (adventureEventType != AdventureEventType.ChargeUpdated)
									{
									}
								}
								else
								{
									base.StartCoroutine(base.CheckOutputAndDEFMDEFStatus().GetEnumerator());
								}
							}
							break;
						case AdventureEventType.UnitSelectedSkill:
						{
							AdventureUnitSkill adventureUnitSkill = arg3 as AdventureUnitSkill;
							if (adventureUnitSkill != null)
							{
								base.StartCoroutine(base.UnitSelectedSkill(battleUnit, adventureUnitSkill).GetEnumerator());
							}
							break;
						}
						case AdventureEventType.UnitCompletesTurn:
							break;
						}
						break;
					case AdventureEventType.UnitRevived:
						base.StartCoroutine(base.UnitRevived().GetEnumerator());
						break;
					case AdventureEventType.UnitLoosesEffect:
						break;
					case AdventureEventType.BattleEffectDispersed:
						break;
					case AdventureEventType.UnitReadyInBattle:
						base.StartCoroutine(base.CheckOutputAndDEFMDEFStatus().GetEnumerator());
						break;
					case AdventureEventType.UnitTurnProgressAlterred:
						break;
					}
				}
			}
			return false;
		}

		// Token: 0x170011C0 RID: 4544
		// (get) Token: 0x060053BF RID: 21439 RVA: 0x000B11E3 File Offset: 0x000AF5E3
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011C1 RID: 4545
		// (get) Token: 0x060053C0 RID: 21440 RVA: 0x000B11EB File Offset: 0x000AF5EB
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053C1 RID: 21441 RVA: 0x000B11F3 File Offset: 0x000AF5F3
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060053C2 RID: 21442 RVA: 0x000B11F5 File Offset: 0x000AF5F5
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053C3 RID: 21443 RVA: 0x000B11FC File Offset: 0x000AF5FC
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053C4 RID: 21444 RVA: 0x000B1204 File Offset: 0x000AF604
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InBattleUnitCardLayout.<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator0 <AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator = new InBattleUnitCardLayout.<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator0();
			<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator.$this = this;
			<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator.adventureEventType = adventureEventType;
			<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator.arg3 = arg3;
			<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator.battleUnit = battleUnit;
			return <AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator;
		}

		// Token: 0x0400414E RID: 16718
		internal AdventureEventType adventureEventType;

		// Token: 0x0400414F RID: 16719
		internal object arg3;

		// Token: 0x04004150 RID: 16720
		internal IBattleUnit battleUnit;

		// Token: 0x04004151 RID: 16721
		internal InBattleUnitCardLayout $this;

		// Token: 0x04004152 RID: 16722
		internal object $current;

		// Token: 0x04004153 RID: 16723
		internal bool $disposing;

		// Token: 0x04004154 RID: 16724
		internal int $PC;
	}

	// Token: 0x02000CA5 RID: 3237
	[CompilerGenerated]
	private sealed class <UnitRevived>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053C5 RID: 21445 RVA: 0x000B125C File Offset: 0x000AF65C
		[DebuggerHidden]
		public <UnitRevived>c__Iterator1()
		{
		}

		// Token: 0x060053C6 RID: 21446 RVA: 0x000B1264 File Offset: 0x000AF664
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				if (this._originalSprite != null)
				{
					this.AdventurerImage.sprite = this._originalSprite;
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011C2 RID: 4546
		// (get) Token: 0x060053C7 RID: 21447 RVA: 0x000B12E8 File Offset: 0x000AF6E8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011C3 RID: 4547
		// (get) Token: 0x060053C8 RID: 21448 RVA: 0x000B12F0 File Offset: 0x000AF6F0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053C9 RID: 21449 RVA: 0x000B12F8 File Offset: 0x000AF6F8
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060053CA RID: 21450 RVA: 0x000B1308 File Offset: 0x000AF708
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053CB RID: 21451 RVA: 0x000B130F File Offset: 0x000AF70F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053CC RID: 21452 RVA: 0x000B1318 File Offset: 0x000AF718
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InBattleUnitCardLayout.<UnitRevived>c__Iterator1 <UnitRevived>c__Iterator = new InBattleUnitCardLayout.<UnitRevived>c__Iterator1();
			<UnitRevived>c__Iterator.$this = this;
			return <UnitRevived>c__Iterator;
		}

		// Token: 0x04004155 RID: 16725
		internal InBattleUnitCardLayout $this;

		// Token: 0x04004156 RID: 16726
		internal object $current;

		// Token: 0x04004157 RID: 16727
		internal bool $disposing;

		// Token: 0x04004158 RID: 16728
		internal int $PC;
	}

	// Token: 0x02000CA6 RID: 3238
	[CompilerGenerated]
	private sealed class <RountineCheck>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053CD RID: 21453 RVA: 0x000B134C File Offset: 0x000AF74C
		[DebuggerHidden]
		public <RountineCheck>c__Iterator2()
		{
		}

		// Token: 0x060053CE RID: 21454 RVA: 0x000B1354 File Offset: 0x000AF754
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				break;
			case 1u:
				break;
			default:
				return false;
			}
			if (base.BattleUnit != null && base.BattleUnit.IsAliveInBattle())
			{
				brief = base.BattleUnit.GetAttributeBrief();
				this.AttackOutputText.SetLableText(brief.WithBattleEffects.OutputValue);
				this.MDEFText.SetLableText(brief.WithBattleEffects.Toughness);
				this.SpeedText.SetLableText(brief.WithBattleEffects.Agility);
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011C4 RID: 4548
		// (get) Token: 0x060053CF RID: 21455 RVA: 0x000B1450 File Offset: 0x000AF850
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011C5 RID: 4549
		// (get) Token: 0x060053D0 RID: 21456 RVA: 0x000B1458 File Offset: 0x000AF858
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053D1 RID: 21457 RVA: 0x000B1460 File Offset: 0x000AF860
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060053D2 RID: 21458 RVA: 0x000B1470 File Offset: 0x000AF870
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053D3 RID: 21459 RVA: 0x000B1477 File Offset: 0x000AF877
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053D4 RID: 21460 RVA: 0x000B1480 File Offset: 0x000AF880
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InBattleUnitCardLayout.<RountineCheck>c__Iterator2 <RountineCheck>c__Iterator = new InBattleUnitCardLayout.<RountineCheck>c__Iterator2();
			<RountineCheck>c__Iterator.$this = this;
			return <RountineCheck>c__Iterator;
		}

		// Token: 0x04004159 RID: 16729
		internal BattleUnitAttributeBriefSet <brief>__1;

		// Token: 0x0400415A RID: 16730
		internal InBattleUnitCardLayout $this;

		// Token: 0x0400415B RID: 16731
		internal object $current;

		// Token: 0x0400415C RID: 16732
		internal bool $disposing;

		// Token: 0x0400415D RID: 16733
		internal int $PC;
	}

	// Token: 0x02000CA7 RID: 3239
	[CompilerGenerated]
	private sealed class <CheckOutputAndDEFMDEFStatus>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053D5 RID: 21461 RVA: 0x000B14B4 File Offset: 0x000AF8B4
		[DebuggerHidden]
		public <CheckOutputAndDEFMDEFStatus>c__Iterator3()
		{
		}

		// Token: 0x060053D6 RID: 21462 RVA: 0x000B14BC File Offset: 0x000AF8BC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				brief = base.BattleUnit.GetAttributeBrief();
				this.AttackOutputText.SetLableText(brief.WithBattleEffects.OutputValue);
				this.MDEFText.SetLableText(brief.WithBattleEffects.Toughness);
				this.SpeedText.SetLableText(brief.WithBattleEffects.Agility);
				break;
			}
			return false;
		}

		// Token: 0x170011C6 RID: 4550
		// (get) Token: 0x060053D7 RID: 21463 RVA: 0x000B158A File Offset: 0x000AF98A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011C7 RID: 4551
		// (get) Token: 0x060053D8 RID: 21464 RVA: 0x000B1592 File Offset: 0x000AF992
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053D9 RID: 21465 RVA: 0x000B159A File Offset: 0x000AF99A
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060053DA RID: 21466 RVA: 0x000B15AA File Offset: 0x000AF9AA
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053DB RID: 21467 RVA: 0x000B15B1 File Offset: 0x000AF9B1
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053DC RID: 21468 RVA: 0x000B15BC File Offset: 0x000AF9BC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InBattleUnitCardLayout.<CheckOutputAndDEFMDEFStatus>c__Iterator3 <CheckOutputAndDEFMDEFStatus>c__Iterator = new InBattleUnitCardLayout.<CheckOutputAndDEFMDEFStatus>c__Iterator3();
			<CheckOutputAndDEFMDEFStatus>c__Iterator.$this = this;
			return <CheckOutputAndDEFMDEFStatus>c__Iterator;
		}

		// Token: 0x0400415E RID: 16734
		internal BattleUnitAttributeBriefSet <brief>__0;

		// Token: 0x0400415F RID: 16735
		internal InBattleUnitCardLayout $this;

		// Token: 0x04004160 RID: 16736
		internal object $current;

		// Token: 0x04004161 RID: 16737
		internal bool $disposing;

		// Token: 0x04004162 RID: 16738
		internal int $PC;
	}

	// Token: 0x02000CA8 RID: 3240
	[CompilerGenerated]
	private sealed class <CheckCurrentBattleEffectsStatus>c__AnonStorey7
	{
		// Token: 0x060053DD RID: 21469 RVA: 0x000B15F0 File Offset: 0x000AF9F0
		public <CheckCurrentBattleEffectsStatus>c__AnonStorey7()
		{
		}

		// Token: 0x060053DE RID: 21470 RVA: 0x000B15F8 File Offset: 0x000AF9F8
		internal bool <>m__0(InBattleEffetGameObject i)
		{
			return this.keys.Contains(i.GetBattleEffect().BattleEffectType);
		}

		// Token: 0x04004163 RID: 16739
		internal List<BattleEffectType> keys;
	}

	// Token: 0x02000CA9 RID: 3241
	[CompilerGenerated]
	private sealed class <CheckCurrentBattleEffectsStatus>c__AnonStorey6
	{
		// Token: 0x060053DF RID: 21471 RVA: 0x000B1610 File Offset: 0x000AFA10
		public <CheckCurrentBattleEffectsStatus>c__AnonStorey6()
		{
		}

		// Token: 0x060053E0 RID: 21472 RVA: 0x000B1618 File Offset: 0x000AFA18
		internal bool <>m__0(InBattleEffetGameObject i)
		{
			return i.GetBattleEffect().BattleEffectType == this.groupByEffect.Key;
		}

		// Token: 0x04004164 RID: 16740
		internal IGrouping<BattleEffectType, BattleEffectBase> groupByEffect;
	}

	// Token: 0x02000CAA RID: 3242
	[CompilerGenerated]
	private sealed class <UnitDead>c__Iterator4 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053E1 RID: 21473 RVA: 0x000B1632 File Offset: 0x000AFA32
		[DebuggerHidden]
		public <UnitDead>c__Iterator4()
		{
		}

		// Token: 0x060053E2 RID: 21474 RVA: 0x000B163C File Offset: 0x000AFA3C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				if (adventurerBattleUnit.GetId() == base.BattleUnit.GetId())
				{
					this.AdventurerImage.sprite = FilePath.GetDeadAvatarImage();
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011C8 RID: 4552
		// (get) Token: 0x060053E3 RID: 21475 RVA: 0x000B16C9 File Offset: 0x000AFAC9
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011C9 RID: 4553
		// (get) Token: 0x060053E4 RID: 21476 RVA: 0x000B16D1 File Offset: 0x000AFAD1
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053E5 RID: 21477 RVA: 0x000B16D9 File Offset: 0x000AFAD9
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060053E6 RID: 21478 RVA: 0x000B16E9 File Offset: 0x000AFAE9
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004165 RID: 16741
		internal IBattleUnit adventurerBattleUnit;

		// Token: 0x04004166 RID: 16742
		internal InBattleUnitCardLayout $this;

		// Token: 0x04004167 RID: 16743
		internal object $current;

		// Token: 0x04004168 RID: 16744
		internal bool $disposing;

		// Token: 0x04004169 RID: 16745
		internal int $PC;
	}

	// Token: 0x02000CAB RID: 3243
	[CompilerGenerated]
	private sealed class <UnitSelectedSkill>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053E7 RID: 21479 RVA: 0x000B16F0 File Offset: 0x000AFAF0
		[DebuggerHidden]
		public <UnitSelectedSkill>c__Iterator5()
		{
		}

		// Token: 0x060053E8 RID: 21480 RVA: 0x000B16F8 File Offset: 0x000AFAF8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				if (base.BattleUnit.GetId() == ActionUnit.GetId())
				{
					foreach (InBattleSkillObj inBattleSkillObj in this.SkillImages)
					{
						if (inBattleSkillObj.GetAdventureUnitSkill() != null && Skill.Skill == inBattleSkillObj.GetAdventureUnitSkill().Skill && inBattleSkillObj.gameObject.activeSelf)
						{
							inBattleSkillObj.SkillSelected();
						}
					}
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011CA RID: 4554
		// (get) Token: 0x060053E9 RID: 21481 RVA: 0x000B17D0 File Offset: 0x000AFBD0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011CB RID: 4555
		// (get) Token: 0x060053EA RID: 21482 RVA: 0x000B17D8 File Offset: 0x000AFBD8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053EB RID: 21483 RVA: 0x000B17E0 File Offset: 0x000AFBE0
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060053EC RID: 21484 RVA: 0x000B17F0 File Offset: 0x000AFBF0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053ED RID: 21485 RVA: 0x000B17F7 File Offset: 0x000AFBF7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053EE RID: 21486 RVA: 0x000B1800 File Offset: 0x000AFC00
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InBattleUnitCardLayout.<UnitSelectedSkill>c__Iterator5 <UnitSelectedSkill>c__Iterator = new InBattleUnitCardLayout.<UnitSelectedSkill>c__Iterator5();
			<UnitSelectedSkill>c__Iterator.$this = this;
			<UnitSelectedSkill>c__Iterator.ActionUnit = ActionUnit;
			<UnitSelectedSkill>c__Iterator.Skill = Skill;
			return <UnitSelectedSkill>c__Iterator;
		}

		// Token: 0x0400416A RID: 16746
		internal IBattleUnit ActionUnit;

		// Token: 0x0400416B RID: 16747
		internal AdventureUnitSkill Skill;

		// Token: 0x0400416C RID: 16748
		internal InBattleUnitCardLayout $this;

		// Token: 0x0400416D RID: 16749
		internal object $current;

		// Token: 0x0400416E RID: 16750
		internal bool $disposing;

		// Token: 0x0400416F RID: 16751
		internal int $PC;
	}
}
