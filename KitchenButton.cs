internal partial class KitchenButton : Button
{

    private int _id;
    private int _index;
    private decimal _payRate;

    public KitchenButton(string _text, int W, int H, Color cBack, Color cFore)
    {
        System.Text = _text;
        Width = W;
        Height = H;
        BackColor = cBack;
        ForeColor = cFore;
        Font = new Font("Comic Sans MS", 12.0d);

    }

    public KitchenButton()
    {

    }

    internal int ID
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    internal int ButtonIndex
    {
        get
        {
            return _index;
        }
        set
        {
            _index = value;
        }
    }

    internal decimal PayRate
    {
        get
        {
            return _payRate;
        }
        set
        {
            _payRate = value;
        }
    }

}





// ********************
// AvailTableButton

internal partial class AvailTableButton : Button
{

    private long _experienceNumber;
    private int _numberOfCustomers;
    private int _numberOfChecks;
    private int _currentMenu;
    private long _tabID;
    private int _empID;

    public AvailTableButton()
    {

    }

    internal long ExperienceNumber
    {
        get
        {
            return _experienceNumber;
        }
        set
        {
            _experienceNumber = value;
        }
    }

    internal int NumberOfCustomers
    {
        get
        {
            return _numberOfCustomers;
        }
        set
        {
            _numberOfCustomers = value;
        }
    }

    internal int NumberOfChecks
    {
        get
        {
            return _numberOfChecks;
        }
        set
        {
            _numberOfChecks = value;
        }
    }

    internal int CurrentMenu
    {
        get
        {
            return _currentMenu;
        }
        set
        {
            _currentMenu = value;
        }
    }

    internal long TabID
    {
        get
        {
            return _tabID;
        }
        set
        {
            _tabID = value;
        }
    }

    internal int EmpID
    {
        get
        {
            return _empID;
        }
        set
        {
            _empID = value;
        }
    }

}

// *****************
// clockIn Button
// *****************
// no longer using

internal partial class ClockInButton : Button
{

    private int _empID;
    private int _passcodeID;
    private int _jobCodeID;

    internal int EmpID
    {
        get
        {
            return _empID;
        }
        set
        {
            _empID = value;
        }
    }

    internal int PassCodeID
    {
        get
        {
            return _passcodeID;
        }
        set
        {
            _passcodeID = value;
        }
    }

    internal int JobCodeID
    {
        get
        {
            return _jobCodeID;
        }
        set
        {
            _jobCodeID = value;
        }
    }

}