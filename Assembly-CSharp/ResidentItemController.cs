using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200024D RID: 589
public class ResidentItemController : ResidentItemBaseController
{
	// Token: 0x06000F35 RID: 3893 RVA: 0x0009380D File Offset: 0x00091C0D
	public ResidentItemController()
	{
	}

	// Token: 0x06000F36 RID: 3894 RVA: 0x00093815 File Offset: 0x00091C15
	public override void Init(Resident resident)
	{
		base.Init(resident);
		this.InTripIndicator.SetActive(GameWorld.instance.PlayerProfile.CurrentJourneys.Any((TripRecord j) => j.Vehicle.Travellers.OfType<Resident>().Any((Resident a) => a.Id == base.Resident.Id)));
	}

	// Token: 0x06000F37 RID: 3895 RVA: 0x0009384C File Offset: 0x00091C4C
	private void Update()
	{
		if (base.Resident.HappinessValue > 0.0)
		{
			this.ProgressBar.SetActive(true);
			this.HappynessFill.fillAmount = (float)base.Resident.HappinessValue / 100f;
		}
		else
		{
			this.ProgressBar.SetActive(false);
		}
	}

	// Token: 0x06000F38 RID: 3896 RVA: 0x000938AC File Offset: 0x00091CAC
	public void OnMouseOverHappyEmoji()
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = base.Resident.Type.GetDescription().Title,
			Description = base.Resident.Type.GetDescription().Details1,
			Position = this.AvatarImage.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000F39 RID: 3897 RVA: 0x0009391E File Offset: 0x00091D1E
	public void OnMouseExitHappyEmoji()
	{
		this.CloseTooltip();
	}

	// Token: 0x06000F3A RID: 3898 RVA: 0x00093926 File Offset: 0x00091D26
	[CompilerGenerated]
	private bool <Init>m__0(TripRecord j)
	{
		return j.Vehicle.Travellers.OfType<Resident>().Any((Resident a) => a.Id == base.Resident.Id);
	}

	// Token: 0x06000F3B RID: 3899 RVA: 0x00093949 File Offset: 0x00091D49
	[CompilerGenerated]
	private bool <Init>m__1(Resident a)
	{
		return a.Id == base.Resident.Id;
	}

	// Token: 0x04001099 RID: 4249
	public GameObject ProgressBar;

	// Token: 0x0400109A RID: 4250
	public Image HappynessFill;

	// Token: 0x0400109B RID: 4251
	public GameObject InTripIndicator;
}
