using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PomodoroGames.ReflectiveUI
{
    /// <summary>
    /// The color changing effect on TextMeshPro is based on TextMeshProUGUI component
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMPColorHandler : ColorHandler
    {
        private TextMeshProUGUI textMeshPro;

        private TMP_ColorGradient colorGradient;
    
        private void Start()
        {
            cameraRecorder = CameraRecorder.Instance;
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }
    

        protected override void HandleVerticalColorGradient()
        {
            Color[] colorData = cameraRecorder.GetVerticalColor(screenPosition * 100.0f);
            if (colorData != null)
            {
                Color targetTopColor = colorData[0];
                Color targetBottomColor = colorData[1];

                Color defaultTopColor = textMeshPro.colorGradient.topLeft;
                Color defaultBottomColor = textMeshPro.colorGradient.bottomLeft;

                Color topColor = Color.Lerp(defaultTopColor, targetTopColor, Time.deltaTime * 2.0f);
                Color bottomColor = Color.Lerp(defaultBottomColor, targetBottomColor, Time.deltaTime * 2.0f);

                textMeshPro.colorGradient = new VertexGradient(topColor, bottomColor, topColor, bottomColor);
            }
        }
    
        protected override void HandleHorizontalColorGradient()
        {
            Color[] colorData = cameraRecorder.GetHorizontalColor(screenPosition * 100.0f);
            if (colorData != null)
            {
                Color targetLeftColor = colorData[0];
                Color targetRightColor = colorData[1];

                Color defaultLeftColor = textMeshPro.colorGradient.topLeft;
                Color defaultRightColor = textMeshPro.colorGradient.bottomRight;

                Color leftColor = Color.Lerp(defaultLeftColor, targetLeftColor, Time.deltaTime * 2.0f);
                Color rightColor = Color.Lerp(defaultRightColor, targetRightColor, Time.deltaTime * 2.0f);


                textMeshPro.colorGradient = new VertexGradient(leftColor, rightColor, leftColor, rightColor);
            }
        }
    
    }
}


