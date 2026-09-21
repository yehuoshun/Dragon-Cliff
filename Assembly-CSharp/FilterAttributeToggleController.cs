using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E3 RID: 483
public class FilterAttributeToggleController : MonoBehaviour
{
	// Token: 0x06000CDF RID: 3295 RVA: 0x0008C830 File Offset: 0x0008AC30
	public FilterAttributeToggleController()
	{
	}

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x06000CE0 RID: 3296 RVA: 0x0008C838 File Offset: 0x0008AC38
	// (set) Token: 0x06000CE1 RID: 3297 RVA: 0x0008C840 File Offset: 0x0008AC40
	public AttributeType AttributeType
	{
		[CompilerGenerated]
		get
		{
			return this.<AttributeType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AttributeType>k__BackingField = value;
		}
	}

	// Token: 0x06000CE2 RID: 3298 RVA: 0x0008C849 File Offset: 0x0008AC49
	public void Init(AttributeType type)
	{
		this.AttributeType = type;
		this.AttributeText.text = type.GetLocalization().Short;
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x0008C868 File Offset: 0x0008AC68
	public void OnToggleChange()
	{
		base.GetComponentInParent<InventoryFilterPanelController>().OnAttributeToggle(this.AttributeType, this.Toggle.isOn);
	}

	// Token: 0x04000EF8 RID: 3832
	public Toggle Toggle;

	// Token: 0x04000EF9 RID: 3833
	public TextMeshProUGUI AttributeText;

	// Token: 0x04000EFA RID: 3834
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <AttributeType>k__BackingField;
}
