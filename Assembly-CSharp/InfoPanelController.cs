using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000270 RID: 624
public class InfoPanelController : MonoBehaviour
{
	// Token: 0x06001017 RID: 4119 RVA: 0x00097394 File Offset: 0x00095794
	public InfoPanelController()
	{
	}

	// Token: 0x06001018 RID: 4120 RVA: 0x000973CC File Offset: 0x000957CC
	private void Awake()
	{
		this._playerProfile = GameWorld.instance.PlayerProfile;
		TownTitleType title = this._playerProfile.GetTitle();
		double reputation = this._playerProfile.GetProgress(null).Reputation;
		this.SetReputation(title, reputation);
		this._lastReputation = reputation;
		this._lastTitle = title;
	}

	// Token: 0x06001019 RID: 4121 RVA: 0x00097425 File Offset: 0x00095825
	private void SetReputation(TownTitleType title, double reputation)
	{
		this.ReputationText.text = title.GetDescription().Title;
	}

	// Token: 0x0600101A RID: 4122 RVA: 0x00097440 File Offset: 0x00095840
	public void Update()
	{
		if (Math.Abs(this._lastReputation - this._playerProfile.GetProgress(null).Reputation) > 0.0)
		{
			this.SetReputation(this._playerProfile.GetTitle(), this._playerProfile.GetProgress(null).Reputation);
			this._lastReputation = this._playerProfile.GetProgress(null).Reputation;
			TownTitleType title = this._playerProfile.GetTitle();
			string text = UIComponentType.ReputationTitleChange.GetName().ReplaceToBuilder(UIComponentKey.ReputationTitle, title.GetDescription().Title).ToString();
			if (this._lastTitle != title)
			{
				this.DisplyMovingNotification(new FlyingText
				{
					DisplyingText = text
				});
				this.AddLogTextOneLine(new LogText
				{
					Text = text
				});
				this._lastTitle = title;
			}
		}
	}

	// Token: 0x0600101B RID: 4123 RVA: 0x00097538 File Offset: 0x00095938
	public void ShowReputationTooltip()
	{
		this.ReputationDetails.gameObject.SetActive(true);
		this.ReputationDetails.Init();
	}

	// Token: 0x0600101C RID: 4124 RVA: 0x00097556 File Offset: 0x00095956
	public void ShowCompetitionRankTooltip()
	{
	}

	// Token: 0x0600101D RID: 4125 RVA: 0x00097558 File Offset: 0x00095958
	public void HideTooltip()
	{
		this.ReputationDetails.gameObject.SetActive(false);
	}

	// Token: 0x0600101E RID: 4126 RVA: 0x0009756C File Offset: 0x0009596C
	public void AddALUText(ALUTextItem item)
	{
		ALUTextController alutextController = UnityEngine.Object.Instantiate<ALUTextController>(Resources.Load<ALUTextController>(FilePath.GetInfoText(InfoTextType.ProfessionLevelUp)));
		alutextController.Item = item;
		alutextController.InfoText.text = item.Adventurer.UnitClass + " reached Lv" + item.NewLevel;
		alutextController.transform.SetParent(this.TextContainer.transform, false);
	}

	// Token: 0x0600101F RID: 4127 RVA: 0x000975D8 File Offset: 0x000959D8
	public void AddSLUText(SLUTextItem item)
	{
		SLUTextController slutextController = UnityEngine.Object.Instantiate<SLUTextController>(Resources.Load<SLUTextController>(FilePath.GetInfoText(InfoTextType.SkillLevelUp)));
		slutextController.Item = item;
		slutextController.InfoText.text = string.Concat(new object[]
		{
			item.Adventurer.UnitClass,
			"'s ",
			item.Skill.SkillType,
			" reached Lv",
			item.NewLevel
		});
		slutextController.transform.SetParent(this.TextContainer.transform, false);
	}

	// Token: 0x06001020 RID: 4128 RVA: 0x00097670 File Offset: 0x00095A70
	public void AddBattleEncounterInfoText(List<AdventurerBattleUnit> adventurerBattleUnits, BattleEncounter encounter)
	{
		Text text = UnityEngine.Object.Instantiate<Text>(Resources.Load<Text>(FilePath.GetInfoText(InfoTextType.NormalInfoBlack)));
		text.text = adventurerBattleUnits.Count + "adventurer Encounter Enemys ";
		text.transform.SetParent(this.TextContainer.transform, false);
	}

	// Token: 0x06001021 RID: 4129 RVA: 0x000976C0 File Offset: 0x00095AC0
	public void AddFailedEncouterInfo(bool isPulledOff)
	{
		Text text = UnityEngine.Object.Instantiate<Text>(Resources.Load<Text>(FilePath.GetInfoText(InfoTextType.NormalInfoBlack)));
		text.text = ((!isPulledOff) ? "Adventure faild" : "Adventure pulled off ");
		text.transform.SetParent(this.TextContainer.transform, false);
	}

	// Token: 0x06001022 RID: 4130 RVA: 0x00097710 File Offset: 0x00095B10
	public void AddSucessfulInfo()
	{
		Text text = UnityEngine.Object.Instantiate<Text>(Resources.Load<Text>(FilePath.GetInfoText(InfoTextType.NormalInfoBlack)));
		text.text = "Adventure Succeeded";
		text.transform.SetParent(this.TextContainer.transform, false);
	}

	// Token: 0x06001023 RID: 4131 RVA: 0x00097750 File Offset: 0x00095B50
	public void AddRandomInfoToPanel(string info)
	{
		Text text = UnityEngine.Object.Instantiate<Text>(Resources.Load<Text>(FilePath.GetInfoText(InfoTextType.NormalInfoBlack)));
		text.text = info;
		text.transform.SetParent(this.TextContainer.transform, false);
	}

	// Token: 0x06001024 RID: 4132 RVA: 0x0009778C File Offset: 0x00095B8C
	public void AddResourceUpdateInfo(List<ResourceUpdate> reousrUpdates)
	{
		Text text = UnityEngine.Object.Instantiate<Text>(Resources.Load<Text>(FilePath.GetInfoText(InfoTextType.ReceivedResource)));
		text.text = "Got ";
		foreach (ResourceUpdate resourceUpdate in reousrUpdates)
		{
			Text text2 = text;
			string text3 = text2.text;
			text2.text = string.Concat(new object[]
			{
				text3,
				" ",
				resourceUpdate.ChangeAmount,
				" ",
				resourceUpdate.ResourceType.GetDescription().Title
			});
		}
		if (reousrUpdates.Count == 0)
		{
			Text text4 = text;
			text4.text += " nothing";
		}
		text.transform.SetParent(this.TextContainer.transform, false);
	}

	// Token: 0x0400115D RID: 4445
	public GameObject TextContainer;

	// Token: 0x0400115E RID: 4446
	public Image RankImage;

	// Token: 0x0400115F RID: 4447
	public TextMeshProUGUI ReputationText;

	// Token: 0x04001160 RID: 4448
	public TextMeshProUGUI RankText;

	// Token: 0x04001161 RID: 4449
	public ReputationDetailsController ReputationDetails;

	// Token: 0x04001162 RID: 4450
	private double _lastReputation = -1.0;

	// Token: 0x04001163 RID: 4451
	private double _lastRank = -1.0;

	// Token: 0x04001164 RID: 4452
	private double _lastComforRate = -1.0;

	// Token: 0x04001165 RID: 4453
	private PlayerProfile _playerProfile;

	// Token: 0x04001166 RID: 4454
	private TownTitleType _lastTitle;
}
