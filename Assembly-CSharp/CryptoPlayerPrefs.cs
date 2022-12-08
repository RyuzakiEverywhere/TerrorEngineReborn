using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

// Token: 0x02000265 RID: 613
public static class CryptoPlayerPrefs
{
	// Token: 0x06001152 RID: 4434 RVA: 0x0007125C File Offset: 0x0006F65C
	public static bool HasKey(string key)
	{
		string key2 = CryptoPlayerPrefs.hashedKey(key);
		return PlayerPrefs.HasKey(key2);
	}

	// Token: 0x06001153 RID: 4435 RVA: 0x00071278 File Offset: 0x0006F678
	public static void DeleteKey(string key)
	{
		string key2 = CryptoPlayerPrefs.hashedKey(key);
		PlayerPrefs.DeleteKey(key2);
	}

	// Token: 0x06001154 RID: 4436 RVA: 0x00071292 File Offset: 0x0006F692
	public static void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}

	// Token: 0x06001155 RID: 4437 RVA: 0x00071299 File Offset: 0x0006F699
	public static void Save()
	{
		PlayerPrefs.Save();
	}

	// Token: 0x06001156 RID: 4438 RVA: 0x000712A0 File Offset: 0x0006F6A0
	public static void SetInt(string key, int val)
	{
		string text = CryptoPlayerPrefs.hashedKey(key);
		int num = val;
		if (CryptoPlayerPrefs._useXor)
		{
			int num2 = CryptoPlayerPrefs.computeXorOperand(key, text);
			int num3 = CryptoPlayerPrefs.computePlusOperand(num2);
			num = (val + num3 ^ num2);
		}
		if (CryptoPlayerPrefs._useRijndael)
		{
			PlayerPrefs.SetString(text, CryptoPlayerPrefs.encrypt(text, string.Empty + num));
		}
		else
		{
			PlayerPrefs.SetInt(text, num);
		}
	}

	// Token: 0x06001157 RID: 4439 RVA: 0x00071307 File Offset: 0x0006F707
	public static void SetLong(string key, long val)
	{
		CryptoPlayerPrefs.SetString(key, val.ToString());
	}

	// Token: 0x06001158 RID: 4440 RVA: 0x0007131C File Offset: 0x0006F71C
	public static void SetString(string key, string val)
	{
		string text = CryptoPlayerPrefs.hashedKey(key);
		string text2 = val;
		if (CryptoPlayerPrefs._useXor)
		{
			int num = CryptoPlayerPrefs.computeXorOperand(key, text);
			int num2 = CryptoPlayerPrefs.computePlusOperand(num);
			text2 = string.Empty;
			foreach (char c in val)
			{
				char c2 = (char)((int)c + num2 ^ num);
				text2 += c2;
			}
		}
		if (CryptoPlayerPrefs._useRijndael)
		{
			PlayerPrefs.SetString(text, CryptoPlayerPrefs.encrypt(text, text2));
		}
		else
		{
			PlayerPrefs.SetString(text, text2);
		}
	}

	// Token: 0x06001159 RID: 4441 RVA: 0x000713B5 File Offset: 0x0006F7B5
	public static void SetFloat(string key, float val)
	{
		CryptoPlayerPrefs.SetString(key, val.ToString());
	}

	// Token: 0x0600115A RID: 4442 RVA: 0x000713CC File Offset: 0x0006F7CC
	public static int GetInt(string key, int defaultValue = 0)
	{
		string text = CryptoPlayerPrefs.hashedKey(key);
		if (!PlayerPrefs.HasKey(text))
		{
			return defaultValue;
		}
		int num;
		if (CryptoPlayerPrefs._useRijndael)
		{
			num = int.Parse(CryptoPlayerPrefs.decrypt(text));
		}
		else
		{
			num = PlayerPrefs.GetInt(text);
		}
		int result = num;
		if (CryptoPlayerPrefs._useXor)
		{
			int num2 = CryptoPlayerPrefs.computeXorOperand(key, text);
			int num3 = CryptoPlayerPrefs.computePlusOperand(num2);
			result = (num2 ^ num) - num3;
		}
		return result;
	}

	// Token: 0x0600115B RID: 4443 RVA: 0x00071433 File Offset: 0x0006F833
	public static long GetLong(string key, long defaultValue = 0L)
	{
		return long.Parse(CryptoPlayerPrefs.GetString(key, defaultValue.ToString()));
	}

	// Token: 0x0600115C RID: 4444 RVA: 0x00071450 File Offset: 0x0006F850
	public static string GetString(string key, string defaultValue = "")
	{
		string text = CryptoPlayerPrefs.hashedKey(key);
		if (!PlayerPrefs.HasKey(text))
		{
			return defaultValue;
		}
		string text2;
		if (CryptoPlayerPrefs._useRijndael)
		{
			text2 = CryptoPlayerPrefs.decrypt(text);
		}
		else
		{
			text2 = PlayerPrefs.GetString(text);
		}
		string text3 = text2;
		if (CryptoPlayerPrefs._useXor)
		{
			int num = CryptoPlayerPrefs.computeXorOperand(key, text);
			int num2 = CryptoPlayerPrefs.computePlusOperand(num);
			text3 = string.Empty;
			foreach (char c in text2)
			{
				char c2 = (char)((num ^ (int)c) - num2);
				text3 += c2;
			}
		}
		return text3;
	}

	// Token: 0x0600115D RID: 4445 RVA: 0x000714F3 File Offset: 0x0006F8F3
	public static float GetFloat(string key, float defaultValue = 0f)
	{
		return float.Parse(CryptoPlayerPrefs.GetString(key, defaultValue.ToString()));
	}

	// Token: 0x0600115E RID: 4446 RVA: 0x0007150D File Offset: 0x0006F90D
	private static string encrypt(string cKey, string data)
	{
		return CryptoPlayerPrefs.EncryptString(data, CryptoPlayerPrefs.getEncryptionPassword(cKey));
	}

	// Token: 0x0600115F RID: 4447 RVA: 0x0007151B File Offset: 0x0006F91B
	private static string decrypt(string cKey)
	{
		return CryptoPlayerPrefs.DecryptString(PlayerPrefs.GetString(cKey), CryptoPlayerPrefs.getEncryptionPassword(cKey));
	}

	// Token: 0x06001160 RID: 4448 RVA: 0x00071530 File Offset: 0x0006F930
	private static string hashedKey(string key)
	{
		if (CryptoPlayerPrefs.keyHashs == null)
		{
			CryptoPlayerPrefs.keyHashs = new Dictionary<string, string>();
		}
		if (CryptoPlayerPrefs.keyHashs.ContainsKey(key))
		{
			return CryptoPlayerPrefs.keyHashs[key];
		}
		string text = CryptoPlayerPrefs.Md5Sum(key);
		CryptoPlayerPrefs.keyHashs.Add(key, text);
		return text;
	}

	// Token: 0x06001161 RID: 4449 RVA: 0x00071584 File Offset: 0x0006F984
	private static int computeXorOperand(string key, string cryptedKey)
	{
		if (CryptoPlayerPrefs.xorOperands == null)
		{
			CryptoPlayerPrefs.xorOperands = new Dictionary<string, int>();
		}
		if (CryptoPlayerPrefs.xorOperands.ContainsKey(key))
		{
			return CryptoPlayerPrefs.xorOperands[key];
		}
		int num = 0;
		foreach (char c in cryptedKey)
		{
			num += (int)c;
		}
		num += CryptoPlayerPrefs.salt;
		CryptoPlayerPrefs.xorOperands.Add(key, num);
		return num;
	}

	// Token: 0x06001162 RID: 4450 RVA: 0x000715FD File Offset: 0x0006F9FD
	private static int computePlusOperand(int xor)
	{
		return xor & xor << 1;
	}

	// Token: 0x06001163 RID: 4451 RVA: 0x00071604 File Offset: 0x0006FA04
	public static string Md5Sum(string strToEncrypt)
	{
		UTF8Encoding utf8Encoding = new UTF8Encoding();
		byte[] bytes = utf8Encoding.GetBytes(strToEncrypt);
		MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] array = md5CryptoServiceProvider.ComputeHash(bytes);
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			text += Convert.ToString(array[i], 16).PadLeft(2, '0');
		}
		return text.PadLeft(32, '0');
	}

	// Token: 0x06001164 RID: 4452 RVA: 0x00071674 File Offset: 0x0006FA74
	private static byte[] EncryptString(byte[] clearText, Rijndael alg)
	{
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, alg.CreateEncryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(clearText, 0, clearText.Length);
		cryptoStream.Close();
		return memoryStream.ToArray();
	}

	// Token: 0x06001165 RID: 4453 RVA: 0x000716B0 File Offset: 0x0006FAB0
	private static string EncryptString(string clearText, string Password)
	{
		Rijndael rijndaelForKey = CryptoPlayerPrefs.getRijndaelForKey(Password);
		byte[] bytes = Encoding.Unicode.GetBytes(clearText);
		byte[] inArray = CryptoPlayerPrefs.EncryptString(bytes, rijndaelForKey);
		return Convert.ToBase64String(inArray);
	}

	// Token: 0x06001166 RID: 4454 RVA: 0x000716E0 File Offset: 0x0006FAE0
	private static byte[] DecryptString(byte[] cipherData, Rijndael alg)
	{
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, alg.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(cipherData, 0, cipherData.Length);
		cryptoStream.Close();
		return memoryStream.ToArray();
	}

	// Token: 0x06001167 RID: 4455 RVA: 0x0007171C File Offset: 0x0006FB1C
	private static string DecryptString(string cipherText, string Password)
	{
		if (CryptoPlayerPrefs.rijndaelDict == null)
		{
			CryptoPlayerPrefs.rijndaelDict = new Dictionary<string, Rijndael>();
		}
		byte[] cipherData = Convert.FromBase64String(cipherText);
		Rijndael rijndaelForKey = CryptoPlayerPrefs.getRijndaelForKey(Password);
		byte[] bytes = CryptoPlayerPrefs.DecryptString(cipherData, rijndaelForKey);
		return Encoding.Unicode.GetString(bytes);
	}

	// Token: 0x06001168 RID: 4456 RVA: 0x00071760 File Offset: 0x0006FB60
	private static Rijndael getRijndaelForKey(string key)
	{
		if (CryptoPlayerPrefs.rijndaelDict == null)
		{
			CryptoPlayerPrefs.rijndaelDict = new Dictionary<string, Rijndael>();
		}
		Rijndael rijndael;
		if (CryptoPlayerPrefs.rijndaelDict.ContainsKey(key))
		{
			rijndael = CryptoPlayerPrefs.rijndaelDict[key];
		}
		else
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(key, new byte[]
			{
				73,
				97,
				110,
				32,
				77,
				100,
				118,
				101,
				101,
				100,
				101,
				118,
				118
			});
			rijndael = Rijndael.Create();
			rijndael.Key = rfc2898DeriveBytes.GetBytes(32);
			rijndael.IV = rfc2898DeriveBytes.GetBytes(16);
			CryptoPlayerPrefs.rijndaelDict.Add(key, rijndael);
		}
		return rijndael;
	}

	// Token: 0x06001169 RID: 4457 RVA: 0x000717EA File Offset: 0x0006FBEA
	private static string getEncryptionPassword(string pw)
	{
		return CryptoPlayerPrefs.Md5Sum(pw + CryptoPlayerPrefs.salt);
	}

	// Token: 0x0600116A RID: 4458 RVA: 0x00071804 File Offset: 0x0006FC04
	private static bool test(bool use_Rijndael, bool use_Xor)
	{
		bool flag = true;
		bool useRijndael = CryptoPlayerPrefs._useRijndael;
		bool useXor = CryptoPlayerPrefs._useXor;
		CryptoPlayerPrefs.useRijndael(use_Rijndael);
		CryptoPlayerPrefs.useXor(use_Xor);
		int num = 0;
		string text = "cryptotest_int";
		string text2 = CryptoPlayerPrefs.hashedKey(text);
		CryptoPlayerPrefs.SetInt(text, num);
		int @int = CryptoPlayerPrefs.GetInt(text, 0);
		bool flag2 = num == @int;
		flag = (flag && flag2);
		Debug.Log("INT Bordertest Zero: " + ((!flag2) ? "fail" : "ok"));
		Debug.Log(string.Concat(new object[]
		{
			"(Key: ",
			text,
			"; Crypted Key: ",
			text2,
			"; Input value: ",
			num,
			"; Saved value: ",
			PlayerPrefs.GetString(text2),
			"; Return value: ",
			@int,
			")"
		}));
		num = int.MaxValue;
		text = "cryptotest_intmax";
		text2 = CryptoPlayerPrefs.hashedKey(text);
		CryptoPlayerPrefs.SetInt(text, num);
		@int = CryptoPlayerPrefs.GetInt(text, 0);
		flag2 = (num == @int);
		flag = (flag && flag2);
		Debug.Log("INT Bordertest Max: " + ((!flag2) ? "fail" : "ok"));
		Debug.Log(string.Concat(new object[]
		{
			"(Key: ",
			text,
			"; Crypted Key: ",
			text2,
			"; Input value: ",
			num,
			"; Saved value: ",
			PlayerPrefs.GetString(text2),
			"; Return value: ",
			@int,
			")"
		}));
		num = int.MinValue;
		text = "cryptotest_intmin";
		text2 = CryptoPlayerPrefs.hashedKey(text);
		CryptoPlayerPrefs.SetInt(text, num);
		@int = CryptoPlayerPrefs.GetInt(text, 0);
		flag2 = (num == @int);
		flag = (flag && flag2);
		Debug.Log("INT Bordertest Min: " + ((!flag2) ? "fail" : "ok"));
		Debug.Log(string.Concat(new object[]
		{
			"(Key: ",
			text,
			"; Crypted Key: ",
			text2,
			"; Input value: ",
			num,
			"; Saved value: ",
			PlayerPrefs.GetString(text2),
			"; Return value: ",
			@int,
			")"
		}));
		text = "cryptotest_intrand";
		text2 = CryptoPlayerPrefs.hashedKey(text);
		bool flag3 = true;
		for (int i = 0; i < 100; i++)
		{
			int num2 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			num = num2;
			CryptoPlayerPrefs.SetInt(text, num);
			@int = CryptoPlayerPrefs.GetInt(text, 0);
			flag2 = (num == @int);
			flag3 = (flag3 && flag2);
			flag = (flag && flag2);
		}
		Debug.Log("INT Test Random: " + ((!flag3) ? "fail" : "ok"));
		float num3 = 0f;
		text = "cryptotest_float";
		text2 = CryptoPlayerPrefs.hashedKey(text);
		CryptoPlayerPrefs.SetFloat(text, num3);
		float @float = CryptoPlayerPrefs.GetFloat(text, 0f);
		flag2 = num3.ToString().Equals(@float.ToString());
		flag = (flag && flag2);
		Debug.Log("FLOAT Bordertest Zero: " + ((!flag2) ? "fail" : "ok"));
		Debug.Log(string.Concat(new object[]
		{
			"(Key: ",
			text,
			"; Crypted Key: ",
			text2,
			"; Input value: ",
			num3,
			"; Saved value: ",
			PlayerPrefs.GetString(text2),
			"; Return value: ",
			@float,
			")"
		}));
		num3 = float.MaxValue;
		text = "cryptotest_floatmax";
		text2 = CryptoPlayerPrefs.hashedKey(text);
		CryptoPlayerPrefs.SetFloat(text, num3);
		@float = CryptoPlayerPrefs.GetFloat(text, 0f);
		flag2 = num3.ToString().Equals(@float.ToString());
		flag = (flag && flag2);
		Debug.Log("FLOAT Bordertest Max: " + ((!flag2) ? "fail" : "ok"));
		Debug.Log(string.Concat(new object[]
		{
			"(Key: ",
			text,
			"; Crypted Key: ",
			text2,
			"; Input value: ",
			num3,
			"; Saved value: ",
			PlayerPrefs.GetString(text2),
			"; Return value: ",
			@float,
			")"
		}));
		num3 = float.MinValue;
		text = "cryptotest_floatmin";
		text2 = CryptoPlayerPrefs.hashedKey(text);
		CryptoPlayerPrefs.SetFloat(text, num3);
		@float = CryptoPlayerPrefs.GetFloat(text, 0f);
		flag2 = num3.ToString().Equals(@float.ToString());
		flag = (flag && flag2);
		Debug.Log("FLOAT Bordertest Min: " + ((!flag2) ? "fail" : "ok"));
		Debug.Log(string.Concat(new object[]
		{
			"(Key: ",
			text,
			"; Crypted Key: ",
			text2,
			"; Input value: ",
			num3,
			"; Saved value: ",
			PlayerPrefs.GetString(text2),
			"; Return value: ",
			@float,
			")"
		}));
		text = "cryptotest_floatrand";
		text2 = CryptoPlayerPrefs.hashedKey(text);
		flag3 = true;
		for (int j = 0; j < 100; j++)
		{
			float num4 = (float)UnityEngine.Random.Range(int.MinValue, int.MaxValue) * UnityEngine.Random.value;
			num3 = num4;
			CryptoPlayerPrefs.SetFloat(text, num3);
			@float = CryptoPlayerPrefs.GetFloat(text, 0f);
			flag2 = num3.ToString().Equals(@float.ToString());
			flag3 = (flag3 && flag2);
			flag = (flag && flag2);
		}
		Debug.Log("FLOAT Test Random: " + ((!flag3) ? "fail" : "ok"));
		CryptoPlayerPrefs.DeleteKey("cryptotest_int");
		CryptoPlayerPrefs.DeleteKey("cryptotest_intmax");
		CryptoPlayerPrefs.DeleteKey("cryptotest_intmin");
		CryptoPlayerPrefs.DeleteKey("cryptotest_intrandom");
		CryptoPlayerPrefs.DeleteKey("cryptotest_float");
		CryptoPlayerPrefs.DeleteKey("cryptotest_floatmax");
		CryptoPlayerPrefs.DeleteKey("cryptotest_floatmin");
		CryptoPlayerPrefs.DeleteKey("cryptotest_floatrandom");
		CryptoPlayerPrefs.useRijndael(useRijndael);
		CryptoPlayerPrefs.useXor(useXor);
		return flag;
	}

	// Token: 0x0600116B RID: 4459 RVA: 0x00071EB0 File Offset: 0x000702B0
	public static bool test()
	{
		bool flag = CryptoPlayerPrefs.test(true, true);
		bool flag2 = CryptoPlayerPrefs.test(true, false);
		bool flag3 = CryptoPlayerPrefs.test(false, true);
		bool flag4 = CryptoPlayerPrefs.test(false, false);
		return flag && flag2 && flag3 && flag4;
	}

	// Token: 0x0600116C RID: 4460 RVA: 0x00071EF7 File Offset: 0x000702F7
	public static void setSalt(int s)
	{
		CryptoPlayerPrefs.salt = s;
	}

	// Token: 0x0600116D RID: 4461 RVA: 0x00071EFF File Offset: 0x000702FF
	public static void useRijndael(bool use)
	{
		CryptoPlayerPrefs._useRijndael = use;
	}

	// Token: 0x0600116E RID: 4462 RVA: 0x00071F07 File Offset: 0x00070307
	public static void useXor(bool use)
	{
		CryptoPlayerPrefs._useXor = use;
	}

	// Token: 0x0400122A RID: 4650
	private static Dictionary<string, string> keyHashs;

	// Token: 0x0400122B RID: 4651
	private static Dictionary<string, int> xorOperands;

	// Token: 0x0400122C RID: 4652
	private static Dictionary<string, Rijndael> rijndaelDict;

	// Token: 0x0400122D RID: 4653
	private static int salt = int.MaxValue;

	// Token: 0x0400122E RID: 4654
	private static bool _useRijndael = true;

	// Token: 0x0400122F RID: 4655
	private static bool _useXor = true;
}
