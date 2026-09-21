using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020009BF RID: 2495
[Serializable]
public class Vehicle
{
	// Token: 0x06004443 RID: 17475 RVA: 0x001BAC8D File Offset: 0x001B908D
	public Vehicle()
	{
	}

	// Token: 0x06004444 RID: 17476 RVA: 0x001BAC95 File Offset: 0x001B9095
	public bool IsAvaliable(DestinationType? destination)
	{
		return !GameWorld.instance.PlayerProfile.CurrentJourneys.Any((TripRecord t) => t.Vehicle.Id == this.Id && !t.Completed);
	}

	// Token: 0x06004445 RID: 17477 RVA: 0x001BACBA File Offset: 0x001B90BA
	public int GetRepairCost()
	{
		return this.Type.GetGenerator().GetRepairCost(this);
	}

	// Token: 0x06004446 RID: 17478 RVA: 0x001BACCD File Offset: 0x001B90CD
	public void Repair()
	{
		this.Type.GetGenerator().Repair(this);
	}

	// Token: 0x06004447 RID: 17479 RVA: 0x001BACE0 File Offset: 0x001B90E0
	public void ClearTravellers()
	{
		this.Travellers = new List<ITraveller>();
	}

	// Token: 0x06004448 RID: 17480 RVA: 0x001BACED File Offset: 0x001B90ED
	public void AddTraveller(ITraveller add)
	{
		if ((double)this.Travellers.Count < this.Stats.GetValue(VehicleAttributeType.Capacity))
		{
			this.Travellers.Add(add);
		}
	}

	// Token: 0x06004449 RID: 17481 RVA: 0x001BAD18 File Offset: 0x001B9118
	public void RemoveTraveller(ITraveller remove)
	{
		if (this.Travellers.Any((ITraveller t) => t == remove))
		{
			this.Travellers.Remove(remove);
		}
	}

	// Token: 0x0600444A RID: 17482 RVA: 0x001BAD60 File Offset: 0x001B9160
	public List<JourneyContributionModifier> GetContribution()
	{
		IEnumerable<JourneyContributionModifier> source = this.Travellers.SelectMany((ITraveller t) => t.GetContributions());
		IEnumerable<IGrouping<JourneyContributeType, JourneyContributionModifier>> enumerable = from c in source
		group c by c.Type;
		List<JourneyContributionModifier> list = new List<JourneyContributionModifier>();
		foreach (IGrouping<JourneyContributeType, JourneyContributionModifier> grouping in enumerable)
		{
			List<JourneyContributionModifier> list2 = list;
			JourneyContributionModifier journeyContributionModifier = new JourneyContributionModifier();
			journeyContributionModifier.Value = grouping.Sum((JourneyContributionModifier g) => g.Value);
			journeyContributionModifier.Key = string.Empty;
			journeyContributionModifier.Type = grouping.Key;
			list2.Add(journeyContributionModifier);
		}
		return list;
	}

	// Token: 0x0600444B RID: 17483 RVA: 0x001BAE58 File Offset: 0x001B9258
	[CompilerGenerated]
	private bool <IsAvaliable>m__0(TripRecord t)
	{
		return t.Vehicle.Id == this.Id && !t.Completed;
	}

	// Token: 0x0600444C RID: 17484 RVA: 0x001BAE81 File Offset: 0x001B9281
	[CompilerGenerated]
	private static IEnumerable<JourneyContributionModifier> <GetContribution>m__1(ITraveller t)
	{
		return t.GetContributions();
	}

	// Token: 0x0600444D RID: 17485 RVA: 0x001BAE89 File Offset: 0x001B9289
	[CompilerGenerated]
	private static JourneyContributeType <GetContribution>m__2(JourneyContributionModifier c)
	{
		return c.Type;
	}

	// Token: 0x0600444E RID: 17486 RVA: 0x001BAE91 File Offset: 0x001B9291
	[CompilerGenerated]
	private static double <GetContribution>m__3(JourneyContributionModifier g)
	{
		return g.Value;
	}

	// Token: 0x04003385 RID: 13189
	public VehicleType Type;

	// Token: 0x04003386 RID: 13190
	public int Level;

	// Token: 0x04003387 RID: 13191
	public string Id;

	// Token: 0x04003388 RID: 13192
	public List<VechileAttributeModifier> Stats;

	// Token: 0x04003389 RID: 13193
	public double Durability;

	// Token: 0x0400338A RID: 13194
	public double CurrentMaxDurability;

	// Token: 0x0400338B RID: 13195
	public List<ITraveller> Travellers;

	// Token: 0x0400338C RID: 13196
	[CompilerGenerated]
	private static Func<ITraveller, IEnumerable<JourneyContributionModifier>> <>f__am$cache0;

	// Token: 0x0400338D RID: 13197
	[CompilerGenerated]
	private static Func<JourneyContributionModifier, JourneyContributeType> <>f__am$cache1;

	// Token: 0x0400338E RID: 13198
	[CompilerGenerated]
	private static Func<JourneyContributionModifier, double> <>f__am$cache2;

	// Token: 0x0200100A RID: 4106
	[CompilerGenerated]
	private sealed class <RemoveTraveller>c__AnonStorey0
	{
		// Token: 0x060067D8 RID: 26584 RVA: 0x001BAE99 File Offset: 0x001B9299
		public <RemoveTraveller>c__AnonStorey0()
		{
		}

		// Token: 0x060067D9 RID: 26585 RVA: 0x001BAEA1 File Offset: 0x001B92A1
		internal bool <>m__0(ITraveller t)
		{
			return t == this.remove;
		}

		// Token: 0x040061D4 RID: 25044
		internal ITraveller remove;
	}
}
