
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class ClassCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub ClassAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Class for Add
			Dim class1 As [Class] = QBOHelper.CreateClass(qboContextoAuth)
			'Adding the Class
			Dim added As [Class] = Helper.Add(Of [Class])(qboContextoAuth, class1)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub ClassFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			ClassAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Class using FindAll
			Dim classes As List(Of [Class]) = Helper.FindAll(Of [Class])(qboContextoAuth, New [Class](), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub ClassFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Class for Adding
			Dim class1 As [Class] = QBOHelper.CreateClass(qboContextoAuth)
			'Adding the Class
			Dim added As [Class] = Helper.Add(Of [Class])(qboContextoAuth, class1)
			Dim found As [Class] = Helper.FindById(Of [Class])(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub ClassUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Class for Adding
			Dim class1 As [Class] = QBOHelper.CreateClass(qboContextoAuth)
			'Adding the Class
			Dim added As [Class] = Helper.Add(Of [Class])(qboContextoAuth, class1)
			'Change the data of added entity
			Dim changed As [Class] = QBOHelper.UpdateClass(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As [Class] = Helper.Update(Of [Class])(qboContextoAuth, changed)
			'Verify the updated Class
		End Sub


		Public Sub ClassSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Class for Adding
			Dim class1 As [Class] = QBOHelper.CreateClass(qboContextoAuth)
			'Adding the Class
			Dim added As [Class] = Helper.Add(Of [Class])(qboContextoAuth, class1)
			'Change the data of added entity
			Dim changed As [Class] = QBOHelper.SparseUpdateClass(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As [Class] = Helper.Update(Of [Class])(qboContextoAuth, changed)
			'Verify the updated Class
		End Sub

		#End Region

		#Region "Delete Operations"


		'Delete is Soft Delete for Name List entities- Update operation with Active=false


		#End Region

		#Region "CDC Operations"


		Public Sub ClassCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			ClassAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Class using FindAll
			Dim classes As List(Of [Class]) = Helper.CDC(qboContextoAuth, New [Class](), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub ClassBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As [Class] = Helper.FindOrAdd(qboContextoAuth, New [Class]())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateClass(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateClass(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Class")

			' batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of [Class])(qboContextoAuth, batchEntries)

		End Sub

		#End Region

		#Region "Query"

		Public Sub ClassQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of [Class])(qboContextoAuth)
			Dim existing As [Class] = Helper.FindOrAdd(Of [Class])(qboContextoAuth, New [Class]())
        Dim cl As List(Of [Class]) = entityQuery.ExecuteIdsQuery("SELECT * FROM Class where Id='" + existing.Id + "'").ToList '(Of [Class])()

    End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub ClassAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Class for Add
			Dim entity As [Class] = QBOHelper.CreateClass(qboContextoAuth)

			Dim added As [Class] = Helper.AddAsync(Of [Class])(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub ClassRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			ClassAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Class using FindAll
			Helper.FindAllAsync(Of [Class])(qboContextoAuth, New [Class]())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub ClassFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Class for Adding
			Dim entity As [Class] = QBOHelper.CreateClass(qboContextoAuth)
			'Adding the Class
			Dim added As [Class] = Helper.Add(Of [Class])(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of [Class])(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub ClassUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Class for Adding
			Dim entity As [Class] = QBOHelper.CreateClass(qboContextoAuth)
			'Adding the Class
			Dim added As [Class] = Helper.Add(Of [Class])(qboContextoAuth, entity)

			'Update the Class
			Dim updated As [Class] = QBOHelper.UpdateClass(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As [Class] = Helper.UpdateAsync(Of [Class])(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		'Delete is Soft Delete for Name List entities- Update operation with Active=false



		#End Region
		#End Region
	End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
