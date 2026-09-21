using System;
using TMPro;
using UnityEngine;

// Token: 0x0200028A RID: 650
public class ResourcePanelController : MonoBehaviour
{
	// Token: 0x06001151 RID: 4433 RVA: 0x0009A970 File Offset: 0x00098D70
	public ResourcePanelController()
	{
	}

	// Token: 0x06001152 RID: 4434 RVA: 0x0009A984 File Offset: 0x00098D84
	private void Awake()
	{
		double money = GameWorld.instance.PlayerProfile.GetMoney();
		this._lastMoney = money;
		this._lastMoneyForChangeAmountText = money;
		this.MoneyText.text = money.ToString("N0");
	}

	// Token: 0x06001153 RID: 4435 RVA: 0x0009A9C6 File Offset: 0x00098DC6
	private void Update()
	{
		this.DisplayMoneyText();
		this.DisplayAshText();
	}

	// Token: 0x06001154 RID: 4436 RVA: 0x0009A9D4 File Offset: 0x00098DD4
	private void DisplayAshText()
	{
		if (!this.AshText.gameObject.activeSelf)
		{
			return;
		}
		double resourceQuantity = GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.AshOfHope);
		if (Math.Abs(resourceQuantity - this._lastAshForChangeAmountText) >= 1.0)
		{
			this.AshChangeAmountContrller.ShowAshChangeText(resourceQuantity - this._lastAshForChangeAmountText);
			if (resourceQuantity > this._lastAshForChangeAmountText)
			{
				this.PlaySoundClip(this.MoneyIncreseClip);
			}
			else if (resourceQuantity < this._lastAshForChangeAmountText)
			{
				this.PlaySoundClip(this.MoneyDecreseClip);
			}
			this._lastAshForChangeAmountText = resourceQuantity;
		}
		if (Math.Abs(resourceQuantity - this._lastAsh) >= 0.1)
		{
			this._ashTimer += Time.unscaledDeltaTime * this.AmountUpdateTime;
			this.AshText.text = Mathf.Lerp((float)this._lastAsh, (float)resourceQuantity, this._ashTimer).ToString("N0");
			if (this._ashTimer >= 1f)
			{
				this.AshText.text = resourceQuantity.ToString("N0");
				this._lastAsh = resourceQuantity;
			}
		}
		else
		{
			this._ashTimer = 0f;
		}
	}

	// Token: 0x06001155 RID: 4437 RVA: 0x0009AB14 File Offset: 0x00098F14
	private void DisplayMoneyText()
	{
		double money = GameWorld.instance.PlayerProfile.GetMoney();
		if (Math.Abs(money - this._lastMoneyForChangeAmountText) >= 1.0)
		{
			this.MoneyChangeAmountContrller.ShowMoneyChangeText(money - this._lastMoneyForChangeAmountText);
			if (money > this._lastMoneyForChangeAmountText)
			{
				this.PlaySoundClip(this.MoneyIncreseClip);
			}
			else if (money < this._lastMoneyForChangeAmountText)
			{
				this.PlaySoundClip(this.MoneyDecreseClip);
			}
			this._lastMoneyForChangeAmountText = money;
		}
		if (Math.Abs(money - this._lastMoney) >= 0.1)
		{
			this._timer += Time.unscaledDeltaTime * this.AmountUpdateTime;
			this.MoneyText.text = Mathf.Lerp((float)this._lastMoney, (float)money, this._timer).ToString("N0");
			if (this._timer >= 1f)
			{
				this.MoneyText.text = money.ToString("N0");
				this._lastMoney = money;
			}
		}
		else
		{
			this._timer = 0f;
		}
		if (money >= PlayerProfile.MaxPossibleResources_NonItem)
		{
			this.MoneyText.color = ColorPicker.NagetiveRed;
			this.MoneyText.raycastTarget = true;
		}
		else
		{
			this.MoneyText.color = Color.white;
			this.MoneyText.raycastTarget = false;
		}
	}

	// Token: 0x06001156 RID: 4438 RVA: 0x0009AC84 File Offset: 0x00099084
	public void OnMouseOverMoney()
	{
		this.OpenDescriptionTooltip(new TooltipItem
		{
			Description = UIComponentType.MoneyLimitedReachedDescription.GetName().ReplaceToBuilder(UIComponentKey.Amount, PlayerProfile.MaxPossibleResources_NonItem.ToCommaFormat()).ToString(),
			Position = this.MoneyText.transform.position
		});
	}

	// Token: 0x06001157 RID: 4439 RVA: 0x0009ACDD File Offset: 0x000990DD
	public void OnMouseExitMoney()
	{
		this.CloseDescriptionTooltip();
	}

	// Token: 0x06001158 RID: 4440 RVA: 0x0009ACE5 File Offset: 0x000990E5
	public void PointerInResourceButton()
	{
		TownManager.Instance.Ui.OpenResourceMenu();
	}

	// Token: 0x06001159 RID: 4441 RVA: 0x0009ACF6 File Offset: 0x000990F6
	public void PointerOutResourceButton()
	{
		TownManager.Instance.Ui.CloseResourceMenu();
	}

	// Token: 0x04001227 RID: 4647
	public TextMeshProUGUI MoneyText;

	// Token: 0x04001228 RID: 4648
	public TextMeshProUGUI AshText;

	// Token: 0x04001229 RID: 4649
	public ChangeMoneyAmountController MoneyChangeAmountContrller;

	// Token: 0x0400122A RID: 4650
	public ChangeMoneyAmountController AshChangeAmountContrller;

	// Token: 0x0400122B RID: 4651
	public float AmountUpdateTime = 1f;

	// Token: 0x0400122C RID: 4652
	public AudioClip MoneyIncreseClip;

	// Token: 0x0400122D RID: 4653
	public AudioClip MoneyDecreseClip;

	// Token: 0x0400122E RID: 4654
	private double _lastMoney;

	// Token: 0x0400122F RID: 4655
	private double _lastMoneyForChangeAmountText;

	// Token: 0x04001230 RID: 4656
	private float _timer;

	// Token: 0x04001231 RID: 4657
	private double _lastAsh;

	// Token: 0x04001232 RID: 4658
	private double _lastAshForChangeAmountText;

	// Token: 0x04001233 RID: 4659
	private float _ashTimer;
}
