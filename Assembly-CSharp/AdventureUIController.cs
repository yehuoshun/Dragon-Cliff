using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000356 RID: 854
public class AdventureUIController : MonoBehaviour
{
	// Token: 0x060016C0 RID: 5824 RVA: 0x000B2B65 File Offset: 0x000B0F65
	public AdventureUIController()
	{
	}

	// Token: 0x060016C1 RID: 5825 RVA: 0x000B2B70 File Offset: 0x000B0F70
	private void Start()
	{
		this.SetAdventureLayoutStatus(false);
		this.NewHeroesPanelObj.SetActive(false);
		foreach (AdventurerInBattleAsCardController adventurerInBattleAsCardController in this.NewHeroesPanel.AdventurerInBattleAsCardControllers)
		{
			adventurerInBattleAsCardController.gameObject.SetActive(false);
		}
		SceneManager.sceneLoaded += this.SceneManager_sceneLoaded;
	}

	// Token: 0x060016C2 RID: 5826 RVA: 0x000B2BD1 File Offset: 0x000B0FD1
	private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		this.SpeedBarMat.Reset();
	}

	// Token: 0x060016C3 RID: 5827 RVA: 0x000B2BDE File Offset: 0x000B0FDE
	private void OnApplicationQuit()
	{
		this.SpeedBarMat.Reset();
	}

	// Token: 0x060016C4 RID: 5828 RVA: 0x000B2BEC File Offset: 0x000B0FEC
	private void Update()
	{
		if (this._currentAdventure != null && this._currentAdventure.TimeLeft() != null)
		{
			this.TimerObj.gameObject.SetActive(true);
			this.AdventureTimer.text = this._currentAdventure.TimeLeft().Value.DoubleToString();
			this.AdventureTimer.color = ((!(this._currentAdventure.ActionCountPossible < 50.0)) ? ColorPicker.QuestCompletedColor : ColorPicker.NagetiveRed);
		}
		else
		{
			this.TimerObj.gameObject.SetActive(false);
		}
		if (this._currentAdventure != null && this._currentAdventure.RunePower != null)
		{
			this.RunePowerPanel.UpdateRuneValues(this._currentAdventure.RunePower);
		}
	}

	// Token: 0x060016C5 RID: 5829 RVA: 0x000B2CE3 File Offset: 0x000B10E3
	public void EnableEscapeButton()
	{
		this.PulloutButton.interactable = true;
	}

	// Token: 0x060016C6 RID: 5830 RVA: 0x000B2CF1 File Offset: 0x000B10F1
	public void DisableEscapeButton()
	{
		this.PulloutButton.interactable = false;
	}

	// Token: 0x060016C7 RID: 5831 RVA: 0x000B2CFF File Offset: 0x000B10FF
	public void ShowBossSkillBar(ISpecialEffectDataLoad effect)
	{
		this.BossSkillBar.Init(effect);
		this.BossSkillBar.gameObject.SetActive(true);
	}

	// Token: 0x060016C8 RID: 5832 RVA: 0x000B2D1E File Offset: 0x000B111E
	public void HideBossSkillBar()
	{
		if (this.BossSkillBar.gameObject.activeSelf)
		{
			this.BossSkillBar.Hide();
			this.BossSkillBar.gameObject.SetActive(false);
		}
	}

	// Token: 0x060016C9 RID: 5833 RVA: 0x000B2D51 File Offset: 0x000B1151
	public void UpdateBossSkillBar(double charge)
	{
		this.BossSkillBar.UpdateChargeBar(charge);
	}

	// Token: 0x060016CA RID: 5834 RVA: 0x000B2D5F File Offset: 0x000B115F
	public void ShowChooseTargetNotifyText()
	{
		this.ChooseTargeNotifyText.SetActive(true);
	}

	// Token: 0x060016CB RID: 5835 RVA: 0x000B2D6D File Offset: 0x000B116D
	public void HideChooseTargetNotifyText()
	{
		this.ChooseTargeNotifyText.SetActive(false);
	}

	// Token: 0x060016CC RID: 5836 RVA: 0x000B2D7B File Offset: 0x000B117B
	public void PreEscape()
	{
		this.EscapeComfirmPanel.gameObject.SetActive(true);
	}

	// Token: 0x060016CD RID: 5837 RVA: 0x000B2D90 File Offset: 0x000B1190
	public void Escape()
	{
		if (!BattleManager.instance.RewardPanel.gameObject.activeSelf)
		{
			this.InProgress(UIComponentType.EscapeInProgressText.GetName());
			if (!this._pulloutInprogress)
			{
				this._pulloutInprogress = true;
				BattleManager.instance.PullBackClicked();
				IEnumerator enumerator = GameWorld.instance.GetCurrentAdventure().PullOff().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
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
				this._pulloutInprogress = false;
			}
		}
		this.EscapeComfirmPanel.gameObject.SetActive(false);
	}

	// Token: 0x060016CE RID: 5838 RVA: 0x000B2E50 File Offset: 0x000B1250
	public void UpdateAdventurersSpecialEffects(List<ISpecialEffectDataLoad> adventuerS)
	{
		if (adventuerS.Count <= 0)
		{
			return;
		}
		this.AdventurerSpecialEffects.Init(adventuerS);
		this.AdventurerSpecialEffects.gameObject.SetActive(true);
	}

	// Token: 0x060016CF RID: 5839 RVA: 0x000B2E7C File Offset: 0x000B127C
	public void UpdateEnviromentSpecialEffects(List<ISpecialEffectDataLoad> enviromentS)
	{
		if (enviromentS.Count <= 0)
		{
			return;
		}
		this.EnviromentSpecialEffects.Init(enviromentS);
		this.EnviromentSpecialEffects.gameObject.SetActive(true);
	}

	// Token: 0x060016D0 RID: 5840 RVA: 0x000B2EA8 File Offset: 0x000B12A8
	public void UpdateBossSpecialEffects(List<ISpecialEffectDataLoad> bossS)
	{
		if (bossS.Count <= 0)
		{
			return;
		}
		this.BossSpecialEffects.Init(bossS);
		this.BossSpecialEffects.gameObject.SetActive(true);
	}

	// Token: 0x060016D1 RID: 5841 RVA: 0x000B2ED4 File Offset: 0x000B12D4
	public void HideAdventurersSpecialEffects()
	{
		this.AdventurerSpecialEffects.gameObject.SetActive(false);
	}

	// Token: 0x060016D2 RID: 5842 RVA: 0x000B2EE7 File Offset: 0x000B12E7
	public void HideEnviromentSpecialEffects()
	{
		this.EnviromentSpecialEffects.gameObject.SetActive(false);
	}

	// Token: 0x060016D3 RID: 5843 RVA: 0x000B2EFA File Offset: 0x000B12FA
	public void HideBossSpecialEffects()
	{
		this.BossSpecialEffects.gameObject.SetActive(false);
	}

	// Token: 0x060016D4 RID: 5844 RVA: 0x000B2F0D File Offset: 0x000B130D
	private void SetAdventureLayoutStatus(bool active)
	{
		this.AdventureSection.SetActive(active);
	}

	// Token: 0x060016D5 RID: 5845 RVA: 0x000B2F1C File Offset: 0x000B131C
	public void SetAdventure(Adventure adventure)
	{
		this._currentAdventure = adventure;
		this.NewHeroesPanel.SetAdventure(adventure);
		this.RunePowerPanel.Init(this._currentAdventure);
		if (this.AdventureLevel != null)
		{
			this.AdventureLevel.text = UIComponentType.WorldMapLevelText.GetName().ReplaceToBuilder(UIComponentKey.NumberOfLevel, adventure.LevelNumber.ToString()).ToString();
		}
		this.SetAdventureLayoutStatus(true);
		if (this._currentAdventure.AutoTacticRules != null && this._currentAdventure.AutoTacticRules.Count > 0)
		{
			this.PauseAutoTacticPanel.Init(this._currentAdventure);
			this.PauseAutoTacticPanel.gameObject.SetActive(true);
		}
		else
		{
			this.PauseAutoTacticPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060016D6 RID: 5846 RVA: 0x000B2FF8 File Offset: 0x000B13F8
	public void InitNewAdventure(Adventure adventure)
	{
		this.BattleLogPanel.InitAdventurerDamageBoard(adventure);
	}

	// Token: 0x060016D7 RID: 5847 RVA: 0x000B3006 File Offset: 0x000B1406
	public void SetUpListener(BattleEncounter encounter)
	{
		this.NewHeroesPanel.SetUpListener(encounter);
		encounter.Log.LogAdded += this.Log_LogAdded;
		this.SettingInWalkingAdventurerUIStatus(true);
	}

	// Token: 0x060016D8 RID: 5848 RVA: 0x000B3032 File Offset: 0x000B1432
	private void Log_LogAdded(string obj)
	{
		this.BattleLogPanel.AddLogText(obj);
	}

	// Token: 0x060016D9 RID: 5849 RVA: 0x000B3040 File Offset: 0x000B1440
	private void SettingInWalkingAdventurerUIStatus(bool active)
	{
		this.NewHeroesPanelObj.SetActive(active);
		this.AdventureSpeedIndicator.SetActive(active);
		this.PlayerGauge.SetActive(active);
		this.SkillInfoTextObj.SetActive(active);
	}

	// Token: 0x060016DA RID: 5850 RVA: 0x000B3072 File Offset: 0x000B1472
	public void LeavesEncouter()
	{
		this.NewHeroesPanel.LeavesEncounter();
		this.SettingInWalkingAdventurerUIStatus(false);
		this.HideBossSpecialEffects();
		this.SpeedBarMat.Reset();
		if (!TownManager.Instance.Ui.IsInTown)
		{
			this.CloseTooltip();
		}
	}

	// Token: 0x060016DB RID: 5851 RVA: 0x000B30B1 File Offset: 0x000B14B1
	public void ViewBattle()
	{
		this.SetAdventureLayoutStatus(true);
	}

	// Token: 0x060016DC RID: 5852 RVA: 0x000B30BA File Offset: 0x000B14BA
	public void ViewTown()
	{
		this.SetAdventureLayoutStatus(false);
	}

	// Token: 0x060016DD RID: 5853 RVA: 0x000B30C3 File Offset: 0x000B14C3
	public void AdventurerFinished()
	{
		this._currentAdventure = null;
		this.RunePowerPanel.Hide();
		this.NewHeroesPanel.AdventureFinished();
		this.SetAdventureLayoutStatus(false);
	}

	// Token: 0x040016CD RID: 5837
	public TextMeshProUGUI AdventureLevel;

	// Token: 0x040016CE RID: 5838
	public GameObject TimerObj;

	// Token: 0x040016CF RID: 5839
	public TextMeshProUGUI AdventureTimer;

	// Token: 0x040016D0 RID: 5840
	public NewHeroInBattleInfoController NewHeroesPanel;

	// Token: 0x040016D1 RID: 5841
	public GameObject NewHeroesPanelObj;

	// Token: 0x040016D2 RID: 5842
	public Button PulloutButton;

	// Token: 0x040016D3 RID: 5843
	public GameObject AdventureSpeedIndicator;

	// Token: 0x040016D4 RID: 5844
	public GameObject AdventureSection;

	// Token: 0x040016D5 RID: 5845
	public GameObject PlayerGauge;

	// Token: 0x040016D6 RID: 5846
	public GameObject SkillInfoTextObj;

	// Token: 0x040016D7 RID: 5847
	public PauseAutoTacticPanelController PauseAutoTacticPanel;

	// Token: 0x040016D8 RID: 5848
	public SpecialEffectsController AdventurerSpecialEffects;

	// Token: 0x040016D9 RID: 5849
	public SpecialEffectsController EnviromentSpecialEffects;

	// Token: 0x040016DA RID: 5850
	public SpecialEffectsController BossSpecialEffects;

	// Token: 0x040016DB RID: 5851
	public BossSkillBarController BossSkillBar;

	// Token: 0x040016DC RID: 5852
	public EscapeComfirmPanelController EscapeComfirmPanel;

	// Token: 0x040016DD RID: 5853
	public BattleLogPanelController BattleLogPanel;

	// Token: 0x040016DE RID: 5854
	public SpeedBarMovingController SpeedBarMat;

	// Token: 0x040016DF RID: 5855
	public RunePowerPanelController RunePowerPanel;

	// Token: 0x040016E0 RID: 5856
	public GameObject ChooseTargeNotifyText;

	// Token: 0x040016E1 RID: 5857
	private bool _pulloutInprogress;

	// Token: 0x040016E2 RID: 5858
	private Adventure _currentAdventure;
}
