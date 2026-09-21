using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000340 RID: 832
public class BattleManager : MonoBehaviour
{
	// Token: 0x06001610 RID: 5648 RVA: 0x000AE254 File Offset: 0x000AC654
	public BattleManager()
	{
	}

	// Token: 0x17000117 RID: 279
	// (get) Token: 0x06001611 RID: 5649 RVA: 0x000AE272 File Offset: 0x000AC672
	// (set) Token: 0x06001612 RID: 5650 RVA: 0x000AE27A File Offset: 0x000AC67A
	public bool BattleStarted
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleStarted>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<BattleStarted>k__BackingField = value;
		}
	}

	// Token: 0x17000118 RID: 280
	// (get) Token: 0x06001613 RID: 5651 RVA: 0x000AE283 File Offset: 0x000AC683
	// (set) Token: 0x06001614 RID: 5652 RVA: 0x000AE28B File Offset: 0x000AC68B
	public bool IsInCombat
	{
		[CompilerGenerated]
		get
		{
			return this.<IsInCombat>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsInCombat>k__BackingField = value;
		}
	}

	// Token: 0x06001615 RID: 5653 RVA: 0x000AE294 File Offset: 0x000AC694
	public void PullBackClicked()
	{
		this.Spawner.StopMoving();
	}

	// Token: 0x17000119 RID: 281
	// (get) Token: 0x06001616 RID: 5654 RVA: 0x000AE2A1 File Offset: 0x000AC6A1
	// (set) Token: 0x06001617 RID: 5655 RVA: 0x000AE2A9 File Offset: 0x000AC6A9
	public bool IsPendingToDisplayResource
	{
		[CompilerGenerated]
		get
		{
			return this.<IsPendingToDisplayResource>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsPendingToDisplayResource>k__BackingField = value;
		}
	}

	// Token: 0x06001618 RID: 5656 RVA: 0x000AE2B2 File Offset: 0x000AC6B2
	private void Awake()
	{
		if (BattleManager.instance == null)
		{
			BattleManager.instance = this;
		}
		else if (BattleManager.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001619 RID: 5657 RVA: 0x000AE2EC File Offset: 0x000AC6EC
	private void Start()
	{
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		playerProfile.GameWorldEventTriggered = (Action<GameWorldEvent, object>)Delegate.Combine(playerProfile.GameWorldEventTriggered, new Action<GameWorldEvent, object>(this.PlayerProfileOnGameWorldEventTriggered));
		this.RewardPanel.ConfirmButton.onClick.AddListener(new UnityAction(this.CompeletionPanelConfirmButton));
		this._encounterGabTime = this.Spawner.GetEncounterGapTime();
	}

	// Token: 0x0600161A RID: 5658 RVA: 0x000AE358 File Offset: 0x000AC758
	private void Update()
	{
		if (this._targetingStrategy != null)
		{
			if (!this._targetingStrategy.IsResolved && !this.TargetSelectionCancelled)
			{
				if (Input.GetMouseButtonDown(1))
				{
					this.AdventureUi.HideChooseTargetNotifyText();
					this.ActiveSkillReleased();
				}
			}
			else if (this._targetingStrategy.IsResolved)
			{
				base.StartCoroutine(this.CastSkill().GetEnumerator());
			}
		}
	}

	// Token: 0x0600161B RID: 5659 RVA: 0x000AE3D0 File Offset: 0x000AC7D0
	private IEnumerable CastSkill()
	{
		this.AdventureUi.HideChooseTargetNotifyText();
		ActiveSkillTargetingStrategyBase strategy = this._targetingStrategy;
		this._targetingStrategy = null;
		SkillLogicBase logic = strategy.Skill.GetSkillLogic();
		ActiveSkillLogicBase activeLogic = logic as ActiveSkillLogicBase;
		if (activeLogic != null)
		{
			IEnumerator enumerator = activeLogic.Cast(strategy.Skill, strategy, false).GetEnumerator();
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

	// Token: 0x0600161C RID: 5660 RVA: 0x000AE3F3 File Offset: 0x000AC7F3
	public void CompeletionPanelConfirmButton()
	{
		this._confirmed = true;
		this.RewardPanel.ConfirmedButtonClick();
		this.PlayerConfirmed();
	}

	// Token: 0x0600161D RID: 5661 RVA: 0x000AE40D File Offset: 0x000AC80D
	public void AutoConfirmComplete()
	{
		if (this.RewardPanel.gameObject.activeSelf)
		{
			this._confirmed = true;
			this.RewardPanel.AutoConfirmed();
			this.PlayerConfirmed();
		}
	}

	// Token: 0x0600161E RID: 5662 RVA: 0x000AE43C File Offset: 0x000AC83C
	private void PlayerConfirmed()
	{
		UIMiscGenerator.Instance.ClearHealthDetails();
		this.AdventureUi.AdventurerFinished();
		this.BattleStarted = false;
		this.IsInCombat = false;
	}

	// Token: 0x0600161F RID: 5663 RVA: 0x000AE464 File Offset: 0x000AC864
	private void PlayerProfileOnGameWorldEventTriggered(GameWorldEvent gameWorldEvent, object o)
	{
		if (gameWorldEvent != GameWorldEvent.AdventureInitialising)
		{
			if (gameWorldEvent == GameWorldEvent.BattleEncounterRewardsCollected)
			{
				List<ResourceUpdate> resources = o as List<ResourceUpdate>;
				this.ResourceCollectedAfterEncounter(resources);
			}
		}
		else
		{
			AdventureInitialisingEvent adventureInitialisingEvent = o as AdventureInitialisingEvent;
			this.BindingListeners(adventureInitialisingEvent.Adventure);
		}
	}

	// Token: 0x06001620 RID: 5664 RVA: 0x000AE4B1 File Offset: 0x000AC8B1
	private void ResourceCollectedAfterEncounter(List<ResourceUpdate> resources)
	{
		if (resources == null)
		{
			return;
		}
		this.ResouceController.UpdateAmount(this._currentAdventure.CompleteRewardList);
	}

	// Token: 0x06001621 RID: 5665 RVA: 0x000AE4D0 File Offset: 0x000AC8D0
	public void ActiveSkillSelectionState(List<IBattleUnit> unitsToHighlight, ActiveSkillTargetingStrategyBase targetingStrategy)
	{
		IBattleUnit battleUnit = unitsToHighlight.FirstOrDefault<IBattleUnit>();
		if (battleUnit != null)
		{
			TimeController.Instance.IsInTargetSelection(true);
			this.Spawner.HighLightSelection(unitsToHighlight, targetingStrategy is FriendlySingleStrategy);
			this._targetingStrategy = targetingStrategy;
		}
		else
		{
			this.AdventureUi.HideChooseTargetNotifyText();
		}
	}

	// Token: 0x06001622 RID: 5666 RVA: 0x000AE524 File Offset: 0x000AC924
	public void StartABattle(List<string> selectedAdventureres, AdventureType adventureType, ConsumableItemController consumable)
	{
		List<Item> list = new List<Item>();
		if (consumable != null)
		{
			list.Add(consumable.GetItem());
		}
		this._confirmed = false;
	}

	// Token: 0x06001623 RID: 5667 RVA: 0x000AE558 File Offset: 0x000AC958
	private void BindingListeners(Adventure adventure)
	{
		adventure.AdventureInitialized += this.AdventureInitialized;
		this.Spawner.SetAdventure(adventure, adventure.AdventureType);
		adventure.AdventuresWalking += this.AdventureOnAdventuresWalking;
		adventure.AdventureCompletes += this.AdventrueOnAdventureCompletes;
		this.AdventureUi.SetAdventure(adventure);
		adventure.AdventuresEnterEncounter += this.AdventureOnAdventuresEnterEncounter;
		adventure.AdventuresCompleteEncounter += this.InitedAdventureOnAdventuresCompleteEncounter;
	}

	// Token: 0x06001624 RID: 5668 RVA: 0x000AE5E0 File Offset: 0x000AC9E0
	private IEnumerable AdventureInitialized(Adventure adv)
	{
		this.BattleStarted = true;
		if (!AutoAdventureController.Instance.StopShowingBattleScene())
		{
			TownManager.Instance.Ui.ShowBattle();
		}
		UIMiscGenerator.Instance.ClearHealthDetails();
		this._currentAdventure = adv;
		this.Spawner.InitEnemy(this._currentAdventure.Encounters[this._currentEncounterIndex]);
		this._currentEncounterIndex++;
		this.AdventureUi.UpdateAdventurersSpecialEffects(this._currentAdventure.PlayerEffects);
		this.AdventureUi.UpdateEnviromentSpecialEffects(this._currentAdventure.DungeonEffects);
		this.AdventureUi.DisableEscapeButton();
		this.AdventureUi.InitNewAdventure(adv);
		GameMusicController.Instance.AdventureInitialized(adv);
		yield return new WaitForSeconds(1f);
		this.AdventureUi.EnableEscapeButton();
		yield break;
	}

	// Token: 0x06001625 RID: 5669 RVA: 0x000AE60C File Offset: 0x000ACA0C
	private IEnumerable AdventureOnAdventuresEnterEncounter(List<AdventurerBattleUnit> adventurerBattleUnits, IEncounter encounter)
	{
		this.IsInCombat = true;
		this.Spawner.StopMoving();
		IEnumerator enumerator = this.Spawner.EntersEncounterAndSetsUpListeners(encounter, adventurerBattleUnits).GetEnumerator();
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
		this.AdventureUi.SetUpListener((BattleEncounter)encounter);
		this.AdventureUi.EnableEscapeButton();
		IBattleUnit boss = encounter.EnemyUnits.FirstOrDefault((IBattleUnit e) => e.IsBoss());
		if (boss != null)
		{
			this.AdventureUi.UpdateBossSpecialEffects(boss.SpecialEffects);
			EnemyBattleUnit enemyBattleUnit = boss as EnemyBattleUnit;
			if (enemyBattleUnit != null && enemyBattleUnit.SlotSelection == AdventureEncounterSlotType.Boss)
			{
				this.AdventureUi.DisableEscapeButton();
			}
		}
		GameMusicController.Instance.EnterEncounter(adventurerBattleUnits, encounter);
		if (!this.GetAdditionalData(UIAdditionalDataKey.BattleTutorialTriggered, false) && encounter.CurrentAdventure.Encounters.Count > 0 && encounter.CurrentAdventure.Encounters[0] == encounter)
		{
			TownManager.Instance.Ui.ShowBattleTutorial();
		}
		yield break;
	}

	// Token: 0x06001626 RID: 5670 RVA: 0x000AE640 File Offset: 0x000ACA40
	private IEnumerable InitedAdventureOnAdventuresCompleteEncounter(List<AdventurerBattleUnit> adventurerBattleUnits, IEncounter encounter)
	{
		UIMiscGenerator.Instance.ClearPopupText();
		if (this._currentAdventure.Survivied == Adventure.SurvivalStatus.Surviving)
		{
			AdventurerBattleUnit adventurerBattleUnit = adventurerBattleUnits.FirstOrDefault<AdventurerBattleUnit>();
			if (adventurerBattleUnit != null)
			{
				this.AdventurePlayerGauge.CompleteEncounter();
				this.IsInCombat = false;
				this.AdventureUi.LeavesEncouter();
				this.Spawner.DefeatedEncounter(encounter, this._currentAdventure);
				if (this._currentAdventure.Encounters.Count > this._currentEncounterIndex)
				{
					this.Spawner.InitEnemy(this._currentAdventure.Encounters[this._currentEncounterIndex]);
				}
				yield return base.StartCoroutine(CombatManager.Instance.FinishedEncounter(false));
			}
			this._currentEncounterIndex++;
		}
		TownManager.Instance.Ui.AdventureDialog.CloseAll();
		this.AdventureUi.HideBossSkillBar();
		GameMusicController.Instance.CompleteEncounter(adventurerBattleUnits, encounter);
		yield break;
	}

	// Token: 0x06001627 RID: 5671 RVA: 0x000AE674 File Offset: 0x000ACA74
	private IEnumerable AdventureOnAdventuresWalking(List<AdventurerBattleUnit> adventurerBattleUnits)
	{
		this.Spawner.ContinueMoving();
		int numberOfTimePotions = 3;
		if (this._currentAdventure.Encounters.Count <= this._currentEncounterIndex)
		{
			if (this._currentAdventure.Encounters.Count == this._currentEncounterIndex)
			{
				this.shouldWaitfor1Second = true;
				IEnumerator enumerator = this.Spawner.InitRewardsChest(this._currentAdventure.Chests, 1f).GetEnumerator();
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
				float changePerPotion = (this._encounterGabTime - 1f) / Convert.ToSingle(numberOfTimePotions);
				for (int i = 0; i < numberOfTimePotions; i++)
				{
					yield return new WaitForSeconds(changePerPotion);
				}
			}
			else
			{
				this.Spawner.MoveChests();
				IEnumerator enumerator2 = this.Spawner.WaitingForOpenChest(1f).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		else
		{
			float changePerPotion2 = this._encounterGabTime / Convert.ToSingle(numberOfTimePotions);
			for (int j = 0; j < numberOfTimePotions; j++)
			{
				yield return new WaitForSeconds(changePerPotion2);
			}
		}
		yield break;
	}

	// Token: 0x06001628 RID: 5672 RVA: 0x000AE698 File Offset: 0x000ACA98
	private void AllocateCompletionPanel(List<ResourceUpdate> resourceUpdates, AdventureCompleteType adventureCompleteType)
	{
		string adventureCompeletionStatus = string.Empty;
		if (adventureCompleteType != AdventureCompleteType.Failure)
		{
			if (adventureCompleteType != AdventureCompleteType.PulledOff)
			{
				if (adventureCompleteType == AdventureCompleteType.Successful)
				{
					adventureCompeletionStatus = UIComponentType.AdventureRewardPanelTitleCompleted.GetName();
				}
			}
			else
			{
				adventureCompeletionStatus = UIComponentType.AdventureRewardPanelTitleFailed.GetName();
				this.FinishedProgress();
				AutoAdventureController.Instance.StopAutoAdventure();
			}
		}
		else
		{
			adventureCompeletionStatus = UIComponentType.AdventureRewardPanelTitleFailed.GetName();
			AutoAdventureController.Instance.AdventureFailed();
		}
		this.RewardPanel.CompletionInfo(adventureCompeletionStatus, resourceUpdates, adventureCompleteType);
		this.RewardPanel.gameObject.SetActive(true);
		this.AdventureUi.DisableEscapeButton();
	}

	// Token: 0x06001629 RID: 5673 RVA: 0x000AE73C File Offset: 0x000ACB3C
	private IEnumerable AdventrueOnAdventureCompletes(List<ResourceUpdate> resourceUpdates, AdventureCompleteType adventureCompleteType, Adventure finishedAdventure)
	{
		this.AdventureUi.HideAdventurersSpecialEffects();
		this.AdventureUi.HideEnviromentSpecialEffects();
		this.AdventureUi.HideBossSpecialEffects();
		this.AdventurePlayerGauge.CompleteEncounter();
		this.shouldWaitfor1Second = false;
		this._currentEncounterIndex = 0;
		if (adventureCompleteType == AdventureCompleteType.PulledOff || adventureCompleteType == AdventureCompleteType.Failure)
		{
			this.AdventureUi.LeavesEncouter();
			this.Spawner.StopMoving();
			yield return CombatManager.Instance.FinishedEncounter(true);
		}
		else
		{
			IEnumerator enumerator = this.Spawner.OpenAllChests().GetEnumerator();
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
		this.AllocateCompletionPanel(resourceUpdates, adventureCompleteType);
		while (!this._confirmed && adventureCompleteType != AdventureCompleteType.PulledOff)
		{
			yield return new WaitForSeconds(1f);
		}
		this.Spawner.ClearAllSpawner();
		this.Spawner.ChestCollected();
		this.ResouceController.Reset();
		yield break;
	}

	// Token: 0x0600162A RID: 5674 RVA: 0x000AE76D File Offset: 0x000ACB6D
	private AbilityGaugeControl getWhichGameObjecttoupdate()
	{
		return this.AdventurePlayerGauge;
	}

	// Token: 0x1700011A RID: 282
	// (get) Token: 0x0600162B RID: 5675 RVA: 0x000AE775 File Offset: 0x000ACB75
	// (set) Token: 0x0600162C RID: 5676 RVA: 0x000AE77D File Offset: 0x000ACB7D
	public bool TargetSelectionCancelled
	{
		[CompilerGenerated]
		get
		{
			return this.<TargetSelectionCancelled>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<TargetSelectionCancelled>k__BackingField = value;
		}
	}

	// Token: 0x0600162D RID: 5677 RVA: 0x000AE788 File Offset: 0x000ACB88
	public void ActiveSkillReleased()
	{
		this._previousTargetingUnits.Clear();
		foreach (UnitCombatController unitCombatController in this._targetingBattleUnits)
		{
			this._previousTargetingUnits.Add(unitCombatController.BattleUnit);
		}
		this.Spawner.ActiveSkillCasted();
		this._targetingStrategy = null;
		this._targetingBattleUnits.Clear();
		this.TargetSelectionCancelled = false;
		TimeController.Instance.IsInTargetSelection(false);
	}

	// Token: 0x0600162E RID: 5678 RVA: 0x000AE828 File Offset: 0x000ACC28
	public void SettingTarget(UnitCombatController SelectedUnitController)
	{
		if (!this._targetingBattleUnits.Contains(SelectedUnitController) && this._targetingStrategy != null)
		{
			this._targetingBattleUnits.Add(SelectedUnitController);
			this._targetingStrategy.Resolve((from t in this._targetingBattleUnits
			select t.BattleUnit).ToList<IBattleUnit>());
		}
	}

	// Token: 0x0600162F RID: 5679 RVA: 0x000AE895 File Offset: 0x000ACC95
	public List<IBattleUnit> GetTargets()
	{
		return this._previousTargetingUnits;
	}

	// Token: 0x06001630 RID: 5680 RVA: 0x000AE89D File Offset: 0x000ACC9D
	public void SetSelectedUnit(IBattleUnit SelectedBattleUnit, Sprite normalStandingSprite)
	{
		this.AdventureUi.NewHeroesPanel.SetSelectedUnit(SelectedBattleUnit, normalStandingSprite);
	}

	// Token: 0x06001631 RID: 5681 RVA: 0x000AE8B4 File Offset: 0x000ACCB4
	public IEnumerable GaugeUpdated(IBattleUnit unit, AdventureEventType type, object obj)
	{
		switch (type)
		{
		case AdventureEventType.BattleEncounterPlayerGaugeUpdated:
			this.getWhichGameObjecttoupdate().GaugeValueUpdated(unit, type, obj);
			yield break;
		case AdventureEventType.BattleEncounterPlayerGaugeFullyCharged:
			this.getWhichGameObjecttoupdate().GaugeFullyCharged();
			yield break;
		case AdventureEventType.BattleEncounterPlayerGaugeReleased:
			this.getWhichGameObjecttoupdate().GaugeReleased();
			yield break;
		}
		yield break;
	}

	// Token: 0x06001632 RID: 5682 RVA: 0x000AE8EC File Offset: 0x000ACCEC
	[CompilerGenerated]
	private static IBattleUnit <SettingTarget>m__0(UnitCombatController t)
	{
		return t.BattleUnit;
	}

	// Token: 0x04001654 RID: 5716
	public static BattleManager instance;

	// Token: 0x04001655 RID: 5717
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <BattleStarted>k__BackingField;

	// Token: 0x04001656 RID: 5718
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsInCombat>k__BackingField;

	// Token: 0x04001657 RID: 5719
	public AdventureUIController AdventureUi;

	// Token: 0x04001658 RID: 5720
	public AdventureRewardPanelController RewardPanel;

	// Token: 0x04001659 RID: 5721
	public InfoPanelController InfoPanel;

	// Token: 0x0400165A RID: 5722
	public Spawner Spawner;

	// Token: 0x0400165B RID: 5723
	public BattleResourcePanelController ResouceController;

	// Token: 0x0400165C RID: 5724
	public AbilityGaugeControl AdventurePlayerGauge;

	// Token: 0x0400165D RID: 5725
	private Adventure _currentAdventure;

	// Token: 0x0400165E RID: 5726
	private float _encounterGabTime;

	// Token: 0x0400165F RID: 5727
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsPendingToDisplayResource>k__BackingField;

	// Token: 0x04001660 RID: 5728
	private bool _confirmed;

	// Token: 0x04001661 RID: 5729
	public ActiveSkillTargetingStrategyBase _targetingStrategy;

	// Token: 0x04001662 RID: 5730
	private int _currentEncounterIndex;

	// Token: 0x04001663 RID: 5731
	private bool shouldWaitfor1Second;

	// Token: 0x04001664 RID: 5732
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <TargetSelectionCancelled>k__BackingField;

	// Token: 0x04001665 RID: 5733
	private List<UnitCombatController> _targetingBattleUnits = new List<UnitCombatController>();

	// Token: 0x04001666 RID: 5734
	private List<IBattleUnit> _previousTargetingUnits = new List<IBattleUnit>();

	// Token: 0x04001667 RID: 5735
	[CompilerGenerated]
	private static Func<UnitCombatController, IBattleUnit> <>f__am$cache0;

	// Token: 0x02000C9A RID: 3226
	[CompilerGenerated]
	private sealed class <CastSkill>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005371 RID: 21361 RVA: 0x000AE8F4 File Offset: 0x000ACCF4
		[DebuggerHidden]
		public <CastSkill>c__Iterator0()
		{
		}

		// Token: 0x06005372 RID: 21362 RVA: 0x000AE8FC File Offset: 0x000ACCFC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this.AdventureUi.HideChooseTargetNotifyText();
				strategy = this._targetingStrategy;
				this._targetingStrategy = null;
				logic = strategy.Skill.GetSkillLogic();
				activeLogic = (logic as ActiveSkillLogicBase);
				if (activeLogic == null)
				{
					goto IL_12F;
				}
				enumerator = activeLogic.Cast(strategy.Skill, strategy, false).GetEnumerator();
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
			IL_12F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011AE RID: 4526
		// (get) Token: 0x06005373 RID: 21363 RVA: 0x000AEA54 File Offset: 0x000ACE54
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011AF RID: 4527
		// (get) Token: 0x06005374 RID: 21364 RVA: 0x000AEA5C File Offset: 0x000ACE5C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005375 RID: 21365 RVA: 0x000AEA64 File Offset: 0x000ACE64
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

		// Token: 0x06005376 RID: 21366 RVA: 0x000AEAD4 File Offset: 0x000ACED4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005377 RID: 21367 RVA: 0x000AEADB File Offset: 0x000ACEDB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005378 RID: 21368 RVA: 0x000AEAE4 File Offset: 0x000ACEE4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleManager.<CastSkill>c__Iterator0 <CastSkill>c__Iterator = new BattleManager.<CastSkill>c__Iterator0();
			<CastSkill>c__Iterator.$this = this;
			return <CastSkill>c__Iterator;
		}

		// Token: 0x040040FC RID: 16636
		internal ActiveSkillTargetingStrategyBase <strategy>__0;

		// Token: 0x040040FD RID: 16637
		internal SkillLogicBase <logic>__0;

		// Token: 0x040040FE RID: 16638
		internal ActiveSkillLogicBase <activeLogic>__0;

		// Token: 0x040040FF RID: 16639
		internal IEnumerator $locvar0;

		// Token: 0x04004100 RID: 16640
		internal object <_>__1;

		// Token: 0x04004101 RID: 16641
		internal IDisposable $locvar1;

		// Token: 0x04004102 RID: 16642
		internal BattleManager $this;

		// Token: 0x04004103 RID: 16643
		internal object $current;

		// Token: 0x04004104 RID: 16644
		internal bool $disposing;

		// Token: 0x04004105 RID: 16645
		internal int $PC;
	}

	// Token: 0x02000C9B RID: 3227
	[CompilerGenerated]
	private sealed class <AdventureInitialized>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005379 RID: 21369 RVA: 0x000AEB18 File Offset: 0x000ACF18
		[DebuggerHidden]
		public <AdventureInitialized>c__Iterator1()
		{
		}

		// Token: 0x0600537A RID: 21370 RVA: 0x000AEB20 File Offset: 0x000ACF20
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				base.BattleStarted = true;
				if (!AutoAdventureController.Instance.StopShowingBattleScene())
				{
					TownManager.Instance.Ui.ShowBattle();
				}
				UIMiscGenerator.Instance.ClearHealthDetails();
				this._currentAdventure = adv;
				this.Spawner.InitEnemy(this._currentAdventure.Encounters[this._currentEncounterIndex]);
				this._currentEncounterIndex++;
				this.AdventureUi.UpdateAdventurersSpecialEffects(this._currentAdventure.PlayerEffects);
				this.AdventureUi.UpdateEnviromentSpecialEffects(this._currentAdventure.DungeonEffects);
				this.AdventureUi.DisableEscapeButton();
				this.AdventureUi.InitNewAdventure(adv);
				GameMusicController.Instance.AdventureInitialized(adv);
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.AdventureUi.EnableEscapeButton();
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011B0 RID: 4528
		// (get) Token: 0x0600537B RID: 21371 RVA: 0x000AEC8A File Offset: 0x000AD08A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011B1 RID: 4529
		// (get) Token: 0x0600537C RID: 21372 RVA: 0x000AEC92 File Offset: 0x000AD092
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600537D RID: 21373 RVA: 0x000AEC9A File Offset: 0x000AD09A
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600537E RID: 21374 RVA: 0x000AECAA File Offset: 0x000AD0AA
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600537F RID: 21375 RVA: 0x000AECB1 File Offset: 0x000AD0B1
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005380 RID: 21376 RVA: 0x000AECBC File Offset: 0x000AD0BC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleManager.<AdventureInitialized>c__Iterator1 <AdventureInitialized>c__Iterator = new BattleManager.<AdventureInitialized>c__Iterator1();
			<AdventureInitialized>c__Iterator.$this = this;
			<AdventureInitialized>c__Iterator.adv = adv;
			return <AdventureInitialized>c__Iterator;
		}

		// Token: 0x04004106 RID: 16646
		internal Adventure adv;

		// Token: 0x04004107 RID: 16647
		internal BattleManager $this;

		// Token: 0x04004108 RID: 16648
		internal object $current;

		// Token: 0x04004109 RID: 16649
		internal bool $disposing;

		// Token: 0x0400410A RID: 16650
		internal int $PC;
	}

	// Token: 0x02000C9C RID: 3228
	[CompilerGenerated]
	private sealed class <AdventureOnAdventuresEnterEncounter>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005381 RID: 21377 RVA: 0x000AECFC File Offset: 0x000AD0FC
		[DebuggerHidden]
		public <AdventureOnAdventuresEnterEncounter>c__Iterator2()
		{
		}

		// Token: 0x06005382 RID: 21378 RVA: 0x000AED04 File Offset: 0x000AD104
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				base.IsInCombat = true;
				this.Spawner.StopMoving();
				enumerator = this.Spawner.EntersEncounterAndSetsUpListeners(encounter, adventurerBattleUnits).GetEnumerator();
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
			this.AdventureUi.SetUpListener((BattleEncounter)encounter);
			this.AdventureUi.EnableEscapeButton();
			boss = encounter.EnemyUnits.FirstOrDefault((IBattleUnit e) => e.IsBoss());
			if (boss != null)
			{
				this.AdventureUi.UpdateBossSpecialEffects(boss.SpecialEffects);
				EnemyBattleUnit enemyBattleUnit = boss as EnemyBattleUnit;
				if (enemyBattleUnit != null && enemyBattleUnit.SlotSelection == AdventureEncounterSlotType.Boss)
				{
					this.AdventureUi.DisableEscapeButton();
				}
			}
			GameMusicController.Instance.EnterEncounter(adventurerBattleUnits, encounter);
			if (!this.GetAdditionalData(UIAdditionalDataKey.BattleTutorialTriggered, false) && encounter.CurrentAdventure.Encounters.Count > 0 && encounter.CurrentAdventure.Encounters[0] == encounter)
			{
				TownManager.Instance.Ui.ShowBattleTutorial();
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011B2 RID: 4530
		// (get) Token: 0x06005383 RID: 21379 RVA: 0x000AEF40 File Offset: 0x000AD340
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011B3 RID: 4531
		// (get) Token: 0x06005384 RID: 21380 RVA: 0x000AEF48 File Offset: 0x000AD348
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005385 RID: 21381 RVA: 0x000AEF50 File Offset: 0x000AD350
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

		// Token: 0x06005386 RID: 21382 RVA: 0x000AEFC0 File Offset: 0x000AD3C0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005387 RID: 21383 RVA: 0x000AEFC7 File Offset: 0x000AD3C7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005388 RID: 21384 RVA: 0x000AEFD0 File Offset: 0x000AD3D0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleManager.<AdventureOnAdventuresEnterEncounter>c__Iterator2 <AdventureOnAdventuresEnterEncounter>c__Iterator = new BattleManager.<AdventureOnAdventuresEnterEncounter>c__Iterator2();
			<AdventureOnAdventuresEnterEncounter>c__Iterator.$this = this;
			<AdventureOnAdventuresEnterEncounter>c__Iterator.encounter = encounter;
			<AdventureOnAdventuresEnterEncounter>c__Iterator.adventurerBattleUnits = adventurerBattleUnits;
			return <AdventureOnAdventuresEnterEncounter>c__Iterator;
		}

		// Token: 0x06005389 RID: 21385 RVA: 0x000AF01C File Offset: 0x000AD41C
		private static bool <>m__0(IBattleUnit e)
		{
			return e.IsBoss();
		}

		// Token: 0x0400410B RID: 16651
		internal IEncounter encounter;

		// Token: 0x0400410C RID: 16652
		internal List<AdventurerBattleUnit> adventurerBattleUnits;

		// Token: 0x0400410D RID: 16653
		internal IEnumerator $locvar0;

		// Token: 0x0400410E RID: 16654
		internal object <_>__1;

		// Token: 0x0400410F RID: 16655
		internal IDisposable $locvar1;

		// Token: 0x04004110 RID: 16656
		internal IBattleUnit <boss>__0;

		// Token: 0x04004111 RID: 16657
		internal BattleManager $this;

		// Token: 0x04004112 RID: 16658
		internal object $current;

		// Token: 0x04004113 RID: 16659
		internal bool $disposing;

		// Token: 0x04004114 RID: 16660
		internal int $PC;

		// Token: 0x04004115 RID: 16661
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}

	// Token: 0x02000C9D RID: 3229
	[CompilerGenerated]
	private sealed class <InitedAdventureOnAdventuresCompleteEncounter>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600538A RID: 21386 RVA: 0x000AF024 File Offset: 0x000AD424
		[DebuggerHidden]
		public <InitedAdventureOnAdventuresCompleteEncounter>c__Iterator3()
		{
		}

		// Token: 0x0600538B RID: 21387 RVA: 0x000AF02C File Offset: 0x000AD42C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				UIMiscGenerator.Instance.ClearPopupText();
				if (this._currentAdventure.Survivied != Adventure.SurvivalStatus.Surviving)
				{
					goto IL_141;
				}
				adventurerBattleUnit = adventurerBattleUnits.FirstOrDefault<AdventurerBattleUnit>();
				if (adventurerBattleUnit != null)
				{
					this.AdventurePlayerGauge.CompleteEncounter();
					base.IsInCombat = false;
					this.AdventureUi.LeavesEncouter();
					this.Spawner.DefeatedEncounter(encounter, this._currentAdventure);
					if (this._currentAdventure.Encounters.Count > this._currentEncounterIndex)
					{
						this.Spawner.InitEnemy(this._currentAdventure.Encounters[this._currentEncounterIndex]);
					}
					this.$current = base.StartCoroutine(CombatManager.Instance.FinishedEncounter(false));
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				break;
			case 1u:
				break;
			default:
				return false;
			}
			this._currentEncounterIndex++;
			IL_141:
			TownManager.Instance.Ui.AdventureDialog.CloseAll();
			this.AdventureUi.HideBossSkillBar();
			GameMusicController.Instance.CompleteEncounter(adventurerBattleUnits, encounter);
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011B4 RID: 4532
		// (get) Token: 0x0600538C RID: 21388 RVA: 0x000AF1BE File Offset: 0x000AD5BE
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011B5 RID: 4533
		// (get) Token: 0x0600538D RID: 21389 RVA: 0x000AF1C6 File Offset: 0x000AD5C6
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600538E RID: 21390 RVA: 0x000AF1CE File Offset: 0x000AD5CE
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600538F RID: 21391 RVA: 0x000AF1DE File Offset: 0x000AD5DE
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005390 RID: 21392 RVA: 0x000AF1E5 File Offset: 0x000AD5E5
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005391 RID: 21393 RVA: 0x000AF1F0 File Offset: 0x000AD5F0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleManager.<InitedAdventureOnAdventuresCompleteEncounter>c__Iterator3 <InitedAdventureOnAdventuresCompleteEncounter>c__Iterator = new BattleManager.<InitedAdventureOnAdventuresCompleteEncounter>c__Iterator3();
			<InitedAdventureOnAdventuresCompleteEncounter>c__Iterator.$this = this;
			<InitedAdventureOnAdventuresCompleteEncounter>c__Iterator.adventurerBattleUnits = adventurerBattleUnits;
			<InitedAdventureOnAdventuresCompleteEncounter>c__Iterator.encounter = encounter;
			return <InitedAdventureOnAdventuresCompleteEncounter>c__Iterator;
		}

		// Token: 0x04004116 RID: 16662
		internal List<AdventurerBattleUnit> adventurerBattleUnits;

		// Token: 0x04004117 RID: 16663
		internal AdventurerBattleUnit <adventurerBattleUnit>__1;

		// Token: 0x04004118 RID: 16664
		internal IEncounter encounter;

		// Token: 0x04004119 RID: 16665
		internal BattleManager $this;

		// Token: 0x0400411A RID: 16666
		internal object $current;

		// Token: 0x0400411B RID: 16667
		internal bool $disposing;

		// Token: 0x0400411C RID: 16668
		internal int $PC;
	}

	// Token: 0x02000C9E RID: 3230
	[CompilerGenerated]
	private sealed class <AdventureOnAdventuresWalking>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005392 RID: 21394 RVA: 0x000AF23C File Offset: 0x000AD63C
		[DebuggerHidden]
		public <AdventureOnAdventuresWalking>c__Iterator4()
		{
		}

		// Token: 0x06005393 RID: 21395 RVA: 0x000AF244 File Offset: 0x000AD644
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this.Spawner.ContinueMoving();
				numberOfTimePotions = 3;
				if (this._currentAdventure.Encounters.Count > this._currentEncounterIndex)
				{
					changePerPotion2 = this._encounterGabTime / Convert.ToSingle(numberOfTimePotions);
					j = 0;
					goto IL_2DF;
				}
				if (this._currentAdventure.Encounters.Count != this._currentEncounterIndex)
				{
					this.Spawner.MoveChests();
					enumerator2 = this.Spawner.WaitingForOpenChest(1f).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
				this.shouldWaitfor1Second = true;
				enumerator = this.Spawner.InitRewardsChest(this._currentAdventure.Chests, 1f).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				i++;
				goto IL_1B3;
			case 3u:
				goto IL_1FC;
			case 4u:
				j++;
				goto IL_2DF;
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
			changePerPotion = (this._encounterGabTime - 1f) / Convert.ToSingle(numberOfTimePotions);
			i = 0;
			IL_1B3:
			if (i >= numberOfTimePotions)
			{
				goto IL_27E;
			}
			this.$current = new WaitForSeconds(changePerPotion);
			if (!this.$disposing)
			{
				this.$PC = 2;
			}
			return true;
			Block_7:
			try
			{
				IL_1FC:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_27E:
			goto IL_2F0;
			IL_2DF:
			if (j < numberOfTimePotions)
			{
				this.$current = new WaitForSeconds(changePerPotion2);
				if (!this.$disposing)
				{
					this.$PC = 4;
				}
				return true;
			}
			IL_2F0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011B6 RID: 4534
		// (get) Token: 0x06005394 RID: 21396 RVA: 0x000AF568 File Offset: 0x000AD968
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011B7 RID: 4535
		// (get) Token: 0x06005395 RID: 21397 RVA: 0x000AF570 File Offset: 0x000AD970
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005396 RID: 21398 RVA: 0x000AF578 File Offset: 0x000AD978
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
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005397 RID: 21399 RVA: 0x000AF630 File Offset: 0x000ADA30
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005398 RID: 21400 RVA: 0x000AF637 File Offset: 0x000ADA37
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005399 RID: 21401 RVA: 0x000AF640 File Offset: 0x000ADA40
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleManager.<AdventureOnAdventuresWalking>c__Iterator4 <AdventureOnAdventuresWalking>c__Iterator = new BattleManager.<AdventureOnAdventuresWalking>c__Iterator4();
			<AdventureOnAdventuresWalking>c__Iterator.$this = this;
			return <AdventureOnAdventuresWalking>c__Iterator;
		}

		// Token: 0x0400411D RID: 16669
		internal int <numberOfTimePotions>__0;

		// Token: 0x0400411E RID: 16670
		internal IEnumerator $locvar0;

		// Token: 0x0400411F RID: 16671
		internal object <_>__1;

		// Token: 0x04004120 RID: 16672
		internal IDisposable $locvar1;

		// Token: 0x04004121 RID: 16673
		internal float <changePerPotion>__2;

		// Token: 0x04004122 RID: 16674
		internal int <i>__3;

		// Token: 0x04004123 RID: 16675
		internal IEnumerator $locvar2;

		// Token: 0x04004124 RID: 16676
		internal object <_>__4;

		// Token: 0x04004125 RID: 16677
		internal IDisposable $locvar3;

		// Token: 0x04004126 RID: 16678
		internal float <changePerPotion>__5;

		// Token: 0x04004127 RID: 16679
		internal int <i>__6;

		// Token: 0x04004128 RID: 16680
		internal BattleManager $this;

		// Token: 0x04004129 RID: 16681
		internal object $current;

		// Token: 0x0400412A RID: 16682
		internal bool $disposing;

		// Token: 0x0400412B RID: 16683
		internal int $PC;
	}

	// Token: 0x02000C9F RID: 3231
	[CompilerGenerated]
	private sealed class <AdventrueOnAdventureCompletes>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600539A RID: 21402 RVA: 0x000AF674 File Offset: 0x000ADA74
		[DebuggerHidden]
		public <AdventrueOnAdventureCompletes>c__Iterator5()
		{
		}

		// Token: 0x0600539B RID: 21403 RVA: 0x000AF67C File Offset: 0x000ADA7C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				this.AdventureUi.HideAdventurersSpecialEffects();
				this.AdventureUi.HideEnviromentSpecialEffects();
				this.AdventureUi.HideBossSpecialEffects();
				this.AdventurePlayerGauge.CompleteEncounter();
				this.shouldWaitfor1Second = false;
				this._currentEncounterIndex = 0;
				if (adventureCompleteType == AdventureCompleteType.PulledOff || adventureCompleteType == AdventureCompleteType.Failure)
				{
					this.AdventureUi.LeavesEncouter();
					this.Spawner.StopMoving();
					this.$current = CombatManager.Instance.FinishedEncounter(true);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				enumerator = this.Spawner.OpenAllChests().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				goto IL_185;
			case 2u:
				break;
			case 3u:
				IL_1C5:
				if (this._confirmed || adventureCompleteType == AdventureCompleteType.PulledOff)
				{
					this.Spawner.ClearAllSpawner();
					this.Spawner.ChestCollected();
					this.ResouceController.Reset();
					this.$PC = -1;
					return false;
				}
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 3;
				}
				return true;
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
			IL_185:
			base.AllocateCompletionPanel(resourceUpdates, adventureCompleteType);
			goto IL_1C5;
		}

		// Token: 0x170011B8 RID: 4536
		// (get) Token: 0x0600539C RID: 21404 RVA: 0x000AF8B4 File Offset: 0x000ADCB4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011B9 RID: 4537
		// (get) Token: 0x0600539D RID: 21405 RVA: 0x000AF8BC File Offset: 0x000ADCBC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600539E RID: 21406 RVA: 0x000AF8C4 File Offset: 0x000ADCC4
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

		// Token: 0x0600539F RID: 21407 RVA: 0x000AF93C File Offset: 0x000ADD3C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053A0 RID: 21408 RVA: 0x000AF943 File Offset: 0x000ADD43
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053A1 RID: 21409 RVA: 0x000AF94C File Offset: 0x000ADD4C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleManager.<AdventrueOnAdventureCompletes>c__Iterator5 <AdventrueOnAdventureCompletes>c__Iterator = new BattleManager.<AdventrueOnAdventureCompletes>c__Iterator5();
			<AdventrueOnAdventureCompletes>c__Iterator.$this = this;
			<AdventrueOnAdventureCompletes>c__Iterator.adventureCompleteType = adventureCompleteType;
			<AdventrueOnAdventureCompletes>c__Iterator.resourceUpdates = resourceUpdates;
			return <AdventrueOnAdventureCompletes>c__Iterator;
		}

		// Token: 0x0400412C RID: 16684
		internal AdventureCompleteType adventureCompleteType;

		// Token: 0x0400412D RID: 16685
		internal IEnumerator $locvar0;

		// Token: 0x0400412E RID: 16686
		internal object <_>__1;

		// Token: 0x0400412F RID: 16687
		internal IDisposable $locvar1;

		// Token: 0x04004130 RID: 16688
		internal List<ResourceUpdate> resourceUpdates;

		// Token: 0x04004131 RID: 16689
		internal BattleManager $this;

		// Token: 0x04004132 RID: 16690
		internal object $current;

		// Token: 0x04004133 RID: 16691
		internal bool $disposing;

		// Token: 0x04004134 RID: 16692
		internal int $PC;
	}

	// Token: 0x02000CA0 RID: 3232
	[CompilerGenerated]
	private sealed class <GaugeUpdated>c__Iterator6 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053A2 RID: 21410 RVA: 0x000AF998 File Offset: 0x000ADD98
		[DebuggerHidden]
		public <GaugeUpdated>c__Iterator6()
		{
		}

		// Token: 0x060053A3 RID: 21411 RVA: 0x000AF9A0 File Offset: 0x000ADDA0
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				switch (type)
				{
				case AdventureEventType.BattleEncounterPlayerGaugeUpdated:
					base.getWhichGameObjecttoupdate().GaugeValueUpdated(unit, type, obj);
					break;
				case AdventureEventType.BattleEncounterPlayerGaugeFullyCharged:
					base.getWhichGameObjecttoupdate().GaugeFullyCharged();
					break;
				case AdventureEventType.BattleEncounterPlayerGaugeReleased:
					base.getWhichGameObjecttoupdate().GaugeReleased();
					break;
				}
			}
			return false;
		}

		// Token: 0x170011BA RID: 4538
		// (get) Token: 0x060053A4 RID: 21412 RVA: 0x000AFA39 File Offset: 0x000ADE39
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011BB RID: 4539
		// (get) Token: 0x060053A5 RID: 21413 RVA: 0x000AFA41 File Offset: 0x000ADE41
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053A6 RID: 21414 RVA: 0x000AFA49 File Offset: 0x000ADE49
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060053A7 RID: 21415 RVA: 0x000AFA4B File Offset: 0x000ADE4B
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053A8 RID: 21416 RVA: 0x000AFA52 File Offset: 0x000ADE52
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053A9 RID: 21417 RVA: 0x000AFA5C File Offset: 0x000ADE5C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleManager.<GaugeUpdated>c__Iterator6 <GaugeUpdated>c__Iterator = new BattleManager.<GaugeUpdated>c__Iterator6();
			<GaugeUpdated>c__Iterator.$this = this;
			<GaugeUpdated>c__Iterator.type = type;
			<GaugeUpdated>c__Iterator.unit = unit;
			<GaugeUpdated>c__Iterator.obj = obj;
			return <GaugeUpdated>c__Iterator;
		}

		// Token: 0x04004135 RID: 16693
		internal AdventureEventType type;

		// Token: 0x04004136 RID: 16694
		internal IBattleUnit unit;

		// Token: 0x04004137 RID: 16695
		internal object obj;

		// Token: 0x04004138 RID: 16696
		internal BattleManager $this;

		// Token: 0x04004139 RID: 16697
		internal object $current;

		// Token: 0x0400413A RID: 16698
		internal bool $disposing;

		// Token: 0x0400413B RID: 16699
		internal int $PC;
	}
}
