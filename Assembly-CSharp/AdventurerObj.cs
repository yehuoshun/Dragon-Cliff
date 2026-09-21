using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200031C RID: 796
public class AdventurerObj : MonoBehaviour
{
	// Token: 0x0600151E RID: 5406 RVA: 0x000A98A9 File Offset: 0x000A7CA9
	public AdventurerObj()
	{
	}

	// Token: 0x17000110 RID: 272
	// (get) Token: 0x0600151F RID: 5407 RVA: 0x000A98BC File Offset: 0x000A7CBC
	// (set) Token: 0x06001520 RID: 5408 RVA: 0x000A98C4 File Offset: 0x000A7CC4
	public bool SelectionState
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectionState>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectionState>k__BackingField = value;
		}
	}

	// Token: 0x06001521 RID: 5409 RVA: 0x000A98CD File Offset: 0x000A7CCD
	public AdventurerProfile GetAdventurerProfile()
	{
		return this.adventurer;
	}

	// Token: 0x06001522 RID: 5410 RVA: 0x000A98D8 File Offset: 0x000A7CD8
	private void Start()
	{
		this.AdventurerGameObject.onClick.AddListener(new UnityAction(this.HandleClick));
		this.CheckBoxButton.onClick.AddListener(new UnityAction(this.AttempToAddToAdventure));
		this.HighlightButton.onClick.AddListener(new UnityAction(this.AttempToAddToAdventure));
		this._highlightImages = this.HighLightImages.ToList<Image>();
	}

	// Token: 0x06001523 RID: 5411 RVA: 0x000A994C File Offset: 0x000A7D4C
	private void Update()
	{
		if (this.SelectionState)
		{
			Image toHighlight = this._highlightImages[GameCounter.instance.HighlightIndex];
			IEnumerable<Image> enumerable = from h in this._highlightImages
			where h != toHighlight
			select h;
			toHighlight.color = Color.yellow;
			foreach (Image image in enumerable)
			{
				image.color = Color.white;
			}
		}
	}

	// Token: 0x06001524 RID: 5412 RVA: 0x000A99F8 File Offset: 0x000A7DF8
	public void Setup(AdventurerProfile currentAdventurer, AdventurerScrollList currentList, float percentage)
	{
		this.adventurerList = currentList;
		this.adventurer = currentAdventurer;
		this.adLevel.text = string.Concat(new object[]
		{
			"Lv: ",
			currentAdventurer.GetLevel(),
			"\n( Exp:",
			currentAdventurer.Experience,
			")"
		});
		this.AdventurerId.text = this.adventurer.GetUnitName();
		List<Skill> skills = currentAdventurer.GetSkills();
		Skill skill = skills.FirstOrDefault((Skill s) => s.CommandType == SkillCommandType.Active);
		if (skill != null)
		{
			this.ActiveSkill.gameObject.SetActive(true);
			this.ActiveSkill.SetAdventurerProfile(currentAdventurer, skill);
		}
		else
		{
			this.ActiveSkill.gameObject.SetActive(false);
		}
		this.SelectionState = false;
		GameObject gameObject = GameObjectCreator.CreateUiHero(currentAdventurer, this.AdventruerAvatar.transform);
		gameObject.transform.position = this.AdventruerAvatar.transform.position;
		base.transform.localScale = Vector3.one;
		this.DisplayInfo.SetDisplayValues(this.adventurer, percentage);
		this.EquimentsControl.SetEquipments(this.adventurer.GetEquipments());
	}

	// Token: 0x06001525 RID: 5413 RVA: 0x000A9B44 File Offset: 0x000A7F44
	public void Highlight()
	{
		this.SetSelectionState(true);
	}

	// Token: 0x06001526 RID: 5414 RVA: 0x000A9B50 File Offset: 0x000A7F50
	private void SetSelectionState(bool active)
	{
		this.SelectionState = active;
		this.HighlightSection.SetActive(active);
		this.SelectionButton.gameObject.SetActive(!active);
		if (active)
		{
			this.SelectionButton.image.sprite = FilePath.GetFillSpriteBaseOnPercentage(1f);
			this.SelectionButton.GetComponentInChildren<Text>().text = "已选择";
		}
		else
		{
			this.SelectionButton.GetComponentInChildren<Text>().text = "选择";
			this.SelectionButton.image.sprite = FilePath.GetFillSpriteBaseOnPercentage(0.1f);
		}
	}

	// Token: 0x06001527 RID: 5415 RVA: 0x000A9BED File Offset: 0x000A7FED
	public void DeHighlight()
	{
		this.SetSelectionState(false);
		this._highlightImages.ForEach(delegate(Image h)
		{
			h.color = Color.white;
		});
	}

	// Token: 0x06001528 RID: 5416 RVA: 0x000A9C1E File Offset: 0x000A801E
	public void AttempToAddToAdventure()
	{
		this.adventurerList.AdventruerToBattle(this);
	}

	// Token: 0x06001529 RID: 5417 RVA: 0x000A9C2C File Offset: 0x000A802C
	public void HandleClick()
	{
		if (this.one_click && Time.time - this.timer_for_double_click > 0.2f)
		{
			this.one_click = false;
		}
		if (!this.one_click)
		{
			this.one_click = true;
			this.timer_for_double_click = Time.time;
		}
		else
		{
			this.one_click = false;
			this.adventurerList.AdventruerToBattle(this);
		}
		this.adventurerList.DisplaySkill(this);
	}

	// Token: 0x0600152A RID: 5418 RVA: 0x000A9CA2 File Offset: 0x000A80A2
	public void NotOnSkillDisplay()
	{
		base.gameObject.GetComponent<Image>().color = Color.white;
	}

	// Token: 0x0600152B RID: 5419 RVA: 0x000A9CB9 File Offset: 0x000A80B9
	public void OnSkillDisplay()
	{
		base.gameObject.GetComponent<Image>().color = Color.yellow;
	}

	// Token: 0x0600152C RID: 5420 RVA: 0x000A9CD0 File Offset: 0x000A80D0
	[CompilerGenerated]
	private static bool <Setup>m__0(Skill s)
	{
		return s.CommandType == SkillCommandType.Active;
	}

	// Token: 0x0600152D RID: 5421 RVA: 0x000A9CDB File Offset: 0x000A80DB
	[CompilerGenerated]
	private static void <DeHighlight>m__1(Image h)
	{
		h.color = Color.white;
	}

	// Token: 0x04001532 RID: 5426
	public Button AdventurerGameObject;

	// Token: 0x04001533 RID: 5427
	public Button CheckBoxButton;

	// Token: 0x04001534 RID: 5428
	public Text AdventurerId;

	// Token: 0x04001535 RID: 5429
	public GameObject AdventruerAvatar;

	// Token: 0x04001536 RID: 5430
	public Text adLevel;

	// Token: 0x04001537 RID: 5431
	public AdventurerAttackOutputSection DisplayInfo;

	// Token: 0x04001538 RID: 5432
	public AdventurerEquipmentsSection EquimentsControl;

	// Token: 0x04001539 RID: 5433
	private AdventurerProfile adventurer;

	// Token: 0x0400153A RID: 5434
	private AdventurerScrollList adventurerList;

	// Token: 0x0400153B RID: 5435
	public GameObject HighlightSection;

	// Token: 0x0400153C RID: 5436
	public Button HighlightButton;

	// Token: 0x0400153D RID: 5437
	public Image[] HighLightImages;

	// Token: 0x0400153E RID: 5438
	public Button SelectionButton;

	// Token: 0x0400153F RID: 5439
	private List<Image> _highlightImages = new List<Image>();

	// Token: 0x04001540 RID: 5440
	public AdventurerSkillController ActiveSkill;

	// Token: 0x04001541 RID: 5441
	private bool one_click;

	// Token: 0x04001542 RID: 5442
	private float timer_for_double_click;

	// Token: 0x04001543 RID: 5443
	private const float delay = 0.2f;

	// Token: 0x04001544 RID: 5444
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <SelectionState>k__BackingField;

	// Token: 0x04001545 RID: 5445
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache0;

	// Token: 0x04001546 RID: 5446
	[CompilerGenerated]
	private static Action<Image> <>f__am$cache1;

	// Token: 0x02000C8D RID: 3213
	[CompilerGenerated]
	private sealed class <Update>c__AnonStorey0
	{
		// Token: 0x0600533B RID: 21307 RVA: 0x000A9CE8 File Offset: 0x000A80E8
		public <Update>c__AnonStorey0()
		{
		}

		// Token: 0x0600533C RID: 21308 RVA: 0x000A9CF0 File Offset: 0x000A80F0
		internal bool <>m__0(Image h)
		{
			return h != this.toHighlight;
		}

		// Token: 0x040040CD RID: 16589
		internal Image toHighlight;
	}
}
