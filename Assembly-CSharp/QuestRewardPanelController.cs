using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class QuestRewardPanelController : MonoBehaviour
{
	// Token: 0x06000EF2 RID: 3826 RVA: 0x00092865 File Offset: 0x00090C65
	public QuestRewardPanelController()
	{
	}

	// Token: 0x06000EF3 RID: 3827 RVA: 0x0009286D File Offset: 0x00090C6D
	private void Awake()
	{
		this.TitleText.ForceMeshUpdate();
		this._titleAnimated = true;
	}

	// Token: 0x06000EF4 RID: 3828 RVA: 0x00092881 File Offset: 0x00090C81
	private void Start()
	{
	}

	// Token: 0x06000EF5 RID: 3829 RVA: 0x00092884 File Offset: 0x00090C84
	private void Update()
	{
		if (this._titleAnimated)
		{
			for (int i = 0; i < this.TitleText.textInfo.characterCount; i++)
			{
				TMP_CharacterInfo tmp_CharacterInfo = this.TitleText.textInfo.characterInfo[i];
				if (tmp_CharacterInfo.isVisible)
				{
					tmp_CharacterInfo.textElement.scale = Mathf.Lerp(0f, 1f, 1f);
				}
			}
		}
	}

	// Token: 0x06000EF6 RID: 3830 RVA: 0x0009290C File Offset: 0x00090D0C
	public void Init(List<QuestRewardBase> rewards, Quest quest)
	{
		this.ResetContainer();
		foreach (QuestRewardBase reward in rewards)
		{
			RewardItemController rewardItemController = UnityEngine.Object.Instantiate<RewardItemController>(this.RewardItemPre);
			rewardItemController.Init(reward, quest);
			rewardItemController.transform.SetParent(this.Container, false);
		}
	}

	// Token: 0x06000EF7 RID: 3831 RVA: 0x00092988 File Offset: 0x00090D88
	private void ResetContainer()
	{
		IEnumerator enumerator = this.Container.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
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
	}

	// Token: 0x06000EF8 RID: 3832 RVA: 0x000929F4 File Offset: 0x00090DF4
	public void Claim()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04001058 RID: 4184
	public RewardItemController RewardItemPre;

	// Token: 0x04001059 RID: 4185
	public Transform Container;

	// Token: 0x0400105A RID: 4186
	public TextMeshProUGUI TitleText;

	// Token: 0x0400105B RID: 4187
	private bool _titleAnimated;
}
