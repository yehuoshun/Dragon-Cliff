using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002D7 RID: 727
public class TooltipController : MonoBehaviour, ITooltip
{
	// Token: 0x06001353 RID: 4947 RVA: 0x000A243B File Offset: 0x000A083B
	public TooltipController()
	{
	}

	// Token: 0x06001354 RID: 4948 RVA: 0x000A2443 File Offset: 0x000A0843
	private void Awake()
	{
		this._canvas = base.GetComponentInParent<Canvas>();
	}

	// Token: 0x06001355 RID: 4949 RVA: 0x000A2451 File Offset: 0x000A0851
	private void Update()
	{
		if (base.gameObject.activeSelf && this._overflowFixQuatar > 0)
		{
			this.FixOverflow();
		}
	}

	// Token: 0x06001356 RID: 4950 RVA: 0x000A2475 File Offset: 0x000A0875
	public void Hide()
	{
		base.gameObject.SetActive(false);
		this.SecondPanel.gameObject.SetActive(false);
	}

	// Token: 0x06001357 RID: 4951 RVA: 0x000A2494 File Offset: 0x000A0894
	public void DisplayContentInCorner(TooltipItem item, TooltipItem secondItem, TooltipPosition tooltipPosition, float widthOffset, float heightOffset)
	{
		this.AssignValues(item);
		RectTransform component = base.GetComponent<RectTransform>();
		Vector2 pivot = default(Vector2);
		Vector3 positionOffset = default(Vector3);
		Vector3 a = default(Vector3);
		Rect rect = this._canvas.GetComponent<RectTransform>().rect;
		float scaleFactor = this._canvas.scaleFactor;
		float width = rect.width;
		float height = rect.height;
		switch (tooltipPosition)
		{
		case TooltipPosition.BottomLeft:
			pivot = new Vector2(0f, 0f);
			positionOffset = Vector3.right * component.rect.width;
			a = new Vector3(widthOffset, heightOffset, 0f);
			break;
		case TooltipPosition.TopLeft:
			pivot = new Vector2(0f, 1f);
			positionOffset = Vector3.right * component.rect.width;
			a = new Vector3(widthOffset, height + heightOffset, 0f);
			break;
		case TooltipPosition.BottomRight:
			pivot = new Vector2(1f, 0f);
			positionOffset = Vector3.left * component.rect.width;
			a = new Vector3(width + widthOffset, heightOffset, 0f);
			break;
		case TooltipPosition.TopRight:
			pivot = new Vector2(1f, 1f);
			positionOffset = Vector3.left * component.rect.width;
			a = new Vector3(width + widthOffset, height + heightOffset, 0f);
			break;
		}
		this.DisplaySecondPanel(item, secondItem, tooltipPosition, 0f, positionOffset);
		component.pivot = pivot;
		base.transform.position = a * scaleFactor;
		this._overflowFixQuatar = 1;
	}

	// Token: 0x06001358 RID: 4952 RVA: 0x000A2654 File Offset: 0x000A0A54
	public void DisplayContent(TooltipItem item, TooltipItem secondItem)
	{
		this.AssignValues(item);
		RectTransform component = base.GetComponent<RectTransform>();
		Vector2 pivot = default(Vector2);
		Vector3 positionOffset = default(Vector3);
		float num = 0.07f;
		TooltipPosition tooltipPosition = this.CalculatePivot();
		switch (tooltipPosition)
		{
		case TooltipPosition.BottomLeft:
			pivot = new Vector2(0f - num, 0f);
			positionOffset = Vector3.right * component.rect.width;
			break;
		case TooltipPosition.TopLeft:
			pivot = new Vector2(0f - num, 1f);
			positionOffset = Vector3.right * component.rect.width;
			break;
		case TooltipPosition.BottomRight:
			pivot = new Vector2(1f + num, 0f);
			positionOffset = Vector3.left * component.rect.width;
			break;
		case TooltipPosition.TopRight:
			pivot = new Vector2(1f + num, 1f);
			positionOffset = Vector3.left * component.rect.width;
			break;
		}
		this.DisplaySecondPanel(item, secondItem, tooltipPosition, num, positionOffset);
		component.pivot = pivot;
		base.transform.position = item.Position;
		this._overflowFixQuatar = 1;
	}

	// Token: 0x06001359 RID: 4953 RVA: 0x000A27A0 File Offset: 0x000A0BA0
	private void AssignValues(TooltipItem item)
	{
		if (item.TitleColor.a != 0f)
		{
			this.Type.color = item.TitleColor;
		}
		else
		{
			this.Type.color = Color.white;
		}
		this.TitlePanel.SetActive(!string.IsNullOrEmpty(item.Type) || !(item.Image == null));
		this.Title.text = item.Title;
		this.Description.text = item.Description.Replace("\n", "<size=4>\n</size>");
		this.Description2.text = ((item.Description2 == null) ? string.Empty : item.Description2.Replace("\n", "<size=4>\n</size>"));
		this.Type.text = item.Type;
		this.Value.text = item.Value;
		this.Level.text = item.Level;
		this.PowerLevel.text = item.PowerLevel;
		this.PrimaryNumber.text = item.PrimaryNumber;
		if (item.Image != null)
		{
			this.ItemImage.transform.parent.gameObject.SetActive(true);
			this.ItemImage.sprite = item.Image;
			if (item.BackgroundImage != null)
			{
				this.ItemBackground.sprite = item.BackgroundImage;
			}
			else
			{
				this.ItemBackground.sprite = FilePath.GetItemGradeBackground(QualityGrade.Normal, false);
			}
		}
		else
		{
			this.ItemImage.transform.parent.gameObject.SetActive(false);
		}
		this.ResetIconContainer();
		List<Sprite> icons = item.Icons;
		if (icons != null)
		{
			for (int i = 0; i < icons.Count; i++)
			{
				Sprite childSprite = null;
				if (item.InnerIcons != null && item.InnerIcons.Count > i)
				{
					childSprite = item.InnerIcons[i];
				}
				TooltipIconController tooltipIconController = UnityEngine.Object.Instantiate<TooltipIconController>(this.IconPre);
				tooltipIconController.Init(icons[i], childSprite);
				tooltipIconController.transform.SetParent(this.IconContainer, false);
			}
		}
		this.Title.gameObject.SetActive(!string.IsNullOrEmpty(item.Title));
		this.Description.gameObject.SetActive(!string.IsNullOrEmpty(item.Description));
		this.Description2.gameObject.SetActive(!string.IsNullOrEmpty(item.Description2));
		this.Value.gameObject.SetActive(!string.IsNullOrEmpty(item.Value));
		this.Level.gameObject.SetActive(!string.IsNullOrEmpty(item.Level));
		this.PowerLevel.gameObject.SetActive(!string.IsNullOrEmpty(item.PowerLevel));
		this.PrimaryNumber.gameObject.SetActive(!string.IsNullOrEmpty(item.PrimaryNumber));
		this.IconContainer.gameObject.SetActive(icons != null);
		this.TypeIcon.gameObject.SetActive(item.ShowTypeIcon);
	}

	// Token: 0x0600135A RID: 4954 RVA: 0x000A2AEC File Offset: 0x000A0EEC
	private void DisplaySecondPanel(TooltipItem item, TooltipItem secondItem, TooltipPosition tooltipPosition, float pivotOffset, Vector3 positionOffset)
	{
		this.SecondPanel.gameObject.SetActive(secondItem != null);
		if (secondItem != null)
		{
			this._isSecondPanelActive = true;
			RectTransform component = this.SecondPanel.GetComponent<RectTransform>();
			Vector2 pivot = default(Vector2);
			switch (tooltipPosition)
			{
			case TooltipPosition.BottomLeft:
				pivot = new Vector2(0f - pivotOffset, 0f);
				break;
			case TooltipPosition.TopLeft:
				pivot = new Vector2(0f - pivotOffset, 1f);
				break;
			case TooltipPosition.BottomRight:
				pivot = new Vector2(1f + pivotOffset, 0f);
				break;
			case TooltipPosition.TopRight:
				pivot = new Vector2(1f + pivotOffset, 1f);
				break;
			}
			component.pivot = pivot;
			this.SecondPanel.transform.position = item.Position + positionOffset * this._canvas.scaleFactor;
			this.SecondPanel.DisplaySubTooltip(secondItem);
		}
		else
		{
			this._isSecondPanelActive = false;
		}
	}

	// Token: 0x0600135B RID: 4955 RVA: 0x000A2C00 File Offset: 0x000A1000
	private void FixOverflow()
	{
		Rect screenRect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
		Vector3[] array = new Vector3[4];
		Vector3[] array2 = new Vector3[4];
		base.GetComponent<RectTransform>().GetWorldCorners(array);
		this.SecondPanel.GetComponent<RectTransform>().GetWorldCorners(array2);
		List<Vector3> source = (from corner in array
		where !screenRect.Contains(corner)
		select corner).ToList<Vector3>();
		List<Vector3> source2 = (from corner in array2
		where !screenRect.Contains(corner)
		select corner).ToList<Vector3>();
		Vector3 lhs = source.FirstOrDefault((Vector3 c) => c.x < 0f);
		Vector3 lhs2 = source.FirstOrDefault((Vector3 c) => c.x > (float)Screen.width);
		Vector3 lhs3 = source.FirstOrDefault((Vector3 c) => c.y < 0f);
		Vector3 lhs4 = source.FirstOrDefault((Vector3 c) => c.y > (float)Screen.height);
		if (lhs != Vector3.zero)
		{
			Vector3 b = Vector3.right * -lhs.x;
			base.transform.position += b;
		}
		if (lhs2 != Vector3.zero)
		{
			Vector3 b2 = Vector3.left * (lhs2.x - (float)Screen.width);
			base.transform.position += b2;
		}
		if (lhs3 != Vector3.zero)
		{
			base.transform.position += Vector3.up * -lhs3.y;
		}
		if (lhs4 != Vector3.zero)
		{
			base.transform.position += Vector3.down * (lhs4.y - (float)Screen.height);
		}
		Vector3 lhs5 = source2.FirstOrDefault((Vector3 c) => c.x < 0f);
		Vector3 lhs6 = source2.FirstOrDefault((Vector3 c) => c.x > (float)Screen.width);
		Vector3 lhs7 = source2.FirstOrDefault((Vector3 c) => c.y < 0f);
		Vector3 lhs8 = source2.FirstOrDefault((Vector3 c) => c.y > (float)Screen.height);
		if (lhs5 != Vector3.zero)
		{
			Vector3 b3 = Vector3.right * -lhs5.x;
			base.transform.position += b3;
			this.SecondPanel.transform.position += b3;
		}
		if (lhs6 != Vector3.zero)
		{
			Vector3 b4 = Vector3.left * (lhs6.x - (float)Screen.width);
			base.transform.position += b4;
			this.SecondPanel.transform.position += b4;
		}
		if (lhs7 != Vector3.zero)
		{
			this.SecondPanel.transform.position += Vector3.up * -lhs7.y;
		}
		if (lhs8 != Vector3.zero)
		{
			this.SecondPanel.transform.position += Vector3.down * (lhs8.y - (float)Screen.height);
		}
		this._overflowFixQuatar--;
	}

	// Token: 0x0600135C RID: 4956 RVA: 0x000A3000 File Offset: 0x000A1400
	private void ResetIconContainer()
	{
		IEnumerator enumerator = this.IconContainer.GetEnumerator();
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
	}

	// Token: 0x0600135D RID: 4957 RVA: 0x000A306C File Offset: 0x000A146C
	[CompilerGenerated]
	private static bool <FixOverflow>m__0(Vector3 c)
	{
		return c.x < 0f;
	}

	// Token: 0x0600135E RID: 4958 RVA: 0x000A307C File Offset: 0x000A147C
	[CompilerGenerated]
	private static bool <FixOverflow>m__1(Vector3 c)
	{
		return c.x > (float)Screen.width;
	}

	// Token: 0x0600135F RID: 4959 RVA: 0x000A308D File Offset: 0x000A148D
	[CompilerGenerated]
	private static bool <FixOverflow>m__2(Vector3 c)
	{
		return c.y < 0f;
	}

	// Token: 0x06001360 RID: 4960 RVA: 0x000A309D File Offset: 0x000A149D
	[CompilerGenerated]
	private static bool <FixOverflow>m__3(Vector3 c)
	{
		return c.y > (float)Screen.height;
	}

	// Token: 0x06001361 RID: 4961 RVA: 0x000A30AE File Offset: 0x000A14AE
	[CompilerGenerated]
	private static bool <FixOverflow>m__4(Vector3 c)
	{
		return c.x < 0f;
	}

	// Token: 0x06001362 RID: 4962 RVA: 0x000A30BE File Offset: 0x000A14BE
	[CompilerGenerated]
	private static bool <FixOverflow>m__5(Vector3 c)
	{
		return c.x > (float)Screen.width;
	}

	// Token: 0x06001363 RID: 4963 RVA: 0x000A30CF File Offset: 0x000A14CF
	[CompilerGenerated]
	private static bool <FixOverflow>m__6(Vector3 c)
	{
		return c.y < 0f;
	}

	// Token: 0x06001364 RID: 4964 RVA: 0x000A30DF File Offset: 0x000A14DF
	[CompilerGenerated]
	private static bool <FixOverflow>m__7(Vector3 c)
	{
		return c.y > (float)Screen.height;
	}

	// Token: 0x040013D8 RID: 5080
	public Image ItemBackground;

	// Token: 0x040013D9 RID: 5081
	public Image ItemImage;

	// Token: 0x040013DA RID: 5082
	public GameObject TitlePanel;

	// Token: 0x040013DB RID: 5083
	public TextMeshProUGUI Title;

	// Token: 0x040013DC RID: 5084
	public TextMeshProUGUI Type;

	// Token: 0x040013DD RID: 5085
	public TextMeshProUGUI Description;

	// Token: 0x040013DE RID: 5086
	public TextMeshProUGUI Description2;

	// Token: 0x040013DF RID: 5087
	public TextMeshProUGUI Value;

	// Token: 0x040013E0 RID: 5088
	public TextMeshProUGUI PrimaryNumber;

	// Token: 0x040013E1 RID: 5089
	public TextMeshProUGUI Level;

	// Token: 0x040013E2 RID: 5090
	public TextMeshProUGUI PowerLevel;

	// Token: 0x040013E3 RID: 5091
	public SubTooltipController SecondPanel;

	// Token: 0x040013E4 RID: 5092
	public Transform IconContainer;

	// Token: 0x040013E5 RID: 5093
	public TooltipIconController IconPre;

	// Token: 0x040013E6 RID: 5094
	public GameObject TypeIcon;

	// Token: 0x040013E7 RID: 5095
	private Canvas _canvas;

	// Token: 0x040013E8 RID: 5096
	private bool _isSecondPanelActive;

	// Token: 0x040013E9 RID: 5097
	private int _overflowFixQuatar;

	// Token: 0x040013EA RID: 5098
	[CompilerGenerated]
	private static Func<Vector3, bool> <>f__am$cache0;

	// Token: 0x040013EB RID: 5099
	[CompilerGenerated]
	private static Func<Vector3, bool> <>f__am$cache1;

	// Token: 0x040013EC RID: 5100
	[CompilerGenerated]
	private static Func<Vector3, bool> <>f__am$cache2;

	// Token: 0x040013ED RID: 5101
	[CompilerGenerated]
	private static Func<Vector3, bool> <>f__am$cache3;

	// Token: 0x040013EE RID: 5102
	[CompilerGenerated]
	private static Func<Vector3, bool> <>f__am$cache4;

	// Token: 0x040013EF RID: 5103
	[CompilerGenerated]
	private static Func<Vector3, bool> <>f__am$cache5;

	// Token: 0x040013F0 RID: 5104
	[CompilerGenerated]
	private static Func<Vector3, bool> <>f__am$cache6;

	// Token: 0x040013F1 RID: 5105
	[CompilerGenerated]
	private static Func<Vector3, bool> <>f__am$cache7;

	// Token: 0x02000C71 RID: 3185
	[CompilerGenerated]
	private sealed class <FixOverflow>c__AnonStorey0
	{
		// Token: 0x060052F1 RID: 21233 RVA: 0x000A30F0 File Offset: 0x000A14F0
		public <FixOverflow>c__AnonStorey0()
		{
		}

		// Token: 0x060052F2 RID: 21234 RVA: 0x000A30F8 File Offset: 0x000A14F8
		internal bool <>m__0(Vector3 corner)
		{
			return !this.screenRect.Contains(corner);
		}

		// Token: 0x060052F3 RID: 21235 RVA: 0x000A3109 File Offset: 0x000A1509
		internal bool <>m__1(Vector3 corner)
		{
			return !this.screenRect.Contains(corner);
		}

		// Token: 0x040040A2 RID: 16546
		internal Rect screenRect;
	}
}
