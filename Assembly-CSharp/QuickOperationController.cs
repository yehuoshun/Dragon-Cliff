using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020001F3 RID: 499
public class QuickOperationController : MonoBehaviour
{
	// Token: 0x06000D38 RID: 3384 RVA: 0x0008DA30 File Offset: 0x0008BE30
	public QuickOperationController()
	{
	}

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x06000D39 RID: 3385 RVA: 0x0008DA38 File Offset: 0x0008BE38
	// (set) Token: 0x06000D3A RID: 3386 RVA: 0x0008DA40 File Offset: 0x0008BE40
	public QuickOperationStatus QuickOperatingStatus
	{
		[CompilerGenerated]
		get
		{
			return this.<QuickOperatingStatus>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<QuickOperatingStatus>k__BackingField = value;
		}
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x0008DA4C File Offset: 0x0008BE4C
	private void Update()
	{
		QuickOperationStatus quickOperatingStatus = this.QuickOperatingStatus;
		if (quickOperatingStatus != QuickOperationStatus.QuickSelling)
		{
			if (quickOperatingStatus != QuickOperationStatus.QuickLocking)
			{
				if (quickOperatingStatus == QuickOperationStatus.QuickUnlocking)
				{
					this.QuickUnlockingIcon.transform.position = Input.mousePosition;
				}
			}
			else
			{
				this.QuickLockingIcon.transform.position = Input.mousePosition;
			}
		}
		else
		{
			this.QuickSellingIcon.transform.position = Input.mousePosition;
		}
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x0008DAC8 File Offset: 0x0008BEC8
	public bool IsQuickOperating()
	{
		return this.QuickOperatingStatus != QuickOperationStatus.None;
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x0008DAD6 File Offset: 0x0008BED6
	public void StopQuickOperating()
	{
		this.ChangeQuickOperatingStatus(QuickOperationStatus.None);
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x0008DADF File Offset: 0x0008BEDF
	public void ChangeQuickOperatingStatus(QuickOperationStatus status)
	{
		this.QuickOperatingStatus = status;
		this.QuickSellingIcon.SetActive(status == QuickOperationStatus.QuickSelling);
		this.QuickLockingIcon.SetActive(status == QuickOperationStatus.QuickLocking);
		this.QuickUnlockingIcon.SetActive(status == QuickOperationStatus.QuickUnlocking);
	}

	// Token: 0x04000F47 RID: 3911
	public GameObject QuickSellingIcon;

	// Token: 0x04000F48 RID: 3912
	public GameObject QuickLockingIcon;

	// Token: 0x04000F49 RID: 3913
	public GameObject QuickUnlockingIcon;

	// Token: 0x04000F4A RID: 3914
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QuickOperationStatus <QuickOperatingStatus>k__BackingField;
}
