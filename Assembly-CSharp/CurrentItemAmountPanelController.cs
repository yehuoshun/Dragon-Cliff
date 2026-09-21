using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x020001AC RID: 428
public class CurrentItemAmountPanelController : MonoBehaviour
{
	// Token: 0x06000B47 RID: 2887 RVA: 0x000857AF File Offset: 0x00083BAF
	public CurrentItemAmountPanelController()
	{
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x000857B7 File Offset: 0x00083BB7
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06000B49 RID: 2889 RVA: 0x000857C0 File Offset: 0x00083BC0
	public void Init()
	{
		List<Item> items = GameWorld.instance.PlayerProfile.Items;
		int num = items.Count((Item i) => i.IsUiEquipment());
		int num2 = items.Count((Item i) => i.Type.GetResourceCategory() == ResourceCategory.Gem);
		int num3 = items.Count((Item i) => i.Type.GetResourceCategory() == ResourceCategory.Usable);
		this.EquipmentsAmount.text = num.ToString();
		this.GemAmount.text = num2.ToString();
		this.UsableAmount.text = num3.ToString();
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x00085891 File Offset: 0x00083C91
	[CompilerGenerated]
	private static bool <Init>m__0(Item i)
	{
		return i.IsUiEquipment();
	}

	// Token: 0x06000B4B RID: 2891 RVA: 0x00085899 File Offset: 0x00083C99
	[CompilerGenerated]
	private static bool <Init>m__1(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x06000B4C RID: 2892 RVA: 0x000858AA File Offset: 0x00083CAA
	[CompilerGenerated]
	private static bool <Init>m__2(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Usable;
	}

	// Token: 0x04000DCD RID: 3533
	public TextMeshProUGUI EquipmentsAmount;

	// Token: 0x04000DCE RID: 3534
	public TextMeshProUGUI GemAmount;

	// Token: 0x04000DCF RID: 3535
	public TextMeshProUGUI UsableAmount;

	// Token: 0x04000DD0 RID: 3536
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x04000DD1 RID: 3537
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache1;

	// Token: 0x04000DD2 RID: 3538
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache2;
}
