using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class PaymentUserControl : System.Windows.Forms.UserControl
{
    // ********************************
    // do not use anymore
    // was for closing out check


    private decimal _userControlChangingAmount;

    public event ChangeClosingAmountEventHandler ChangeClosingAmount;

    public delegate void ChangeClosingAmountEventHandler(object sender, EventArgs e);

    internal decimal UserControlChangingAmount
    {
        get
        {
            return _userControlChangingAmount;
        }
        set
        {
            _userControlChangingAmount = value;
        }
    }

    #region  Windows Form Designer generated code 

    public PaymentUserControl() : base()
    {

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
    private Global.System.Windows.Forms.TextBox _txtPaymentType;

    internal virtual Global.System.Windows.Forms.TextBox txtPaymentType
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtPaymentType;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _txtPaymentType = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnAmount;

    internal virtual Global.System.Windows.Forms.Button btnAmount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAmount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAmount != null)
            {
                _btnAmount.Click -= btnAmount_Click;
            }

            _btnAmount = value;
            if (_btnAmount != null)
            {
                _btnAmount.Click += btnAmount_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTip;

    internal virtual Global.System.Windows.Forms.Button btnTip
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTip;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnTip = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnTipAdjustment;

    internal virtual Global.System.Windows.Forms.Button btnTipAdjustment
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTipAdjustment;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnTipAdjustment = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _txtPaymentType = new System.Windows.Forms.TextBox();
        _btnAmount = new System.Windows.Forms.Button();
        _btnAmount.Click += btnAmount_Click;
        _btnTip = new System.Windows.Forms.Button();
        _btnTipAdjustment = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // txtPaymentType
        // 
        _txtPaymentType.BorderStyle = System.Windows.Forms.BorderStyle.None;
        _txtPaymentType.Location = new System.Drawing.Point(0, 0);
        _txtPaymentType.Name = "_txtPaymentType";
        _txtPaymentType.Size = new System.Drawing.Size(112, 13);
        _txtPaymentType.TabIndex = 0;
        _txtPaymentType.Text = "";
        // 
        // btnAmount
        // 
        _btnAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _btnAmount.Location = new System.Drawing.Point(112, 0);
        _btnAmount.Name = "_btnAmount";
        _btnAmount.Size = new System.Drawing.Size(72, 24);
        _btnAmount.TabIndex = 1;
        _btnAmount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // btnTip
        // 
        _btnTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _btnTip.Location = new System.Drawing.Point(184, 0);
        _btnTip.Name = "_btnTip";
        _btnTip.Size = new System.Drawing.Size(48, 24);
        _btnTip.TabIndex = 2;
        _btnTip.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // btnTipAdjustment
        // 
        _btnTipAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _btnTipAdjustment.Location = new System.Drawing.Point(232, 0);
        _btnTipAdjustment.Name = "_btnTipAdjustment";
        _btnTipAdjustment.Size = new System.Drawing.Size(48, 24);
        _btnTipAdjustment.TabIndex = 3;
        _btnTipAdjustment.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // PaymentUserControl
        // 
        this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.Controls.Add(_btnTipAdjustment);
        this.Controls.Add(_btnTip);
        this.Controls.Add(_btnAmount);
        this.Controls.Add(_txtPaymentType);
        this.Name = "PaymentUserControl";
        this.Size = new System.Drawing.Size(280, 24);
        this.ResumeLayout(false);

    }

    #endregion


    private void btnAmount_Click(object sender, EventArgs e)
    {

        UserControlChangingAmount = (decimal)btnAmount.Text;


        ChangeClosingAmount?.Invoke(sender, e);

    }

    // Private Sub myBase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click

    // End Sub

}