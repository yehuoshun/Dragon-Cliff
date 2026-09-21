using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B74 RID: 2932
	public class TextMeshProFloatingText : MonoBehaviour
	{
		// Token: 0x06004D7C RID: 19836 RVA: 0x001F82F5 File Offset: 0x001F66F5
		public TextMeshProFloatingText()
		{
		}

		// Token: 0x06004D7D RID: 19837 RVA: 0x001F8313 File Offset: 0x001F6713
		private void Awake()
		{
			this.m_transform = base.transform;
			this.m_floatingText = new GameObject(base.name + " floating text");
			this.m_cameraTransform = Camera.main.transform;
		}

		// Token: 0x06004D7E RID: 19838 RVA: 0x001F834C File Offset: 0x001F674C
		private void Start()
		{
			if (this.SpawnType == 0)
			{
				this.m_textMeshPro = this.m_floatingText.AddComponent<TextMeshPro>();
				this.m_textMeshPro.rectTransform.sizeDelta = new Vector2(3f, 3f);
				this.m_floatingText_Transform = this.m_floatingText.transform;
				this.m_floatingText_Transform.position = this.m_transform.position + new Vector3(0f, 15f, 0f);
				this.m_textMeshPro.alignment = TextAlignmentOptions.Center;
				this.m_textMeshPro.color = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), byte.MaxValue);
				this.m_textMeshPro.fontSize = 24f;
				this.m_textMeshPro.text = string.Empty;
				base.StartCoroutine(this.DisplayTextMeshProFloatingText());
			}
			else if (this.SpawnType == 1)
			{
				this.m_floatingText_Transform = this.m_floatingText.transform;
				this.m_floatingText_Transform.position = this.m_transform.position + new Vector3(0f, 15f, 0f);
				this.m_textMesh = this.m_floatingText.AddComponent<TextMesh>();
				this.m_textMesh.font = (Resources.Load("Fonts/ARIAL", typeof(Font)) as Font);
				this.m_textMesh.GetComponent<Renderer>().sharedMaterial = this.m_textMesh.font.material;
				this.m_textMesh.color = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), byte.MaxValue);
				this.m_textMesh.anchor = TextAnchor.LowerCenter;
				this.m_textMesh.fontSize = 24;
				base.StartCoroutine(this.DisplayTextMeshFloatingText());
			}
			else if (this.SpawnType == 2)
			{
			}
		}

		// Token: 0x06004D7F RID: 19839 RVA: 0x001F856C File Offset: 0x001F696C
		public IEnumerator DisplayTextMeshProFloatingText()
		{
			float CountDuration = 2f;
			float starting_Count = UnityEngine.Random.Range(5f, 20f);
			float current_Count = starting_Count;
			Vector3 start_pos = this.m_floatingText_Transform.position;
			Color32 start_color = this.m_textMeshPro.color;
			float alpha = 255f;
			float fadeDuration = 3f / starting_Count * CountDuration;
			while (current_Count > 0f)
			{
				current_Count -= Time.deltaTime / CountDuration * starting_Count;
				if (current_Count <= 3f)
				{
					alpha = Mathf.Clamp(alpha - Time.deltaTime / fadeDuration * 255f, 0f, 255f);
				}
				this.m_textMeshPro.SetText("{0}", (float)((int)current_Count));
				this.m_textMeshPro.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);
				this.m_floatingText_Transform.position += new Vector3(0f, starting_Count * Time.deltaTime, 0f);
				if (!this.lastPOS.Compare(this.m_cameraTransform.position, 1000) || !this.lastRotation.Compare(this.m_cameraTransform.rotation, 1000))
				{
					this.lastPOS = this.m_cameraTransform.position;
					this.lastRotation = this.m_cameraTransform.rotation;
					this.m_floatingText_Transform.rotation = this.lastRotation;
					Vector3 vector = this.m_transform.position - this.lastPOS;
					this.m_transform.forward = new Vector3(vector.x, 0f, vector.z);
				}
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 1f));
			this.m_floatingText_Transform.position = start_pos;
			base.StartCoroutine(this.DisplayTextMeshProFloatingText());
			yield break;
		}

		// Token: 0x06004D80 RID: 19840 RVA: 0x001F8588 File Offset: 0x001F6988
		public IEnumerator DisplayTextMeshFloatingText()
		{
			float CountDuration = 2f;
			float starting_Count = UnityEngine.Random.Range(5f, 20f);
			float current_Count = starting_Count;
			Vector3 start_pos = this.m_floatingText_Transform.position;
			Color32 start_color = this.m_textMesh.color;
			float alpha = 255f;
			int int_counter = 0;
			float fadeDuration = 3f / starting_Count * CountDuration;
			while (current_Count > 0f)
			{
				current_Count -= Time.deltaTime / CountDuration * starting_Count;
				if (current_Count <= 3f)
				{
					alpha = Mathf.Clamp(alpha - Time.deltaTime / fadeDuration * 255f, 0f, 255f);
				}
				int_counter = (int)current_Count;
				this.m_textMesh.text = int_counter.ToString();
				this.m_textMesh.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);
				this.m_floatingText_Transform.position += new Vector3(0f, starting_Count * Time.deltaTime, 0f);
				if (!this.lastPOS.Compare(this.m_cameraTransform.position, 1000) || !this.lastRotation.Compare(this.m_cameraTransform.rotation, 1000))
				{
					this.lastPOS = this.m_cameraTransform.position;
					this.lastRotation = this.m_cameraTransform.rotation;
					this.m_floatingText_Transform.rotation = this.lastRotation;
					Vector3 vector = this.m_transform.position - this.lastPOS;
					this.m_transform.forward = new Vector3(vector.x, 0f, vector.z);
				}
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 1f));
			this.m_floatingText_Transform.position = start_pos;
			base.StartCoroutine(this.DisplayTextMeshFloatingText());
			yield break;
		}

		// Token: 0x04003BFC RID: 15356
		public Font TheFont;

		// Token: 0x04003BFD RID: 15357
		private GameObject m_floatingText;

		// Token: 0x04003BFE RID: 15358
		private TextMeshPro m_textMeshPro;

		// Token: 0x04003BFF RID: 15359
		private TextMesh m_textMesh;

		// Token: 0x04003C00 RID: 15360
		private Transform m_transform;

		// Token: 0x04003C01 RID: 15361
		private Transform m_floatingText_Transform;

		// Token: 0x04003C02 RID: 15362
		private Transform m_cameraTransform;

		// Token: 0x04003C03 RID: 15363
		private Vector3 lastPOS = Vector3.zero;

		// Token: 0x04003C04 RID: 15364
		private Quaternion lastRotation = Quaternion.identity;

		// Token: 0x04003C05 RID: 15365
		public int SpawnType;

		// Token: 0x0200108E RID: 4238
		[CompilerGenerated]
		private sealed class <DisplayTextMeshProFloatingText>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069BF RID: 27071 RVA: 0x001F85A3 File Offset: 0x001F69A3
			[DebuggerHidden]
			public <DisplayTextMeshProFloatingText>c__Iterator0()
			{
			}

			// Token: 0x060069C0 RID: 27072 RVA: 0x001F85AC File Offset: 0x001F69AC
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					CountDuration = 2f;
					starting_Count = UnityEngine.Random.Range(5f, 20f);
					current_Count = starting_Count;
					start_pos = this.m_floatingText_Transform.position;
					start_color = this.m_textMeshPro.color;
					alpha = 255f;
					fadeDuration = 3f / starting_Count * CountDuration;
					break;
				case 1u:
					break;
				case 2u:
					this.m_floatingText_Transform.position = start_pos;
					base.StartCoroutine(base.DisplayTextMeshProFloatingText());
					this.$PC = -1;
					return false;
				default:
					return false;
				}
				if (current_Count <= 0f)
				{
					this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.1f, 1f));
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
				}
				else
				{
					current_Count -= Time.deltaTime / CountDuration * starting_Count;
					if (current_Count <= 3f)
					{
						alpha = Mathf.Clamp(alpha - Time.deltaTime / fadeDuration * 255f, 0f, 255f);
					}
					this.m_textMeshPro.SetText("{0}", (float)((int)current_Count));
					this.m_textMeshPro.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);
					this.m_floatingText_Transform.position += new Vector3(0f, starting_Count * Time.deltaTime, 0f);
					if (!this.lastPOS.Compare(this.m_cameraTransform.position, 1000) || !this.lastRotation.Compare(this.m_cameraTransform.rotation, 1000))
					{
						this.lastPOS = this.m_cameraTransform.position;
						this.lastRotation = this.m_cameraTransform.rotation;
						this.m_floatingText_Transform.rotation = this.lastRotation;
						Vector3 vector = this.m_transform.position - this.lastPOS;
						this.m_transform.forward = new Vector3(vector.x, 0f, vector.z);
					}
					this.$current = new WaitForEndOfFrame();
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
				}
				return true;
			}

			// Token: 0x17001613 RID: 5651
			// (get) Token: 0x060069C1 RID: 27073 RVA: 0x001F88D9 File Offset: 0x001F6CD9
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001614 RID: 5652
			// (get) Token: 0x060069C2 RID: 27074 RVA: 0x001F88E1 File Offset: 0x001F6CE1
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069C3 RID: 27075 RVA: 0x001F88E9 File Offset: 0x001F6CE9
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069C4 RID: 27076 RVA: 0x001F88F9 File Offset: 0x001F6CF9
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006442 RID: 25666
			internal float <CountDuration>__0;

			// Token: 0x04006443 RID: 25667
			internal float <starting_Count>__0;

			// Token: 0x04006444 RID: 25668
			internal float <current_Count>__0;

			// Token: 0x04006445 RID: 25669
			internal Vector3 <start_pos>__0;

			// Token: 0x04006446 RID: 25670
			internal Color32 <start_color>__0;

			// Token: 0x04006447 RID: 25671
			internal float <alpha>__0;

			// Token: 0x04006448 RID: 25672
			internal float <fadeDuration>__0;

			// Token: 0x04006449 RID: 25673
			internal TextMeshProFloatingText $this;

			// Token: 0x0400644A RID: 25674
			internal object $current;

			// Token: 0x0400644B RID: 25675
			internal bool $disposing;

			// Token: 0x0400644C RID: 25676
			internal int $PC;
		}

		// Token: 0x0200108F RID: 4239
		[CompilerGenerated]
		private sealed class <DisplayTextMeshFloatingText>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069C5 RID: 27077 RVA: 0x001F8900 File Offset: 0x001F6D00
			[DebuggerHidden]
			public <DisplayTextMeshFloatingText>c__Iterator1()
			{
			}

			// Token: 0x060069C6 RID: 27078 RVA: 0x001F8908 File Offset: 0x001F6D08
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					CountDuration = 2f;
					starting_Count = UnityEngine.Random.Range(5f, 20f);
					current_Count = starting_Count;
					start_pos = this.m_floatingText_Transform.position;
					start_color = this.m_textMesh.color;
					alpha = 255f;
					int_counter = 0;
					fadeDuration = 3f / starting_Count * CountDuration;
					break;
				case 1u:
					break;
				case 2u:
					this.m_floatingText_Transform.position = start_pos;
					base.StartCoroutine(base.DisplayTextMeshFloatingText());
					this.$PC = -1;
					return false;
				default:
					return false;
				}
				if (current_Count <= 0f)
				{
					this.$current = new WaitForSeconds(UnityEngine.Random.Range(0.1f, 1f));
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
				}
				else
				{
					current_Count -= Time.deltaTime / CountDuration * starting_Count;
					if (current_Count <= 3f)
					{
						alpha = Mathf.Clamp(alpha - Time.deltaTime / fadeDuration * 255f, 0f, 255f);
					}
					int_counter = (int)current_Count;
					this.m_textMesh.text = int_counter.ToString();
					this.m_textMesh.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);
					this.m_floatingText_Transform.position += new Vector3(0f, starting_Count * Time.deltaTime, 0f);
					if (!this.lastPOS.Compare(this.m_cameraTransform.position, 1000) || !this.lastRotation.Compare(this.m_cameraTransform.rotation, 1000))
					{
						this.lastPOS = this.m_cameraTransform.position;
						this.lastRotation = this.m_cameraTransform.rotation;
						this.m_floatingText_Transform.rotation = this.lastRotation;
						Vector3 vector = this.m_transform.position - this.lastPOS;
						this.m_transform.forward = new Vector3(vector.x, 0f, vector.z);
					}
					this.$current = new WaitForEndOfFrame();
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
				}
				return true;
			}

			// Token: 0x17001615 RID: 5653
			// (get) Token: 0x060069C7 RID: 27079 RVA: 0x001F8C4D File Offset: 0x001F704D
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001616 RID: 5654
			// (get) Token: 0x060069C8 RID: 27080 RVA: 0x001F8C55 File Offset: 0x001F7055
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069C9 RID: 27081 RVA: 0x001F8C5D File Offset: 0x001F705D
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069CA RID: 27082 RVA: 0x001F8C6D File Offset: 0x001F706D
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0400644D RID: 25677
			internal float <CountDuration>__0;

			// Token: 0x0400644E RID: 25678
			internal float <starting_Count>__0;

			// Token: 0x0400644F RID: 25679
			internal float <current_Count>__0;

			// Token: 0x04006450 RID: 25680
			internal Vector3 <start_pos>__0;

			// Token: 0x04006451 RID: 25681
			internal Color32 <start_color>__0;

			// Token: 0x04006452 RID: 25682
			internal float <alpha>__0;

			// Token: 0x04006453 RID: 25683
			internal int <int_counter>__0;

			// Token: 0x04006454 RID: 25684
			internal float <fadeDuration>__0;

			// Token: 0x04006455 RID: 25685
			internal TextMeshProFloatingText $this;

			// Token: 0x04006456 RID: 25686
			internal object $current;

			// Token: 0x04006457 RID: 25687
			internal bool $disposing;

			// Token: 0x04006458 RID: 25688
			internal int $PC;
		}
	}
}
