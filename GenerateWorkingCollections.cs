using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataSet_Builder;

internal static partial class GenerateWorkingCollections
{


    internal static void AddEmployeeToCollections(ref Employee newemployee)
    {
        var alreadyOnFloor = default(bool);

        try
        {
            AddEmployeeToWorkingCollection(ref newemployee);

            if (newemployee.Bartender == true)
            {
                currentBartenders.Add(newemployee);
            }
            if (newemployee.Server == true)
            {
                currentServers.Add(newemployee);
            }
            if (newemployee.Manager == true)
            {
                currentManagers.Add(newemployee);
            }

            if (newemployee.Bartender == true | newemployee.Server == true | newemployee.Manager == true)
            {
                foreach (Employee emp in todaysFloorPersonnel)
                {
                    // checking for duplicates
                    if (emp.EmployeeID == newemployee.EmployeeID)
                    {
                        alreadyOnFloor = true;
                        break;
                    }
                }
                if (alreadyOnFloor == false)
                {
                    todaysFloorPersonnel.Add(newemployee);
                }
            }
        }
        catch (Exception ex)
        {

        }

    }

    internal static void RemoveEmployeeFromCollection(int empID)
    {
        var currentEmployee = default(Employee);

        foreach (Employee currentCurrentEmployee in workingEmployees)
        {
            currentEmployee = currentCurrentEmployee;
            if (currentEmployee.EmployeeID == empID)
            {
                break;
            }
        }

        try
        {
            if (currentEmployee.Bartender == true)
            {
                currentBartenders.Remove(currentEmployee);
            }
            if (currentEmployee.Server == true)
            {
                currentServers.Remove(currentEmployee);
            }
            if (currentEmployee.Manager == true)
            {
                currentManagers.Remove(currentEmployee);
            }

            if (currentEmployee.Bartender == true | currentEmployee.Server == true | currentEmployee.Manager == true)
            {
                // todaysFloorPersonnel.Remove(currentEmployee)
            }
            RemoveEmployeeFromWorkingCollection(ref currentEmployee);
        }
        catch (Exception ex)
        {

        }


    }

    internal static void AddEmployeeToSwipeCodeEmployeesEmployeeCollection(ref Employee newEmployee)
    {

        SwipeCodeEmployees.Add(newEmployee);

    }

    internal static void AddEmployeeToAllEmployeeCollection(ref Employee newEmployee)
    {

        AllEmployees.Add(newEmployee);

    }

    internal static void AddEmployeeToAllFloorCollection(ref Employee newEmployee)
    {

        allFloorPersonnel.Add(newEmployee);

    }

    internal static void AddEmployeeToSalariedEmployeeCollection(ref Employee newEmployee)
    {

        SalariedEmployees.Add(newEmployee);
        // 444      If Not newEmployee.EmployeeID = 6986 Then
        // currentManagers.Add(newEmployee)
        // End If

    }

    internal static void AddEmployeeToWorkingCollection(ref Employee newEmployee)
    {
        // _workingEMployees is a structure defined in term_Tahsc

        workingEmployees.Add(newEmployee);

    }

    internal static void RemoveEmployeeFromWorkingCollection(ref Employee currentEmployee)
    {
        // _workingEMployees is a structure defined in term_Tahsc

        workingEmployees.Remove(currentEmployee);

    }

    // this is different .. we only need this once
    // b/c working collections are the same on every terminal

    internal static void LogInEmployeesEnteredWhenBackUp222()
    {

        foreach (Employee currentEmployee in workingEmployees)
        {
            if (currentEmployee.dbUP == false & currentEmployee.ClockInReq == true)
            {
                try
                {
                    GenerateOrderTables.EnterEmployeeToLoginDataSet(currentEmployee);
                    currentEmployee.dbUP = true;
                }
                catch (Exception ex)
                {

                }

            }
        }

    }

}