internal partial class OrderButton : Button
{

    private BorderStyle _border = BorderStyle.None;
    private Border3DStyle _borderStyle3D;
    private bool _drinkCategory;
    private bool _subCategory;
    private bool _drinkAdds;
    private string _text;
    private string _name;
    private int _id;
    private decimal _price;
    private float _cost;
    private int _foodID;      // carries food id to modifier selection
    private int _numberFree;
    private int _functions;
    private int _functionGroup;
    private string _functionFlag;
    private bool _isPrimary;
    private int _foodTableIndex;      // which primary or secondary table to use
    private bool _halfSplit;
    private decimal _InvMultiplier;
    private bool _extended;
    private string _dpMethod;

    private int _mainButtonIndex;
    private int _modifierButtonIndex;
    private int _modifierMenuIndex;
    private int _maxMenuIndex;
    private int _categoryID;
    private DataView _activeDataView;
    private int _previousID;

    internal BorderStyle Border
    {
        get
        {
            return _border;
        }
        set
        {
            _border = value;
        }
    }
    internal Border3DStyle BorderStyle3D
    {
        get
        {
            return _borderStyle3D;
        }
        set
        {
            _borderStyle3D = value;
        }
    }
    internal bool DrinkCategory
    {
        get
        {
            return _drinkCategory;
        }
        set
        {
            _drinkCategory = value;
        }
    }

    internal bool SubCategory
    {
        get
        {
            return _subCategory;
        }
        set
        {
            _subCategory = value;
        }
    }

    internal bool DrinkAdds
    {
        get
        {
            return _drinkAdds;
        }
        set
        {
            _drinkAdds = value;
        }
    }

    internal int ID
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    internal decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            _price = value;
        }
    }
    internal float Cost
    {
        get
        {
            return _cost;
        }
        set
        {
            _cost = value;
        }
    }

    internal string CatName
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    internal int FoodID
    {
        get
        {
            return _foodID;
        }
        set
        {
            _foodID = value;
        }
    }

    internal int NumberFree
    {
        get
        {
            return _numberFree;
        }
        set
        {
            _numberFree = value;
        }
    }

    internal int Functions
    {
        get
        {
            return _functions;
        }
        set
        {
            _functions = value;
        }
    }

    internal int FunctionGroup
    {
        get
        {
            return _functionGroup;
        }
        set
        {
            _functionGroup = value;
        }
    }

    internal string FunctionFlag
    {
        get
        {
            return _functionFlag;
        }
        set
        {
            _functionFlag = value;
        }
    }

    internal bool IsPrimary
    {
        get
        {
            return _isPrimary;
        }
        set
        {
            _isPrimary = value;
        }
    }

    internal int FoodTableIndex
    {
        get
        {
            return _foodTableIndex;
        }
        set
        {
            _foodTableIndex = value;
        }
    }

    internal bool HalfSplit
    {
        get
        {
            return _halfSplit;
        }
        set
        {
            _halfSplit = value;
        }
    }

    internal decimal InvMultiplier
    {
        get
        {
            return _InvMultiplier;
        }
        set
        {
            _InvMultiplier = value;
        }
    }

    internal bool Extended
    {
        get
        {
            return _extended;
        }
        set
        {
            _extended = value;
        }
    }

    internal string dpMethod
    {
        get
        {
            return _dpMethod;
        }
        set
        {
            _dpMethod = value;
        }
    }

    internal int MainButtonIndex
    {
        get
        {
            return _mainButtonIndex;
        }
        set
        {
            _mainButtonIndex = value;
        }
    }

    internal int ModifierButtonIndex
    {
        get
        {
            return _modifierButtonIndex;
        }
        set
        {
            _modifierButtonIndex = value;
        }
    }

    internal int ModifierMenuIndex
    {
        get
        {
            return _modifierMenuIndex;
        }
        set
        {
            _modifierMenuIndex = value;
        }
    }

    internal int MaxMenuIndex
    {
        get
        {
            return _maxMenuIndex;
        }
        set
        {
            _maxMenuIndex = value;
        }
    }

    internal int CategoryID
    {
        get
        {
            return _categoryID;
        }
        set
        {
            _categoryID = value;
        }
    }

    internal DataView ActiveDataView
    {
        get
        {
            return _activeDataView;
        }
        set
        {
            _activeDataView = value;
        }
    }

    internal int PreviousID
    {
        get
        {
            return _previousID;
        }
        set
        {
            _previousID = value;
        }
    }

    public OrderButton(string fontString) : base()
    {


        if (fontString == "12")
        {

            // Me.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
            // Me.FlatAppearance.BorderSize = 2
            // Me.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            // Me.Border = BorderStyle.Fixed3D
            // Me.BorderStyle3D = Border3DStyle.RaisedOuter
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0d, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        }
        else if (fontString == "10")
        {
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.0d, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        }
        else
        {
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.0d, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        }
        // Me.Font = New System.Drawing.Font("Comic Sans MS", 10.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    }


}