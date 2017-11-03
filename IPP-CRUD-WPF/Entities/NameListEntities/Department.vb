
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class DepartmentCRUD


		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub DepartmentAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Department for Add
			Dim department As Department = QBOHelper.CreateDepartment(qboContextoAuth)
			'Adding the Department
			Dim added As Department = Helper.Add(Of Department)(qboContextoAuth, department)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub DepartmentFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			DepartmentAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Department using FindAll
			Dim departments As List(Of Department) = Helper.FindAll(Of Department)(qboContextoAuth, New Department(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub DepartmentFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Department for Adding
			Dim department As Department = QBOHelper.CreateDepartment(qboContextoAuth)
			'Adding the Department
			Dim added As Department = Helper.Add(Of Department)(qboContextoAuth, department)
			Dim found As Department = Helper.FindById(Of Department)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub DepartmentUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Department for Adding
			Dim department As Department = QBOHelper.CreateDepartment(qboContextoAuth)
			'Adding the Department
			Dim added As Department = Helper.Add(Of Department)(qboContextoAuth, department)
			'Change the data of added entity
			Dim changed As Department = QBOHelper.UpdateDepartment(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Department = Helper.Update(Of Department)(qboContextoAuth, changed)
			'Verify the updated Department
		End Sub


		Public Sub DepartmentSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Department for Adding
			Dim department As Department = QBOHelper.CreateDepartment(qboContextoAuth)
			'Adding the Department
			Dim added As Department = Helper.Add(Of Department)(qboContextoAuth, department)
			'Change the data of added entity
			Dim changed As Department = QBOHelper.UpdateDepartmentSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Department = Helper.Update(Of Department)(qboContextoAuth, changed)
			'Verify the updated Department
		End Sub

		#End Region





		#Region "CDC Operations"


		Public Sub DepartmentCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			DepartmentAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Department using CDC
			Dim entities As List(Of Department) = Helper.CDC(qboContextoAuth, New Department(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub DepartmentBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Department = Helper.FindOrAdd(qboContextoAuth, New Department())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateDepartment(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateDepartment(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Department")

			'batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Department)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub DepartmentQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Department)(qboContextoAuth)
			Dim existing As Department = Helper.FindOrAdd(Of Department)(qboContextoAuth, New Department())
        Dim test As List(Of Department) = entityQuery.ExecuteIdsQuery("SELECT * FROM Department where Id='" + existing.Id + "'").ToList '(Of Department)()
    End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub DepartmentAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Department for Add
			Dim entity As Department = QBOHelper.CreateDepartment(qboContextoAuth)

			Dim added As Department = Helper.AddAsync(Of Department)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub DepartmentRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			DepartmentAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Department using FindAll
			Helper.FindAllAsync(Of Department)(qboContextoAuth, New Department())
		End Sub

		#End Region



		#Region "Update Operation"


		Public Sub DepartmentUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Department for Adding
			Dim entity As Department = QBOHelper.CreateDepartment(qboContextoAuth)
			'Adding the Department
			Dim added As Department = Helper.Add(Of Department)(qboContextoAuth, entity)

			'Update the Department
			Dim updated As Department = QBOHelper.UpdateDepartment(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Department = Helper.UpdateAsync(Of Department)(qboContextoAuth, updated)

		End Sub


		Public Sub DepartmentSparseUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Department for Adding
			Dim entity As Department = QBOHelper.CreateDepartment(qboContextoAuth)
			'Adding the Department
			Dim added As Department = Helper.Add(Of Department)(qboContextoAuth, entity)

			'Update the Department
			Dim updated As Department = QBOHelper.UpdateDepartmentSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Call the service
			Dim updatedReturned As Department = Helper.UpdateAsync(Of Department)(qboContextoAuth, updated)

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
