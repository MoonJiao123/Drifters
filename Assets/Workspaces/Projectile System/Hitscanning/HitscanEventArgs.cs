using System;

namespace ProjectileSystem {

	public class HitscanEventArgs : EventArgs {
		public HitscanInfo ScanInfo => scanInfo;

		private readonly HitscanInfo scanInfo;

		public HitscanEventArgs(HitscanInfo scanInfo) {
			this.scanInfo = scanInfo;
		}
	}
}
