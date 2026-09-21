using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

// Token: 0x0200048A RID: 1162
public class TestingProcessor : IFactionProcessor
{
	// Token: 0x0600212E RID: 8494 RVA: 0x000E87BC File Offset: 0x000E6BBC
	public TestingProcessor()
	{
	}

	// Token: 0x1700022B RID: 555
	// (get) Token: 0x0600212F RID: 8495 RVA: 0x000E87C4 File Offset: 0x000E6BC4
	public GameFactionType CorrespondingGameFactionType
	{
		get
		{
			return GameFactionType.Test;
		}
	}

	// Token: 0x06002130 RID: 8496 RVA: 0x000E87C8 File Offset: 0x000E6BC8
	public void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameSessionStarted && TestingProcessor.InTesting)
		{
			GameWorld.instance.PlayerProfile.EndlessRecord.SetCurrentAchievedLevel(5050);
			List<AdventurerProfile> list = (from w in GameWorld.instance.PlayerProfile.AdventurerProfiles
			where w.UnitClass == UnitClass.SnowMaiden
			select w).ToList<AdventurerProfile>();
			foreach (AdventurerProfile adventurerProfile in list)
			{
				adventurerProfile.SpecialEffects.Add(new SnowMaidenStarEffectData
				{
					ExtraRate = 1.0,
					PerLevelRate = 50
				});
			}
			GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in ItemExtensions.GetEnumValues<ResourceType>()
			where r.GetResourceCategory() == ResourceCategory.Device
			select new ResourceUpdate
			{
				ResourceType = r,
				RelatedItems = new List<Item>
				{
					r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
				},
				ChangeAmount = 1.0
			}).ToList<ResourceUpdate>());
			GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in ItemExtensions.GetEnumValues<ResourceType>()
			where r.GetResourceCategory() == ResourceCategory.Device
			select new ResourceUpdate
			{
				ResourceType = r,
				RelatedItems = new List<Item>
				{
					r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
				},
				ChangeAmount = 1.0
			}).ToList<ResourceUpdate>());
			GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in ItemExtensions.GetEnumValues<ResourceType>()
			where r.GetResourceCategory() == ResourceCategory.Device
			select new ResourceUpdate
			{
				ResourceType = r,
				RelatedItems = new List<Item>
				{
					r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
				},
				ChangeAmount = 1.0
			}).ToList<ResourceUpdate>());
			GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in ItemExtensions.GetEnumValues<ResourceType>()
			where r.GetResourceCategory() == ResourceCategory.Device
			select new ResourceUpdate
			{
				ResourceType = r,
				RelatedItems = new List<Item>
				{
					r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
				},
				ChangeAmount = 1.0
			}).ToList<ResourceUpdate>());
			GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in ItemExtensions.GetEnumValues<ResourceType>()
			where r.GetResourceCategory() == ResourceCategory.Device
			select new ResourceUpdate
			{
				ResourceType = r,
				RelatedItems = new List<Item>
				{
					r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
				},
				ChangeAmount = 1.0
			}).ToList<ResourceUpdate>());
			GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in ItemExtensions.GetEnumValues<ResourceType>()
			where r.GetResourceCategory() == ResourceCategory.Device
			select new ResourceUpdate
			{
				ResourceType = r,
				RelatedItems = new List<Item>
				{
					r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
				},
				ChangeAmount = 1.0
			}).ToList<ResourceUpdate>());
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.PrismScope,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.PrismScope.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.RockOfDeerGod,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.RockOfDeerGod.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.TorchOfDeerGod,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.TorchOfDeerGod.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.FragmentOfDemon,
					ChangeAmount = 100000.0,
					RelatedItems = new List<Item>()
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.HeartOfThorns,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.HeartOfThorns.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.EyesOfThorns,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.EyesOfThorns.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.BoneOfThorns,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.BoneOfThorns.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.HatredOfPrince,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.HatredOfPrince.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.LoveOfPrince,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.LoveOfPrince.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.SinOfPrince,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.SinOfPrince.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.DustOfCorruption,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.DustOfCorruption.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.PetalOfCorruption,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.PetalOfCorruption.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.GhostOfCorruption,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.GhostOfCorruption.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.CircleOfFocus,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.CircleOfFocus.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.WheelOfFocus,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.WheelOfFocus.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.SpikeOfFocus,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.SpikeOfFocus.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 5, 1)
					}
				}
			});
			List<UnitClass> list2 = (from a in (from u in UnitExtensions.UnitConfigurations
			select u.Value).OfType<AdventurerUnitConfigurationBase>()
			select a.CorrespondingUnitClass).ToList<UnitClass>();
			foreach (UnitClass @class in list2)
			{
				GameWorld.instance.PlayerProfile.AdventurerProfiles.Add(@class.GenerateAdventurerProfileWithDefinedQuality(8f));
			}
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.ScrollOfExplosion,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.ScrollOfExplosion.ItemGenerate(ResourceSourceType.ScrollCreation, ItemGenerationQuality.CreateStar(), 1, 12)
					}
				}
			});
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.ScrollOfSpellObsorption,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.ScrollOfSpellObsorption.ItemGenerate(ResourceSourceType.ScrollCreation, ItemGenerationQuality.CreateStar(), 1, 12)
					}
				}
			});
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.ScrollOfSwiftness,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.ScrollOfSwiftness.ItemGenerate(ResourceSourceType.ScrollCreation, ItemGenerationQuality.CreateStar(), 1, 12)
					}
				}
			});
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.ScrollOfRage,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.ScrollOfRage.ItemGenerate(ResourceSourceType.ScrollCreation, ItemGenerationQuality.CreateStar(), 1, 12)
					}
				}
			});
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.ScrollOfReflection,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						ResourceType.ScrollOfReflection.ItemGenerate(ResourceSourceType.ScrollCreation, ItemGenerationQuality.CreateStar(), 1, 12)
					}
				}
			});
		}
		if (TestingProcessor.InTesting)
		{
		}
	}

	// Token: 0x06002131 RID: 8497 RVA: 0x000E9314 File Offset: 0x000E7714
	public IEnumerable ProcessBattleEvent(BroadcastEvent evt)
	{
		if (TestingProcessor.InTesting)
		{
			if (evt.EventType == AdventureEventType.UnitReadyInBattle && evt.EventTriggeringUnit.IsPlayer)
			{
				IEnumerator enumerator = evt.EventTriggeringUnit.ApplySkillEffect(new GuiltEffect(1.0, 1.0, 1.0, evt.EventTriggeringUnit), false).GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						yield break;
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
				IEnumerator enumerator2 = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						AttributeType = AttributeType.PhysicalPenetration,
						Key = string.Empty,
						ModificationType = ModificationType.Addition,
						Value = 1.0
					},
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						AttributeType = AttributeType.FirePenetration,
						Key = string.Empty,
						ModificationType = ModificationType.Addition,
						Value = 1.0
					},
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						AttributeType = AttributeType.IcePenetration,
						Key = string.Empty,
						ModificationType = ModificationType.Addition,
						Value = 1.0
					},
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						AttributeType = AttributeType.ShadowPenetration,
						Key = string.Empty,
						ModificationType = ModificationType.Addition,
						Value = 1.0
					},
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						AttributeType = AttributeType.PoisonPenetration,
						Key = string.Empty,
						ModificationType = ModificationType.Addition,
						Value = 1.0
					},
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						AttributeType = AttributeType.DivinePenetration,
						Key = string.Empty,
						ModificationType = ModificationType.Addition,
						Value = 1.0
					},
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						AttributeType = AttributeType.LighteningPenetration,
						Key = string.Empty,
						ModificationType = ModificationType.Addition,
						Value = 1.0
					}
				}, AttributeModificationEffect.PostDamageReleaseRemovePartial + "225", new int?(1), null, null, false, false, false), false).GetEnumerator();
				try
				{
					if (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						yield break;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			if (evt.EventType == AdventureEventType.UnitRegularTurnStarts && evt.EventTriggeringUnit is AdventurerBattleUnit)
			{
				IEnumerator enumerator3 = evt.EventTriggeringUnit.ApplySkillEffect(new FreeCastEffect(evt.EventTriggeringUnit, null, null, 1, "freecast"), false).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _ = enumerator3.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x000E9338 File Offset: 0x000E7738
	public List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.AdventureInitialized,
			AdventureEventType.UnitReadyInBattle,
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002133 RID: 8499 RVA: 0x000E9362 File Offset: 0x000E7762
	// Note: this type is marked as 'beforefieldinit'.
	static TestingProcessor()
	{
	}

	// Token: 0x06002134 RID: 8500 RVA: 0x000E9364 File Offset: 0x000E7764
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__0(AdventurerProfile w)
	{
		return w.UnitClass == UnitClass.SnowMaiden;
	}

	// Token: 0x06002135 RID: 8501 RVA: 0x000E9373 File Offset: 0x000E7773
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__1(ResourceType r)
	{
		return r.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x06002136 RID: 8502 RVA: 0x000E9380 File Offset: 0x000E7780
	[CompilerGenerated]
	private static ResourceUpdate <ProcessGameEvent>m__2(ResourceType r)
	{
		return new ResourceUpdate
		{
			ResourceType = r,
			RelatedItems = new List<Item>
			{
				r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
			},
			ChangeAmount = 1.0
		};
	}

	// Token: 0x06002137 RID: 8503 RVA: 0x000E93CD File Offset: 0x000E77CD
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__3(ResourceType r)
	{
		return r.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x06002138 RID: 8504 RVA: 0x000E93DC File Offset: 0x000E77DC
	[CompilerGenerated]
	private static ResourceUpdate <ProcessGameEvent>m__4(ResourceType r)
	{
		return new ResourceUpdate
		{
			ResourceType = r,
			RelatedItems = new List<Item>
			{
				r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
			},
			ChangeAmount = 1.0
		};
	}

	// Token: 0x06002139 RID: 8505 RVA: 0x000E9429 File Offset: 0x000E7829
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__5(ResourceType r)
	{
		return r.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x0600213A RID: 8506 RVA: 0x000E9438 File Offset: 0x000E7838
	[CompilerGenerated]
	private static ResourceUpdate <ProcessGameEvent>m__6(ResourceType r)
	{
		return new ResourceUpdate
		{
			ResourceType = r,
			RelatedItems = new List<Item>
			{
				r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
			},
			ChangeAmount = 1.0
		};
	}

	// Token: 0x0600213B RID: 8507 RVA: 0x000E9485 File Offset: 0x000E7885
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__7(ResourceType r)
	{
		return r.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x000E9494 File Offset: 0x000E7894
	[CompilerGenerated]
	private static ResourceUpdate <ProcessGameEvent>m__8(ResourceType r)
	{
		return new ResourceUpdate
		{
			ResourceType = r,
			RelatedItems = new List<Item>
			{
				r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
			},
			ChangeAmount = 1.0
		};
	}

	// Token: 0x0600213D RID: 8509 RVA: 0x000E94E1 File Offset: 0x000E78E1
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__9(ResourceType r)
	{
		return r.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x0600213E RID: 8510 RVA: 0x000E94F0 File Offset: 0x000E78F0
	[CompilerGenerated]
	private static ResourceUpdate <ProcessGameEvent>m__A(ResourceType r)
	{
		return new ResourceUpdate
		{
			ResourceType = r,
			RelatedItems = new List<Item>
			{
				r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
			},
			ChangeAmount = 1.0
		};
	}

	// Token: 0x0600213F RID: 8511 RVA: 0x000E953D File Offset: 0x000E793D
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__B(ResourceType r)
	{
		return r.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x06002140 RID: 8512 RVA: 0x000E954C File Offset: 0x000E794C
	[CompilerGenerated]
	private static ResourceUpdate <ProcessGameEvent>m__C(ResourceType r)
	{
		return new ResourceUpdate
		{
			ResourceType = r,
			RelatedItems = new List<Item>
			{
				r.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 25, 1)
			},
			ChangeAmount = 1.0
		};
	}

	// Token: 0x06002141 RID: 8513 RVA: 0x000E9599 File Offset: 0x000E7999
	[CompilerGenerated]
	private static UnitConfigurationBase <ProcessGameEvent>m__D(KeyValuePair<UnitClass, UnitConfigurationBase> u)
	{
		return u.Value;
	}

	// Token: 0x06002142 RID: 8514 RVA: 0x000E95A2 File Offset: 0x000E79A2
	[CompilerGenerated]
	private static UnitClass <ProcessGameEvent>m__E(AdventurerUnitConfigurationBase a)
	{
		return a.CorrespondingUnitClass;
	}

	// Token: 0x04001D40 RID: 7488
	public static bool InTesting;

	// Token: 0x04001D41 RID: 7489
	public static bool UseForceLocalization;

	// Token: 0x04001D42 RID: 7490
	public static bool InDiagnose;

	// Token: 0x04001D43 RID: 7491
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache0;

	// Token: 0x04001D44 RID: 7492
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache1;

	// Token: 0x04001D45 RID: 7493
	[CompilerGenerated]
	private static Func<ResourceType, ResourceUpdate> <>f__am$cache2;

	// Token: 0x04001D46 RID: 7494
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache3;

	// Token: 0x04001D47 RID: 7495
	[CompilerGenerated]
	private static Func<ResourceType, ResourceUpdate> <>f__am$cache4;

	// Token: 0x04001D48 RID: 7496
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache5;

	// Token: 0x04001D49 RID: 7497
	[CompilerGenerated]
	private static Func<ResourceType, ResourceUpdate> <>f__am$cache6;

	// Token: 0x04001D4A RID: 7498
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache7;

	// Token: 0x04001D4B RID: 7499
	[CompilerGenerated]
	private static Func<ResourceType, ResourceUpdate> <>f__am$cache8;

	// Token: 0x04001D4C RID: 7500
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache9;

	// Token: 0x04001D4D RID: 7501
	[CompilerGenerated]
	private static Func<ResourceType, ResourceUpdate> <>f__am$cacheA;

	// Token: 0x04001D4E RID: 7502
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cacheB;

	// Token: 0x04001D4F RID: 7503
	[CompilerGenerated]
	private static Func<ResourceType, ResourceUpdate> <>f__am$cacheC;

	// Token: 0x04001D50 RID: 7504
	[CompilerGenerated]
	private static Func<KeyValuePair<UnitClass, UnitConfigurationBase>, UnitConfigurationBase> <>f__am$cacheD;

	// Token: 0x04001D51 RID: 7505
	[CompilerGenerated]
	private static Func<AdventurerUnitConfigurationBase, UnitClass> <>f__am$cacheE;

	// Token: 0x02000D37 RID: 3383
	[CompilerGenerated]
	private sealed class <ProcessBattleEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600568E RID: 22158 RVA: 0x000E95AA File Offset: 0x000E79AA
		[DebuggerHidden]
		public <ProcessBattleEvent>c__Iterator0()
		{
		}

		// Token: 0x0600568F RID: 22159 RVA: 0x000E95B4 File Offset: 0x000E79B4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!TestingProcessor.InTesting)
				{
					return false;
				}
				if (evt.EventType == AdventureEventType.UnitReadyInBattle && evt.EventTriggeringUnit.IsPlayer)
				{
					IEnumerator enumerator4 = evt.EventTriggeringUnit.ApplySkillEffect(new GuiltEffect(1.0, 1.0, 1.0, evt.EventTriggeringUnit), false).GetEnumerator();
					try
					{
						if (enumerator4.MoveNext())
						{
							object obj = enumerator4.Current;
							return false;
						}
					}
					finally
					{
						IDisposable disposable4;
						if ((disposable4 = (enumerator4 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
					IEnumerator enumerator5 = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.PhysicalPenetration,
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = 1.0
						},
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.FirePenetration,
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = 1.0
						},
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.IcePenetration,
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = 1.0
						},
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.ShadowPenetration,
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = 1.0
						},
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.PoisonPenetration,
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = 1.0
						},
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.DivinePenetration,
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = 1.0
						},
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.LighteningPenetration,
							Key = string.Empty,
							ModificationType = ModificationType.Addition,
							Value = 1.0
						}
					}, AttributeModificationEffect.PostDamageReleaseRemovePartial + "225", new int?(1), null, null, false, false, false), false).GetEnumerator();
					try
					{
						if (enumerator5.MoveNext())
						{
							object obj2 = enumerator5.Current;
							return false;
						}
					}
					finally
					{
						IDisposable disposable5;
						if ((disposable5 = (enumerator5 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				if (evt.EventType != AdventureEventType.UnitRegularTurnStarts || !(evt.EventTriggeringUnit is AdventurerBattleUnit))
				{
					return false;
				}
				enumerator3 = evt.EventTriggeringUnit.ApplySkillEffect(new FreeCastEffect(evt.EventTriggeringUnit, null, null, 1, "freecast"), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_ = enumerator3.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			return false;
		}

		// Token: 0x17001242 RID: 4674
		// (get) Token: 0x06005690 RID: 22160 RVA: 0x000E9A48 File Offset: 0x000E7E48
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001243 RID: 4675
		// (get) Token: 0x06005691 RID: 22161 RVA: 0x000E9A50 File Offset: 0x000E7E50
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005692 RID: 22162 RVA: 0x000E9A58 File Offset: 0x000E7E58
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005693 RID: 22163 RVA: 0x000E9AC8 File Offset: 0x000E7EC8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005694 RID: 22164 RVA: 0x000E9ACF File Offset: 0x000E7ECF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005695 RID: 22165 RVA: 0x000E9AD8 File Offset: 0x000E7ED8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TestingProcessor.<ProcessBattleEvent>c__Iterator0 <ProcessBattleEvent>c__Iterator = new TestingProcessor.<ProcessBattleEvent>c__Iterator0();
			<ProcessBattleEvent>c__Iterator.evt = evt;
			return <ProcessBattleEvent>c__Iterator;
		}

		// Token: 0x04004532 RID: 17714
		internal BroadcastEvent evt;

		// Token: 0x04004533 RID: 17715
		internal IEnumerator $locvar4;

		// Token: 0x04004534 RID: 17716
		internal object <_>__1;

		// Token: 0x04004535 RID: 17717
		internal IDisposable $locvar5;

		// Token: 0x04004536 RID: 17718
		internal object $current;

		// Token: 0x04004537 RID: 17719
		internal bool $disposing;

		// Token: 0x04004538 RID: 17720
		internal int $PC;
	}
}
