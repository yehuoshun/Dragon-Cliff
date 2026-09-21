using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000122 RID: 290
public class CombatUnitHealthController : MonoBehaviour
{
	// Token: 0x060007EC RID: 2028 RVA: 0x00073FB0 File Offset: 0x000723B0
	public CombatUnitHealthController()
	{
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x00073FB8 File Offset: 0x000723B8
	private void Start()
	{
		Canvas componentInChildren = base.GetComponentInChildren<Canvas>();
		componentInChildren.worldCamera = TownManager.Instance.Ui.BattleCamera;
		componentInChildren.sortingLayerName = "Characters";
		componentInChildren.sortingOrder = 5;
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x00073FF3 File Offset: 0x000723F3
	public IBattleUnit GetBattleUnit()
	{
		return this._battleUnit;
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x00073FFB File Offset: 0x000723FB
	public void ResetHealth(bool status)
	{
		if (!status)
		{
			this._battleUnit = null;
		}
		base.gameObject.SetActive(status);
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x00074018 File Offset: 0x00072418
	public void SetbattleUnit(IBattleUnit battleUnit)
	{
		this._battleUnit = battleUnit;
		this._lastLife = this._battleUnit.HealthPoints;
		this._lastMaxLife = this._battleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
		if (this.StyleIcon != null)
		{
			UnitClassStyle correspondingClassStyle = battleUnit.GetUnitType().GetConfiguration().CorrespondingClassStyle;
			if (battleUnit.IsPlayer || correspondingClassStyle == UnitClassStyle.None || battleUnit.IsBoss())
			{
				this.StyleIcon.gameObject.SetActive(false);
			}
			else
			{
				this.StyleIcon.Init(battleUnit);
				this.StyleIcon.gameObject.SetActive(true);
			}
		}
		if (this.LevelText != null)
		{
			this.LevelText.text = ((!battleUnit.IsPlayer) ? battleUnit.Level.DoubleToInt().ToLevelText() : string.Empty);
		}
		this.SetHealth(this._lastLife, this._lastMaxLife);
		this.Diselect();
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00074119 File Offset: 0x00072519
	private void SetHealth(double healthPoints, double maxLife)
	{
		this.HealthFill.fillAmount = (float)(healthPoints / maxLife);
		this.HealthText.text = healthPoints.RoundDouble(0).LargeDoubleToShortNumber() + "/" + maxLife.RoundDouble(0).LargeDoubleToShortNumber();
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x00074158 File Offset: 0x00072558
	public void UpdateHealth()
	{
		double num = this._battleUnit.HealthPoints.RoundDouble(0);
		double num2 = this._battleUnit.GetMaxLife(AttributeRetrievalLevel.Skill).RoundDouble(0);
		this.HealthFill.fillAmount = (float)(num / num2);
		if (num < 0.0)
		{
			this.HealthText.text = 0 + "/" + num2.ToExpression();
		}
		else if (num > 0.0 && num < 1.0)
		{
			this.HealthText.text = 1 + "/" + num2.ToExpression();
		}
		else
		{
			this.HealthText.text = num.RoundDouble(0).LargeDoubleToShortNumber() + "/" + num2.RoundDouble(0).LargeDoubleToShortNumber();
		}
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x0007423F File Offset: 0x0007263F
	public void Select()
	{
		this.SelectionImage.SetActive(true);
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x0007424D File Offset: 0x0007264D
	public void Diselect()
	{
		this.SelectionImage.SetActive(false);
	}

	// Token: 0x04000AC4 RID: 2756
	public Image HealthFill;

	// Token: 0x04000AC5 RID: 2757
	public TextMeshProUGUI HealthText;

	// Token: 0x04000AC6 RID: 2758
	public RectTransform RectTrans;

	// Token: 0x04000AC7 RID: 2759
	public GameObject SelectionImage;

	// Token: 0x04000AC8 RID: 2760
	public HealthBarStyleIconController StyleIcon;

	// Token: 0x04000AC9 RID: 2761
	public TextMeshProUGUI LevelText;

	// Token: 0x04000ACA RID: 2762
	private IBattleUnit _battleUnit;

	// Token: 0x04000ACB RID: 2763
	private double _lastLife;

	// Token: 0x04000ACC RID: 2764
	private double _lastMaxLife;
}
