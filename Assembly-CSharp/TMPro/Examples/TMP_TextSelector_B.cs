using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples
{
	// Token: 0x02000B6D RID: 2925
	public class TMP_TextSelector_B : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler, IEventSystemHandler
	{
		// Token: 0x06004D5E RID: 19806 RVA: 0x001F6853 File Offset: 0x001F4C53
		public TMP_TextSelector_B()
		{
		}

		// Token: 0x06004D5F RID: 19807 RVA: 0x001F6870 File Offset: 0x001F4C70
		private void Awake()
		{
			this.m_TextMeshPro = base.gameObject.GetComponent<TextMeshProUGUI>();
			this.m_Canvas = base.gameObject.GetComponentInParent<Canvas>();
			if (this.m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				this.m_Camera = null;
			}
			else
			{
				this.m_Camera = this.m_Canvas.worldCamera;
			}
			this.m_TextPopup_RectTransform = UnityEngine.Object.Instantiate<RectTransform>(this.TextPopup_Prefab_01);
			this.m_TextPopup_RectTransform.SetParent(this.m_Canvas.transform, false);
			this.m_TextPopup_TMPComponent = this.m_TextPopup_RectTransform.GetComponentInChildren<TextMeshProUGUI>();
			this.m_TextPopup_RectTransform.gameObject.SetActive(false);
		}

		// Token: 0x06004D60 RID: 19808 RVA: 0x001F6916 File Offset: 0x001F4D16
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D61 RID: 19809 RVA: 0x001F692E File Offset: 0x001F4D2E
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D62 RID: 19810 RVA: 0x001F6946 File Offset: 0x001F4D46
		private void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
			if (obj == this.m_TextMeshPro)
			{
				this.m_cachedMeshInfoVertexData = this.m_TextMeshPro.textInfo.CopyMeshInfoVertexData();
			}
		}

		// Token: 0x06004D63 RID: 19811 RVA: 0x001F6970 File Offset: 0x001F4D70
		private void LateUpdate()
		{
			if (this.isHoveringObject)
			{
				int num = TMP_TextUtilities.FindIntersectingCharacter(this.m_TextMeshPro, Input.mousePosition, this.m_Camera, true);
				if (num == -1 || num != this.m_lastIndex)
				{
					this.RestoreCachedVertexAttributes(this.m_lastIndex);
					this.m_lastIndex = -1;
				}
				if (num != -1 && num != this.m_lastIndex && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
				{
					this.m_lastIndex = num;
					int materialReferenceIndex = this.m_TextMeshPro.textInfo.characterInfo[num].materialReferenceIndex;
					int vertexIndex = this.m_TextMeshPro.textInfo.characterInfo[num].vertexIndex;
					Vector3[] vertices = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].vertices;
					Vector2 v = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
					Vector3 b = v;
					vertices[vertexIndex] -= b;
					vertices[vertexIndex + 1] = vertices[vertexIndex + 1] - b;
					vertices[vertexIndex + 2] = vertices[vertexIndex + 2] - b;
					vertices[vertexIndex + 3] = vertices[vertexIndex + 3] - b;
					float d = 1.5f;
					this.m_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * d);
					vertices[vertexIndex] = this.m_matrix.MultiplyPoint3x4(vertices[vertexIndex]);
					vertices[vertexIndex + 1] = this.m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
					vertices[vertexIndex + 2] = this.m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
					vertices[vertexIndex + 3] = this.m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);
					vertices[vertexIndex] += b;
					vertices[vertexIndex + 1] = vertices[vertexIndex + 1] + b;
					vertices[vertexIndex + 2] = vertices[vertexIndex + 2] + b;
					vertices[vertexIndex + 3] = vertices[vertexIndex + 3] + b;
					Color32 color = new Color32(byte.MaxValue, byte.MaxValue, 192, byte.MaxValue);
					Color32[] colors = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
					colors[vertexIndex] = color;
					colors[vertexIndex + 1] = color;
					colors[vertexIndex + 2] = color;
					colors[vertexIndex + 3] = color;
					TMP_MeshInfo tmp_MeshInfo = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex];
					int dst = vertices.Length - 4;
					tmp_MeshInfo.SwapVertexData(vertexIndex, dst);
					this.m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
				}
				int num2 = TMP_TextUtilities.FindIntersectingWord(this.m_TextMeshPro, Input.mousePosition, this.m_Camera);
				if (this.m_TextPopup_RectTransform != null && this.m_selectedWord != -1 && (num2 == -1 || num2 != this.m_selectedWord))
				{
					TMP_WordInfo tmp_WordInfo = this.m_TextMeshPro.textInfo.wordInfo[this.m_selectedWord];
					for (int i = 0; i < tmp_WordInfo.characterCount; i++)
					{
						int num3 = tmp_WordInfo.firstCharacterIndex + i;
						int materialReferenceIndex2 = this.m_TextMeshPro.textInfo.characterInfo[num3].materialReferenceIndex;
						int vertexIndex2 = this.m_TextMeshPro.textInfo.characterInfo[num3].vertexIndex;
						Color32[] colors2 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex2].colors32;
						Color32 color2 = colors2[vertexIndex2].Tint(1.33333f);
						colors2[vertexIndex2] = color2;
						colors2[vertexIndex2 + 1] = color2;
						colors2[vertexIndex2 + 2] = color2;
						colors2[vertexIndex2 + 3] = color2;
					}
					this.m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
					this.m_selectedWord = -1;
				}
				if (num2 != -1 && num2 != this.m_selectedWord && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
				{
					this.m_selectedWord = num2;
					TMP_WordInfo tmp_WordInfo2 = this.m_TextMeshPro.textInfo.wordInfo[num2];
					for (int j = 0; j < tmp_WordInfo2.characterCount; j++)
					{
						int num4 = tmp_WordInfo2.firstCharacterIndex + j;
						int materialReferenceIndex3 = this.m_TextMeshPro.textInfo.characterInfo[num4].materialReferenceIndex;
						int vertexIndex3 = this.m_TextMeshPro.textInfo.characterInfo[num4].vertexIndex;
						Color32[] colors3 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex3].colors32;
						Color32 color3 = colors3[vertexIndex3].Tint(0.75f);
						colors3[vertexIndex3] = color3;
						colors3[vertexIndex3 + 1] = color3;
						colors3[vertexIndex3 + 2] = color3;
						colors3[vertexIndex3 + 3] = color3;
					}
					this.m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
				}
				int num5 = TMP_TextUtilities.FindIntersectingLink(this.m_TextMeshPro, Input.mousePosition, this.m_Camera);
				if ((num5 == -1 && this.m_selectedLink != -1) || num5 != this.m_selectedLink)
				{
					this.m_TextPopup_RectTransform.gameObject.SetActive(false);
					this.m_selectedLink = -1;
				}
				if (num5 != -1 && num5 != this.m_selectedLink)
				{
					this.m_selectedLink = num5;
					TMP_LinkInfo tmp_LinkInfo = this.m_TextMeshPro.textInfo.linkInfo[num5];
					Vector3 zero = Vector3.zero;
					RectTransformUtility.ScreenPointToWorldPointInRectangle(this.m_TextMeshPro.rectTransform, Input.mousePosition, this.m_Camera, out zero);
					string linkID = tmp_LinkInfo.GetLinkID();
					if (linkID != null)
					{
						if (!(linkID == "id_01"))
						{
							if (linkID == "id_02")
							{
								this.m_TextPopup_RectTransform.position = zero;
								this.m_TextPopup_RectTransform.gameObject.SetActive(true);
								this.m_TextPopup_TMPComponent.text = "You have selected link <#ffff00> ID 02";
							}
						}
						else
						{
							this.m_TextPopup_RectTransform.position = zero;
							this.m_TextPopup_RectTransform.gameObject.SetActive(true);
							this.m_TextPopup_TMPComponent.text = "You have selected link <#ffff00> ID 01";
						}
					}
				}
			}
			else if (this.m_lastIndex != -1)
			{
				this.RestoreCachedVertexAttributes(this.m_lastIndex);
				this.m_lastIndex = -1;
			}
		}

		// Token: 0x06004D64 RID: 19812 RVA: 0x001F713A File Offset: 0x001F553A
		public void OnPointerEnter(PointerEventData eventData)
		{
			this.isHoveringObject = true;
		}

		// Token: 0x06004D65 RID: 19813 RVA: 0x001F7143 File Offset: 0x001F5543
		public void OnPointerExit(PointerEventData eventData)
		{
			this.isHoveringObject = false;
		}

		// Token: 0x06004D66 RID: 19814 RVA: 0x001F714C File Offset: 0x001F554C
		public void OnPointerClick(PointerEventData eventData)
		{
		}

		// Token: 0x06004D67 RID: 19815 RVA: 0x001F714E File Offset: 0x001F554E
		public void OnPointerUp(PointerEventData eventData)
		{
		}

		// Token: 0x06004D68 RID: 19816 RVA: 0x001F7150 File Offset: 0x001F5550
		private void RestoreCachedVertexAttributes(int index)
		{
			if (index == -1 || index > this.m_TextMeshPro.textInfo.characterCount - 1)
			{
				return;
			}
			int materialReferenceIndex = this.m_TextMeshPro.textInfo.characterInfo[index].materialReferenceIndex;
			int vertexIndex = this.m_TextMeshPro.textInfo.characterInfo[index].vertexIndex;
			Vector3[] vertices = this.m_cachedMeshInfoVertexData[materialReferenceIndex].vertices;
			Vector3[] vertices2 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].vertices;
			vertices2[vertexIndex] = vertices[vertexIndex];
			vertices2[vertexIndex + 1] = vertices[vertexIndex + 1];
			vertices2[vertexIndex + 2] = vertices[vertexIndex + 2];
			vertices2[vertexIndex + 3] = vertices[vertexIndex + 3];
			Color32[] colors = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
			Color32[] colors2 = this.m_cachedMeshInfoVertexData[materialReferenceIndex].colors32;
			colors[vertexIndex] = colors2[vertexIndex];
			colors[vertexIndex + 1] = colors2[vertexIndex + 1];
			colors[vertexIndex + 2] = colors2[vertexIndex + 2];
			colors[vertexIndex + 3] = colors2[vertexIndex + 3];
			Vector2[] uvs = this.m_cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
			Vector2[] uvs2 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs0;
			uvs2[vertexIndex] = uvs[vertexIndex];
			uvs2[vertexIndex + 1] = uvs[vertexIndex + 1];
			uvs2[vertexIndex + 2] = uvs[vertexIndex + 2];
			uvs2[vertexIndex + 3] = uvs[vertexIndex + 3];
			Vector2[] uvs3 = this.m_cachedMeshInfoVertexData[materialReferenceIndex].uvs2;
			Vector2[] uvs4 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs2;
			uvs4[vertexIndex] = uvs3[vertexIndex];
			uvs4[vertexIndex + 1] = uvs3[vertexIndex + 1];
			uvs4[vertexIndex + 2] = uvs3[vertexIndex + 2];
			uvs4[vertexIndex + 3] = uvs3[vertexIndex + 3];
			int num = (vertices.Length / 4 - 1) * 4;
			vertices2[num] = vertices[num];
			vertices2[num + 1] = vertices[num + 1];
			vertices2[num + 2] = vertices[num + 2];
			vertices2[num + 3] = vertices[num + 3];
			colors2 = this.m_cachedMeshInfoVertexData[materialReferenceIndex].colors32;
			colors = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
			colors[num] = colors2[num];
			colors[num + 1] = colors2[num + 1];
			colors[num + 2] = colors2[num + 2];
			colors[num + 3] = colors2[num + 3];
			uvs = this.m_cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
			uvs2 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs0;
			uvs2[num] = uvs[num];
			uvs2[num + 1] = uvs[num + 1];
			uvs2[num + 2] = uvs[num + 2];
			uvs2[num + 3] = uvs[num + 3];
			uvs3 = this.m_cachedMeshInfoVertexData[materialReferenceIndex].uvs2;
			uvs4 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs2;
			uvs4[num] = uvs3[num];
			uvs4[num + 1] = uvs3[num + 1];
			uvs4[num + 2] = uvs3[num + 2];
			uvs4[num + 3] = uvs3[num + 3];
			this.m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
		}

		// Token: 0x04003BD0 RID: 15312
		public RectTransform TextPopup_Prefab_01;

		// Token: 0x04003BD1 RID: 15313
		private RectTransform m_TextPopup_RectTransform;

		// Token: 0x04003BD2 RID: 15314
		private TextMeshProUGUI m_TextPopup_TMPComponent;

		// Token: 0x04003BD3 RID: 15315
		private const string k_LinkText = "You have selected link <#ffff00>";

		// Token: 0x04003BD4 RID: 15316
		private const string k_WordText = "Word Index: <#ffff00>";

		// Token: 0x04003BD5 RID: 15317
		private TextMeshProUGUI m_TextMeshPro;

		// Token: 0x04003BD6 RID: 15318
		private Canvas m_Canvas;

		// Token: 0x04003BD7 RID: 15319
		private Camera m_Camera;

		// Token: 0x04003BD8 RID: 15320
		private bool isHoveringObject;

		// Token: 0x04003BD9 RID: 15321
		private int m_selectedWord = -1;

		// Token: 0x04003BDA RID: 15322
		private int m_selectedLink = -1;

		// Token: 0x04003BDB RID: 15323
		private int m_lastIndex = -1;

		// Token: 0x04003BDC RID: 15324
		private Matrix4x4 m_matrix;

		// Token: 0x04003BDD RID: 15325
		private TMP_MeshInfo[] m_cachedMeshInfoVertexData;
	}
}
