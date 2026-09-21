using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000115 RID: 277
public class AdventurerUIController : MonoBehaviour
{
	// Token: 0x0600078D RID: 1933 RVA: 0x00071A94 File Offset: 0x0006FE94
	public AdventurerUIController()
	{
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x0600078E RID: 1934 RVA: 0x00071A9C File Offset: 0x0006FE9C
	// (set) Token: 0x0600078F RID: 1935 RVA: 0x00071AA4 File Offset: 0x0006FEA4
	public AdventurerProfile Adventurer
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurer>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurer>k__BackingField = value;
		}
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x00071AAD File Offset: 0x0006FEAD
	public virtual void AssignEvent()
	{
	}

	// Token: 0x06000791 RID: 1937 RVA: 0x00071AB0 File Offset: 0x0006FEB0
	public void Init(AdventurerProfile adventurer, FixedAdventurerAnimation fixAnim = FixedAdventurerAnimation.Walk)
	{
		if (this.Adventurer == null || (this.Adventurer != null && this.Adventurer.Id != adventurer.Id))
		{
			this.Adventurer = adventurer;
			this.AssignEvent();
		}
		base.GetComponent<AdventurerUIAnimation>().Init(fixAnim);
		base.GetComponent<AdventurerAppearanceController>().InitAppearance(this.Adventurer);
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x00071B18 File Offset: 0x0006FF18
	protected bool IsDifferentAdventurer(AdventurerProfile adventurer)
	{
		return this.Adventurer == null || (this.Adventurer != null && this.Adventurer.Id != adventurer.Id);
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x00071B4C File Offset: 0x0006FF4C
	public void OnClick()
	{
	}

	// Token: 0x04000A76 RID: 2678
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <Adventurer>k__BackingField;
}
