using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002FE RID: 766
public class WorldMapController : MonoBehaviour
{
	// Token: 0x0600142C RID: 5164 RVA: 0x000A573B File Offset: 0x000A3B3B
	public WorldMapController()
	{
	}

	// Token: 0x170000F6 RID: 246
	// (get) Token: 0x0600142D RID: 5165 RVA: 0x000A5778 File Offset: 0x000A3B78
	private bool SpecialMapSelected
	{
		get
		{
			return this.IsSpecialMap(this._selectedAdventure);
		}
	}

	// Token: 0x0600142E RID: 5166 RVA: 0x000A5788 File Offset: 0x000A3B88
	private void Awake()
	{
		this.AutoUseUsableToggle.isOn = (GameWorld.instance.PlayerProfile.ConsumableItem != null);
		this.RepeaToggle.isOn = false;
		this.GoForwardLevelToggle.isOn = false;
		this.GoForwardLevelToggle.gameObject.SetActive(false);
	}

	// Token: 0x0600142F RID: 5167 RVA: 0x000A57E0 File Offset: 0x000A3BE0
	private void OnEnable()
	{
		GameWorld.instance.PlayerProfile.GetBattleTeams().ForEach(delegate(BattleTeam b)
		{
			b.Rules.RemoveAll((StrategyRule r) => r == null);
		});
		this.DropPanel.gameObject.SetActive(false);
		this.SetUpPage();
	}

	// Token: 0x06001430 RID: 5168 RVA: 0x000A5835 File Offset: 0x000A3C35
	private void OnDisable()
	{
		this.SelectUsableItemPanel.gameObject.SetActive(false);
		this.ConfigueAdventuererPanel.gameObject.SetActive(false);
		this.AutoTacticPanel.gameObject.SetActive(false);
	}

	// Token: 0x06001431 RID: 5169 RVA: 0x000A586C File Offset: 0x000A3C6C
	public void SetUpPage()
	{
		this.KeyNotifyText.SetActive(false);
		this.GoButton.interactable = true;
		if (AutoAdventureController.Instance.AutoAdventure != null)
		{
			this.RepeaToggle.isOn = AutoAdventureController.Instance.AutoAdventure.IsOn;
		}
		List<DungeonRecord> dungeonRecords = this.GetDungeonRecords();
		foreach (WorldMapColliderBaseController worldMapColliderBaseController in this.Colliders)
		{
			worldMapColliderBaseController.Init(dungeonRecords, this);
		}
		using (List<DungeonRecord>.Enumerator enumerator2 = dungeonRecords.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				DungeonRecord record = enumerator2.Current;
				ChessItemController chessItemController = this.Chesses.FirstOrDefault((ChessItemController c) => c.AdventureType == record.AdventureType);
				if (chessItemController != null)
				{
					if (this.IsEnabledRecord(record))
					{
						chessItemController.EnableChess();
					}
					else
					{
						chessItemController.DisableChess();
					}
				}
				if (GameWorld.instance.PlayerProfile.HasSpecialAdventureOpen())
				{
					this.DessertMap.color = this.EnableColor;
					this.SpecialChess.EnableChess();
				}
				else
				{
					this.SpecialChess.DisableChess();
				}
				if (this.SpecialMapSelected)
				{
					this.SpecialChess.Select(AdventureType.Special);
				}
			}
		}
		this.Chesses.ForEach(delegate(ChessItemController c)
		{
			c.Select(this._selectedAdventure);
		});
		DungeonRecord dungeonRecord = dungeonRecords.FirstOrDefault((DungeonRecord d) => d.AdventureType == this._selectedAdventure);
		if (dungeonRecord != null && !this.IsEnabledRecord(dungeonRecord))
		{
			this._selectedAdventure = AdventureType.None;
			this.Chesses.ForEach(delegate(ChessItemController c)
			{
				c.Select(this._selectedAdventure);
			});
			this.HideLevelSelectionPanel();
		}
		if (this._selectedAdventure != AdventureType.None)
		{
			if (!this.SpecialMapSelected)
			{
				this.OnMapChange(GameWorld.instance.PlayerProfile.GetAdventureSelectedLevel(this._selectedAdventure));
			}
			else
			{
				this.UpdateSpecialLevelSelectionPanel(0);
			}
		}
		else
		{
			this.LocationTitle.text = string.Empty;
			this.LocationDescription.text = string.Empty;
		}
		if (this._selectedAdventure == AdventureType.Endless_Entry)
		{
			this.KeyNotifyText.SetActive(true);
			this.GoButton.interactable = (GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.MysticKey) >= 1.0);
		}
		this.SelectToggledItem();
		this.UpdateUsableItem();
		this.UpdateHeroPanel();
		this.UpdateAdventurerEffects();
	}

	// Token: 0x06001432 RID: 5170 RVA: 0x000A5B28 File Offset: 0x000A3F28
	public void ConsumableItemToggleClick()
	{
		if (this.AutoUseUsableToggle.isOn && this._selectedUsableItem != null)
		{
			GameWorld.instance.PlayerProfile.ConsumableItem = new ConsumableItem
			{
				ResourceType = this._selectedUsableItem.Type,
				Level = this._selectedUsableItem.Level
			};
		}
		if (this.AutoUseUsableToggle.isOn && this._selectedUsableItem == null)
		{
			this.AutoUseUsableToggle.isOn = false;
		}
		if (!this.AutoUseUsableToggle.isOn)
		{
			GameWorld.instance.PlayerProfile.ConsumableItem = null;
		}
	}

	// Token: 0x06001433 RID: 5171 RVA: 0x000A5BD0 File Offset: 0x000A3FD0
	private void SelectToggledItem()
	{
		ConsumableItem consumableItem = GameWorld.instance.PlayerProfile.ConsumableItem;
		if (consumableItem != null)
		{
			List<ResourceProfileAntiCheat> consumables = GameWorld.instance.PlayerProfile.GetConsumables();
			ResourceProfileAntiCheat resourceProfileAntiCheat = consumables.FirstOrDefault((ResourceProfileAntiCheat e) => e.ResourceType == consumableItem.ResourceType);
			if (resourceProfileAntiCheat != null)
			{
				this.AutoUseUsableToggle.isOn = true;
				this.SelectUsableItem(resourceProfileAntiCheat.ResourceType.ItemGenerate(ResourceSourceType.None, ItemGenerationQuality.CreateGraded(QualityGrade.Normal), 0, 1));
			}
			else
			{
				this.AutoUseUsableToggle.isOn = false;
			}
		}
		else
		{
			this.AutoUseUsableToggle.isOn = false;
			this.SelectUsableItem(null);
		}
	}

	// Token: 0x06001434 RID: 5172 RVA: 0x000A5C7B File Offset: 0x000A407B
	private bool IsSpecialMap(AdventureType adventureType)
	{
		return adventureType == AdventureType.Special;
	}

	// Token: 0x06001435 RID: 5173 RVA: 0x000A5C84 File Offset: 0x000A4084
	private bool MapIsEnable(AdventureType type)
	{
		if (this.IsSpecialMap(type))
		{
			return GameWorld.instance.PlayerProfile.HasSpecialAdventureOpen();
		}
		DungeonRecord dungeonRecord = this.GetDungeonRecords().FirstOrDefault((DungeonRecord d) => d.AdventureType == type);
		return dungeonRecord != null && this.IsEnabledRecord(dungeonRecord);
	}

	// Token: 0x06001436 RID: 5174 RVA: 0x000A5CE7 File Offset: 0x000A40E7
	public void DeselectItem()
	{
		this._selectedUsableItem = null;
		this.UsableItemPanel.Reset();
		this.CloseTooltip();
	}

	// Token: 0x06001437 RID: 5175 RVA: 0x000A5D04 File Offset: 0x000A4104
	public void UpdateUsableItem()
	{
		if (this._selectedUsableItem == null)
		{
			this.UsableItemPanel.Reset();
		}
		else
		{
			List<ResourceProfileAntiCheat> list = (from i in GameWorld.instance.PlayerProfile.GetConsumables()
			where i.ResourceType == this._selectedUsableItem.Type
			select i).ToList<ResourceProfileAntiCheat>();
			if (list.Count > 0 && list[0].GetValue() > 0.0)
			{
				this.UsableItemPanel.Init(list[0].ResourceType.ItemGenerate(ResourceSourceType.None, ItemGenerationQuality.CreateGraded(QualityGrade.Normal), 0, 1));
			}
			else
			{
				this._selectedUsableItem = null;
				this.UsableItemPanel.Reset();
			}
		}
	}

	// Token: 0x06001438 RID: 5176 RVA: 0x000A5DB9 File Offset: 0x000A41B9
	public void OpenSelectUsableItemPanel()
	{
		this.SelectUsableItemPanel.AutoSelectedItem(this._selectedUsableItem);
		this.SelectUsableItemPanel.Init();
		this.SelectUsableItemPanel.gameObject.SetActive(true);
	}

	// Token: 0x06001439 RID: 5177 RVA: 0x000A5DE8 File Offset: 0x000A41E8
	public void CloseSelectUsableItemPanel()
	{
		this.SelectUsableItemPanel.gameObject.SetActive(false);
	}

	// Token: 0x0600143A RID: 5178 RVA: 0x000A5DFC File Offset: 0x000A41FC
	public void StartAdventure()
	{
		if (GameWorld.instance.PlayerProfile.IsInventoryFull())
		{
			this.DisplayWarningText(UIComponentType.InventoryFullNotify.GetName());
			AutoAdventureController.Instance.StopAutoAdventure();
			TownManager.Instance.Ui.ShowTown();
			return;
		}
		if (this._selectedAdventure == AdventureType.None)
		{
			AutoAdventureController.Instance.StopAutoAdventure();
			TownManager.Instance.Ui.ShowTown();
			return;
		}
		if (this._selectedAdventure == AdventureType.Endless_Entry && GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.MysticKey) <= 0.0)
		{
			AutoAdventureController.Instance.StopAutoAdventure();
			TownManager.Instance.Ui.ShowTown();
			return;
		}
		if (GameWorld.instance.GetCurrentAdventure() != null)
		{
			this.DisplayWarningText(UIComponentType.WorldMapLastAdventureNotEndNotify.GetName());
			TownManager.Instance.Ui.ShowTown();
			return;
		}
		if (this._selectedLevel != -1 && this._selectedAdventure != AdventureType.None)
		{
			if (this._heroList.Any((AdventurerProfile h) => h != null))
			{
				List<Item> list = new List<Item>();
				if (this._selectedUsableItem != null)
				{
					list.Add(this._selectedUsableItem);
				}
				BattleTeam selectedBattleTeam = GameWorld.instance.PlayerProfile.GetSelectedBattleTeam();
				List<StrategyRule> autoStrategyRules = (!selectedBattleTeam.AutoUseTactic) ? null : selectedBattleTeam.Rules;
				if (this.SpecialMapSelected)
				{
					GameWorld.instance.StartAdventure((from h in (from h in this._heroList
					where h != null
					select h).ToList<AdventurerProfile>()
					select h.Id).ToList<string>(), this._specialAdventure, (from i in list
					select i.Type).ToList<ResourceType>(), false, autoStrategyRules);
				}
				else
				{
					GameWorld.instance.PlayerProfile.SetDungeonRecordLevel(this._selectedAdventure, this._selectedLevel);
					AutoAdventureController.Instance.SetAutoAdventure(new AutoAdventureItem
					{
						IsOn = this.RepeaToggle.isOn,
						SelectedAdventure = this._selectedAdventure,
						SelectedAdventurers = this._heroList.ToList<AdventurerProfile>(),
						SelectedItems = list
					});
					GameWorld.instance.StartAdventure((from h in (from h in this._heroList
					where h != null
					select h).ToList<AdventurerProfile>()
					select h.Id).ToList<string>(), this._selectedAdventure, (from i in list
					select i.Type).ToList<ResourceType>(), this.GoForwardLevelToggle.isOn, autoStrategyRules);
				}
				base.gameObject.SetActive(false);
				return;
			}
		}
		this.DisplayWarningText(UIComponentType.WorldMapNotYetSelectAdventurerOrMap.GetName());
	}

	// Token: 0x0600143B RID: 5179 RVA: 0x000A612C File Offset: 0x000A452C
	public void SelectUsableItem(Item item)
	{
		this._selectedUsableItem = item;
		this.UsableItemPanel.Init(item);
		if (this._selectedUsableItem != null)
		{
			GameWorld.instance.PlayerProfile.ConsumableItem = new ConsumableItem
			{
				ResourceType = this._selectedUsableItem.Type,
				Level = this._selectedUsableItem.Level
			};
		}
	}

	// Token: 0x0600143C RID: 5180 RVA: 0x000A618F File Offset: 0x000A458F
	public void UpdateHeroPanel()
	{
		this.UpdateRules();
		this.SelectBattleTeam(GameWorld.instance.PlayerProfile.GetIndexOfSelectedBattleTeam());
	}

	// Token: 0x0600143D RID: 5181 RVA: 0x000A61AC File Offset: 0x000A45AC
	public void SelectBattleTeam(int index)
	{
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		if (index < playerProfile.GetBattleTeams().Count)
		{
			GameWorld.instance.PlayerProfile.SelectBattleTeam(index);
			this.ConfigueAdventuererPanel.UpdatePickedHeros();
			this.AssignSelectedBattleTeam(GameWorld.instance.PlayerProfile.GetSelectedBattleTeam());
		}
		for (int i = 0; i < playerProfile.GetBattleTeams().Count; i++)
		{
			this.TeamButtons[i].interactable = (i != index);
		}
		this.UpdateRules();
		this.UpdateAdventurerEffects();
	}

	// Token: 0x0600143E RID: 5182 RVA: 0x000A6248 File Offset: 0x000A4648
	private void UpdateRules()
	{
		BattleTeam battleTeam = GameWorld.instance.PlayerProfile.GetSelectedBattleTeam();
		battleTeam.Rules = (from r in battleTeam.Rules
		where battleTeam.Adventurers.Any((AdventurerProfile h) => h.Id == r.AdventurerId)
		select r).ToList<StrategyRule>();
		GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Rules = battleTeam.Rules;
		this.AutoUseTacticToggle.isOn = battleTeam.AutoUseTactic;
	}

	// Token: 0x0600143F RID: 5183 RVA: 0x000A62D4 File Offset: 0x000A46D4
	private void AssignSelectedBattleTeam(BattleTeam team)
	{
		for (int i = 0; i < team.Adventurers.Count; i++)
		{
			this._heroList[i] = team.Adventurers[i];
		}
		for (int j = team.Adventurers.Count; j < this._heroList.Length; j++)
		{
			this._heroList[j] = null;
		}
		List<AdventurerProfile> adventurerProfiles = GameWorld.instance.PlayerProfile.AdventurerProfiles;
		for (int k = 0; k < this._heroList.Length; k++)
		{
			if (!adventurerProfiles.Contains(this._heroList[k]))
			{
				this._heroList[k] = null;
			}
		}
		this.HeroPanel.Init(this._heroList, GameWorld.instance.PlayerProfile.AdvancedTeamEnabled());
	}

	// Token: 0x06001440 RID: 5184 RVA: 0x000A63A4 File Offset: 0x000A47A4
	public void MoveHero(int currentIndex, int newIndex)
	{
		List<AdventurerProfile> adventurers = GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Adventurers;
		int count = adventurers.Count;
		if (count == 0 || count <= currentIndex || count <= newIndex)
		{
			return;
		}
		AdventurerProfile value = adventurers[newIndex];
		adventurers[newIndex] = adventurers[currentIndex];
		adventurers[currentIndex] = value;
		this.UpdateHeroPanel();
	}

	// Token: 0x06001441 RID: 5185 RVA: 0x000A6408 File Offset: 0x000A4808
	public void DeselectHero(int index)
	{
		List<AdventurerProfile> adventurers = GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Adventurers;
		if (adventurers.Count > index)
		{
			adventurers.RemoveAt(index);
			this.UpdateHeroPanel();
		}
	}

	// Token: 0x06001442 RID: 5186 RVA: 0x000A6443 File Offset: 0x000A4843
	public void ChangeHero(int index)
	{
		this.ConfigueAdventuererPanel.UpdateHeroPage();
		this.ConfigueAdventuererPanel.gameObject.SetActive(true);
	}

	// Token: 0x06001443 RID: 5187 RVA: 0x000A6461 File Offset: 0x000A4861
	public void OpenHeroConfiguePanel()
	{
		this.ConfigueAdventuererPanel.UpdateHeroPage();
		this.ConfigueAdventuererPanel.gameObject.SetActive(true);
	}

	// Token: 0x06001444 RID: 5188 RVA: 0x000A647F File Offset: 0x000A487F
	public void ClosePanel()
	{
		this.ConfigueAdventuererPanel.gameObject.SetActive(false);
	}

	// Token: 0x06001445 RID: 5189 RVA: 0x000A6492 File Offset: 0x000A4892
	public void OpenAutoTacticPanel()
	{
		this.AutoTacticPanel.Init(GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Rules);
		this.AutoTacticPanel.gameObject.SetActive(true);
	}

	// Token: 0x06001446 RID: 5190 RVA: 0x000A64C4 File Offset: 0x000A48C4
	public void CloseAutoTacticPanel()
	{
		this.AutoTacticPanel.gameObject.SetActive(false);
	}

	// Token: 0x06001447 RID: 5191 RVA: 0x000A64D7 File Offset: 0x000A48D7
	public void ConfirmAutoTacticPanel()
	{
		GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Rules = this.AutoTacticPanel.Rules;
		this.AutoTacticPanel.gameObject.SetActive(false);
	}

	// Token: 0x06001448 RID: 5192 RVA: 0x000A6509 File Offset: 0x000A4909
	public void ToggleAutoTactic()
	{
		GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().AutoUseTactic = this.AutoUseTacticToggle.isOn;
	}

	// Token: 0x06001449 RID: 5193 RVA: 0x000A652C File Offset: 0x000A492C
	public void PickHeros(List<AdventurerProfile> heros)
	{
		int num = (!GameWorld.instance.PlayerProfile.AdvancedTeamEnabled()) ? 3 : 5;
		for (int i = 0; i < heros.Count; i++)
		{
			this._heroList[i] = heros[i];
		}
		for (int j = heros.Count; j < num; j++)
		{
			this._heroList[j] = null;
		}
		this.ClosePanel();
		GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Adventurers = heros;
		this.UpdateHeroPanel();
		this.UpdateAdventurerEffects();
	}

	// Token: 0x0600144A RID: 5194 RVA: 0x000A65C2 File Offset: 0x000A49C2
	public void HideLevelSelectionPanel()
	{
		this.LevelSelectionPanel.Hide();
	}

	// Token: 0x0600144B RID: 5195 RVA: 0x000A65D0 File Offset: 0x000A49D0
	public void OnMapChange(int level)
	{
		if (this._selectedAdventure == AdventureType.None)
		{
			return;
		}
		this.UpdateLevelSelectionPanel(level);
		int maxVisibleLevel = this._selectedAdventure.GetMaxVisibleLevel();
		if (base.isActiveAndEnabled)
		{
			this.LevelSelectionPanel.DisplaySelectedPage();
		}
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x000A6614 File Offset: 0x000A4A14
	public void UpdateLevelSelectionPanel(int level)
	{
		if (this._selectedAdventure == AdventureType.None)
		{
			return;
		}
		List<DungeonLevelDetails> levelDetails = this._selectedAdventure.GetLevelDetails();
		if (level <= 0)
		{
			level = 1;
		}
		this._selectedLevel = level;
		this.LevelSelectionPanel.ShowLevelPanel(levelDetails, this._selectedLevel);
		DungeonLevelDetails dungeonLevelDetails = levelDetails.FirstOrDefault((DungeonLevelDetails l) => l.LevelNumber == level);
		if (dungeonLevelDetails != null)
		{
			this.DropPanel.Init(dungeonLevelDetails.EquipmentLevel, dungeonLevelDetails.GemLevel);
			this.DropPanel.gameObject.SetActive(true);
		}
		else
		{
			this.DropPanel.gameObject.SetActive(false);
		}
		GameWorld.instance.PlayerProfile.SetDungeonRecordLevel(this._selectedAdventure, this._selectedLevel);
		this.UpdateMapEffects();
		this.RepeatToggleChange();
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x000A66F8 File Offset: 0x000A4AF8
	public void SelectLevel(DungeonLevelDetails dungeon, bool changingLevel)
	{
		if (this._selectedAdventure == AdventureType.None)
		{
			return;
		}
		int num = dungeon.LevelNumber;
		if (num <= 0)
		{
			num = 1;
		}
		this._selectedLevel = num;
		this.LevelSelectionPanel.ChangeLevelSelected(dungeon);
		this.DropPanel.Init(dungeon.EquipmentLevel, dungeon.GemLevel);
		this.DropPanel.gameObject.SetActive(true);
		if (changingLevel)
		{
			this.DropPanel.Show();
		}
		GameWorld.instance.PlayerProfile.SetDungeonRecordLevel(this._selectedAdventure, this._selectedLevel);
		this.UpdateMapEffects();
		this.RepeatToggleChange();
	}

	// Token: 0x0600144E RID: 5198 RVA: 0x000A6796 File Offset: 0x000A4B96
	public void SelectLevelFromChessLevelItem(AdventureType type, int level)
	{
		this._selectedAdventure = type;
		this._selectedLevel = level;
		this.StartAdventure();
	}

	// Token: 0x0600144F RID: 5199 RVA: 0x000A67AC File Offset: 0x000A4BAC
	public void UpdateSpecialLevelSelectionPanel(int level)
	{
		List<AdventureType> specialAdventureTypes = GameWorld.instance.PlayerProfile.GetSpecialAdventureTypes();
		if (specialAdventureTypes.Count <= 0)
		{
			this._selectedAdventure = AdventureType.None;
		}
		else if (specialAdventureTypes.Count > level)
		{
			this._specialAdventure = specialAdventureTypes[level];
			this._selectedLevel = 1;
			this.LevelSelectionPanel.ShowSpecialLevelPanel(specialAdventureTypes, level);
		}
	}

	// Token: 0x06001450 RID: 5200 RVA: 0x000A6810 File Offset: 0x000A4C10
	public void SelectAdventureLevel(int value)
	{
		if (!this.SpecialMapSelected)
		{
			this._selectedLevel = value;
			GameWorld.instance.PlayerProfile.SetDungeonRecordLevel(this._selectedAdventure, this._selectedLevel + 1);
			this.UpdateMapEffects();
		}
		else
		{
			List<AdventureType> specialAdventureTypes = GameWorld.instance.PlayerProfile.GetSpecialAdventureTypes();
			this._specialAdventure = specialAdventureTypes[value];
			this._selectedLevel = 1;
		}
	}

	// Token: 0x06001451 RID: 5201 RVA: 0x000A687C File Offset: 0x000A4C7C
	private void UpdateMapEffects()
	{
		List<Item> list = new List<Item>();
		if (this._selectedUsableItem != null)
		{
			list.Add(this._selectedUsableItem);
		}
		List<ISpecialEffectDataLoad> list2 = GameWorld.instance.ShowAdventureDungeonEffects((from h in (from h in this._heroList
		where h != null
		select h).ToList<AdventurerProfile>()
		select h.Id).ToList<string>(), this._selectedAdventure, (from i in list
		select i.Type).ToList<ResourceType>());
		if (list2.Count != 0)
		{
			this.MapEffectPanel.Init(list2);
			this.MapEffectPanel.gameObject.SetActive(true);
		}
		else
		{
			this.MapEffectPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001452 RID: 5202 RVA: 0x000A6974 File Offset: 0x000A4D74
	private void UpdateAdventurerEffects()
	{
		BattleTeam selectedBattleTeam = GameWorld.instance.PlayerProfile.GetSelectedBattleTeam();
		List<ISpecialEffectDataLoad> adventureTeamBonus = TeamSetBase.GetAdventureTeamBonus(selectedBattleTeam.Adventurers);
		if (adventureTeamBonus.Count > 0)
		{
			this.TeamSetEffectPanel.Init(adventureTeamBonus);
			this.TeamSetEffectPanel.gameObject.SetActive(true);
		}
		else
		{
			this.TeamSetEffectPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001453 RID: 5203 RVA: 0x000A69DC File Offset: 0x000A4DDC
	public void DisplayLocationDetails(AdventureType type)
	{
		if (this._selectedAdventure == type)
		{
			return;
		}
		Description description = type.GetDescription();
		this.LocationTitle.text = description.Title;
		this.LocationDescription.text = description.Details1;
		this.Chesses.ForEach(delegate(ChessItemController c)
		{
			c.MouseOver(type);
		});
		if (this.GetIsSpeicalMap(type))
		{
			this.SpecialChess.MouseOver(AdventureType.Special);
		}
	}

	// Token: 0x06001454 RID: 5204 RVA: 0x000A6A6C File Offset: 0x000A4E6C
	public void HideLocationDetails(AdventureType type)
	{
		this.LocationTitle.text = string.Empty;
		this.LocationDescription.text = string.Empty;
		if (this.MapIsEnable(type))
		{
			ChessItemController chessItemController = this.Chesses.FirstOrDefault((ChessItemController c) => c.AdventureType == type);
			if (chessItemController != null)
			{
				chessItemController.MouseExit(type);
			}
			if (this.GetIsSpeicalMap(type) && !this.GetIsSpeicalMap(this._selectedAdventure))
			{
				this.SpecialChess.MouseExit(AdventureType.Special);
			}
		}
		if (this._selectedAdventure != AdventureType.None)
		{
			this.ShowSelectedMap();
		}
	}

	// Token: 0x06001455 RID: 5205 RVA: 0x000A6B2C File Offset: 0x000A4F2C
	public void SelectMap(AdventureType type)
	{
		if (this._selectedAdventure == type)
		{
			this._selectedAdventure = AdventureType.None;
			ChessItemController chessItemController = this.Chesses.FirstOrDefault((ChessItemController c) => c.AdventureType == type);
			if (chessItemController != null)
			{
				chessItemController.MouseExit(type);
			}
			if (this.GetIsSpeicalMap(type))
			{
				this.SpecialChess.MouseExit(AdventureType.Special);
			}
			this.HideLocationDetails(type);
			this.HideLevelSelectionPanel();
			this.KeyNotifyText.SetActive(false);
			this.GoButton.interactable = true;
		}
		else
		{
			this._selectedAdventure = type;
			this.ClearSeleted();
			this.ShowSelectedMap();
			if (!this.SpecialMapSelected)
			{
				this.OnMapChange(GameWorld.instance.PlayerProfile.GetAdventureSelectedLevel(this._selectedAdventure));
			}
			else
			{
				this.UpdateSpecialLevelSelectionPanel(0);
			}
			if (this.GetIsSpeicalMap(type))
			{
				this.SpecialChess.Select(AdventureType.Special);
			}
			if (!this.GetIsSpeicalMap(this._selectedAdventure))
			{
				this.RepeaToggle.gameObject.SetActive(true);
				this.GoForwardLevelToggle.isOn = false;
				this.GoForwardLevelToggle.gameObject.SetActive(false);
			}
			else
			{
				this.RepeaToggle.isOn = false;
				this.GoForwardLevelToggle.isOn = false;
				this.RepeaToggle.gameObject.SetActive(false);
				this.GoForwardLevelToggle.gameObject.SetActive(false);
			}
			if (type == AdventureType.Endless_Entry)
			{
				this.KeyNotifyText.SetActive(true);
				this.GoButton.interactable = (GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.MysticKey) >= 1.0);
			}
			else
			{
				this.KeyNotifyText.SetActive(false);
				this.GoButton.interactable = true;
			}
		}
	}

	// Token: 0x06001456 RID: 5206 RVA: 0x000A6D28 File Offset: 0x000A5128
	public void RepeatToggleChange()
	{
		if (AutoAdventureController.Instance.AutoAdventure.IsOn)
		{
			return;
		}
		if (this.RepeaToggle.isOn && this._selectedAdventure != AdventureType.None && this._selectedLevel != 0)
		{
			this.GoForwardLevelToggle.isOn = false;
			this.GoForwardLevelToggle.gameObject.SetActive(false);
			if (this._selectedLevel == this._selectedAdventure.GetMaxVisibleLevel())
			{
				this.GoForwardLevelToggle.gameObject.SetActive(true);
			}
		}
		else
		{
			this.GoForwardLevelToggle.isOn = false;
			this.GoForwardLevelToggle.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001457 RID: 5207 RVA: 0x000A6DD8 File Offset: 0x000A51D8
	public void RemoveAdventurer(AdventurerProfile profile)
	{
		for (int i = 0; i < this._heroList.Length; i++)
		{
			if (this._heroList[i] != null && this._heroList[i].Id == profile.Id)
			{
				this._heroList[i] = null;
			}
		}
		this.UpdateHeroPanel();
	}

	// Token: 0x06001458 RID: 5208 RVA: 0x000A6E38 File Offset: 0x000A5238
	private void ShowSelectedMap()
	{
		Description description = this._selectedAdventure.GetDescription();
		this.LocationTitle.text = description.Title;
		this.LocationDescription.text = description.Details1;
		this.Chesses.ForEach(delegate(ChessItemController c)
		{
			c.Select(this._selectedAdventure);
		});
	}

	// Token: 0x06001459 RID: 5209 RVA: 0x000A6E8C File Offset: 0x000A528C
	public void ClearSeleted()
	{
		this.LocationTitle.text = string.Empty;
		this.LocationDescription.text = string.Empty;
		if (GameWorld.instance.PlayerProfile.HasSpecialAdventureOpen())
		{
			this.SpecialChess.EnableChess();
		}
		else
		{
			this.SpecialChess.DisableChess();
		}
		using (List<DungeonRecord>.Enumerator enumerator = this.GetDungeonRecords().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				DungeonRecord dungeonRecord = enumerator.Current;
				ChessItemController chessItemController = this.Chesses.FirstOrDefault((ChessItemController c) => c.AdventureType == dungeonRecord.AdventureType);
				if (chessItemController != null)
				{
					if (this.IsEnabledRecord(dungeonRecord))
					{
						chessItemController.EnableChess();
					}
					else
					{
						chessItemController.DisableChess();
					}
				}
			}
		}
	}

	// Token: 0x0600145A RID: 5210 RVA: 0x000A6F84 File Offset: 0x000A5384
	public bool IsEnabledRecord(DungeonRecord record)
	{
		if (record.AdventureType == AdventureType.Endless_Entry)
		{
			return GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.MysticKey) >= 0.0;
		}
		return record.IsEnabled;
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x000A6FBC File Offset: 0x000A53BC
	private List<DungeonRecord> GetDungeonRecords()
	{
		List<DungeonRecord> list = new List<DungeonRecord>();
		list.AddRange(GameWorld.instance.PlayerProfile.GetProgress(null).DungeonRecords);
		list.Add(GameWorld.instance.PlayerProfile.EndlessRecord);
		return list;
	}

	// Token: 0x0600145C RID: 5212 RVA: 0x000A7008 File Offset: 0x000A5408
	private bool GetIsSpeicalMap(AdventureType type)
	{
		switch (type)
		{
		case AdventureType.HellishPath:
		case AdventureType.SnowMountain:
		case AdventureType.MistForest:
		case AdventureType.NorthernTerritory:
		case AdventureType.Endless_Entry:
			break;
		default:
			switch (type)
			{
			case AdventureType.WoodenForest:
			case AdventureType.ImperialMausoleum:
			case AdventureType.BuriedTemple:
				return false;
			case AdventureType.SilientPalace:
				return true;
			}
			return true;
		case AdventureType.ShadowPath:
		case AdventureType.RoyalWaterFall:
		case AdventureType.Special:
			return true;
		}
		return false;
	}

	// Token: 0x0600145D RID: 5213 RVA: 0x000A7086 File Offset: 0x000A5486
	[CompilerGenerated]
	private static void <OnEnable>m__0(BattleTeam b)
	{
		b.Rules.RemoveAll((StrategyRule r) => r == null);
	}

	// Token: 0x0600145E RID: 5214 RVA: 0x000A70B1 File Offset: 0x000A54B1
	[CompilerGenerated]
	private void <SetUpPage>m__1(ChessItemController c)
	{
		c.Select(this._selectedAdventure);
	}

	// Token: 0x0600145F RID: 5215 RVA: 0x000A70BF File Offset: 0x000A54BF
	[CompilerGenerated]
	private bool <SetUpPage>m__2(DungeonRecord d)
	{
		return d.AdventureType == this._selectedAdventure;
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000A70CF File Offset: 0x000A54CF
	[CompilerGenerated]
	private void <SetUpPage>m__3(ChessItemController c)
	{
		c.Select(this._selectedAdventure);
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x000A70DD File Offset: 0x000A54DD
	[CompilerGenerated]
	private bool <UpdateUsableItem>m__4(ResourceProfileAntiCheat i)
	{
		return i.ResourceType == this._selectedUsableItem.Type;
	}

	// Token: 0x06001462 RID: 5218 RVA: 0x000A70F2 File Offset: 0x000A54F2
	[CompilerGenerated]
	private static bool <StartAdventure>m__5(AdventurerProfile h)
	{
		return h != null;
	}

	// Token: 0x06001463 RID: 5219 RVA: 0x000A70FB File Offset: 0x000A54FB
	[CompilerGenerated]
	private static bool <StartAdventure>m__6(AdventurerProfile h)
	{
		return h != null;
	}

	// Token: 0x06001464 RID: 5220 RVA: 0x000A7104 File Offset: 0x000A5504
	[CompilerGenerated]
	private static string <StartAdventure>m__7(AdventurerProfile h)
	{
		return h.Id;
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000A710C File Offset: 0x000A550C
	[CompilerGenerated]
	private static ResourceType <StartAdventure>m__8(Item i)
	{
		return i.Type;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x000A7114 File Offset: 0x000A5514
	[CompilerGenerated]
	private static bool <StartAdventure>m__9(AdventurerProfile h)
	{
		return h != null;
	}

	// Token: 0x06001467 RID: 5223 RVA: 0x000A711D File Offset: 0x000A551D
	[CompilerGenerated]
	private static string <StartAdventure>m__A(AdventurerProfile h)
	{
		return h.Id;
	}

	// Token: 0x06001468 RID: 5224 RVA: 0x000A7125 File Offset: 0x000A5525
	[CompilerGenerated]
	private static ResourceType <StartAdventure>m__B(Item i)
	{
		return i.Type;
	}

	// Token: 0x06001469 RID: 5225 RVA: 0x000A712D File Offset: 0x000A552D
	[CompilerGenerated]
	private static bool <UpdateMapEffects>m__C(AdventurerProfile h)
	{
		return h != null;
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000A7136 File Offset: 0x000A5536
	[CompilerGenerated]
	private static string <UpdateMapEffects>m__D(AdventurerProfile h)
	{
		return h.Id;
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x000A713E File Offset: 0x000A553E
	[CompilerGenerated]
	private static ResourceType <UpdateMapEffects>m__E(Item i)
	{
		return i.Type;
	}

	// Token: 0x0600146C RID: 5228 RVA: 0x000A7146 File Offset: 0x000A5546
	[CompilerGenerated]
	private void <ShowSelectedMap>m__F(ChessItemController c)
	{
		c.Select(this._selectedAdventure);
	}

	// Token: 0x0600146D RID: 5229 RVA: 0x000A7154 File Offset: 0x000A5554
	[CompilerGenerated]
	private static bool <OnEnable>m__10(StrategyRule r)
	{
		return r == null;
	}

	// Token: 0x0400146C RID: 5228
	public TextMeshProUGUI LocationTitle;

	// Token: 0x0400146D RID: 5229
	public TextMeshProUGUI LocationDescription;

	// Token: 0x0400146E RID: 5230
	public Image DarkMap;

	// Token: 0x0400146F RID: 5231
	public Image SnowMap;

	// Token: 0x04001470 RID: 5232
	public Image GrassMap;

	// Token: 0x04001471 RID: 5233
	public Image DessertMap;

	// Token: 0x04001472 RID: 5234
	public Image VolcanoMap;

	// Token: 0x04001473 RID: 5235
	public Image TempleMap;

	// Token: 0x04001474 RID: 5236
	public Image HauntedGardenMap;

	// Token: 0x04001475 RID: 5237
	public Image NorthenTerrainMap;

	// Token: 0x04001476 RID: 5238
	public List<ChessItemController> Chesses;

	// Token: 0x04001477 RID: 5239
	public ChessItemController SpecialChess;

	// Token: 0x04001478 RID: 5240
	public Color MouseOverColor = ColorPicker.NagetiveRed;

	// Token: 0x04001479 RID: 5241
	public Color SeletedColor = Color.blue;

	// Token: 0x0400147A RID: 5242
	public Color EnableColor = Color.white;

	// Token: 0x0400147B RID: 5243
	public LevelSelectionPanelController LevelSelectionPanel;

	// Token: 0x0400147C RID: 5244
	public ConfigueAdventurerPanelController ConfigueAdventuererPanel;

	// Token: 0x0400147D RID: 5245
	public WorldSelectUsableItemPanelController SelectUsableItemPanel;

	// Token: 0x0400147E RID: 5246
	public AutoTacticPanelController AutoTacticPanel;

	// Token: 0x0400147F RID: 5247
	public WorldMapHeroPanelController HeroPanel;

	// Token: 0x04001480 RID: 5248
	public List<Button> TeamButtons;

	// Token: 0x04001481 RID: 5249
	public WorldUsableItemPanelController UsableItemPanel;

	// Token: 0x04001482 RID: 5250
	public MapEffectPanelController MapEffectPanel;

	// Token: 0x04001483 RID: 5251
	public MapEffectPanelController TeamSetEffectPanel;

	// Token: 0x04001484 RID: 5252
	public Toggle AutoUseUsableToggle;

	// Token: 0x04001485 RID: 5253
	public Toggle RepeaToggle;

	// Token: 0x04001486 RID: 5254
	public Toggle GoForwardLevelToggle;

	// Token: 0x04001487 RID: 5255
	public Toggle AutoUseTacticToggle;

	// Token: 0x04001488 RID: 5256
	public GameObject KeyNotifyText;

	// Token: 0x04001489 RID: 5257
	public Button GoButton;

	// Token: 0x0400148A RID: 5258
	public DropItemPanelController DropPanel;

	// Token: 0x0400148B RID: 5259
	public List<WorldMapColliderBaseController> Colliders;

	// Token: 0x0400148C RID: 5260
	private AdventureType _selectedAdventure = AdventureType.None;

	// Token: 0x0400148D RID: 5261
	private AdventureType _specialAdventure;

	// Token: 0x0400148E RID: 5262
	private int _selectedLevel;

	// Token: 0x0400148F RID: 5263
	private readonly AdventurerProfile[] _heroList = new AdventurerProfile[5];

	// Token: 0x04001490 RID: 5264
	private Item _selectedUsableItem;

	// Token: 0x04001491 RID: 5265
	[CompilerGenerated]
	private static Action<BattleTeam> <>f__am$cache0;

	// Token: 0x04001492 RID: 5266
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache1;

	// Token: 0x04001493 RID: 5267
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache2;

	// Token: 0x04001494 RID: 5268
	[CompilerGenerated]
	private static Func<AdventurerProfile, string> <>f__am$cache3;

	// Token: 0x04001495 RID: 5269
	[CompilerGenerated]
	private static Func<Item, ResourceType> <>f__am$cache4;

	// Token: 0x04001496 RID: 5270
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache5;

	// Token: 0x04001497 RID: 5271
	[CompilerGenerated]
	private static Func<AdventurerProfile, string> <>f__am$cache6;

	// Token: 0x04001498 RID: 5272
	[CompilerGenerated]
	private static Func<Item, ResourceType> <>f__am$cache7;

	// Token: 0x04001499 RID: 5273
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache8;

	// Token: 0x0400149A RID: 5274
	[CompilerGenerated]
	private static Func<AdventurerProfile, string> <>f__am$cache9;

	// Token: 0x0400149B RID: 5275
	[CompilerGenerated]
	private static Func<Item, ResourceType> <>f__am$cacheA;

	// Token: 0x0400149C RID: 5276
	[CompilerGenerated]
	private static Predicate<StrategyRule> <>f__am$cacheB;

	// Token: 0x02000C7B RID: 3195
	[CompilerGenerated]
	private sealed class <SetUpPage>c__AnonStorey0
	{
		// Token: 0x06005306 RID: 21254 RVA: 0x000A715A File Offset: 0x000A555A
		public <SetUpPage>c__AnonStorey0()
		{
		}

		// Token: 0x06005307 RID: 21255 RVA: 0x000A7162 File Offset: 0x000A5562
		internal bool <>m__0(ChessItemController c)
		{
			return c.AdventureType == this.record.AdventureType;
		}

		// Token: 0x040040AC RID: 16556
		internal DungeonRecord record;
	}

	// Token: 0x02000C7C RID: 3196
	[CompilerGenerated]
	private sealed class <SelectToggledItem>c__AnonStorey1
	{
		// Token: 0x06005308 RID: 21256 RVA: 0x000A7177 File Offset: 0x000A5577
		public <SelectToggledItem>c__AnonStorey1()
		{
		}

		// Token: 0x06005309 RID: 21257 RVA: 0x000A717F File Offset: 0x000A557F
		internal bool <>m__0(ResourceProfileAntiCheat e)
		{
			return e.ResourceType == this.consumableItem.ResourceType;
		}

		// Token: 0x040040AD RID: 16557
		internal ConsumableItem consumableItem;
	}

	// Token: 0x02000C7D RID: 3197
	[CompilerGenerated]
	private sealed class <MapIsEnable>c__AnonStorey2
	{
		// Token: 0x0600530A RID: 21258 RVA: 0x000A7194 File Offset: 0x000A5594
		public <MapIsEnable>c__AnonStorey2()
		{
		}

		// Token: 0x0600530B RID: 21259 RVA: 0x000A719C File Offset: 0x000A559C
		internal bool <>m__0(DungeonRecord d)
		{
			return d.AdventureType == this.type;
		}

		// Token: 0x040040AE RID: 16558
		internal AdventureType type;
	}

	// Token: 0x02000C7E RID: 3198
	[CompilerGenerated]
	private sealed class <UpdateRules>c__AnonStorey3
	{
		// Token: 0x0600530C RID: 21260 RVA: 0x000A71AC File Offset: 0x000A55AC
		public <UpdateRules>c__AnonStorey3()
		{
		}

		// Token: 0x0600530D RID: 21261 RVA: 0x000A71B4 File Offset: 0x000A55B4
		internal bool <>m__0(StrategyRule r)
		{
			return this.battleTeam.Adventurers.Any((AdventurerProfile h) => h.Id == r.AdventurerId);
		}

		// Token: 0x040040AF RID: 16559
		internal BattleTeam battleTeam;

		// Token: 0x02000C84 RID: 3204
		private sealed class <UpdateRules>c__AnonStorey4
		{
			// Token: 0x06005318 RID: 21272 RVA: 0x000A71F1 File Offset: 0x000A55F1
			public <UpdateRules>c__AnonStorey4()
			{
			}

			// Token: 0x06005319 RID: 21273 RVA: 0x000A71F9 File Offset: 0x000A55F9
			internal bool <>m__0(AdventurerProfile h)
			{
				return h.Id == this.r.AdventurerId;
			}

			// Token: 0x040040B5 RID: 16565
			internal StrategyRule r;

			// Token: 0x040040B6 RID: 16566
			internal WorldMapController.<UpdateRules>c__AnonStorey3 <>f__ref$3;
		}
	}

	// Token: 0x02000C7F RID: 3199
	[CompilerGenerated]
	private sealed class <UpdateLevelSelectionPanel>c__AnonStorey5
	{
		// Token: 0x0600530E RID: 21262 RVA: 0x000A7211 File Offset: 0x000A5611
		public <UpdateLevelSelectionPanel>c__AnonStorey5()
		{
		}

		// Token: 0x0600530F RID: 21263 RVA: 0x000A7219 File Offset: 0x000A5619
		internal bool <>m__0(DungeonLevelDetails l)
		{
			return l.LevelNumber == this.level;
		}

		// Token: 0x040040B0 RID: 16560
		internal int level;
	}

	// Token: 0x02000C80 RID: 3200
	[CompilerGenerated]
	private sealed class <DisplayLocationDetails>c__AnonStorey6
	{
		// Token: 0x06005310 RID: 21264 RVA: 0x000A7229 File Offset: 0x000A5629
		public <DisplayLocationDetails>c__AnonStorey6()
		{
		}

		// Token: 0x06005311 RID: 21265 RVA: 0x000A7231 File Offset: 0x000A5631
		internal void <>m__0(ChessItemController c)
		{
			c.MouseOver(this.type);
		}

		// Token: 0x040040B1 RID: 16561
		internal AdventureType type;
	}

	// Token: 0x02000C81 RID: 3201
	[CompilerGenerated]
	private sealed class <HideLocationDetails>c__AnonStorey7
	{
		// Token: 0x06005312 RID: 21266 RVA: 0x000A723F File Offset: 0x000A563F
		public <HideLocationDetails>c__AnonStorey7()
		{
		}

		// Token: 0x06005313 RID: 21267 RVA: 0x000A7247 File Offset: 0x000A5647
		internal bool <>m__0(ChessItemController c)
		{
			return c.AdventureType == this.type;
		}

		// Token: 0x040040B2 RID: 16562
		internal AdventureType type;
	}

	// Token: 0x02000C82 RID: 3202
	[CompilerGenerated]
	private sealed class <SelectMap>c__AnonStorey8
	{
		// Token: 0x06005314 RID: 21268 RVA: 0x000A7257 File Offset: 0x000A5657
		public <SelectMap>c__AnonStorey8()
		{
		}

		// Token: 0x06005315 RID: 21269 RVA: 0x000A725F File Offset: 0x000A565F
		internal bool <>m__0(ChessItemController c)
		{
			return c.AdventureType == this.type;
		}

		// Token: 0x040040B3 RID: 16563
		internal AdventureType type;
	}

	// Token: 0x02000C83 RID: 3203
	[CompilerGenerated]
	private sealed class <ClearSeleted>c__AnonStorey9
	{
		// Token: 0x06005316 RID: 21270 RVA: 0x000A726F File Offset: 0x000A566F
		public <ClearSeleted>c__AnonStorey9()
		{
		}

		// Token: 0x06005317 RID: 21271 RVA: 0x000A7277 File Offset: 0x000A5677
		internal bool <>m__0(ChessItemController c)
		{
			return c.AdventureType == this.dungeonRecord.AdventureType;
		}

		// Token: 0x040040B4 RID: 16564
		internal DungeonRecord dungeonRecord;
	}
}
