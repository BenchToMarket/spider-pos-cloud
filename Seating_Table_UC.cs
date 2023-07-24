using System;
using System.Runtime.CompilerServices;

public partial class Seating_Table_UC : System.Windows.Forms.UserControl
{

    // ***************************
    // not using
    // using Seating_Table_UC2


    private int _index;
    private int _term_table_Num;
    private int _floorPlanID;
    private bool _isAvail;
    private int _tblStatusID;
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

    internal int tblStatusID
    {
        get
        {
            return _tblStatusID;
        }
        set
        {
            _tblStatusID = value;
        }
    }


    public event TableSelectedEventEventHandler TableSelectedEvent;

    public delegate void TableSelectedEventEventHandler(int tn);




    public Seating_Table_UC(int i, float x, float y, float w, float h, int tn, int fp, bool isAct, int ts) : base()
    {

        _index = i;
        _term_table_Num = tn;    // this is index for walls
        this.Location = new System.Drawing.Point((int)Math.Round(x), (int)Math.Round(y));
        _floorPlanID = fp;
        this.Width = w;
        this.Height = h;
        _isAvail = isAct;
        _tblStatusID = ts;

        lblTableNum = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // lblTableNum
        // 
        lblTableNum.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

        lblTableNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        lblTableNum.Location = new System.Drawing.Point(16, 24);
        lblTableNum.Name = "lblTableNum";
        lblTableNum.Size = new System.Drawing.Size(40, 16);
        lblTableNum.TabIndex = 0;
        lblTableNum.Text = Term_Table_Num.ToString();
        // 
        // Seating_Table_UC
        // 
        // Me.BackColor = System.Drawing.Color.IndianRed
        this.Controls.Add(lblTableNum);
        this.Name = "Seating_Table_UC";
        // Me.Size = New System.Drawing.Size(64, 56)
        this.ResumeLayout(false);
        base.Click += Seating_Table_Click;



    }







    private void Seating_Table_Click(object sender, EventArgs e)
    {

        TableSelectedEvent?.Invoke(Term_Table_Num);

    }

}