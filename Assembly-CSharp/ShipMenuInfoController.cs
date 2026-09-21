using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002B0 RID: 688
public class ShipMenuInfoController : MonoBehaviour
{
	// Token: 0x0600128B RID: 4747 RVA: 0x0009EEC8 File Offset: 0x0009D2C8
	public ShipMenuInfoController()
	{
	}

	// Token: 0x0600128C RID: 4748 RVA: 0x0009EED0 File Offset: 0x0009D2D0
	public void Init(Vehicle vehicle)
	{
		this._vehicle = vehicle;
		this.ShipTitle.text = vehicle.Type.GetDescription().Title;
		this.Durability.text = vehicle.Durability.DoubleToString() + "/" + vehicle.CurrentMaxDurability.DoubleToString();
		this.ShipImage.sprite = FilePath.GetVehicleSprite(vehicle.Type);
		string text = "0";
		string text2 = "0";
		string text3 = "0";
		string text4 = "0";
		string text5 = "0";
		List<TripRecord> currentJourneys = GameWorld.instance.PlayerProfile.CurrentJourneys;
		TripRecord tripRecord = currentJourneys.FirstOrDefault((TripRecord j) => j.Vehicle.Id == vehicle.Id);
		foreach (VechileAttributeModifier vechileAttributeModifier in vehicle.Stats)
		{
			VehicleAttributeType attributeType = vechileAttributeModifier.AttributeType;
			if (attributeType != VehicleAttributeType.Speed)
			{
				if (attributeType != VehicleAttributeType.Life)
				{
					if (attributeType == VehicleAttributeType.Capacity)
					{
						this.Capacity.text = vehicle.Travellers.Count + "/" + vechileAttributeModifier.Value.DoubleToString();
					}
				}
				else if (tripRecord != null)
				{
					this.HealthAmount.text = tripRecord.CurrentHealth.DoubleToString() + "/" + vechileAttributeModifier.Value.DoubleToString();
					this.HealthBar.fillAmount = (float)tripRecord.CurrentHealth / (float)vechileAttributeModifier.Value;
				}
				else
				{
					this.HealthAmount.text = vechileAttributeModifier.Value.DoubleToString() + "/" + vechileAttributeModifier.Value.DoubleToString();
					this.HealthBar.fillAmount = 1f;
				}
			}
			else
			{
				this.Speed.text = vechileAttributeModifier.Value.DoubleToString();
			}
		}
		foreach (JourneyContributionModifier journeyContributionModifier in vehicle.GetContribution())
		{
			switch (journeyContributionModifier.Type)
			{
			case JourneyContributeType.BattleSkill:
				text = journeyContributionModifier.Value.DoubleToString();
				break;
			case JourneyContributeType.TradeSkill:
				text2 = journeyContributionModifier.Value.DoubleToString();
				break;
			case JourneyContributeType.CultureSkill:
				text3 = journeyContributionModifier.Value.DoubleToString();
				break;
			case JourneyContributeType.ResearchSkill:
				text4 = journeyContributionModifier.Value.DoubleToString();
				break;
			case JourneyContributeType.CollectionSkill:
				text5 = journeyContributionModifier.Value.DoubleToString();
				break;
			}
		}
		this.BattleSkill.text = text;
		this.TradeSkill.text = text2;
		this.CultureSkill.text = text3;
		this.ResearchSkill.text = text4;
		this.CollectionSkill.text = text5;
	}

	// Token: 0x0600128D RID: 4749 RVA: 0x0009F238 File Offset: 0x0009D638
	public void UpdateHealth(double currentHealth)
	{
		VechileAttributeModifier vechileAttributeModifier = this._vehicle.Stats.FirstOrDefault((VechileAttributeModifier s) => s.AttributeType == VehicleAttributeType.Life);
		if (vechileAttributeModifier != null)
		{
			this.HealthAmount.text = currentHealth.DoubleToString() + "/" + vechileAttributeModifier.Value.DoubleToString();
			this.HealthBar.fillAmount = (float)currentHealth / (float)vechileAttributeModifier.Value;
		}
	}

	// Token: 0x0600128E RID: 4750 RVA: 0x0009F2B4 File Offset: 0x0009D6B4
	[CompilerGenerated]
	private static bool <UpdateHealth>m__0(VechileAttributeModifier s)
	{
		return s.AttributeType == VehicleAttributeType.Life;
	}

	// Token: 0x04001339 RID: 4921
	public TextMeshProUGUI ShipTitle;

	// Token: 0x0400133A RID: 4922
	public TextMeshProUGUI Durability;

	// Token: 0x0400133B RID: 4923
	public TextMeshProUGUI Speed;

	// Token: 0x0400133C RID: 4924
	public TextMeshProUGUI Capacity;

	// Token: 0x0400133D RID: 4925
	public TextMeshProUGUI HealthAmount;

	// Token: 0x0400133E RID: 4926
	public TextMeshProUGUI BattleSkill;

	// Token: 0x0400133F RID: 4927
	public TextMeshProUGUI TradeSkill;

	// Token: 0x04001340 RID: 4928
	public TextMeshProUGUI CultureSkill;

	// Token: 0x04001341 RID: 4929
	public TextMeshProUGUI ResearchSkill;

	// Token: 0x04001342 RID: 4930
	public TextMeshProUGUI CollectionSkill;

	// Token: 0x04001343 RID: 4931
	public Image ShipImage;

	// Token: 0x04001344 RID: 4932
	public Image HealthBar;

	// Token: 0x04001345 RID: 4933
	private Vehicle _vehicle;

	// Token: 0x04001346 RID: 4934
	[CompilerGenerated]
	private static Func<VechileAttributeModifier, bool> <>f__am$cache0;

	// Token: 0x02000C69 RID: 3177
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060052DD RID: 21213 RVA: 0x0009F2BF File Offset: 0x0009D6BF
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060052DE RID: 21214 RVA: 0x0009F2C7 File Offset: 0x0009D6C7
		internal bool <>m__0(TripRecord j)
		{
			return j.Vehicle.Id == this.vehicle.Id;
		}

		// Token: 0x04004097 RID: 16535
		internal Vehicle vehicle;
	}
}
