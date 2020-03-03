using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class UseRenderingPlugin : MonoBehaviour
{
    #if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
        [DllImport("__Internal")]
    #else
        [DllImport("RenderingPlugin")]
    #endif
        private static extern void SetTimeFromUnity(float t);

        IEnumerator Start()
        {
            yield return StartCoroutine("CallPluginAtEndOfFrames");
        }

        private IEnumerator CallPluginAtEndOfFrames()
        {
            while(true)
            {
                // Wait until all frame rendering is done

                // Set time for the plugin
                SetTimeFromUnity(Time.timeSinceLevelLoad);
            }
        }
}