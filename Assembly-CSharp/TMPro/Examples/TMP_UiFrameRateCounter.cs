using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B6E RID: 2926
	public class TMP_UiFrameRateCounter : MonoBehaviour
	{
		// Token: 0x06004D69 RID: 19817 RVA: 0x001F76CE File Offset: 0x001F5ACE
		public TMP_UiFrameRateCounter()
		{
		}

		// Token: 0x06004D6A RID: 19818 RVA: 0x001F76E8 File Offset: 0x001F5AE8
		private void Awake()
		{
			if (!base.enabled)
			{
				return;
			}
			Application.targetFrameRate = 120;
			GameObject gameObject = new GameObject("Frame Counter");
			this.m_frameCounter_transform = gameObject.AddComponent<RectTransform>();
			this.m_frameCounter_transform.SetParent(base.transform, false);
			this.m_TextMeshPro = gameObject.AddComponent<TextMeshProUGUI>();
			this.m_TextMeshPro.font = (Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset);
			this.m_TextMeshPro.fontSharedMaterial = (Resources.Load("Fonts & Materials/LiberationSans SDF - Overlay", typeof(Material)) as Material);
			this.m_TextMeshPro.enableWordWrapping = false;
			this.m_TextMeshPro.fontSize = 36f;
			this.m_TextMeshPro.isOverlay = true;
			this.Set_FrameCounter_Position(this.AnchorPosition);
			this.last_AnchorPosition = this.AnchorPosition;
		}

		// Token: 0x06004D6B RID: 19819 RVA: 0x001F77C5 File Offset: 0x001F5BC5
		private void Start()
		{
			this.m_LastInterval = Time.realtimeSinceStartup;
			this.m_Frames = 0;
		}

		// Token: 0x06004D6C RID: 19820 RVA: 0x001F77DC File Offset: 0x001F5BDC
		private void Update()
		{
			if (this.AnchorPosition != this.last_AnchorPosition)
			{
				this.Set_FrameCounter_Position(this.AnchorPosition);
			}
			this.last_AnchorPosition = this.AnchorPosition;
			this.m_Frames++;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (realtimeSinceStartup > this.m_LastInterval + this.UpdateInterval)
			{
				float num = (float)this.m_Frames / (realtimeSinceStartup - this.m_LastInterval);
				float arg = 1000f / Mathf.Max(num, 1E-05f);
				if (num < 30f)
				{
					this.htmlColorTag = "<color=yellow>";
				}
				else if (num < 10f)
				{
					this.htmlColorTag = "<color=red>";
				}
				else
				{
					this.htmlColorTag = "<color=green>";
				}
				this.m_TextMeshPro.SetText(this.htmlColorTag + "{0:2}</color> FPS \n{1:2} <#8080ff>MS", num, arg);
				this.m_Frames = 0;
				this.m_LastInterval = realtimeSinceStartup;
			}
		}

		// Token: 0x06004D6D RID: 19821 RVA: 0x001F78C8 File Offset: 0x001F5CC8
		private void Set_FrameCounter_Position(TMP_UiFrameRateCounter.FpsCounterAnchorPositions anchor_position)
		{
			switch (anchor_position)
			{
			case TMP_UiFrameRateCounter.FpsCounterAnchorPositions.TopLeft:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.TopLeft;
				this.m_frameCounter_transform.pivot = new Vector2(0f, 1f);
				this.m_frameCounter_transform.anchorMin = new Vector2(0.01f, 0.99f);
				this.m_frameCounter_transform.anchorMax = new Vector2(0.01f, 0.99f);
				this.m_frameCounter_transform.anchoredPosition = new Vector2(0f, 1f);
				break;
			case TMP_UiFrameRateCounter.FpsCounterAnchorPositions.BottomLeft:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.BottomLeft;
				this.m_frameCounter_transform.pivot = new Vector2(0f, 0f);
				this.m_frameCounter_transform.anchorMin = new Vector2(0.01f, 0.01f);
				this.m_frameCounter_transform.anchorMax = new Vector2(0.01f, 0.01f);
				this.m_frameCounter_transform.anchoredPosition = new Vector2(0f, 0f);
				break;
			case TMP_UiFrameRateCounter.FpsCounterAnchorPositions.TopRight:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.TopRight;
				this.m_frameCounter_transform.pivot = new Vector2(1f, 1f);
				this.m_frameCounter_transform.anchorMin = new Vector2(0.99f, 0.99f);
				this.m_frameCounter_transform.anchorMax = new Vector2(0.99f, 0.99f);
				this.m_frameCounter_transform.anchoredPosition = new Vector2(1f, 1f);
				break;
			case TMP_UiFrameRateCounter.FpsCounterAnchorPositions.BottomRight:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.BottomRight;
				this.m_frameCounter_transform.pivot = new Vector2(1f, 0f);
				this.m_frameCounter_transform.anchorMin = new Vector2(0.99f, 0.01f);
				this.m_frameCounter_transform.anchorMax = new Vector2(0.99f, 0.01f);
				this.m_frameCounter_transform.anchoredPosition = new Vector2(1f, 0f);
				break;
			}
		}

		// Token: 0x04003BDE RID: 15326
		public float UpdateInterval = 5f;

		// Token: 0x04003BDF RID: 15327
		private float m_LastInterval;

		// Token: 0x04003BE0 RID: 15328
		private int m_Frames;

		// Token: 0x04003BE1 RID: 15329
		public TMP_UiFrameRateCounter.FpsCounterAnchorPositions AnchorPosition = TMP_UiFrameRateCounter.FpsCounterAnchorPositions.TopRight;

		// Token: 0x04003BE2 RID: 15330
		private string htmlColorTag;

		// Token: 0x04003BE3 RID: 15331
		private const string fpsLabel = "{0:2}</color> FPS \n{1:2} <#8080ff>MS";

		// Token: 0x04003BE4 RID: 15332
		private TextMeshProUGUI m_TextMeshPro;

		// Token: 0x04003BE5 RID: 15333
		private RectTransform m_frameCounter_transform;

		// Token: 0x04003BE6 RID: 15334
		private TMP_UiFrameRateCounter.FpsCounterAnchorPositions last_AnchorPosition;

		// Token: 0x02000B6F RID: 2927
		public enum FpsCounterAnchorPositions
		{
			// Token: 0x04003BE8 RID: 15336
			TopLeft,
			// Token: 0x04003BE9 RID: 15337
			BottomLeft,
			// Token: 0x04003BEA RID: 15338
			TopRight,
			// Token: 0x04003BEB RID: 15339
			BottomRight
		}
	}
}
