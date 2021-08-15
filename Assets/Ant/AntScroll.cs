using UnityEngine;
using System.Collections.Generic;

using UnityEngine.UI; 
using XLua; 

   
public abstract class AntScroll : ScrollRect
{
	protected RectTransform rtf;

	protected RectTransform _prefabItem;


	#region abstracts
	protected abstract float GetDimension(Vector2 vector);

	protected abstract float GetPos(Vector2 vector);

    protected abstract Vector2 GetVector(float value);
	#endregion

	[HideInInspector]
	public int dataCount;


	private int _startIndex;

	private int _endIndex;

	private List<RectTransform> _items;
    private List<RectTransform> _pool;
    private Queue<RectTransform> _poolFree;

    private float _itemSize;
    //private Vector2 _org;
    [CSharpCallLua]
    public delegate void RenderDelegate(int index, RectTransform tf,int tfIndex);

	public RenderDelegate renderHandler;

	[SerializeField]
	public bool useObjectPool;

    //private float _fixDirect;

    protected override void Awake()
    { 
        base.Awake();
		if (Application.isPlaying == false)
			return;
		rtf = GetComponent<RectTransform>();
        //_fixDirect = horizontal ? 1 : -1;

        Init();

    }

	protected void Init()
	{
		List<RectTransform> listChild = new List<RectTransform>();

		foreach (RectTransform child in content)
		{
			listChild.Add(child);
		}
       // Debug.Log("AntScroll  listChild.Count ============================= " + listChild.Count);
		for (int i = 0; i < listChild.Count; i++)
		{
			if (_prefabItem == null)
			{
				_prefabItem = listChild[i];
				_prefabItem.gameObject.SetActive(false);
			}
			else
			{
				Destroy(listChild[i].gameObject);
			}
		}
        _itemSize = GetDimension(_prefabItem.sizeDelta);
        _startIndex = 0;
        _endIndex = 0;
        _items = new List<RectTransform>();
        _pool = new List<RectTransform>();
        _poolFree = new Queue<RectTransform>();
        
    }

    public GameObject GetPrefab()
    {
        return _prefabItem.gameObject;
    }

    protected override void Start()
    {
        base.Start();
		if (Application.isPlaying == false)
			return;
        Refresh();



	}


	protected RectTransform GetPrefabItem(int index)
	{
		return _prefabItem;
	}

	public void SetCount(int value)
	{  
        dataCount = value;
		  Debug.Log("SetCount -> C# :" +dataCount);
        if (horizontal)
            content.sizeDelta = new Vector2(_prefabItem.sizeDelta.x * dataCount, content.sizeDelta.y);
        else
        {
        
         //   Debug.Log("_prefabItem  " + _prefabItem);
            content.sizeDelta = new Vector2(content.sizeDelta.x, _prefabItem.sizeDelta.y * dataCount);
        }
        Refresh();
	}

	public void Refresh()
	{
        for (int i = 0; i < _pool.Count; i++)
            _pool[i].gameObject.SetActive(false);

        float py = 0;
        if (_items.Count > 0)
            py = GetPos(_items[0].anchoredPosition);

        for (int i = _items.Count - 1; i > -1; i--)
            RemoveFromItems(i);

        
        float viewSize = GetDimension(rtf.sizeDelta);

        if (_startIndex > dataCount)
        {
            _startIndex = 0;
            py = 0f;
        }
            

        for (int i = _startIndex; i < dataCount; i++)
		{
            RectTransform newItem = CreateItem(i);
            _items.Add(newItem);

            newItem.anchoredPosition = GetVector(py);
			
			_endIndex = i;
			py = GetPos(newItem.anchoredPosition) + _itemSize;
            
			if (GetPos(content.anchoredPosition) + py > viewSize)
			{
				break;
			}
		}

        
	}


	private Vector2 _contentLastAnchoredPosition;

	protected override void SetContentAnchoredPosition(Vector2 position)
	{   
		base.SetContentAnchoredPosition(position);

		if (_contentLastAnchoredPosition == content.anchoredPosition)
		{
			content.anchoredPosition = new Vector2((float)System.Math.Round(_contentLastAnchoredPosition.x, 2), (float)System.Math.Round(_contentLastAnchoredPosition.y, 2));
		}
		_contentLastAnchoredPosition = content.anchoredPosition;

		if (_items == null || _items.Count == 0)
		{
			return;
		}

		RectTransform topItem = _items[0];
		RectTransform bottomItem = _items[_items.Count - 1];
        
		if (GetPos(content.anchoredPosition) + GetPos(topItem.anchoredPosition) > 0)
		{
			if (_startIndex > 0)
			{
				RectTransform newItem = CreateItem(_startIndex - 1);
                newItem.anchoredPosition = GetVector(GetPos(topItem.anchoredPosition) - _itemSize);
                newItem.SetSiblingIndex(0);
				_startIndex--;
				_items.Insert(0, newItem);
            }
		}
		else if (GetPos(content.anchoredPosition) + GetPos(topItem.anchoredPosition) + _itemSize < 0)
		{
            if(_items.Count != 1)
            {
                _startIndex++;
                RemoveFromItems(0);
            }
        }

		topItem = _items[0];
		bottomItem = _items[_items.Count - 1];

        //Debug.Log((GetDimension(content.anchoredPosition) + GetPos(bottomItem.anchoredPosition) + _itemSize) + " " + GetDimension(rtf.sizeDelta));
		if (GetPos(content.anchoredPosition) + GetPos(bottomItem.anchoredPosition) + _itemSize < GetDimension(rtf.sizeDelta))
		{
			if (_endIndex < dataCount - 1)
			{
				//float py = GetDimension(bottomItem.anchoredPosition + _fixDirect * bottomItem.sizeDelta / 2);
				RectTransform newItem = CreateItem(_endIndex + 1);
				newItem.anchoredPosition = GetVector(GetPos(bottomItem.anchoredPosition) + _itemSize);
				_items.Add(newItem);
				_endIndex++;
            }
		}
		else if (GetPos(content.anchoredPosition) + GetPos(bottomItem.anchoredPosition) >  GetDimension(rtf.sizeDelta))
		{
            if (_items.Count != 1)
            {
                RemoveFromItems(_items.Count - 1);
                _endIndex--;
            }
        }
	}

    protected void RemoveFromItems(int index)
    {
        _items[index].gameObject.SetActive(false);
        _poolFree.Enqueue(_items[index]);
        _items.RemoveAt(index);
    }

	protected RectTransform CreateItem(int index)
	{
        RectTransform newItem = null;
        if (_poolFree.Count > 0)
        {
            newItem = _poolFree.Dequeue();
        }
        else
        {
            newItem = Instantiate(GetPrefabItem(index)) as RectTransform;
            newItem.transform.SetParent(content.transform, false);
            _pool.Add(newItem);
        }
        newItem.SetSiblingIndex(index);
        newItem.gameObject.name = "item" + index;
		newItem.gameObject.SetActive(true);
		RenderHandler(index, newItem);
       
        return newItem;
	}
    

    private void RenderHandler(int index, RectTransform tf)
	{
 
		Debug.Log("RenderHandler -> "+renderHandler);
        if(renderHandler != null)
            renderHandler(index, tf, _pool.IndexOf(tf));
	}
}
