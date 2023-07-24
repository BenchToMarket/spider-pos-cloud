

public partial class OrderCloseGridColumn : DataGridTextBoxColumn
{

    public OrderCloseGridColumn() : base()
    {

    }

    protected override void Paint(Global.System.Drawing.Graphics g, System.Drawing.Rectangle bounds, Global.System.Windows.Forms.CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
    {

        DataGrid thisGrid = this.DataGridTableStyle.DataGrid;
        object statusValue = thisGrid(rowNum, 0);
        // Dim itemIDValue As Object = thisGrid(rowNum, 5)
        object priceIDValue = thisGrid(rowNum, 4);

        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 0, false)))
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
            foreBrush = new SolidBrush(c19); // c17) '(c1)
        }

        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 3, false)))             // Ready for Delivery
        {
            // backBrush = New SolidBrush(Color.Gold)
            foreBrush = new SolidBrush(Color.Gold);
        }

        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 4, false)))             // Delivered
        {
            // backBrush = New SolidBrush(Color.LightGray)
            foreBrush = new SolidBrush(c10);  // (Color.lightGray)
        }

        else if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(statusValue, 8, false), Operators.ConditionalCompareObjectEqual(statusValue, 9, false))))  // xFer or Voided
        {
            // backBrush = New SolidBrush(Color.LightGray)
            foreBrush = new SolidBrush(c10);  // (Color.lightGray)
        }

        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, -1, false)))
        {
            foreBrush = new SolidBrush(Color.LightGray);

        }

        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(priceIDValue, 0, false)))
        {
            foreBrush = new SolidBrush(c1);
        }


        backBrush = new SolidBrush(Color.Black);

        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);

    }

}