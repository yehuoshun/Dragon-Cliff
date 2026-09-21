using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002DA RID: 730
public class TownEffectItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06001367 RID: 4967 RVA: 0x000A317C File Offset: 0x000A157C
	public TownEffectItemController()
	{
	}

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x06001368 RID: 4968 RVA: 0x000A3184 File Offset: 0x000A1584
	// (set) Token: 0x06001369 RID: 4969 RVA: 0x000A318C File Offset: 0x000A158C
	public TownEffectBase TownEffect
	{
		[CompilerGenerated]
		get
		{
			return this.<TownEffect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TownEffect>k__BackingField = value;
		}
	}

	// Token: 0x170000DC RID: 220
	// (get) Token: 0x0600136A RID: 4970 RVA: 0x000A3195 File Offset: 0x000A1595
	// (set) Token: 0x0600136B RID: 4971 RVA: 0x000A319D File Offset: 0x000A159D
	public bool MouseOvered
	{
		[CompilerGenerated]
		get
		{
			return this.<MouseOvered>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MouseOvered>k__BackingField = value;
		}
	}

	// Token: 0x0600136C RID: 4972 RVA: 0x000A31A6 File Offset: 0x000A15A6
	public void Init(TownEffectBase townEffect)
	{
		this.TownEffect = townEffect;
		this.EffectIcon.sprite = FilePath.GetTownEffectIcon(townEffect);
		this.Animator.SetTrigger("Appear");
	}

	// Token: 0x0600136D RID: 4973 RVA: 0x000A31D0 File Offset: 0x000A15D0
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.TownEffect == null)
		{
			return;
		}
		Description description = this.TownEffect.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = string.Concat(new object[]
			{
				description.Details1,
				" ",
				UIComponentType.TownEffectRemainingDays.GetName(),
				": ",
				this.TownEffect.RemainingDays()
			}),
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
		this.MouseOvered = true;
	}

	// Token: 0x0600136E RID: 4974 RVA: 0x000A327C File Offset: 0x000A167C
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
		this.MouseOvered = false;
	}

	// Token: 0x040013FA RID: 5114
	public Image EffectIcon;

	// Token: 0x040013FB RID: 5115
	public Animator Animator;

	// Token: 0x040013FC RID: 5116
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownEffectBase <TownEffect>k__BackingField;

	// Token: 0x040013FD RID: 5117
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <MouseOvered>k__BackingField;
}
