using Entitas;
using Entitas.CodeGeneration.Attributes;
using TMPro;
using UnityEngine;

// ReSharper disable CheckNamespace

public class Id : IComponent { [PrimaryEntityIndex] public int value; }
public class TileLink : IComponent { public int id; }
public class TileNameLink : IComponent { public int id; }
public class TileHealthLink : IComponent { public int id; }
public class TileIconLink : IComponent { public int id; }

[Unique] public class MainCamera : IComponent { public Camera value; }

public class TouchComponent : IComponent { }
public class Touchable : IComponent { }
public class Touched : IComponent { }

public class GameObjectComponent : IComponent { public GameObject value; }
public class Position : IComponent { public Vector3 value; }
public class Scale : IComponent { public Vector3 value; }
public class Rotation : IComponent { public Vector3 value; }
public class Activeness : IComponent { public bool value; }

public class Destroyed : IComponent { }

public class Tile : IComponent { }
public class Target : IComponent { }
public class TileName : IComponent { public string value; }
public class CubicPosition : IComponent { public Vector3Int value; }
public class GridPosition : IComponent { public Vector3Int value; }
public class TileHealth : IComponent { public int value; }
public class TileMaxHealth : IComponent { public int value; }

public class Player : IComponent { }
public class EmptyTile : IComponent { }


public class UnityAnimatorRequested : IComponent{}
public class UnityAnimator : IComponent { public Animator value; }
public class UnityAnimatorFloat : IComponent { public string name; public float value; public Animator animator;}
public class UnityAnimatorInt : IComponent { public string name; public int value; public Animator animator;}
public class UnityAnimatorBool : IComponent { public string name; public bool value; public Animator animator;}


public class TextMeshProText : IComponent { public TMP_Text value; }
public class Text : IComponent { public string value; }
public class TextColor : IComponent { public Color value; }