using System;
using System.Collections;
using System.Collections.Generic;
using AssetKits.ParticleImage;
using Game.SpinSystem.Utils;
using Game.Systems.Event;
using UnityEngine;

namespace Game.SpinSystem.UI.Collected
{
    public class CollectedParticleImage : MonoBehaviour
    {
        
        [SerializeField] private ParticleImage particleImage;
        [SerializeField] private float particleSize;
        [SerializeField] private int maxParticles;
        private void OnValidate()
        {
            if (particleImage == null)
            {
                particleImage = GetComponent<ParticleImage>();
            }
        }

        private void OnEnable()
        {
            EventManager.Subscribe<RewardCollectedEvent>(RewardCollected);
        }

        private void RewardCollected(RewardCollectedEvent obj)
        { 
            AddressableSpriteCache.GetSprite(obj.item.iconReference, sprite =>
            {
                particleImage.Stop();
                int particleAmount = maxParticles;
                if (obj.item.amount <= maxParticles)
                {
                    particleAmount = obj.item.amount;
                }
                particleImage.SetBurst(0,0, particleAmount);
                float aspectRatio = sprite.rect.height / sprite.rect.width;
                particleImage.SetSeperated(particleSize, particleSize * aspectRatio);
                particleImage.sprite = sprite;
                particleImage.Play();
            });
         
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe<RewardCollectedEvent>(RewardCollected);
        }
    }

}

