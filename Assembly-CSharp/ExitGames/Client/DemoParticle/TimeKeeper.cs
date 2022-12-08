using System;

namespace ExitGames.Client.DemoParticle
{
	// Token: 0x0200015A RID: 346
	public class TimeKeeper
	{
		// Token: 0x0600084F RID: 2127 RVA: 0x0004B725 File Offset: 0x00049B25
		public TimeKeeper(int interval)
		{
			this.IsEnabled = true;
			this.Interval = interval;
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0004B746 File Offset: 0x00049B46
		// (set) Token: 0x06000851 RID: 2129 RVA: 0x0004B74E File Offset: 0x00049B4E
		public int Interval { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x0004B757 File Offset: 0x00049B57
		// (set) Token: 0x06000853 RID: 2131 RVA: 0x0004B75F File Offset: 0x00049B5F
		public bool IsEnabled { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x0004B768 File Offset: 0x00049B68
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x0004B79A File Offset: 0x00049B9A
		public bool ShouldExecute
		{
			get
			{
				return this.IsEnabled && (this.shouldExecute || Environment.TickCount - this.lastExecutionTime > this.Interval);
			}
			set
			{
				this.shouldExecute = value;
			}
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0004B7A3 File Offset: 0x00049BA3
		public void Reset()
		{
			this.shouldExecute = false;
			this.lastExecutionTime = Environment.TickCount;
		}

		// Token: 0x04000A59 RID: 2649
		private int lastExecutionTime = Environment.TickCount;

		// Token: 0x04000A5A RID: 2650
		private bool shouldExecute;
	}
}
