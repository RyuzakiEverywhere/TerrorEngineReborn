using System;
using SimpleAI.Navigation;
using SimpleAI.Steering;
using UnityEngine;

// Token: 0x0200017C RID: 380
[RequireComponent(typeof(Rigidbody))]
public class SteeringAgentComponent : MonoBehaviour
{
	// Token: 0x06000904 RID: 2308 RVA: 0x00051FFF File Offset: 0x000503FF
	private void Awake()
	{
		this.m_path = null;
		this.m_bArrived = false;
		this.m_pathTerrain = null;
		this.m_accelerationRate = 1000f;
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x00052024 File Offset: 0x00050424
	private void Update()
	{
		if (this.npcmodel == null)
		{
			this.npcmodel = base.transform.Find("npc-pos").gameObject.transform;
		}
		if (this.m_bArrived)
		{
			if (base.gameObject.GetComponent<NpcSync>().usestatic)
			{
				NoiseEffect[] array = UnityEngine.Object.FindObjectsOfType(typeof(NoiseEffect)) as NoiseEffect[];
				foreach (NoiseEffect noiseEffect in array)
				{
					noiseEffect.enabled = true;
				}
			}
			if (base.gameObject.GetComponent<NpcSync>().advancedstatic)
			{
				GameObject.Find("StaticEffect").GetComponent<SlenderStatic>().startstatic = true;
			}
		}
		else if (base.gameObject.GetComponent<NpcSync>().usestatic)
		{
			NoiseEffect[] array3 = UnityEngine.Object.FindObjectsOfType(typeof(NoiseEffect)) as NoiseEffect[];
			foreach (NoiseEffect noiseEffect2 in array3)
			{
				noiseEffect2.enabled = false;
			}
		}
		if (this.m_bArrived)
		{
			base.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		else if (this.m_path != null)
		{
			float num = this.m_path.MapPointToPathDistance(base.transform.position);
			float pathDistance = num + this.m_lookAheadDistance;
			Vector3 vector = this.m_path.MapPathDistanceToPoint(pathDistance);
			vector.y = this.m_pathTerrain.GetTerrainHeight(vector);
			Vector3 velocity = Vector3.zero;
			Vector3 vector2 = this.m_path.Points[this.m_path.Points.Length - 1];
			vector2.y = this.m_pathTerrain.GetTerrainHeight(vector2);
			Vector3 position = base.transform.position;
			position.y = this.m_pathTerrain.GetTerrainHeight(position);
			float num2 = Vector3.Distance(position, vector2);
			this.targetDir = Quaternion.LookRotation(new Vector3(vector2.x, base.transform.position.y, vector2.z) - base.transform.position);
			this.npcmodel.rotation = Quaternion.Slerp(this.npcmodel.rotation, this.targetDir, 10f * Time.deltaTime);
			if (num2 <= this.m_arrivalDistance)
			{
				if (!this.m_bArrived)
				{
					velocity = Vector3.zero;
					this.OnArrived();
				}
			}
			else
			{
				velocity = this.ComputeArrivalVelocity(vector, vector2, position, base.GetComponent<Rigidbody>().velocity);
			}
			base.GetComponent<Rigidbody>().velocity = velocity;
		}
		if (base.gameObject.GetComponent<Interaction_Chase>().enabled && !this.checkchase)
		{
			this.ischasing = true;
			this.checkchase = true;
		}
		base.GetComponent<Rigidbody>().AddForce(Vector3.down * 100f);
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x00052328 File Offset: 0x00050728
	private void OnDrawGizmos()
	{
		if (this.m_debugShowPath && this.m_path != null)
		{
			Gizmos.color = this.m_debugPathColor;
			for (int i = 1; i < this.m_path.PointCount; i++)
			{
				Vector3 from = this.m_path.Points[i - 1] + Vector3.up * 0.1f;
				Vector3 to = this.m_path.Points[i] + Vector3.up * 0.1f;
				Gizmos.DrawLine(from, to);
			}
			Gizmos.color = this.m_debugGoalColor;
			Vector3 center = this.m_path.Points[this.m_path.PointCount - 1] + Vector3.up * 0.1f;
			Gizmos.DrawWireSphere(center, this.m_arrivalDistance);
		}
		if (this.m_debugShowVelocity)
		{
			Gizmos.DrawRay(base.transform.position, base.GetComponent<Rigidbody>().velocity);
		}
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x0005244A File Offset: 0x0005084A
	public void SteerAlongPath(Vector3[] path, IPathTerrain pathTerrain)
	{
		this.m_pathTerrain = pathTerrain;
		this.m_bArrived = false;
		this.m_path = new PolylinePathway(path.Length, path);
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x00052469 File Offset: 0x00050869
	public void StopSteering()
	{
		this.m_bArrived = false;
		this.m_path = null;
		base.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x00052489 File Offset: 0x00050889
	private void OnArrived()
	{
		this.m_bArrived = true;
		base.SendMessageUpwards("OnSteeringRequestSucceeded", SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x000524A0 File Offset: 0x000508A0
	private Vector3 ComputeArrivalVelocity(Vector3 seekPos, Vector3 target, Vector3 position, Vector3 currentVelocity)
	{
		float magnitude = (target - position).magnitude;
		float value = this.m_maxSpeed * (magnitude / this.m_slowingDistance);
		float min = this.m_maxSpeed / 4f;
		float maxLength = Mathf.Clamp(value, min, this.m_maxSpeed);
		Vector3 a = seekPos - position;
		a.y = 0f;
		a.Normalize();
		Vector3 b = -Vector3.up * this.m_gravitationalAccelerationRate * base.GetComponent<Rigidbody>().mass;
		Vector3 a2 = this.m_accelerationRate * a + b;
		Vector3 vec = currentVelocity + a2 * Time.deltaTime;
		return PolylinePathway.TruncateLength(vec, maxLength);
	}

	// Token: 0x04000AFD RID: 2813
	public float m_arrivalDistance = 0.25f;

	// Token: 0x04000AFE RID: 2814
	public float m_maxSpeed = 2f;

	// Token: 0x04000AFF RID: 2815
	public float m_lookAheadDistance = 0.5f;

	// Token: 0x04000B00 RID: 2816
	public float m_slowingDistance = 1f;

	// Token: 0x04000B01 RID: 2817
	public float m_accelerationRate = 25f;

	// Token: 0x04000B02 RID: 2818
	public float m_gravitationalAccelerationRate;

	// Token: 0x04000B03 RID: 2819
	public Color m_debugPathColor = Color.yellow;

	// Token: 0x04000B04 RID: 2820
	public Color m_debugGoalColor = Color.red;

	// Token: 0x04000B05 RID: 2821
	public bool m_debugShowPath = true;

	// Token: 0x04000B06 RID: 2822
	public bool m_debugShowVelocity;

	// Token: 0x04000B07 RID: 2823
	public Vector3 target;

	// Token: 0x04000B08 RID: 2824
	public Quaternion targetDir;

	// Token: 0x04000B09 RID: 2825
	public bool ischasing;

	// Token: 0x04000B0A RID: 2826
	public bool checkchase;

	// Token: 0x04000B0B RID: 2827
	public Transform npcmodel;

	// Token: 0x04000B0C RID: 2828
	public PolylinePathway m_path;

	// Token: 0x04000B0D RID: 2829
	public bool m_bArrived;

	// Token: 0x04000B0E RID: 2830
	private IPathTerrain m_pathTerrain;
}
