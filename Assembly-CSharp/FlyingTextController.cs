using System;
using TMPro;
using UnityEngine;

// Token: 0x0200020D RID: 525
public class FlyingTextController : MonoBehaviour
{
	// Token: 0x06000DE4 RID: 3556 RVA: 0x00090147 File Offset: 0x0008E547
	public FlyingTextController()
	{
	}

	// Token: 0x06000DE5 RID: 3557 RVA: 0x00090150 File Offset: 0x0008E550
	public void Init(FlyingText text)
	{
		this.MainText.text = text.DisplyingText;
		this.LinkText.text = ((!string.IsNullOrEmpty(text.LinkText)) ? text.LinkText : string.Empty);
		this.MainText.color = text.Textcolor;
		this._relatedObj = text.RelatedObj;
	}

	// Token: 0x06000DE6 RID: 3558 RVA: 0x000901B8 File Offset: 0x0008E5B8
	public void ClickText()
	{
		Quest quest = this._relatedObj as Quest;
		if (quest != null)
		{
			GameWorld.instance.PlayerProfile.CompleteQuest(quest);
		}
	}

	// Token: 0x04000FCF RID: 4047
	public TextMeshProUGUI MainText;

	// Token: 0x04000FD0 RID: 4048
	public TextMeshProUGUI LinkText;

	// Token: 0x04000FD1 RID: 4049
	private object _relatedObj;
}
