using System;

namespace Andtech.Pooling {

	/// <summary>
	/// Indicates that the type can be pooled.
	/// </summary>
	public interface IPoolable {

		/// <summary>
		/// Forces the object to request to be reclaimed.
		/// </summary>
		void RequestReclaim();

		/// <summary>
		/// Invoked after the object had been dispatched by the pooling system.
		/// </summary>
		void OnDispatch();

		/// <summary>
		/// Invoked after the object had been reclaimed by the pooling system.
		/// </summary>
		void OnReclaim();

		#region EVENT
		event EventHandler RequestedReclaim;
		#endregion EVENT
	}
}
