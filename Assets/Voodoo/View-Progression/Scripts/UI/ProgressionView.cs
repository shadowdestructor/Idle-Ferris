using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Voodoo.Meta
{
	public class ProgressionView : View<ProgressionView>
	{
		public void UpdateProgression(float _progression, float _maxProgression)
		{
			if (_maxProgression <= 0)
			{
				Debug.LogError("_maxProgression must be > 0.");
				return;
			}

			float clampedProgression = Mathf.Clamp(_progression, 0, _maxProgression);
			float fillAmount = clampedProgression / _maxProgression;

		}
	}
}
