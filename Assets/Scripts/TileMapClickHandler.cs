using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapClickHandler : MonoBehaviour
{
    public Tilemap tilemap; 
    //reference to icon
    public GameObject iconPrefab; 

    public Gold goldScript;
    public Inventory inventoryScript;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (goldScript != null && !inventoryScript.isShopOpen && goldScript.remainingIcons > 0){

            
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the world position of the mouse click
            Vector3Int cellPosition = tilemap.WorldToCell(worldPos); // Convert the world position to a cell position on the tilemap

            TileBase clickedTile = tilemap.GetTile(cellPosition); // Get the tile at the clicked position

            if (clickedTile != null) // Ensure the tile exists
            {
                PlaceIconOnTile(cellPosition);
                goldScript.remainingIcons--;

            }
            }
            else{
                Debug.Log("No more items!");
            }
        }
    }

void PlaceIconOnTile(Vector3Int cellPosition)
{
    //Convert the cell position to world position
    Vector3 worldPosition = tilemap.CellToWorld(cellPosition);

    //Instantiate the icon prefab
    GameObject icon = Instantiate(iconPrefab);

    //Parent it to the Canvas
    icon.transform.SetParent(GameObject.Find("Canvas").transform, false);

    //Convert the world position to screen position
    Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

    // Set the icons anchored position in the Canvas
    RectTransform rectTransform = icon.GetComponent<RectTransform>();
    if (rectTransform != null)
    {
        //Use the screen position as the anchored position and using the skew TODO: fix hardcoded values - this is how off the icon is being added 
        rectTransform.anchoredPosition = new Vector2(screenPosition.x-460, screenPosition.y-210);
    }
}


}
