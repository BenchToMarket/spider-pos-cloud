using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

public partial class SelectionPanel_UC : System.Windows.Forms.UserControl
{

    private DataSet_Builder.BatchButton_UC btnSelection;

    private DataView _dvUsing = new DataView();
    private DataTable _dtUsing;
    private string _purpose;
    private int _pMenuID;
    private int _sMenuID;




    private float btnWidth;
    private float btnHeight;
    private float buttonspace = 2f;

    private MenuSelection_ _menuSelect;

    private MenuSelection_ menuSelect
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _menuSelect;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_menuSelect != null)
            {
                _menuSelect.AcceptMenuEvent -= AccentMenu_Click;
                _menuSelect.ChangeMenus -= ChangeMenu;
            }

            _menuSelect = value;
            if (_menuSelect != null)
            {
                _menuSelect.AcceptMenuEvent += AccentMenu_Click;
                _menuSelect.ChangeMenus += ChangeMenu;
            }
        }
    }


    public event CancelSelectionEventHandler CancelSelection;

    public delegate void CancelSelectionEventHandler();
    public event ButtonSelectedEventHandler ButtonSelected;

    public delegate void ButtonSelectedEventHandler(object sender, EventArgs e);
    public event ChangeMenusEventHandler ChangeMenus;

    public delegate void ChangeMenusEventHandler();
    public event AcceptMenuEventEventHandler AcceptMenuEvent;

    public delegate void AcceptMenuEventEventHandler();

    public DataView dvUsing
    {
        get
        {
            return _dvUsing;
        }
        set
        {
            _dvUsing = value;
        }
    }

    public DataTable dtUsing
    {
        get
        {
            return _dtUsing;
        }
        set
        {
            _dtUsing = value;
        }
    }

    public string Purpose
    {
        get
        {
            return _purpose;
        }
        set
        {
            _purpose = value;
        }
    }

    public int PMenuID
    {
        get
        {
            return _pMenuID;
        }
        set
        {
            _pMenuID = value;
        }
    }

    public int SMenuID
    {
        get
        {
            return _sMenuID;
        }
        set
        {
            _sMenuID = value;
        }
    }

    #region  Windows Form Designer generated code 

    public SelectionPanel_UC() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

        dvUsing = new DataView();
        dtUsing = new DataTable();
        InitializeOther();

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
    private Global.System.Windows.Forms.Panel _pnlBorder;

    internal virtual Global.System.Windows.Forms.Panel pnlBorder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlBorder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlBorder = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlButtonFill;

    internal virtual Global.System.Windows.Forms.Panel pnlButtonFill
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlButtonFill;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlButtonFill != null)
            {
                _pnlButtonFill.Click -= ButtonSelection_Click;
            }

            _pnlButtonFill = value;
            if (_pnlButtonFill != null)
            {
                _pnlButtonFill.Click += ButtonSelection_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlBorder = new System.Windows.Forms.Panel();
        _pnlButtonFill = new System.Windows.Forms.Panel();
        _pnlButtonFill.Click += ButtonSelection_Click;
        _pnlBorder.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlBorder
        // 
        _pnlBorder.BackColor = Color.SlateBlue;
        _pnlBorder.Controls.Add(_pnlButtonFill);
        _pnlBorder.ForeColor = SystemColors.ActiveCaptionText;
        _pnlBorder.Location = new Point(0, 0);
        _pnlBorder.Name = "_pnlBorder";
        _pnlBorder.Size = new Size(624, 560);
        _pnlBorder.TabIndex = 0;
        // 
        // pnlButtonFill
        // 
        _pnlButtonFill.BackColor = Color.LightGray;
        _pnlButtonFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _pnlButtonFill.Location = new Point(16, 16);
        _pnlButtonFill.Name = "_pnlButtonFill";
        _pnlButtonFill.Size = new Size(592, 520);
        _pnlButtonFill.TabIndex = 0;
        // 
        // SelectionPanel_UC
        // 
        this.BackColor = Color.LightSlateGray;
        this.Controls.Add(_pnlBorder);
        this.Name = "SelectionPanel_UC";
        this.Size = new Size(624, 552);
        _pnlBorder.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        // DetermineButtonSizes()
        // DetermineButtonLocations()




    }

    public void DetermineButtonSizes()
    {

        if (dvUsing.Count < 41)
        {
            btnWidth = (pnlButtonFill.Width - 5f * buttonspace) / 4;
            btnHeight = (pnlButtonFill.Height - 11f * buttonspace) / 10;
        }

        else
        {
            // *** we can change this depending on how we want to display
            btnWidth = (pnlButtonFill.Width - 5f * buttonspace) / 4;
            btnHeight = (pnlButtonFill.Height - 13f * buttonspace) / 12;

        }


    }

    public void DetermineButtonLocations()
    {
        float x = buttonspace;
        float y = buttonspace;
        var count = default(int);

        foreach (DataRowView vRow in dvUsing)
        {
            CreateButtons(x, y, ref vRow);
            if (count < 6)
            {
                y = y + btnHeight + buttonspace;
            }
            else
            {
                x = x + btnWidth + buttonspace;
                y = buttonspace;
                count = 0;
            }
            count += 1;
        }


    }

    private void CreateButtons(float x, float y, ref DataRowView vRow)
    {
        var menuName = default(string);

        foreach (DataRow oRow in dtUsing.Rows)
        {
            if (oRow("MenuID") == vRow("PrimaryMenu"))
            {
                menuName = oRow("MenuName");
                break;
            }
        }


        btnSelection = new DataSet_Builder.BatchButton_UC(btnWidth, btnHeight, vRow, menuName);


        {
            ref var withBlock = ref btnSelection;
            withBlock.Location = new Point((int)Math.Round(x), (int)Math.Round(y));
            this.btnSelection.TableClicked += ButtonSelection_Click;

        }

        pnlButtonFill.Controls.Add(btnSelection);


    }

    public void ButtonSelection_Click(object sender, EventArgs e)
    {
        var objButton = new DataSet_Builder.BatchButton_UC(default, default, default, default);

        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        ButtonSelected?.Invoke(sender, e);

        this.Dispose();

    }

    public void StartOpenNewBusiness()
    {
        menuSelect = new MenuSelection_uc(dtUsing, (object)null, (object)null);    // nothing indicates no menuID

        menuSelect.Location = new Point((pnlButtonFill.Width - menuSelect.Width) / 2, 50);
        pnlButtonFill.Controls.Add(menuSelect);


    }
    public void ClearSelectionPanel()
    {
        pnlButtonFill.Controls.Clear();

    }

    private void AccentMenu_Click()
    {
        _pMenuID = menuSelect.PMenuID;
        _sMenuID = menuSelect.SMenuID;
        AcceptMenuEvent?.Invoke();

    }

    private void ChangeMenu()
    {
        _pMenuID = menuSelect.PMenuID;
        _sMenuID = menuSelect.SMenuID;
        ChangeMenus?.Invoke();

    }


}