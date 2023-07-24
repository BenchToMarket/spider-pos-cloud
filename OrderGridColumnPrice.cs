

public partial class OrderGridColumnPrice : DataGridTextBoxColumn
{

    // **************
    // no longer using ... wse just use OrdeGridColumn

    public OrderGridColumnPrice() : base()
    {


    }


    protected override void Paint(Global.System.Drawing.Graphics g, System.Drawing.Rectangle bounds, Global.System.Windows.Forms.CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
    {

        DataGrid thisGrid = this.DataGridTableStyle.DataGrid;
        object statusValue = thisGrid(rowNum, 0);
        object itemIDValue = thisGrid(rowNum, 5);

        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(itemIDValue, 0, false)))
        {
            foreBrush = new SolidBrush(c2);
        }
        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 0, false)))
        {

            foreBrush = new SolidBrush(c3);
        }

        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 1, false)))                         // Hold
        {
            // backBrush = New SolidBrush(Color.Red)
            foreBrush = new SolidBrush(Color.Red);
        }

        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 2, false)))             // Sent to Kitchen/Bar
        {
            // backBrush = New SolidBrush(c6) '(Color.Yellow)
            foreBrush = new SolidBrush(c6);
        }


        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 3, false)))             // Ready for Delivery
        {
            // backBrush = New SolidBrush(Color.Gold)
            foreBrush = new SolidBrush(Color.Gold);
        }


        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 4, false)))             // Delivered
        {
            // backBrush = New SolidBrush(Color.LightGray)
            foreBrush = new SolidBrush(Color.LightGray);
        }


        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, -1, false)))
        {
            foreBrush = new SolidBrush(Color.LightGray);

        }

        backBrush = new SolidBrush(Color.Black);

        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);

    }

}