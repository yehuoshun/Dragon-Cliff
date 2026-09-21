using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000326 RID: 806
public class IndividualHeroAvatarControl : MonoBehaviour
{
	// Token: 0x0600157E RID: 5502 RVA: 0x000AB41B File Offset: 0x000A981B
	public IndividualHeroAvatarControl()
	{
	}

	// Token: 0x0600157F RID: 5503 RVA: 0x000AB424 File Offset: 0x000A9824
	private void Start()
	{
		this.DeletionButton.onClick.AddListener(new UnityAction(this.RemoveHeroFromTheList));
		if (this._obj != null)
		{
			this.SetHero(this._obj);
		}
		else
		{
			this.Avatar.gameObject.SetActive(false);
			this.ParticleSystemIndicator.Play();
			this.DeletionButton.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001580 RID: 5504 RVA: 0x000AB49C File Offset: 0x000A989C
	public void SetupControl(SelectedHeroAvatarIndication control)
	{
		this._control = control;
	}

	// Token: 0x06001581 RID: 5505 RVA: 0x000AB4A5 File Offset: 0x000A98A5
	public AdventurerObj GetAdventurerObj()
	{
		return this._obj;
	}

	// Token: 0x06001582 RID: 5506 RVA: 0x000AB4B0 File Offset: 0x000A98B0
	public void SetHero(AdventurerObj obj)
	{
		this._obj = obj;
		this.Avatar.gameObject.SetActive(true);
		this.Avatar.sprite = Resources.Load<Sprite>(FilePath.GetAdventurerAvatar(obj.GetAdventurerProfile().UnitClass));
		this.ParticleSystemIndicator.Stop();
		this.DeletionButton.gameObject.SetActive(true);
	}

	// Token: 0x06001583 RID: 5507 RVA: 0x000AB511 File Offset: 0x000A9911
	private void OnEnable()
	{
		if (this._obj != null)
		{
			this.ParticleSystemIndicator.Stop();
		}
	}

	// Token: 0x06001584 RID: 5508 RVA: 0x000AB530 File Offset: 0x000A9930
	private void RemoveHeroFromTheList()
	{
		this._control.RemoveWithAvatarCrossOption(this._obj);
		this.Avatar.gameObject.SetActive(false);
		this.DeletionButton.gameObject.SetActive(false);
		this.ParticleSystemIndicator.Play();
		this._obj = null;
	}

	// Token: 0x06001585 RID: 5509 RVA: 0x000AB584 File Offset: 0x000A9984
	public void RemovedFromTheCheckBoxOption(AdventurerObj obj)
	{
		if (obj.GetAdventurerProfile().Id == this._obj.GetAdventurerProfile().Id)
		{
			this._obj = null;
			this.Avatar.gameObject.SetActive(false);
			this.ParticleSystemIndicator.Play();
			this.DeletionButton.gameObject.SetActive(false);
		}
	}

	// Token: 0x04001592 RID: 5522
	public Image Avatar;

	// Token: 0x04001593 RID: 5523
	public ParticleSystem ParticleSystemIndicator;

	// Token: 0x04001594 RID: 5524
	public Button DeletionButton;

	// Token: 0x04001595 RID: 5525
	private SelectedHeroAvatarIndication _control;

	// Token: 0x04001596 RID: 5526
	private AdventurerObj _obj;
}
