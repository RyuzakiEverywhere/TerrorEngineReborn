using System;
using UnityEngine;

namespace SimpleAI.Steering
{
	// Token: 0x0200018E RID: 398
	public class PolylinePathway : Pathway
	{
		// Token: 0x06000974 RID: 2420 RVA: 0x0005403F File Offset: 0x0005243F
		public PolylinePathway()
		{
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x00054047 File Offset: 0x00052447
		public PolylinePathway(int _pointCount)
		{
			this.Initialize(_pointCount, null);
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00054057 File Offset: 0x00052457
		public PolylinePathway(int _pointCount, Vector3[] _points)
		{
			this.Initialize(_pointCount, _points);
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x00054067 File Offset: 0x00052467
		public Vector3[] Points
		{
			get
			{
				return this.points;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x0005406F File Offset: 0x0005246F
		public int PointCount
		{
			get
			{
				return this.pointCount;
			}
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00054077 File Offset: 0x00052477
		public void ReInitialize(int _pointCount, Vector3[] _points)
		{
			this.Initialize(_pointCount, _points);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x00054084 File Offset: 0x00052484
		private void Initialize(int _pointCount, Vector3[] _points)
		{
			this.pointCount = _pointCount;
			this.totalPathLength = 0f;
			this.lengths = new float[this.pointCount];
			this.points = new Vector3[this.pointCount];
			this.normals = new Vector3[this.pointCount];
			if (_points == null)
			{
				return;
			}
			for (int i = 0; i < this.pointCount; i++)
			{
				bool flag = false;
				int num = (!flag) ? i : 0;
				this.points[i] = _points[num];
				if (i > 0)
				{
					this.normals[i] = this.points[i] - this.points[i - 1];
					this.lengths[i] = this.normals[i].magnitude;
					this.normals[i] *= 1f / this.lengths[i];
					this.totalPathLength += this.lengths[i];
				}
			}
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x000541BA File Offset: 0x000525BA
		public float GetTotalPathLength()
		{
			return this.totalPathLength;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x000541C4 File Offset: 0x000525C4
		public override float MapPointToPathDistance(Vector3 point)
		{
			float num = float.MaxValue;
			float num2 = 0f;
			float result = 0f;
			for (int i = 1; i < this.pointCount; i++)
			{
				this.segmentLength = this.lengths[i];
				this.segmentNormal = this.normals[i];
				float num3 = this.PointToSegmentDistance(point, this.points[i - 1], this.points[i]);
				if (num3 < num)
				{
					num = num3;
					result = num2 + this.segmentProjection;
				}
				num2 += this.segmentLength;
			}
			return result;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x00054270 File Offset: 0x00052670
		public override Vector3 MapPathDistanceToPoint(float pathDistance)
		{
			float num = pathDistance;
			if (pathDistance < 0f)
			{
				return this.points[0];
			}
			if (pathDistance >= this.totalPathLength)
			{
				return this.points[this.pointCount - 1];
			}
			Vector3 result = Vector3.zero;
			for (int i = 1; i < this.pointCount; i++)
			{
				this.segmentLength = this.lengths[i];
				if (this.segmentLength >= num)
				{
					float alpha = num / this.segmentLength;
					result = PolylinePathway.interpolate(alpha, this.points[i - 1], this.points[i]);
					break;
				}
				num -= this.segmentLength;
			}
			return result;
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x00054340 File Offset: 0x00052740
		public float PointToSegmentDistance(Vector3 point, Vector3 ep0, Vector3 ep1)
		{
			this.local = point - ep0;
			this.segmentProjection = Vector3.Dot(this.segmentNormal, this.local);
			if (this.segmentProjection < 0f)
			{
				this.chosen = ep0;
				this.segmentProjection = 0f;
				return (point - ep0).magnitude;
			}
			if (this.segmentProjection > this.segmentLength)
			{
				this.chosen = ep1;
				this.segmentProjection = this.segmentLength;
				return (point - ep1).magnitude;
			}
			this.chosen = this.segmentNormal * this.segmentProjection;
			this.chosen += ep0;
			return (point - this.chosen).magnitude;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x00054414 File Offset: 0x00052814
		public static float interpolate(float alpha, float x0, float x1)
		{
			return x0 + (x1 - x0) * alpha;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0005441D File Offset: 0x0005281D
		public static Vector3 interpolate(float alpha, Vector3 x0, Vector3 x1)
		{
			return x0 + (x1 - x0) * alpha;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00054434 File Offset: 0x00052834
		public static Vector3 TruncateLength(Vector3 vec, float maxLength)
		{
			float magnitude = vec.magnitude;
			Vector3 vector = vec;
			if (magnitude > maxLength)
			{
				vector.Normalize();
				vector *= maxLength;
			}
			return vector;
		}

		// Token: 0x04000B2C RID: 2860
		private int pointCount;

		// Token: 0x04000B2D RID: 2861
		private Vector3[] points;

		// Token: 0x04000B2E RID: 2862
		private float segmentLength;

		// Token: 0x04000B2F RID: 2863
		private float segmentProjection;

		// Token: 0x04000B30 RID: 2864
		private Vector3 local;

		// Token: 0x04000B31 RID: 2865
		private Vector3 chosen;

		// Token: 0x04000B32 RID: 2866
		private Vector3 segmentNormal;

		// Token: 0x04000B33 RID: 2867
		private float[] lengths;

		// Token: 0x04000B34 RID: 2868
		private Vector3[] normals;

		// Token: 0x04000B35 RID: 2869
		private float totalPathLength;
	}
}
