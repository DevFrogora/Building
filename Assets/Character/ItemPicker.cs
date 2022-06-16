using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPicker : MonoBehaviour
{
    [SerializeField] private Transform _pickerPoint;
    [SerializeField] private float _pickerPointRadius = 0.5f;
    [SerializeField] private LayerMask _pickerLayerMask;

    private readonly Collider[] _colliders = new Collider[50]; // 3 collider (item ) we are checking
    [SerializeField] private int _numFound; // number of collider(item found)

    public List<int> itemsIdFound = new List<int>();

    public Image itemUIPrefab;
    public GameObject pickerUIContainer;

    public List<Image> itemsUIlist = new List<Image>();

    int previousItemCount;
    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_pickerPoint.position, _pickerPointRadius,
            _colliders, _pickerLayerMask);

        if (_numFound > 0)
        {
            if(previousItemCount != _numFound)
            {
                clearItemFoundList();
                for (int i = 0; i < _numFound; i++)
                {
                    var pickerItem = _colliders[i].GetComponent<IInventoryItem>();
                    if (itemsIdFound.Contains(pickerItem.ItemId))
                    {

                    }
                    else
                    {
                        
                        var itemUI = Instantiate(itemUIPrefab);
                        itemUI.gameObject.transform.SetParent(pickerUIContainer.transform);
                        itemUI.rectTransform.localScale = itemUIPrefab.transform.localScale;
                        itemUI.rectTransform.rotation = Quaternion.identity;
                        itemUI.GetComponent<PickerItemUI>().image.sprite = pickerItem.spriteImage;
                        itemUI.GetComponent<PickerItemUI>().itemName.text = pickerItem.Name;
                        itemUI.GetComponent<PickerItemUI>().itemPrefab = _colliders[i].gameObject;

                        itemsUIlist.Add(itemUI);
                        //pickerItem.OnPickup();
                        itemsIdFound.Add(pickerItem.ItemId);
                        Debug.Log("From Interactor");
                    }
                }
                previousItemCount = _numFound;
            }

        }
        else
        {
            clearItemFoundList();
        }
    }


    void clearItemFoundList()
    {
        previousItemCount = 0;
        for (int i = 0; i < itemsUIlist.Count; i++)
        {
            var item = itemsUIlist[i];
            // Remove from list.
            itemsUIlist.RemoveAt(i);

            // Destroy object.
            Destroy(item.gameObject);
        }
        itemsIdFound.Clear();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_pickerPoint.position, _pickerPointRadius);
    }
}

