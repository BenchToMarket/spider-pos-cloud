using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataSet_Builder;



public partial class TabSelection_UC : System.Windows.Forms.UserControl
{



    private KitchenButton[] btnTabIdentity = new KitchenButton[41];
    private int numberOfIdentifiers = 20;



    private string _tabIdentString;
    private int _nCustomers;


    public string TabIdentString
    {
        get
        {
            return _tabIdentString;
        }
        set
        {
            _tabIdentString = value;
        }
    }

    public string NCustomers
    {
        get
        {
            return _nCustomers.ToString();
        }
        set
        {
            _nCustomers = Conversions.ToInteger(value);
        }
    }

    public event TabIdentDisposeEventHandler TabIdentDispose;

    public delegate void TabIdentDisposeEventHandler();


    #region  Windows Form Designer generated code 

    public TabSelection_UC() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
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
    private DataSet_Builder.NumberOfCustomers_UC _NumberOfCustomers_UC1;

    internal virtual DataSet_Builder.NumberOfCustomers_UC NumberOfCustomers_UC1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberOfCustomers_UC1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberOfCustomers_UC1 != null)
            {
                _NumberOfCustomers_UC1.NumberCustomerEntered -= NumCust_Click;
            }

            _NumberOfCustomers_UC1 = value;
            if (_NumberOfCustomers_UC1 != null)
            {
                _NumberOfCustomers_UC1.NumberCustomerEntered += NumCust_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _Panel1;

    internal virtual Global.System.Windows.Forms.Panel Panel1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel1 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel2;

    internal virtual Global.System.Windows.Forms.Panel Panel2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel2 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label1;

    internal virtual Global.System.Windows.Forms.Label Label1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label1 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlTabIdentity;

    internal virtual Global.System.Windows.Forms.Panel pnlTabIdentity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlTabIdentity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlTabIdentity = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnCancel;

    internal virtual Global.System.Windows.Forms.Button btnCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCancel != null)
            {
                _btnCancel.Click -= btnCancel_Click;
            }

            _btnCancel = value;
            if (_btnCancel != null)
            {
                _btnCancel.Click += btnCancel_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnAccept;

    internal virtual Global.System.Windows.Forms.Button btnAccept
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAccept;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAccept != null)
            {
                _btnAccept.Click -= btnAccept_Click;
            }

            _btnAccept = value;
            if (_btnAccept != null)
            {
                _btnAccept.Click += btnAccept_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _NumberOfCustomers_UC1 = new DataSet_Builder.NumberOfCustomers_UC();
        _NumberOfCustomers_UC1.NumberCustomerEntered += NumCust_Click;
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel2 = new System.Windows.Forms.Panel();
        _Label1 = new System.Windows.Forms.Label();
        _pnlTabIdentity = new System.Windows.Forms.Panel();
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _btnAccept = new System.Windows.Forms.Button();
        _btnAccept.Click += btnAccept_Click;
        _Panel1.SuspendLayout();
        _Panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // NumberOfCustomers_UC1
        // 
        _NumberOfCustomers_UC1.BackColor = System.Drawing.Color.Black;
        _NumberOfCustomers_UC1.Location = new System.Drawing.Point(56, 80);
        _NumberOfCustomers_UC1.Name = "_NumberOfCustomers_UC1";
        _NumberOfCustomers_UC1.Size = new System.Drawing.Size(312, 480);
        _NumberOfCustomers_UC1.TabIndex = 0;
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.Black;
        _Panel1.Controls.Add(_Panel2);
        _Panel1.Location = new System.Drawing.Point(424, 80);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(464, 480);
        _Panel1.TabIndex = 1;
        // 
        // Panel2
        // 
        _Panel2.BackColor = System.Drawing.Color.CornflowerBlue;
        _Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel2.Controls.Add(_Label1);
        _Panel2.Controls.Add(_pnlTabIdentity);
        _Panel2.Location = new System.Drawing.Point(16, 16);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(432, 448);
        _Panel2.TabIndex = 0;
        // 
        // Label1
        // 
        _Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.ForeColor = System.Drawing.Color.White;
        _Label1.Location = new System.Drawing.Point(0, 0);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(432, 40);
        _Label1.TabIndex = 1;
        _Label1.Text = "Tab Identifier";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlTabIdentity
        // 
        _pnlTabIdentity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlTabIdentity.Location = new System.Drawing.Point(24, 48);
        _pnlTabIdentity.Name = "_pnlTabIdentity";
        _pnlTabIdentity.Size = new System.Drawing.Size(392, 344);
        _pnlTabIdentity.TabIndex = 0;
        // 
        // btnCancel
        // 
        _btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCancel.Location = new System.Drawing.Point(760, 576);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(88, 48);
        _btnCancel.TabIndex = 2;
        _btnCancel.Text = "Cancel";
        // 
        // btnAccept
        // 
        _btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAccept.Location = new System.Drawing.Point(648, 576);
        _btnAccept.Name = "_btnAccept";
        _btnAccept.Size = new System.Drawing.Size(88, 48);
        _btnAccept.TabIndex = 3;
        _btnAccept.Text = "Accept";
        // 
        // TabSelection_UC
        // 
        this.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        this.Controls.Add(_btnAccept);
        this.Controls.Add(_btnCancel);
        this.Controls.Add(_Panel1);
        this.Controls.Add(_NumberOfCustomers_UC1);
        this.Name = "TabSelection_UC";
        this.Size = new System.Drawing.Size(920, 648);
        _Panel1.ResumeLayout(false);
        _Panel2.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        _nCustomers = 0;
        _tabIdentString = "***---***";

        CreateTabIdentityButtonPanel();

    }


    public void InitializeCurrentSettings(int nc, string idString)
    {

        _nCustomers = nc;
        _tabIdentString = idString;

        if (!(Conversions.ToDouble(NCustomers) == 0d))
        {
            NumberOfCustomers_UC1.ColorButtonFromStart(currentTable.NumberOfCustomers);
        }
        else
        {
            NumberOfCustomers_UC1.ColorButtonFromStart(0);
        }
        if (!(TabIdentString == "***---***"))
        {
            foreach (DataRow oRow in ds.Tables("TabIdentifier").Rows)
            {
                if (oRow("TabSelectorIdentity") == TabIdentString)
                {
                    btnTabIdentity[oRow("TabSelectorOrder")].BackColor = Color.RoyalBlue;
                    return;
                }
            }
        }
        _tabIdentString = "***---***"; // this is a reset if there was no match

    }

    private void CreateTabIdentityButtonPanel()
    {
        float w = pnlTabIdentity.Width / 5;
        float h = pnlTabIdentity.Height / 4;
        float x = 0f;
        float y = 0f;
        int r = 0;
        int c = 0;

        int index;

        var loopTo = numberOfIdentifiers;
        for (index = 1; index <= loopTo; index++)
        {

            x = w * c;
            y = h * r;

            CreateTabIdentityButton(index, x, y, w, h, c7);

            if (index == 5 | index == 10 | index == 15 | index == 20 | index == 25 | index == 30 | index == 35 | index == 40)
            {
                r += 1;
                c = 0;
            }
            else
            {
                c += 1;
            }
        }

        foreach (DataRow oRow in ds.Tables("TabIdentifier").Rows)
        {
            {
                ref var withBlock = ref btnTabIdentity[oRow("TabSelectorOrder")];
                withBlock.Text = oRow("TabSelectorIdentity");
                withBlock.BackColor = c15;
                withBlock.ID = oRow("TabSelectorOrder");
                withBlock.Click += ModifyTabIdentityButton_Click;
            }
        }

    }



    private void CreateTabIdentityButton(int btnNo, float xPos, float yPos, float w, float h, Color cc)
    {

        // we don't create the first one son they match with the ID integer
        btnTabIdentity[btnNo] = new KitchenButton("", w, h, cc, c2);
        {
            ref var withBlock = ref btnTabIdentity[btnNo];
            withBlock.Location = new Point(xPos, yPos);
            withBlock.ForeColor = c3;
        }

        pnlTabIdentity.Controls.Add(btnTabIdentity[btnNo]);

    }



    private void ModifyTabIdentityButton_Click(object sender, EventArgs e)
    {

        KitchenButton objButton;

        try
        {
            objButton = (KitchenButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        _tabIdentString = objButton.Text;
        TabIdentityChange(objButton);

    }

    private void TabIdentityChange(KitchenButton obj)
    {

        foreach (DataRow oRow in ds.Tables("TabIdentifier").Rows)
        {
            {
                ref var withBlock = ref btnTabIdentity[oRow("TabSelectorOrder")];
                withBlock.BackColor = c15;
            }
        }

        obj.BackColor = Color.RoyalBlue;
        PerformAcceptTest();

    }

    private void NumCust_Click(int custInteger)
    {

        _nCustomers = custInteger;
        PerformAcceptTest();

    }

    private void PerformAcceptTest()
    {

        if (!(Conversions.ToDouble(NCustomers) == 0d) & !(TabIdentString == "***---***"))
        {
            currentTable.NumberOfCustomers = NCustomers;
            currentTable.TabName = TabIdentString;
            // currentTable.TabID = -555
            GenerateOrderTables.LoadTabIDinExperinceTable();
            // sss      GenerateOrderTables.SaveAvailTabsAndTables()
            TabIdentDispose?.Invoke();
        }

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        TabIdentDispose?.Invoke();

    }

    private void btnAccept_Click(object sender, EventArgs e)
    {

        bool somethingChanged = false;

        if (!(Conversions.ToDouble(NCustomers) == 0d) & !(currentTable.NumberOfCustomers == NCustomers))
        {
            currentTable.NumberOfCustomers = NCustomers;
            somethingChanged = true;
        }

        if (!(TabIdentString == "***---***") & !(currentTable.TabName == TabIdentString))
        {
            currentTable.TabName = TabIdentString;
            somethingChanged = true;
        }

        if (somethingChanged == true)
        {
            GenerateOrderTables.LoadTabIDinExperinceTable();
        }
        TabIdentDispose?.Invoke();

    }
}