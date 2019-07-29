using Andtech;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Unsorted {

	public class Scrim : SingletonBehaviour<Scrim> {
		public TextMeshProUGUI textTitle;
		public TextMeshProUGUI textDescription;
		public CanvasGroup cg;
		public RectTransform rt;

		public static string Title {
			set => Current.textTitle.text = value;
		}
		public static string Description {
			set => Current.textDescription.text = value;
		}
		public int Powerup;

		public static void Show() {
			Current.StopAllCoroutines();
			Current.StartCoroutine(Current.Displaying());
		}

		IEnumerator Displaying() {
			foreach (float alpha in AlphaCurve.Sigmoid(0.75F)) {
				cg.alpha = alpha;
				rt.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, alpha);
				yield return null;
			}

			yield return new WaitForSeconds(4.0F);

			foreach (float alpha in AlphaCurve.Sigmoid(0.75F)) {
				cg.alpha = 1.0F - alpha;
				rt.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, alpha);
				yield return null;
			}
		}
	}
}
