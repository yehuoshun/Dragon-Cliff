using System;
using UnityEngine;

// Token: 0x0200013A RID: 314
public class PopupTextController : MonoBehaviour
{
	// Token: 0x060008B6 RID: 2230 RVA: 0x00078181 File Offset: 0x00076581
	public PopupTextController()
	{
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x00078189 File Offset: 0x00076589
	public static void InitializeDamageText()
	{
		PopupTextController._canvas = UnityEngine.Object.FindObjectOfType<UIController>();
		if (!PopupTextController._popupTextDamage)
		{
			PopupTextController._popupTextDamage = Resources.Load<PopupText>("Prefabs/PopupText/PopupTextDamage");
		}
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x000781B3 File Offset: 0x000765B3
	public static void InitializeHealingText()
	{
		PopupTextController._canvas = UnityEngine.Object.FindObjectOfType<UIController>();
		if (!PopupTextController._popupTextHealing)
		{
			PopupTextController._popupTextHealing = Resources.Load<PopupText>("Prefabs/PopupText/PopupTextHealing");
		}
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x000781E0 File Offset: 0x000765E0
	public static void CreateDamagePopupText(PopupTextElement text)
	{
		PopupTextController.InitializeDamageText();
		PopupText popupText = UnityEngine.Object.Instantiate<PopupText>(PopupTextController._popupTextDamage);
		Vector2 v = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(text.Position);
		popupText.transform.SetParent(PopupTextController._canvas.transform, false);
		popupText.transform.position = v;
		popupText.SetText(text);
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x0007824C File Offset: 0x0007664C
	public static void CreateHealingPopupText(PopupTextElement text)
	{
		PopupTextController.InitializeHealingText();
		PopupText popupText = UnityEngine.Object.Instantiate<PopupText>(PopupTextController._popupTextHealing);
		Vector2 v = Camera.main.WorldToScreenPoint(text.Position);
		popupText.transform.SetParent(PopupTextController._canvas.transform, false);
		popupText.transform.position = v;
		popupText.SetText(text);
	}

	// Token: 0x04000B46 RID: 2886
	private static PopupText _popupTextDamage;

	// Token: 0x04000B47 RID: 2887
	private static PopupText _popupTextHealing;

	// Token: 0x04000B48 RID: 2888
	private static UIController _canvas;
}
