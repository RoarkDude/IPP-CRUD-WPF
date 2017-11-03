
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class EmployeeCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub EmployeeAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Employee for Add
			Dim employee As Employee = QBOHelper.CreateEmployee(qboContextoAuth)
			'Adding the Employee
			Dim added As Employee = Helper.Add(Of Employee)(qboContextoAuth, employee)


		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub EmployeeFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			Dim employee As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())

			'Retrieving the Employee using FindAll
			Dim employees As List(Of Employee) = Helper.FindAll(Of Employee)(qboContextoAuth, New Employee(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub EmployeeFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Employee for Adding
			Dim employee As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())
			Dim found As Employee = Helper.FindById(Of Employee)(qboContextoAuth, employee)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub EmployeeUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			Dim employee As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())
			'Change the data of added entity
			Dim changed As Employee = QBOHelper.UpdateEmployee(qboContextoAuth, employee)
			'Update the returned entity data
			Dim updated As Employee = Helper.Update(Of Employee)(qboContextoAuth, changed)
			'Verify the updated Employee
		End Sub


		Public Sub EmployeeSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			Dim employee As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())
			'Change the data of added entity
			Dim changed As Employee = QBOHelper.SparseUpdateEmployee(qboContextoAuth, employee.Id, employee.SyncToken)
			'Update the returned entity data
			Dim updated As Employee = Helper.Update(Of Employee)(qboContextoAuth, changed)
			'Verify the updated Employee
		End Sub

		#End Region



		#Region "CDC Operations"


		Public Sub EmployeeCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			Dim employee As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())

			'Retrieving the Employee using CDC
			Dim entities As List(Of Employee) = Helper.CDC(qboContextoAuth, New Employee(), DateTime.Now.AddDays(-100))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub EmployeeBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateEmployee(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateEmployee(qboContextoAuth, existing))

			'batchEntries.Add(OperationEnum.query, "select * from Employee");

			'batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Employee)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"


		Public Sub EmployeeQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Employee)(qboContextoAuth)
			Dim existing As Employee = Helper.FindOrAdd(Of Employee)(qboContextoAuth, New Employee())
        Dim test As List(Of Employee) = entityQuery.ExecuteIdsQuery("SELECT * FROM Employee where Id='" + existing.Id + "'").ToList '(Of Employee)()

    End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub EmployeeAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Employee for Add
			Dim entity As Employee = QBOHelper.CreateEmployee(qboContextoAuth)

			Dim added As Employee = Helper.AddAsync(Of Employee)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub EmployeeRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			Dim employee As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())

			'Retrieving the Employee using FindAll
			Helper.FindAllAsync(Of Employee)(qboContextoAuth, New Employee())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub EmployeeFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			Dim employee As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())

			'FindById and verify
			Helper.FindByIdAsync(Of Employee)(qboContextoAuth, employee)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub EmployeeUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			Dim employee As Employee = Helper.FindOrAdd(qboContextoAuth, New Employee())

			'Update the Employee
			Dim updated As Employee = QBOHelper.UpdateEmployee(qboContextoAuth, employee)
			'Call the service
			Dim updatedReturned As Employee = Helper.UpdateAsync(Of Employee)(qboContextoAuth, updated)

		End Sub

		#End Region



		#End Region

	End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
