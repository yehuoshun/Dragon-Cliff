using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000129 RID: 297
public class UIMiscGenerator : MonoBehaviour
{
	// Token: 0x0600081B RID: 2075 RVA: 0x00074F42 File Offset: 0x00073342
	public UIMiscGenerator()
	{
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x00074F6B File Offset: 0x0007336B
	private void Awake()
	{
		if (UIMiscGenerator.Instance == null)
		{
			UIMiscGenerator.Instance = this;
		}
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x00074F84 File Offset: 0x00073384
	private void Update()
	{
		for (int i = 0; i < this._effectTextsList.Count; i++)
		{
			if (this._waitingTimes.Count <= i)
			{
				return;
			}
			List<float> waitingTimes;
			int index;
			(waitingTimes = this._waitingTimes)[index = i] = waitingTimes[index] + Time.deltaTime;
			if (this._effectTextsList[i].Count > 0 && this._lastTexts[i] != this._effectTextsList[i][0] && this._waitingTimes[i] > 0.2f)
			{
				PopupTextElement popupTextElement = this._effectTextsList[i][0];
				this.CreatePositivePopupText(popupTextElement);
				this._effectTextsList[i].RemoveAt(0);
				this._lastTexts[i] = popupTextElement;
				this._waitingTimes[i] = 0f;
			}
		}
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x00075078 File Offset: 0x00073478
	public void ShowTalkingSymbol(Vector3 position, bool onTheLeft)
	{
		if (onTheLeft)
		{
			position += Vector3.right * 3f.ToScale();
		}
		else
		{
			position += Vector3.left * 3f.ToScale();
		}
		Vector2 v = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(position);
		this.TalkingSymbol.transform.SetParent(this.CombatUi, false);
		this.TalkingSymbol.transform.position = v;
		this.TalkingSymbol.Init(onTheLeft);
		this.TalkingSymbol.gameObject.SetActive(true);
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x0007512D File Offset: 0x0007352D
	public void HideTalkingSymbol()
	{
		this.TalkingSymbol.gameObject.SetActive(false);
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x00075140 File Offset: 0x00073540
	public void CreateHealthDetails(IBattleUnit unit, Transform ParentToBe, Vector3 position)
	{
		GameObject gameObject = ObjectPoolManager.Instance.Spawn(PoolType.HealthDetails, Vector3.zero);
		gameObject.GetComponentInChildren<HealthDetailsController>().Init(unit);
		gameObject.transform.SetParent(ParentToBe, false);
		gameObject.transform.localPosition = position;
		gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		this.HealthDetails.Add(gameObject);
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x000751B0 File Offset: 0x000735B0
	public void CreateHealPopupText(PopupTextElement text)
	{
		GameObject gameObject = this.PoolObject(PoolType.HealingPopupText, default(Vector3));
		Vector2 v = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(text.Position);
		gameObject.transform.SetParent(this.CombatUi, false);
		gameObject.transform.position = v;
		gameObject.GetComponent<HealingPopupText>().SetText(text);
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x00075220 File Offset: 0x00073620
	public void CreatePositivePopupText(PopupTextElement text)
	{
		GameObject gameObject = this.PoolObject(PoolType.TextPopupText, default(Vector3));
		Vector2 v = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(text.Position);
		gameObject.transform.SetParent(this.CombatUi, false);
		gameObject.transform.position = v;
		gameObject.GetComponent<EffectPopupText>().SetText(text);
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x00075290 File Offset: 0x00073690
	public void CreateDamagePopupText(PopupTextElement text)
	{
		GameObject gameObject = this.PoolObject(PoolType.DamagePopupText, default(Vector3));
		Vector2 v = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(text.Position);
		gameObject.transform.SetParent(this.CombatUi, false);
		gameObject.transform.position = v;
		gameObject.GetComponent<DamagePopupText>().SetText(text);
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x00075300 File Offset: 0x00073700
	public void CreateMissPopupText(PopupTextElement text)
	{
		GameObject gameObject = this.PoolObject(PoolType.MissPopupText, default(Vector3));
		Vector2 v = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(text.Position);
		gameObject.transform.SetParent(this.CombatUi, false);
		gameObject.transform.position = v;
		gameObject.GetComponent<MissPopupText>().SetText(text);
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x0007536D File Offset: 0x0007376D
	public void AddPopupTexts(List<PopupTextElement> text)
	{
		this._effectTextsList.Add(text);
		this._waitingTimes.Add(0f);
		this._lastTexts.Add(new PopupTextElement());
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x0007539C File Offset: 0x0007379C
	public void ClearPopupText()
	{
		foreach (List<PopupTextElement> list in this._effectTextsList)
		{
			list.Clear();
		}
		this._effectTextsList.Clear();
		this._waitingTimes.Clear();
		this._lastTexts.Clear();
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x00075418 File Offset: 0x00073818
	public void PopupSkillNameText(SkillType SkillName, PopupText pop)
	{
		Vector2 v = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(this.SkillCastedTextPosition.position);
		pop.transform.SetParent(this.CombatUi, false);
		pop.transform.position = v;
		pop.SetTextOnly(SkillName.GetDescription().Title);
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x0007547E File Offset: 0x0007387E
	public void ClearHealthDetails()
	{
		this.HealthDetails.ForEach(delegate(GameObject h)
		{
			GameObjectUtil.RecycleDestroy(h);
		});
		this.HealthDetails.Clear();
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x000754B3 File Offset: 0x000738B3
	[CompilerGenerated]
	private static void <ClearHealthDetails>m__0(GameObject h)
	{
		GameObjectUtil.RecycleDestroy(h);
	}

	// Token: 0x04000AE8 RID: 2792
	public static UIMiscGenerator Instance;

	// Token: 0x04000AE9 RID: 2793
	public Transform CombatUi;

	// Token: 0x04000AEA RID: 2794
	public List<GameObject> HealthDetails;

	// Token: 0x04000AEB RID: 2795
	public TalkingSymbolController TalkingSymbol;

	// Token: 0x04000AEC RID: 2796
	public Transform SkillCastedTextPosition;

	// Token: 0x04000AED RID: 2797
	private readonly List<List<PopupTextElement>> _effectTextsList = new List<List<PopupTextElement>>();

	// Token: 0x04000AEE RID: 2798
	private readonly List<float> _waitingTimes = new List<float>();

	// Token: 0x04000AEF RID: 2799
	private readonly List<PopupTextElement> _lastTexts = new List<PopupTextElement>();

	// Token: 0x04000AF0 RID: 2800
	private const float TextTimeOffset = 0.2f;

	// Token: 0x04000AF1 RID: 2801
	[CompilerGenerated]
	private static Action<GameObject> <>f__am$cache0;
}
