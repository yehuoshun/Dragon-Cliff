using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200035E RID: 862
public abstract class InBattleUnitPanelObj : MonoBehaviour
{
	// Token: 0x0600171E RID: 5918 RVA: 0x000B3473 File Offset: 0x000B1873
	protected InBattleUnitPanelObj()
	{
	}

	// Token: 0x17000132 RID: 306
	// (get) Token: 0x0600171F RID: 5919 RVA: 0x000B3486 File Offset: 0x000B1886
	// (set) Token: 0x06001720 RID: 5920 RVA: 0x000B348E File Offset: 0x000B188E
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

	// Token: 0x17000133 RID: 307
	// (get) Token: 0x06001721 RID: 5921 RVA: 0x000B3497 File Offset: 0x000B1897
	// (set) Token: 0x06001722 RID: 5922 RVA: 0x000B349F File Offset: 0x000B189F
	public HeroInBattleInfoController _heroInBattleInfoController
	{
		[CompilerGenerated]
		get
		{
			return this.<_heroInBattleInfoController>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<_heroInBattleInfoController>k__BackingField = value;
		}
	}

	// Token: 0x06001723 RID: 5923 RVA: 0x000B34A8 File Offset: 0x000B18A8
	private void Update()
	{
		if (this.BattleUnit.Status != BattleUnitStatus.Dead)
		{
			this.ProgressBar.value = (float)this.BattleUnit.TurnProgress;
		}
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x000B34D4 File Offset: 0x000B18D4
	public virtual void UpdateUnitHealth()
	{
		float num = (float)this.BattleUnit.HealthPoints / (float)this.BattleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
		this.HealthSlider.value = num;
		if (this.BattleUnit.HealthPoints > 0.0 && this.BattleUnit.HealthPoints < 1.0)
		{
			this.HealthLabel.text = Mathf.Ceil((float)this.BattleUnit.HealthPoints) + "/" + this.BattleUnit.GetMaxLife(AttributeRetrievalLevel.Skill).ToExpression();
		}
		else
		{
			this.HealthLabel.text = this.BattleUnit.HealthPoints.ToExpression() + "/" + this.BattleUnit.GetMaxLife(AttributeRetrievalLevel.Skill).ToExpression();
		}
		this.FillSprite.sprite = FilePath.GetFillSpriteBaseOnPercentage(num);
	}

	// Token: 0x06001725 RID: 5925 RVA: 0x000B35C4 File Offset: 0x000B19C4
	public void SetCorresponseBattleUnit(IBattleUnit battleUnit, HeroInBattleInfoController heroInBattleInfoController, BattleEncounter encounter, ProgressIndicatorController progressIndicator)
	{
		this.BattleUnit = battleUnit;
		this.BattleUnit.RegisterEventCallbackFromUiLayer(new Func<IBattleUnit, AdventureEventType, object, IEnumerable>(this.AdventurerBattleUnitOnReceivesEventCallBack));
		this._progressIndicatorController = progressIndicator;
		this._heroInBattleInfoController = heroInBattleInfoController;
		this.AvatarHighlighter.gameObject.SetActive(false);
		this.HeroName.text = this.BattleUnit.GetUnitType().GetDescription().Title;
		this.HeroLevel.text = "Lv" + this.BattleUnit.Level;
		this.CheckCurrentBattleEffectsStatus();
	}

	// Token: 0x06001726 RID: 5926 RVA: 0x000B365B File Offset: 0x000B1A5B
	public virtual void BattleFinished()
	{
		this.CheckCurrentBattleEffectsStatus();
		this.SkillHoverFinished();
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x000B3669 File Offset: 0x000B1A69
	public void BindListener(IBattleUnit adventurerBattleUnit)
	{
		if (adventurerBattleUnit.GetId() == this.BattleUnit.GetId())
		{
			this.BattleUnit.RegisterEventCallbackFromUiLayer(new Func<IBattleUnit, AdventureEventType, object, IEnumerable>(this.AdventurerBattleUnitOnReceivesEventCallBack));
		}
	}

	// Token: 0x06001728 RID: 5928 RVA: 0x000B369E File Offset: 0x000B1A9E
	public virtual void AdventureFinished()
	{
		this._inBattleEffetGameObjects.ForEach(delegate(InBattleEffetGameObject i)
		{
			i.EffectExpired();
		});
		this._inBattleEffetGameObjects.Clear();
		GameObjectUtil.RecycleDestroy(base.gameObject);
	}

	// Token: 0x06001729 RID: 5929 RVA: 0x000B36E0 File Offset: 0x000B1AE0
	private void SkillHoverFinished()
	{
		foreach (InBattleSkillObj inBattleSkillObj in this.SkillImages)
		{
			inBattleSkillObj.Finished();
			inBattleSkillObj.DeHighlightSkill();
		}
	}

	// Token: 0x0600172A RID: 5930 RVA: 0x000B3718 File Offset: 0x000B1B18
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

	// Token: 0x0600172B RID: 5931 RVA: 0x000B3948 File Offset: 0x000B1D48
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

	// Token: 0x0600172C RID: 5932 RVA: 0x000B39D4 File Offset: 0x000B1DD4
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

	// Token: 0x0600172D RID: 5933 RVA: 0x000B3A70 File Offset: 0x000B1E70
	public virtual void UnitDead(IBattleUnit adventurerBattleUnit)
	{
		if (adventurerBattleUnit.GetId() == this.BattleUnit.GetId())
		{
			this._originalSprite = this.Avatar.sprite;
			this.Avatar.sprite = FilePath.GetDeadAvatarImage();
			this._inBattleEffetGameObjects.ForEach(delegate(InBattleEffetGameObject i)
			{
				i.EffectExpired();
			});
		}
	}

	// Token: 0x0600172E RID: 5934 RVA: 0x000B3AE4 File Offset: 0x000B1EE4
	public virtual IEnumerable AdventurerBattleUnitOnReceivesEventCallBack(IBattleUnit battleUnit, AdventureEventType adventureEventType, object arg3)
	{
		switch (adventureEventType)
		{
		case AdventureEventType.UnitPostReceivesDamage:
		case AdventureEventType.UnitPostReceivesHeal:
			break;
		case AdventureEventType.UnitKilled:
			this.UnitDead(battleUnit);
			break;
		default:
			switch (adventureEventType)
			{
			case AdventureEventType.UnitEntersTurn:
			{
				this.AvatarHighlighter.gameObject.SetActive(true);
				IEnumerator enumerator = this.UpdateBattleOrder(battleUnit).GetEnumerator();
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
				this.UnitEntersTurn(battleUnit);
				break;
			}
			default:
				if (adventureEventType == AdventureEventType.UnitEffectTriggered)
				{
					if (!(arg3 is BattleEffectBase))
					{
						throw new Exception("UnitReceivesEffect is null ");
					}
				}
				break;
			case AdventureEventType.UnitSelectedSkill:
				break;
			case AdventureEventType.UnitCompletesTurn:
				this.AvatarHighlighter.gameObject.SetActive(false);
				this.TurnFinished(battleUnit);
				yield return new WaitForSeconds(0.5f);
				break;
			}
			break;
		case AdventureEventType.UnitRevived:
			UnityEngine.Debug.Log("Resurrected");
			if (this._originalSprite != null)
			{
				this.Avatar.sprite = this._originalSprite;
			}
			break;
		case AdventureEventType.UnitReceivesEffect:
			if (!(arg3 is BattleEffectBase))
			{
				throw new Exception("UnitReceivesEffect is null ");
			}
			break;
		case AdventureEventType.UnitLoosesEffect:
			if (!(arg3 is BattleEffectBase))
			{
				throw new Exception("UnitLoosesEffect is null ");
			}
			break;
		case AdventureEventType.BattleEffectDispersed:
			break;
		case AdventureEventType.UnitTurnProgressAlterred:
			this._progressIndicatorController.UpdatePosition();
			break;
		}
		this.CheckCurrentBattleEffectsStatus();
		this.UpdateUnitHealth();
		yield break;
	}

	// Token: 0x0600172F RID: 5935 RVA: 0x000B3B1C File Offset: 0x000B1F1C
	private void UnitEntersTurn(IBattleUnit unit)
	{
		this._heroInBattleInfoController.EnterTurn(unit);
	}

	// Token: 0x06001730 RID: 5936 RVA: 0x000B3B2C File Offset: 0x000B1F2C
	private void TurnFinished(IBattleUnit turnCompleteUnit)
	{
		Image component = this.ProgressBar.fillRect.GetComponent<Image>();
		if (component != null)
		{
			component.color = this._originalColor;
		}
		this._heroInBattleInfoController.TurnComplete(turnCompleteUnit);
	}

	// Token: 0x06001731 RID: 5937 RVA: 0x000B3B70 File Offset: 0x000B1F70
	public virtual IEnumerable UpdateBattleOrder(IBattleUnit InTurnBattleUnit)
	{
		Image image = this.ProgressBar.fillRect.GetComponent<Image>();
		if (image != null)
		{
			this._originalColor = image.color;
			image.color = Color.yellow;
		}
		IEnumerator enumerator = this._heroInBattleInfoController.UpdateCurrentEncouterOrder(InTurnBattleUnit).GetEnumerator();
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

	// Token: 0x06001732 RID: 5938 RVA: 0x000B3B9A File Offset: 0x000B1F9A
	public virtual void UpdateOrders()
	{
		this._heroInBattleInfoController.UpdateRestOfSpeed();
	}

	// Token: 0x06001733 RID: 5939 RVA: 0x000B3BA7 File Offset: 0x000B1FA7
	public virtual void SetItemsImages()
	{
	}

	// Token: 0x06001734 RID: 5940 RVA: 0x000B3BA9 File Offset: 0x000B1FA9
	[CompilerGenerated]
	private static void <AdventureFinished>m__0(InBattleEffetGameObject i)
	{
		i.EffectExpired();
	}

	// Token: 0x06001735 RID: 5941 RVA: 0x000B3BB1 File Offset: 0x000B1FB1
	[CompilerGenerated]
	private static BattleEffectType <CheckCurrentBattleEffectsStatus>m__1(BattleEffectBase b)
	{
		return b.BattleEffectType;
	}

	// Token: 0x06001736 RID: 5942 RVA: 0x000B3BB9 File Offset: 0x000B1FB9
	[CompilerGenerated]
	private static void <UnitDead>m__2(InBattleEffetGameObject i)
	{
		i.EffectExpired();
	}

	// Token: 0x04001722 RID: 5922
	public GameObject EffectsPanel;

	// Token: 0x04001723 RID: 5923
	public InBattleSkillObj[] SkillImages;

	// Token: 0x04001724 RID: 5924
	public Text HeroName;

	// Token: 0x04001725 RID: 5925
	public Text HeroLevel;

	// Token: 0x04001726 RID: 5926
	public Text HealthLabel;

	// Token: 0x04001727 RID: 5927
	public Slider HealthSlider;

	// Token: 0x04001728 RID: 5928
	public Image FillSprite;

	// Token: 0x04001729 RID: 5929
	public Slider ProgressBar;

	// Token: 0x0400172A RID: 5930
	public Image Avatar;

	// Token: 0x0400172B RID: 5931
	private Sprite _originalSprite;

	// Token: 0x0400172C RID: 5932
	public Image AvatarHighlighter;

	// Token: 0x0400172D RID: 5933
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <BattleUnit>k__BackingField;

	// Token: 0x0400172E RID: 5934
	private ProgressIndicatorController _progressIndicatorController;

	// Token: 0x0400172F RID: 5935
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HeroInBattleInfoController <_heroInBattleInfoController>k__BackingField;

	// Token: 0x04001730 RID: 5936
	private readonly List<InBattleEffetGameObject> _inBattleEffetGameObjects = new List<InBattleEffetGameObject>();

	// Token: 0x04001731 RID: 5937
	private Color _originalColor;

	// Token: 0x04001732 RID: 5938
	[CompilerGenerated]
	private static Action<InBattleEffetGameObject> <>f__am$cache0;

	// Token: 0x04001733 RID: 5939
	[CompilerGenerated]
	private static Func<BattleEffectBase, BattleEffectType> <>f__am$cache1;

	// Token: 0x04001734 RID: 5940
	[CompilerGenerated]
	private static Action<InBattleEffetGameObject> <>f__am$cache2;

	// Token: 0x02000CB3 RID: 3251
	[CompilerGenerated]
	private sealed class <CheckCurrentBattleEffectsStatus>c__AnonStorey3
	{
		// Token: 0x06005412 RID: 21522 RVA: 0x000B3BC1 File Offset: 0x000B1FC1
		public <CheckCurrentBattleEffectsStatus>c__AnonStorey3()
		{
		}

		// Token: 0x06005413 RID: 21523 RVA: 0x000B3BC9 File Offset: 0x000B1FC9
		internal bool <>m__0(InBattleEffetGameObject i)
		{
			return this.keys.Contains(i.GetBattleEffect().BattleEffectType);
		}

		// Token: 0x0400418C RID: 16780
		internal List<BattleEffectType> keys;
	}

	// Token: 0x02000CB4 RID: 3252
	[CompilerGenerated]
	private sealed class <CheckCurrentBattleEffectsStatus>c__AnonStorey2
	{
		// Token: 0x06005414 RID: 21524 RVA: 0x000B3BE1 File Offset: 0x000B1FE1
		public <CheckCurrentBattleEffectsStatus>c__AnonStorey2()
		{
		}

		// Token: 0x06005415 RID: 21525 RVA: 0x000B3BE9 File Offset: 0x000B1FE9
		internal bool <>m__0(InBattleEffetGameObject i)
		{
			return i.GetBattleEffect().BattleEffectType == this.groupByEffect.Key;
		}

		// Token: 0x0400418D RID: 16781
		internal IGrouping<BattleEffectType, BattleEffectBase> groupByEffect;
	}

	// Token: 0x02000CB5 RID: 3253
	[CompilerGenerated]
	private sealed class <AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005416 RID: 21526 RVA: 0x000B3C03 File Offset: 0x000B2003
		[DebuggerHidden]
		public <AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator0()
		{
		}

		// Token: 0x06005417 RID: 21527 RVA: 0x000B3C0C File Offset: 0x000B200C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				switch (adventureEventType)
				{
				case AdventureEventType.UnitPostReceivesDamage:
				case AdventureEventType.UnitPostReceivesHeal:
					goto IL_2BF;
				case AdventureEventType.UnitKilled:
					this.UnitDead(battleUnit);
					goto IL_2BF;
				default:
					switch (adventureEventType)
					{
					case AdventureEventType.UnitEntersTurn:
						this.AvatarHighlighter.gameObject.SetActive(true);
						enumerator = this.UpdateBattleOrder(battleUnit).GetEnumerator();
						num = 4294967293u;
						break;
					default:
					{
						if (adventureEventType != AdventureEventType.UnitEffectTriggered)
						{
							goto IL_2BF;
						}
						BattleEffectBase triggeredEffect = arg3 as BattleEffectBase;
						if (triggeredEffect == null)
						{
							throw new Exception("UnitReceivesEffect is null ");
						}
						goto IL_2BF;
					}
					case AdventureEventType.UnitSelectedSkill:
						goto IL_2BF;
					case AdventureEventType.UnitCompletesTurn:
						this.AvatarHighlighter.gameObject.SetActive(false);
						base.TurnFinished(battleUnit);
						this.$current = new WaitForSeconds(0.5f);
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						return true;
					}
					break;
				case AdventureEventType.UnitRevived:
					UnityEngine.Debug.Log("Resurrected");
					if (this._originalSprite != null)
					{
						this.Avatar.sprite = this._originalSprite;
					}
					goto IL_2BF;
				case AdventureEventType.UnitReceivesEffect:
				{
					BattleEffectBase battleEffect = arg3 as BattleEffectBase;
					if (battleEffect == null)
					{
						throw new Exception("UnitReceivesEffect is null ");
					}
					goto IL_2BF;
				}
				case AdventureEventType.UnitLoosesEffect:
				{
					BattleEffectBase lostEffect = arg3 as BattleEffectBase;
					if (lostEffect == null)
					{
						throw new Exception("UnitLoosesEffect is null ");
					}
					goto IL_2BF;
				}
				case AdventureEventType.BattleEffectDispersed:
					goto IL_2BF;
				case AdventureEventType.UnitTurnProgressAlterred:
					this._progressIndicatorController.UpdatePosition();
					goto IL_2BF;
				}
				break;
			case 1u:
				break;
			case 2u:
				goto IL_2BF;
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
			base.UnitEntersTurn(battleUnit);
			IL_2BF:
			this.CheckCurrentBattleEffectsStatus();
			this.UpdateUnitHealth();
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011D4 RID: 4564
		// (get) Token: 0x06005418 RID: 21528 RVA: 0x000B3F08 File Offset: 0x000B2308
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011D5 RID: 4565
		// (get) Token: 0x06005419 RID: 21529 RVA: 0x000B3F10 File Offset: 0x000B2310
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600541A RID: 21530 RVA: 0x000B3F18 File Offset: 0x000B2318
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

		// Token: 0x0600541B RID: 21531 RVA: 0x000B3F8C File Offset: 0x000B238C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600541C RID: 21532 RVA: 0x000B3F93 File Offset: 0x000B2393
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600541D RID: 21533 RVA: 0x000B3F9C File Offset: 0x000B239C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InBattleUnitPanelObj.<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator0 <AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator = new InBattleUnitPanelObj.<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator0();
			<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator.$this = this;
			<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator.adventureEventType = adventureEventType;
			<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator.arg3 = arg3;
			<AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator.battleUnit = battleUnit;
			return <AdventurerBattleUnitOnReceivesEventCallBack>c__Iterator;
		}

		// Token: 0x0400418E RID: 16782
		internal AdventureEventType adventureEventType;

		// Token: 0x0400418F RID: 16783
		internal object arg3;

		// Token: 0x04004190 RID: 16784
		internal BattleEffectBase <battleEffect>__1;

		// Token: 0x04004191 RID: 16785
		internal BattleEffectBase <triggeredEffect>__1;

		// Token: 0x04004192 RID: 16786
		internal BattleEffectBase <lostEffect>__1;

		// Token: 0x04004193 RID: 16787
		internal IBattleUnit battleUnit;

		// Token: 0x04004194 RID: 16788
		internal IEnumerator $locvar0;

		// Token: 0x04004195 RID: 16789
		internal object <_>__2;

		// Token: 0x04004196 RID: 16790
		internal IDisposable $locvar1;

		// Token: 0x04004197 RID: 16791
		internal InBattleUnitPanelObj $this;

		// Token: 0x04004198 RID: 16792
		internal object $current;

		// Token: 0x04004199 RID: 16793
		internal bool $disposing;

		// Token: 0x0400419A RID: 16794
		internal int $PC;
	}

	// Token: 0x02000CB6 RID: 3254
	[CompilerGenerated]
	private sealed class <UpdateBattleOrder>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600541E RID: 21534 RVA: 0x000B3FF4 File Offset: 0x000B23F4
		[DebuggerHidden]
		public <UpdateBattleOrder>c__Iterator1()
		{
		}

		// Token: 0x0600541F RID: 21535 RVA: 0x000B3FFC File Offset: 0x000B23FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				image = this.ProgressBar.fillRect.GetComponent<Image>();
				if (image != null)
				{
					this._originalColor = image.color;
					image.color = Color.yellow;
				}
				enumerator = base._heroInBattleInfoController.UpdateCurrentEncouterOrder(InTurnBattleUnit).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011D6 RID: 4566
		// (get) Token: 0x06005420 RID: 21536 RVA: 0x000B4140 File Offset: 0x000B2540
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011D7 RID: 4567
		// (get) Token: 0x06005421 RID: 21537 RVA: 0x000B4148 File Offset: 0x000B2548
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005422 RID: 21538 RVA: 0x000B4150 File Offset: 0x000B2550
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

		// Token: 0x06005423 RID: 21539 RVA: 0x000B41C0 File Offset: 0x000B25C0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005424 RID: 21540 RVA: 0x000B41C7 File Offset: 0x000B25C7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005425 RID: 21541 RVA: 0x000B41D0 File Offset: 0x000B25D0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InBattleUnitPanelObj.<UpdateBattleOrder>c__Iterator1 <UpdateBattleOrder>c__Iterator = new InBattleUnitPanelObj.<UpdateBattleOrder>c__Iterator1();
			<UpdateBattleOrder>c__Iterator.$this = this;
			<UpdateBattleOrder>c__Iterator.InTurnBattleUnit = InTurnBattleUnit;
			return <UpdateBattleOrder>c__Iterator;
		}

		// Token: 0x0400419B RID: 16795
		internal Image <image>__0;

		// Token: 0x0400419C RID: 16796
		internal IBattleUnit InTurnBattleUnit;

		// Token: 0x0400419D RID: 16797
		internal IEnumerator $locvar0;

		// Token: 0x0400419E RID: 16798
		internal object <_>__1;

		// Token: 0x0400419F RID: 16799
		internal IDisposable $locvar1;

		// Token: 0x040041A0 RID: 16800
		internal InBattleUnitPanelObj $this;

		// Token: 0x040041A1 RID: 16801
		internal object $current;

		// Token: 0x040041A2 RID: 16802
		internal bool $disposing;

		// Token: 0x040041A3 RID: 16803
		internal int $PC;
	}
}
