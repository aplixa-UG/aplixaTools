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
	private bool _updateElementDimensions = false;
	private bool _stickElementToCursor = false;

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
        _items = items.ToList();
        _itemClasses = new string[items.Count()];

		_indices.Clear();

        for (int i = 0; i < items.Count(); i++)
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

		var ownDimensions = JsInterop.GetElementDimensions(
			"body",
			$"#dragdroparea-{GetHashCode()}"
		);

		var pos = JsInterop.GetMousePosInContainer($"#dragdroparea-{GetHashCode()}");
		_itemClasses = new string[_items.Count];


		for (int j = 0; j < _items.Count; j++)
		{
			var dimensions = _elementDimensions[j];
			if (dimensions.Contains(pos))
			{
				MoveItem(_selectedItem, j);
				break;
			}

			if (j + 1 < _items.Count)
			{
				var nextDimensions = _elementDimensions[j + 1];

				var gap = new ElementDimensions
				{
					Position = new Pos2
					{
						X = 0,
						Y = dimensions.Position.Y + dimensions.Size.Y,
					},
					Size = new Pos2
					{
						X = ownDimensions.Size.X,
						Y = nextDimensions.Size.Y - dimensions.Size.Y
					}
				};
			}
		}

		await OnItemDrop.InvokeAsync(_indices.ToArray());

		_selectedItem = -1;
        _stickElementToCursor = false;
    }

    private void UpdateElementDimensions()
	{
		_elementDimensions.Clear();

		for (int i = 0; i < _items.Count; i++)
		{
			var query = $"#dragdropitem-{i}";
			var dimensions = JsInterop.GetElementDimensions(
				$"#dragdroparea-{GetHashCode()}",
				query
			);
            _elementDimensions.Add(dimensions);
		}
    }
}
