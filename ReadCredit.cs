using System;
using System.Runtime.InteropServices;
using System.Text;
using DataSet_Builder;



public partial class ReadCredit : IDisposable
{

    // Dim auth As New TStream


    // HID device
    private const short MagtekVendorID = 2049;        // 801 (this is the Hex VendorID)
    private const short IDTechVendorID = 2765;
    // Const KanecalVendorID As Short = 2765
    // Const MyProductID As Short = 2
    // Const IDTechProductID As Short = 1280
    internal bool myDeviceDetected;
    internal string myDevicePathName;
    // Friend myDevice As IDataReader
    internal int ReadHandle;
    private int EventObject;


    private HIDD_ATTRIBUTES deviceAttributes;
    private string devicePathName;
    private IntPtr deviceInfoSet;
    private SP_DEVICE_INTERFACE_DATA myDeviceInterfaceData;
    private SP_DEVICE_INTERFACE_DETAIL_DATA myDeviceInterfaceDetailData;
    private int HIDHandle;
    private string vbNullString = null;

    private bool lastDevice = false;
    private int result;
    private bool bResult;
    private int MemberIndex;
    private int m_lBufferSize;
    private SECURITY_ATTRIBUTES security;
    private Guid HidGuid;
    private HIDP_CAPS Capabilities;
    private OVERLAPPED HIDOverlapped;
    private IntPtr PreparsedData;

    public const short HidP_Input = 0;

    private bool cardSwiped;

    private int NumberOfBytesRead;
    // Allocate a buffer for the report.
    // Byte 0 is the report ID.
    private byte[] ReadBuffer;

    internal DataSet_Builder.Payment newPayment;

    private string _payName;
    private bool _isNewTab = false;
    private string _activeScreen;
    // OPTIONS:
    // Login
    // OrderScreen
    // CloseCheck
    // SeatingTab
    // TabEnterScreen

    private bool _giftAddingAmount;

    internal string PayName
    {
        get
        {
            return _payName;
        }
        set
        {
            _payName = value;
        }
    }

    public bool IsNewTab
    {
        get
        {
            return _isNewTab;
        }
        set
        {
            _isNewTab = value;
        }
    }

    public string ActiveScreen
    {
        get
        {
            return _activeScreen;
        }
        set
        {
            _activeScreen = value;
        }
    }

    public bool GiftAddingAmount
    {
        get
        {
            return _giftAddingAmount;
        }
        set
        {
            _giftAddingAmount = value;
        }
    }

    private System.ComponentModel.IContainer components;

    public event CardReadSuccessfulEventHandler CardReadSuccessful;

    public delegate void CardReadSuccessfulEventHandler(ref DataSet_Builder.Payment newPayment);
    public event CardReadFailedEventHandler CardReadFailed;

    public delegate void CardReadFailedEventHandler();
    public event EnteringTabNameInKeyboardEventHandler EnteringTabNameInKeyboard;

    public delegate void EnteringTabNameInKeyboardEventHandler(string tabName);
    public event ManagementCardSwipedEventHandler ManagementCardSwiped;

    public delegate void ManagementCardSwipedEventHandler(DataSet_Builder.Employee emp);
    public event RetruningGiftAddingAmountToFalseEventHandler RetruningGiftAddingAmountToFalse;

    public delegate void RetruningGiftAddingAmountToFalseEventHandler();


    public ReadCredit(bool _isNewTabBoolean)
    {
        // MyBase.new()

        // testing
        // _isNewTabBoolean = True

        _isNewTab = _isNewTabBoolean;
        CloseManualAuth_Load();
    }

    // Form overrides dispose to clean up the component list.
    protected void Dispose()
    {

        if (components is not null)
        {
            components.Dispose();
            GC.SuppressFinalize(this);
        }
        // Me.Dispose()
    }

    void IDisposable.Dispose() => Dispose();


    internal void CloseManualAuth_Load() // (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    {

        // Me.tmrCardRead = New System.Windows.Forms.Timer
        // AddHandler tmrCardRead.Tick, AddressOf tmrCardRead_Tick
        tmrCardRead.Interval = 500;  // 100  '
        // tmrCardRead.Start()

        HidGuid = Guid.Empty;
        lastDevice = false;

        security.lpSecurityDescriptor = 0;
        security.bInheritHandle = Conversions.ToInteger(true);
        security.nLength = Len(security);

        result = HidD_GetHidGuid(ref HidGuid);
        // MsgBox("HidGuid:  " & HidGuid.ToString)

        deviceInfoSet = SetupDiGetClassDevs(ref HidGuid, ref vbNullString, 0, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);       // 16) '2 Or 16)
        // MsgBox("deviceInfoSet:  " & deviceInfoSet.ToString)

        MemberIndex = 0;

        do
        {
            myDeviceInterfaceData.cbSize = Marshal.SizeOf(myDeviceInterfaceData);

            result = SetupDiEnumDeviceInterfaces(deviceInfoSet, 0, ref HidGuid, MemberIndex, ref myDeviceInterfaceData);
            if (result == 0)
                lastDevice = true;
            // MsgBox("myDeviceInterfaceData:   " & myDeviceInterfaceData.InterfaceClassGuid.ToString)


            if (result != 0)
            {

                bResult = SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref myDeviceInterfaceData, IntPtr.Zero, 0, ref m_lBufferSize, IntPtr.Zero);

                // store the structure data
                myDeviceInterfaceDetailData.cbSize = Marshal.SizeOf(myDeviceInterfaceDetailData);

                var detailDataBuffer = Marshal.AllocHGlobal(m_lBufferSize);
                // stores cbSize in first 4 bytes of array
                Marshal.WriteInt32(detailDataBuffer, 4 + Marshal.SystemDefaultCharSize);

                bResult = SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref myDeviceInterfaceData, detailDataBuffer, m_lBufferSize, ref m_lBufferSize, IntPtr.Zero);

                var pDevicePathName = new IntPtr(detailDataBuffer.ToInt32() + 4);
                devicePathName = Marshal.PtrToStringAuto(pDevicePathName);
                // MsgBox("ProductID:  " & deviceAttributes.ProductID)
                // MsgBox("DevicePathName:   " & devicePathName)

                Marshal.FreeHGlobal(detailDataBuffer);   // free's memory allocated earlier

                security.lpSecurityDescriptor = 0;
                security.bInheritHandle = Conversions.ToInteger(true);
                security.nLength = Len(security);

                HIDHandle = CreateFile(ref devicePathName, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, ref security, OPEN_EXISTING, 0, 0);
                // MsgBox("HIDHandle:  " & HIDHandle)

                deviceAttributes.Size = Marshal.SizeOf(deviceAttributes);

                result = HidD_GetAttributes(HIDHandle, ref deviceAttributes);

                // the Hex Values for VendorID give a "56A" on the tablet PC
                // so we must use the true values
                // MsgBox(deviceAttributes.VendorID.ToString)
                // MsgBox(deviceAttributes.ProductID.ToString)

                if (deviceAttributes.VendorID == MagtekVendorID | deviceAttributes.VendorID == IDTechVendorID) // And deviceAttributes.ProductID = MyProductID Then
                {
                    myDeviceDetected = true;
                }
                // If (Hex(deviceAttributes.VendorID) = MyVendorID) And (Hex(deviceAttributes.ProductID) = MyProductID) Then
                // myDeviceDetected = True
                // End If

            }

            MemberIndex += 1;
        }

        while (!(lastDevice == true | myDeviceDetected == true));

        result = SetupDiDestroyDeviceInfoList(deviceInfoSet);

        if (myDeviceDetected == true)
        {
            // FindtheHid = True
            // Dim result As Boolean
            // result = RegisterHidNotification(devicePathName)
            // ADD    registerHidNotification

            GetDeviceCapabilities();

            ReadHandle = CreateFile(ref devicePathName, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, ref security, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, 0);

            PrepareForOverlappedTransfer();
            // tmrCardRead.Enabled = True

            tmrCardRead.Tick += tmrCardRead_Tick;
            tmrCardRead.Start();

            // ***
            ReadBuffer = new byte[Capabilities.InputReportByteLength];

        }

    }

    internal void tmrCardRead_Tick(object sender, EventArgs e) // Handles tmrCardRead.Tick
    {

        ReadAndWriteToDevice();

    }

    internal void ReadAndWriteToDevice()
    {
        // testCounter += 1
        try
        {
            ReadReport();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);

        }

    }

    private void GetDeviceCapabilities()
    {

        // ******************************************************************************
        // HidD_GetPreparsedData
        // Returns: a pointer to a buffer containing information about the device's capabilities.
        // Requires: A handle returned by CreateFile.
        // There's no need to access the buffer directly,
        // but HidP_GetCaps and other API functions require a pointer to the buffer.
        // ******************************************************************************

        var ppData = new byte[30];
        string ppDataString;

        // Preparsed Data is a pointer to a routine-allocated buffer.
        result = HidD_GetPreparsedData(HIDHandle, ref PreparsedData);

        // Copy the data at PreparsedData into a byte array.

        try
        {
            ppDataString = Convert.ToBase64String(ppData);
        }
        catch (ArgumentNullException exp)
        {
            Interaction.MsgBox("PreparsedData array is null.");
            return;
        }

        // ******************************************************************************
        // HidP_GetCaps
        // Find out the device's capabilities.
        // For standard devices such as joysticks, you can find out the specific
        // capabilities of the device.
        // For a custom device where the software knows what the device is capable of,
        // this call is unneeded.
        // Requires: The pointer to a buffer containing the information.
        // The pointer is returned by HidD_GetPreparsedData.
        // Returns: a Capabilites structure containing the information.
        // ******************************************************************************

        result = HidP_GetCaps(PreparsedData, ref Capabilities);

        // ******************************************************************************
        // HidP_GetValueCaps
        // Returns a buffer containing an array of HidP_ValueCaps structures.
        // Each structure defines the capabilities of one value.
        // This application doesn't use this data.
        // ******************************************************************************

        // This is a guess. The byte array holds the structures.
        var ValueCaps = new byte[1024];

        result = HidP_GetValueCaps(HidP_Input, ref ValueCaps[0], ref Capabilities.NumberInputValueCaps, PreparsedData);

        // Call DisplayResultOfAPICall("HidP_GetValueCaps")

        // To use this data, copy the ValueCaps byte array into an array of structures.

        // Free the buffer reserved by HidD_GetPreparsedData
        result = HidD_FreePreparsedData(ref PreparsedData);
        // Call DisplayResultOfAPICall("HidD_FreePreparsedData")

    }


    private void PrepareForOverlappedTransfer()
    {

        // ******************************************************************************
        // CreateEvent
        // Creates an event object for the overlapped structure used with ReadFile.
        // Requires a security attributes structure or null,
        // Manual Reset = False (The system automatically resets the state to nonsignaled 
        // after a waiting thread has been released.),
        // Initial state = True (signaled),
        // and event object name (optional)
        // Returns a handle to the event object.
        // ******************************************************************************

        // Dim tempEvent As Integer
        // tempEvent = EventObject
        // EventObject = CreateEvent(tempEvent, CInt(False), CInt(True), "")

        if (EventObject == 0)
        {
            string arglpName = "";
            EventObject = ReadCredit.CreateEvent(0, Conversions.ToInteger(false), Conversions.ToInteger(true), ref arglpName);
        }

        // Set the members of the overlapped structure.
        HIDOverlapped.Offset = 0;
        HIDOverlapped.OffsetHigh = 0;
        HIDOverlapped.hEvent = EventObject;
        // result = Nothing

    }

    private void ReadReport()
    {
        // Read data from the device.

        // Dim Count As Object
        // Dim NumberOfBytesRead As Integer
        // Allocate a buffer for the report.
        // Byte 0 is the report ID.
        // ReDim ReadBuffer(Capabilities.InputReportByteLength - 1) ' As Byte
        // Dim UBoundReadBuffer As Short

        // ******************************************************************************
        // ReadFile
        // Returns: the report in ReadBuffer.
        // Requires: a device handle returned by CreateFile
        // (for overlapped I/O, CreateFile must be called with FILE_FLAG_OVERLAPPED),
        // the Input report length in bytes returned by HidP_GetCaps,
        // and an overlapped structure whose hEvent member is set to an event object.
        // ******************************************************************************

        // Dim nonHexValue As String
        // Dim ByteValue As String
        // The ReadBuffer array begins at 0, so subtract 1 from the number of bytes.

        // ***      ReDim ReadBuffer(Capabilities.InputReportByteLength - 1)
        // Scroll to the bottom of the list box.
        // lstResults.SelectedIndex = lstResults.Items.Count - 1

        // Do an overlapped ReadFile.
        // The function returns immediately, even if the data hasn't been received yet.
        result = ReadFile(ReadHandle, ref ReadBuffer[0], Capabilities.InputReportByteLength, ref NumberOfBytesRead, ref HIDOverlapped);





        // ******************************************************************************
        // WaitForSingleObject
        // Used with overlapped ReadFile.
        // Returns when ReadFile has received the requested amount of data or on timeout.
        // Requires an event object created with CreateEvent
        // and a timeout value in milliseconds.
        // ******************************************************************************
        result = WaitForSingleObject(EventObject, 80);   // 1000)    '30000 is a 30 second timeout


        // Find out if ReadFile completed or timeout.
        switch (result)
        {
            case var @case when @case == WAIT_OBJECT_0:
                {

                    // ReadFile has completed
                    // Beep()
                    // PrepareForOverlappedTransfer()
                    // Exit Select

                    int track2Length;
                    int count;

                    newPayment = new DataSet_Builder.Payment();

                    track2Length = ReadBuffer[4] + ReadBuffer[5];
                    // Track1(4)    Track2(5)
                    var ascii = new ASCIIEncoding();
                    char ByteChar;
                    var nextTrack2Count = default(int);
                    var makeLowerCase = default(bool);
                    var spaceFoundInName = default(bool);
                    var possibleFirstName = default(string);
                    var noFirstName = default(bool);
                    string firstNameString;
                    var lastChrSpace = default(bool);

                    try
                    {
                        var loopTo = Information.UBound(ReadBuffer);
                        for (count = 0; count <= loopTo; count++) // 8 To UBound(ReadBuffer) ' 336
                        {
                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "%") // Track1 start
                            {
                                newPayment.Track1Found = true;
                                nextTrack2Count = count + 2;
                                break;
                            }
                        }

                        // AccountNumber from Track1
                        var loopTo1 = Information.UBound(ReadBuffer);
                        for (count = nextTrack2Count; count <= loopTo1; count++) // 336
                        {
                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "^")
                            {
                                nextTrack2Count = count + 1;
                                break;
                            }
                            newPayment.Track1 = newPayment.Track1 + Strings.Chr(ReadBuffer[count]);
                            // newPayment.AccountNumber = newPayment.AccountNumber & Chr(ReadBuffer(count))
                        }

                        // For count = 8 To UBound(ReadBuffer) ' 336
                        // If Chr(ReadBuffer(count)) = "^" Then
                        // nextTrack2Count = count + 1
                        // Exit For
                        // End If
                        // Next

                        newPayment.Name = " ";     // place the space between names first

                        // lastName
                        var loopTo2 = Information.UBound(ReadBuffer);
                        for (count = nextTrack2Count; count <= loopTo2; count++) // 336
                        {
                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "^")
                            {
                                // this is the end of the name, so looks like no first name
                                // We only get here if there was no seperator "/" and name is all together
                                nextTrack2Count = count + 1;
                                noFirstName = true;
                                break;
                            }
                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "/")
                            {
                                nextTrack2Count = count + 1;
                                break;
                            }

                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == " " & lastChrSpace == true)
                            {
                            }

                            else
                            {
                                if (makeLowerCase == true)
                                {
                                    newPayment.LastName = newPayment.LastName + Strings.Chr(ReadBuffer[count]).ToString().ToLower();
                                }
                                else
                                {
                                    newPayment.LastName = newPayment.LastName + Strings.Chr(ReadBuffer[count]);
                                    makeLowerCase = true;
                                }
                                // 2 if thens below in case there is no seperator between first and last name
                                if (spaceFoundInName == true)
                                {
                                    possibleFirstName = possibleFirstName + Strings.Chr(ReadBuffer[count]);
                                }
                            }

                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == " ")
                            {
                                possibleFirstName = "";
                                spaceFoundInName = true;
                                lastChrSpace = true;
                            }
                            else
                            {
                                lastChrSpace = false;
                            }
                        }
                        if (newPayment.LastName is null) // .Length = 0 Then
                        {
                            // this will be the default last name
                            newPayment.LastName = "Customer";
                        }
                        if (newPayment.LastName.Length == 0)
                        {
                            // just in case, will never be true
                            newPayment.LastName = "Customer";
                        }
                        newPayment.Name = newPayment.LastName;
                        makeLowerCase = false;


                        // FirstName
                        if (noFirstName == true)
                        {
                            newPayment.FirstName = possibleFirstName;
                        }
                        else
                        {
                            var loopTo3 = Information.UBound(ReadBuffer);
                            for (count = nextTrack2Count; count <= loopTo3; count++) // 336
                            {
                                if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "^")
                                {
                                    nextTrack2Count = count + 1;
                                    break;
                                }
                                if (!(Conversions.ToString(Strings.Chr(ReadBuffer[count])) == " "))
                                {
                                    // 444        firstNameString = firstNameString & Chr(ReadBuffer(count))
                                    if (makeLowerCase == true)
                                    {
                                        newPayment.FirstName = newPayment.FirstName + Strings.Chr(ReadBuffer[count]).ToString().ToLower();
                                    }
                                    else
                                    {
                                        newPayment.FirstName = newPayment.FirstName + Strings.Chr(ReadBuffer[count]);
                                        makeLowerCase = true;
                                    }
                                }
                            }
                        }

                        if (newPayment.FirstName is null)
                        {
                            // this will be the default last name
                            newPayment.FirstName = "";
                        }
                        // If newPayment.FirstName.Length = 0 Then
                        // newPayment.FirstName = ""
                        // End If

                        firstNameString = newPayment.FirstName;
                        if (firstNameString.Length > 0)
                        {
                            newPayment.Name = newPayment.Name + ", " + firstNameString;
                        }

                        // ***************   end of Track 1, ends at ?

                        // finds the start of Track2 info, starts at ;
                        var loopTo4 = Information.UBound(ReadBuffer);
                        for (count = nextTrack2Count; count <= loopTo4; count++) // 336
                        {
                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == ";")
                            {
                                nextTrack2Count = count + 1;
                                break;
                            }
                        }

                        // AccountNumber
                        var loopTo5 = Information.UBound(ReadBuffer);
                        for (count = nextTrack2Count; count <= loopTo5; count++) // 336
                        {
                            newPayment.Track2 = newPayment.Track2 + Strings.Chr(ReadBuffer[count]);
                            // this will add the =

                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "=")
                            {
                                nextTrack2Count = count + 1;
                                break;
                            }
                            newPayment.AccountNumber = newPayment.AccountNumber + Strings.Chr(ReadBuffer[count]);
                        }

                        // ExpYear
                        var loopTo6 = nextTrack2Count + 1;
                        for (count = nextTrack2Count; count <= loopTo6; count++)  // reads 2 characters
                        {
                            newPayment.Track2 = newPayment.Track2 + Strings.Chr(ReadBuffer[count]);
                            newPayment.ExpDate = newPayment.ExpDate + Strings.Chr(ReadBuffer[count]);
                        }
                        nextTrack2Count += 2;

                        // ExpMonth
                        var monthString = default(string);
                        var loopTo7 = nextTrack2Count + 1;
                        for (count = nextTrack2Count; count <= loopTo7; count++)  // reads 2 characters
                        {
                            newPayment.Track2 = newPayment.Track2 + Strings.Chr(ReadBuffer[count]);
                            monthString = monthString + Strings.Chr(ReadBuffer[count]);
                        }
                        nextTrack2Count += 2;

                        newPayment.ExpDate = monthString + newPayment.ExpDate;

                        // 444     If ValidateExpDate(newPayment.ExpDate) = False Then Exit Sub

                        var loopTo8 = Information.UBound(ReadBuffer);
                        for (count = nextTrack2Count; count <= loopTo8; count++) // 336
                        {

                            if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "?")
                            {
                                if (!(track2Length == 0))
                                {

                                    cardSwiped = true;
                                    // tmrCardRead.Dispose()
                                    // RemoveHandler tmrCardRead.Tick, AddressOf tmrCardRead_Tick
                                    // tmrCardRead.Stop()

                                    newPayment.Swiped = true;


                                    string tabString;

                                    // 444              If IsNewTab = True Then
                                    tabString = newPayment.LastName;
                                    if (newPayment.FirstName.Length > 0)
                                    {
                                        tabString = tabString + ", " + newPayment.FirstName;
                                    }

                                    EnteringTabNameInKeyboard?.Invoke(tabString);
                                    // 444End If

                                    try
                                    {
                                        SuccessfulCardReadProcessing(ref newPayment, tabString);
                                    }
                                    // RaiseEvent CardReadSuccessful(newPayment)
                                    catch (Exception ex)
                                    {
                                        CardReadFailed?.Invoke();
                                        CancelIo(ReadHandle);
                                        return;
                                    }
                                }

                                else
                                {
                                    Interaction.MsgBox("Card Swipe does Not Read Correctly");
                                }
                                // result = CloseHandle(HIDHandle)
                                // result = CloseHandle(ReadHandle)
                                // PrepareForOverlappedTransfer()
                                // result = 258
                                break;
                            }
                            newPayment.Track2 = newPayment.Track2 + Strings.Chr(ReadBuffer[count]);
                        }
                        if (track2Length == 0)
                        {
                            Interaction.MsgBox("Card Swipe does Not Read Correctly");
                        }
                    }

                    // MsgBox("ReadFile completed successfully.")
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.Message);
                        // RemoveHandler tmrCardRead.Tick, AddressOf tmrCardRead_Tick
                        // tmrCardRead.Stop()
                        // ReadBuffer = Nothing
                        CardReadFailed?.Invoke();
                        CancelIo(ReadHandle);    // 444

                        // PrepareForOverlappedTransfer()
                        // result = Nothing
                        return;

                    }

                    break;
                }

            case var case1 when case1 == WAIT_TIMEOUT:
                {

                    // result = CloseHandle(HIDHandle)
                    // result = CloseHandle(ReadHandle)
                    // ReadHandle = CreateFile(devicePathName, GENERIC_READ Or GENERIC_WRITE, FILE_SHARE_READ Or FILE_SHARE_WRITE, security, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, 0)
                    // PrepareForOverlappedTransfer()
                    // CancelIo()
                    result = CancelIo(ReadHandle);
                    break;
                }

            default:
                {

                    CancelIo(ReadHandle);
                    break;
                }

        }

    }

    private void SuccessfulCardReadProcessing(ref Payment newPayment, string tabString)
    {

        if (newPayment.Track2.Length > 0)
        {
            newPayment.SwipeCode = CryOutloud.Encrypt(newPayment.Track2, "test");
            if (newPayment.SwipeCode.Length > 20)
            {
                newPayment.SwipeCode = newPayment.SwipeCode.ToString.Substring(0, 20);
            }
        }

        // we do this so managers can open a Tab under their credit card 
        // under Seating_EnterTab
        if (IsNewTab == false)
        {
            foreach (Employee emp in SwipeCodeEmployees)
            {
                if (emp.SwipeCode == newPayment.SwipeCode)
                {
                    ManagementCardSwiped?.Invoke(emp);
                    return;
                }
            }
        }

        newPayment.PaymentTypeName = GenerateOrderTables.DetermineCreditCardName(newPayment.AccountNumber);
        if (newPayment.PaymentTypeName == "")
        {
            // need to also determine if management swipe card
            // RaiseEvent CardReadFailed()
            Interaction.MsgBox("Card Type is not recognized");
            CancelIo(ReadHandle);
            return;
        }
        if (ValidateExpDate(newPayment.ExpDate) == false)
        {
            // only attempt validate if this is a paying credit card
            return;
        }

        if (IsNewTab == true)
        {
            if (OpenNewTab(-999, tabString) == false)
            {
                CardReadFailed?.Invoke();
                CancelIo(ReadHandle);
                return;
            }
        }

        if (currentTable is not null)
        {
            if (!(ActiveScreen == "Login") & currentTable.ExperienceNumber != default)  // Not ActiveScreen = "TableScreen" And 
            {
                try
                {
                    newPayment.experienceNumber = currentTable.ExperienceNumber;
                    newPayment.PaymentTypeID = DetermineCreditCardID(newPayment.PaymentTypeName);

                    newPayment.SpiderAcct = CreateAccountNumber(newPayment); // .LastName, newPayment.AccountNumber)
                    GenerateOrderTables.CreateTabAcctPlaceInExperience(newPayment);
                    if (newPayment.PaymentTypeName == "MPS Gift")
                    {
                        // this may change PaymentTypeID to -97
                        PopulateGiftPaymentInfo();
                    }

                    // payment collection is for loyalty and gift card (2 seperate things)
                    GenerateOrderTables.AddPaymentToCollection(newPayment); // was not in CustomerCardRead in Tab_Screen
                    CardReadSuccessful?.Invoke(ref newPayment);
                }
                catch (Exception ex)
                {
                    CardReadFailed?.Invoke();
                    CancelIo(ReadHandle);
                }
            }
        }


    }

    private void PopulateGiftPaymentInfo()
    {
        string authStatus;

        // we are checking balance on all Gift Cards
        // we have not created a DataRow, so everything is different (must be done w/ newPayment)
        if (!(newPayment.PaymentTypeID == -97))
        {
            // if -97, the status of this gift card already determined
            // authStatus = DetermineGiftCardBalance(newPayment)
            authStatus = GenerateOrderTables.GiftCardTransaction(default, newPayment, "Balance");
            if (authStatus == "MPS Gift Card")
            {
                Interaction.MsgBox(authStatus);
                return;
            }
            if (authStatus == "Account Not Issued")
            {
                newPayment.PaymentTypeID = -97;
                newPayment.PaymentTypeName = "Issue Gift";
                // we need to make sure the payment amount is negative
                // enter amount of gift on number pad
                newPayment.Purchase = -50.0d;
                newPayment.PaymentFlag = "Issue";
            }
            // If newPayment.Balance < newPayment.Purchase Then
            // newPayment.Purchase = newPayment.Balance
            // MsgBox("Balance remaining on card before purchase: " & newPayment.Balance)
            // otherwise defaults to purchase
            // End If

            else if (_giftAddingAmount == true)
            {
                // this is Return, which is adding more money back on Gift Card
                // we record same as issue
                newPayment.PaymentTypeID = -97;
                newPayment.PaymentTypeName = "Increase Gift";
                newPayment.PaymentFlag = "Issue";
                if (newPayment.Purchase > 0)
                {
                    newPayment.Purchase *= -1;
                }
                RetruningGiftAddingAmountToFalse?.Invoke(); // ReturnGiftCardAddToFalse()
            }
            else
            {
                newPayment.PaymentFlag = "Gift";
            }
        }

    }

    public void Shutdown()
    {
        // tmrCardRead.Stop()
        // RemoveHandler tmrCardRead.Tick, AddressOf tmrCardRead_Tick

        result = CancelIo(ReadHandle);
        result = CloseHandle(HIDHandle);
        result = CloseHandle(ReadHandle);
        // CancelIo(ReadHandle)
        // CloseHandle(HIDHandle)
        // '      CloseHandle(ReadHandle)
        // UnregisterDeviceNotification(deviceNotificationHandle)
        HidD_FreePreparsedData(ref PreparsedData);

        // Finalize()

    }

    ~ReadCredit()
    {

    }

    [DllImport("hid.dll")]
    public static extern int HidD_GetAttributes(int HidDeviceObject, ref HIDD_ATTRIBUTES Attributes);



    // Declared as a function for consistency,
    // but returns nothing. (Ignore the returned value.)
    [DllImport("hid.dll")]
    public static extern int HidD_GetHidGuid(ref Guid HidGuid);



    [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, int hwndParent, int Flags);





    [DllImport("setupapi.dll")]
    public static extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);



    [DllImport("setupapi.dll")]
    public static extern int SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, int DeviceInfoData, ref Guid InterfaceClassGuid, int MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);






    [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
    public static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);







    [DllImport("kernel32")]
    public static extern int CancelIo(int hFile);


    [DllImport("kernel32")]
    public static extern int CloseHandle(int hObject);



    [DllImport("kernel32", CharSet = CharSet.Auto)]
    public static extern int CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, ref SECURITY_ATTRIBUTES lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);








    [DllImport("kernel32")]
    public static extern int ReadFile(int hFile, ref byte lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, ref OVERLAPPED lpOverlapped);






    [DllImport("kernel32")]
    public static extern int WaitForSingleObject(int hHandle, int dwMilliseconds);



    [DllImport("kernel32", CharSet = CharSet.Auto)]
    public static extern int CreateEvent(int SecurityAttributes, int bManualReset, int bInitialState, string lpName);




    [DllImport("hid.dll")]
    public static extern int HidD_GetPreparsedData(int HidDeviceObject, ref IntPtr PreparsedData);




    [DllImport("hid.dll")]
    public static extern int HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);



    [DllImport("hid.dll")]
    public static extern int HidP_GetValueCaps(short ReportType, ref byte ValueCaps, ref short ValueCapsLength, IntPtr PreparsedData);





    [DllImport("hid.dll")]
    public static extern int HidD_FreePreparsedData(ref IntPtr PreparsedData);


    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool UnregisterDeviceNotification(IntPtr Handle);


}