using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000256 RID: 598
public class SchoolCreateScrollPanelController : MonoBehaviour
{
	// Token: 0x06000F89 RID: 3977 RVA: 0x00094F73 File Offset: 0x00093373
	public SchoolCreateScrollPanelController()
	{
	}

	// Token: 0x06000F8A RID: 3978 RVA: 0x00094F7B File Offset: 0x0009337B
	private void Awake()
	{
		this._timer = 0f;
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x00094F88 File Offset: 0x00093388
	private void OnDisable()
	{
		this._timer = 0f;
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x00094F95 File Offset: 0x00093395
	private void Update()
	{
		this._timer += Time.unscaledDeltaTime;
	}

	// Token: 0x06000F8D RID: 3981 RVA: 0x00094FAC File Offset: 0x000933AC
	public void Init(List<ResourceConsumptionRequirement> requiredResources)
	{
		bool flag = requiredResources.MetRequirements();
		int num = 1;
		if (flag)
		{
			int num2 = 999;
			foreach (ResourceConsumptionRequirement resourceConsumptionRequirement in requiredResources)
			{
				int num3 = (int)GameWorld.instance.PlayerProfile.GetResourceAmount_AvaliableForProduction(resourceConsumptionRequirement.ResourceType) / resourceConsumptionRequirement.AmountRequired;
				if (num3 == 0)
				{
					num2 = 1;
				}
				if (num3 > 0 && num3 < num2)
				{
					num2 = num3;
				}
			}
			num = num2;
		}
		this.Slider.maxValue = (float)num;
		this.CreateAmount = 1;
		this.Slider.value = 1f;
		this.Amount.text = "x" + 1;
		IEnumerator enumerator2 = this.RequiredItemContainer.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object obj = enumerator2.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator2 as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		foreach (ResourceConsumptionRequirement requiredResource in requiredResources)
		{
			SchoolCreateScrollRequiredItemController schoolCreateScrollRequiredItemController = UnityEngine.Object.Instantiate<SchoolCreateScrollRequiredItemController>(this.RequiredItemPre);
			schoolCreateScrollRequiredItemController.Init(requiredResource, 1);
			schoolCreateScrollRequiredItemController.transform.SetParent(this.RequiredItemContainer, false);
		}
		this.CreateButton.interactable = flag;
	}

	// Token: 0x06000F8E RID: 3982 RVA: 0x00095168 File Offset: 0x00093568
	public void AmountIncreaseByOne()
	{
		if (this.Slider.value < this.Slider.maxValue)
		{
			this.Slider.value += 1f;
			this.SliderAmountUpdated();
		}
	}

	// Token: 0x06000F8F RID: 3983 RVA: 0x000951A2 File Offset: 0x000935A2
	public void AmountDecreaseByOne()
	{
		if (this.Slider.value > 0f)
		{
			this.Slider.value -= 1f;
			this.SliderAmountUpdated();
		}
	}

	// Token: 0x06000F90 RID: 3984 RVA: 0x000951D8 File Offset: 0x000935D8
	public void SliderAmountUpdated()
	{
		if (this._timer < 0.1f)
		{
			return;
		}
		List<ResourceConsumptionRequirement> costForCombineScroll = base.GetComponentInParent<SchoolMenuController>().School.GetCostForCombineScroll();
		bool interactable = costForCombineScroll.MetRequirements();
		int num = (int)this.Slider.value;
		IEnumerator enumerator = this.RequiredItemContainer.GetEnumerator();
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
		foreach (ResourceConsumptionRequirement requiredResource in costForCombineScroll)
		{
			SchoolCreateScrollRequiredItemController schoolCreateScrollRequiredItemController = UnityEngine.Object.Instantiate<SchoolCreateScrollRequiredItemController>(this.RequiredItemPre);
			schoolCreateScrollRequiredItemController.Init(requiredResource, num);
			schoolCreateScrollRequiredItemController.transform.SetParent(this.RequiredItemContainer, false);
		}
		this.Amount.text = "x" + num;
		this.CreateAmount = num;
		this.CreateButton.interactable = interactable;
	}

	// Token: 0x040010CB RID: 4299
	public Transform RequiredItemContainer;

	// Token: 0x040010CC RID: 4300
	public SchoolCreateScrollRequiredItemController RequiredItemPre;

	// Token: 0x040010CD RID: 4301
	public SchoolScrollResultItemController ResultItem;

	// Token: 0x040010CE RID: 4302
	public Button CreateButton;

	// Token: 0x040010CF RID: 4303
	public Slider Slider;

	// Token: 0x040010D0 RID: 4304
	public TextMeshProUGUI Amount;

	// Token: 0x040010D1 RID: 4305
	public int CreateAmount;

	// Token: 0x040010D2 RID: 4306
	private float _timer;
}
