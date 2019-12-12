using System.Collections.Generic;
using DeadBreach.ECS;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Entitas.VisualDebugging.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable CheckNamespace

public class Id : IComponent { [PrimaryEntityIndex] public int value; }
public class TileLink : IComponent { public int id; }

[Unique] public class MainCamera : IComponent { public Camera value; }
[Unique] public class MainCanvas : IComponent { public Canvas value; }

public class TouchComponent : IComponent { }
public class Touchable : IComponent { }
public class Touched : IComponent { }

public class PointerEnterHandler : IComponent { }
public class PointerEnter : IComponent { }

public class GameObjectComponent : IComponent { public GameObject value; }
public class Position : IComponent { public Vector3 value; }
public class Scale : IComponent { public Vector3 value; }
public class Rotation : IComponent { public Vector3 value; }

public class GameObjectDestroyed : IComponent { }
public class Destroyed : IComponent { }

public class Player : IComponent { }
public class Tile : IComponent { }
public class PathTile : IComponent { }
public class PathEndTile : IComponent { }
public class DestroyedTile : IComponent { }
public class PathDestroyed : IComponent { }
public class Target : IComponent { public Vector2Int value; }
public class GridPosition : IComponent { public Vector2Int value; }
public class StartTile : IComponent { }

public class PathFinderAgent : IComponent { }
public class PathFinderObstacle : IComponent { }
public class PathFinderPath : IComponent { public List<Vector2Int> value; }
public class PathFinderPathConfirmed : IComponent { }


public class ImageComponent : IComponent{ public Image value; }
public class ImageColor : IComponent{ public Color value; }


public class UnityAnimatorRequested : IComponent{}
public class UnityAnimator : IComponent { public Animator value; }
public class UnityAnimatorFloat : IComponent { public string name; public float value; public Animator animator;}
public class UnityAnimatorInt : IComponent { public string name; public int value; public Animator animator;}
public class UnityAnimatorBool : IComponent { public string name; public bool value; public Animator animator;}

[DontDrawComponent] public class Tween : IComponent { public DG.Tweening.Tween value; }
public class TweenPlaying : IComponent { }
public class TweenMove : IComponent { public TweenTransform to; }

public class TextMeshProText : IComponent { public TMP_Text value; }
public class Text : IComponent { public string value; }
public class TextColor : IComponent { public Color value; }