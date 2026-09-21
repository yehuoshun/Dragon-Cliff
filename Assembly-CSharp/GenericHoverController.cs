using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000389 RID: 905
public abstract class GenericHoverController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06001840 RID: 6208 RVA: 0x000ABDA1 File Offset: 0x000AA1A1
	protected GenericHoverController()
	{
	}

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x06001841 RID: 6209 RVA: 0x000ABDA9 File Offset: 0x000AA1A9
	// (set) Token: 0x06001842 RID: 6210 RVA: 0x000ABDB1 File Offset: 0x000AA1B1
	public virtual bool _pointerIn
	{
		[CompilerGenerated]
		get
		{
			return this.<_pointerIn>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<_pointerIn>k__BackingField = value;
		}
	}

	// Token: 0x06001843 RID: 6211 RVA: 0x000ABDBA File Offset: 0x000AA1BA
	public virtual void Start()
	{
		this._pointerIn = false;
	}

	// Token: 0x06001844 RID: 6212 RVA: 0x000ABDC3 File Offset: 0x000AA1C3
	public void Finished()
	{
		if (this._pointerIn)
		{
			this.CloseTooltip();
		}
		this._pointerIn = false;
	}

	// Token: 0x06001845 RID: 6213 RVA: 0x000ABDDD File Offset: 0x000AA1DD
	public void OnPointerEnter(PointerEventData eventData)
	{
		this._pointerIn = true;
	}

	// Token: 0x06001846 RID: 6214 RVA: 0x000ABDE6 File Offset: 0x000AA1E6
	public virtual void UpdateHoverInfo()
	{
	}

	// Token: 0x06001847 RID: 6215 RVA: 0x000ABDE8 File Offset: 0x000AA1E8
	public void OnPointerExit(PointerEventData eventData)
	{
		this.Finished();
	}

	// Token: 0x06001848 RID: 6216 RVA: 0x000ABDF0 File Offset: 0x000AA1F0
	public virtual void OnDisable()
	{
		this.Finished();
	}

	// Token: 0x04001800 RID: 6144
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <_pointerIn>k__BackingField;
}
