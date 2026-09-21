using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002AD RID: 685
public class ShipLogPanelController : MonoBehaviour
{
	// Token: 0x0600125C RID: 4700 RVA: 0x0009DEAB File Offset: 0x0009C2AB
	public ShipLogPanelController()
	{
	}

	// Token: 0x0600125D RID: 4701 RVA: 0x0009DEB4 File Offset: 0x0009C2B4
	public void Init(List<ITripeEncounter> encounters)
	{
		this.Clear();
		this.AddStartText();
		foreach (ITripeEncounter encounter in encounters)
		{
			this.AddLog(encounter);
		}
		this.ScrollRect.verticalNormalizedPosition = 0f;
	}

	// Token: 0x0600125E RID: 4702 RVA: 0x0009DF28 File Offset: 0x0009C328
	public void AddStartText()
	{
		TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(this.LogPre);
		textMeshProUGUI.text = UIComponentType.ShipMenuLogStart.GetName();
		textMeshProUGUI.transform.SetParent(this.LogContainer, false);
	}

	// Token: 0x0600125F RID: 4703 RVA: 0x0009DF64 File Offset: 0x0009C364
	public void AddLog(ITripeEncounter encounter)
	{
		TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(this.LogPre);
		Description encounterDescription = encounter.GetEncounterDescription();
		textMeshProUGUI.text = encounterDescription.Title + "\n" + encounterDescription.Details1 + encounter.GetEncounterOutcomeDescription().Details1;
		textMeshProUGUI.color = ((!encounter.IsPositive()) ? ColorPicker.NagetiveRed : ColorPicker.PositiveGreen);
		textMeshProUGUI.transform.SetParent(this.LogContainer, false);
		this.ScrollRect.verticalNormalizedPosition = 0f;
	}

	// Token: 0x06001260 RID: 4704 RVA: 0x0009DFF0 File Offset: 0x0009C3F0
	public void Clear()
	{
		IEnumerator enumerator = this.LogContainer.GetEnumerator();
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

	// Token: 0x0400131D RID: 4893
	public TextMeshProUGUI LogPre;

	// Token: 0x0400131E RID: 4894
	public Transform LogContainer;

	// Token: 0x0400131F RID: 4895
	public ScrollRect ScrollRect;
}
