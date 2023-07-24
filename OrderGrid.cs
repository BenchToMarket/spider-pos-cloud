public partial class OrderGrid : DataGrid
{






    public OrderGrid()
    {




    }



    public void ScrollToRow(int row)
    {
        if (this.DataSource is not null)
        {
            this.GridVScrolled(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, row));
        }
    }



}