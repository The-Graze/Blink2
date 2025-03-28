using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Blink2
{

    class BlinkManager : MonoBehaviour
    {
        private GorillaEyeExpressions? eye;
        public void OnEnable() => StartCoroutine(BlinkLoop());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator BlinkLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                if (Random.Range(0, 3) == 0)
                {
                    TriggerBlink();
                }
            }
        }
        private void TriggerBlink()
        {
            if (eye == null)
            {
                eye = GetComponent<GorillaEyeExpressions>();
            }
            else
            {
                eye.overrideDuration = eye.screamDuration;
                eye.overrideUV = new Vector2(0.25f, 0);
                eye.IsEyeExpressionOverriden = true;
            }
        }
    }
}
