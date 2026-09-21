using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000479 RID: 1145
[Serializable]
public class RecruitmentFacility : IBuildingProfile
{
	// Token: 0x06002074 RID: 8308 RVA: 0x000E1574 File Offset: 0x000DF974
	public RecruitmentFacility()
	{
	}

	// Token: 0x06002075 RID: 8309 RVA: 0x000E157C File Offset: 0x000DF97C
	public void ResetCandidates()
	{
		this.Candidates = new List<AdventurerCandidate>();
	}

	// Token: 0x06002076 RID: 8310 RVA: 0x000E1589 File Offset: 0x000DF989
	public int GetRollPointsRequired()
	{
		if (this.CurrentNumberOfRerolls != null)
		{
			return this.CurrentNumberOfRerolls.Value * RecruitmentFacility.PointsIncrementPerAdd + RecruitmentFacility.BasePointsRequiredForAddNew;
		}
		this.CurrentNumberOfRerolls = new int?(0);
		return RecruitmentFacility.BasePointsRequiredForAddNew;
	}

	// Token: 0x06002077 RID: 8311 RVA: 0x000E15C4 File Offset: 0x000DF9C4
	public bool CanGetNewAdventurer()
	{
		return GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.PracticePoints) >= (double)this.GetRollPointsRequired();
	}

	// Token: 0x06002078 RID: 8312 RVA: 0x000E15E6 File Offset: 0x000DF9E6
	public void RefreshNewAdventurer()
	{
		if (this.CanGetNewAdventurer())
		{
			GameWorld.instance.PlayerProfile.RunPredictable("refreshadventurer", delegate
			{
				this.RefreshLogic();
			});
		}
	}

	// Token: 0x06002079 RID: 8313 RVA: 0x000E1614 File Offset: 0x000DFA14
	private void RefreshLogic()
	{
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.PracticePoints,
				ChangeAmount = (double)(-(double)this.GetRollPointsRequired()),
				RelatedItems = new List<Item>()
			}
		});
		int? currentNumberOfRerolls = this.CurrentNumberOfRerolls;
		this.CurrentNumberOfRerolls = ((currentNumberOfRerolls == null) ? null : new int?(currentNumberOfRerolls.GetValueOrDefault() + 1));
		this.Candidates.AddRange(RecruitmentFacility.GenerateProfiles(1, (!GameWorld.instance.PlayerProfile.GetEnabledStars().Any((int s) => s == 2)) ? 0.0 : 0.1));
		this.OnCandidatesRenewed(this.Candidates);
	}

	// Token: 0x0600207A RID: 8314 RVA: 0x000E1704 File Offset: 0x000DFB04
	public void AddCandidates(List<AdventurerCandidate> candidates)
	{
		this.Candidates.AddRange(candidates);
		this.OnCandidatesRenewed(this.Candidates);
	}

	// Token: 0x1700021A RID: 538
	// (get) Token: 0x0600207B RID: 8315 RVA: 0x000E171E File Offset: 0x000DFB1E
	public BuildingType BuildingType
	{
		get
		{
			return BuildingType.RecruitmentFacility;
		}
	}

	// Token: 0x0600207C RID: 8316 RVA: 0x000E1721 File Offset: 0x000DFB21
	public void RefreshCandidates(int numberOfGenerations, double starChance)
	{
		this.Candidates.AddRange(RecruitmentFacility.GenerateProfiles(numberOfGenerations, starChance));
		this.OnCandidatesRenewed(this.Candidates);
	}

	// Token: 0x0600207D RID: 8317 RVA: 0x000E1741 File Offset: 0x000DFB41
	public List<AdventurerCandidate> GetCandidates()
	{
		if (this.Candidates == null)
		{
			return new List<AdventurerCandidate>();
		}
		return this.Candidates;
	}

	// Token: 0x0600207E RID: 8318 RVA: 0x000E175A File Offset: 0x000DFB5A
	public bool CanPurchase(AdventurerProfile candidate)
	{
		return this.HaveEnoughMoneyToPurchase(candidate) && GameWorld.instance.PlayerProfile.GetMaxNumberOfAdventurers() > GameWorld.instance.PlayerProfile.AdventurerProfiles.Count;
	}

	// Token: 0x0600207F RID: 8319 RVA: 0x000E1790 File Offset: 0x000DFB90
	public bool HaveEnoughMoneyToPurchase(AdventurerProfile candidate)
	{
		return this.GetCandidatePrice(candidate) <= GameWorld.instance.PlayerProfile.GetMoney();
	}

	// Token: 0x06002080 RID: 8320 RVA: 0x000E17B0 File Offset: 0x000DFBB0
	public double GetCandidatePrice(AdventurerProfile candidate)
	{
		if (this.GetCandidates().Any((AdventurerCandidate c) => c.Profile == candidate))
		{
			return (double)(candidate.UnitClass.GetConfiguration().RecruitmentPriceRaw * (int)candidate.Grade);
		}
		return double.MaxValue;
	}

	// Token: 0x06002081 RID: 8321 RVA: 0x000E1814 File Offset: 0x000DFC14
	public void Purchase(AdventurerProfile candidate)
	{
		if (this.GetCandidates().Any((AdventurerCandidate c) => c.Profile == candidate) && this.CanPurchase(candidate))
		{
			double changeAmount = -this.GetCandidatePrice(candidate);
			AdventurerCandidate item = this.GetCandidates().FirstOrDefault((AdventurerCandidate c) => c.Profile == candidate);
			this.Candidates.Remove(item);
			GameWorld.instance.PlayerProfile.AddAdventurer(candidate);
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.Money,
					RelatedItems = new List<Item>(),
					ChangeAmount = changeAmount
				}
			});
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventurerPurchased, candidate);
			this.OnCandidatesRenewed(this.Candidates);
		}
	}

	// Token: 0x06002082 RID: 8322 RVA: 0x000E190C File Offset: 0x000DFD0C
	public List<UnitClass> GetPossibleCandidates()
	{
		return (from u in UnitExtensions.UnitConfigurations
		select u.Value into p
		where GameWorld.instance.PlayerProfile.AdventurerTypeObtained(p.CorrespondingUnitClass)
		select p into u
		select u.CorrespondingUnitClass).ToList<UnitClass>();
	}

	// Token: 0x06002083 RID: 8323 RVA: 0x000E198C File Offset: 0x000DFD8C
	public static List<AdventurerCandidate> GenerateProfiles(int numberOfCandidates, double starChance)
	{
		List<AdventurerCandidate> list = new List<AdventurerCandidate>();
		List<RecruitmentCandidatePresence> possibilities = (from u in UnitExtensions.UnitConfigurations
		select u.Value.RecruitmentPresence into p
		where GameWorld.instance.PlayerProfile.AdventurerTypeObtained(p.UnitClass)
		select p).ToList<RecruitmentCandidatePresence>();
		for (int i = 0; i < numberOfCandidates; i++)
		{
			list.Add(new AdventurerCandidate
			{
				Profile = Possibility<RecruitmentCandidatePresence>.Select(possibilities).UnitClass.RandomGenerateAdventurerProfileWithStarChance(starChance),
				DaysTillExpiration = RecruitmentFacility.AdventurerCandidateExpiration
			});
		}
		return list;
	}

	// Token: 0x1700021B RID: 539
	// (get) Token: 0x06002084 RID: 8324 RVA: 0x000E1A30 File Offset: 0x000DFE30
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x06002085 RID: 8325 RVA: 0x000E1A38 File Offset: 0x000DFE38
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.AdventurerTypeUnloced)
		{
			UnitClass @class = (UnitClass)data;
			this.Candidates.Add(new AdventurerCandidate
			{
				Profile = @class.RandomGenerateAdventurerProfileWithStarChance(0.0),
				DaysTillExpiration = RecruitmentFacility.AdventurerCandidateExpiration
			});
			this.OnCandidatesRenewed(this.Candidates);
		}
		if (evt == GameWorldEvent.GameDaysChanged)
		{
			this.NumberOfDaysTillRefresh--;
			if (this.NumberOfDaysTillRefresh <= 0)
			{
				this.RefreshCandidates(GameWorld.instance.PlayerProfile.GetNumberOfRefreshAdventurers(), (!GameWorld.instance.PlayerProfile.GetEnabledStars().Any((int s) => s == 2)) ? 0.0 : 0.5);
				this.NumberOfDaysTillRefresh = PlayerProfile.RecruitmentRefreshDays;
				this.CurrentNumberOfRerolls = new int?(0);
			}
			foreach (AdventurerCandidate adventurerCandidate in this.Candidates)
			{
				adventurerCandidate.DaysTillExpiration--;
			}
			bool flag = this.Candidates.Any((AdventurerCandidate c) => c.DaysTillExpiration <= 0);
			this.Candidates = (from c in this.Candidates
			where c.DaysTillExpiration > 0
			select c).ToList<AdventurerCandidate>();
			if (flag)
			{
				this.OnCandidatesRenewed(this.Candidates);
			}
		}
	}

	// Token: 0x06002086 RID: 8326 RVA: 0x000E1BF4 File Offset: 0x000DFFF4
	protected virtual void OnDaysPasses(float obj)
	{
		Action<float> daysPasses = this.DaysPasses;
		if (daysPasses != null)
		{
			daysPasses(obj);
		}
	}

	// Token: 0x06002087 RID: 8327 RVA: 0x000E1C18 File Offset: 0x000E0018
	public virtual void OnCandidatesRenewed(List<AdventurerCandidate> obj)
	{
		Action<List<AdventurerCandidate>> candidatesListUpdated = this.CandidatesListUpdated;
		if (candidatesListUpdated != null)
		{
			candidatesListUpdated(obj);
		}
	}

	// Token: 0x06002088 RID: 8328 RVA: 0x000E1C39 File Offset: 0x000E0039
	public void Process(float timeDelta)
	{
	}

	// Token: 0x06002089 RID: 8329 RVA: 0x000E1C3B File Offset: 0x000E003B
	// Note: this type is marked as 'beforefieldinit'.
	static RecruitmentFacility()
	{
	}

	// Token: 0x0600208A RID: 8330 RVA: 0x000E1C58 File Offset: 0x000E0058
	[CompilerGenerated]
	private void <RefreshNewAdventurer>m__0()
	{
		this.RefreshLogic();
	}

	// Token: 0x0600208B RID: 8331 RVA: 0x000E1C60 File Offset: 0x000E0060
	[CompilerGenerated]
	private static bool <RefreshLogic>m__1(int s)
	{
		return s == 2;
	}

	// Token: 0x0600208C RID: 8332 RVA: 0x000E1C66 File Offset: 0x000E0066
	[CompilerGenerated]
	private static UnitConfigurationBase <GetPossibleCandidates>m__2(KeyValuePair<UnitClass, UnitConfigurationBase> u)
	{
		return u.Value;
	}

	// Token: 0x0600208D RID: 8333 RVA: 0x000E1C6F File Offset: 0x000E006F
	[CompilerGenerated]
	private static bool <GetPossibleCandidates>m__3(UnitConfigurationBase p)
	{
		return GameWorld.instance.PlayerProfile.AdventurerTypeObtained(p.CorrespondingUnitClass);
	}

	// Token: 0x0600208E RID: 8334 RVA: 0x000E1C86 File Offset: 0x000E0086
	[CompilerGenerated]
	private static UnitClass <GetPossibleCandidates>m__4(UnitConfigurationBase u)
	{
		return u.CorrespondingUnitClass;
	}

	// Token: 0x0600208F RID: 8335 RVA: 0x000E1C8E File Offset: 0x000E008E
	[CompilerGenerated]
	private static RecruitmentCandidatePresence <GenerateProfiles>m__5(KeyValuePair<UnitClass, UnitConfigurationBase> u)
	{
		return u.Value.RecruitmentPresence;
	}

	// Token: 0x06002090 RID: 8336 RVA: 0x000E1C9C File Offset: 0x000E009C
	[CompilerGenerated]
	private static bool <GenerateProfiles>m__6(RecruitmentCandidatePresence p)
	{
		return GameWorld.instance.PlayerProfile.AdventurerTypeObtained(p.UnitClass);
	}

	// Token: 0x06002091 RID: 8337 RVA: 0x000E1CB3 File Offset: 0x000E00B3
	[CompilerGenerated]
	private static bool <ProcessEvent>m__7(int s)
	{
		return s == 2;
	}

	// Token: 0x06002092 RID: 8338 RVA: 0x000E1CB9 File Offset: 0x000E00B9
	[CompilerGenerated]
	private static bool <ProcessEvent>m__8(AdventurerCandidate c)
	{
		return c.DaysTillExpiration <= 0;
	}

	// Token: 0x06002093 RID: 8339 RVA: 0x000E1CC7 File Offset: 0x000E00C7
	[CompilerGenerated]
	private static bool <ProcessEvent>m__9(AdventurerCandidate c)
	{
		return c.DaysTillExpiration > 0;
	}

	// Token: 0x04001CE3 RID: 7395
	public static int AdventurerCandidateExpiration = 20;

	// Token: 0x04001CE4 RID: 7396
	private static int BasePointsRequiredForAddNew = 50000;

	// Token: 0x04001CE5 RID: 7397
	private static int PointsIncrementPerAdd = 25000;

	// Token: 0x04001CE6 RID: 7398
	[NonSerialized]
	public Action<float> DaysPasses;

	// Token: 0x04001CE7 RID: 7399
	[NonSerialized]
	public Action<List<AdventurerCandidate>> CandidatesListUpdated;

	// Token: 0x04001CE8 RID: 7400
	public List<AdventurerCandidate> Candidates;

	// Token: 0x04001CE9 RID: 7401
	public ClassCategory? CurrentRecruitmentOrientation;

	// Token: 0x04001CEA RID: 7402
	public string _id;

	// Token: 0x04001CEB RID: 7403
	public int NumberOfDaysTillRefresh;

	// Token: 0x04001CEC RID: 7404
	[NonSerialized]
	public int? CurrentRollFee;

	// Token: 0x04001CED RID: 7405
	public int? CurrentNumberOfRerolls;

	// Token: 0x04001CEE RID: 7406
	[CompilerGenerated]
	private static Func<int, bool> <>f__am$cache0;

	// Token: 0x04001CEF RID: 7407
	[CompilerGenerated]
	private static Func<KeyValuePair<UnitClass, UnitConfigurationBase>, UnitConfigurationBase> <>f__am$cache1;

	// Token: 0x04001CF0 RID: 7408
	[CompilerGenerated]
	private static Func<UnitConfigurationBase, bool> <>f__am$cache2;

	// Token: 0x04001CF1 RID: 7409
	[CompilerGenerated]
	private static Func<UnitConfigurationBase, UnitClass> <>f__am$cache3;

	// Token: 0x04001CF2 RID: 7410
	[CompilerGenerated]
	private static Func<KeyValuePair<UnitClass, UnitConfigurationBase>, RecruitmentCandidatePresence> <>f__am$cache4;

	// Token: 0x04001CF3 RID: 7411
	[CompilerGenerated]
	private static Func<RecruitmentCandidatePresence, bool> <>f__am$cache5;

	// Token: 0x04001CF4 RID: 7412
	[CompilerGenerated]
	private static Func<int, bool> <>f__am$cache6;

	// Token: 0x04001CF5 RID: 7413
	[CompilerGenerated]
	private static Func<AdventurerCandidate, bool> <>f__am$cache7;

	// Token: 0x04001CF6 RID: 7414
	[CompilerGenerated]
	private static Func<AdventurerCandidate, bool> <>f__am$cache8;

	// Token: 0x02000D25 RID: 3365
	[CompilerGenerated]
	private sealed class <GetCandidatePrice>c__AnonStorey0
	{
		// Token: 0x0600563D RID: 22077 RVA: 0x000E1CD2 File Offset: 0x000E00D2
		public <GetCandidatePrice>c__AnonStorey0()
		{
		}

		// Token: 0x0600563E RID: 22078 RVA: 0x000E1CDA File Offset: 0x000E00DA
		internal bool <>m__0(AdventurerCandidate c)
		{
			return c.Profile == this.candidate;
		}

		// Token: 0x040044C9 RID: 17609
		internal AdventurerProfile candidate;
	}

	// Token: 0x02000D26 RID: 3366
	[CompilerGenerated]
	private sealed class <Purchase>c__AnonStorey1
	{
		// Token: 0x0600563F RID: 22079 RVA: 0x000E1CEA File Offset: 0x000E00EA
		public <Purchase>c__AnonStorey1()
		{
		}

		// Token: 0x06005640 RID: 22080 RVA: 0x000E1CF2 File Offset: 0x000E00F2
		internal bool <>m__0(AdventurerCandidate c)
		{
			return c.Profile == this.candidate;
		}

		// Token: 0x06005641 RID: 22081 RVA: 0x000E1D02 File Offset: 0x000E0102
		internal bool <>m__1(AdventurerCandidate c)
		{
			return c.Profile == this.candidate;
		}

		// Token: 0x040044CA RID: 17610
		internal AdventurerProfile candidate;
	}
}
