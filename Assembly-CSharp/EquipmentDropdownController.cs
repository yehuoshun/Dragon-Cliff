using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;

// Token: 0x020001B3 RID: 435
public class EquipmentDropdownController : EquipmentDropdownBaseController
{
	// Token: 0x06000B6B RID: 2923 RVA: 0x000860C0 File Offset: 0x000844C0
	public EquipmentDropdownController()
	{
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x000860C8 File Offset: 0x000844C8
	private void Start()
	{
		this.Init();
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x000860D0 File Offset: 0x000844D0
	public void Init()
	{
		base.DropdownValues = new List<OrderTypeDropdownValue>();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		ItemOrderType orderType = GameWorld.instance.PlayerProfile.ItemOrderType;
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
		OrderTypeDropdownValue orderTypeDropdownValue = base.DropdownValues.SingleOrDefault((OrderTypeDropdownValue d) => d.Type == orderType);
		if (orderTypeDropdownValue == null)
		{
			orderTypeDropdownValue = base.DropdownValues[0];
		}
		base.SelectedValue = orderTypeDropdownValue.Value;
		this.Dropdown.captionText.text = orderTypeDropdownValue.Text;
		this.Dropdown.options.Clear();
		this.Dropdown.options.AddRange(list);
		this.Dropdown.value = base.SelectedValue;
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x00086248 File Offset: 0x00084648
	public ItemOrderType GetSlectedOrderType()
	{
		if (base.DropdownValues == null)
		{
			this.Init();
		}
		return base.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == base.SelectedValue).Type;
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x00086277 File Offset: 0x00084677
	[CompilerGenerated]
	private bool <GetSlectedOrderType>m__0(OrderTypeDropdownValue d)
	{
		return d.Value == base.SelectedValue;
	}

	// Token: 0x02000C2C RID: 3116
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x0600522E RID: 21038 RVA: 0x00086287 File Offset: 0x00084687
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x0600522F RID: 21039 RVA: 0x0008628F File Offset: 0x0008468F
		internal bool <>m__0(OrderTypeDropdownValue d)
		{
			return d.Type == this.orderType;
		}

		// Token: 0x04004032 RID: 16434
		internal ItemOrderType orderType;
	}
}
