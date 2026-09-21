using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200014C RID: 332
public class SeasonScreenController : MonoBehaviour
{
	// Token: 0x06000911 RID: 2321 RVA: 0x00079840 File Offset: 0x00077C40
	public SeasonScreenController()
	{
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x00079848 File Offset: 0x00077C48
	public void Init(Season season)
	{
		this.SeasonTitle.text = season.ToString();
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x00079862 File Offset: 0x00077C62
	public void InitWithMessage(string message)
	{
		this.SeasonTitle.text = message;
	}

	// Token: 0x04000BBC RID: 3004
	public Text SeasonTitle;
}
