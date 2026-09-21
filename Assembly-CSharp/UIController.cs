using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x02000297 RID: 663
public class UIController : MonoBehaviour
{
	// Token: 0x060011A1 RID: 4513 RVA: 0x0009BDD4 File Offset: 0x0009A1D4
	public UIController()
	{
	}

	// Token: 0x060011A2 RID: 4514 RVA: 0x0009BE22 File Offset: 0x0009A222
	private void Start()
	{
		this.HealthBars = new List<GameObject>();
		this.MainCamera.gameObject.SetActive(true);
		this.BattleCamera.gameObject.SetActive(false);
	}

	// Token: 0x060011A3 RID: 4515 RVA: 0x0009BE54 File Offset: 0x0009A254
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (this.IsAnyLogMenuOpened())
			{
				this.CloseOpeningLogMenu();
			}
			else if (this.IsAnyMenuOpened())
			{
				this.CloseOpeningMenu();
			}
			else if (this.SettingPanel.gameObject.activeSelf)
			{
				this.CloseSettingPanel();
			}
			else
			{
				this.OpenSettingPanel();
			}
		}
		if (Input.GetKeyUp(KeyCode.Tab))
		{
			if (this.BattleCamera.gameObject.activeSelf)
			{
				this.ShowTown();
			}
			else
			{
				this.ToggleWorldMap();
			}
			this.CloseTooltip();
			this.CloseDescriptionTooltip();
		}
	}

	// Token: 0x060011A4 RID: 4516 RVA: 0x0009BEFD File Offset: 0x0009A2FD
	public bool IsUsingInput()
	{
		bool result;
		if (!this.KeyboardSettingPanel.activeSelf)
		{
			result = this.Inputs.Any((TMP_InputField i) => i.isFocused);
		}
		else
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060011A5 RID: 4517 RVA: 0x0009BF3C File Offset: 0x0009A33C
	public bool CanUseHotKey()
	{
		bool result;
		if (!this.KeyboardSettingPanel.activeSelf)
		{
			result = (this.Inputs.All((TMP_InputField i) => !i.isFocused) && this.IsInTown);
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060011A6 RID: 4518 RVA: 0x0009BF92 File Offset: 0x0009A392
	private void CloseOpeningMenu()
	{
		this.OpenMenu(MainMenu.None);
		this.CloseTooltip();
		this.CloseDescriptionTooltip();
	}

	// Token: 0x060011A7 RID: 4519 RVA: 0x0009BFA8 File Offset: 0x0009A3A8
	private bool IsAnyMenuOpened()
	{
		return this.ResidentMenu.gameObject.activeSelf || this.HeroMenu.gameObject.activeSelf || this.QuestMenu.gameObject.activeSelf || this.TownEventMenu.gameObject.activeSelf || this.RecruitmentMenu.gameObject.activeSelf || this.WeaponShopMenu.gameObject.activeSelf || this.ArmorShopMenu.gameObject.activeSelf || this.MyShopMenu.gameObject.activeSelf || this.BuildShipMenu.gameObject.activeSelf || this.ShipMenu.gameObject.activeSelf || this.FurnaceMenu.gameObject.activeSelf || this.SchoolMenu.gameObject.activeSelf || this.WorldMap.gameObject.activeSelf;
	}

	// Token: 0x060011A8 RID: 4520 RVA: 0x0009C0C4 File Offset: 0x0009A4C4
	private void CloseOpeningLogMenu()
	{
		this.OpenLogMenu(LogMenu.None);
		this.CloseTooltip();
		this.CloseDescriptionTooltip();
	}

	// Token: 0x060011A9 RID: 4521 RVA: 0x0009C0DC File Offset: 0x0009A4DC
	private bool IsAnyLogMenuOpened()
	{
		return this.ManualMenu.gameObject.activeSelf || this.GemLogPanel.activeSelf || this.SpecialEffectLogPanel.activeSelf || this.HeroLogPanel.activeSelf;
	}

	// Token: 0x060011AA RID: 4522 RVA: 0x0009C12C File Offset: 0x0009A52C
	public void ShowMainUi(bool show)
	{
		this.MainUi.GetComponent<CanvasGroup>().SetUiActive(show);
	}

	// Token: 0x060011AB RID: 4523 RVA: 0x0009C140 File Offset: 0x0009A540
	public void OpenMenu(MainMenu menu)
	{
		this.HeroMenu.gameObject.SetActive(menu == MainMenu.HeroMenu);
		this.ResidentMenu.gameObject.SetActive(menu == MainMenu.ResidentMenu);
		this.QuestMenu.gameObject.SetActive(menu == MainMenu.QuestMenu);
		this.TownEventMenu.gameObject.SetActive(menu == MainMenu.TownEventMenu);
		this.RecruitmentMenu.gameObject.SetActive(menu == MainMenu.RecruitmentMenu);
		this.WeaponShopMenu.gameObject.SetActive(menu == MainMenu.ShopMenu);
		this.ArmorShopMenu.gameObject.SetActive(menu == MainMenu.ArmorShopMenu);
		this.MyShopMenu.gameObject.SetActive(menu == MainMenu.MyShopMenu);
		this.BuildShipMenu.gameObject.SetActive(menu == MainMenu.BuildShipMenu);
		this.ShipMenu.gameObject.SetActive(menu == MainMenu.ShipMenu);
		this.FurnaceMenu.gameObject.SetActive(menu == MainMenu.FurnaceMenu);
		this.SchoolMenu.gameObject.SetActive(menu == MainMenu.SchoolMenu);
		this.WorldMap.gameObject.SetActive(menu == MainMenu.WorldMap);
		this.CloseTooltip();
		this.CloseDescriptionTooltip();
	}

	// Token: 0x060011AC RID: 4524 RVA: 0x0009C263 File Offset: 0x0009A663
	public void OpenKeyboardSettingPanel()
	{
		this.KeyboardSettingPanel.SetActive(true);
	}

	// Token: 0x060011AD RID: 4525 RVA: 0x0009C271 File Offset: 0x0009A671
	public void CloseKeyboardSettingPanel()
	{
		this.KeyboardSettingPanel.SetActive(false);
	}

	// Token: 0x060011AE RID: 4526 RVA: 0x0009C27F File Offset: 0x0009A67F
	public void OpenHeroLogPanel()
	{
		this.OpenLogMenu(LogMenu.HeroLog);
	}

	// Token: 0x060011AF RID: 4527 RVA: 0x0009C288 File Offset: 0x0009A688
	public void HideHeroLogPanel()
	{
		this.HeroLogPanel.SetActive(false);
	}

	// Token: 0x060011B0 RID: 4528 RVA: 0x0009C296 File Offset: 0x0009A696
	public void ToggleHeroLogPanel()
	{
		if (this.HeroLogPanel.activeSelf)
		{
			this.HideHeroLogPanel();
		}
		else
		{
			this.OpenHeroLogPanel();
		}
	}

	// Token: 0x060011B1 RID: 4529 RVA: 0x0009C2B9 File Offset: 0x0009A6B9
	public void ShowGemLogPanel()
	{
		this.OpenLogMenu(LogMenu.GemLog);
	}

	// Token: 0x060011B2 RID: 4530 RVA: 0x0009C2C2 File Offset: 0x0009A6C2
	public void HideGemLogPanel()
	{
		this.GemLogPanel.SetActive(false);
	}

	// Token: 0x060011B3 RID: 4531 RVA: 0x0009C2D0 File Offset: 0x0009A6D0
	public void ToggleGemLogPanel()
	{
		if (this.GemLogPanel.activeSelf)
		{
			this.HideGemLogPanel();
		}
		else
		{
			this.ShowGemLogPanel();
		}
	}

	// Token: 0x060011B4 RID: 4532 RVA: 0x0009C2F3 File Offset: 0x0009A6F3
	public void ShowSpecialEffectLogPanel()
	{
		this.OpenLogMenu(LogMenu.SpecialEffectLog);
	}

	// Token: 0x060011B5 RID: 4533 RVA: 0x0009C2FC File Offset: 0x0009A6FC
	public void HideSpecialEffectLogPanel()
	{
		this.SpecialEffectLogPanel.SetActive(false);
	}

	// Token: 0x060011B6 RID: 4534 RVA: 0x0009C30A File Offset: 0x0009A70A
	public void ToggleSpecialEffectPanel()
	{
		if (this.SpecialEffectLogPanel.activeSelf)
		{
			this.HideSpecialEffectLogPanel();
		}
		else
		{
			this.ShowSpecialEffectLogPanel();
		}
	}

	// Token: 0x060011B7 RID: 4535 RVA: 0x0009C330 File Offset: 0x0009A730
	private void OpenLogMenu(LogMenu menu)
	{
		this.GemLogPanel.SetActive(menu == LogMenu.GemLog);
		this.SpecialEffectLogPanel.SetActive(menu == LogMenu.SpecialEffectLog);
		this.ManualMenu.gameObject.SetActive(menu == LogMenu.Manual);
		this.HeroLogPanel.SetActive(menu == LogMenu.HeroLog);
	}

	// Token: 0x060011B8 RID: 4536 RVA: 0x0009C37E File Offset: 0x0009A77E
	public void ShowGameEndingPanel()
	{
		this.GameEndingPanel.SetActive(true);
	}

	// Token: 0x060011B9 RID: 4537 RVA: 0x0009C38C File Offset: 0x0009A78C
	public void ShowBattleTutorial()
	{
		this.BattleTutorial.SetActive(true);
	}

	// Token: 0x060011BA RID: 4538 RVA: 0x0009C39A File Offset: 0x0009A79A
	public void HideBattleTutorial()
	{
		this.BattleTutorial.SetActive(false);
	}

	// Token: 0x060011BB RID: 4539 RVA: 0x0009C3A8 File Offset: 0x0009A7A8
	public void ShowInProgressPanel(string description)
	{
		this.InProgressPanel.Init(description);
		this.InProgressPanel.gameObject.SetActive(true);
	}

	// Token: 0x060011BC RID: 4540 RVA: 0x0009C3C7 File Offset: 0x0009A7C7
	public void HideInProgressPanel()
	{
		this.InProgressPanel.gameObject.SetActive(false);
	}

	// Token: 0x060011BD RID: 4541 RVA: 0x0009C3DA File Offset: 0x0009A7DA
	public void ShowBackToBattlePanel()
	{
		this.BackToBattlePanel.gameObject.SetActive(true);
	}

	// Token: 0x060011BE RID: 4542 RVA: 0x0009C3ED File Offset: 0x0009A7ED
	public void HideBackToBattlePanel()
	{
		this.BackToBattlePanel.gameObject.SetActive(false);
	}

	// Token: 0x060011BF RID: 4543 RVA: 0x0009C400 File Offset: 0x0009A800
	public void AddNewAdventurerDialog(AdventurerSpeaksEvent speakEvent)
	{
		this.AdventurerDialogPanel.NewDialog(speakEvent);
	}

	// Token: 0x060011C0 RID: 4544 RVA: 0x0009C40E File Offset: 0x0009A80E
	public void ToggleQuestList()
	{
		if (this.QuestBriefPanel.activeSelf)
		{
			this.CloseQuestList();
		}
		else
		{
			this.OpenQuestList();
		}
	}

	// Token: 0x060011C1 RID: 4545 RVA: 0x0009C431 File Offset: 0x0009A831
	public void OpenQuestList()
	{
		this.QuestBriefPanel.SetActive(true);
	}

	// Token: 0x060011C2 RID: 4546 RVA: 0x0009C43F File Offset: 0x0009A83F
	public void CloseQuestList()
	{
		this.QuestBriefPanel.SetActive(false);
	}

	// Token: 0x060011C3 RID: 4547 RVA: 0x0009C44D File Offset: 0x0009A84D
	public void OpenManualMenu()
	{
		this.OpenLogMenu(LogMenu.Manual);
	}

	// Token: 0x060011C4 RID: 4548 RVA: 0x0009C456 File Offset: 0x0009A856
	public void CloseManualMenu()
	{
		this.ManualMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011C5 RID: 4549 RVA: 0x0009C469 File Offset: 0x0009A869
	public void ToggleMenualMenu()
	{
		if (this.ManualMenu.gameObject.activeSelf)
		{
			this.CloseManualMenu();
		}
		else
		{
			this.OpenManualMenu();
		}
	}

	// Token: 0x060011C6 RID: 4550 RVA: 0x0009C491 File Offset: 0x0009A891
	public void OpenSettingPanel()
	{
		this.SettingPanel.gameObject.SetActive(true);
	}

	// Token: 0x060011C7 RID: 4551 RVA: 0x0009C4A4 File Offset: 0x0009A8A4
	public void CloseSettingPanel()
	{
		this.SettingPanel.gameObject.SetActive(false);
	}

	// Token: 0x060011C8 RID: 4552 RVA: 0x0009C4B7 File Offset: 0x0009A8B7
	public void OpenPreviewBar()
	{
		this.PreviewBar.gameObject.SetActive(true);
	}

	// Token: 0x060011C9 RID: 4553 RVA: 0x0009C4CA File Offset: 0x0009A8CA
	public void ClosePreviewBar()
	{
		this.PreviewBar.gameObject.SetActive(false);
	}

	// Token: 0x060011CA RID: 4554 RVA: 0x0009C4DD File Offset: 0x0009A8DD
	public void OpenRecritmentMenu()
	{
		this.OpenMenu(MainMenu.RecruitmentMenu);
	}

	// Token: 0x060011CB RID: 4555 RVA: 0x0009C4E6 File Offset: 0x0009A8E6
	public void CloseRecritmentMenu()
	{
		this.RecruitmentMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011CC RID: 4556 RVA: 0x0009C4F9 File Offset: 0x0009A8F9
	public void OpenResourceMenu()
	{
		this.ResourceMenu.gameObject.SetActive(true);
	}

	// Token: 0x060011CD RID: 4557 RVA: 0x0009C50C File Offset: 0x0009A90C
	public void CloseResourceMenu()
	{
		this.ResourceMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011CE RID: 4558 RVA: 0x0009C51F File Offset: 0x0009A91F
	public void ToggleResourceMenu()
	{
		if (this.ResourceMenu.gameObject.activeSelf)
		{
			this.CloseResourceMenu();
		}
		else
		{
			this.OpenResourceMenu();
		}
	}

	// Token: 0x060011CF RID: 4559 RVA: 0x0009C547 File Offset: 0x0009A947
	public void OpenMyShopMenu()
	{
		this.OpenMenu(MainMenu.MyShopMenu);
	}

	// Token: 0x060011D0 RID: 4560 RVA: 0x0009C551 File Offset: 0x0009A951
	public void CloseMyShopMenu()
	{
		this.MyShopMenu.Close();
		this.MyShopMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011D1 RID: 4561 RVA: 0x0009C56F File Offset: 0x0009A96F
	public void OpenShipMenu()
	{
		this.OpenMenu(MainMenu.ShipMenu);
	}

	// Token: 0x060011D2 RID: 4562 RVA: 0x0009C579 File Offset: 0x0009A979
	public void CloseShipMenu()
	{
		this.ShipMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011D3 RID: 4563 RVA: 0x0009C58C File Offset: 0x0009A98C
	public void ToggleShipMenu()
	{
		if (this.ShipMenu.gameObject.activeSelf)
		{
			this.CloseShipMenu();
		}
		else
		{
			this.OpenShipMenu();
		}
	}

	// Token: 0x060011D4 RID: 4564 RVA: 0x0009C5B4 File Offset: 0x0009A9B4
	public void OpenBuildShipMenu()
	{
		this.OpenMenu(MainMenu.BuildShipMenu);
	}

	// Token: 0x060011D5 RID: 4565 RVA: 0x0009C5BE File Offset: 0x0009A9BE
	public void CloseBuildShipMenu()
	{
		this.BuildShipMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011D6 RID: 4566 RVA: 0x0009C5D1 File Offset: 0x0009A9D1
	public void ToggleBuildShipMenu()
	{
		if (this.BuildShipMenu.gameObject.activeSelf)
		{
			this.CloseBuildShipMenu();
		}
		else
		{
			this.OpenBuildShipMenu();
		}
	}

	// Token: 0x060011D7 RID: 4567 RVA: 0x0009C5F9 File Offset: 0x0009A9F9
	public void OpenFurnaceMenu()
	{
		this.OpenMenu(MainMenu.FurnaceMenu);
	}

	// Token: 0x060011D8 RID: 4568 RVA: 0x0009C603 File Offset: 0x0009AA03
	public void CloseFurnaceMenu()
	{
		this.FurnaceMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011D9 RID: 4569 RVA: 0x0009C616 File Offset: 0x0009AA16
	public void OpenSchoolMenu()
	{
		this.OpenMenu(MainMenu.SchoolMenu);
	}

	// Token: 0x060011DA RID: 4570 RVA: 0x0009C61F File Offset: 0x0009AA1F
	public void CloseSchoolMenu()
	{
		this.SchoolMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011DB RID: 4571 RVA: 0x0009C632 File Offset: 0x0009AA32
	public void OpenWorldMap()
	{
		this.OpenMenu(MainMenu.WorldMap);
	}

	// Token: 0x060011DC RID: 4572 RVA: 0x0009C63B File Offset: 0x0009AA3B
	public void CloseWorldMap()
	{
		this.WorldMap.gameObject.SetActive(false);
	}

	// Token: 0x060011DD RID: 4573 RVA: 0x0009C650 File Offset: 0x0009AA50
	public void ToggleWorldMap()
	{
		if (BattleManager.instance.IsInCombat || BattleManager.instance.BattleStarted)
		{
			this.ShowBattle();
			UIMiscGenerator.Instance.ClearHealthDetails();
		}
		else if (this.WorldMap.gameObject.activeSelf)
		{
			this.CloseWorldMap();
		}
		else
		{
			this.OpenWorldMap();
		}
	}

	// Token: 0x060011DE RID: 4574 RVA: 0x0009C6B6 File Offset: 0x0009AAB6
	public void OpenWeaponShopMenu()
	{
		this.WeaponShopMenu.ItemRequirementController.UpdateAmount();
		this.OpenMenu(MainMenu.ShopMenu);
	}

	// Token: 0x060011DF RID: 4575 RVA: 0x0009C6CF File Offset: 0x0009AACF
	public void CloseWeaponShopMenu()
	{
		this.WeaponShopMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011E0 RID: 4576 RVA: 0x0009C6E2 File Offset: 0x0009AAE2
	public void OpenArmorShopMenu()
	{
		this.ArmorShopMenu.ItemRequirementController.UpdateAmount();
		this.OpenMenu(MainMenu.ArmorShopMenu);
	}

	// Token: 0x060011E1 RID: 4577 RVA: 0x0009C6FB File Offset: 0x0009AAFB
	public void CloseArmorShopMenu()
	{
		this.ArmorShopMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011E2 RID: 4578 RVA: 0x0009C70E File Offset: 0x0009AB0E
	public void OpenCasinoMenu()
	{
		this.OpenMenu(MainMenu.CasinoMenu);
	}

	// Token: 0x060011E3 RID: 4579 RVA: 0x0009C717 File Offset: 0x0009AB17
	public void OpenQuestMenu()
	{
		this.OpenMenu(MainMenu.QuestMenu);
	}

	// Token: 0x060011E4 RID: 4580 RVA: 0x0009C721 File Offset: 0x0009AB21
	public void CloseQuestMenu()
	{
		this.QuestMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011E5 RID: 4581 RVA: 0x0009C734 File Offset: 0x0009AB34
	public void ToggleQuestMenu()
	{
		if (this.QuestMenu.gameObject.activeSelf)
		{
			this.CloseQuestMenu();
		}
		else
		{
			this.OpenQuestMenu();
		}
	}

	// Token: 0x060011E6 RID: 4582 RVA: 0x0009C75C File Offset: 0x0009AB5C
	public void OpenTownEventMenu()
	{
		this.OpenMenu(MainMenu.TownEventMenu);
	}

	// Token: 0x060011E7 RID: 4583 RVA: 0x0009C766 File Offset: 0x0009AB66
	public void CloseTownEventMenu()
	{
		this.TownEventMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011E8 RID: 4584 RVA: 0x0009C779 File Offset: 0x0009AB79
	public void ToggleTownEventMenu()
	{
		if (this.TownEventMenu.gameObject.activeSelf)
		{
			this.CloseTownEventMenu();
		}
		else
		{
			this.OpenTownEventMenu();
		}
	}

	// Token: 0x060011E9 RID: 4585 RVA: 0x0009C7A1 File Offset: 0x0009ABA1
	public void OpenResidentMenu()
	{
		this.OpenMenu(MainMenu.ResidentMenu);
	}

	// Token: 0x060011EA RID: 4586 RVA: 0x0009C7AA File Offset: 0x0009ABAA
	public void CloseResidentMenu()
	{
		this.ResidentMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011EB RID: 4587 RVA: 0x0009C7BD File Offset: 0x0009ABBD
	public void ToggleVisitorMenu()
	{
		if (this.ResidentMenu.gameObject.activeSelf)
		{
			this.CloseResidentMenu();
		}
		else
		{
			this.OpenResidentMenu();
		}
	}

	// Token: 0x060011EC RID: 4588 RVA: 0x0009C7E5 File Offset: 0x0009ABE5
	public void OpenHeroMenu()
	{
		this.OpenMenu(MainMenu.HeroMenu);
	}

	// Token: 0x060011ED RID: 4589 RVA: 0x0009C7EE File Offset: 0x0009ABEE
	public void CloseHeroMenu()
	{
		this.HeroMenu.gameObject.SetActive(false);
	}

	// Token: 0x060011EE RID: 4590 RVA: 0x0009C801 File Offset: 0x0009AC01
	public void ToggleHeroMenu()
	{
		if (this.HeroMenu.gameObject.activeSelf)
		{
			this.CloseHeroMenu();
		}
		else
		{
			this.OpenHeroMenu();
		}
	}

	// Token: 0x060011EF RID: 4591 RVA: 0x0009C82C File Offset: 0x0009AC2C
	public void OpenTooltip(TooltipItem item, TooltipItem secondItem = null, TooltipPosition tooltipPosition = TooltipPosition.None, float widthOffset = 0f, float heightOffset = 0f)
	{
		if (item == null)
		{
			return;
		}
		if (!this.Tooltip.gameObject.activeSelf)
		{
			this.Tooltip.gameObject.SetActive(true);
		}
		if (tooltipPosition != TooltipPosition.None)
		{
			this.Tooltip.DisplayContentInCorner(item, secondItem, tooltipPosition, widthOffset, heightOffset);
		}
		else
		{
			this.Tooltip.DisplayContent(item, secondItem);
		}
	}

	// Token: 0x060011F0 RID: 4592 RVA: 0x0009C890 File Offset: 0x0009AC90
	public void CloseTooltip()
	{
		this.Tooltip.Hide();
	}

	// Token: 0x060011F1 RID: 4593 RVA: 0x0009C89D File Offset: 0x0009AC9D
	public void OpenDescriptionTooltip(TooltipItem item)
	{
		if (item == null)
		{
			return;
		}
		this.DescriptionTooltip.gameObject.SetActive(true);
		this.DescriptionTooltip.DisplayContent(item);
	}

	// Token: 0x060011F2 RID: 4594 RVA: 0x0009C8C3 File Offset: 0x0009ACC3
	public void CloseDescriptionTooltip()
	{
		this.DescriptionTooltip.Hide();
	}

	// Token: 0x060011F3 RID: 4595 RVA: 0x0009C8D0 File Offset: 0x0009ACD0
	public void SwitchCamera()
	{
		this.BattleCamera.gameObject.SetActive(!this.BattleCamera.gameObject.activeSelf);
	}

	// Token: 0x060011F4 RID: 4596 RVA: 0x0009C8F8 File Offset: 0x0009ACF8
	public void ShowTown()
	{
		this.BattleCamera.gameObject.SetActive(false);
		this.MainCamera.gameObject.SetActive(true);
		this.IsInTown = true;
		this.UiSetActive(this.CombatUi, false);
		this.UiSetActive(this.AdventureInBattleInfoPanel.gameObject, false);
		this.UiSetActive(this.MainUi, true);
		this.HealthBars.ForEach(delegate(GameObject h)
		{
			this.UiSetActive(h, false);
		});
		GameMusicController.Instance.PlayTownMusic();
	}

	// Token: 0x060011F5 RID: 4597 RVA: 0x0009C97C File Offset: 0x0009AD7C
	public void ShowBattle()
	{
		this.BattleCamera.gameObject.SetActive(true);
		this.MainCamera.gameObject.SetActive(false);
		this.UiSetActive(this.CombatUi, true);
		this.UiSetActive(this.AdventureInBattleInfoPanel.gameObject, true);
		this.UiSetActive(this.MainUi, false);
		this.HealthBars.ForEach(delegate(GameObject h)
		{
			this.UiSetActive(h, true);
		});
		this.IsInTown = false;
		this.AdventureInBattleInfoPanel.ViewBattle();
		this.BattleCamera.GetComponent<FX_Camera>().UpdateCameraLocation(this._battleUiCamPosition, 28f);
		GameMusicController.Instance.PlayBattleMusic();
	}

	// Token: 0x060011F6 RID: 4598 RVA: 0x0009CA25 File Offset: 0x0009AE25
	public void AddHealthBar(GameObject obj)
	{
		if (!this.HealthBars.Contains(obj))
		{
			this.HealthBars.Add(obj);
		}
	}

	// Token: 0x060011F7 RID: 4599 RVA: 0x0009CA44 File Offset: 0x0009AE44
	private void UiSetActive(GameObject obj, bool enable)
	{
		obj.GetComponent<CanvasGroup>().SetUiActive(enable);
	}

	// Token: 0x060011F8 RID: 4600 RVA: 0x0009CA52 File Offset: 0x0009AE52
	public void GoToWalkingintoBattle()
	{
	}

	// Token: 0x060011F9 RID: 4601 RVA: 0x0009CA54 File Offset: 0x0009AE54
	[CompilerGenerated]
	private static bool <IsUsingInput>m__0(TMP_InputField i)
	{
		return i.isFocused;
	}

	// Token: 0x060011FA RID: 4602 RVA: 0x0009CA5C File Offset: 0x0009AE5C
	[CompilerGenerated]
	private static bool <CanUseHotKey>m__1(TMP_InputField i)
	{
		return !i.isFocused;
	}

	// Token: 0x060011FB RID: 4603 RVA: 0x0009CA67 File Offset: 0x0009AE67
	[CompilerGenerated]
	private void <ShowTown>m__2(GameObject h)
	{
		this.UiSetActive(h, false);
	}

	// Token: 0x060011FC RID: 4604 RVA: 0x0009CA71 File Offset: 0x0009AE71
	[CompilerGenerated]
	private void <ShowBattle>m__3(GameObject h)
	{
		this.UiSetActive(h, true);
	}

	// Token: 0x04001288 RID: 4744
	public Camera MainCamera;

	// Token: 0x04001289 RID: 4745
	public Camera BattleCamera;

	// Token: 0x0400128A RID: 4746
	public Canvas Canvas;

	// Token: 0x0400128B RID: 4747
	public ShopMenuController WeaponShopMenu;

	// Token: 0x0400128C RID: 4748
	public ShopMenuController ArmorShopMenu;

	// Token: 0x0400128D RID: 4749
	public HeroMenuController HeroMenu;

	// Token: 0x0400128E RID: 4750
	public ResidentMenuController ResidentMenu;

	// Token: 0x0400128F RID: 4751
	public QuestMenuController QuestMenu;

	// Token: 0x04001290 RID: 4752
	public EventMenuController TownEventMenu;

	// Token: 0x04001291 RID: 4753
	public RecruitmentMenuController RecruitmentMenu;

	// Token: 0x04001292 RID: 4754
	public InventoryMenuController InventoryMenu;

	// Token: 0x04001293 RID: 4755
	public ResourceMenuController ResourceMenu;

	// Token: 0x04001294 RID: 4756
	public MyShopMenuController MyShopMenu;

	// Token: 0x04001295 RID: 4757
	public FurnaceMenuController FurnaceMenu;

	// Token: 0x04001296 RID: 4758
	public SchoolMenuController SchoolMenu;

	// Token: 0x04001297 RID: 4759
	public WorldMapController WorldMap;

	// Token: 0x04001298 RID: 4760
	public TooltipController Tooltip;

	// Token: 0x04001299 RID: 4761
	public DescriptionTooltipController DescriptionTooltip;

	// Token: 0x0400129A RID: 4762
	public InfoPanelController InfoPanel;

	// Token: 0x0400129B RID: 4763
	public AdventurerDialogPanelController AdventurerDialogPanel;

	// Token: 0x0400129C RID: 4764
	public AdventureStoryController AdventureStory;

	// Token: 0x0400129D RID: 4765
	public CriticalAdventurerDialogController CriticalAdvneAdventurerDialog;

	// Token: 0x0400129E RID: 4766
	public AdventureDialogController AdventureDialog;

	// Token: 0x0400129F RID: 4767
	public BackToBattlePanleController BackToBattlePanel;

	// Token: 0x040012A0 RID: 4768
	public TownSettingPanelController SettingPanel;

	// Token: 0x040012A1 RID: 4769
	public InProgressPanelController InProgressPanel;

	// Token: 0x040012A2 RID: 4770
	public BoostedInfoPanelController BoostedInfoPanel;

	// Token: 0x040012A3 RID: 4771
	public TownEffectPanelController TownEffectPanel;

	// Token: 0x040012A4 RID: 4772
	public GameSpeedPanelController GameSpeedPanel;

	// Token: 0x040012A5 RID: 4773
	public BuildShipMenuController BuildShipMenu;

	// Token: 0x040012A6 RID: 4774
	public ShipMenuController ShipMenu;

	// Token: 0x040012A7 RID: 4775
	public ManualMenuController ManualMenu;

	// Token: 0x040012A8 RID: 4776
	public GameObject KeyboardSettingPanel;

	// Token: 0x040012A9 RID: 4777
	public GameObject QuestBriefPanel;

	// Token: 0x040012AA RID: 4778
	public GameObject GemLogPanel;

	// Token: 0x040012AB RID: 4779
	public GameObject SpecialEffectLogPanel;

	// Token: 0x040012AC RID: 4780
	public GameObject HeroLogPanel;

	// Token: 0x040012AD RID: 4781
	public PreviewAdventuererController PreviewBar;

	// Token: 0x040012AE RID: 4782
	public GameObject MainUi;

	// Token: 0x040012AF RID: 4783
	public GameObject CombatUi;

	// Token: 0x040012B0 RID: 4784
	public List<GameObject> HealthBars;

	// Token: 0x040012B1 RID: 4785
	public bool IsInTown = true;

	// Token: 0x040012B2 RID: 4786
	public AdventureUIController AdventureInBattleInfoPanel;

	// Token: 0x040012B3 RID: 4787
	public GameObject BattleTutorial;

	// Token: 0x040012B4 RID: 4788
	public GameObject GameEndingPanel;

	// Token: 0x040012B5 RID: 4789
	public List<TMP_InputField> Inputs;

	// Token: 0x040012B6 RID: 4790
	private readonly Vector3 _competitionCamPosition = new Vector3(-128f, -248f, -10f);

	// Token: 0x040012B7 RID: 4791
	private readonly Vector3 _battleUiCamPosition = new Vector3(-335f, 8f, -10f);

	// Token: 0x040012B8 RID: 4792
	private const float _battleAndCompetitionOrthographicSize = 28f;

	// Token: 0x040012B9 RID: 4793
	[CompilerGenerated]
	private static Func<TMP_InputField, bool> <>f__am$cache0;

	// Token: 0x040012BA RID: 4794
	[CompilerGenerated]
	private static Func<TMP_InputField, bool> <>f__am$cache1;
}
