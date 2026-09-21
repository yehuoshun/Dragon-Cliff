using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000282 RID: 642
public class QuantityPanelController : MonoBehaviour
{
	// Token: 0x0600110F RID: 4367 RVA: 0x00099AEF File Offset: 0x00097EEF
	public QuantityPanelController()
	{
	}

	// Token: 0x06001110 RID: 4368 RVA: 0x00099AF7 File Offset: 0x00097EF7
	private void Awake()
	{
		if (QuantityPanelController.Instance == null)
		{
			QuantityPanelController.Instance = this;
		}
	}

	// Token: 0x06001111 RID: 4369 RVA: 0x00099B0F File Offset: 0x00097F0F
	public void Init(CapableRecipeController selectedRecipe)
	{
		this._selectedRecipe = selectedRecipe;
		this.InputField.text = "1";
		this._enteredAmount = 1;
	}

	// Token: 0x06001112 RID: 4370 RVA: 0x00099B30 File Offset: 0x00097F30
	public void UpdateAmount(string amount)
	{
		this._enteredAmount = 0;
		int num = 0;
		if (!int.TryParse(amount, out num))
		{
			return;
		}
		if (num > 0 && num <= 99)
		{
			this._enteredAmount = num;
		}
	}

	// Token: 0x06001113 RID: 4371 RVA: 0x00099B6C File Offset: 0x00097F6C
	public void Close()
	{
		QuantityPanelController.Instance.gameObject.SetActive(false);
	}

	// Token: 0x04001206 RID: 4614
	public static QuantityPanelController Instance;

	// Token: 0x04001207 RID: 4615
	public InputField InputField;

	// Token: 0x04001208 RID: 4616
	private int _enteredAmount;

	// Token: 0x04001209 RID: 4617
	private CapableRecipeController _selectedRecipe;
}
