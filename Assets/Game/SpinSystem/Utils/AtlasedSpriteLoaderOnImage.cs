using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Game.SpinSystem.Utils
{
    public class AtlasedSpriteLoaderOnImage : MonoBehaviour
    {
        [SerializeField] AssetReferenceAtlasedSprite spriteReference;
        [SerializeField] private Image image;

        private void OnValidate()
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }

        private void Awake()
        {
            AddressableSpriteCache.GetSprite(spriteReference, sprite =>
            {
                image.sprite = sprite;
            });
           
        }
    }

}
