using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Spin/Spin Visual Config")]
public class SpinVisualConfig : ScriptableObject
{
    public SpinType spinType;
    public Sprite wheelBaseSprite;
    public Sprite indicatorSprite;
    public string displayText;
    public Color DisplayNormalColor;
    public Color DisplayHighlightedColor;
    public Color TitleColor;
}
public enum SpinType
{
    Bronze,
    Silver,
    Gold
}