using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FloorTiler : MonoBehaviour {
	public Sprite floorSprite;
	public float tileCount = 1;
	public float colliderInset = 0.1f;
	private float oldTileCount = 0;
	private float oldInset = 0;
	private GameObject[] tiles = new GameObject[0];
	bool initialized = false;
	public bool flipInside = false;
	private bool oldFlip = false;
	public int orderInLayer = 0;
	private int oldOrderInLayer = -1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if ((!initialized || CheckHasChanged()) && floorSprite != null) {
			initialized = true;
			oldTileCount = tileCount;
			oldInset = colliderInset;
			oldFlip = flipInside;
			oldOrderInLayer = orderInLayer;
			DestroyChildren ();
			GenerateTiles ();
			GenerateColliders ();
		}
	}

	private bool CheckHasChanged(){
		bool hasChanged = false;
		hasChanged = hasChanged || tileCount != oldTileCount;
		hasChanged = hasChanged || colliderInset != oldInset;
		hasChanged = hasChanged || flipInside != oldFlip;
		hasChanged = hasChanged || orderInLayer != oldOrderInLayer;
		return hasChanged;
	}

	private void DestroyChildren(){
		int childCount = transform.childCount;
		for (int i = 0; i < childCount; i++) {
			DestroyImmediate (transform.GetChild (0).gameObject);
		}
		tiles = new GameObject[0];
	}

	private void GenerateTiles(){
		int wholeTileCount = (int)tileCount;
		int partialTileCount;
		if (tileCount > wholeTileCount) {
			partialTileCount = wholeTileCount + 1;
		} else {
			partialTileCount = wholeTileCount;
		}
		tiles = new GameObject[partialTileCount];
		float floorWidth = floorSprite.bounds.size.x;
		for (int i = 0; i < wholeTileCount; i++) {
			SpawnTile (i, floorWidth * i);
		}
		if (wholeTileCount < partialTileCount) {
			SpawnTile (partialTileCount - 1, floorWidth * (tileCount - 1));
		}
	}

	private void SpawnTile(int index, float xOffset){
		tiles [index] = new GameObject ("Tile " + index);
		SpriteRenderer spriteRend = tiles [index].AddComponent<SpriteRenderer> ();
		spriteRend.sprite = floorSprite;
		spriteRend.sortingLayerName = "Mid-ground";
		spriteRend.sortingOrder = orderInLayer;
		tiles [index].transform.SetParent (transform);
		tiles [index].transform.localPosition = new Vector3(xOffset, 0, 0);
		tiles [index].transform.localRotation = Quaternion.identity;
		if (flipInside) {
			Vector3 newScale = tiles [index].transform.localScale;
			newScale.y *= -1;
			tiles [index].transform.localScale = newScale;
		}
	}

	private Bounds GetTotalBounds(){
		Bounds totalBounds = new Bounds (transform.position, Vector3.zero);
		for (int i = 0; i < tiles.Length; i++) {
			totalBounds.Encapsulate(tiles[i].GetComponent<SpriteRenderer>().bounds);
		}
		return totalBounds;
	}

	private void GenerateColliders(){
		Bounds totalBounds = GetTotalBounds ();
		Vector2 center, size;

		// Generate ground collider.
		center = (Vector2)totalBounds.center + new Vector2(0, -totalBounds.size.y / 4);
		size = new Vector2 (totalBounds.size.x - 2 * colliderInset, totalBounds.size.y / 2);
		SpawnColliderObject ("ground", center, size);

		// Generate roof collider.
		center = (Vector2)totalBounds.center + new Vector2(0, totalBounds.size.y / 4);
		size = new Vector2 (totalBounds.size.x - 2 * colliderInset, totalBounds.size.y / 2);
		SpawnColliderObject ("roof", center, size);

		// Generate left wall collider.
		center = (Vector2)totalBounds.center + new Vector2(totalBounds.size.x / 4, 0);
		size = new Vector2 (totalBounds.size.x / 2, totalBounds.size.y - 2 * colliderInset);
		SpawnColliderObject ("leftwall", center, size);

		// Generate right wall collider.
		center = (Vector2)totalBounds.center + new Vector2(-totalBounds.size.x / 4, 0);
		size = new Vector2 (totalBounds.size.x / 2, totalBounds.size.y - 2 * colliderInset);
		SpawnColliderObject ("leftwall", center, size);
	}

	private void SpawnColliderObject(string tag, Vector3 center, Vector3 size){
		GameObject obj = new GameObject (tag + " Collider");
		obj.transform.SetParent (transform);
		obj.transform.position = center;
		obj.tag = tag;
		BoxCollider2D collider = obj.AddComponent<BoxCollider2D> ();
		collider.size = size;
	}
}
