using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A5 RID: 677
public class BuildShipMenuController : MonoBehaviour
{
	// Token: 0x06001235 RID: 4661 RVA: 0x0009D5D4 File Offset: 0x0009B9D4
	public BuildShipMenuController()
	{
	}

	// Token: 0x06001236 RID: 4662 RVA: 0x0009D5DC File Offset: 0x0009B9DC
	private void OnEnable()
	{
		this.SelectShip(this._currentIndex);
		this.BoatMan.HideNewBoatText();
	}

	// Token: 0x06001237 RID: 4663 RVA: 0x0009D5F5 File Offset: 0x0009B9F5
	public void Next()
	{
		this.SelectShip(this._currentIndex + 1);
	}

	// Token: 0x06001238 RID: 4664 RVA: 0x0009D605 File Offset: 0x0009BA05
	public void Previous()
	{
		this.SelectShip(this._currentIndex - 1);
	}

	// Token: 0x06001239 RID: 4665 RVA: 0x0009D618 File Offset: 0x0009BA18
	public void SelectShip(int index)
	{
		List<VehicleGeneratorBase> list = GameWorld.instance.PlayerProfile.GetProduceableVehicles();
		list = (from s in list
		orderby s.VehicleType
		select s).ToList<VehicleGeneratorBase>();
		if (index < list.Count)
		{
			this._currentIndex = index;
			this._vehicle = list[index];
			this.ShipTitle.text = this._vehicle.VehicleType.GetDescription().Title;
			this.ShipImage.sprite = FilePath.GetVehicleSprite(this._vehicle.VehicleType);
			this.LeftButton.interactable = (index != 0);
			this.RightButton.interactable = (list.Count - 1 != index);
			IEnumerator enumerator = this.ResourceContainer.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					UnityEngine.Object.Destroy(transform.gameObject);
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
			foreach (ResourceConsumptionRequirement requirement in this._vehicle.ProductionRequirements)
			{
				ShipResourceItemController shipResourceItemController = UnityEngine.Object.Instantiate<ShipResourceItemController>(this.ResourceItemPre);
				shipResourceItemController.Init(requirement);
				shipResourceItemController.transform.SetParent(this.ResourceContainer, false);
			}
			this.BuildButton.interactable = GameWorld.instance.PlayerProfile.CanCreateVehicle(this._vehicle.VehicleType);
		}
	}

	// Token: 0x0600123A RID: 4666 RVA: 0x0009D7DC File Offset: 0x0009BBDC
	public void BuildShip()
	{
		if (GameWorld.instance.PlayerProfile.CanCreateVehicle(this._vehicle.VehicleType))
		{
			GameWorld.instance.PlayerProfile.CreateVehicle(this._vehicle.VehicleType);
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = UIComponentType.BuildShipMenuBuildShipSuccessfully.GetName(),
				Textcolor = ColorPicker.PositiveGreen
			});
			base.gameObject.SetActive(false);
		}
		else
		{
			this.DisplayWarningText(UIComponentType.BuildShipMenuBuildShipFailed.GetName());
		}
	}

	// Token: 0x0600123B RID: 4667 RVA: 0x0009D86C File Offset: 0x0009BC6C
	[CompilerGenerated]
	private static VehicleType <SelectShip>m__0(VehicleGeneratorBase s)
	{
		return s.VehicleType;
	}

	// Token: 0x040012FC RID: 4860
	public TextMeshProUGUI ShipTitle;

	// Token: 0x040012FD RID: 4861
	public Image ShipImage;

	// Token: 0x040012FE RID: 4862
	public Button LeftButton;

	// Token: 0x040012FF RID: 4863
	public Button RightButton;

	// Token: 0x04001300 RID: 4864
	public Transform ResourceContainer;

	// Token: 0x04001301 RID: 4865
	public ShipResourceItemController ResourceItemPre;

	// Token: 0x04001302 RID: 4866
	public Button BuildButton;

	// Token: 0x04001303 RID: 4867
	public BoatManController BoatMan;

	// Token: 0x04001304 RID: 4868
	private int _currentIndex;

	// Token: 0x04001305 RID: 4869
	private VehicleGeneratorBase _vehicle;

	// Token: 0x04001306 RID: 4870
	[CompilerGenerated]
	private static Func<VehicleGeneratorBase, VehicleType> <>f__am$cache0;
}
