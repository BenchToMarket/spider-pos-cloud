using System;
using System.Collections;
using System.Runtime.InteropServices;
using DataSet_Builder;



public static partial class term_Tahsc
{

    private static Login programStart;

    public static string connectserver;
    public static string localConnectServer;
    public static bool securityPhoenixEst;
    public static bool securityLocalEst;
    public static bool connectionDown = false;

    public static string ourComputerName;
    public static string ourServerName;
    public static bool pointToServer = false;

    public static string typeProgram = "v_1_0";
    // Public typeProgram As String = "Demo"
    // Public typeProgram As String = "Online_Demo"
    public static bool acitveDemo = true; // this is so we can shut off demo
    public static long demoExpNumID = 1L;
    public static int demoNewTicketID = 100001;
    public static long demoOpenOrdersID = 1L;
    public static long demoPaymentID = 1L;
    public static long demoOrderNumber = 123001L;
    public static long demoTabID = 100001L;
    public static int demoCcNumberAddon = 1;
    public static decimal demoCashOpen;

    public static DateTime dateOfExpiration = Conversions.ToDate("03/01/2010"); // "02/02/2020"

    // *** just for testing
    public static DateTime time1;
    public static DateTime time2;
    public static TimeSpan timeDiff;

    // Public Sub Main()
    // LetsStartProgram()
    // End Sub

    // Private Sub LetsStartProgram()
    // programStart = New Login
    // programStart.Show()
    // programStart.DisplayInitialLogon()
    // End Sub

    private static void TestTime()
    {
        time1 = DateTime.Now;
        time2 = DateTime.Now;
        timeDiff = time2.Subtract(time1);
        Interaction.MsgBox(timeDiff.ToString());
    }

    internal static Color c1 = Color.FromArgb(249, 200, 7); // (249, 218, 31) 'Color.Yellow '(252, 234, 128)
    internal static Color c2 = Color.Black;
    internal static Color c3 = Color.White;
    internal static Color c4 = Color.FromArgb(0, 0, 100); // Color.SlateBlue    ' Color.MediumSlateBlue  '
    internal static Color c5 = Color.DimGray;
    internal static Color c6 = Color.FromArgb(100, 149, 237);  // Foods
    internal static Color c7 = Color.SlateGray;
    internal static Color c8 = Color.LightSteelBlue;       // Color.AliceBlue   'Color.PowderBlue
    internal static Color c9 = Color.Firebrick; // Crimson        'Color.Red
    internal static Color c10 = Color.LightSlateGray;
    internal static Color c11 = Color.DarkGray;
    internal static Color c12 = Color.LightGray;
    internal static Color c13 = Color.Black;
    internal static Color c14 = Color.WhiteSmoke;
    internal static Color c15 = Color.CornflowerBlue;
    internal static Color c16 = Color.FromArgb(59, 96, 141);  // Drinks
    internal static Color c17 = Color.RoyalBlue;
    internal static Color c18 = Color.IndianRed;
    internal static Color c19 = Color.DodgerBlue;
    internal static Color c20 = Color.FromArgb(0, 0, 240);

    public enum floorPlanEnum
    {

        FloorPlan1 = 1,
        FloorPlan2 = 2,
        FloorPlan3 = 3,
        FloorPlan4 = 4,
        FloorPlan5 = 5

    }

    internal static Rectangle wa = Screen.PrimaryScreen.WorkingArea;
    internal static Rectangle totalArea = Screen.PrimaryScreen.Bounds;
    internal static double ssX = 1024d;     // wa.Width 
    internal static double ssY = 740d;      // wa.Height '768  
    internal const int buttonSpace = 4;
    internal static double viewOrderWidth = ssX * 0.3d;
    internal static double viewOrderHeight = ssY * 0.7d;

    internal static bool isPhoenixComputer = true;  // this will only be true is the software for Phoenix
    // Friend localMerchantID As Integer
    internal static bool mainServerConnected = true;
    internal static bool tablesFilled;
    internal static int timeoutInterval = 1000;   // default is 1000  (1 sec for every interval count)
    internal static bool allowTableOverride = true;
    // Friend timeoutMultiplier As Integer = 30    ' 30 seconds

    internal static int[] printingRouting = new int[21];
    internal static string[] printingName = new string[21];
    internal static bool[] printingBoolean = new bool[21];
    internal static bool printExpiditer = false;

    internal static CompanyMainInfo companyInfo;
    internal static DinnerTable currentTable;
    internal static EmployeeCollection AllEmployees = new EmployeeCollection();
    internal static EmployeeCollection SalariedEmployees = new EmployeeCollection();
    internal static EmployeeCollection SwipeCodeEmployees = new EmployeeCollection();
    internal static TerminalCollection groupTerminals = new TerminalCollection();
    internal static RawMaterialCollection currentRawMaterials = new RawMaterialCollection();
    internal static Terminal currentTerminal;
    internal static Employee currentServer;
    internal static Employee currentClockEmp;
    internal static Employee actingManager;
    internal static Employee empActive;
    internal static Customer currentCustomer;
    internal static int numberOfTables = 100;
    internal static int numberOfWalls = 50;
    internal static Seating_Table_UC2[] btnTable = new Seating_Table_UC2[101];
    internal static Panel[] btnWall = new Panel[51];

    internal static EmployeeCollection workingEmployees = new EmployeeCollection();       // everyone currently clocked-in to the system
    internal static EmployeeCollection currentServers = new EmployeeCollection();
    internal static EmployeeCollection currentBartenders = new EmployeeCollection();
    internal static EmployeeCollection loggedInBartenders = new EmployeeCollection();
    internal static EmployeeCollection currentManagers = new EmployeeCollection();
    internal static EmployeeCollection todaysFloorPersonnel = new EmployeeCollection();   // everyone who worked the floor that day
    internal static EmployeeCollection allFloorPersonnel = new EmployeeCollection();   // everyone who worked the floor that day
    internal static DataViewBarCollection currentQuickTicketDataViews = new DataViewBarCollection();
    internal static PaymentCollection tabcc = new PaymentCollection();
    internal static PaymentCollection tabccThisExperience = new PaymentCollection();
    internal static CurrentItemCollection newItemCollection = new CurrentItemCollection();

    // 222
    // below 2 collections not used
    internal static PhysicalTableCollection currentPhysicalTables = new PhysicalTableCollection(); // this is all tables in restaurant
    internal static ActiveTableCollection currentActiveTables = new ActiveTableCollection();     // this is active for current employee

    internal static ManagementAuthorization employeeAuthorization;
    internal static OverrideSystemCode systemAuthorization;

    // Friend primaryMenuID As Integer          '= 1
    // Friend secondaryMenuID As Integer            ' = 2
    // Friend autoChangeMneu As DateTime
    // Friend initPrimaryMenuID As Integer
    // Friend currentPrimaryMenuID As Integer
    // Friend currentSecondaryMenuID As Integer

    internal static ArrayList mainCategoryIDArrayList = new ArrayList();
    internal static ArrayList secondaryCategoryIDArrayList = new ArrayList();

    // each terminal Bar Group will have its own currentBartenders Collection
    // any bartender can access their info from any terminal in their terminal group
    // managers may log into any bartender group
    // Friend activeCheck As Integer
    internal static bool activeCheckChanged = false;
    internal static int sinDragSource;
    internal static int checkDragTarget;
    internal static int movingCustomer;    // this is if we are moving the customer panel in split checks
    internal static bool newlyCreatedCheck;
    internal static bool orderScreenInitialized;
    // is a 0 if not
    // only temp
    // ***         ***     some of this should be read off the database

    // should add first two only in CompanyInfo
    // Friend CompanyID As String '= "001111"
    // Friend LocationID As String ' = "000001"
    // Friend currentTerminal.TermID As Integer

    // Friend merchantID As String = "494901"
    // Friend operatorID As String = "eGlobal"
    // Friend currentTerminal.TermMethod As Integer    '(1 -TableService  2 - Qiuck)
    // Friend currentMenuID As Integer
    // Friend currentShift As Integer = 1
    // Friend usingDefaults As Boolean
    // Friend currentTerminal.currentDailyCode As Int64         '***    ***************** need to change
    // Friend lastTicketNumber As Integer = 0
    // Friend autoCloseCheck As Boolean
    // Friend endOfWeek As DayOfWeek    ' (Monday -1 ... Sunday -7)
    // Friend begOfWeek As DayOfWeek
    // Friend onlyOneFloorPlan As Boolean
    // Friend calculateAvgByEntrees As Boolean = True
    // Friend usingBartenderMethod As Boolean = True
    // Friend autoGratuityPercent As Decimal = 0.18
    // Friend isKitchenExpiditer As Boolean = False    ' read off DailyBusiness

    // Friend routingIndex1 As Integer
    // Friend routingIndex2 As Integer
    // Friend routingIndex3 As Integer
    // Friend routingIndex4 As Integer
    // Friend routingIndex5 As Integer

    // ************************************************
    // Card Reader Declarations
    // ************************************************

    // from setupapi.h
    public const short DIGCF_PRESENT = 2;
    public const short DIGCF_DEVICEINTERFACE = 16;

    public const int FILE_FLAG_OVERLAPPED = 0x40000000;
    public const short FILE_SHARE_READ = 1;
    public const short FILE_SHARE_WRITE = 2;
    public const int GENERIC_READ = int.MinValue + 0x00000000;
    public const int GENERIC_WRITE = 0x40000000;
    public const short OPEN_EXISTING = 3;
    public const int WAIT_TIMEOUT = 0x102;
    public const short WAIT_OBJECT_0 = 0;



    [StructLayout(LayoutKind.Sequential)]
    public partial struct HIDD_ATTRIBUTES
    {
        public int Size;
        public short VendorID;
        public short ProductID;
        public short VersionNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct SP_DEVICE_INTERFACE_DATA
    {
        public int cbSize;
        public Guid InterfaceClassGuid;
        public int Flags;
        public int Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        public int cbSize;
        public string DevicePath;
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public int lpSecurityDescriptor;
        public int bInheritHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct OVERLAPPED
    {
        public int Internal;
        public int InternalHigh;
        public int Offset;
        public int OffsetHigh;
        public int hEvent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct HIDP_CAPS
    {
        public short Usage;
        public short UsagePage;
        public short InputReportByteLength;
        public short OutputReportByteLength;
        public short FeatureReportByteLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public short[] Reserved;
        public short NumberLinkCollectionNodes;
        public short NumberInputButtonCaps;
        public short NumberInputValueCaps;
        public short NumberInputDataIndices;
        public short NumberOutputButtonCaps;
        public short NumberOutputValueCaps;
        public short NumberOutputDataIndices;
        public short NumberFeatureButtonCaps;
        public short NumberFeatureValueCaps;
        public short NumberFeatureDataIndices;

    }





    // Individual Food/Drink Item Status Listing:
    // 0   Order Taken
    // 1   Hold
    // 2   Sent to Kitchen/Bar
    // 3   Ready For Delivery
    // 4   Delivered


    // Table Status Listing:   ??????
    // 0   Not Available
    // 1   Available for Seating
    // 2   Sat
    // 3   Food Ordered
    // 4   Food Ready
    // 6   Food Delivered
    // 7   Check Down





    internal partial struct OverrideSystemCode
    {

        private int _voidItem;
        private int _forcePrice;
        private int _compItem;
        private int _taxExempt;
        private int _reprintCheck;
        private int _reprintOrder;
        private int _reopenCheck;
        private int _voidCheck;
        private int _adjustPayment;
        private int _assignComps;
        private int _assignGratuity;
        private int _transferItem;
        private int _transferCheck;
        private int _reprintCredit;


        internal int VoidItem
        {
            get
            {
                return _voidItem;
            }
            set
            {
                _voidItem = value;
            }
        }

        internal int ForcePrice
        {
            get
            {
                return _forcePrice;
            }
            set
            {
                _forcePrice = value;
            }
        }

        internal int CompItem
        {
            get
            {
                return _compItem;
            }
            set
            {
                _compItem = value;
            }
        }

        internal int TaxExempt
        {
            get
            {
                return _taxExempt;
            }
            set
            {
                _taxExempt = value;
            }
        }

        internal int ReprintCheck
        {
            get
            {
                return _reprintCheck;
            }
            set
            {
                _reprintCheck = value;
            }
        }

        internal int ReprintOrder
        {
            get
            {
                return _reprintOrder;
            }
            set
            {
                _reprintOrder = value;
            }
        }

        internal int ReopenCheck
        {
            get
            {
                return _reopenCheck;
            }
            set
            {
                _reopenCheck = value;
            }
        }

        internal int VoidCheck
        {
            get
            {
                return _voidCheck;
            }
            set
            {
                _voidCheck = value;
            }
        }

        internal int AdjustPayment
        {
            get
            {
                return _adjustPayment;
            }
            set
            {
                _adjustPayment = value;
            }
        }

        internal int AssignComps
        {
            get
            {
                return _assignComps;
            }
            set
            {
                _assignComps = value;
            }
        }

        internal int AssignGratuity
        {
            get
            {
                return _assignGratuity;
            }
            set
            {
                _assignGratuity = value;
            }
        }

        internal int TransferItem
        {
            get
            {
                return _transferItem;
            }
            set
            {
                _transferItem = value;
            }
        }

        internal int TransferCheck
        {
            get
            {
                return _transferCheck;
            }
            set
            {
                _transferCheck = value;
            }
        }

        internal int ReprintCredit
        {
            get
            {
                return _reprintCredit;
            }
            set
            {
                _reprintCredit = value;
            }
        }


    }




}