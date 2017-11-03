
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class PurchaseOrderCRUD


		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub PurchaseOrderAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Add
			Dim purchaseOrder As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, purchaseOrder)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub PurchaseOrderFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PurchaseOrderAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the PurchaseOrder using FindAll
			Dim purchaseOrders As List(Of PurchaseOrder) = Helper.FindAll(Of PurchaseOrder)(qboContextoAuth, New PurchaseOrder(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub PurchaseOrderFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Adding
			Dim purchaseOrder As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, purchaseOrder)
			Dim found As PurchaseOrder = Helper.FindById(Of PurchaseOrder)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub PurchaseOrderUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Adding
			Dim purchaseOrder As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, purchaseOrder)
			'Change the data of added entity
			Dim changed As PurchaseOrder = QBOHelper.UpdatePurchaseOrder(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As PurchaseOrder = Helper.Update(Of PurchaseOrder)(qboContextoAuth, changed)

		End Sub


		Public Sub PurchaseOrderSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Adding
			Dim purchaseOrder As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, purchaseOrder)
			'Change the data of added entity
			Dim changed As PurchaseOrder = QBOHelper.UpdatePurchaseOrderSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As PurchaseOrder = Helper.Update(Of PurchaseOrder)(qboContextoAuth, changed)

		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub PurchaseOrderDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Adding
			Dim purchaseOrder As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, purchaseOrder)
			'Delete the returned entity
			Try

				Dim deleted As PurchaseOrder = Helper.Delete(Of PurchaseOrder)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub




		#End Region

		#Region "CDC Operations"


		Public Sub PurchaseOrderCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PurchaseOrderAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the PurchaseOrder using CDC
			Dim entities As List(Of PurchaseOrder) = Helper.CDC(qboContextoAuth, New PurchaseOrder(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub PurchaseOrderBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As PurchaseOrder = Helper.FindOrAdd(qboContextoAuth, New PurchaseOrder())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreatePurchaseOrder(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdatePurchaseOrder(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from PurchaseOrder")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of PurchaseOrder)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub PurchaseOrderQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of PurchaseOrder)(qboContextoAuth)
			Dim existing As PurchaseOrder = Helper.FindOrAdd(Of PurchaseOrder)(qboContextoAuth, New PurchaseOrder())
			Dim test As List(Of PurchaseOrder) = entityQuery.ExecuteIdsQuery("SELECT * FROM PurchaseOrder where Id='" + existing.Id + "'").ToList() '(Of PurchaseOrder)()
		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub PurchaseOrderAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Add
			Dim entity As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)

			Dim added As PurchaseOrder = Helper.AddAsync(Of PurchaseOrder)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub PurchaseOrderRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PurchaseOrderAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the PurchaseOrder using FindAll
			Helper.FindAllAsync(Of PurchaseOrder)(qboContextoAuth, New PurchaseOrder())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub PurchaseOrderFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Adding
			Dim entity As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of PurchaseOrder)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub PurchaseOrderUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Adding
			Dim entity As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, entity)

			'Update the PurchaseOrder
			Dim updated As PurchaseOrder = QBOHelper.UpdatePurchaseOrder(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As PurchaseOrder = Helper.UpdateAsync(Of PurchaseOrder)(qboContextoAuth, updated)

		End Sub


		Public Sub PurchaseOrderSparseUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Adding
			Dim entity As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, entity)

			'Update the PurchaseOrder
			Dim updated As PurchaseOrder = QBOHelper.UpdatePurchaseOrderSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Call the service
			Dim updatedReturned As PurchaseOrder = Helper.UpdateAsync(Of PurchaseOrder)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub PurchaseOrderDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PurchaseOrder for Adding
			Dim entity As PurchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth)
			'Adding the PurchaseOrder
			Dim added As PurchaseOrder = Helper.Add(Of PurchaseOrder)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of PurchaseOrder)(qboContextoAuth, added)
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
