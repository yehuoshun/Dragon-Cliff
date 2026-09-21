using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000154 RID: 340
public class BattleResourceItemController : MonoBehaviour
{
	// Token: 0x06000936 RID: 2358 RVA: 0x0007A1F6 File Offset: 0x000785F6
	public BattleResourceItemController()
	{
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x06000937 RID: 2359 RVA: 0x0007A1FE File Offset: 0x000785FE
	// (set) Token: 0x06000938 RID: 2360 RVA: 0x0007A206 File Offset: 0x00078606
	public ResourceUpdate Resource
	{
		[CompilerGenerated]
		get
		{
			return this.<Resource>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resource>k__BackingField = value;
		}
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x0007A210 File Offset: 0x00078610
	public void Init(ResourceUpdate resource)
	{
		this.Resource = resource;
		this._currentAmount = resource.ChangeAmount;
		this.ResourceImage.sprite = FilePath.GetRecipeImage(resource.ResourceType);
		this.AmountText.text = this._currentAmount.DoubleToString();
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x0007A25C File Offset: 0x0007865C
	public void UpdateAmount(double changeAmount)
	{
		this._currentAmount = changeAmount;
		this.AmountText.text = this._currentAmount.DoubleToString();
	}

	// Token: 0x04000BEC RID: 3052
	public Image ResourceImage;

	// Token: 0x04000BED RID: 3053
	public TextMeshProUGUI AmountText;

	// Token: 0x04000BEE RID: 3054
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceUpdate <Resource>k__BackingField;

	// Token: 0x04000BEF RID: 3055
	private double _currentAmount;
}
