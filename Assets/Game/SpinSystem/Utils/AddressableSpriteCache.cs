using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.SpinSystem.Utils
{
    public static class AddressableSpriteCache
    {
        private static readonly Dictionary<AssetReferenceAtlasedSprite, Sprite> _spriteCache = new();

        public static void GetSprite(AssetReferenceAtlasedSprite reference, Action<Sprite> onComplete)
        {
            if (reference == null)
            {
                Debug.LogWarning("⚠ Sprite reference is null.");
                onComplete?.Invoke(null);
                return;
            }

            if (_spriteCache.TryGetValue(reference, out var cachedSprite))
            {
                onComplete?.Invoke(cachedSprite);
                return;
            }

            // ✅ Eğer asset zaten yüklendiyse
            if (reference.IsDone && reference.Asset is Sprite sprite)
            {
                _spriteCache[reference] = sprite;
                onComplete?.Invoke(sprite);
                return;
            }

            // ⛔ Eğer asset yüklü değilse, o zaman load et
            var handle = reference.LoadAssetAsync<Sprite>();
            handle.Completed += h =>
            {
                if (h.Status == AsyncOperationStatus.Succeeded)
                {
                    _spriteCache[reference] = h.Result;
                    onComplete?.Invoke(h.Result);
                }
                else
                {
                    Debug.LogWarning($"❌ Failed to load sprite: {reference.RuntimeKey}");
                    onComplete?.Invoke(null);
                }
            };
        }


        public static void ClearCache()
        {
            _spriteCache.Clear();
        }
    }
}