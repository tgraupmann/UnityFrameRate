// reference: https://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html
// reference: https://forum.unity3d.com/threads/how-can-i-display-fps-on-android-device.386250/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FramesPerSecond : MonoBehaviour
{
    public Text _mTextFPS = null;
    private int _mFramesPerSec;
    private float _mFrequency = 1.0f;

    void Awake()
    {
        Application.targetFrameRate = 200; //mobile appears capped at 60 fps
        //QualitySettings.vSyncCount = 2; //limit to 30 FPS on mobile
        QualitySettings.vSyncCount = 1; // capped at 60 fps on mobile
        //QualitySettings.vSyncCount = 0; // capped at 60 fps on mobile
    }

    void Start()
    {
        StartCoroutine(FPS());
    }

    private IEnumerator FPS()
    {
        while (true)
        {
            // Capture frame-per-second
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(_mFrequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;

            // Display it
            if (_mTextFPS)
            {
                _mTextFPS.text = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
            }
        }
    }
}
