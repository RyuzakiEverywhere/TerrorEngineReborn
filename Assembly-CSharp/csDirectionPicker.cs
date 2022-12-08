using System;
using System.Collections.Generic;

// Token: 0x0200026B RID: 619
public class csDirectionPicker
{
	// Token: 0x17000318 RID: 792
	// (get) Token: 0x060011BB RID: 4539 RVA: 0x00072F96 File Offset: 0x00071396
	public bool HasNextDirection
	{
		get
		{
			return this.directionsPicked.Count < 4;
		}
	}

	// Token: 0x17000319 RID: 793
	// (get) Token: 0x060011BC RID: 4540 RVA: 0x00072FA6 File Offset: 0x000713A6
	private bool MustChangeDirection
	{
		get
		{
			return this.directionsPicked.Count > 0 || this.changeDirectionModifier > csRandom.Instance.Next(0, 99);
		}
	}

	// Token: 0x060011BD RID: 4541 RVA: 0x00072FD4 File Offset: 0x000713D4
	private csDungeonCell.DirectionType PickDifferentDirection()
	{
		csDungeonCell.DirectionType directionType;
		do
		{
			directionType = (csDungeonCell.DirectionType)csRandom.Instance.Next(3);
		}
		while (directionType == this.previousDirection && this.directionsPicked.Count < 3);
		return directionType;
	}

	// Token: 0x060011BE RID: 4542 RVA: 0x0007300C File Offset: 0x0007140C
	public csDungeonCell.DirectionType GetNextDirection()
	{
		if (!this.HasNextDirection)
		{
			throw new InvalidOperationException("No directions available");
		}
		csDungeonCell.DirectionType directionType;
		do
		{
			directionType = ((!this.MustChangeDirection) ? this.previousDirection : this.PickDifferentDirection());
		}
		while (this.directionsPicked.Contains(directionType));
		this.directionsPicked.Add(directionType);
		return directionType;
	}

	// Token: 0x060011BF RID: 4543 RVA: 0x0007306A File Offset: 0x0007146A
	public void Constructor(csDungeonCell.DirectionType previousDirection, int changeDirectionModifier)
	{
		this.previousDirection = previousDirection;
		this.changeDirectionModifier = changeDirectionModifier;
	}

	// Token: 0x04001251 RID: 4689
	private List<csDungeonCell.DirectionType> directionsPicked = new List<csDungeonCell.DirectionType>();

	// Token: 0x04001252 RID: 4690
	private csDungeonCell.DirectionType previousDirection;

	// Token: 0x04001253 RID: 4691
	private int changeDirectionModifier;
}
