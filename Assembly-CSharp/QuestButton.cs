using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200039F RID: 927
public class QuestButton : MonoBehaviour
{
	// Token: 0x060018C1 RID: 6337 RVA: 0x000BF120 File Offset: 0x000BD520
	public QuestButton()
	{
	}

	// Token: 0x060018C2 RID: 6338 RVA: 0x000BF128 File Offset: 0x000BD528
	private void Start()
	{
		this._button = base.GetComponent<Button>();
		this._button.onClick.AddListener(new UnityAction(this.OnclickQuestButton));
	}

	// Token: 0x060018C3 RID: 6339 RVA: 0x000BF152 File Offset: 0x000BD552
	private void OnclickQuestButton()
	{
	}

	// Token: 0x04001899 RID: 6297
	public QuestPanelController QuestPanel;

	// Token: 0x0400189A RID: 6298
	private Button _button;
}
