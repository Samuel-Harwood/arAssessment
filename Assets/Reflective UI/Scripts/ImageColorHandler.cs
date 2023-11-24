using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PomodoroGames.ReflectiveUI
{
    /// <summary>
    /// The color changing effect on Image is based on material component.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class ImageColorHandler : ColorHandler
    {
        private Material instancedMaterial;

        private void Start()
        {
            cameraRecorder = CameraRecorder.Instance;

            Material material = GetComponent<Image>().material;
            instancedMaterial = new Material(material);
            GetComponent<Image>().material = instancedMaterial;
        
            material.SetColor("_TopColor", Color.white);
            material.SetColor("_BottomColor", Color.white);
            material.SetColor("_LeftColor", Color.white);
            material.SetColor("_RightColor", Color.white);
        }

        protected override void HandleVerticalColorGradient()
        {
            Color[] colorData = cameraRecorder.GetVerticalColor(screenPosition * 100.0f);
            if (colorData != null)
            {
                Color targetTopColor = colorData[0];
                Color targetBottomColor = colorData[1];

                Color defaultTopColor = instancedMaterial.GetColor("_TopColor");
                Color defaultBottomColor = instancedMaterial.GetColor("_BottomColor");

                Color topColor = Color.Lerp(defaultTopColor, targetTopColor, Time.deltaTime * 2.0f);
                Color bottomColor = Color.Lerp(defaultBottomColor, targetBottomColor, Time.deltaTime * 2.0f);

                instancedMaterial.SetColor("_TopColor", topColor);
                instancedMaterial.SetColor("_BottomColor", bottomColor);
            }
        }

        protected override void HandleHorizontalColorGradient()
        {
            
            Color[] colorData = cameraRecorder.GetHorizontalColor(screenPosition * 100.0f);
            if (colorData != null)
            { 
                Color targetLeftColor = colorData[0];
                Color targetRightColor = colorData[1];

                Color defaultLeftColor = instancedMaterial.GetColor("_LeftColor");
                Color defaultRightColor = instancedMaterial.GetColor("_RightColor");

                Color leftColor = Color.Lerp(defaultLeftColor, targetLeftColor, Time.deltaTime * 2.0f);
                Color rightColor = Color.Lerp(defaultRightColor, targetRightColor, Time.deltaTime * 2.0f);

                instancedMaterial.SetColor("_LeftColor", leftColor);
                instancedMaterial.SetColor("_RightColor", rightColor);
            }
        }
    
    }
}


