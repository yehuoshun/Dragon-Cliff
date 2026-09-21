using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200022F RID: 559
public class QuestItemController : PageElementController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000EA1 RID: 3745 RVA: 0x0009173C File Offset: 0x0008FB3C
	public QuestItemController()
	{
	}

	// Token: 0x17000091 RID: 145
	// (get) Token: 0x06000EA2 RID: 3746 RVA: 0x00091744 File Offset: 0x0008FB44
	// (set) Token: 0x06000EA3 RID: 3747 RVA: 0x0009174C File Offset: 0x0008FB4C
	public PageQuest PageQuest
	{
		[CompilerGenerated]
		get
		{
			return this.<PageQuest>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PageQuest>k__BackingField = value;
		}
	}

	// Token: 0x06000EA4 RID: 3748 RVA: 0x00091758 File Offset: 0x0008FB58
	public override void Init(PageElement item)
	{
		base.PageElement = item;
		this.PageQuest = (PageQuest)item;
		this.NewTextObj.SetActive(this.PageQuest.Quest.IsNew);
		this.CompeletedTextObj.SetActive(this.PageQuest.Quest.Completed);
		Description description = this.PageQuest.Quest.GetDescription();
		string text = description.Title;
		if (this.PageQuest.Quest.QuestIdentifier.IsMainQuest())
		{
			text = ColorPicker.GetNegativeColoredString("[" + UIComponentType.QuestItemMainQuestTitle.GetName() + "] ") + text;
		}
		this.QuestTitle.text = text;
	}

	// Token: 0x06000EA5 RID: 3749 RVA: 0x00091811 File Offset: 0x0008FC11
	public void OnPointerClick(PointerEventData eventData)
	{
		this.NewTextObj.SetActive(false);
		base.GetComponentInParent<QuestMenuController>().SelecteQuest(this.PageQuest);
	}

	// Token: 0x0400101B RID: 4123
	public TextMeshProUGUI QuestTitle;

	// Token: 0x0400101C RID: 4124
	public GameObject NewTextObj;

	// Token: 0x0400101D RID: 4125
	public GameObject CompeletedTextObj;

	// Token: 0x0400101E RID: 4126
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageQuest <PageQuest>k__BackingField;
}
