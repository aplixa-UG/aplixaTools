using AplixaTools.PDFEdit.Models;
using AplixaTools.PDFEdit.Services;
using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class DragDropArea<TItem>
{
	[Inject] public JsInteropService JsInterop { get; set; }

	/// <summary>
	/// Classes to apply to the container
	/// </summary>
	[Parameter] public string Class { get; set; }
	/// <summary>
	/// A HTML Template for an element (The element itself is accessible in the "context" variable)
	/// </summary>
	[Parameter] public RenderFragment<TItem> ChildContent { get; set; }
	/// <summary>
	/// The Items to render using the HTML Template
	/// </summary>
	[Parameter] public IEnumerable<TItem> Items { get; set; }
	/// <summary>
	/// Fires when the user drops a item
	/// Contains a int[] with the new order of the elements' indices
	/// </summary>
	[Parameter] public EventCallback<int[]> OnItemDrop { get; set; }

	private List<TItem> _items = new();
	private string[] _itemClasses = Array.Empty<string>();
	private int _selectedItem = -1;
	private bool _updateElementDimensions;
	private bool _stickElementToCursor;

	private readonly List<int> _indices = new();

    private readonly List<ElementDimensions> _elementDimensions = new();

    protected override void OnInitialized()
	{
		Update(Items);

		base.OnInitialized();
	}

	protected override void OnAfterRender(bool firstRender)
	{
		if (firstRender || _updateElementDimensions)
		{
            Console.WriteLine("Updating Element Dimensions");
            UpdateElementDimensions();
			_updateElementDimensions = false;
		}

		if (_selectedItem > -1 && _stickElementToCursor)
		{
			JsInterop.StickElementToCursor($"#dragdroparea-{GetHashCode()} .grabbed");
			_stickElementToCursor = false;
		}

		base.OnAfterRender(firstRender);
	}

    /// <summary>
    /// Updates the DragDropArea. Should be used synonimously with StateHasChanged
    /// </summary>
    public void Update(IEnumerable<TItem> items)
    {
        var enumerable = items as TItem[] ?? items.ToArray();
        var length = enumerable.Length;

		_items = enumerable.ToList();
        _itemClasses = new string[length];

        _indices.Clear();

        for (var i = 0; i < length; i++)
        {
            _indices.Add(i);
        }

        _updateElementDimensions = true;
        StateHasChanged();
    }

    private void MoveItem(int from, int to)
	{
		_indices[to] = from;
		_indices[from] = to;
	}

	private void ItemOnMouseDown(int i)
	{
		if (JsInterop.GetHoveredItemAttribute("data-clickable") == "true")
		{
			return;
		}

		_itemClasses[i] = "grabbed";
		_selectedItem = i;
		_stickElementToCursor = true;
	}

	private async Task ContainerOnMouseUp()
	{
		if (_selectedItem == -1)
		{
			return;
		}

		JsInterop.UnstickElementsFromCursor();

		var pos = JsInterop.GetMousePosInContainer($"#dragdroparea-{GetHashCode()}");
		_itemClasses = new string[_items.Count];


		for (var j = 0; j < _items.Count; j++)
		{
			var dimensions = _elementDimensions[j];

            if (!dimensions.Contains(pos)) continue;

            MoveItem(_selectedItem, j);
            break;
        }

		await OnItemDrop.InvokeAsync(_indices.ToArray());

		_selectedItem = -1;
        _stickElementToCursor = false;
    }

    public void UpdateElementDimensions()
	{
		_elementDimensions.Clear();

        for (var i = 0; i < _items.Count; i++)
		{
			var query = $"#dragdropitem-{i}";
			var dimensions = JsInterop.GetElementDimensions(
				$"#dragdroparea-{GetHashCode()}",
				query
			);
            _elementDimensions.Add(dimensions);
        }

		StateHasChanged();
    }
}
