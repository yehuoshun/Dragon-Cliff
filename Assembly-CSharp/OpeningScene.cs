using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000386 RID: 902
public class OpeningScene : MonoBehaviour
{
	// Token: 0x06001838 RID: 6200 RVA: 0x000B988B File Offset: 0x000B7C8B
	public OpeningScene()
	{
	}

	// Token: 0x06001839 RID: 6201 RVA: 0x000B9893 File Offset: 0x000B7C93
	private void Start()
	{
		this.Text.text = "VS";
		this._animator = base.GetComponent<Animator>();
	}

	// Token: 0x040017F6 RID: 6134
	public TextMeshProUGUI Text;

	// Token: 0x040017F7 RID: 6135
	private Animator _animator;

	// Token: 0x040017F8 RID: 6136
	public Text CounterText;

	// Token: 0x040017F9 RID: 6137
	public CompetitionTownInfo TownInfo;

	// Token: 0x040017FA RID: 6138
	public CompetitionTownInfo OpponentTownInfo;
}
