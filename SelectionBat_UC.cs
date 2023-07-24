using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class SelectionBat_UC : DataSet_Builder.SelectionPanel_UC
{

    // *** not using currently
    // will use when we add batches


    #region  Windows Form Designer generated code 

    public SelectionBat_UC(ref DataView dv, string pp) : base()
    {
        dvUsing = dv;
        dtUsing = ds.Tables("MenuChoice");
        Purpose = pp;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        // dvUsing = New DataView
        DetermineButtonSizes();
        DetermineButtonLocations();
        // GenerateDailyControlButtons()


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
            _Button1 = value;
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
            _Button6 = value;
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
            _Button5 = value;
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
            _Button4 = value;
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
            _Button3 = value;
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
            _Button2 = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _Button6 = new System.Windows.Forms.Button();
        _Button5 = new System.Windows.Forms.Button();
        _Button4 = new System.Windows.Forms.Button();
        _Button3 = new System.Windows.Forms.Button();
        _Button2 = new System.Windows.Forms.Button();
        _Button1 = new System.Windows.Forms.Button();
        _Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.LightGray;
        _Panel1.Controls.Add(_Button6);
        _Panel1.Controls.Add(_Button5);
        _Panel1.Controls.Add(_Button4);
        _Panel1.Controls.Add(_Button3);
        _Panel1.Controls.Add(_Button2);
        _Panel1.Controls.Add(_Button1);
        _Panel1.Location = new System.Drawing.Point(16, 504);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(768, 72);
        _Panel1.TabIndex = 2;
        // 
        // Button6
        // 
        _Button6.BackColor = System.Drawing.Color.LightSlateGray;
        _Button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button6.Location = new System.Drawing.Point(656, 8);
        _Button6.Name = "_Button6";
        _Button6.Size = new System.Drawing.Size(96, 56);
        _Button6.TabIndex = 5;
        // 
        // Button5
        // 
        _Button5.BackColor = System.Drawing.Color.LightSlateGray;
        _Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button5.Location = new System.Drawing.Point(528, 8);
        _Button5.Name = "_Button5";
        _Button5.Size = new System.Drawing.Size(96, 56);
        _Button5.TabIndex = 4;
        // 
        // Button4
        // 
        _Button4.BackColor = System.Drawing.Color.LightSlateGray;
        _Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button4.Location = new System.Drawing.Point(400, 8);
        _Button4.Name = "_Button4";
        _Button4.Size = new System.Drawing.Size(96, 56);
        _Button4.TabIndex = 3;
        // 
        // Button3
        // 
        _Button3.BackColor = System.Drawing.Color.LightSlateGray;
        _Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button3.Location = new System.Drawing.Point(272, 8);
        _Button3.Name = "_Button3";
        _Button3.Size = new System.Drawing.Size(96, 56);
        _Button3.TabIndex = 2;
        // 
        // Button2
        // 
        _Button2.BackColor = System.Drawing.Color.LightSlateGray;
        _Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button2.Location = new System.Drawing.Point(144, 8);
        _Button2.Name = "_Button2";
        _Button2.Size = new System.Drawing.Size(96, 56);
        _Button2.TabIndex = 1;
        // 
        // Button1
        // 
        _Button1.BackColor = System.Drawing.Color.LightSlateGray;
        _Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button1.Location = new System.Drawing.Point(16, 8);
        _Button1.Name = "_Button1";
        _Button1.Size = new System.Drawing.Size(96, 56);
        _Button1.TabIndex = 0;
        // 
        // SelectionBat_UC
        // 
        this.Controls.Add(_Panel1);
        this.Name = "SelectionBat_UC";
        this.Size = new System.Drawing.Size(800, 640);
        this.Controls.SetChildIndex(_Panel1, 0);
        _Panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion



}