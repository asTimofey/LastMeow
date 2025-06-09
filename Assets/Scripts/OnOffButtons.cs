using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffButtons : MonoBehaviour
{
    [SerializeField] private string[] anotherTags;
    [SerializeField] public GameObject itemSprites;
    [SerializeField] private List<GameObject> otherSprites = new List<GameObject>();
    [SerializeField] public List<GameObject> enabledClicks = new List<GameObject>();
    [SerializeField] private Sprite clickedSprite;
    [SerializeField] private GameObject _object;
    public void DisableClicks()
    {
        _object.GetComponent<CollectableItem>().ObjectFound();
        Init();
        DisableParentObject();
        DisableChildrens();
    }
    private void DisableChildrens()
    {
        foreach (var item in otherSprites)
        {
            if (item.GetComponent<Button>().enabled == false)
            {
                item.GetComponent<Animator>().enabled = false;
            }
            else
            {
                enabledClicks.Add(item);
                item.GetComponent<Button>().enabled = false;
                item.GetComponent<Animator>().enabled = false;
            }
        }
    }
    public void DisableParentObject()
    {
        itemSprites.GetComponent<Button>().enabled = false;
        itemSprites.GetComponent<Animator>().enabled = false;
        Image[] childrens = itemSprites.GetComponentsInChildren<Image>();
        foreach (var child in childrens)
        {
            child.sprite = clickedSprite;
        }
    }
    private void Init()
    {
        foreach (string anotherTag in anotherTags)
        {
            GameObject[] items = GameObject.FindGameObjectsWithTag(anotherTag);
            foreach (GameObject item in items)
            {
                otherSprites.Add(item);
            }
        }
    }
}