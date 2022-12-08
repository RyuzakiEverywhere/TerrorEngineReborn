using System;
using ProtoBuf;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020001F9 RID: 505
[ProtoContract]
public sealed class NavMeshAgentSerializer
{
	// Token: 0x06000CD0 RID: 3280 RVA: 0x00062ADC File Offset: 0x00060EDC
	public NavMeshAgentSerializer(GameObject gameObject, NavMeshAgentSerializer component)
	{
		NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		if (navMeshAgent == null)
		{
			navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
		}
		navMeshAgent.destination = (Vector3)component.Destination;
		navMeshAgent.stoppingDistance = component.StoppingDistance;
		navMeshAgent.velocity = (Vector3)component.Velocity;
		navMeshAgent.nextPosition = (Vector3)component.NextPosition;
		navMeshAgent.baseOffset = component.BaseOffset;
		navMeshAgent.autoTraverseOffMeshLink = component.AutoTraverseOffMeshLink;
		navMeshAgent.autoRepath = component.AutoRepath;
		navMeshAgent.walkableMask = component.WalkableMask;
		navMeshAgent.speed = component.Speed;
		navMeshAgent.angularSpeed = component.AngularSpeed;
		navMeshAgent.acceleration = component.Acceleration;
		navMeshAgent.updatePosition = component.UpdatePosition;
		navMeshAgent.updateRotation = component.UpdateRotation;
		navMeshAgent.radius = component.Radius;
		navMeshAgent.height = component.Height;
		navMeshAgent.enabled = component.Enabled;
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x00062BD8 File Offset: 0x00060FD8
	public NavMeshAgentSerializer(GameObject gameObject)
	{
		NavMeshAgent component = gameObject.GetComponent<NavMeshAgent>();
		this.Destination = (Vector3Serializer)component.destination;
		this.StoppingDistance = component.stoppingDistance;
		this.Velocity = (Vector3Serializer)component.velocity;
		this.NextPosition = (Vector3Serializer)component.nextPosition;
		this.BaseOffset = component.baseOffset;
		this.AutoTraverseOffMeshLink = component.autoTraverseOffMeshLink;
		this.AutoRepath = component.autoRepath;
		this.WalkableMask = component.walkableMask;
		this.Speed = component.speed;
		this.AngularSpeed = component.angularSpeed;
		this.Acceleration = component.acceleration;
		this.UpdatePosition = component.updatePosition;
		this.UpdateRotation = component.updateRotation;
		this.Radius = component.radius;
		this.Height = component.height;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x00062CC1 File Offset: 0x000610C1
	private NavMeshAgentSerializer()
	{
	}

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x00062CC9 File Offset: 0x000610C9
	// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x00062CD1 File Offset: 0x000610D1
	[ProtoMember(1)]
	public Vector3Serializer Destination { get; set; }

	// Token: 0x1700018A RID: 394
	// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x00062CDA File Offset: 0x000610DA
	// (set) Token: 0x06000CD6 RID: 3286 RVA: 0x00062CE2 File Offset: 0x000610E2
	[ProtoMember(2)]
	public float StoppingDistance { get; set; }

	// Token: 0x1700018B RID: 395
	// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x00062CEB File Offset: 0x000610EB
	// (set) Token: 0x06000CD8 RID: 3288 RVA: 0x00062CF3 File Offset: 0x000610F3
	[ProtoMember(3)]
	public Vector3Serializer Velocity { get; set; }

	// Token: 0x1700018C RID: 396
	// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x00062CFC File Offset: 0x000610FC
	// (set) Token: 0x06000CDA RID: 3290 RVA: 0x00062D04 File Offset: 0x00061104
	[ProtoMember(4)]
	public Vector3Serializer NextPosition { get; set; }

	// Token: 0x1700018D RID: 397
	// (get) Token: 0x06000CDB RID: 3291 RVA: 0x00062D0D File Offset: 0x0006110D
	// (set) Token: 0x06000CDC RID: 3292 RVA: 0x00062D15 File Offset: 0x00061115
	[ProtoMember(5)]
	public float BaseOffset { get; set; }

	// Token: 0x1700018E RID: 398
	// (get) Token: 0x06000CDD RID: 3293 RVA: 0x00062D1E File Offset: 0x0006111E
	// (set) Token: 0x06000CDE RID: 3294 RVA: 0x00062D26 File Offset: 0x00061126
	[ProtoMember(6)]
	public bool AutoTraverseOffMeshLink { get; set; }

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x06000CDF RID: 3295 RVA: 0x00062D2F File Offset: 0x0006112F
	// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x00062D37 File Offset: 0x00061137
	[ProtoMember(7)]
	public bool AutoRepath { get; set; }

	// Token: 0x17000190 RID: 400
	// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x00062D40 File Offset: 0x00061140
	// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x00062D48 File Offset: 0x00061148
	[ProtoMember(8)]
	public int WalkableMask { get; set; }

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x00062D51 File Offset: 0x00061151
	// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x00062D59 File Offset: 0x00061159
	[ProtoMember(9)]
	public float Speed { get; set; }

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00062D62 File Offset: 0x00061162
	// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x00062D6A File Offset: 0x0006116A
	[ProtoMember(10)]
	public float AngularSpeed { get; set; }

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x00062D73 File Offset: 0x00061173
	// (set) Token: 0x06000CE8 RID: 3304 RVA: 0x00062D7B File Offset: 0x0006117B
	[ProtoMember(11)]
	public float Acceleration { get; set; }

	// Token: 0x17000194 RID: 404
	// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x00062D84 File Offset: 0x00061184
	// (set) Token: 0x06000CEA RID: 3306 RVA: 0x00062D8C File Offset: 0x0006118C
	[ProtoMember(12)]
	public bool UpdatePosition { get; set; }

	// Token: 0x17000195 RID: 405
	// (get) Token: 0x06000CEB RID: 3307 RVA: 0x00062D95 File Offset: 0x00061195
	// (set) Token: 0x06000CEC RID: 3308 RVA: 0x00062D9D File Offset: 0x0006119D
	[ProtoMember(13)]
	public bool UpdateRotation { get; set; }

	// Token: 0x17000196 RID: 406
	// (get) Token: 0x06000CED RID: 3309 RVA: 0x00062DA6 File Offset: 0x000611A6
	// (set) Token: 0x06000CEE RID: 3310 RVA: 0x00062DAE File Offset: 0x000611AE
	[ProtoMember(14)]
	public float Radius { get; set; }

	// Token: 0x17000197 RID: 407
	// (get) Token: 0x06000CEF RID: 3311 RVA: 0x00062DB7 File Offset: 0x000611B7
	// (set) Token: 0x06000CF0 RID: 3312 RVA: 0x00062DBF File Offset: 0x000611BF
	[ProtoMember(15)]
	public float Height { get; set; }

	// Token: 0x17000198 RID: 408
	// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x00062DC8 File Offset: 0x000611C8
	// (set) Token: 0x06000CF2 RID: 3314 RVA: 0x00062DD0 File Offset: 0x000611D0
	[ProtoMember(16)]
	public ObstacleAvoidanceTypeSerializer ObstacleAvoidanceType { get; set; }

	// Token: 0x17000199 RID: 409
	// (get) Token: 0x06000CF3 RID: 3315 RVA: 0x00062DD9 File Offset: 0x000611D9
	// (set) Token: 0x06000CF4 RID: 3316 RVA: 0x00062DE1 File Offset: 0x000611E1
	[ProtoMember(17)]
	public bool Enabled { get; set; }
}
