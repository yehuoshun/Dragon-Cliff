using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002CE RID: 718
public class RequiredRecipeController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06001323 RID: 4899 RVA: 0x000A191E File Offset: 0x0009FD1E
	public RequiredRecipeController()
	{
	}

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x06001324 RID: 4900 RVA: 0x000A1926 File Offset: 0x0009FD26
	// (set) Token: 0x06001325 RID: 4901 RVA: 0x000A192E File Offset: 0x0009FD2E
	public ResourceConsumptionRequirement Requirement
	{
		[CompilerGenerated]
		get
		{
			return this.<Requirement>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Requirement>k__BackingField = value;
		}
	}

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x06001326 RID: 4902 RVA: 0x000A1937 File Offset: 0x0009FD37
	// (set) Token: 0x06001327 RID: 4903 RVA: 0x000A193F File Offset: 0x0009FD3F
	public bool IsEnoughToProduce
	{
		[CompilerGenerated]
		get
		{
			return this.<IsEnoughToProduce>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsEnoughToProduce>k__BackingField = value;
		}
	}

	// Token: 0x06001328 RID: 4904 RVA: 0x000A1948 File Offset: 0x0009FD48
	public void Init(ResourceConsumptionRequirement requirement, int amount)
	{
		this.Requirement = requirement;
		this.RecipeImage.sprite = FilePath.GetRecipeImage(this.Requirement.ResourceType);
		this.UpdateRecipeAmount(amount);
	}

	// Token: 0x06001329 RID: 4905 RVA: 0x000A1974 File Offset: 0x0009FD74
	public void UpdateRecipeAmount(int quantity)
	{
		int num = this.Requirement.AmountRequired * quantity;
		double resourceQuantity = GameWorld.instance.PlayerProfile.GetResourceQuantity(this.Requirement.ResourceType);
		this.IsEnoughToProduce = ((double)num <= resourceQuantity);
		Color color = (!this.IsEnoughToProduce) ? ColorPicker.NagetiveRed : ColorPicker.PositiveGreen;
		this.AmoutRatio.text = resourceQuantity.DoubleToShortNumber() + " / " + num;
		this.AmoutRatio.color = color;
	}

	// Token: 0x0600132A RID: 4906 RVA: 0x000A1A00 File Offset: 0x0009FE00
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this.Requirement.ResourceType.GetDescription();
		if (string.IsNullOrEmpty(description.Details1))
		{
			this.OpenDescriptionTooltip(new TooltipItem
			{
				Description = description.Title,
				Position = base.transform.position
			});
		}
		else
		{
			this.OpenTooltip(new TooltipItem
			{
				Title = description.Title,
				Description = description.Details1,
				Position = base.transform.position
			}, null, TooltipPosition.None, 0f, 0f);
		}
	}

	// Token: 0x0600132B RID: 4907 RVA: 0x000A1A9F File Offset: 0x0009FE9F
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
		this.CloseDescriptionTooltip();
	}

	// Token: 0x040013BA RID: 5050
	public Image RecipeImage;

	// Token: 0x040013BB RID: 5051
	public TextMeshProUGUI AmoutRatio;

	// Token: 0x040013BC RID: 5052
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceConsumptionRequirement <Requirement>k__BackingField;

	// Token: 0x040013BD RID: 5053
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsEnoughToProduce>k__BackingField;
}
