

public partial class OrderGridColumn : DataGridTextBoxColumn
{

    private bool forPrice;
    private bool forQuantity;
    private bool forCourse;


    public OrderGridColumn(bool price, bool quantity, bool course) : base()
    {

        forPrice = price;
        forQuantity = quantity;
        forCourse = course;

    }


    protected override void Paint(Global.System.Drawing.Graphics g, System.Drawing.Rectangle bounds, Global.System.Windows.Forms.CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
    {

        DataGrid thisGrid = this.DataGridTableStyle.DataGrid;
        object statusValue = thisGrid(rowNum, 0);
        object sinIDValue = thisGrid(rowNum, 1);
        object siiIDValue = thisGrid(rowNum, 2);
        object itemIDValue = thisGrid(rowNum, 6);
        object quantityIDValue = thisGrid(rowNum, 7);
        object priceIDValue = thisGrid(rowNum, 9);


        if (forPrice == true) // 444 And itemIDValue = 0 Then
        {
            // 444   foreBrush = New SolidBrush(c2)
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(itemIDValue, 0, false)))
            {
                foreBrush = new SolidBrush(c2);
            }
            else if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(sinIDValue, siiIDValue, false), Operators.ConditionalCompareObjectEqual(priceIDValue, 0, false))))
            {
                foreBrush = new SolidBrush(c2);
            }
            else
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 0, false)))             // not sent yet
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sinIDValue, siiIDValue, false)))
                    {
                        foreBrush = new SolidBrush(c3);
                    }
                    else
                    {
                        foreBrush = new SolidBrush(Color.AntiqueWhite);
                    }
                }

                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 1, false)))                         // Hold
                {
                    foreBrush = new SolidBrush(Color.Red);
                }

                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 2, false)))             // Sent to Kitchen/Bar
                {
                    foreBrush = new SolidBrush(c17); // (c1)  '(c6)
                }

                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 3, false)))             // Ready for Delivery
                {
                    foreBrush = new SolidBrush(Color.Gold);
                }

                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 4, false)))             // Delivered
                {
                    foreBrush = new SolidBrush(c10);  // (Color.LightGray)
                }

                else if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(statusValue, 8, false), Operators.ConditionalCompareObjectEqual(statusValue, 9, false)), Operators.ConditionalCompareObjectEqual(statusValue, 10, false))))               // xFer or   Voided
                {
                    foreBrush = new SolidBrush(c10);  // (Color.LightGray)
                }

                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, -1, false)))
                {
                    foreBrush = new SolidBrush(Color.LightGray);

                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(priceIDValue, 0, false)))
                {
                    foreBrush = new SolidBrush(c1);
                }
            }
        }

        else if (forCourse == true)
        {
            if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(itemIDValue, 0, false), Operators.ConditionalCompareObjectNotEqual(sinIDValue, siiIDValue, false))))
            {
                foreBrush = new SolidBrush(c2);
            }
            else
            {
                foreBrush = new SolidBrush(c15);
            }
        }

        else if (forQuantity == true)
        {
            // only display quantity if on main item and > 1     otherwise black
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityIDValue, 1, false)))
            {
                foreBrush = new SolidBrush(c2);
            }
            // ElseIf quantityIDValue > 9 Then
            // foreBrush = New SolidBrush(c1)
            // g.ScaleTransform(0.95F, 1.0F)
            else
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(sinIDValue, siiIDValue, false)))
                {
                    foreBrush = new SolidBrush(c2);
                }
                else
                {
                    foreBrush = new SolidBrush(c1);
                }
                // MsgBox(bounds.ToString)
                // bounds = New Rectangle(2, 48, 15, 23)

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(quantityIDValue, 9, false)))
                {

                    // Me.TextBox.Font = New Font("Microsoft Sans Serif", 2.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    // Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                }
            }
        }
        else
        {
            // not sure if this is just a repeat of price (or there is some other criteria passed)
            // ithink this is for Item Name as well
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 0, false)))                     // not ordered yet
            {

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sinIDValue, siiIDValue, false)))
                {
                    foreBrush = new SolidBrush(c3);
                }
                else
                {
                    foreBrush = new SolidBrush(Color.AntiqueWhite);
                }
            }

            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 1, false)))                         // Hold
            {
                foreBrush = new SolidBrush(Color.Red);
            }

            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 2, false)))             // Sent to Kitchen/Bar
            {
                foreBrush = new SolidBrush(c17); // (c1)  '(c6)
            }

            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 3, false)))             // Ready for Delivery
            {
                foreBrush = new SolidBrush(Color.Gold);
            }

            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, 4, false)))             // Delivered
            {
                foreBrush = new SolidBrush(c10);  // (Color.LightGray)
            }

            else if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(statusValue, 8, false), Operators.ConditionalCompareObjectEqual(statusValue, 9, false)), Operators.ConditionalCompareObjectEqual(statusValue, 10, false))))               // xFer or   Voided
            {
                foreBrush = new SolidBrush(c10);  // (Color.LightGray)
            }

            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(statusValue, -1, false)))
            {
                foreBrush = new SolidBrush(Color.LightGray);

            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(priceIDValue, 0, false)))
            {
                foreBrush = new SolidBrush(c1);
            }

        }

        backBrush = new SolidBrush(Color.Black);



        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);

    }
}