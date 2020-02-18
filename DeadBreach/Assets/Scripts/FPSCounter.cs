using TMPro;
using UnityEngine;

namespace SpaceLandingSim
{
    public class FPSCounter : MonoBehaviour
    {
        private const int UpdateRate = 8;

        private TextMeshProUGUI text;

        private int frameCount;
        private float dt;
        private float fps;
        
        private void Start() => 
            text = GetComponent<TextMeshProUGUI>();


        private void Update()
        {
            frameCount++;
            dt += Time.unscaledDeltaTime;
            if (dt > 1f/UpdateRate)
            {
                fps = frameCount / dt ;
                text.text = ((int)(fps)).ToString();
                frameCount = 0;
                dt -= 1f/UpdateRate;
            }
        }
    }
}
