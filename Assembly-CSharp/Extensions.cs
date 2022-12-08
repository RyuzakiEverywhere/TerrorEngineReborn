using System;
using System.Collections;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x0200012F RID: 303
public static class Extensions
{
	// Token: 0x060006C2 RID: 1730 RVA: 0x00042DF8 File Offset: 0x000411F8
	public static PhotonView[] GetPhotonViewsInChildren(this GameObject go)
	{
		return go.GetComponentsInChildren<PhotonView>(true);
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x00042E01 File Offset: 0x00041201
	public static PhotonView GetPhotonView(this GameObject go)
	{
		return go.GetComponent<PhotonView>();
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00042E0C File Offset: 0x0004120C
	public static bool AlmostEquals(this Vector3 target, Vector3 second, float sqrMagniturePrecision)
	{
		return (target - second).sqrMagnitude < sqrMagniturePrecision;
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00042E2C File Offset: 0x0004122C
	public static bool AlmostEquals(this Vector2 target, Vector2 second, float sqrMagniturePrecision)
	{
		return (target - second).sqrMagnitude < sqrMagniturePrecision;
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00042E4B File Offset: 0x0004124B
	public static bool AlmostEquals(this Quaternion target, Quaternion second, float maxAngle)
	{
		return Quaternion.Angle(target, second) < maxAngle;
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00042E57 File Offset: 0x00041257
	public static bool AlmostEquals(this float target, float second, float floatDiff)
	{
		return Mathf.Abs(target - second) < floatDiff;
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x00042E64 File Offset: 0x00041264
	public static void Merge(this IDictionary target, IDictionary addHash)
	{
		if (addHash == null || target.Equals(addHash))
		{
			return;
		}
		IEnumerator enumerator = addHash.Keys.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object key = enumerator.Current;
				target[key] = addHash[key];
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

	// Token: 0x060006C9 RID: 1737 RVA: 0x00042EE0 File Offset: 0x000412E0
	public static void MergeStringKeys(this IDictionary target, IDictionary addHash)
	{
		if (addHash == null || target.Equals(addHash))
		{
			return;
		}
		IEnumerator enumerator = addHash.Keys.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (obj is string)
				{
					target[obj] = addHash[obj];
				}
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

	// Token: 0x060006CA RID: 1738 RVA: 0x00042F68 File Offset: 0x00041368
	public static string ToStringFull(this IDictionary origin)
	{
		return SupportClass.DictionaryToString(origin, false);
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x00042F74 File Offset: 0x00041374
	public static Hashtable StripToStringKeys(this IDictionary original)
	{
		Hashtable hashtable = new Hashtable();
		IDictionaryEnumerator enumerator = original.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				if (dictionaryEntry.Key is string)
				{
					hashtable[dictionaryEntry.Key] = dictionaryEntry.Value;
				}
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
		return hashtable;
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x00042FFC File Offset: 0x000413FC
	public static void StripKeysWithNullValues(this IDictionary original)
	{
		object[] array = new object[original.Count];
		original.Keys.CopyTo(array, 0);
		foreach (object key in array)
		{
			if (original[key] == null)
			{
				original.Remove(key);
			}
		}
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x00043050 File Offset: 0x00041450
	public static bool Contains(this int[] target, int nr)
	{
		for (int i = 0; i < target.Length; i++)
		{
			if (target[i] == nr)
			{
				return true;
			}
		}
		return false;
	}
}
