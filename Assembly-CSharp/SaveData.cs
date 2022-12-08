using System;
using System.Collections.Generic;
using ProtoBuf;

// Token: 0x0200024D RID: 589
[ProtoContract]
public sealed class SaveData
{
	// Token: 0x17000302 RID: 770
	// (get) Token: 0x06001076 RID: 4214 RVA: 0x000684B7 File Offset: 0x000668B7
	// (set) Token: 0x06001077 RID: 4215 RVA: 0x000684BF File Offset: 0x000668BF
	[ProtoMember(4)]
	public string LevelName { get; set; }

	// Token: 0x0400111E RID: 4382
	[ProtoMember(1)]
	public List<string> UniqueGameObjectNames = new List<string>();

	// Token: 0x0400111F RID: 4383
	[ProtoMember(2)]
	public List<GameObjectSerializer> GameObjects = new List<GameObjectSerializer>();

	// Token: 0x04001120 RID: 4384
	[ProtoMember(3)]
	public List<string> DestroyedObjectNames = new List<string>();
}
