using System;
using TMPro;
using UnityEngine;

// Token: 0x02000287 RID: 647
public class ResetTalentConfirmPanelController : MonoBehaviour
{
	// Token: 0x0600113F RID: 4415 RVA: 0x0009A3ED File Offset: 0x000987ED
	public ResetTalentConfirmPanelController()
	{
	}

	// Token: 0x06001140 RID: 4416 RVA: 0x0009A3F5 File Offset: 0x000987F5
	public void Init(double amount)
	{
		this.Description.text = UIComponentType.TalentConfirmResetText.GetName().ReplaceToBuilder(UIComponentKey.Money, ColorPicker.GetHaxString(Color.cyan, amount.DoubleToString())).ToString();
	}

	// Token: 0x06001141 RID: 4417 RVA: 0x0009A42B File Offset: 0x0009882B
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x0400121D RID: 4637
	public TextMeshProUGUI Description;
}
