using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;

// Token: 0x020002CC RID: 716
public class RecipeDropdownController : EquipmentDropdownBaseController
{
	// Token: 0x0600131B RID: 4891 RVA: 0x000A16EE File Offset: 0x0009FAEE
	public RecipeDropdownController()
	{
	}

	// Token: 0x0600131C RID: 4892 RVA: 0x000A16F6 File Offset: 0x0009FAF6
	private void Start()
	{
		this.Init(ItemOrderType.Default);
	}

	// Token: 0x0600131D RID: 4893 RVA: 0x000A1700 File Offset: 0x0009FB00
	public void Init(ItemOrderType orderType)
	{
		base.DropdownValues = new List<OrderTypeDropdownValue>();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int num = 0;
		IEnumerator enumerator = Enum.GetValues(typeof(ItemOrderType)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				string orderTypeTitle = base.GetOrderTypeTitle((ItemOrderType)obj);
				base.DropdownValues.Add(new OrderTypeDropdownValue
				{
					Value = num,
					Text = orderTypeTitle,
					Type = (ItemOrderType)obj
				});
				list.Add(new TMP_Dropdown.OptionData
				{
					text = orderTypeTitle
				});
				num++;
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
		OrderTypeDropdownValue orderTypeDropdownValue = base.DropdownValues.Single((OrderTypeDropdownValue d) => d.Type == orderType);
		base.SelectedValue = orderTypeDropdownValue.Value;
		this.Dropdown.captionText.text = orderTypeDropdownValue.Text;
		this.Dropdown.options.Clear();
		this.Dropdown.options.AddRange(list);
		this.Dropdown.value = base.SelectedValue;
	}

	// Token: 0x0600131E RID: 4894 RVA: 0x000A1854 File Offset: 0x0009FC54
	public ItemOrderType GetSlectedOrderType()
	{
		if (base.DropdownValues == null)
		{
			this.Init(ItemOrderType.Default);
		}
		return base.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == base.SelectedValue).Type;
	}

	// Token: 0x0600131F RID: 4895 RVA: 0x000A1884 File Offset: 0x0009FC84
	[CompilerGenerated]
	private bool <GetSlectedOrderType>m__0(OrderTypeDropdownValue d)
	{
		return d.Value == base.SelectedValue;
	}

	// Token: 0x02000C6F RID: 3183
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060052ED RID: 21229 RVA: 0x000A1894 File Offset: 0x0009FC94
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060052EE RID: 21230 RVA: 0x000A189C File Offset: 0x0009FC9C
		internal bool <>m__0(OrderTypeDropdownValue d)
		{
			return d.Type == this.orderType;
		}

		// Token: 0x040040A0 RID: 16544
		internal ItemOrderType orderType;
	}
}
