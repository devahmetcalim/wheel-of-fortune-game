
using UnityEngine;

namespace Game.SpinSystem.Utils
{
    public class TextureUtils : MonoBehaviour
    {
        public static Texture2D SpriteToTexture(Sprite sprite)
        {
            if (!Mathf.Approximately(sprite.rect.width, sprite.texture.width) || !Mathf.Approximately(sprite.rect.height, sprite.texture.height))
            {
                // Sprite bir atlas içinde, sadece kendi alanını al
                Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
                Color[] pixels = sprite.texture.GetPixels(
                    (int)sprite.textureRect.x,
                    (int)sprite.textureRect.y,
                    (int)sprite.textureRect.width,
                    (int)sprite.textureRect.height);
                newText.SetPixels(pixels);
                newText.Apply();
                return newText;
            }
            else
            {
                // Sprite tüm texture'u kapsıyorsa direkt döndür
                return sprite.texture;
            }
        }
    }
}

