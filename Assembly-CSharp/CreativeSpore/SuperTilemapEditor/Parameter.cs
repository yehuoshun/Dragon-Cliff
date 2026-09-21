using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B80 RID: 2944
	[Serializable]
	public class Parameter
	{
		// Token: 0x06004DC9 RID: 19913 RVA: 0x001FBE01 File Offset: 0x001FA201
		private Parameter(string name)
		{
			this.name = name;
		}

		// Token: 0x06004DCA RID: 19914 RVA: 0x001FBE1B File Offset: 0x001FA21B
		public Parameter(string name, bool value) : this(name)
		{
			this._boolValue = value;
			this._paramType = eParameterType.Bool;
		}

		// Token: 0x06004DCB RID: 19915 RVA: 0x001FBE32 File Offset: 0x001FA232
		public Parameter(string name, int value) : this(name)
		{
			this._intValue = value;
			this._paramType = eParameterType.Int;
		}

		// Token: 0x06004DCC RID: 19916 RVA: 0x001FBE49 File Offset: 0x001FA249
		public Parameter(string name, float value) : this(name)
		{
			this._floatValue = value;
			this._paramType = eParameterType.Float;
		}

		// Token: 0x06004DCD RID: 19917 RVA: 0x001FBE60 File Offset: 0x001FA260
		public Parameter(string name, string value) : this(name)
		{
			this._stringValue = value;
			this._paramType = eParameterType.String;
		}

		// Token: 0x06004DCE RID: 19918 RVA: 0x001FBE77 File Offset: 0x001FA277
		public Parameter(string name, UnityEngine.Object value) : this(name)
		{
			this._objectValue = value;
			this._paramType = eParameterType.Object;
		}

		// Token: 0x06004DCF RID: 19919 RVA: 0x001FBE90 File Offset: 0x001FA290
		public override string ToString()
		{
			switch (this._paramType)
			{
			case eParameterType.Bool:
				return this._boolValue.ToString();
			case eParameterType.Int:
				return this._intValue.ToString();
			case eParameterType.Float:
				return this._floatValue.ToString();
			case eParameterType.Object:
				return this._objectValue.ToString();
			case eParameterType.String:
				return this._stringValue.ToString();
			default:
				return "<Not defined>";
			}
		}

		// Token: 0x06004DD0 RID: 19920 RVA: 0x001FBF18 File Offset: 0x001FA318
		public eParameterType GetParamType()
		{
			return this._paramType;
		}

		// Token: 0x06004DD1 RID: 19921 RVA: 0x001FBF20 File Offset: 0x001FA320
		public bool GetAsBool()
		{
			return this._boolValue;
		}

		// Token: 0x06004DD2 RID: 19922 RVA: 0x001FBF28 File Offset: 0x001FA328
		public int GetAsInt()
		{
			return this._intValue;
		}

		// Token: 0x06004DD3 RID: 19923 RVA: 0x001FBF30 File Offset: 0x001FA330
		public float GetAsFloat()
		{
			return this._floatValue;
		}

		// Token: 0x06004DD4 RID: 19924 RVA: 0x001FBF38 File Offset: 0x001FA338
		public string GetAsString()
		{
			return this._stringValue;
		}

		// Token: 0x06004DD5 RID: 19925 RVA: 0x001FBF40 File Offset: 0x001FA340
		public UnityEngine.Object GetAsObject()
		{
			return this._objectValue;
		}

		// Token: 0x06004DD6 RID: 19926 RVA: 0x001FBF48 File Offset: 0x001FA348
		public void SetValue(bool value)
		{
			this._boolValue = value;
		}

		// Token: 0x06004DD7 RID: 19927 RVA: 0x001FBF51 File Offset: 0x001FA351
		public void SetValue(int value)
		{
			this._intValue = value;
		}

		// Token: 0x06004DD8 RID: 19928 RVA: 0x001FBF5A File Offset: 0x001FA35A
		public void SetValue(float value)
		{
			this._floatValue = value;
		}

		// Token: 0x06004DD9 RID: 19929 RVA: 0x001FBF63 File Offset: 0x001FA363
		public void SetValue(string value)
		{
			this._stringValue = value;
		}

		// Token: 0x06004DDA RID: 19930 RVA: 0x001FBF6C File Offset: 0x001FA36C
		public void SetValue(UnityEngine.Object value)
		{
			this._objectValue = value;
		}

		// Token: 0x04003C38 RID: 15416
		private const string k_warning_msg_wrongType = "Parameter {0} of type {1} accessed as {2}";

		// Token: 0x04003C39 RID: 15417
		public string name;

		// Token: 0x04003C3A RID: 15418
		[SerializeField]
		private eParameterType _paramType;

		// Token: 0x04003C3B RID: 15419
		[SerializeField]
		private bool _boolValue;

		// Token: 0x04003C3C RID: 15420
		[SerializeField]
		private int _intValue;

		// Token: 0x04003C3D RID: 15421
		[SerializeField]
		private float _floatValue;

		// Token: 0x04003C3E RID: 15422
		[SerializeField]
		private string _stringValue = string.Empty;

		// Token: 0x04003C3F RID: 15423
		[SerializeField]
		private UnityEngine.Object _objectValue;
	}
}
