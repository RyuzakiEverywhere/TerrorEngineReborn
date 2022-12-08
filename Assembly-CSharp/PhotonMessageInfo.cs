using System;

// Token: 0x0200013D RID: 317
public class PhotonMessageInfo
{
	// Token: 0x06000745 RID: 1861 RVA: 0x00047CBC File Offset: 0x000460BC
	public PhotonMessageInfo()
	{
		this.sender = PhotonNetwork.player;
		this.timeInt = (int)(PhotonNetwork.time * 1000.0);
		this.photonView = null;
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x00047CEC File Offset: 0x000460EC
	public PhotonMessageInfo(PhotonPlayer player, int timestamp, PhotonView view)
	{
		this.sender = player;
		this.timeInt = timestamp;
		this.photonView = view;
	}

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x06000747 RID: 1863 RVA: 0x00047D09 File Offset: 0x00046109
	public double timestamp
	{
		get
		{
			return this.timeInt / 1000.0;
		}
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x00047D1D File Offset: 0x0004611D
	public override string ToString()
	{
		return string.Format("[PhotonMessageInfo: player='{1}' timestamp={0}]", this.timestamp, this.sender);
	}

	// Token: 0x040009D6 RID: 2518
	private int timeInt;

	// Token: 0x040009D7 RID: 2519
	public PhotonPlayer sender;

	// Token: 0x040009D8 RID: 2520
	public PhotonView photonView;
}
