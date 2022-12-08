using System;
using ProtoBuf;

// Token: 0x0200024E RID: 590
[ProtoContract]
public sealed class SaveFileInfo
{
	// Token: 0x06001078 RID: 4216 RVA: 0x000684C8 File Offset: 0x000668C8
	public SaveFileInfo(string name, int levelNumber, string levelName, string date)
	{
		this.Name = name;
		this.LevelNumber = levelNumber;
		this.LevelName = levelName;
		this.Date = date;
	}

	// Token: 0x06001079 RID: 4217 RVA: 0x000684ED File Offset: 0x000668ED
	public SaveFileInfo(SaveFileInfo saveFileInfo)
	{
		this.Name = saveFileInfo.Name;
		this.LevelNumber = saveFileInfo.LevelNumber;
		this.LevelName = saveFileInfo.LevelName;
		this.Date = saveFileInfo.Date;
	}

	// Token: 0x0600107A RID: 4218 RVA: 0x00068525 File Offset: 0x00066925
	public SaveFileInfo()
	{
	}

	// Token: 0x17000303 RID: 771
	// (get) Token: 0x0600107B RID: 4219 RVA: 0x0006852D File Offset: 0x0006692D
	// (set) Token: 0x0600107C RID: 4220 RVA: 0x00068535 File Offset: 0x00066935
	[ProtoMember(1)]
	public string Name { get; private set; }

	// Token: 0x17000304 RID: 772
	// (get) Token: 0x0600107D RID: 4221 RVA: 0x0006853E File Offset: 0x0006693E
	// (set) Token: 0x0600107E RID: 4222 RVA: 0x00068546 File Offset: 0x00066946
	[ProtoMember(2)]
	public int LevelNumber { get; private set; }

	// Token: 0x17000305 RID: 773
	// (get) Token: 0x0600107F RID: 4223 RVA: 0x0006854F File Offset: 0x0006694F
	// (set) Token: 0x06001080 RID: 4224 RVA: 0x00068557 File Offset: 0x00066957
	[ProtoMember(3)]
	public string LevelName { get; private set; }

	// Token: 0x17000306 RID: 774
	// (get) Token: 0x06001081 RID: 4225 RVA: 0x00068560 File Offset: 0x00066960
	// (set) Token: 0x06001082 RID: 4226 RVA: 0x00068568 File Offset: 0x00066968
	[ProtoMember(4)]
	public string Date { get; private set; }
}
