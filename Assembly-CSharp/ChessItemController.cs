using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002E4 RID: 740
public class ChessItemController : MonoBehaviour
{
	// Token: 0x060013A5 RID: 5029 RVA: 0x000A40F3 File Offset: 0x000A24F3
	public ChessItemController()
	{
	}

	// Token: 0x060013A6 RID: 5030 RVA: 0x000A40FC File Offset: 0x000A24FC
	private void OnEnable()
	{
		if (this.LevelItemContainer == null)
		{
			return;
		}
		List<QuestRequirementBase> list = GameWorld.instance.PlayerProfile.GetProgress(null).Quests.SelectMany((Quest q) => from qe in q.QuestRequirements
		where qe.CorrespondingQuestRequirementType == QuestRequirementType.DungeonCompletion || qe.CorrespondingQuestRequirementType == QuestRequirementType.CustomizedDungeonHuntRequirement
		select qe).ToList<QuestRequirementBase>();
		List<int> list2 = new List<int>();
		foreach (QuestRequirementBase questRequirementBase in list)
		{
			if (questRequirementBase is DungeonCompletionRequirementLogic)
			{
				DungeonCompletionRequirementLogic dungeonCompletionRequirementLogic = questRequirementBase as DungeonCompletionRequirementLogic;
				if (dungeonCompletionRequirementLogic.DungeonType == this.AdventureType)
				{
					list2.Add(dungeonCompletionRequirementLogic.LevelNumber);
				}
			}
			else if (questRequirementBase is DungeonExplorationRequirementLogic)
			{
				DungeonExplorationRequirementLogic dungeonExplorationRequirementLogic = questRequirementBase as DungeonExplorationRequirementLogic;
				if (dungeonExplorationRequirementLogic.DungeonType == this.AdventureType)
				{
					list2.Add(dungeonExplorationRequirementLogic.LevelNumber);
				}
			}
			else if (questRequirementBase is CustomizedDungeonThroughRequirementLogic)
			{
				CustomizedDungeonThroughRequirementLogic customizedDungeonThroughRequirementLogic = questRequirementBase as CustomizedDungeonThroughRequirementLogic;
				if (customizedDungeonThroughRequirementLogic.DungeonType == this.AdventureType)
				{
					list2.Add(customizedDungeonThroughRequirementLogic.Configuration.LevelNumber);
				}
			}
		}
		IEnumerator enumerator2 = this.LevelItemContainer.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object obj = enumerator2.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator2 as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		if (this.LevelItemPre != null)
		{
			foreach (int level in list2)
			{
				ChessLevelItemController chessLevelItemController = UnityEngine.Object.Instantiate<ChessLevelItemController>(this.LevelItemPre);
				chessLevelItemController.Init(this.AdventureType, level);
				chessLevelItemController.transform.SetParent(this.LevelItemContainer, false);
			}
		}
	}

	// Token: 0x060013A7 RID: 5031 RVA: 0x000A4330 File Offset: 0x000A2730
	public void MouseOver(AdventureType adventureType)
	{
		if (this.AdventureType == adventureType)
		{
			this.Image.sprite = this.MouseOverSprite;
			this.BottomCircle.color = ColorPicker.White;
		}
	}

	// Token: 0x060013A8 RID: 5032 RVA: 0x000A435F File Offset: 0x000A275F
	public void MouseExit(AdventureType adventureType)
	{
		if (this.AdventureType == adventureType)
		{
			this.Image.sprite = this.NormalSprite;
			this.BottomCircle.color = ColorPicker.White;
		}
	}

	// Token: 0x060013A9 RID: 5033 RVA: 0x000A4390 File Offset: 0x000A2790
	public void Select(AdventureType adventureType)
	{
		if (this.AdventureType == adventureType)
		{
			this.Image.sprite = this.SelectedSprite;
			this.BottomCircle.color = ColorPicker.NagetiveRed;
		}
		else if (base.GetComponent<WorldMapColliderBaseController>().IsEnable)
		{
			this.Image.sprite = this.NormalSprite;
			this.BottomCircle.color = ColorPicker.White;
		}
		else
		{
			this.Image.sprite = this.DisableSprite;
			this.BottomCircle.color = ColorPicker.Grey;
		}
	}

	// Token: 0x060013AA RID: 5034 RVA: 0x000A4426 File Offset: 0x000A2826
	public void EnableChess(AdventureType type)
	{
		if (this.AdventureType == type)
		{
			this.EnableChess();
		}
		else
		{
			this.DisableChess();
		}
	}

	// Token: 0x060013AB RID: 5035 RVA: 0x000A4445 File Offset: 0x000A2845
	public void DisableChess()
	{
		this.Image.sprite = this.DisableSprite;
		this.BottomCircle.color = ColorPicker.Grey;
	}

	// Token: 0x060013AC RID: 5036 RVA: 0x000A4468 File Offset: 0x000A2868
	public void EnableChess()
	{
		this.Image.sprite = this.NormalSprite;
		this.BottomCircle.color = ColorPicker.White;
	}

	// Token: 0x060013AD RID: 5037 RVA: 0x000A448B File Offset: 0x000A288B
	[CompilerGenerated]
	private static IEnumerable<QuestRequirementBase> <OnEnable>m__0(Quest q)
	{
		return from qe in q.QuestRequirements
		where qe.CorrespondingQuestRequirementType == QuestRequirementType.DungeonCompletion || qe.CorrespondingQuestRequirementType == QuestRequirementType.CustomizedDungeonHuntRequirement
		select qe;
	}

	// Token: 0x060013AE RID: 5038 RVA: 0x000A44B5 File Offset: 0x000A28B5
	[CompilerGenerated]
	private static bool <OnEnable>m__1(QuestRequirementBase qe)
	{
		return qe.CorrespondingQuestRequirementType == QuestRequirementType.DungeonCompletion || qe.CorrespondingQuestRequirementType == QuestRequirementType.CustomizedDungeonHuntRequirement;
	}

	// Token: 0x0400141C RID: 5148
	public AdventureType AdventureType;

	// Token: 0x0400141D RID: 5149
	public Image Image;

	// Token: 0x0400141E RID: 5150
	public Sprite SelectedSprite;

	// Token: 0x0400141F RID: 5151
	public Sprite MouseOverSprite;

	// Token: 0x04001420 RID: 5152
	public Sprite NormalSprite;

	// Token: 0x04001421 RID: 5153
	public Sprite DisableSprite;

	// Token: 0x04001422 RID: 5154
	public Image BottomCircle;

	// Token: 0x04001423 RID: 5155
	public Transform LevelItemContainer;

	// Token: 0x04001424 RID: 5156
	public ChessLevelItemController LevelItemPre;

	// Token: 0x04001425 RID: 5157
	[CompilerGenerated]
	private static Func<Quest, IEnumerable<QuestRequirementBase>> <>f__am$cache0;

	// Token: 0x04001426 RID: 5158
	[CompilerGenerated]
	private static Func<QuestRequirementBase, bool> <>f__am$cache1;
}
