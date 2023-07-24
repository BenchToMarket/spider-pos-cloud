using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataSet_Builder;

public partial class Seating_EnterTab : System.Windows.Forms.UserControl
{

    private string _newTabName;
    // Friend WithEvents readAuthSeating As ReadCredit

    private DataSet_Builder.Payment tabAccountInfo = new DataSet_Builder.Payment();
    private Timer cardReadFailedTimer;

    private string _methodUse;
    private Global.System.Windows.Forms.Button _btnPickup;

    internal virtual Global.System.Windows.Forms.Button btnPickup
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPickup;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPickup != null)
            {
                _btnPickup.Click -= btnPickup_Click;
            }

            _btnPickup = value;
            if (_btnPickup != null)
            {
                _btnPickup.Click += btnPickup_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblCardReadFailed;

    internal virtual Global.System.Windows.Forms.Label lblCardReadFailed
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCardReadFailed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCardReadFailed = value;
        }
    }
    private string _startedFrom;

    internal string NewTabName
    {
        get
        {
            return _newTabName;
        }
        set
        {
            _newTabName = value;
        }
    }

    internal string MethedUse
    {
        get
        {
            return _methodUse;
        }
        set
        {
            _methodUse = value;
        }
    }

    internal string StartedFrom
    {
        get
        {
            return _startedFrom;
        }
        set
        {
            _startedFrom = value;
        }
    }


    public event OpenNewTabEventEventHandler OpenNewTabEvent;

    public delegate void OpenNewTabEventEventHandler();
    public event OpenNewTakeOutTabEventHandler OpenNewTakeOutTab;

    public delegate void OpenNewTakeOutTabEventHandler();
    public event CancelNewTabEventHandler CancelNewTab;

    public delegate void CancelNewTabEventHandler();
    public event CustomerCardEventEventHandler CustomerCardEvent;

    public delegate void CustomerCardEventEventHandler(); // ByRef tabAccountInfo As DataSet_Builder.Payment)


    #region  Windows Form Designer generated code 

    public Seating_EnterTab() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();
        // _startedFrom = fm

        // Add any initialization after the InitializeComponent() call
        if (typeProgram == "Online_Demo")
        {
            btnDemoCC.Visible = true;
            btnDemoCC.BringToFront();
        }

        // 444      If tn Is Nothing Then
        // this means this is from Login, there is no Tab Name 
        // therefeor is for New Tab Open
        // 444       readAuthSeating = New ReadCredit(True)
        // 444        Else
        // 444        readAuthSeating = New ReadCredit(False)
        // 444      End If

        // readAuth.IsNewTab = True

    }

    // Form overrides dispose to clean up the component list.
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
    private Global.System.Windows.Forms.Button _btnEnterTabCancel;

    internal virtual Global.System.Windows.Forms.Button btnEnterTabCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnEnterTabCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnEnterTabCancel != null)
            {
                _btnEnterTabCancel.Click -= btnEnterTabCancel_Click;
            }

            _btnEnterTabCancel = value;
            if (_btnEnterTabCancel != null)
            {
                _btnEnterTabCancel.Click += btnEnterTabCancel_Click;
            }
        }
    }
    private DataSet_Builder.KeyBoard_UC _tabNameKeyboard;

    internal virtual DataSet_Builder.KeyBoard_UC tabNameKeyboard
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tabNameKeyboard;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tabNameKeyboard != null)
            {
                _tabNameKeyboard.StringEntered -= TabNameEntered;
            }

            _tabNameKeyboard = value;
            if (_tabNameKeyboard != null)
            {
                _tabNameKeyboard.StringEntered += TabNameEntered;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnOpen;

    internal virtual Global.System.Windows.Forms.Button btnOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOpen != null)
            {
                _btnOpen.Click -= btnOpen_Click;
            }

            _btnOpen = value;
            if (_btnOpen != null)
            {
                _btnOpen.Click += btnOpen_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTakeOut;

    internal virtual Global.System.Windows.Forms.Button btnTakeOut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTakeOut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTakeOut != null)
            {
                _btnTakeOut.Click -= btnTakeOut_Click;
            }

            _btnTakeOut = value;
            if (_btnTakeOut != null)
            {
                _btnTakeOut.Click += btnTakeOut_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDemoCC;

    internal virtual Global.System.Windows.Forms.Button btnDemoCC
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDemoCC;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDemoCC != null)
            {
                _btnDemoCC.Click -= btnDemoCC_Click;
            }

            _btnDemoCC = value;
            if (_btnDemoCC != null)
            {
                _btnDemoCC.Click += btnDemoCC_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _btnPickup = new System.Windows.Forms.Button();
        _btnPickup.Click += btnPickup_Click;
        _btnDemoCC = new System.Windows.Forms.Button();
        _btnDemoCC.Click += btnDemoCC_Click;
        _btnTakeOut = new System.Windows.Forms.Button();
        _btnTakeOut.Click += btnTakeOut_Click;
        _btnOpen = new System.Windows.Forms.Button();
        _btnOpen.Click += btnOpen_Click;
        _btnEnterTabCancel = new System.Windows.Forms.Button();
        _btnEnterTabCancel.Click += btnEnterTabCancel_Click;
        _Label1 = new System.Windows.Forms.Label();
        _tabNameKeyboard = new DataSet_Builder.KeyBoard_UC();
        _tabNameKeyboard.StringEntered += TabNameEntered;
        _lblCardReadFailed = new System.Windows.Forms.Label();
        _Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.RoyalBlue;
        _Panel1.Controls.Add(_lblCardReadFailed);
        _Panel1.Controls.Add(_btnPickup);
        _Panel1.Controls.Add(_btnDemoCC);
        _Panel1.Controls.Add(_btnTakeOut);
        _Panel1.Controls.Add(_btnOpen);
        _Panel1.Controls.Add(_btnEnterTabCancel);
        _Panel1.Controls.Add(_Label1);
        _Panel1.Controls.Add(_tabNameKeyboard);
        _Panel1.Location = new System.Drawing.Point(24, 16);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(728, 416);
        _Panel1.TabIndex = 1;
        // 
        // btnPickup
        // 
        _btnPickup.BackColor = System.Drawing.Color.LightSlateGray;
        _btnPickup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnPickup.ForeColor = System.Drawing.Color.White;
        _btnPickup.Location = new System.Drawing.Point(600, 16);
        _btnPickup.Name = "_btnPickup";
        _btnPickup.Size = new System.Drawing.Size(104, 56);
        _btnPickup.TabIndex = 22;
        _btnPickup.Text = "Pickup";
        _btnPickup.UseVisualStyleBackColor = false;
        // 
        // btnDemoCC
        // 
        _btnDemoCC.BackColor = System.Drawing.Color.LightSteelBlue;
        _btnDemoCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDemoCC.Location = new System.Drawing.Point(128, 40);
        _btnDemoCC.Name = "_btnDemoCC";
        _btnDemoCC.Size = new System.Drawing.Size(104, 64);
        _btnDemoCC.TabIndex = 21;
        _btnDemoCC.Text = "Demo Card Swipe";
        _btnDemoCC.UseVisualStyleBackColor = false;
        _btnDemoCC.Visible = false;
        // 
        // btnTakeOut
        // 
        _btnTakeOut.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTakeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTakeOut.ForeColor = System.Drawing.Color.White;
        _btnTakeOut.Location = new System.Drawing.Point(472, 16);
        _btnTakeOut.Name = "_btnTakeOut";
        _btnTakeOut.Size = new System.Drawing.Size(104, 56);
        _btnTakeOut.TabIndex = 4;
        _btnTakeOut.Text = "Take Out";
        _btnTakeOut.UseVisualStyleBackColor = false;
        // 
        // btnOpen
        // 
        _btnOpen.BackColor = System.Drawing.Color.LightSlateGray;
        _btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnOpen.ForeColor = System.Drawing.Color.White;
        _btnOpen.Location = new System.Drawing.Point(346, 16);
        _btnOpen.Name = "_btnOpen";
        _btnOpen.Size = new System.Drawing.Size(104, 56);
        _btnOpen.TabIndex = 3;
        _btnOpen.Text = "Dine In";
        _btnOpen.UseVisualStyleBackColor = false;
        // 
        // btnEnterTabCancel
        // 
        _btnEnterTabCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnEnterTabCancel.ForeColor = System.Drawing.Color.White;
        _btnEnterTabCancel.Location = new System.Drawing.Point(24, 16);
        _btnEnterTabCancel.Name = "_btnEnterTabCancel";
        _btnEnterTabCancel.Size = new System.Drawing.Size(104, 48);
        _btnEnterTabCancel.TabIndex = 2;
        _btnEnterTabCancel.Text = "Cancel";
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.ForeColor = System.Drawing.Color.Black;
        _Label1.Location = new System.Drawing.Point(168, 16);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(104, 40);
        _Label1.TabIndex = 1;
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // tabNameKeyboard
        // 
        _tabNameKeyboard.BackColor = System.Drawing.Color.SlateGray;
        _tabNameKeyboard.EnteredString = (object)null;
        _tabNameKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _tabNameKeyboard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _tabNameKeyboard.Location = new System.Drawing.Point(16, 80);
        _tabNameKeyboard.Name = "_tabNameKeyboard";
        _tabNameKeyboard.Size = new System.Drawing.Size(688, 312);
        _tabNameKeyboard.TabIndex = 0;
        // 
        // lblCardReadFailed
        // 
        _lblCardReadFailed.AutoSize = true;
        _lblCardReadFailed.BackColor = System.Drawing.Color.White;
        _lblCardReadFailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCardReadFailed.Location = new System.Drawing.Point(252, 109);
        _lblCardReadFailed.Name = "_lblCardReadFailed";
        _lblCardReadFailed.Size = new System.Drawing.Size(240, 29);
        _lblCardReadFailed.TabIndex = 23;
        _lblCardReadFailed.Text = "Card Read Failed...";
        _lblCardReadFailed.Visible = false;
        // 
        // Seating_EnterTab
        // 
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(_Panel1);
        this.Name = "Seating_EnterTab";
        this.Size = new System.Drawing.Size(776, 485);
        _Panel1.ResumeLayout(false);
        _Panel1.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    internal void RestartSeatingTabWithName(string fm, string tn)
    {

        if (tn is not null)
        {
            _newTabName = tn;
            tabNameKeyboard.StartingWithText(tn);
        }
        else
        {
            tabNameKeyboard.StartingWithText("");
        }
        _startedFrom = fm;

    }

    private void TabNameEntered(object sender, EventArgs e)
    {

        _methodUse = "Dine In";

        if (tabNameKeyboard.EnteredString is not null)
        {
            _newTabName = tabNameKeyboard.EnteredString;
        }
        else
        {
            _newTabName = "New Tab";
        }

        RemoveCardHandler();
        OpenNewTabEvent?.Invoke();

    }

    private void btnEnterTabCancel_Click(object sender, EventArgs e)
    {

        RemoveCardHandler();
        CancelNewTab?.Invoke();

    }

    private void btnOpen_Click(object sender, EventArgs e)
    {

        _methodUse = "Dine In";

        if (tabNameKeyboard.EnteredString is null | tabNameKeyboard.EnteredString.Length == 0)
        {
            _newTabName = _methodUse + " Tab";
        }
        else
        {
            _newTabName = tabNameKeyboard.EnteredString;
        }

        RemoveCardHandler();
        OpenNewTabEvent?.Invoke();
    }

    private void btnTakeOut_Click(object sender, EventArgs e)
    {

        _methodUse = "Take Out";
        // currentTable.MethodUse = "Take Out"

        if (tabNameKeyboard.EnteredString is null | tabNameKeyboard.EnteredString.Length == 0)
        {
            _newTabName = _methodUse + " Tab";
        }
        else
        {
            _newTabName = tabNameKeyboard.EnteredString;
        }

        RemoveCardHandler();
        OpenNewTakeOutTab?.Invoke(); // OpenNewTabEve)  '
    }

    private void btnPickup_Click(object sender, EventArgs e)
    {
        _methodUse = "Pickup";
        // currentTable.MethodUse = "Pickup"

        if (tabNameKeyboard.EnteredString is null | tabNameKeyboard.EnteredString.Length == 0)
        {
            _newTabName = _methodUse + " Tab";
        }
        else
        {
            _newTabName = tabNameKeyboard.EnteredString;
        }

        RemoveCardHandler();
        OpenNewTakeOutTab?.Invoke();
    }

    private void CustomerCardRead222(ref DataSet_Builder.Payment newpayment) // 444 Handles readAuthSeating.CardReadSuccessful
    {

        // AddPaymentToCollection(newpayment)
        // _methodUse = "Dine In"
        // tabAccountInfo = newpayment

        RemoveCardHandler();
        CustomerCardEvent?.Invoke(); // 444tabAccountInfo)

    }

    internal void CardRead_Failed222() // 444 Handles readAuthSeating.CardReadFailed
    {

        lblCardReadFailed.Visible = true;

        return;
        // cardReadFailedTimer = New Timer
        // AddHandler cardReadFailedTimer.Tick, AddressOf CardReadTimerExpired222
        // cardReadFailedTimer.Interval = 3000
        // cardReadFailedTimer.Start()

    }
    private void CardReadTimerExpired222(object sender, EventArgs e)
    {

        cardReadFailedTimer.Dispose();
        lblCardReadFailed.Visible = false;

    }

    internal void EnterTabNameFromSwipe(string tabName) // 444 Handles readAuthSeating.EnteringTabNameInKeyboard
    {

        lblCardReadFailed.Visible = false;
        tabNameKeyboard.StartingWithText(tabName);
        this.Update();

    }

    private void RemoveCardHandler()
    {
        // 222
        // tmrCardRead.Stop()
        // RemoveHandler tmrCardRead.Tick, AddressOf readAuthSeating.tmrCardRead_Tick

    }


    private void btnDemoCC_Click(object sender, EventArgs e)
    {
        var newPayment = default(Payment);

        newPayment.experienceNumber = demoExpNumID;    // currentTable.ExperienceNumber
        newPayment.Name = "Test Credit";
        newPayment.FirstName = "Test";
        newPayment.LastName = "Credit";
        newPayment.Track2 = "37130000000000";
        newPayment.AccountNumber = "371301234567890" + demoCcNumberAddon.ToString;
        newPayment.PaymentTypeID = 2;
        newPayment.PaymentTypeName = "AMEX";
        newPayment.ExpDate = "0809";
        newPayment.Swiped = true;
        demoCcNumberAddon += 1;

        _methodUse = "Dine In";
        tabAccountInfo = newPayment;

        if (typeProgram == "Online_Demo")
        {
            // it is always Online_Demo here
            _newTabName = newPayment.Name; // "New Tab"
            RemoveCardHandler();
            OpenNewTabEvent?.Invoke();
            return;
        }

        // 444     RemoveCardHandler()
        // 444 RaiseEvent CustomerCardEvent() 

    }



}