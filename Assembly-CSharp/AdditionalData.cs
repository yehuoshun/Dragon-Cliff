using System;
using System.Collections.Generic;

// Token: 0x020003AC RID: 940
[Serializable]
public class AdditionalData
{
	// Token: 0x060018FF RID: 6399 RVA: 0x000BFCFC File Offset: 0x000BE0FC
	public AdditionalData()
	{
		this.NumberData = new Dictionary<string, int>();
		this.StringData = new Dictionary<string, string>();
		this.DoubleData = new Dictionary<string, double>();
		this.FloatData = new Dictionary<string, float>();
		this.BoolData = new Dictionary<string, bool>();
	}

	// Token: 0x06001900 RID: 6400 RVA: 0x000BFD3B File Offset: 0x000BE13B
	public void AddOrUpdateData(string key, int value)
	{
		if (this.NumberData.ContainsKey(key))
		{
			this.NumberData[key] = value;
		}
		else
		{
			this.NumberData.Add(key, value);
		}
	}

	// Token: 0x06001901 RID: 6401 RVA: 0x000BFD6D File Offset: 0x000BE16D
	public void AddOrUpdateData(string key, string value)
	{
		if (this.StringData.ContainsKey(key))
		{
			this.StringData[key] = value;
		}
		else
		{
			this.StringData.Add(key, value);
		}
	}

	// Token: 0x06001902 RID: 6402 RVA: 0x000BFD9F File Offset: 0x000BE19F
	public void AddOrUpdateData(string key, bool value)
	{
		if (this.BoolData.ContainsKey(key))
		{
			this.BoolData[key] = value;
		}
		else
		{
			this.BoolData.Add(key, value);
		}
	}

	// Token: 0x06001903 RID: 6403 RVA: 0x000BFDD1 File Offset: 0x000BE1D1
	public void AddOrUpdateData(string key, double value)
	{
		if (this.DoubleData.ContainsKey(key))
		{
			this.DoubleData[key] = value;
		}
		else
		{
			this.DoubleData.Add(key, value);
		}
	}

	// Token: 0x06001904 RID: 6404 RVA: 0x000BFE03 File Offset: 0x000BE203
	public void AddOrUpdateData(string key, float value)
	{
		if (this.FloatData.ContainsKey(key))
		{
			this.FloatData[key] = value;
		}
		else
		{
			this.FloatData.Add(key, value);
		}
	}

	// Token: 0x06001905 RID: 6405 RVA: 0x000BFE35 File Offset: 0x000BE235
	public bool ContainsInt(string key)
	{
		return this.NumberData.ContainsKey(key);
	}

	// Token: 0x06001906 RID: 6406 RVA: 0x000BFE43 File Offset: 0x000BE243
	public bool ContainsBool(string key)
	{
		return this.BoolData.ContainsKey(key);
	}

	// Token: 0x06001907 RID: 6407 RVA: 0x000BFE51 File Offset: 0x000BE251
	public bool ContainsString(string key)
	{
		return this.StringData.ContainsKey(key);
	}

	// Token: 0x06001908 RID: 6408 RVA: 0x000BFE5F File Offset: 0x000BE25F
	public bool ContainsDouble(string key)
	{
		return this.DoubleData.ContainsKey(key);
	}

	// Token: 0x06001909 RID: 6409 RVA: 0x000BFE6D File Offset: 0x000BE26D
	public bool ContainsFloat(string key)
	{
		return this.FloatData.ContainsKey(key);
	}

	// Token: 0x0600190A RID: 6410 RVA: 0x000BFE7B File Offset: 0x000BE27B
	public int GetInt(string key)
	{
		if (this.ContainsInt(key))
		{
			return this.NumberData[key];
		}
		throw new Exception("Invalid key for getting int: check contains int first");
	}

	// Token: 0x0600190B RID: 6411 RVA: 0x000BFEA0 File Offset: 0x000BE2A0
	public double GetDouble(string key)
	{
		if (this.ContainsDouble(key))
		{
			return this.DoubleData[key];
		}
		throw new Exception("Invalid key for getting double: check contains double first");
	}

	// Token: 0x0600190C RID: 6412 RVA: 0x000BFEC5 File Offset: 0x000BE2C5
	public string GetString(string key)
	{
		if (this.ContainsString(key))
		{
			return this.StringData[key];
		}
		throw new Exception("invalid key for getting string: check contains string first");
	}

	// Token: 0x0600190D RID: 6413 RVA: 0x000BFEEA File Offset: 0x000BE2EA
	public float GetFloat(string key)
	{
		if (this.ContainsFloat(key))
		{
			return this.FloatData[key];
		}
		throw new Exception("invalid key for getting float: check contains float first");
	}

	// Token: 0x0600190E RID: 6414 RVA: 0x000BFF0F File Offset: 0x000BE30F
	public bool GetBool(string key)
	{
		if (this.ContainsBool(key))
		{
			return this.BoolData[key];
		}
		throw new Exception("invalid key for getting bool: check contains bool first");
	}

	// Token: 0x040018C9 RID: 6345
	public Dictionary<string, int> NumberData;

	// Token: 0x040018CA RID: 6346
	public Dictionary<string, string> StringData;

	// Token: 0x040018CB RID: 6347
	public Dictionary<string, double> DoubleData;

	// Token: 0x040018CC RID: 6348
	public Dictionary<string, float> FloatData;

	// Token: 0x040018CD RID: 6349
	public Dictionary<string, bool> BoolData;
}
