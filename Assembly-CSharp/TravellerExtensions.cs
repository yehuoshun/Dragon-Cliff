using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020009A9 RID: 2473
public static class TravellerExtensions
{
	// Token: 0x060043EC RID: 17388 RVA: 0x001B9504 File Offset: 0x001B7904
	public static bool IsInTravel(this ITraveller traveller)
	{
		return GameWorld.instance.PlayerProfile.CurrentJourneys.Any((TripRecord t) => !t.Completed && t.Travellers.Any((ITraveller v) => v.GetId() == traveller.GetId())) || GameWorld.instance.PlayerProfile.CurrentVehicles.Any((Vehicle v) => v.Travellers.Any((ITraveller tv) => tv.GetId() == traveller.GetId()));
	}

	// Token: 0x060043ED RID: 17389 RVA: 0x001B9566 File Offset: 0x001B7966
	public static JourneyContributionGenerator GetGenerator(this JourneyContributeType type)
	{
		return TravellerExtensions.JourneyContributionGenerators[type];
	}

	// Token: 0x060043EE RID: 17390 RVA: 0x001B9573 File Offset: 0x001B7973
	public static DestinationProcessBase GetProcess(this DestinationType type)
	{
		return TravellerExtensions.DestinationProcess[type];
	}

	// Token: 0x060043EF RID: 17391 RVA: 0x001B9580 File Offset: 0x001B7980
	public static VehicleGeneratorBase GetGenerator(this VehicleType type)
	{
		return TravellerExtensions.VehicleCreators[type];
	}

	// Token: 0x060043F0 RID: 17392 RVA: 0x001B958D File Offset: 0x001B798D
	public static TripEncounterProcess GetProcess(this TripEncounterType type)
	{
		return TravellerExtensions.EncounterProcess[type];
	}

	// Token: 0x060043F1 RID: 17393 RVA: 0x001B959C File Offset: 0x001B799C
	public static double GetValue(this List<VechileAttributeModifier> stats, VehicleAttributeType type)
	{
		return (from s in stats
		where s.AttributeType == type
		select s).Sum((VechileAttributeModifier s) => s.Value);
	}

	// Token: 0x060043F2 RID: 17394 RVA: 0x001B95EC File Offset: 0x001B79EC
	public static double GetValue(this List<JourneyContributionModifier> stats, JourneyContributeType type)
	{
		return (from s in stats
		where s.Type == type
		select s).Sum((JourneyContributionModifier s) => s.Value);
	}

	// Token: 0x060043F3 RID: 17395 RVA: 0x001B963C File Offset: 0x001B7A3C
	// Note: this type is marked as 'beforefieldinit'.
	static TravellerExtensions()
	{
	}

	// Token: 0x060043F4 RID: 17396 RVA: 0x001B96A1 File Offset: 0x001B7AA1
	[CompilerGenerated]
	private static double <GetValue>m__0(VechileAttributeModifier s)
	{
		return s.Value;
	}

	// Token: 0x060043F5 RID: 17397 RVA: 0x001B96A9 File Offset: 0x001B7AA9
	[CompilerGenerated]
	private static double <GetValue>m__1(JourneyContributionModifier s)
	{
		return s.Value;
	}

	// Token: 0x060043F6 RID: 17398 RVA: 0x001B96B1 File Offset: 0x001B7AB1
	[CompilerGenerated]
	private static DestinationType <DestinationProcess>m__2(DestinationProcessBase p)
	{
		return p.DestinationType;
	}

	// Token: 0x060043F7 RID: 17399 RVA: 0x001B96B9 File Offset: 0x001B7AB9
	[CompilerGenerated]
	private static VehicleType <VehicleCreators>m__3(VehicleGeneratorBase p)
	{
		return p.VehicleType;
	}

	// Token: 0x060043F8 RID: 17400 RVA: 0x001B96C1 File Offset: 0x001B7AC1
	[CompilerGenerated]
	private static TripEncounterType <EncounterProcess>m__4(TripEncounterProcess p)
	{
		return p.Type;
	}

	// Token: 0x060043F9 RID: 17401 RVA: 0x001B96C9 File Offset: 0x001B7AC9
	[CompilerGenerated]
	private static JourneyContributeType <JourneyContributionGenerators>m__5(JourneyContributionGenerator p)
	{
		return p.Type;
	}

	// Token: 0x04003349 RID: 13129
	public static Dictionary<DestinationType, DestinationProcessBase> DestinationProcess = ItemExtensions.GetDictionaryOfAbastract<DestinationType, DestinationProcessBase>((DestinationProcessBase p) => p.DestinationType);

	// Token: 0x0400334A RID: 13130
	public static Dictionary<VehicleType, VehicleGeneratorBase> VehicleCreators = ItemExtensions.GetDictionaryOfAbastract<VehicleType, VehicleGeneratorBase>((VehicleGeneratorBase p) => p.VehicleType);

	// Token: 0x0400334B RID: 13131
	public static Dictionary<TripEncounterType, TripEncounterProcess> EncounterProcess = ItemExtensions.GetDictionaryOfAbastract<TripEncounterType, TripEncounterProcess>((TripEncounterProcess p) => p.Type);

	// Token: 0x0400334C RID: 13132
	public static Dictionary<JourneyContributeType, JourneyContributionGenerator> JourneyContributionGenerators = ItemExtensions.GetDictionaryOfAbastract<JourneyContributeType, JourneyContributionGenerator>((JourneyContributionGenerator p) => p.Type);

	// Token: 0x0400334D RID: 13133
	[CompilerGenerated]
	private static Func<VechileAttributeModifier, double> <>f__am$cache0;

	// Token: 0x0400334E RID: 13134
	[CompilerGenerated]
	private static Func<JourneyContributionModifier, double> <>f__am$cache1;

	// Token: 0x02001006 RID: 4102
	[CompilerGenerated]
	private sealed class <IsInTravel>c__AnonStorey0
	{
		// Token: 0x060067CC RID: 26572 RVA: 0x001B96D1 File Offset: 0x001B7AD1
		public <IsInTravel>c__AnonStorey0()
		{
		}

		// Token: 0x060067CD RID: 26573 RVA: 0x001B96D9 File Offset: 0x001B7AD9
		internal bool <>m__0(TripRecord t)
		{
			return !t.Completed && t.Travellers.Any((ITraveller v) => v.GetId() == this.traveller.GetId());
		}

		// Token: 0x060067CE RID: 26574 RVA: 0x001B9700 File Offset: 0x001B7B00
		internal bool <>m__1(Vehicle v)
		{
			return v.Travellers.Any((ITraveller tv) => tv.GetId() == this.traveller.GetId());
		}

		// Token: 0x060067CF RID: 26575 RVA: 0x001B9719 File Offset: 0x001B7B19
		internal bool <>m__2(ITraveller v)
		{
			return v.GetId() == this.traveller.GetId();
		}

		// Token: 0x060067D0 RID: 26576 RVA: 0x001B9731 File Offset: 0x001B7B31
		internal bool <>m__3(ITraveller tv)
		{
			return tv.GetId() == this.traveller.GetId();
		}

		// Token: 0x040061D0 RID: 25040
		internal ITraveller traveller;
	}

	// Token: 0x02001007 RID: 4103
	[CompilerGenerated]
	private sealed class <GetValue>c__AnonStorey1
	{
		// Token: 0x060067D1 RID: 26577 RVA: 0x001B9749 File Offset: 0x001B7B49
		public <GetValue>c__AnonStorey1()
		{
		}

		// Token: 0x060067D2 RID: 26578 RVA: 0x001B9751 File Offset: 0x001B7B51
		internal bool <>m__0(VechileAttributeModifier s)
		{
			return s.AttributeType == this.type;
		}

		// Token: 0x040061D1 RID: 25041
		internal VehicleAttributeType type;
	}

	// Token: 0x02001008 RID: 4104
	[CompilerGenerated]
	private sealed class <GetValue>c__AnonStorey2
	{
		// Token: 0x060067D3 RID: 26579 RVA: 0x001B9761 File Offset: 0x001B7B61
		public <GetValue>c__AnonStorey2()
		{
		}

		// Token: 0x060067D4 RID: 26580 RVA: 0x001B9769 File Offset: 0x001B7B69
		internal bool <>m__0(JourneyContributionModifier s)
		{
			return s.Type == this.type;
		}

		// Token: 0x040061D2 RID: 25042
		internal JourneyContributeType type;
	}
}
