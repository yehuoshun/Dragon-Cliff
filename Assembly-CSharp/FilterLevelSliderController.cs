using System;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E6 RID: 486
public class FilterLevelSliderController : MonoBehaviour
{
	// Token: 0x06000CE9 RID: 3305 RVA: 0x0008C8F1 File Offset: 0x0008ACF1
	public FilterLevelSliderController()
	{
	}

	// Token: 0x06000CEA RID: 3306 RVA: 0x0008C8F9 File Offset: 0x0008ACF9
	private void OnEnable()
	{
		this.Reset();
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x0008C904 File Offset: 0x0008AD04
	public void Reset()
	{
		if (GameWorld.instance.PlayerProfile.Items.Any<Item>())
		{
			this._itemMaxLevel = (from i in GameWorld.instance.PlayerProfile.Items
			where i.Type.GetResourceCategory() != ResourceCategory.Amulet
			select i).Max((Item i) => i.Level);
		}
		else
		{
			this._itemMaxLevel = 0;
		}
		this.LevelSlider.maxValue = (float)(this._itemMaxLevel + 1);
		this.LevelSlider.value = this.LevelSlider.maxValue;
		this.LevelText.text = UIComponentType.InventoryAllText.GetName();
	}

	// Token: 0x06000CEC RID: 3308 RVA: 0x0008C9D0 File Offset: 0x0008ADD0
	public void OnSliderValueChange()
	{
		InventoryFilterPanelController componentInParent = base.GetComponentInParent<InventoryFilterPanelController>();
		if (componentInParent == null)
		{
			return;
		}
		if (this.LevelSlider.value > (float)this._itemMaxLevel)
		{
			this.LevelText.text = UIComponentType.InventoryAllText.GetName();
			componentInParent.OnSliderChange(0);
		}
		else
		{
			this.LevelText.text = ((int)this.LevelSlider.value).ToLevelText();
			componentInParent.OnSliderChange((int)this.LevelSlider.value);
		}
	}

	// Token: 0x06000CED RID: 3309 RVA: 0x0008CA57 File Offset: 0x0008AE57
	[CompilerGenerated]
	private static bool <Reset>m__0(Item i)
	{
		return i.Type.GetResourceCategory() != ResourceCategory.Amulet;
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x0008CA6B File Offset: 0x0008AE6B
	[CompilerGenerated]
	private static int <Reset>m__1(Item i)
	{
		return i.Level;
	}

	// Token: 0x04000EFF RID: 3839
	public Slider LevelSlider;

	// Token: 0x04000F00 RID: 3840
	public TextMeshProUGUI LevelText;

	// Token: 0x04000F01 RID: 3841
	private int _itemMaxLevel;

	// Token: 0x04000F02 RID: 3842
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x04000F03 RID: 3843
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cache1;
}
