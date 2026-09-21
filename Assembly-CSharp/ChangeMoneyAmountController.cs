using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x02000267 RID: 615
public class ChangeMoneyAmountController : MonoBehaviour
{
	// Token: 0x06000FEB RID: 4075 RVA: 0x000968CB File Offset: 0x00094CCB
	public ChangeMoneyAmountController()
	{
	}

	// Token: 0x06000FEC RID: 4076 RVA: 0x000968F4 File Offset: 0x00094CF4
	private void Update()
	{
		this._moneyTimer += Time.unscaledDeltaTime;
		if (this._awaitingMoneyTexts.Count > 0 && this._moneyTimer >= this.TextGapTime)
		{
			this.SpawnMoneyText(this._awaitingMoneyTexts[0], false);
			this._awaitingMoneyTexts.RemoveAt(0);
			this._moneyTimer = 0f;
		}
		this._ashTimer += Time.unscaledDeltaTime;
		if (this._awaitingAshTexts.Count > 0 && this._ashTimer >= this.TextGapTime)
		{
			this.SpawnMoneyText(this._awaitingAshTexts[0], true);
			this._awaitingAshTexts.RemoveAt(0);
			this._ashTimer = 0f;
		}
	}

	// Token: 0x06000FED RID: 4077 RVA: 0x000969C0 File Offset: 0x00094DC0
	public void SpawnMoneyText(double changeAmount, bool isAsh = false)
	{
		TextMeshProUGUI component = UnityEngine.Object.Instantiate<GameObject>(this.ChangeAmountPre).GetComponent<TextMeshProUGUI>();
		component.text = ((changeAmount <= 0.0) ? changeAmount.DoubleToString() : ("+" + changeAmount.DoubleToString()));
		component.color = ((!isAsh) ? ColorPicker.GetPosNegColor(changeAmount) : ColorPicker.AshTextColor);
		component.transform.SetParent(base.transform, false);
		component.gameObject.SetActive(true);
		component.GetComponent<Animator>().SetTrigger("Change");
		UnityEngine.Object.Destroy(component.gameObject, 3f);
	}

	// Token: 0x06000FEE RID: 4078 RVA: 0x00096A68 File Offset: 0x00094E68
	public void ShowMoneyChangeText(double changeAmount)
	{
		this._awaitingMoneyTexts.Add(changeAmount);
	}

	// Token: 0x06000FEF RID: 4079 RVA: 0x00096A76 File Offset: 0x00094E76
	public void ShowAshChangeText(double changeAmount)
	{
		this._awaitingAshTexts.Add(changeAmount);
	}

	// Token: 0x0400112E RID: 4398
	public GameObject ChangeAmountPre;

	// Token: 0x0400112F RID: 4399
	public float TextGapTime = 0.3f;

	// Token: 0x04001130 RID: 4400
	private readonly List<double> _awaitingMoneyTexts = new List<double>();

	// Token: 0x04001131 RID: 4401
	private readonly List<double> _awaitingAshTexts = new List<double>();

	// Token: 0x04001132 RID: 4402
	private float _moneyTimer;

	// Token: 0x04001133 RID: 4403
	private float _ashTimer;
}
