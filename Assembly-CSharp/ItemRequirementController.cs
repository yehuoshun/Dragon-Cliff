using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002C6 RID: 710
public class ItemRequirementController : MonoBehaviour
{
	// Token: 0x060012F1 RID: 4849 RVA: 0x000A08B7 File Offset: 0x0009ECB7
	public ItemRequirementController()
	{
	}

	// Token: 0x170000D5 RID: 213
	// (get) Token: 0x060012F2 RID: 4850 RVA: 0x000A08BF File Offset: 0x0009ECBF
	// (set) Token: 0x060012F3 RID: 4851 RVA: 0x000A08C7 File Offset: 0x0009ECC7
	public RecipeInfo CurrentRecipe
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentRecipe>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CurrentRecipe>k__BackingField = value;
		}
	}

	// Token: 0x060012F4 RID: 4852 RVA: 0x000A08D0 File Offset: 0x0009ECD0
	private void Start()
	{
		this._isInDifficultMode = (GameWorld.instance.PlayerProfile.GetStarRating() >= 2);
		this.Toggle999Text.text = ((!this._isInDifficultMode) ? UIComponentType.FactoryMax999Toggle.GetName() : UIComponentType.FactoryMax9999Toggle.GetName());
	}

	// Token: 0x060012F5 RID: 4853 RVA: 0x000A0927 File Offset: 0x0009ED27
	private void OnEnable()
	{
		this.CraftButton.interactable = false;
	}

	// Token: 0x060012F6 RID: 4854 RVA: 0x000A0938 File Offset: 0x0009ED38
	public void Init(RecipeInfo recipe)
	{
		this.CurrentRecipe = recipe;
		this.RecipeImage.sprite = FilePath.GetRecipeImage(recipe.Recipe.ProductType);
		this.RecipeName.text = recipe.Recipe.RecipeName.GetDescription().Title;
		this.ResetPanel();
		bool additionalData = this.GetAdditionalData(UIAdditionalDataKey.FactoryMax99Toggle, true);
		bool additionalData2 = this.GetAdditionalData(UIAdditionalDataKey.FactoryMax999Toggle, false);
		if (additionalData == this.Max99Toggle.isOn && additionalData2 == this.Max999Toggle.isOn)
		{
			this.InitRequirement();
		}
		this.Max99Toggle.isOn = additionalData;
		this.Max999Toggle.isOn = additionalData2;
	}

	// Token: 0x060012F7 RID: 4855 RVA: 0x000A09E7 File Offset: 0x0009EDE7
	public void QuickCraft(RecipeInfo recipe)
	{
		this.Init(recipe);
		this.Craft();
	}

	// Token: 0x060012F8 RID: 4856 RVA: 0x000A09F8 File Offset: 0x0009EDF8
	public void ToggleMax99()
	{
		if (this.Max99Toggle.isOn)
		{
			this.Max999Toggle.isOn = false;
			this._maxRecipeNumber = 99;
		}
		else
		{
			this.Max999Toggle.isOn = true;
			this._maxRecipeNumber = ((!this._isInDifficultMode) ? 999 : 9999);
		}
		this.AmountSlider.maxValue = (float)this._maxRecipeNumber;
		this.UpdateSavedValue();
		this.InitRequirement();
	}

	// Token: 0x060012F9 RID: 4857 RVA: 0x000A0A78 File Offset: 0x0009EE78
	public void ToggleMax999()
	{
		if (this.Max999Toggle.isOn)
		{
			this.Max99Toggle.isOn = false;
			this._maxRecipeNumber = ((!this._isInDifficultMode) ? 999 : 9999);
		}
		else
		{
			this.Max99Toggle.isOn = true;
			this._maxRecipeNumber = 99;
		}
		this.AmountSlider.maxValue = (float)this._maxRecipeNumber;
		this.UpdateSavedValue();
		this.InitRequirement();
	}

	// Token: 0x060012FA RID: 4858 RVA: 0x000A0AF8 File Offset: 0x0009EEF8
	private void UpdateSavedValue()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.FactoryMax99Toggle, this.Max99Toggle.isOn);
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.FactoryMax999Toggle, this.Max999Toggle.isOn);
	}

	// Token: 0x060012FB RID: 4859 RVA: 0x000A0B50 File Offset: 0x0009EF50
	public void Craft()
	{
		if (!this.CraftButton.interactable)
		{
			return;
		}
		List<RecipeCraftRequirement> list = new List<RecipeCraftRequirement>();
		list.Add(new RecipeCraftRequirement
		{
			CraftingRecipe = this.CurrentRecipe.Recipe.ProductType,
			Amount = this._amountToMake
		});
		base.GetComponentInParent<ShopMenuController>().Craft(list, this.CurrentRecipe.ItemTierLevel);
		this.ResetPanel();
		this.CurrentRecipe = null;
	}

	// Token: 0x060012FC RID: 4860 RVA: 0x000A0BC7 File Offset: 0x0009EFC7
	public void ClearPanel()
	{
		this.CurrentRecipe = null;
		this.UpdateAmountInPanel(0);
	}

	// Token: 0x060012FD RID: 4861 RVA: 0x000A0BD7 File Offset: 0x0009EFD7
	public void ResetPanel()
	{
		this.UpdateAmountInPanel(1);
	}

	// Token: 0x060012FE RID: 4862 RVA: 0x000A0BE0 File Offset: 0x0009EFE0
	private void UpdateAmountInPanel(int amount)
	{
		this._amountToMake = amount;
		this.AmountSlider.value = (float)amount;
		this.AmoutText.text = "x " + this.AmountSlider.value;
	}

	// Token: 0x060012FF RID: 4863 RVA: 0x000A0C1C File Offset: 0x0009F01C
	public void UpdateAmount()
	{
		int maximumAmountCanMake = this.GetMaximumAmountCanMake();
		if (this.AmountSlider.value <= (float)maximumAmountCanMake)
		{
			this.UpdateAmountDetails(this.AmountSlider.value);
		}
		else
		{
			this.AmountSlider.value = (float)maximumAmountCanMake;
		}
	}

	// Token: 0x06001300 RID: 4864 RVA: 0x000A0C68 File Offset: 0x0009F068
	public void AmountIncreaseByOne()
	{
		if (this.AmountSlider.value >= (float)this._maxRecipeNumber || this.AmountSlider.value + 1f > (float)this.GetMaximumAmountCanMake())
		{
			this.DisplayWarningText(UIComponentType.EquipmentMenuOverAmountWarning.GetName());
		}
		else
		{
			this.UpdateAmountDetails(this.AmountSlider.value += 1f);
		}
	}

	// Token: 0x06001301 RID: 4865 RVA: 0x000A0CE0 File Offset: 0x0009F0E0
	public void AmountDecreaseByOne()
	{
		if (this.AmountSlider.value <= 1f || this.AmountSlider.value - 1f > (float)this.GetMaximumAmountCanMake())
		{
			return;
		}
		this.UpdateAmountDetails(this.AmountSlider.value -= 1f);
	}

	// Token: 0x06001302 RID: 4866 RVA: 0x000A0D40 File Offset: 0x0009F140
	private void UpdateAmountDetails(float newAmount)
	{
		this._amountToMake = (int)newAmount;
		this.AmoutText.text = "x " + newAmount;
		this.UpdateRequirementAmount();
	}

	// Token: 0x06001303 RID: 4867 RVA: 0x000A0D6C File Offset: 0x0009F16C
	private int GetMaximumAmountCanMake()
	{
		if (this.CurrentRecipe == null)
		{
			return 0;
		}
		int num = this._maxRecipeNumber;
		foreach (ResourceConsumptionRequirement resourceConsumptionRequirement in this.CurrentRecipe.Recipe.GetProductionRequirements(this.CurrentRecipe.ItemTierLevel))
		{
			IEnumerator enumerator2 = this.RequirementsTrans.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					Transform transform = (Transform)obj;
					RequiredRecipeController component = transform.GetComponent<RequiredRecipeController>();
					if (component.Requirement.ResourceType == resourceConsumptionRequirement.ResourceType)
					{
						int amountRequired = resourceConsumptionRequirement.AmountRequired;
						double resourceQuantity = GameWorld.instance.PlayerProfile.GetResourceQuantity(resourceConsumptionRequirement.ResourceType);
						int num2 = (int)(resourceQuantity / (double)amountRequired);
						num = ((num2 >= num) ? num : num2);
					}
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
		}
		return num;
	}

	// Token: 0x06001304 RID: 4868 RVA: 0x000A0E98 File Offset: 0x0009F298
	private void InitRequirement()
	{
		IEnumerator enumerator = this.RequirementsTrans.GetEnumerator();
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
		int num = this._maxRecipeNumber;
		foreach (ResourceConsumptionRequirement resourceConsumptionRequirement in this.CurrentRecipe.Recipe.GetProductionRequirements(this.CurrentRecipe.ItemTierLevel))
		{
			double resourceQuantity = GameWorld.instance.PlayerProfile.GetResourceQuantity(resourceConsumptionRequirement.ResourceType);
			int num2 = (resourceQuantity / (double)resourceConsumptionRequirement.AmountRequired).DoubleToInt();
			if (num2 < num)
			{
				num = num2;
			}
		}
		if (num == 0)
		{
			num = 1;
		}
		this.UpdateAmountInPanel(num);
		bool interactable = true;
		foreach (ResourceConsumptionRequirement requirement in this.CurrentRecipe.Recipe.GetProductionRequirements(this.CurrentRecipe.ItemTierLevel))
		{
			RequiredRecipeController component = UnityEngine.Object.Instantiate<GameObject>(this.RequiredRecipePre).GetComponent<RequiredRecipeController>();
			component.Init(requirement, num);
			component.transform.SetParent(this.RequirementsTrans, false);
			if (!component.IsEnoughToProduce)
			{
				interactable = false;
			}
		}
		this.CraftButton.interactable = interactable;
	}

	// Token: 0x06001305 RID: 4869 RVA: 0x000A1050 File Offset: 0x0009F450
	private void UpdateRequirementAmount()
	{
		if (this.CurrentRecipe == null)
		{
			return;
		}
		bool interactable = true;
		foreach (ResourceConsumptionRequirement resourceConsumptionRequirement in this.CurrentRecipe.Recipe.GetProductionRequirements(this.CurrentRecipe.ItemTierLevel))
		{
			IEnumerator enumerator2 = this.RequirementsTrans.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					Transform transform = (Transform)obj;
					RequiredRecipeController component = transform.GetComponent<RequiredRecipeController>();
					if (component.Requirement.ResourceType == resourceConsumptionRequirement.ResourceType)
					{
						component.UpdateRecipeAmount(this._amountToMake);
					}
					if (!component.IsEnoughToProduce)
					{
						interactable = false;
					}
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
		}
		this.CraftButton.interactable = interactable;
	}

	// Token: 0x04001392 RID: 5010
	public Image RecipeImage;

	// Token: 0x04001393 RID: 5011
	public TextMeshProUGUI RecipeName;

	// Token: 0x04001394 RID: 5012
	public TextMeshProUGUI AmoutText;

	// Token: 0x04001395 RID: 5013
	public Slider AmountSlider;

	// Token: 0x04001396 RID: 5014
	public Transform RequirementsTrans;

	// Token: 0x04001397 RID: 5015
	public GameObject RequiredRecipePre;

	// Token: 0x04001398 RID: 5016
	public Button CraftButton;

	// Token: 0x04001399 RID: 5017
	public Toggle Max99Toggle;

	// Token: 0x0400139A RID: 5018
	public Toggle Max999Toggle;

	// Token: 0x0400139B RID: 5019
	public TextMeshProUGUI Toggle999Text;

	// Token: 0x0400139C RID: 5020
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RecipeInfo <CurrentRecipe>k__BackingField;

	// Token: 0x0400139D RID: 5021
	private int _amountToMake;

	// Token: 0x0400139E RID: 5022
	private int _maxRecipeNumber;

	// Token: 0x0400139F RID: 5023
	private bool _isInDifficultMode;
}
