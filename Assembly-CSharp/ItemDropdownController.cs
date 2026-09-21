using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;

// Token: 0x020001CB RID: 459
public class ItemDropdownController : EquipmentDropdownBaseController
{
	// Token: 0x06000C7B RID: 3195 RVA: 0x0008A91A File Offset: 0x00088D1A
	public ItemDropdownController()
	{
	}

	// Token: 0x06000C7C RID: 3196 RVA: 0x0008A922 File Offset: 0x00088D22
	private void Start()
	{
		this.Init(ItemOrderType.Default);
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x0008A92C File Offset: 0x00088D2C
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
				ItemOrderType itemOrderType = (ItemOrderType)obj;
				if (itemOrderType != ItemOrderType.OrderByGrade && itemOrderType != ItemOrderType.OrderByLevel && itemOrderType != ItemOrderType.OrderByType && itemOrderType != ItemOrderType.OrderByTime && itemOrderType != ItemOrderType.OrderByHitRateAdjustment && itemOrderType != ItemOrderType.OrderByDodgeRateAdjustment)
				{
					string orderTypeTitle = base.GetOrderTypeTitle(itemOrderType);
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

	// Token: 0x06000C7E RID: 3198 RVA: 0x0008AABC File Offset: 0x00088EBC
	public ItemOrderType GetSlectedOrderType()
	{
		if (base.DropdownValues == null)
		{
			this.Init(ItemOrderType.Default);
		}
		return base.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == base.SelectedValue).Type;
	}

	// Token: 0x06000C7F RID: 3199 RVA: 0x0008AAEC File Offset: 0x00088EEC
	[CompilerGenerated]
	private bool <GetSlectedOrderType>m__0(OrderTypeDropdownValue d)
	{
		return d.Value == base.SelectedValue;
	}

	// Token: 0x02000C37 RID: 3127
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x06005247 RID: 21063 RVA: 0x0008AAFC File Offset: 0x00088EFC
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x06005248 RID: 21064 RVA: 0x0008AB04 File Offset: 0x00088F04
		internal bool <>m__0(OrderTypeDropdownValue d)
		{
			return d.Type == this.orderType;
		}

		// Token: 0x04004040 RID: 16448
		internal ItemOrderType orderType;
	}
}
