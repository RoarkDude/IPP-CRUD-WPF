
Imports System.Collections.Generic
Imports System.Linq
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.QueryFilter



	Public Class InvoiceCRUD
		#Region "Sync Methods"


		#Region "Add Operations"


		Public Sub InvoiceAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Add
			Dim invoice As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, invoice)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub InvoiceFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Adding
			Dim invoice As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, invoice)
			Dim found As Invoice = Helper.FindById(Of Invoice)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub InvoiceUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Adding
			Dim invoice As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, invoice)
			'Change the data of added entity
			Dim changed As Invoice = QBOHelper.UpdateInvoice(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Invoice = Helper.Update(Of Invoice)(qboContextoAuth, changed)
			'Verify the updated Invoice
		End Sub



		Public Sub InvoiceSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Adding
			Dim invoice As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, invoice)
			'Change the data of added entity
			Dim changed As Invoice = QBOHelper.SparseUpdateInvoice(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Invoice = Helper.Update(Of Invoice)(qboContextoAuth, changed)
			'Verify the updated Invoice
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub InvoiceDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Adding
			Dim invoice As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, invoice)
			'Delete the returned entity
			Try

				Dim deleted As Invoice = Helper.Delete(Of Invoice)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub




		Public Sub InvoiceVoidTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Adding
			Dim invoice As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, invoice)
			'Void the returned entity
			Try

				Dim voided As Invoice = Helper.Void(Of Invoice)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub

		#End Region

		#Region "CDC Operations"


		Public Sub InvoiceCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			'InvoiceAddTestUsingoAuth();

			'Retrieving the Invoice using FindAll
			Dim invoices As List(Of Invoice) = Helper.CDC(qboContextoAuth, New Invoice(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub InvoiceBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Invoice = Helper.FindOrAdd(qboContextoAuth, New Invoice())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateInvoice(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateInvoice(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Invoice")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Invoice)(qboContextoAuth, batchEntries)



		End Sub

		#End Region

		#Region "Query"

		Public Sub InvoiceQueryTestUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Invoice)(qboContextoAuth)
			Dim existing As Invoice = Helper.FindOrAdd(Of Invoice)(qboContextoAuth, New Invoice())
			Dim inv As List(Of Invoice) = entityQuery.ExecuteIdsQuery("SELECT * FROM Invoice where Id='" + existing.Id + "'").ToList() '(Of Invoice)()

		End Sub

		#End Region
		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub InvoiceAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Add
			Dim entity As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)

			Dim added As Invoice = Helper.AddAsync(Of Invoice)(qboContextoAuth, entity)

		End Sub

		#End Region



		#Region "FindById Operation"


		Public Sub InvoiceFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Adding
			Dim entity As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Invoice)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub InvoiceUpdateAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Adding
			Dim entity As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, entity)

			'Update the Invoice
			Dim updated As Invoice = QBOHelper.UpdateInvoice(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Invoice = Helper.UpdateAsync(Of Invoice)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub InvoiceDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Invoice for Adding
			Dim entity As Invoice = QBOHelper.CreateInvoice(qboContextoAuth)
			'Adding the Invoice
			Dim added As Invoice = Helper.Add(Of Invoice)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of Invoice)(qboContextoAuth, added)
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
