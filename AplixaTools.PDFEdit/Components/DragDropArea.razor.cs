using AplixaTools.PDFEdit.Models;
using AplixaTools.PDFEdit.Services;
using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class DragDropArea<TItem>
{
	[Inject] public JsInteropService JsInterop { get; set; }

	[Parameter] public string Class { get; set; }
	[Parameter] public RenderFragment<TItem> ChildContent { get; set; }
	[Parameter] public IEnumerable<TItem> Items { get; set; }
	[Parameter] public EventCallback<int[]> OnItemDrop { get; set; }

	private List<TItem> _items = new();
	private string[] _itemClasses = Array.Empty<string>();
	private int _selectedItem = -1;

	private readonly List<int> _indices = new();
	private readonly List<ElementDimensions> _elementDimensions = new();

	protected override void OnInitialized()
	{
		_items = Items.ToList();
		_itemClasses = new string[Items.Count()];

		for (int i = 0; i < Items.Count(); i++)
		{
			_indices.Add(i);
		}

		base.OnInitialized();
	}

	protected override void OnAfterRender(bool firstRender)
	{
		if (firstRender)
		{
			UpdateElementDimensions();
		}

		if (_selectedItem > -1)
		{
			JsInterop.StickElementToCursor($"#dragdroparea-{GetHashCode()} .grabbed");
		}

		base.OnAfterRender(firstRender);
	}

	private void MoveItem(int from, int to)
	{
		Console.WriteLine(string.Join(',', _indices));
		
		var item = _items[from];
		_items.RemoveAt(from);
		_items.Insert(to, item);

		_indices.RemoveAt(from);
		_indices.Insert(to, from);

		Console.WriteLine(string.Join(',', _indices));
	}

	private void ItemOnMouseDown(int i)
	{
		_itemClasses[i] = "grabbed";
		_selectedItem = i;
	}

	private async Task ContainerOnMouseUp()
	{
		JsInterop.UnstickElementFromCursor();
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

				Console.WriteLine($"x: {gap.Position.X} y: {gap.Position.Y} w: {gap.Size.X} h: {gap.Size.Y}");
				Console.WriteLine(gap.Contains(pos));
			}
		}

		await OnItemDrop.InvokeAsync(_indices.ToArray());

		_selectedItem = -1;
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

			Console.WriteLine($"x: {dimensions.Position.X} y: {dimensions.Position.Y} w: {dimensions.Size.X} h: {dimensions.Size.Y}");

            _elementDimensions.Add(dimensions);
		}
	}
}
