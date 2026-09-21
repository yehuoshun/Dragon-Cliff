using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000377 RID: 887
public class ResourceUpdatePanelController : MonoBehaviour
{
	// Token: 0x060017BF RID: 6079 RVA: 0x000B70C0 File Offset: 0x000B54C0
	public ResourceUpdatePanelController()
	{
	}

	// Token: 0x060017C0 RID: 6080 RVA: 0x000B70D4 File Offset: 0x000B54D4
	public void Start()
	{
		this._animator = base.GetComponentInParent<Animator>();
		this._animator.SetBool("isHoveredOn", false);
		this.ResourceButton.onClick.AddListener(new UnityAction(this.ViewResourcePanel));
		this.Initialise();
	}

	// Token: 0x060017C1 RID: 6081 RVA: 0x000B7120 File Offset: 0x000B5520
	private void ViewResourcePanel()
	{
		this._isHovered = !this._isHovered;
		this.Open.SetActive(!this._isHovered);
		this.Close.SetActive(this._isHovered);
		this._animator.SetBool("isHoveredOn", this._isHovered);
	}

	// Token: 0x060017C2 RID: 6082 RVA: 0x000B7178 File Offset: 0x000B5578
	public static Dictionary<ResourceCategory, int> GroupByResourceUpdate(List<ResourceUpdate> update)
	{
		IEnumerable<IGrouping<ResourceCategory, ResourceUpdate>> enumerable = from r in update
		group r by r.ResourceType.GetResourceCategory();
		IEnumerable<IGrouping<ResourceCategory, ResourceUpdate>> source = enumerable;
		if (ResourceUpdatePanelController.<>f__mg$cache0 == null)
		{
			ResourceUpdatePanelController.<>f__mg$cache0 = new Func<IGrouping<ResourceCategory, ResourceUpdate>, List<ResourceUpdate>>(Enumerable.ToList<ResourceUpdate>);
		}
		List<List<ResourceUpdate>> list = source.Select(ResourceUpdatePanelController.<>f__mg$cache0).ToList<List<ResourceUpdate>>();
		Dictionary<ResourceCategory, int> dictionary = new Dictionary<ResourceCategory, int>();
		foreach (List<ResourceUpdate> source2 in list)
		{
			double num = source2.Sum((ResourceUpdate a) => a.ChangeAmount);
			ResourceUpdate resourceUpdate = source2.FirstOrDefault<ResourceUpdate>();
			if (resourceUpdate != null)
			{
				ResourceCategory resourceCategory = resourceUpdate.ResourceType.GetResourceCategory();
				dictionary.Add(resourceCategory, (int)num);
			}
		}
		return dictionary;
	}

	// Token: 0x060017C3 RID: 6083 RVA: 0x000B726C File Offset: 0x000B566C
	public void UpdateWithNewlyCollectedResourceUpdate(List<ResourceUpdate> resourceUpdates)
	{
		Dictionary<ResourceCategory, int> dictionary = ResourceUpdatePanelController.GroupByResourceUpdate(resourceUpdates);
		foreach (KeyValuePair<ResourceCategory, int> keyValuePair in dictionary)
		{
			if (keyValuePair.Key == ResourceCategory.Gem)
			{
				int currentDiamondAmount = this._currentDiamondAmount;
				this._currentDiamondAmount += keyValuePair.Value;
				if (base.isActiveAndEnabled)
				{
					base.StartCoroutine(this.TextProCountTo(currentDiamondAmount, this._currentDiamondAmount, this.DiamondAmountTextMesh, keyValuePair.Key));
				}
			}
			if (keyValuePair.Key == ResourceCategory.Hides)
			{
				int currentLeatherAmount = this._currentLeatherAmount;
				this._currentLeatherAmount += keyValuePair.Value;
				if (base.isActiveAndEnabled)
				{
					base.StartCoroutine(this.TextProCountTo(currentLeatherAmount, this._currentLeatherAmount, this.LeatherAmountTextMesh, keyValuePair.Key));
				}
			}
			if (keyValuePair.Key == ResourceCategory.Ore)
			{
				int currentIronAmount = this._currentIronAmount;
				this._currentIronAmount += keyValuePair.Value;
				if (base.isActiveAndEnabled)
				{
					base.StartCoroutine(this.TextProCountTo(currentIronAmount, this._currentIronAmount, this.IronAmountTextMesh, keyValuePair.Key));
				}
			}
			if (keyValuePair.Key == ResourceCategory.Timber)
			{
				int currentWoodAmount = this._currentWoodAmount;
				this._currentWoodAmount += keyValuePair.Value;
				if (base.isActiveAndEnabled)
				{
					base.StartCoroutine(this.TextProCountTo(currentWoodAmount, this._currentWoodAmount, this.WoodAmountTextMesh, keyValuePair.Key));
				}
			}
		}
	}

	// Token: 0x060017C4 RID: 6084 RVA: 0x000B742C File Offset: 0x000B582C
	private IEnumerator TextProCountTo(int previous, int target, TextMeshProUGUI TargetLabel, ResourceCategory cat)
	{
		int start = previous;
		for (float timer = 0f; timer < this.duration; timer += Time.deltaTime)
		{
			float progress = timer / this.duration;
			TargetLabel.color = Color.yellow;
			previous = (int)Mathf.Lerp((float)start, (float)target, progress);
			TargetLabel.text = previous.ToString();
			yield return null;
		}
		TargetLabel.color = Color.white;
		TargetLabel.transform.localScale = Vector3.one;
		switch (cat)
		{
		case ResourceCategory.Gem:
			TargetLabel.text = this._currentDiamondAmount + string.Empty;
			break;
		case ResourceCategory.Ore:
			TargetLabel.text = this._currentIronAmount + string.Empty;
			break;
		case ResourceCategory.Timber:
			TargetLabel.text = this._currentWoodAmount + string.Empty;
			break;
		case ResourceCategory.Hides:
			TargetLabel.text = this._currentLeatherAmount + string.Empty;
			break;
		}
		yield break;
	}

	// Token: 0x060017C5 RID: 6085 RVA: 0x000B7464 File Offset: 0x000B5864
	public void AdventureFinished()
	{
		this.Initialise();
	}

	// Token: 0x060017C6 RID: 6086 RVA: 0x000B746C File Offset: 0x000B586C
	public static bool RandomBool()
	{
		return (double)UnityEngine.Random.Range(0f, 1f) > 0.5;
	}

	// Token: 0x060017C7 RID: 6087 RVA: 0x000B748C File Offset: 0x000B588C
	private void Initialise()
	{
		this.WoodAmountTextMesh.text = "0";
		this.IronAmountTextMesh.text = "0";
		this.DiamondAmountTextMesh.text = "0";
		this.LeatherAmountTextMesh.text = "0";
		this._currentDiamondAmount = 0;
		this._currentIronAmount = 0;
		this._currentLeatherAmount = 0;
		this._currentWoodAmount = 0;
	}

	// Token: 0x060017C8 RID: 6088 RVA: 0x000B74F5 File Offset: 0x000B58F5
	[CompilerGenerated]
	private static ResourceCategory <GroupByResourceUpdate>m__0(ResourceUpdate r)
	{
		return r.ResourceType.GetResourceCategory();
	}

	// Token: 0x060017C9 RID: 6089 RVA: 0x000B7502 File Offset: 0x000B5902
	[CompilerGenerated]
	private static double <GroupByResourceUpdate>m__1(ResourceUpdate a)
	{
		return a.ChangeAmount;
	}

	// Token: 0x04001792 RID: 6034
	public Button ResourceButton;

	// Token: 0x04001793 RID: 6035
	private int _currentWoodAmount;

	// Token: 0x04001794 RID: 6036
	private int _currentIronAmount;

	// Token: 0x04001795 RID: 6037
	private int _currentLeatherAmount;

	// Token: 0x04001796 RID: 6038
	private int _currentDiamondAmount;

	// Token: 0x04001797 RID: 6039
	public TextMeshProUGUI WoodAmountTextMesh;

	// Token: 0x04001798 RID: 6040
	public TextMeshProUGUI IronAmountTextMesh;

	// Token: 0x04001799 RID: 6041
	public TextMeshProUGUI LeatherAmountTextMesh;

	// Token: 0x0400179A RID: 6042
	public TextMeshProUGUI DiamondAmountTextMesh;

	// Token: 0x0400179B RID: 6043
	public GameObject Open;

	// Token: 0x0400179C RID: 6044
	public GameObject Close;

	// Token: 0x0400179D RID: 6045
	private Animator _animator;

	// Token: 0x0400179E RID: 6046
	private bool _isHovered;

	// Token: 0x0400179F RID: 6047
	private float duration = 1f;

	// Token: 0x040017A0 RID: 6048
	[CompilerGenerated]
	private static Func<IGrouping<ResourceCategory, ResourceUpdate>, List<ResourceUpdate>> <>f__mg$cache0;

	// Token: 0x040017A1 RID: 6049
	[CompilerGenerated]
	private static Func<ResourceUpdate, ResourceCategory> <>f__am$cache0;

	// Token: 0x040017A2 RID: 6050
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache1;

	// Token: 0x02000CC1 RID: 3265
	[CompilerGenerated]
	private sealed class <TextProCountTo>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600545C RID: 21596 RVA: 0x000B750A File Offset: 0x000B590A
		[DebuggerHidden]
		public <TextProCountTo>c__Iterator0()
		{
		}

		// Token: 0x0600545D RID: 21597 RVA: 0x000B7514 File Offset: 0x000B5914
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				start = previous;
				timer = 0f;
				break;
			case 1u:
				timer += Time.deltaTime;
				break;
			default:
				return false;
			}
			if (timer < this.duration)
			{
				progress = timer / this.duration;
				TargetLabel.color = Color.yellow;
				previous = (int)Mathf.Lerp((float)start, (float)target, progress);
				TargetLabel.text = previous.ToString();
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}
			TargetLabel.color = Color.white;
			TargetLabel.transform.localScale = Vector3.one;
			switch (cat)
			{
			case ResourceCategory.Gem:
				TargetLabel.text = this._currentDiamondAmount + string.Empty;
				break;
			case ResourceCategory.Ore:
				TargetLabel.text = this._currentIronAmount + string.Empty;
				break;
			case ResourceCategory.Timber:
				TargetLabel.text = this._currentWoodAmount + string.Empty;
				break;
			case ResourceCategory.Hides:
				TargetLabel.text = this._currentLeatherAmount + string.Empty;
				break;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011E6 RID: 4582
		// (get) Token: 0x0600545E RID: 21598 RVA: 0x000B76FF File Offset: 0x000B5AFF
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011E7 RID: 4583
		// (get) Token: 0x0600545F RID: 21599 RVA: 0x000B7707 File Offset: 0x000B5B07
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005460 RID: 21600 RVA: 0x000B770F File Offset: 0x000B5B0F
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005461 RID: 21601 RVA: 0x000B771F File Offset: 0x000B5B1F
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040041CB RID: 16843
		internal int previous;

		// Token: 0x040041CC RID: 16844
		internal int <start>__0;

		// Token: 0x040041CD RID: 16845
		internal float <timer>__1;

		// Token: 0x040041CE RID: 16846
		internal float <progress>__2;

		// Token: 0x040041CF RID: 16847
		internal TextMeshProUGUI TargetLabel;

		// Token: 0x040041D0 RID: 16848
		internal int target;

		// Token: 0x040041D1 RID: 16849
		internal ResourceCategory cat;

		// Token: 0x040041D2 RID: 16850
		internal ResourceUpdatePanelController $this;

		// Token: 0x040041D3 RID: 16851
		internal object $current;

		// Token: 0x040041D4 RID: 16852
		internal bool $disposing;

		// Token: 0x040041D5 RID: 16853
		internal int $PC;
	}
}
