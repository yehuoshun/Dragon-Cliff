using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Lexic
{
	// Token: 0x020000CF RID: 207
	public class NameGenerator : MonoBehaviour
	{
		// Token: 0x0600063E RID: 1598 RVA: 0x0006273C File Offset: 0x00060B3C
		public NameGenerator()
		{
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x00062764 File Offset: 0x00060B64
		private void Awake()
		{
			if (this.rng == null)
			{
				this.rng = new System.Random();
			}
			Type type = Type.GetType(this.namesSourceClass);
			if (type.BaseType != typeof(BaseNames))
			{
				throw new ArgumentException(this.namesSourceClass + " is not a derived class of BaseNames.");
			}
			MethodInfo method = type.GetMethod("GetRules", BindingFlags.Static | BindingFlags.Public);
			if (method == null)
			{
				throw new MissingMethodException("Class " + this.namesSourceClass + " does not implement GetRules");
			}
			this.rules = (List<string>)method.Invoke(null, null);
			if (this.rules.Count <= 0)
			{
				throw new InvalidOperationException("Rule list empty");
			}
			this.ValidateRules();
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00062824 File Offset: 0x00060C24
		public bool ValidateRules()
		{
			foreach (string text in this.rules)
			{
				Match match = this.ruleRegex.Match(text);
				if (!match.Success)
				{
					throw new ArgumentException("Rule " + text + " has incorrect format.");
				}
			}
			return true;
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x000628A8 File Offset: 0x00060CA8
		public string GetNextRandomName()
		{
			string text = string.Empty;
			string input = this.rules[this.rng.Next(0, this.rules.Count)];
			Match match = this.ruleRegex.Match(input);
			CaptureCollection captures = match.Groups["token"].Captures;
			Type type = Type.GetType(this.namesSourceClass);
			MethodInfo method = type.GetMethod("GetSyllableSet", BindingFlags.Static | BindingFlags.Public);
			if (method == null)
			{
				throw new MissingMethodException("Class " + this.namesSourceClass + " does not implement GetSyllableSet");
			}
			for (int i = 0; i < captures.Count; i++)
			{
				Match match2 = this.tokenRegex.Match(captures[i].Value);
				if (match2.Success)
				{
					int num = int.Parse(match2.Groups[1].Value);
					string value = match2.Groups[2].Value;
					if (this.rng.Next(0, 99) < num)
					{
						List<string> list = (List<string>)method.Invoke(null, new object[]
						{
							value
						});
						if (list.Count <= 0)
						{
							throw new InvalidOperationException("Syllable list for key:" + value + " is empty");
						}
						text += list[this.rng.Next(0, list.Count)];
					}
				}
			}
			return text.Replace("_", " ");
		}

		// Token: 0x04000956 RID: 2390
		public string namesSourceClass;

		// Token: 0x04000957 RID: 2391
		public System.Random rng;

		// Token: 0x04000958 RID: 2392
		private List<string> rules;

		// Token: 0x04000959 RID: 2393
		private Regex ruleRegex = new Regex("^(?<token>(%([0-9]{1,2}|100))([a-z]+))+");

		// Token: 0x0400095A RID: 2394
		private Regex tokenRegex = new Regex("^%([0-9]{1,2}|100)([a-z]+)");
	}
}
