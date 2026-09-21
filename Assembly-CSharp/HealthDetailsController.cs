using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000126 RID: 294
public class HealthDetailsController : MonoBehaviour
{
	// Token: 0x0600080D RID: 2061 RVA: 0x00074A9D File Offset: 0x00072E9D
	public HealthDetailsController()
	{
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x00074AC6 File Offset: 0x00072EC6
	public void Init(IBattleUnit battleUnit)
	{
		this._battleUnit = battleUnit;
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x00074AD0 File Offset: 0x00072ED0
	private void Update()
	{
		if (Math.Abs(this._battleUnit.HealthPoints - this._lastHealth) > 1E-05)
		{
			this.UpdateHealthText();
			this._lastHealth = this._battleUnit.HealthPoints;
		}
		if (this._battleUnit.Status == BattleUnitStatus.Active)
		{
			this.UpdateChargeProgress();
		}
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x00074B30 File Offset: 0x00072F30
	public void OnEnable()
	{
		if (base.GetComponentInParent<Canvas>() != null)
		{
			base.GetComponentInParent<Canvas>().enabled = true;
		}
		if (base.GetComponentInParent<CanvasScaler>() != null)
		{
			base.GetComponentInParent<CanvasScaler>().enabled = true;
		}
		if (base.GetComponentInParent<GraphicRaycaster>() != null)
		{
			base.GetComponentInParent<GraphicRaycaster>().enabled = true;
		}
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x00074B94 File Offset: 0x00072F94
	private void UpdateChargeProgress()
	{
		this.ChargeProgressImage.fillAmount = Convert.ToSingle(this._battleUnit.TurnProgress);
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x00074BB4 File Offset: 0x00072FB4
	private void UpdateHealthText()
	{
		double healthPoints = this._battleUnit.HealthPoints;
		double maxLife = this._battleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
		this.HealthText.text = healthPoints.ToString("0") + "/" + maxLife.ToString("#");
		this.HealthText.color = ((Math.Abs(healthPoints - maxLife) >= 1E-05) ? ((Math.Abs(healthPoints) >= 1E-05) ? this._normolColor : this._zeroHealthColor) : this._fullHealthColor);
	}

	// Token: 0x04000AD9 RID: 2777
	public Text HealthText;

	// Token: 0x04000ADA RID: 2778
	public Image ChargeProgressImage;

	// Token: 0x04000ADB RID: 2779
	private IBattleUnit _battleUnit;

	// Token: 0x04000ADC RID: 2780
	private readonly Color _normolColor = ColorPicker.White;

	// Token: 0x04000ADD RID: 2781
	private readonly Color _fullHealthColor = ColorPicker.FullHealthGreen;

	// Token: 0x04000ADE RID: 2782
	private readonly Color _zeroHealthColor = ColorPicker.ZeroHealthGreen;

	// Token: 0x04000ADF RID: 2783
	private double _lastHealth;
}
