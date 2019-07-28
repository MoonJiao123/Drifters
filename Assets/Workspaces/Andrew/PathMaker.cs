using Andtech.Bezier;
using Andtech.Bezier.Debugging;
using Andtech.Extrusion;
using UnityEngine;

namespace Unsorted {

	[ExecuteAlways]
	public class PathMaker : MonoBehaviour {
		public Transform transformA;
		public Transform transformB;

		public int pointCount;

		public CrossSection2D crossSection;

		public MeshFilter meshFilter;

		void Awake() {
			MakeMesh();
		}

		void MakeMesh() {
			ControlPoint cpA = new ControlPoint(transformA.position, transformA.forward * transformA.localScale.z);
			ControlPoint cpB = new ControlPoint(transformB.position, transformB.forward * transformB.localScale.z);

			Curve curve = CubicBezier.Evaluate(cpA, cpB, pointCount);
			ExtruderResult result = Extruder.Extrude(curve, crossSection, LineTextureMode.Tile);

			meshFilter.sharedMesh = result.GenerateMesh();
		}

#if UNITY_EDITOR
		void OnValidate() {
			MakeMesh();
		}

		void Update() {
			MakeMesh();
		}
#endif
	}
}
