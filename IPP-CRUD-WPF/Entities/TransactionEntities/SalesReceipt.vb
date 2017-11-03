
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class SalesReceiptCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub SalesReceiptAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the SalesReceipt for Add
			Dim salesReceipt As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)
			'Adding the SalesReceipt
			Dim added As SalesReceipt = Helper.Add(Of SalesReceipt)(qboContextoAuth, salesReceipt)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub SalesReceiptFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			SalesReceiptAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the SalesReceipt using FindAll
			Dim salesReceipts As List(Of SalesReceipt) = Helper.FindAll(Of SalesReceipt)(qboContextoAuth, New SalesReceipt(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub SalesReceiptFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the SalesReceipt for Adding
			Dim salesReceipt As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)
			'Adding the SalesReceipt
			Dim added As SalesReceipt = Helper.Add(Of SalesReceipt)(qboContextoAuth, salesReceipt)
			Dim found As SalesReceipt = Helper.FindById(Of SalesReceipt)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub SalesReceiptUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)

			'Creating the SalesReceipt for Adding
			Dim salesReceipt As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)
			'Adding the SalesReceipt
			Dim added As SalesReceipt = Helper.Add(Of SalesReceipt)(qboContextoAuth, salesReceipt)
			'Change the data of added entity
			Dim changed As SalesReceipt = QBOHelper.UpdateSalesReceipt(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As SalesReceipt = Helper.Update(Of SalesReceipt)(qboContextoAuth, changed)
			'Verify the updated SalesReceipt
		End Sub


		Public Sub SalesReceiptSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the SalesReceipt for Adding
			Dim salesReceipt As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)
			'Adding the SalesReceipt
			Dim added As SalesReceipt = Helper.Add(Of SalesReceipt)(qboContextoAuth, salesReceipt)
			'Change the data of added entity
			Dim changed As SalesReceipt = QBOHelper.SparseUpdateSalesReceipt(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As SalesReceipt = Helper.Update(Of SalesReceipt)(qboContextoAuth, changed)
			'Verify the updated SalesReceipt
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub SalesReceiptDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the SalesReceipt for Adding
			Dim salesReceipt As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)
			'Adding the SalesReceipt
			Dim added As SalesReceipt = Helper.Add(Of SalesReceipt)(qboContextoAuth, salesReceipt)
			'Delete the returned entity
			Try

				Dim deleted As SalesReceipt = Helper.Delete(Of SalesReceipt)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub



		#End Region

		#Region "CDC Operations"


		Public Sub SalesReceiptCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			SalesReceiptAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the SalesReceipt using FindAll
			Dim salesReceipts As List(Of SalesReceipt) = Helper.CDC(qboContextoAuth, New SalesReceipt(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub SalesReceiptBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As SalesReceipt = Helper.FindOrAdd(qboContextoAuth, New SalesReceipt())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateSalesReceipt(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateSalesReceipt(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from SalesReceipt")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of SalesReceipt)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub SalesReceiptQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of SalesReceipt)(qboContextoAuth)
			Dim existing As SalesReceipt = Helper.FindOrAdd(Of SalesReceipt)(qboContextoAuth, New SalesReceipt())
			Dim test As List(Of SalesReceipt) = entityQuery.ExecuteIdsQuery("SELECT * FROM SalesReceipt where Id='" + existing.Id + "'").ToList() '(Of SalesReceipt)()
		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub SalesReceiptAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the SalesReceipt for Add
			Dim entity As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)

			Dim added As SalesReceipt = Helper.AddAsync(Of SalesReceipt)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub SalesReceiptRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			SalesReceiptAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the SalesReceipt using FindAll
			Helper.FindAllAsync(Of SalesReceipt)(qboContextoAuth, New SalesReceipt())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub SalesReceiptFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the SalesReceipt for Adding
			Dim entity As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)
			'Adding the SalesReceipt
			Dim added As SalesReceipt = Helper.Add(Of SalesReceipt)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of SalesReceipt)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub SalesReceiptUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the SalesReceipt for Adding
			Dim entity As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)
			'Adding the SalesReceipt
			Dim added As SalesReceipt = Helper.Add(Of SalesReceipt)(qboContextoAuth, entity)

			'Update the SalesReceipt
			Dim updated As SalesReceipt = QBOHelper.UpdateSalesReceipt(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As SalesReceipt = Helper.UpdateAsync(Of SalesReceipt)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub SalesReceiptDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the SalesReceipt for Adding
			Dim entity As SalesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth)
			'Adding the SalesReceipt
			Dim added As SalesReceipt = Helper.Add(Of SalesReceipt)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of SalesReceipt)(qboContextoAuth, added)
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
