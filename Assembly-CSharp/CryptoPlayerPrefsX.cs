using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000267 RID: 615
public class CryptoPlayerPrefsX
{
	// Token: 0x06001173 RID: 4467 RVA: 0x00071F7C File Offset: 0x0007037C
	public static bool SetBool(string name, bool value)
	{
		try
		{
			CryptoPlayerPrefs.SetInt(name, (!value) ? 0 : 1);
		}
		catch
		{
			return false;
		}
		return true;
	}

	// Token: 0x06001174 RID: 4468 RVA: 0x00071FBC File Offset: 0x000703BC
	public static bool GetBool(string name)
	{
		return CryptoPlayerPrefs.GetInt(name, 0) == 1;
	}

	// Token: 0x06001175 RID: 4469 RVA: 0x00071FC8 File Offset: 0x000703C8
	public static bool GetBool(string name, bool defaultValue)
	{
		if (CryptoPlayerPrefs.HasKey(name))
		{
			return CryptoPlayerPrefsX.GetBool(name);
		}
		return defaultValue;
	}

	// Token: 0x06001176 RID: 4470 RVA: 0x00071FDD File Offset: 0x000703DD
	public static bool SetVector2(string key, Vector2 vector)
	{
		return CryptoPlayerPrefsX.SetFloatArray(key, new float[]
		{
			vector.x,
			vector.y
		});
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x00072000 File Offset: 0x00070400
	private static Vector2 GetVector2(string key)
	{
		float[] floatArray = CryptoPlayerPrefsX.GetFloatArray(key);
		if (floatArray.Length < 2)
		{
			return Vector2.zero;
		}
		return new Vector2(floatArray[0], floatArray[1]);
	}

	// Token: 0x06001178 RID: 4472 RVA: 0x0007202E File Offset: 0x0007042E
	public static Vector2 GetVector2(string key, Vector2 defaultValue)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetVector2(key);
		}
		return defaultValue;
	}

	// Token: 0x06001179 RID: 4473 RVA: 0x00072043 File Offset: 0x00070443
	public static bool SetVector3(string key, Vector3 vector)
	{
		return CryptoPlayerPrefsX.SetFloatArray(key, new float[]
		{
			vector.x,
			vector.y,
			vector.z
		});
	}

	// Token: 0x0600117A RID: 4474 RVA: 0x00072070 File Offset: 0x00070470
	public static Vector3 GetVector3(string key)
	{
		float[] floatArray = CryptoPlayerPrefsX.GetFloatArray(key);
		if (floatArray.Length < 3)
		{
			return Vector3.zero;
		}
		return new Vector3(floatArray[0], floatArray[1], floatArray[2]);
	}

	// Token: 0x0600117B RID: 4475 RVA: 0x000720A1 File Offset: 0x000704A1
	public static Vector3 GetVector3(string key, Vector3 defaultValue)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetVector3(key);
		}
		return defaultValue;
	}

	// Token: 0x0600117C RID: 4476 RVA: 0x000720B6 File Offset: 0x000704B6
	public static bool SetQuaternion(string key, Quaternion vector)
	{
		return CryptoPlayerPrefsX.SetFloatArray(key, new float[]
		{
			vector.x,
			vector.y,
			vector.z,
			vector.w
		});
	}

	// Token: 0x0600117D RID: 4477 RVA: 0x000720EC File Offset: 0x000704EC
	public static Quaternion GetQuaternion(string key)
	{
		float[] floatArray = CryptoPlayerPrefsX.GetFloatArray(key);
		if (floatArray.Length < 4)
		{
			return Quaternion.identity;
		}
		return new Quaternion(floatArray[0], floatArray[1], floatArray[2], floatArray[3]);
	}

	// Token: 0x0600117E RID: 4478 RVA: 0x00072120 File Offset: 0x00070520
	public static Quaternion GetQuaternion(string key, Quaternion defaultValue)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetQuaternion(key);
		}
		return defaultValue;
	}

	// Token: 0x0600117F RID: 4479 RVA: 0x00072135 File Offset: 0x00070535
	public static bool SetColor(string key, Color color)
	{
		return CryptoPlayerPrefsX.SetFloatArray(key, new float[]
		{
			color.r,
			color.g,
			color.b,
			color.a
		});
	}

	// Token: 0x06001180 RID: 4480 RVA: 0x0007216C File Offset: 0x0007056C
	public static Color GetColor(string key)
	{
		float[] floatArray = CryptoPlayerPrefsX.GetFloatArray(key);
		if (floatArray.Length < 4)
		{
			return new Color(0f, 0f, 0f, 0f);
		}
		return new Color(floatArray[0], floatArray[1], floatArray[2], floatArray[3]);
	}

	// Token: 0x06001181 RID: 4481 RVA: 0x000721B4 File Offset: 0x000705B4
	public static Color GetColor(string key, Color defaultValue)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetColor(key);
		}
		return defaultValue;
	}

	// Token: 0x06001182 RID: 4482 RVA: 0x000721CC File Offset: 0x000705CC
	public static bool SetBoolArray(string key, bool[] boolArray)
	{
		if (boolArray.Length == 0)
		{
			Debug.LogError("The bool array cannot have 0 entries when setting " + key);
			return false;
		}
		byte[] array = new byte[(boolArray.Length + 7) / 8 + 5];
		array[0] = Convert.ToByte(CryptoPlayerPrefsX.ArrayType.Bool);
		BitArray bitArray = new BitArray(boolArray);
		bitArray.CopyTo(array, 5);
		CryptoPlayerPrefsX.Initialize();
		CryptoPlayerPrefsX.ConvertInt32ToBytes(boolArray.Length, array);
		return CryptoPlayerPrefsX.SaveBytes(key, array);
	}

	// Token: 0x06001183 RID: 4483 RVA: 0x00072234 File Offset: 0x00070634
	public static bool[] GetBoolArray(string key)
	{
		if (!CryptoPlayerPrefs.HasKey(key))
		{
			return new bool[0];
		}
		byte[] array = Convert.FromBase64String(CryptoPlayerPrefs.GetString(key, string.Empty));
		if (array.Length < 6)
		{
			Debug.LogError("Corrupt preference file for " + key);
			return new bool[0];
		}
		if (array[0] != 2)
		{
			Debug.LogError(key + " is not a boolean array");
			return new bool[0];
		}
		CryptoPlayerPrefsX.Initialize();
		byte[] array2 = new byte[array.Length - 5];
		Array.Copy(array, 5, array2, 0, array2.Length);
		BitArray bitArray = new BitArray(array2);
		bitArray.Length = CryptoPlayerPrefsX.ConvertBytesToInt32(array);
		bool[] array3 = new bool[bitArray.Count];
		bitArray.CopyTo(array3, 0);
		return array3;
	}

	// Token: 0x06001184 RID: 4484 RVA: 0x000722E8 File Offset: 0x000706E8
	public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetBoolArray(key);
		}
		bool[] array = new bool[defaultSize];
		for (int i = 0; i < defaultSize; i++)
		{
			array[i] = defaultValue;
		}
		return array;
	}

	// Token: 0x06001185 RID: 4485 RVA: 0x00072328 File Offset: 0x00070728
	public static bool SetStringArray(string key, string[] stringArray)
	{
		if (stringArray.Length == 0)
		{
			Debug.LogError("The string array cannot have 0 entries when setting " + key);
			return false;
		}
		byte[] array = new byte[stringArray.Length + 1];
		array[0] = Convert.ToByte(CryptoPlayerPrefsX.ArrayType.String);
		CryptoPlayerPrefsX.Initialize();
		for (int i = 0; i < stringArray.Length; i++)
		{
			if (stringArray[i] == null)
			{
				Debug.LogError("Can't save null entries in the string array when setting " + key);
				return false;
			}
			if (stringArray[i].Length > 255)
			{
				Debug.LogError("Strings cannot be longer than 255 characters when setting " + key);
				return false;
			}
			array[CryptoPlayerPrefsX.idx++] = (byte)stringArray[i].Length;
		}
		try
		{
			CryptoPlayerPrefs.SetString(key, Convert.ToBase64String(array) + "|" + string.Join(string.Empty, stringArray));
		}
		catch
		{
			return false;
		}
		return true;
	}

	// Token: 0x06001186 RID: 4486 RVA: 0x00072418 File Offset: 0x00070818
	public static string[] GetStringArray(string key)
	{
		if (!CryptoPlayerPrefs.HasKey(key))
		{
			return new string[0];
		}
		string @string = CryptoPlayerPrefs.GetString(key, string.Empty);
		int num = @string.IndexOf("|"[0]);
		if (num < 4)
		{
			Debug.LogError("Corrupt preference file for " + key);
			return new string[0];
		}
		byte[] array = Convert.FromBase64String(@string.Substring(0, num));
		if (array[0] != 3)
		{
			Debug.LogError(key + " is not a string array");
			return new string[0];
		}
		CryptoPlayerPrefsX.Initialize();
		int num2 = array.Length - 1;
		string[] array2 = new string[num2];
		int num3 = num + 1;
		for (int i = 0; i < num2; i++)
		{
			int num4 = (int)array[CryptoPlayerPrefsX.idx++];
			if (num3 + num4 > @string.Length)
			{
				Debug.LogError("Corrupt preference file for " + key);
				return new string[0];
			}
			array2[i] = @string.Substring(num3, num4);
			num3 += num4;
		}
		return array2;
	}

	// Token: 0x06001187 RID: 4487 RVA: 0x00072520 File Offset: 0x00070920
	public static string[] GetStringArray(string key, string defaultValue, int defaultSize)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetStringArray(key);
		}
		string[] array = new string[defaultSize];
		for (int i = 0; i < defaultSize; i++)
		{
			array[i] = defaultValue;
		}
		return array;
	}

	// Token: 0x06001188 RID: 4488 RVA: 0x0007255D File Offset: 0x0007095D
	public static bool SetIntArray(string key, int[] intArray)
	{
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Int32;
		int vectorNumber = 1;
		if (CryptoPlayerPrefsX.<>f__mg$cache0 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache0 = new Action<int[], byte[], int>(CryptoPlayerPrefsX.ConvertFromInt);
		}
		return CryptoPlayerPrefsX.SetValue<int[]>(key, intArray, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache0);
	}

	// Token: 0x06001189 RID: 4489 RVA: 0x00072585 File Offset: 0x00070985
	public static bool SetFloatArray(string key, float[] floatArray)
	{
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Float;
		int vectorNumber = 1;
		if (CryptoPlayerPrefsX.<>f__mg$cache1 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache1 = new Action<float[], byte[], int>(CryptoPlayerPrefsX.ConvertFromFloat);
		}
		return CryptoPlayerPrefsX.SetValue<float[]>(key, floatArray, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache1);
	}

	// Token: 0x0600118A RID: 4490 RVA: 0x000725AD File Offset: 0x000709AD
	public static bool SetVector2Array(string key, Vector2[] vector2Array)
	{
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Vector2;
		int vectorNumber = 2;
		if (CryptoPlayerPrefsX.<>f__mg$cache2 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache2 = new Action<Vector2[], byte[], int>(CryptoPlayerPrefsX.ConvertFromVector2);
		}
		return CryptoPlayerPrefsX.SetValue<Vector2[]>(key, vector2Array, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache2);
	}

	// Token: 0x0600118B RID: 4491 RVA: 0x000725D5 File Offset: 0x000709D5
	public static bool SetVector3Array(string key, Vector3[] vector3Array)
	{
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Vector3;
		int vectorNumber = 3;
		if (CryptoPlayerPrefsX.<>f__mg$cache3 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache3 = new Action<Vector3[], byte[], int>(CryptoPlayerPrefsX.ConvertFromVector3);
		}
		return CryptoPlayerPrefsX.SetValue<Vector3[]>(key, vector3Array, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache3);
	}

	// Token: 0x0600118C RID: 4492 RVA: 0x000725FD File Offset: 0x000709FD
	public static bool SetQuaternionArray(string key, Quaternion[] quaternionArray)
	{
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Quaternion;
		int vectorNumber = 4;
		if (CryptoPlayerPrefsX.<>f__mg$cache4 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache4 = new Action<Quaternion[], byte[], int>(CryptoPlayerPrefsX.ConvertFromQuaternion);
		}
		return CryptoPlayerPrefsX.SetValue<Quaternion[]>(key, quaternionArray, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache4);
	}

	// Token: 0x0600118D RID: 4493 RVA: 0x00072625 File Offset: 0x00070A25
	public static bool SetColorArray(string key, Color[] colorArray)
	{
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Color;
		int vectorNumber = 4;
		if (CryptoPlayerPrefsX.<>f__mg$cache5 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache5 = new Action<Color[], byte[], int>(CryptoPlayerPrefsX.ConvertFromColor);
		}
		return CryptoPlayerPrefsX.SetValue<Color[]>(key, colorArray, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache5);
	}

	// Token: 0x0600118E RID: 4494 RVA: 0x00072650 File Offset: 0x00070A50
	public static int[] GetIntArray(string key)
	{
		List<int> list = new List<int>();
		List<int> list2 = list;
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Int32;
		int vectorNumber = 1;
		if (CryptoPlayerPrefsX.<>f__mg$cache6 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache6 = new Action<List<int>, byte[]>(CryptoPlayerPrefsX.ConvertToInt);
		}
		CryptoPlayerPrefsX.GetValue<List<int>>(key, list2, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache6);
		return list.ToArray();
	}

	// Token: 0x0600118F RID: 4495 RVA: 0x00072690 File Offset: 0x00070A90
	public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetIntArray(key);
		}
		int[] array = new int[defaultSize];
		for (int i = 0; i < defaultSize; i++)
		{
			array[i] = defaultValue;
		}
		return array;
	}

	// Token: 0x06001190 RID: 4496 RVA: 0x000726D0 File Offset: 0x00070AD0
	public static float[] GetFloatArray(string key)
	{
		List<float> list = new List<float>();
		List<float> list2 = list;
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Float;
		int vectorNumber = 1;
		if (CryptoPlayerPrefsX.<>f__mg$cache7 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache7 = new Action<List<float>, byte[]>(CryptoPlayerPrefsX.ConvertToFloat);
		}
		CryptoPlayerPrefsX.GetValue<List<float>>(key, list2, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache7);
		return list.ToArray();
	}

	// Token: 0x06001191 RID: 4497 RVA: 0x00072710 File Offset: 0x00070B10
	public static float[] GetFloatArray(string key, float defaultValue, int defaultSize)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetFloatArray(key);
		}
		float[] array = new float[defaultSize];
		for (int i = 0; i < defaultSize; i++)
		{
			array[i] = defaultValue;
		}
		return array;
	}

	// Token: 0x06001192 RID: 4498 RVA: 0x00072750 File Offset: 0x00070B50
	public static Vector2[] GetVector2Array(string key)
	{
		List<Vector2> list = new List<Vector2>();
		List<Vector2> list2 = list;
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Vector2;
		int vectorNumber = 2;
		if (CryptoPlayerPrefsX.<>f__mg$cache8 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache8 = new Action<List<Vector2>, byte[]>(CryptoPlayerPrefsX.ConvertToVector2);
		}
		CryptoPlayerPrefsX.GetValue<List<Vector2>>(key, list2, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache8);
		return list.ToArray();
	}

	// Token: 0x06001193 RID: 4499 RVA: 0x00072790 File Offset: 0x00070B90
	public static Vector2[] GetVector2Array(string key, Vector2 defaultValue, int defaultSize)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetVector2Array(key);
		}
		Vector2[] array = new Vector2[defaultSize];
		for (int i = 0; i < defaultSize; i++)
		{
			array[i] = defaultValue;
		}
		return array;
	}

	// Token: 0x06001194 RID: 4500 RVA: 0x000727D8 File Offset: 0x00070BD8
	public static Vector3[] GetVector3Array(string key)
	{
		List<Vector3> list = new List<Vector3>();
		List<Vector3> list2 = list;
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Vector3;
		int vectorNumber = 3;
		if (CryptoPlayerPrefsX.<>f__mg$cache9 == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cache9 = new Action<List<Vector3>, byte[]>(CryptoPlayerPrefsX.ConvertToVector3);
		}
		CryptoPlayerPrefsX.GetValue<List<Vector3>>(key, list2, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cache9);
		return list.ToArray();
	}

	// Token: 0x06001195 RID: 4501 RVA: 0x00072818 File Offset: 0x00070C18
	public static Vector3[] GetVector3Array(string key, Vector3 defaultValue, int defaultSize)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetVector3Array(key);
		}
		Vector3[] array = new Vector3[defaultSize];
		for (int i = 0; i < defaultSize; i++)
		{
			array[i] = defaultValue;
		}
		return array;
	}

	// Token: 0x06001196 RID: 4502 RVA: 0x00072860 File Offset: 0x00070C60
	public static Quaternion[] GetQuaternionArray(string key)
	{
		List<Quaternion> list = new List<Quaternion>();
		List<Quaternion> list2 = list;
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Quaternion;
		int vectorNumber = 4;
		if (CryptoPlayerPrefsX.<>f__mg$cacheA == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cacheA = new Action<List<Quaternion>, byte[]>(CryptoPlayerPrefsX.ConvertToQuaternion);
		}
		CryptoPlayerPrefsX.GetValue<List<Quaternion>>(key, list2, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cacheA);
		return list.ToArray();
	}

	// Token: 0x06001197 RID: 4503 RVA: 0x000728A0 File Offset: 0x00070CA0
	public static Quaternion[] GetQuaternionArray(string key, Quaternion defaultValue, int defaultSize)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetQuaternionArray(key);
		}
		Quaternion[] array = new Quaternion[defaultSize];
		for (int i = 0; i < defaultSize; i++)
		{
			array[i] = defaultValue;
		}
		return array;
	}

	// Token: 0x06001198 RID: 4504 RVA: 0x000728E8 File Offset: 0x00070CE8
	public static Color[] GetColorArray(string key)
	{
		List<Color> list = new List<Color>();
		List<Color> list2 = list;
		CryptoPlayerPrefsX.ArrayType arrayType = CryptoPlayerPrefsX.ArrayType.Color;
		int vectorNumber = 4;
		if (CryptoPlayerPrefsX.<>f__mg$cacheB == null)
		{
			CryptoPlayerPrefsX.<>f__mg$cacheB = new Action<List<Color>, byte[]>(CryptoPlayerPrefsX.ConvertToColor);
		}
		CryptoPlayerPrefsX.GetValue<List<Color>>(key, list2, arrayType, vectorNumber, CryptoPlayerPrefsX.<>f__mg$cacheB);
		return list.ToArray();
	}

	// Token: 0x06001199 RID: 4505 RVA: 0x00072928 File Offset: 0x00070D28
	public static Color[] GetColorArray(string key, Color defaultValue, int defaultSize)
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			return CryptoPlayerPrefsX.GetColorArray(key);
		}
		Color[] array = new Color[defaultSize];
		for (int i = 0; i < defaultSize; i++)
		{
			array[i] = defaultValue;
		}
		return array;
	}

	// Token: 0x0600119A RID: 4506 RVA: 0x00072970 File Offset: 0x00070D70
	private static bool SetValue<T>(string key, T array, CryptoPlayerPrefsX.ArrayType arrayType, int vectorNumber, Action<T, byte[], int> convert) where T : IList
	{
		if (array.Count == 0)
		{
			Debug.LogError("The " + arrayType.ToString() + " array cannot have 0 entries when setting " + key);
			return false;
		}
		byte[] array2 = new byte[4 * array.Count * vectorNumber + 1];
		array2[0] = Convert.ToByte(arrayType);
		CryptoPlayerPrefsX.Initialize();
		for (int i = 0; i < array.Count; i++)
		{
			convert(array, array2, i);
		}
		return CryptoPlayerPrefsX.SaveBytes(key, array2);
	}

	// Token: 0x0600119B RID: 4507 RVA: 0x00072A0E File Offset: 0x00070E0E
	private static void ConvertFromInt(int[] array, byte[] bytes, int i)
	{
		CryptoPlayerPrefsX.ConvertInt32ToBytes(array[i], bytes);
	}

	// Token: 0x0600119C RID: 4508 RVA: 0x00072A19 File Offset: 0x00070E19
	private static void ConvertFromFloat(float[] array, byte[] bytes, int i)
	{
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i], bytes);
	}

	// Token: 0x0600119D RID: 4509 RVA: 0x00072A24 File Offset: 0x00070E24
	private static void ConvertFromVector2(Vector2[] array, byte[] bytes, int i)
	{
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].x, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].y, bytes);
	}

	// Token: 0x0600119E RID: 4510 RVA: 0x00072A4A File Offset: 0x00070E4A
	private static void ConvertFromVector3(Vector3[] array, byte[] bytes, int i)
	{
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].x, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].y, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].z, bytes);
	}

	// Token: 0x0600119F RID: 4511 RVA: 0x00072A84 File Offset: 0x00070E84
	private static void ConvertFromQuaternion(Quaternion[] array, byte[] bytes, int i)
	{
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].x, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].y, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].z, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].w, bytes);
	}

	// Token: 0x060011A0 RID: 4512 RVA: 0x00072ADC File Offset: 0x00070EDC
	private static void ConvertFromColor(Color[] array, byte[] bytes, int i)
	{
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].r, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].g, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].b, bytes);
		CryptoPlayerPrefsX.ConvertFloatToBytes(array[i].a, bytes);
	}

	// Token: 0x060011A1 RID: 4513 RVA: 0x00072B34 File Offset: 0x00070F34
	private static void GetValue<T>(string key, T list, CryptoPlayerPrefsX.ArrayType arrayType, int vectorNumber, Action<T, byte[]> convert) where T : IList
	{
		if (CryptoPlayerPrefs.HasKey(key))
		{
			byte[] array = Convert.FromBase64String(CryptoPlayerPrefs.GetString(key, string.Empty));
			if ((array.Length - 1) % (vectorNumber * 4) != 0)
			{
				Debug.LogError("Corrupt preference file for " + key);
				return;
			}
			if ((CryptoPlayerPrefsX.ArrayType)array[0] != arrayType)
			{
				Debug.LogError(key + " is not a " + arrayType.ToString() + " array");
				return;
			}
			CryptoPlayerPrefsX.Initialize();
			int num = (array.Length - 1) / (vectorNumber * 4);
			for (int i = 0; i < num; i++)
			{
				convert(list, array);
			}
		}
	}

	// Token: 0x060011A2 RID: 4514 RVA: 0x00072BD2 File Offset: 0x00070FD2
	private static void ConvertToInt(List<int> list, byte[] bytes)
	{
		list.Add(CryptoPlayerPrefsX.ConvertBytesToInt32(bytes));
	}

	// Token: 0x060011A3 RID: 4515 RVA: 0x00072BE0 File Offset: 0x00070FE0
	private static void ConvertToFloat(List<float> list, byte[] bytes)
	{
		list.Add(CryptoPlayerPrefsX.ConvertBytesToFloat(bytes));
	}

	// Token: 0x060011A4 RID: 4516 RVA: 0x00072BEE File Offset: 0x00070FEE
	private static void ConvertToVector2(List<Vector2> list, byte[] bytes)
	{
		list.Add(new Vector2(CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes)));
	}

	// Token: 0x060011A5 RID: 4517 RVA: 0x00072C07 File Offset: 0x00071007
	private static void ConvertToVector3(List<Vector3> list, byte[] bytes)
	{
		list.Add(new Vector3(CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes)));
	}

	// Token: 0x060011A6 RID: 4518 RVA: 0x00072C26 File Offset: 0x00071026
	private static void ConvertToQuaternion(List<Quaternion> list, byte[] bytes)
	{
		list.Add(new Quaternion(CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes)));
	}

	// Token: 0x060011A7 RID: 4519 RVA: 0x00072C4B File Offset: 0x0007104B
	private static void ConvertToColor(List<Color> list, byte[] bytes)
	{
		list.Add(new Color(CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes), CryptoPlayerPrefsX.ConvertBytesToFloat(bytes)));
	}

	// Token: 0x060011A8 RID: 4520 RVA: 0x00072C70 File Offset: 0x00071070
	public static void ShowArrayType(string key)
	{
		byte[] array = Convert.FromBase64String(CryptoPlayerPrefs.GetString(key, string.Empty));
		if (array.Length > 0)
		{
			CryptoPlayerPrefsX.ArrayType arrayType = (CryptoPlayerPrefsX.ArrayType)array[0];
			Debug.Log(key + " is a " + arrayType.ToString() + " array");
		}
	}

	// Token: 0x060011A9 RID: 4521 RVA: 0x00072CC0 File Offset: 0x000710C0
	private static void Initialize()
	{
		if (BitConverter.IsLittleEndian)
		{
			CryptoPlayerPrefsX.endianDiff1 = 0;
			CryptoPlayerPrefsX.endianDiff2 = 0;
		}
		else
		{
			CryptoPlayerPrefsX.endianDiff1 = 3;
			CryptoPlayerPrefsX.endianDiff2 = 1;
		}
		if (CryptoPlayerPrefsX.byteBlock == null)
		{
			CryptoPlayerPrefsX.byteBlock = new byte[4];
		}
		CryptoPlayerPrefsX.idx = 1;
	}

	// Token: 0x060011AA RID: 4522 RVA: 0x00072D10 File Offset: 0x00071110
	private static bool SaveBytes(string key, byte[] bytes)
	{
		try
		{
			CryptoPlayerPrefs.SetString(key, Convert.ToBase64String(bytes));
		}
		catch
		{
			return false;
		}
		return true;
	}

	// Token: 0x060011AB RID: 4523 RVA: 0x00072D4C File Offset: 0x0007114C
	private static void ConvertFloatToBytes(float f, byte[] bytes)
	{
		CryptoPlayerPrefsX.byteBlock = BitConverter.GetBytes(f);
		CryptoPlayerPrefsX.ConvertTo4Bytes(bytes);
	}

	// Token: 0x060011AC RID: 4524 RVA: 0x00072D5F File Offset: 0x0007115F
	private static float ConvertBytesToFloat(byte[] bytes)
	{
		CryptoPlayerPrefsX.ConvertFrom4Bytes(bytes);
		return BitConverter.ToSingle(CryptoPlayerPrefsX.byteBlock, 0);
	}

	// Token: 0x060011AD RID: 4525 RVA: 0x00072D72 File Offset: 0x00071172
	private static void ConvertInt32ToBytes(int i, byte[] bytes)
	{
		CryptoPlayerPrefsX.byteBlock = BitConverter.GetBytes(i);
		CryptoPlayerPrefsX.ConvertTo4Bytes(bytes);
	}

	// Token: 0x060011AE RID: 4526 RVA: 0x00072D85 File Offset: 0x00071185
	private static int ConvertBytesToInt32(byte[] bytes)
	{
		CryptoPlayerPrefsX.ConvertFrom4Bytes(bytes);
		return BitConverter.ToInt32(CryptoPlayerPrefsX.byteBlock, 0);
	}

	// Token: 0x060011AF RID: 4527 RVA: 0x00072D98 File Offset: 0x00071198
	private static void ConvertTo4Bytes(byte[] bytes)
	{
		bytes[CryptoPlayerPrefsX.idx] = CryptoPlayerPrefsX.byteBlock[CryptoPlayerPrefsX.endianDiff1];
		bytes[CryptoPlayerPrefsX.idx + 1] = CryptoPlayerPrefsX.byteBlock[1 + CryptoPlayerPrefsX.endianDiff2];
		bytes[CryptoPlayerPrefsX.idx + 2] = CryptoPlayerPrefsX.byteBlock[2 - CryptoPlayerPrefsX.endianDiff2];
		bytes[CryptoPlayerPrefsX.idx + 3] = CryptoPlayerPrefsX.byteBlock[3 - CryptoPlayerPrefsX.endianDiff1];
		CryptoPlayerPrefsX.idx += 4;
	}

	// Token: 0x060011B0 RID: 4528 RVA: 0x00072E08 File Offset: 0x00071208
	private static void ConvertFrom4Bytes(byte[] bytes)
	{
		CryptoPlayerPrefsX.byteBlock[CryptoPlayerPrefsX.endianDiff1] = bytes[CryptoPlayerPrefsX.idx];
		CryptoPlayerPrefsX.byteBlock[1 + CryptoPlayerPrefsX.endianDiff2] = bytes[CryptoPlayerPrefsX.idx + 1];
		CryptoPlayerPrefsX.byteBlock[2 - CryptoPlayerPrefsX.endianDiff2] = bytes[CryptoPlayerPrefsX.idx + 2];
		CryptoPlayerPrefsX.byteBlock[3 - CryptoPlayerPrefsX.endianDiff1] = bytes[CryptoPlayerPrefsX.idx + 3];
		CryptoPlayerPrefsX.idx += 4;
	}

	// Token: 0x04001233 RID: 4659
	private static int endianDiff1;

	// Token: 0x04001234 RID: 4660
	private static int endianDiff2;

	// Token: 0x04001235 RID: 4661
	private static int idx;

	// Token: 0x04001236 RID: 4662
	private static byte[] byteBlock;

	// Token: 0x04001237 RID: 4663
	[CompilerGenerated]
	private static Action<int[], byte[], int> <>f__mg$cache0;

	// Token: 0x04001238 RID: 4664
	[CompilerGenerated]
	private static Action<float[], byte[], int> <>f__mg$cache1;

	// Token: 0x04001239 RID: 4665
	[CompilerGenerated]
	private static Action<Vector2[], byte[], int> <>f__mg$cache2;

	// Token: 0x0400123A RID: 4666
	[CompilerGenerated]
	private static Action<Vector3[], byte[], int> <>f__mg$cache3;

	// Token: 0x0400123B RID: 4667
	[CompilerGenerated]
	private static Action<Quaternion[], byte[], int> <>f__mg$cache4;

	// Token: 0x0400123C RID: 4668
	[CompilerGenerated]
	private static Action<Color[], byte[], int> <>f__mg$cache5;

	// Token: 0x0400123D RID: 4669
	[CompilerGenerated]
	private static Action<List<int>, byte[]> <>f__mg$cache6;

	// Token: 0x0400123E RID: 4670
	[CompilerGenerated]
	private static Action<List<float>, byte[]> <>f__mg$cache7;

	// Token: 0x0400123F RID: 4671
	[CompilerGenerated]
	private static Action<List<Vector2>, byte[]> <>f__mg$cache8;

	// Token: 0x04001240 RID: 4672
	[CompilerGenerated]
	private static Action<List<Vector3>, byte[]> <>f__mg$cache9;

	// Token: 0x04001241 RID: 4673
	[CompilerGenerated]
	private static Action<List<Quaternion>, byte[]> <>f__mg$cacheA;

	// Token: 0x04001242 RID: 4674
	[CompilerGenerated]
	private static Action<List<Color>, byte[]> <>f__mg$cacheB;

	// Token: 0x02000268 RID: 616
	private enum ArrayType
	{
		// Token: 0x04001244 RID: 4676
		Float,
		// Token: 0x04001245 RID: 4677
		Int32,
		// Token: 0x04001246 RID: 4678
		Bool,
		// Token: 0x04001247 RID: 4679
		String,
		// Token: 0x04001248 RID: 4680
		Vector2,
		// Token: 0x04001249 RID: 4681
		Vector3,
		// Token: 0x0400124A RID: 4682
		Quaternion,
		// Token: 0x0400124B RID: 4683
		Color
	}
}
