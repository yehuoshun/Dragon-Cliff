using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001F8 RID: 504
public class LogTextController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IItemControl, IEventSystemHandler
{
	// Token: 0x06000D55 RID: 3413 RVA: 0x0008E197 File Offset: 0x0008C597
	public LogTextController()
	{
	}

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x06000D56 RID: 3414 RVA: 0x0008E19F File Offset: 0x0008C59F
	// (set) Token: 0x06000D57 RID: 3415 RVA: 0x0008E1A7 File Offset: 0x0008C5A7
	public LogTexts MyTexts
	{
		[CompilerGenerated]
		get
		{
			return this.<MyTexts>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MyTexts>k__BackingField = value;
		}
	}

	// Token: 0x06000D58 RID: 3416 RVA: 0x0008E1B0 File Offset: 0x0008C5B0
	public void Init(LogTexts texts)
	{
		this.MyTexts = texts;
		string text = string.Empty;
		List<LogText> texts2 = texts.Texts;
		for (int i = 0; i < texts2.Count; i++)
		{
			string text2 = string.Empty;
			text2 = texts2[i].Text;
			text2 = ColorPicker.GetHaxString(texts2[i].TextColor, text2);
			text2 = string.Concat(new object[]
			{
				"<link=",
				i,
				">",
				text2,
				"</link>"
			});
			text = text + " " + text2;
		}
		this.Text.text = text;
	}

	// Token: 0x06000D59 RID: 3417 RVA: 0x0008E258 File Offset: 0x0008C658
	private void Update()
	{
		if (this._isHovering)
		{
			int hoverLinkId = this.GetHoverLinkId();
			if (hoverLinkId != -1)
			{
				LogTextType textType = this.MyTexts.Texts[hoverLinkId].TextType;
				if (textType == LogTextType.Item)
				{
					this.DisplayItemTooltip();
				}
			}
		}
	}

	// Token: 0x06000D5A RID: 3418 RVA: 0x0008E2AC File Offset: 0x0008C6AC
	private void DisplayItemTooltip()
	{
		LogText logText = this.MyTexts.Texts.FirstOrDefault((LogText t) => t.TextType == LogTextType.Item);
		NormalItem normalItem = null;
		if (logText != null)
		{
			normalItem = (logText.RelatedObject as NormalItem);
		}
		if (normalItem != null)
		{
			this.OpenTooltip(this.GetItemTooltip(normalItem), null, TooltipPosition.None, 0f, 0f);
		}
	}

	// Token: 0x06000D5B RID: 3419 RVA: 0x0008E31A File Offset: 0x0008C71A
	public void OnPointerEnter(PointerEventData eventData)
	{
		this._isHovering = true;
	}

	// Token: 0x06000D5C RID: 3420 RVA: 0x0008E323 File Offset: 0x0008C723
	public void OnPointerExit(PointerEventData eventData)
	{
		this._isHovering = false;
		this.CloseTooltip();
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x0008E334 File Offset: 0x0008C734
	public void OnPointerClick(PointerEventData eventData)
	{
		int hoverLinkId = this.GetHoverLinkId();
		if (hoverLinkId != -1)
		{
			switch (this.MyTexts.Texts[hoverLinkId].TextType)
			{
			case LogTextType.CompleteQuest:
				this.CompleteQuest();
				break;
			case LogTextType.NewQuest:
				this.ShowNewQuest();
				break;
			case LogTextType.ShopRefreshed:
				TownManager.Instance.Ui.OpenMyShopMenu();
				break;
			case LogTextType.RecruitmentRefreshed:
				TownManager.Instance.Ui.OpenRecritmentMenu();
				break;
			case LogTextType.ResidentCandidateRefreshed:
				TownManager.Instance.Ui.OpenResidentMenu();
				break;
			}
		}
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x0008E3EC File Offset: 0x0008C7EC
	private int GetHoverLinkId()
	{
		int num = TMP_TextUtilities.FindIntersectingLink(this.Text, Input.mousePosition, Camera.current);
		if (num != -1)
		{
			string linkID = this.Text.textInfo.linkInfo[num].GetLinkID();
			return int.Parse(linkID);
		}
		return -1;
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x0008E43C File Offset: 0x0008C83C
	public void UpdateText(LogText text)
	{
		int num = this.MyTexts.Texts.IndexOf(text);
		if (num >= 0)
		{
			this.MyTexts.Texts[num] = text;
			this.Init(this.MyTexts);
		}
	}

	// Token: 0x06000D60 RID: 3424 RVA: 0x0008E480 File Offset: 0x0008C880
	private void ShowNewQuest()
	{
		LogText logText = this.MyTexts.Texts.FirstOrDefault((LogText t) => t.TextType == LogTextType.NewQuest);
		if (logText != null)
		{
			PageQuest pageQuest = logText.RelatedObject as PageQuest;
			if (pageQuest != null)
			{
				if (!pageQuest.Quest.Completed && !pageQuest.Quest.HasExpired())
				{
					TownManager.Instance.Ui.OpenQuestMenu();
					TownManager.Instance.Ui.QuestMenu.SelecteQuest(pageQuest);
				}
				else
				{
					this.DisplayWarningText(UIComponentType.QuestExpiredOrCompletedWarning.GetName());
				}
			}
		}
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x0008E52C File Offset: 0x0008C92C
	private void CompleteQuest()
	{
		LogText logText = this.MyTexts.Texts.FirstOrDefault((LogText t) => t.TextType == LogTextType.CompleteQuest);
		if (logText != null)
		{
			Quest quest = logText.RelatedObject as Quest;
			if (quest != null)
			{
				GameWorld.instance.PlayerProfile.CompleteQuest(quest);
			}
		}
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x0008E58F File Offset: 0x0008C98F
	[CompilerGenerated]
	private static bool <DisplayItemTooltip>m__0(LogText t)
	{
		return t.TextType == LogTextType.Item;
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x0008E59A File Offset: 0x0008C99A
	[CompilerGenerated]
	private static bool <ShowNewQuest>m__1(LogText t)
	{
		return t.TextType == LogTextType.NewQuest;
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x0008E5A5 File Offset: 0x0008C9A5
	[CompilerGenerated]
	private static bool <CompleteQuest>m__2(LogText t)
	{
		return t.TextType == LogTextType.CompleteQuest;
	}

	// Token: 0x04000F5F RID: 3935
	public TextMeshProUGUI Text;

	// Token: 0x04000F60 RID: 3936
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LogTexts <MyTexts>k__BackingField;

	// Token: 0x04000F61 RID: 3937
	private bool _isHovering;

	// Token: 0x04000F62 RID: 3938
	[CompilerGenerated]
	private static Func<LogText, bool> <>f__am$cache0;

	// Token: 0x04000F63 RID: 3939
	[CompilerGenerated]
	private static Func<LogText, bool> <>f__am$cache1;

	// Token: 0x04000F64 RID: 3940
	[CompilerGenerated]
	private static Func<LogText, bool> <>f__am$cache2;
}
