using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002CD RID: 717
public class RecipeToggleController : MonoBehaviour
{
	// Token: 0x06001320 RID: 4896 RVA: 0x000A18AC File Offset: 0x0009FCAC
	public RecipeToggleController()
	{
	}

	// Token: 0x06001321 RID: 4897 RVA: 0x000A18B4 File Offset: 0x0009FCB4
	public void Init(InventoryToggleType selectedType)
	{
		if (selectedType != this.ToggleType)
		{
			this.Toggle.isOn = false;
		}
		else
		{
			this.Toggle.isOn = true;
		}
		this._oldStatus = this.Toggle.isOn;
	}

	// Token: 0x06001322 RID: 4898 RVA: 0x000A18F0 File Offset: 0x0009FCF0
	public void SelectToggle()
	{
		if (this.Toggle.isOn && !this._oldStatus)
		{
			base.GetComponentInParent<FactoryFilterPanelController>().SelectToggle(this.ToggleType);
		}
	}

	// Token: 0x040013B7 RID: 5047
	public Toggle Toggle;

	// Token: 0x040013B8 RID: 5048
	public InventoryToggleType ToggleType;

	// Token: 0x040013B9 RID: 5049
	private bool _oldStatus;
}
