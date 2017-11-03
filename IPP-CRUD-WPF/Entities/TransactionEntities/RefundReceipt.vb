
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq



	Public Class RefundReceiptCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub RefundReceiptAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Add
			Dim refundReceipt As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)
			'Adding the RefundReceipt
			Dim added As RefundReceipt = Helper.Add(Of RefundReceipt)(qboContextoAuth, refundReceipt)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub RefundReceiptFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			RefundReceiptAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the RefundReceipt using FindAll
			Dim refundReceipts As List(Of RefundReceipt) = Helper.FindAll(Of RefundReceipt)(qboContextoAuth, New RefundReceipt(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub RefundReceiptFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Adding
			Dim refundReceipt As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)
			'Adding the RefundReceipt
			Dim added As RefundReceipt = Helper.Add(Of RefundReceipt)(qboContextoAuth, refundReceipt)
			Dim found As RefundReceipt = Helper.FindById(Of RefundReceipt)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub RefundReceiptUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Adding
			Dim refundReceipt As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)
			'Adding the RefundReceipt
			Dim added As RefundReceipt = Helper.Add(Of RefundReceipt)(qboContextoAuth, refundReceipt)
			'Change the data of added entity
			Dim changed As RefundReceipt = QBOHelper.UpdateRefundReceipt(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As RefundReceipt = Helper.Update(Of RefundReceipt)(qboContextoAuth, changed)
			'Verify the updated RefundReceipt
		End Sub


		Public Sub RefundReceiptSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Adding
			Dim refundReceipt As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)
			'Adding the RefundReceipt
			Dim added As RefundReceipt = Helper.Add(Of RefundReceipt)(qboContextoAuth, refundReceipt)
			'Change the data of added entity
			Dim changed As RefundReceipt = QBOHelper.UpdateRefundReceiptSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As RefundReceipt = Helper.Update(Of RefundReceipt)(qboContextoAuth, changed)
			'Verify the updated RefundReceipt
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub RefundReceiptDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Adding
			Dim refundReceipt As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)
			'Adding the RefundReceipt
			Dim added As RefundReceipt = Helper.Add(Of RefundReceipt)(qboContextoAuth, refundReceipt)
			'Delete the returned entity
			Try

				Dim deleted As RefundReceipt = Helper.Delete(Of RefundReceipt)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub




		#End Region

		#Region "CDC Operations"


		Public Sub RefundReceiptCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			RefundReceiptAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the RefundReceipt using CDC
			Dim entities As List(Of RefundReceipt) = Helper.CDC(qboContextoAuth, New RefundReceipt(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub RefundReceiptBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As RefundReceipt = Helper.FindOrAdd(qboContextoAuth, New RefundReceipt())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateRefundReceipt(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateRefundReceipt(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from RefundReceipt")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of RefundReceipt)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub RefundReceiptQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of RefundReceipt)(qboContextoAuth)
			Dim existing As RefundReceipt = Helper.FindOrAdd(Of RefundReceipt)(qboContextoAuth, New RefundReceipt())
			Dim test As List(Of RefundReceipt) = entityQuery.ExecuteIdsQuery("SELECT * FROM RefundReceipt where Id='" + existing.Id + "'").ToList() '(Of RefundReceipt)()

		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub RefundReceiptAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Add
			Dim entity As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)

			Dim added As RefundReceipt = Helper.AddAsync(Of RefundReceipt)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub RefundReceiptRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			RefundReceiptAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the RefundReceipt using FindAll
			Helper.FindAllAsync(Of RefundReceipt)(qboContextoAuth, New RefundReceipt())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub RefundReceiptFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Adding
			Dim entity As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)
			'Adding the RefundReceipt
			Dim added As RefundReceipt = Helper.Add(Of RefundReceipt)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of RefundReceipt)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub RefundReceiptUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Adding
			Dim entity As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)
			'Adding the RefundReceipt
			Dim added As RefundReceipt = Helper.Add(Of RefundReceipt)(qboContextoAuth, entity)

			'Update the RefundReceipt
			Dim updated As RefundReceipt = QBOHelper.UpdateRefundReceipt(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As RefundReceipt = Helper.UpdateAsync(Of RefundReceipt)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub RefundReceiptDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the RefundReceipt for Adding
			Dim entity As RefundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth)
			'Adding the RefundReceipt
			Dim added As RefundReceipt = Helper.Add(Of RefundReceipt)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of RefundReceipt)(qboContextoAuth, added)
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
