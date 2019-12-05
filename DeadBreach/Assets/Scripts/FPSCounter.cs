using TMPro;
using UnityEngine;

namespace SpaceLandingSim
{
    public class FPSCounter : MonoBehaviour
    {
        private TextMeshProUGUI text;

        void Start() => 
            text = GetComponent<TextMeshProUGUI>();

        void Update() => 
            text.text = ((int)(1f / Time.unscaledDeltaTime)).ToString();
    }
}
