using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B7E RID: 2942
	[Serializable]
	public class ParameterContainer
	{
		// Token: 0x06004DAC RID: 19884 RVA: 0x001FB825 File Offset: 0x001F9C25
		public ParameterContainer()
		{
		}

		// Token: 0x17001092 RID: 4242
		// (get) Token: 0x06004DAD RID: 19885 RVA: 0x001FB838 File Offset: 0x001F9C38
		public List<Parameter> ParameterList
		{
			get
			{
				return this.m_paramList;
			}
		}

		// Token: 0x17001093 RID: 4243
		public Parameter this[string name]
		{
			get
			{
				return this.FindParam(name);
			}
		}

		// Token: 0x06004DAF RID: 19887 RVA: 0x001FB84C File Offset: 0x001F9C4C
		public void AddNewParam(Parameter param, int idx = -1)
		{
			idx = ((idx < 0) ? this.m_paramList.Count : Mathf.Min(idx, this.m_paramList.Count));
			string name = param.name;
			int num = 1;
			while (this.m_paramList.Exists((Parameter x) => x.name == param.name))
			{
				param.name = string.Concat(new object[]
				{
					name,
					" (",
					num,
					")"
				});
				num++;
			}
			this.m_paramList.Insert(idx, param);
		}

		// Token: 0x06004DB0 RID: 19888 RVA: 0x001FB908 File Offset: 0x001F9D08
		public void RemoveParam(string name)
		{
			this.m_paramList.RemoveAll((Parameter x) => x.name == name);
		}

		// Token: 0x06004DB1 RID: 19889 RVA: 0x001FB93C File Offset: 0x001F9D3C
		public void RenameParam(string name, string newName)
		{
			int num = this.m_paramList.FindIndex((Parameter x) => x.name == name);
			if (num >= 0)
			{
				Parameter parameter = this.m_paramList[num];
				this.RemoveParam(name);
				parameter.name = newName;
				this.AddNewParam(parameter, num);
			}
		}

		// Token: 0x06004DB2 RID: 19890 RVA: 0x001FB99D File Offset: 0x001F9D9D
		public void RemoveAll()
		{
			this.m_paramList.Clear();
		}

		// Token: 0x06004DB3 RID: 19891 RVA: 0x001FB9AA File Offset: 0x001F9DAA
		public void SortByName()
		{
			this.m_paramList.Sort((Parameter a, Parameter b) => a.name.CompareTo(b.name));
		}

		// Token: 0x06004DB4 RID: 19892 RVA: 0x001FB9D4 File Offset: 0x001F9DD4
		public void SortByType()
		{
			this.m_paramList.Sort((Parameter a, Parameter b) => a.GetParamType().CompareTo(b.GetParamType()));
		}

		// Token: 0x06004DB5 RID: 19893 RVA: 0x001FBA00 File Offset: 0x001F9E00
		public Parameter FindParam(string name)
		{
			return this.m_paramList.Find((Parameter x) => x.name == name);
		}

		// Token: 0x06004DB6 RID: 19894 RVA: 0x001FBA31 File Offset: 0x001F9E31
		public void AddParam(string name, bool value)
		{
			this.AddParam<bool>(name, value);
		}

		// Token: 0x06004DB7 RID: 19895 RVA: 0x001FBA3B File Offset: 0x001F9E3B
		public void AddParam(string name, int value)
		{
			this.AddParam<int>(name, value);
		}

		// Token: 0x06004DB8 RID: 19896 RVA: 0x001FBA45 File Offset: 0x001F9E45
		public void AddParam(string name, float value)
		{
			this.AddParam<float>(name, value);
		}

		// Token: 0x06004DB9 RID: 19897 RVA: 0x001FBA4F File Offset: 0x001F9E4F
		public void AddParam(string name, string value)
		{
			this.AddParam<string>(name, value);
		}

		// Token: 0x06004DBA RID: 19898 RVA: 0x001FBA59 File Offset: 0x001F9E59
		public void AddParam(string name, UnityEngine.Object value)
		{
			this.AddParam<UnityEngine.Object>(name, value);
		}

		// Token: 0x06004DBB RID: 19899 RVA: 0x001FBA64 File Offset: 0x001F9E64
		private void AddParam<T>(string name, T value)
		{
			Parameter parameter = this.FindParam(name);
			if (parameter != null)
			{
				string.Format("Parameter with name {0} of type {1} and value {2} already exists", parameter.name, parameter.GetParamType(), parameter.ToString());
			}
			else if (value is bool)
			{
				parameter = new Parameter(name, (bool)((object)value));
			}
			else if (value is int)
			{
				parameter = new Parameter(name, (int)((object)value));
			}
			else if (value is float)
			{
				parameter = new Parameter(name, (float)((object)value));
			}
			else if (value is UnityEngine.Object)
			{
				parameter = new Parameter(name, (UnityEngine.Object)((object)value));
			}
			if (parameter != null)
			{
				this.m_paramList.Add(parameter);
			}
		}

		// Token: 0x06004DBC RID: 19900 RVA: 0x001FBB50 File Offset: 0x001F9F50
		public void SetParam(string name, bool value)
		{
			Parameter parameter = this.FindParam(name);
			if (parameter != null)
			{
				parameter.SetValue(value);
			}
			else
			{
				this.AddParam<bool>(name, value);
			}
		}

		// Token: 0x06004DBD RID: 19901 RVA: 0x001FBB80 File Offset: 0x001F9F80
		public void SetParam(string name, int value)
		{
			Parameter parameter = this.FindParam(name);
			if (parameter != null)
			{
				parameter.SetValue(value);
			}
			else
			{
				this.AddParam<int>(name, value);
			}
		}

		// Token: 0x06004DBE RID: 19902 RVA: 0x001FBBB0 File Offset: 0x001F9FB0
		public void SetParam(string name, float value)
		{
			Parameter parameter = this.FindParam(name);
			if (parameter != null)
			{
				parameter.SetValue(value);
			}
			else
			{
				this.AddParam<float>(name, value);
			}
		}

		// Token: 0x06004DBF RID: 19903 RVA: 0x001FBBE0 File Offset: 0x001F9FE0
		public void SetParam(string name, UnityEngine.Object value)
		{
			Parameter parameter = this.FindParam(name);
			if (parameter != null)
			{
				parameter.SetValue(value);
			}
			else
			{
				this.AddParam<UnityEngine.Object>(name, value);
			}
		}

		// Token: 0x06004DC0 RID: 19904 RVA: 0x001FBC10 File Offset: 0x001FA010
		public int GetIntParam(string name, int defaultValue = 0)
		{
			Parameter parameter = this.FindParam(name);
			return (parameter == null) ? defaultValue : parameter.GetAsInt();
		}

		// Token: 0x06004DC1 RID: 19905 RVA: 0x001FBC38 File Offset: 0x001FA038
		public float GetFloatParam(string name, float defaultValue = 0f)
		{
			Parameter parameter = this.FindParam(name);
			return (parameter == null) ? defaultValue : parameter.GetAsFloat();
		}

		// Token: 0x06004DC2 RID: 19906 RVA: 0x001FBC60 File Offset: 0x001FA060
		public string GetStringParam(string name, string defaultValue = "")
		{
			Parameter parameter = this.FindParam(name);
			return (parameter == null) ? defaultValue : parameter.GetAsString();
		}

		// Token: 0x06004DC3 RID: 19907 RVA: 0x001FBC88 File Offset: 0x001FA088
		public bool GetBoolParam(string name, bool defaultValue = false)
		{
			Parameter parameter = this.FindParam(name);
			return (parameter == null) ? defaultValue : parameter.GetAsBool();
		}

		// Token: 0x06004DC4 RID: 19908 RVA: 0x001FBCB0 File Offset: 0x001FA0B0
		public UnityEngine.Object GetObjectParam(string name, UnityEngine.Object defaultValue = null)
		{
			Parameter parameter = this.FindParam(name);
			return (parameter == null) ? defaultValue : parameter.GetAsObject();
		}

		// Token: 0x06004DC5 RID: 19909 RVA: 0x001FBCD8 File Offset: 0x001FA0D8
		public void AddValueToIntParam(string name, int value, bool createIfDoesntExist = true)
		{
			Parameter parameter = this.FindParam(name);
			if (parameter != null)
			{
				parameter.SetValue(parameter.GetAsInt() + value);
			}
			else if (createIfDoesntExist)
			{
				this.AddParam(name, value);
			}
		}

		// Token: 0x06004DC6 RID: 19910 RVA: 0x001FBD14 File Offset: 0x001FA114
		public void AddValueToFloatParam(string name, float value, bool createIfDoesntExist = true)
		{
			Parameter parameter = this.FindParam(name);
			if (parameter != null)
			{
				parameter.SetValue(parameter.GetAsFloat() + value);
			}
			else if (createIfDoesntExist)
			{
				this.AddParam(name, value);
			}
		}

		// Token: 0x06004DC7 RID: 19911 RVA: 0x001FBD50 File Offset: 0x001FA150
		[CompilerGenerated]
		private static int <SortByName>m__0(Parameter a, Parameter b)
		{
			return a.name.CompareTo(b.name);
		}

		// Token: 0x06004DC8 RID: 19912 RVA: 0x001FBD64 File Offset: 0x001FA164
		[CompilerGenerated]
		private static int <SortByType>m__1(Parameter a, Parameter b)
		{
			return a.GetParamType().CompareTo(b.GetParamType());
		}

		// Token: 0x04003C2C RID: 15404
		private const string k_warning_msg_wrongName = "Parameter with name {0} of type {1} and value {2} already exists";

		// Token: 0x04003C2D RID: 15405
		private const string k_warning_msg_paramNotFound = "Parameter with name {0} not found!";

		// Token: 0x04003C2E RID: 15406
		[SerializeField]
		private List<Parameter> m_paramList = new List<Parameter>();

		// Token: 0x04003C2F RID: 15407
		[CompilerGenerated]
		private static Comparison<Parameter> <>f__am$cache0;

		// Token: 0x04003C30 RID: 15408
		[CompilerGenerated]
		private static Comparison<Parameter> <>f__am$cache1;

		// Token: 0x02001097 RID: 4247
		[CompilerGenerated]
		private sealed class <AddNewParam>c__AnonStorey0
		{
			// Token: 0x060069F1 RID: 27121 RVA: 0x001FBD90 File Offset: 0x001FA190
			public <AddNewParam>c__AnonStorey0()
			{
			}

			// Token: 0x060069F2 RID: 27122 RVA: 0x001FBD98 File Offset: 0x001FA198
			internal bool <>m__0(Parameter x)
			{
				return x.name == this.param.name;
			}

			// Token: 0x04006498 RID: 25752
			internal Parameter param;
		}

		// Token: 0x02001098 RID: 4248
		[CompilerGenerated]
		private sealed class <RemoveParam>c__AnonStorey1
		{
			// Token: 0x060069F3 RID: 27123 RVA: 0x001FBDB0 File Offset: 0x001FA1B0
			public <RemoveParam>c__AnonStorey1()
			{
			}

			// Token: 0x060069F4 RID: 27124 RVA: 0x001FBDB8 File Offset: 0x001FA1B8
			internal bool <>m__0(Parameter x)
			{
				return x.name == this.name;
			}

			// Token: 0x04006499 RID: 25753
			internal string name;
		}

		// Token: 0x02001099 RID: 4249
		[CompilerGenerated]
		private sealed class <RenameParam>c__AnonStorey2
		{
			// Token: 0x060069F5 RID: 27125 RVA: 0x001FBDCB File Offset: 0x001FA1CB
			public <RenameParam>c__AnonStorey2()
			{
			}

			// Token: 0x060069F6 RID: 27126 RVA: 0x001FBDD3 File Offset: 0x001FA1D3
			internal bool <>m__0(Parameter x)
			{
				return x.name == this.name;
			}

			// Token: 0x0400649A RID: 25754
			internal string name;
		}

		// Token: 0x0200109A RID: 4250
		[CompilerGenerated]
		private sealed class <FindParam>c__AnonStorey3
		{
			// Token: 0x060069F7 RID: 27127 RVA: 0x001FBDE6 File Offset: 0x001FA1E6
			public <FindParam>c__AnonStorey3()
			{
			}

			// Token: 0x060069F8 RID: 27128 RVA: 0x001FBDEE File Offset: 0x001FA1EE
			internal bool <>m__0(Parameter x)
			{
				return x.name == this.name;
			}

			// Token: 0x0400649B RID: 25755
			internal string name;
		}
	}
}
