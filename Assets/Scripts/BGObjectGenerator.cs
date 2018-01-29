using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BG_SPRITES {Bottle, Bush_1, Bush_2, Partyhats_1, Partyhats_2, HungoverVillager};

public class BGObjectGenerator : MonoBehaviour {
	public float spriteScrollSpeed = 2.35f;
	public int minimumSpriteY = -1000;

	public Sprite bottleSprite;
	public Sprite bushSprite_1;
	public Sprite bushSprite_2;
	public Sprite partyhatsSprite_1;
	public Sprite partyhatsSprite_2;
	public Sprite villagerSprite;

    public float StoneSize = 100;

	private float lastTimestamp;

	// wrapper that will hold all rendered Sprites
	private GameObject bgWrap;

	// Use this for initialization
	void Start () {
		this.bgWrap = this.bgWrap == null ? GameObject.Find("BG_Wrapper") : this.bgWrap; 
		this.lastTimestamp = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - this.lastTimestamp >= 3) {
			generateGO (Random.Range (0, 5));
			this.lastTimestamp = Time.time;
		}
	}

	public void removeSprite(string spriteKey) {
		GameObject.Destroy (GameObject.Find(spriteKey));
	}

    private void calculatePosition(GameObject res) {
        float spriteX = Random.Range(-500, 500);
        if (spriteX > -StoneSize && spriteX < StoneSize)
        {
            spriteX = spriteX > 0 ? StoneSize : -StoneSize;
        }

        Vector3 spritePos = new Vector3(spriteX, 1000, 0);
        Vector3 spriteRot = new Vector3(0, 0, Random.Range(0, 359));

        res.transform.localPosition = spritePos;
        res.transform.Rotate(spriteRot);

        /*
        // check if we should appear ontop of some other object and recalculate 
        // position if needed
        BoxCollider2D spriteCollider = res.GetComponent<BoxCollider2D>();
        if (spriteCollider == null)
        {
            return;
        }
        Vector2 size = spriteCollider.size;
        size.x *= bgWrap.transform.lossyScale.x * res.transform.lossyScale.x;
        size.y *= bgWrap.transform.lossyScale.y * res.transform.lossyScale.y;
        RaycastHit2D[] hitAll = Physics2D.BoxCastAll(
            new Vector2(
                res.transform.position.x,
                res.transform.position.y),
            size,
            0.0f,
            new Vector2());
        foreach (RaycastHit2D hit in hitAll)
        {
            if (hit.collider != null && 
                hit.collider.transform.gameObject != res)
            {
                Debug.Log("REPOSITION!");
                // we hit sth. reposition!
                //calculatePosition(res);
            }
        }
        */
        
    }

	private GameObject generateGO(int newSprite) {
		GameObject res = new GameObject ();
		res.transform.parent = this.bgWrap.transform;
		res.name = res.GetInstanceID().ToString();

		SpriteRenderer sr = res.AddComponent<SpriteRenderer> ();
        sr.sortingOrder = 2;
		PositionChecker posChecker = res.AddComponent<PositionChecker> ();
		BoxCollider2D spriteCollider;

		posChecker.setGOKey (res.name);
		posChecker.setSpeed (this.spriteScrollSpeed);
		posChecker.setMinPos (this.minimumSpriteY);

		switch (newSprite) {
		case 0:
			sr.sprite = this.bottleSprite;
			sr.transform.localScale = new Vector3 (0.6f, 0.6f, 1);
			break;
		case 1:
			sr.sprite = this.bushSprite_1;
			sr.transform.localScale = new Vector3 (2, 2, 1);
			spriteCollider = res.AddComponent<BoxCollider2D> ();
			spriteCollider.size = new Vector2 (70, 70);
			spriteCollider.offset = new Vector2 (5, 0);
			break;
		case 2:
			sr.sprite = this.bushSprite_2;
			sr.transform.localScale = new Vector3 (2, 2, 1);
			spriteCollider = res.AddComponent<BoxCollider2D> ();
			spriteCollider.size = new Vector2 (70, 90);
			spriteCollider.offset = new Vector2 (5, 0);
			break;
		case 3:
			sr.sprite = this.villagerSprite;
			sr.transform.localScale = new Vector3 (2.1f, 2.1f, 1);
			spriteCollider = res.AddComponent<BoxCollider2D> ();
			spriteCollider.size = new Vector2 (60, 75);
			break;
		case 4:
			sr.sprite = this.partyhatsSprite_1;
			sr.transform.localScale = new Vector3 (1.3f, 1.3f, 1);
			break;
		case 5:
			sr.sprite = this.partyhatsSprite_2;
			sr.transform.localScale = new Vector3 (1.3f, 1.3f, 1);
			break;
		}
        calculatePosition(res);
        return res;
	}
}
