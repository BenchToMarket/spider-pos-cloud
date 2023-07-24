using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class Seating_ColorCode : System.Windows.Forms.UserControl
{

    #region  Windows Form Designer generated code 

    public Seating_ColorCode() : base()
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
    private Global.System.Windows.Forms.Label _lblCodeUnavail;

    internal virtual Global.System.Windows.Forms.Label lblCodeUnavail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCodeUnavail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCodeUnavail = value;
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
    private Global.System.Windows.Forms.Panel _Panel3;

    internal virtual Global.System.Windows.Forms.Panel Panel3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel3 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel4;

    internal virtual Global.System.Windows.Forms.Panel Panel4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel4 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblCodeAvail;

    internal virtual Global.System.Windows.Forms.Label lblCodeAvail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCodeAvail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCodeAvail = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel5;

    internal virtual Global.System.Windows.Forms.Panel Panel5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel5 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel6;

    internal virtual Global.System.Windows.Forms.Panel Panel6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel6 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblCodeSat;

    internal virtual Global.System.Windows.Forms.Label lblCodeSat
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCodeSat;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCodeSat = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel7;

    internal virtual Global.System.Windows.Forms.Panel Panel7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel7 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel8;

    internal virtual Global.System.Windows.Forms.Panel Panel8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel8 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel9;

    internal virtual Global.System.Windows.Forms.Panel Panel9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel9 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel10;

    internal virtual Global.System.Windows.Forms.Panel Panel10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel10 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label4;

    internal virtual Global.System.Windows.Forms.Label Label4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label4 = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnCodeClose;

    internal virtual Global.System.Windows.Forms.Button btnCodeClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCodeClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCodeClose != null)
            {
                _btnCodeClose.Click -= btnCodeClose_Click;
            }

            _btnCodeClose = value;
            if (_btnCodeClose != null)
            {
                _btnCodeClose.Click += btnCodeClose_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblCodeCheckDown;

    internal virtual Global.System.Windows.Forms.Label lblCodeCheckDown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCodeCheckDown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCodeCheckDown = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel11;

    internal virtual Global.System.Windows.Forms.Panel Panel11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel11 = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _lblCodeUnavail = new System.Windows.Forms.Label();
        _Panel2 = new System.Windows.Forms.Panel();
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel3 = new System.Windows.Forms.Panel();
        _Panel4 = new System.Windows.Forms.Panel();
        _lblCodeAvail = new System.Windows.Forms.Label();
        _Panel5 = new System.Windows.Forms.Panel();
        _Panel6 = new System.Windows.Forms.Panel();
        _lblCodeSat = new System.Windows.Forms.Label();
        _Panel7 = new System.Windows.Forms.Panel();
        _Panel8 = new System.Windows.Forms.Panel();
        _lblCodeCheckDown = new System.Windows.Forms.Label();
        _Panel9 = new System.Windows.Forms.Panel();
        _Panel10 = new System.Windows.Forms.Panel();
        _Label4 = new System.Windows.Forms.Label();
        _btnCodeClose = new System.Windows.Forms.Button();
        _btnCodeClose.Click += btnCodeClose_Click;
        _Panel11 = new System.Windows.Forms.Panel();
        _Panel2.SuspendLayout();
        _Panel3.SuspendLayout();
        _Panel5.SuspendLayout();
        _Panel7.SuspendLayout();
        _Panel9.SuspendLayout();
        _Panel11.SuspendLayout();
        this.SuspendLayout();
        // 
        // lblCodeUnavail
        // 
        _lblCodeUnavail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCodeUnavail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblCodeUnavail.Location = new System.Drawing.Point(112, 16);
        _lblCodeUnavail.Name = "_lblCodeUnavail";
        _lblCodeUnavail.Size = new System.Drawing.Size(104, 24);
        _lblCodeUnavail.TabIndex = 1;
        _lblCodeUnavail.Text = "Unavailable";
        _lblCodeUnavail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Panel2
        // 
        _Panel2.Controls.Add(_Panel1);
        _Panel2.Controls.Add(_lblCodeUnavail);
        _Panel2.Location = new System.Drawing.Point(16, 16);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(224, 48);
        _Panel2.TabIndex = 2;
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.DimGray;
        _Panel1.Location = new System.Drawing.Point(0, 0);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(72, 48);
        _Panel1.TabIndex = 1;
        // 
        // Panel3
        // 
        _Panel3.Controls.Add(_Panel4);
        _Panel3.Controls.Add(_lblCodeAvail);
        _Panel3.Location = new System.Drawing.Point(16, 80);
        _Panel3.Name = "_Panel3";
        _Panel3.Size = new System.Drawing.Size(224, 48);
        _Panel3.TabIndex = 3;
        // 
        // Panel4
        // 
        _Panel4.BackColor = System.Drawing.Color.CornflowerBlue;
        _Panel4.Location = new System.Drawing.Point(0, 0);
        _Panel4.Name = "_Panel4";
        _Panel4.Size = new System.Drawing.Size(72, 48);
        _Panel4.TabIndex = 1;
        // 
        // lblCodeAvail
        // 
        _lblCodeAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCodeAvail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblCodeAvail.Location = new System.Drawing.Point(112, 16);
        _lblCodeAvail.Name = "_lblCodeAvail";
        _lblCodeAvail.Size = new System.Drawing.Size(104, 24);
        _lblCodeAvail.TabIndex = 1;
        _lblCodeAvail.Text = "Available";
        _lblCodeAvail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Panel5
        // 
        _Panel5.Controls.Add(_Panel6);
        _Panel5.Controls.Add(_lblCodeSat);
        _Panel5.Location = new System.Drawing.Point(16, 144);
        _Panel5.Name = "_Panel5";
        _Panel5.Size = new System.Drawing.Size(224, 48);
        _Panel5.TabIndex = 4;
        // 
        // Panel6
        // 
        _Panel6.BackColor = System.Drawing.Color.Crimson;
        _Panel6.Location = new System.Drawing.Point(0, 0);
        _Panel6.Name = "_Panel6";
        _Panel6.Size = new System.Drawing.Size(72, 48);
        _Panel6.TabIndex = 1;
        // 
        // lblCodeSat
        // 
        _lblCodeSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCodeSat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblCodeSat.Location = new System.Drawing.Point(112, 16);
        _lblCodeSat.Name = "_lblCodeSat";
        _lblCodeSat.Size = new System.Drawing.Size(104, 24);
        _lblCodeSat.TabIndex = 1;
        _lblCodeSat.Text = "Seated";
        _lblCodeSat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Panel7
        // 
        _Panel7.Controls.Add(_Panel8);
        _Panel7.Controls.Add(_lblCodeCheckDown);
        _Panel7.Location = new System.Drawing.Point(16, 208);
        _Panel7.Name = "_Panel7";
        _Panel7.Size = new System.Drawing.Size(224, 48);
        _Panel7.TabIndex = 5;
        // 
        // Panel8
        // 
        _Panel8.BackColor = System.Drawing.Color.Yellow;
        _Panel8.Location = new System.Drawing.Point(0, 0);
        _Panel8.Name = "_Panel8";
        _Panel8.Size = new System.Drawing.Size(72, 48);
        _Panel8.TabIndex = 1;
        // 
        // lblCodeCheckDown
        // 
        _lblCodeCheckDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCodeCheckDown.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblCodeCheckDown.Location = new System.Drawing.Point(112, 16);
        _lblCodeCheckDown.Name = "_lblCodeCheckDown";
        _lblCodeCheckDown.Size = new System.Drawing.Size(104, 24);
        _lblCodeCheckDown.TabIndex = 1;
        _lblCodeCheckDown.Text = "Check Down";
        _lblCodeCheckDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Panel9
        // 
        _Panel9.Controls.Add(_Panel10);
        _Panel9.Controls.Add(_Label4);
        _Panel9.Location = new System.Drawing.Point(16, 272);
        _Panel9.Name = "_Panel9";
        _Panel9.Size = new System.Drawing.Size(224, 48);
        _Panel9.TabIndex = 6;
        // 
        // Panel10
        // 
        _Panel10.BackColor = System.Drawing.Color.LightGreen;
        _Panel10.Location = new System.Drawing.Point(0, 0);
        _Panel10.Name = "_Panel10";
        _Panel10.Size = new System.Drawing.Size(72, 48);
        _Panel10.TabIndex = 1;
        // 
        // Label4
        // 
        _Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Label4.Location = new System.Drawing.Point(112, 16);
        _Label4.Name = "_Label4";
        _Label4.Size = new System.Drawing.Size(104, 24);
        _Label4.TabIndex = 1;
        _Label4.Text = "Your Table";
        _Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnCodeClose
        // 
        _btnCodeClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCodeClose.Location = new System.Drawing.Point(120, 336);
        _btnCodeClose.Name = "_btnCodeClose";
        _btnCodeClose.Size = new System.Drawing.Size(112, 48);
        _btnCodeClose.TabIndex = 8;
        _btnCodeClose.Text = "Close";
        // 
        // Panel11
        // 
        _Panel11.BackColor = System.Drawing.Color.LightSlateGray;
        _Panel11.Controls.Add(_Panel2);
        _Panel11.Controls.Add(_Panel3);
        _Panel11.Controls.Add(_Panel5);
        _Panel11.Controls.Add(_Panel7);
        _Panel11.Controls.Add(_Panel9);
        _Panel11.Controls.Add(_btnCodeClose);
        _Panel11.Location = new System.Drawing.Point(8, 8);
        _Panel11.Name = "_Panel11";
        _Panel11.Size = new System.Drawing.Size(256, 400);
        _Panel11.TabIndex = 9;
        // 
        // Seating_ColorCode
        // 
        this.BackColor = System.Drawing.Color.SlateBlue;
        this.Controls.Add(_Panel11);
        this.Name = "Seating_ColorCode";
        this.Size = new System.Drawing.Size(272, 416);
        _Panel2.ResumeLayout(false);
        _Panel3.ResumeLayout(false);
        _Panel5.ResumeLayout(false);
        _Panel7.ResumeLayout(false);
        _Panel9.ResumeLayout(false);
        _Panel11.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void btnCodeClose_Click(object sender, EventArgs e)
    {

        this.Dispose();

    }
}