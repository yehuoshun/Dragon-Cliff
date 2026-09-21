using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public static class GameConfigurations
{
	// Token: 0x06002240 RID: 8768 RVA: 0x000F9180 File Offset: 0x000F7580
	public static List<ResourceUpdate> GetAdventurerPack()
	{
		return new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.PracticePoints,
				ChangeAmount = 18000.0,
				RelatedItems = new List<Item>()
			}
		};
	}

	// Token: 0x06002241 RID: 8769 RVA: 0x000F91C6 File Offset: 0x000F75C6
	public static bool HasProcessor(this AttributeType type)
	{
		return GameConfigurations.AttributeProcess.ContainsKey(type);
	}

	// Token: 0x06002242 RID: 8770 RVA: 0x000F91D4 File Offset: 0x000F75D4
	public static bool QuestHasBeenIssued(this QuestIdentifier type, int starrating)
	{
		return GameWorld.instance.PlayerProfile.GetProgress(new int?(starrating)).QuestIssuedRecords.ContainsKey(type) && GameWorld.instance.PlayerProfile.GetProgress(new int?(starrating)).QuestIssuedRecords[type] > 0;
	}

	// Token: 0x06002243 RID: 8771 RVA: 0x000F922C File Offset: 0x000F762C
	public static AttributeProcessBase GetProcessor(this AttributeType type)
	{
		return GameConfigurations.AttributeProcess[type];
	}

	// Token: 0x06002244 RID: 8772 RVA: 0x000F923C File Offset: 0x000F763C
	public static double CalculateRate(double original, List<RateModifier> modifiers)
	{
		double num;
		if (modifiers.Any((RateModifier m) => m.RecipeModificationType == ModificationType.Replacement))
		{
			num = modifiers.Last((RateModifier m) => m.RecipeModificationType == ModificationType.Replacement).Value;
		}
		else
		{
			double num2 = (from m in modifiers
			where m.RecipeModificationType == ModificationType.Addition
			select m).Sum((RateModifier a) => a.Value);
			double num3 = (from m in modifiers
			where m.RecipeModificationType == ModificationType.Multiplication
			select m).Sum((RateModifier r) => r.Value) * original;
			num = original + num3 + num2;
		}
		if (num >= 1.0)
		{
			return 1.0;
		}
		if (num <= 0.0)
		{
			return 0.0;
		}
		return num;
	}

	// Token: 0x06002245 RID: 8773 RVA: 0x000F9370 File Offset: 0x000F7770
	private static Type[] GetAllDerivedTypes(this AppDomain aAppDomain, Type aType)
	{
		List<Type> list = new List<Type>();
		Assembly[] assemblies = aAppDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (type.GetInterfaces().Contains(aType) && type.GetConstructor(Type.EmptyTypes) != null)
				{
					list.Add(type);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06002246 RID: 8774 RVA: 0x000F9408 File Offset: 0x000F7808
	private static Type[] GetAllAbstractDerivedTypes(this AppDomain aAppDomain, Type aType)
	{
		List<Type> list = new List<Type>();
		Assembly[] assemblies = aAppDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(aType) && type.GetConstructor(Type.EmptyTypes) != null)
				{
					list.Add(type);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06002247 RID: 8775 RVA: 0x000F94B4 File Offset: 0x000F78B4
	public static List<T> GetImplementationsOfInterface<T>()
	{
		Type[] allDerivedTypes = AppDomain.CurrentDomain.GetAllDerivedTypes(typeof(T));
		List<T> list = new List<T>();
		foreach (Type type in allDerivedTypes)
		{
			T item = (T)((object)Activator.CreateInstance(type));
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06002248 RID: 8776 RVA: 0x000F9514 File Offset: 0x000F7914
	public static List<T> GetImplementationsOfAbstractClass<T>()
	{
		Type[] allAbstractDerivedTypes = AppDomain.CurrentDomain.GetAllAbstractDerivedTypes(typeof(T));
		List<T> list = new List<T>();
		foreach (Type type in allAbstractDerivedTypes)
		{
			T item = (T)((object)Activator.CreateInstance(type));
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06002249 RID: 8777 RVA: 0x000F9574 File Offset: 0x000F7974
	public static void Shuffle<T>(this IList<T> list)
	{
		int i = list.Count;
		while (i > 1)
		{
			i--;
			int index = UnityEngine.Random.Range(0, i + 1);
			T value = list[index];
			list[index] = list[i];
			list[i] = value;
		}
	}

	// Token: 0x0600224A RID: 8778 RVA: 0x000F95C0 File Offset: 0x000F79C0
	// Note: this type is marked as 'beforefieldinit'.
	static GameConfigurations()
	{
	}

	// Token: 0x0600224B RID: 8779 RVA: 0x000F95D8 File Offset: 0x000F79D8
	[CompilerGenerated]
	private static bool <CalculateRate>m__0(RateModifier m)
	{
		return m.RecipeModificationType == ModificationType.Replacement;
	}

	// Token: 0x0600224C RID: 8780 RVA: 0x000F95E3 File Offset: 0x000F79E3
	[CompilerGenerated]
	private static bool <CalculateRate>m__1(RateModifier m)
	{
		return m.RecipeModificationType == ModificationType.Replacement;
	}

	// Token: 0x0600224D RID: 8781 RVA: 0x000F95EE File Offset: 0x000F79EE
	[CompilerGenerated]
	private static bool <CalculateRate>m__2(RateModifier m)
	{
		return m.RecipeModificationType == ModificationType.Addition;
	}

	// Token: 0x0600224E RID: 8782 RVA: 0x000F95F9 File Offset: 0x000F79F9
	[CompilerGenerated]
	private static double <CalculateRate>m__3(RateModifier a)
	{
		return a.Value;
	}

	// Token: 0x0600224F RID: 8783 RVA: 0x000F9601 File Offset: 0x000F7A01
	[CompilerGenerated]
	private static bool <CalculateRate>m__4(RateModifier m)
	{
		return m.RecipeModificationType == ModificationType.Multiplication;
	}

	// Token: 0x06002250 RID: 8784 RVA: 0x000F960C File Offset: 0x000F7A0C
	[CompilerGenerated]
	private static double <CalculateRate>m__5(RateModifier r)
	{
		return r.Value;
	}

	// Token: 0x06002251 RID: 8785 RVA: 0x000F9614 File Offset: 0x000F7A14
	[CompilerGenerated]
	private static AttributeType <AttributeProcess>m__6(AttributeProcessBase process)
	{
		return process.CorrespondingAttributeType;
	}

	// Token: 0x04001DF4 RID: 7668
	public static readonly Dictionary<AttributeType, AttributeProcessBase> AttributeProcess = ItemExtensions.GetDictionaryOfAbastract<AttributeType, AttributeProcessBase>((AttributeProcessBase process) => process.CorrespondingAttributeType);

	// Token: 0x04001DF5 RID: 7669
	[CompilerGenerated]
	private static Func<RateModifier, bool> <>f__am$cache0;

	// Token: 0x04001DF6 RID: 7670
	[CompilerGenerated]
	private static Func<RateModifier, bool> <>f__am$cache1;

	// Token: 0x04001DF7 RID: 7671
	[CompilerGenerated]
	private static Func<RateModifier, bool> <>f__am$cache2;

	// Token: 0x04001DF8 RID: 7672
	[CompilerGenerated]
	private static Func<RateModifier, double> <>f__am$cache3;

	// Token: 0x04001DF9 RID: 7673
	[CompilerGenerated]
	private static Func<RateModifier, bool> <>f__am$cache4;

	// Token: 0x04001DFA RID: 7674
	[CompilerGenerated]
	private static Func<RateModifier, double> <>f__am$cache5;
}
