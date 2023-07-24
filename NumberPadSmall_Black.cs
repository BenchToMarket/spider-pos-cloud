using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;


public partial class NumberPadSmall : System.Windows.Forms.UserControl
{

    private decimal _numberTotal;
    private int _integerNumber;
    private string _numberString;
    private bool _decimalUsed;
    public bool DisplayIntegerNumber;
    public bool changesMade;

    public event NumberEnteredEventHandler NumberEntered;

    public delegate void NumberEnteredEventHandler(object sender, EventArgs e);
    public event NumberChangedEventHandler NumberChanged;

    public delegate void NumberChangedEventHandler();


    public decimal NumberTotal
    {
        get
        {
            return _numberTotal;
        }
        set
        {
            _numberTotal = value;
        }
    }

    public int IntegerNumber
    {
        get
        {
            return _integerNumber;
        }
        set
        {
            _integerNumber = value;
        }
    }

    public string NumberString
    {
        get
        {
            return _numberString;
        }
        set
        {
            _numberString = value;
        }
    }

    public bool DecimalUsed
    {
        get
        {
            return _decimalUsed;
        }
        set
        {
            _decimalUsed = value;
        }
    }

    #region  Windows Form Designer generated code 

    public NumberPadSmall() : base()
    {

        // decimalUsed = decUsed

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

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
    private Global.System.Windows.Forms.Button _Button1;

    internal virtual Global.System.Windows.Forms.Button Button1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button1 != null)
            {
                _Button1.Click -= Button1_Click;
            }

            _Button1 = value;
            if (_Button1 != null)
            {
                _Button1.Click += Button1_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button2;

    internal virtual Global.System.Windows.Forms.Button Button2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button2 != null)
            {
                _Button2.Click -= Button2_Click;
            }

            _Button2 = value;
            if (_Button2 != null)
            {
                _Button2.Click += Button2_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button3;

    internal virtual Global.System.Windows.Forms.Button Button3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button3 != null)
            {
                _Button3.Click -= Button3_Click;
            }

            _Button3 = value;
            if (_Button3 != null)
            {
                _Button3.Click += Button3_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button4;

    internal virtual Global.System.Windows.Forms.Button Button4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button4 != null)
            {
                _Button4.Click -= Button4_Click;
            }

            _Button4 = value;
            if (_Button4 != null)
            {
                _Button4.Click += Button4_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button5;

    internal virtual Global.System.Windows.Forms.Button Button5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button5 != null)
            {
                _Button5.Click -= Button5_Click;
            }

            _Button5 = value;
            if (_Button5 != null)
            {
                _Button5.Click += Button5_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button6;

    internal virtual Global.System.Windows.Forms.Button Button6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button6 != null)
            {
                _Button6.Click -= Button6_Click;
            }

            _Button6 = value;
            if (_Button6 != null)
            {
                _Button6.Click += Button6_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button7;

    internal virtual Global.System.Windows.Forms.Button Button7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button7 != null)
            {
                _Button7.Click -= Button7_Click;
            }

            _Button7 = value;
            if (_Button7 != null)
            {
                _Button7.Click += Button7_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button8;

    internal virtual Global.System.Windows.Forms.Button Button8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button8 != null)
            {
                _Button8.Click -= Button8_Click;
            }

            _Button8 = value;
            if (_Button8 != null)
            {
                _Button8.Click += Button8_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button9;

    internal virtual Global.System.Windows.Forms.Button Button9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button9 != null)
            {
                _Button9.Click -= Button9_Click;
            }

            _Button9 = value;
            if (_Button9 != null)
            {
                _Button9.Click += Button9_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNumberPad;

    internal virtual Global.System.Windows.Forms.Label lblNumberPad
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNumberPad;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNumberPad != null)
            {
                _lblNumberPad.Click -= lblNumberPad_Click;
            }

            _lblNumberPad = value;
            if (_lblNumberPad != null)
            {
                _lblNumberPad.Click += lblNumberPad_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDot;

    internal virtual Global.System.Windows.Forms.Button btnDot
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDot;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDot != null)
            {
                _btnDot.Click -= btnDot_Click;
            }

            _btnDot = value;
            if (_btnDot != null)
            {
                _btnDot.Click += btnDot_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnEnter;

    internal virtual Global.System.Windows.Forms.Button btnEnter
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnEnter;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnEnter != null)
            {
                _btnEnter.Click -= btnEnter_Click;
            }

            _btnEnter = value;
            if (_btnEnter != null)
            {
                _btnEnter.Click += btnEnter_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button0;

    internal virtual Global.System.Windows.Forms.Button Button0
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button0;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button0 != null)
            {
                _Button0.Click -= Button0_Click;
            }

            _Button0 = value;
            if (_Button0 != null)
            {
                _Button0.Click += Button0_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Button1 = new System.Windows.Forms.Button();
        _Button1.Click += Button1_Click;
        _Button2 = new System.Windows.Forms.Button();
        _Button2.Click += Button2_Click;
        _Button3 = new System.Windows.Forms.Button();
        _Button3.Click += Button3_Click;
        _Button4 = new System.Windows.Forms.Button();
        _Button4.Click += Button4_Click;
        _Button5 = new System.Windows.Forms.Button();
        _Button5.Click += Button5_Click;
        _Button6 = new System.Windows.Forms.Button();
        _Button6.Click += Button6_Click;
        _Button7 = new System.Windows.Forms.Button();
        _Button7.Click += Button7_Click;
        _Button8 = new System.Windows.Forms.Button();
        _Button8.Click += Button8_Click;
        _Button9 = new System.Windows.Forms.Button();
        _Button9.Click += Button9_Click;
        _Button0 = new System.Windows.Forms.Button();
        _Button0.Click += Button0_Click;
        _lblNumberPad = new System.Windows.Forms.Label();
        _lblNumberPad.Click += lblNumberPad_Click;
        _btnDot = new System.Windows.Forms.Button();
        _btnDot.Click += btnDot_Click;
        _btnEnter = new System.Windows.Forms.Button();
        _btnEnter.Click += btnEnter_Click;
        this.SuspendLayout();
        // 
        // Button1
        // 
        _Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button1.Location = new System.Drawing.Point(0, 48);
        _Button1.Name = "_Button1";
        _Button1.Size = new System.Drawing.Size(48, 48);
        _Button1.TabIndex = 0;
        _Button1.Text = "1";
        // 
        // Button2
        // 
        _Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button2.Location = new System.Drawing.Point(48, 48);
        _Button2.Name = "_Button2";
        _Button2.Size = new System.Drawing.Size(48, 48);
        _Button2.TabIndex = 1;
        _Button2.Text = "2";
        // 
        // Button3
        // 
        _Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button3.Location = new System.Drawing.Point(96, 48);
        _Button3.Name = "_Button3";
        _Button3.Size = new System.Drawing.Size(48, 48);
        _Button3.TabIndex = 2;
        _Button3.Text = "3";
        // 
        // Button4
        // 
        _Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button4.Location = new System.Drawing.Point(0, 96);
        _Button4.Name = "_Button4";
        _Button4.Size = new System.Drawing.Size(48, 48);
        _Button4.TabIndex = 3;
        _Button4.Text = "4";
        // 
        // Button5
        // 
        _Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button5.Location = new System.Drawing.Point(48, 96);
        _Button5.Name = "_Button5";
        _Button5.Size = new System.Drawing.Size(48, 48);
        _Button5.TabIndex = 4;
        _Button5.Text = "5";
        // 
        // Button6
        // 
        _Button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button6.Location = new System.Drawing.Point(96, 96);
        _Button6.Name = "_Button6";
        _Button6.Size = new System.Drawing.Size(48, 48);
        _Button6.TabIndex = 5;
        _Button6.Text = "6";
        // 
        // Button7
        // 
        _Button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button7.Location = new System.Drawing.Point(0, 144);
        _Button7.Name = "_Button7";
        _Button7.Size = new System.Drawing.Size(48, 48);
        _Button7.TabIndex = 6;
        _Button7.Text = "7";
        // 
        // Button8
        // 
        _Button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button8.Location = new System.Drawing.Point(48, 144);
        _Button8.Name = "_Button8";
        _Button8.Size = new System.Drawing.Size(48, 48);
        _Button8.TabIndex = 7;
        _Button8.Text = "8";
        // 
        // Button9
        // 
        _Button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button9.Location = new System.Drawing.Point(96, 144);
        _Button9.Name = "_Button9";
        _Button9.Size = new System.Drawing.Size(48, 48);
        _Button9.TabIndex = 8;
        _Button9.Text = "9";
        // 
        // Button0
        // 
        _Button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button0.Location = new System.Drawing.Point(0, 192);
        _Button0.Name = "_Button0";
        _Button0.Size = new System.Drawing.Size(48, 48);
        _Button0.TabIndex = 9;
        _Button0.Text = "0";
        // 
        // lblNumberPad
        // 
        _lblNumberPad.BackColor = System.Drawing.Color.White;
        _lblNumberPad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblNumberPad.Location = new System.Drawing.Point(8, 16);
        _lblNumberPad.Name = "_lblNumberPad";
        _lblNumberPad.Size = new System.Drawing.Size(128, 24);
        _lblNumberPad.TabIndex = 10;
        _lblNumberPad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnDot
        // 
        _btnDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDot.Location = new System.Drawing.Point(48, 192);
        _btnDot.Name = "_btnDot";
        _btnDot.Size = new System.Drawing.Size(48, 48);
        _btnDot.TabIndex = 11;
        _btnDot.Text = "00";
        // 
        // btnEnter
        // 
        _btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnEnter.Location = new System.Drawing.Point(96, 192);
        _btnEnter.Name = "_btnEnter";
        _btnEnter.Size = new System.Drawing.Size(48, 48);
        _btnEnter.TabIndex = 12;
        _btnEnter.Text = "ETR";
        // 
        // NumberPadSmall
        // 
        this.BackColor = System.Drawing.Color.SlateGray;
        this.Controls.Add(_btnEnter);
        this.Controls.Add(_btnDot);
        this.Controls.Add(_lblNumberPad);
        this.Controls.Add(_Button0);
        this.Controls.Add(_Button9);
        this.Controls.Add(_Button8);
        this.Controls.Add(_Button7);
        this.Controls.Add(_Button6);
        this.Controls.Add(_Button5);
        this.Controls.Add(_Button4);
        this.Controls.Add(_Button3);
        this.Controls.Add(_Button2);
        this.Controls.Add(_Button1);
        this.Name = "NumberPadSmall";
        this.Size = new System.Drawing.Size(144, 240);
        this.ResumeLayout(false);

    }

    #endregion

    private void CalculateNumberTotal(int addOnInteger)
    {

        if (DecimalUsed == true)
        {
            if (_integerNumber > 100000000)
            {
                return;
            }
            _integerNumber = _integerNumber * 10 + addOnInteger;
            _numberTotal = Conversions.ToDecimal(Strings.Format(_integerNumber / 100d, "##,###.00"));
        }
        else
        {
            _numberString = _numberString + addOnInteger.ToString();
        }
        changesMade = true;

    }

    public void ShowNumberString()
    {

        if (DecimalUsed == true)
        {
            if (DisplayIntegerNumber == false)
            {
                lblNumberPad.Text = NumberTotal;
            }
            else
            {
                lblNumberPad.Text = IntegerNumber;
            }
        }
        else
        {
            lblNumberPad.Text = NumberString;
        }

        NumberChanged?.Invoke();

    }

    public void ResetValues()
    {

        _integerNumber = 0;
        _numberTotal = 0m;
        _numberString = "";
        ShowNumberString();
        changesMade = false;

    }

    private void Button1_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(1);
        ShowNumberString();

    }

    private void Button2_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(2);
        ShowNumberString();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(3);
        ShowNumberString();
    }

    private void Button4_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(4);
        ShowNumberString();
    }

    private void Button5_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(5);
        ShowNumberString();
    }

    private void Button6_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(6);
        ShowNumberString();
    }

    private void Button7_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(7);
        ShowNumberString();
    }

    private void Button8_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(8);
        ShowNumberString();
    }

    private void Button9_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(9);
        ShowNumberString();
    }

    private void Button0_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(0);
        ShowNumberString();
    }

    private void btnDot_Click(object sender, EventArgs e)
    {
        CalculateNumberTotal(0);
        CalculateNumberTotal(0);
        ShowNumberString();

    }

    private void btnEnter_Click(object sender, EventArgs e)
    {

        NumberEntered?.Invoke(sender, e);

    }


    private void lblNumberPad_Click(object sender, EventArgs e)
    {

        ResetValues();

    }

}