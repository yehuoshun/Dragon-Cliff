using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000369 RID: 873
public class CompetitionResultPanel : MonoBehaviour
{
	// Token: 0x06001785 RID: 6021 RVA: 0x000B64DD File Offset: 0x000B48DD
	public CompetitionResultPanel()
	{
	}

	// Token: 0x06001786 RID: 6022 RVA: 0x000B64F0 File Offset: 0x000B48F0
	private void Start()
	{
		this.ConfirmButton.onClick.AddListener(new UnityAction(this.CloseWindow));
	}

	// Token: 0x06001787 RID: 6023 RVA: 0x000B6510 File Offset: 0x000B4910
	private void CloseWindow()
	{
		base.gameObject.SetActive(false);
		TownManager.Instance.Ui.ShowTown();
		this._matchResults.ForEach(delegate(IndividualRankingObj m)
		{
			m.windowClosed();
		});
		this._matchResults.ForEach(delegate(IndividualRankingObj m)
		{
			GameObjectUtil.RecycleDestroy(m.gameObject);
		});
		this._matchResults.Clear();
	}

	// Token: 0x06001788 RID: 6024 RVA: 0x000B6593 File Offset: 0x000B4993
	[CompilerGenerated]
	private static void <CloseWindow>m__0(IndividualRankingObj m)
	{
		m.windowClosed();
	}

	// Token: 0x06001789 RID: 6025 RVA: 0x000B659B File Offset: 0x000B499B
	[CompilerGenerated]
	private static void <CloseWindow>m__1(IndividualRankingObj m)
	{
		GameObjectUtil.RecycleDestroy(m.gameObject);
	}

	// Token: 0x04001772 RID: 6002
	public GameObject ParentObj;

	// Token: 0x04001773 RID: 6003
	public TextMeshProUGUI oneLabel;

	// Token: 0x04001774 RID: 6004
	public Button ConfirmButton;

	// Token: 0x04001775 RID: 6005
	private List<IndividualRankingObj> _matchResults = new List<IndividualRankingObj>();

	// Token: 0x04001776 RID: 6006
	[CompilerGenerated]
	private static Action<IndividualRankingObj> <>f__am$cache0;

	// Token: 0x04001777 RID: 6007
	[CompilerGenerated]
	private static Action<IndividualRankingObj> <>f__am$cache1;
}
