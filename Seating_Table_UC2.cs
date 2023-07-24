using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class Seating_Table_UC2 : System.Windows.Forms.UserControl
{

    private int _index;
    private int _term_table_Num;
    private int _floorPlanID;
    private bool _isActive;
    private int _width;
    private int _height;
    private bool _isAvail;


    internal int Index
    {
        get
        {
            return _index;
        }
        set
        {
            _index = value;
        }
    }

    internal int Term_Table_Num
    {
        get
        {
            return _term_table_Num;
        }
        set
        {
            _term_table_Num = value;
        }
    }

    internal int FloorPlanID
    {
        get
        {
            return _floorPlanID;
        }
        set
        {
            _floorPlanID = value;
        }
    }

    internal bool IsActive
    {
        get
        {
            return _isActive;
        }
        set
        {
            _isActive = value;
        }
    }

    internal bool IsAvail
    {
        get
        {
            return _isAvail;
        }
        set
        {
            _isAvail = value;
        }
    }



    public event TableSelectedEventEventHandler TableSelectedEvent;

    public delegate void TableSelectedEventEventHandler(int tn, bool avail);

    #region  Windows Form Designer generated code 

    public Seating_Table_UC2(int i, float x, float y, float w, float h, int tn, int fp, bool isAct) : base()
    {

        _index = i;
        _term_table_Num = tn;    // this is index for walls
        this.Location = new System.Drawing.Point((int)Math.Round(x), (int)Math.Round(y));
        _floorPlanID = fp;
        _isActive = isAct;
        _width = (int)Math.Round(w);
        _height = (int)Math.Round(h);

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        base.Click += Seating_Table_Click;

    }

    // UserControl overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components is not null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    private Global.System.Windows.Forms.Label _lblTableNum;

    internal virtual Global.System.Windows.Forms.Label lblTableNum
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTableNum;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTableNum != null)
            {
                _lblTableNum.Click -= Seating_Table_Click;
            }

            _lblTableNum = value;
            if (_lblTableNum != null)
            {
                _lblTableNum.Click += Seating_Table_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _lblTableNum = new System.Windows.Forms.Label();
        _lblTableNum.Click += Seating_Table_Click;
        this.SuspendLayout();
        // 
        // lblTableNum
        // 
        _lblTableNum.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

        _lblTableNum.BackColor = System.Drawing.SystemColors.Control;
        _lblTableNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTableNum.Location = new System.Drawing.Point(2, 2);
        _lblTableNum.Name = "_lblTableNum";
        _lblTableNum.Size = new System.Drawing.Size(146, 146);
        _lblTableNum.TabIndex = 0;
        _lblTableNum.Text = "Table";
        _lblTableNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Seating_Table_UC2
        // 
        this.BackColor = System.Drawing.Color.DarkBlue;
        this.Controls.Add(_lblTableNum);
        this.Name = "Seating_Table_UC2";
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        this.Width = _width;
        this.Height = _height;
        lblTableNum.Text = Term_Table_Num.ToString();

    }


    private void Seating_Table_Click(object sender, EventArgs e)
    {

        TableSelectedEvent?.Invoke(Term_Table_Num, IsAvail);

    }


}