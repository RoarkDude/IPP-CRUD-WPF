
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class ItemCRUD
		#Region "Sync Methods"
		#Region "Add Operations"


		Public Sub ItemAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Item for Add
			Dim item As Item = QBOHelper.CreateItem(qboContextoAuth)
			'Adding the Item
			Dim added As Item = Helper.Add(Of Item)(qboContextoAuth, item)


		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub ItemFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			ItemAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Item using FindAll
			Dim items As List(Of Item) = Helper.FindAll(Of Item)(qboContextoAuth, New Item(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub ItemFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Item for Adding
			Dim item As Item = QBOHelper.CreateItem(qboContextoAuth)
			'Adding the Item
			Dim added As Item = Helper.Add(Of Item)(qboContextoAuth, item)
			Dim found As Item = Helper.FindById(Of Item)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub ItemUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Item for Adding
			Dim item As Item = QBOHelper.CreateItem(qboContextoAuth)

			'Adding the Item
			Dim added As Item = Helper.Add(Of Item)(qboContextoAuth, item)
			'Change the data of added entity
			Dim changed As Item = QBOHelper.UpdateItem(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Item = Helper.Update(Of Item)(qboContextoAuth, changed)
			'Verify the updated Item
		End Sub





		Public Sub ItemSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Item for Adding
			Dim item As Item = QBOHelper.CreateItem(qboContextoAuth)
			'Adding the Item
			Dim added As Item = Helper.Add(Of Item)(qboContextoAuth, item)
			'Change the data of added entity
			Dim changed As Item = QBOHelper.SparseUpdateItem(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Item = Helper.Update(Of Item)(qboContextoAuth, changed)
			'Verify the updated Item
		End Sub

		#End Region

		#Region "Delete Operations"



		'Delete is Soft Delete for Name List entities- Update operation with Active=false


		#End Region

		#Region "CDC Operations"


		Public Sub ItemCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			ItemAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Item using FindAll
			Dim items As List(Of Item) = Helper.CDC(qboContextoAuth, New Item(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub ItemBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Item = Helper.FindOrAdd(qboContextoAuth, New Item())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateItem(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateItem(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Item")

			'batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Item)(qboContextoAuth, batchEntries)

		End Sub

		#End Region

		#Region "Query"

		Public Sub ItemQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Item)(qboContextoAuth)
			Dim existing As Item = Helper.FindOrAdd(Of Item)(qboContextoAuth, New Item())
        Dim inv As List(Of Item) = entityQuery.ExecuteIdsQuery("SELECT * FROM Item where Id='" + existing.Id + "'").ToList '(Of Item)()

    End Sub

		#End Region


		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub ItemAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Item for Add
			Dim entity As Item = QBOHelper.CreateItem(qboContextoAuth)

			Dim added As Item = Helper.AddAsync(Of Item)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub ItemRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			ItemAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Item using FindAll
			Helper.FindAllAsync(Of Item)(qboContextoAuth, New Item())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub ItemFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Item for Adding
			Dim entity As Item = QBOHelper.CreateItem(qboContextoAuth)
			'Adding the Item
			Dim added As Item = Helper.Add(Of Item)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Item)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub ItemUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Item for Adding
			Dim entity As Item = QBOHelper.CreateItem(qboContextoAuth)
			'Adding the Item
			Dim added As Item = Helper.Add(Of Item)(qboContextoAuth, entity)

			'Update the Item
			Dim updated As Item = QBOHelper.UpdateItem(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Item = Helper.UpdateAsync(Of Item)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		'Delete is Soft Delete for Name List entities- Update operation with Active=false

		#End Region



		#End Region

		#End Region
	End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
