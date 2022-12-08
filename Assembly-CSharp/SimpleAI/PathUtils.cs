using System;
using UnityEngine;

namespace SimpleAI
{
	// Token: 0x0200019A RID: 410
	public static class PathUtils
	{
		// Token: 0x060009C7 RID: 2503 RVA: 0x00054C0C File Offset: 0x0005300C
		public static bool AreVertsTheSame(Vector3 v1, Vector3 v2)
		{
			return (v1 - v2).sqrMagnitude < 1.0000001E-06f;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x00054C30 File Offset: 0x00053030
		public static float CalcClockwiseAngle(Vector3 dir1, Vector3 dir2)
		{
			dir1.y = 0f;
			dir2.y = 0f;
			dir1.Normalize();
			dir2.Normalize();
			Vector3 rhs = Vector3.Cross(dir1, Vector3.up);
			rhs.Normalize();
			float num = Vector3.Dot(dir2, rhs);
			float f = Vector3.Dot(dir1, dir2);
			float result;
			if (num > 0f)
			{
				result = 6.2831855f - Mathf.Acos(f);
			}
			else
			{
				result = Mathf.Acos(f);
			}
			return result;
		}
	}
}
