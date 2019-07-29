using Andtech;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unsorted {

	public class Scrim : SingletonBehaviour<Scrim> {
		public TextMeshProUGUI textTitle;
		public TextMeshProUGUI textDescription;
		public CanvasGroup cg;
		public RectTransform rt;

		public Graphic one;
		public Graphic two;
		public Graphic three;

		public static string Title {
			set => Current.textTitle.text = value;
		}
		public static string Description {
			set => Current.textDescription.text = value;
		}
		public static int Powerup {
			set {
				Current.one.enabled = value == 0;
				Current.two.enabled = value == 1;
				Current.three.enabled = value == 2;
			}
		}

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
