
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class BillCRUD

		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub BillAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Add
			Dim bill As Bill = QBOHelper.CreateBill(qboContextoAuth)
			'Adding the Bill
			Dim added As Bill = Helper.Add(Of Bill)(qboContextoAuth, bill)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub BillFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			BillAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Bill using FindAll
			Dim bills As List(Of Bill) = Helper.FindAll(Of Bill)(qboContextoAuth, New Bill(), 1, 500)
		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub BillFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Adding
			Dim bill As Bill = QBOHelper.CreateBill(qboContextoAuth)
			'Adding the Bill
			Dim added As Bill = Helper.Add(Of Bill)(qboContextoAuth, bill)
			Dim found As Bill = Helper.FindById(Of Bill)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub BillUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Adding
			Dim bill As Bill = QBOHelper.CreateBill(qboContextoAuth)
			'Adding the Bill
			Dim added As Bill = Helper.Add(Of Bill)(qboContextoAuth, bill)
			'Change the data of added entity
			Dim changed As Bill = QBOHelper.UpdateBill(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Bill = Helper.Update(Of Bill)(qboContextoAuth, changed)
			'Verify the updated Bill
		End Sub


		Public Sub BillSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Adding
			Dim bill As Bill = QBOHelper.CreateBill(qboContextoAuth)
			'Adding the Bill
			Dim added As Bill = Helper.Add(Of Bill)(qboContextoAuth, bill)
			'Change the data of added entity
			Dim changed As Bill = QBOHelper.UpdateBillSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Bill = Helper.Update(Of Bill)(qboContextoAuth, changed)
			'Verify the updated Bill
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub BillDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Adding
			Dim bill As Bill = QBOHelper.CreateBill(qboContextoAuth)
			'Adding the Bill
			Dim added As Bill = Helper.Add(Of Bill)(qboContextoAuth, bill)
			'Delete the returned entity
			Try

				Dim deleted As Bill = Helper.Delete(Of Bill)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub

		#End Region


		#Region "CDC Operations"


		Public Sub BillCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			BillAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Bill using CDC
			Dim entities As List(Of Bill) = Helper.CDC(qboContextoAuth, New Bill(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub BillBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Bill = Helper.FindOrAdd(qboContextoAuth, New Bill())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateBill(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateBill(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Bill")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Bill)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub BillQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Bill)(qboContextoAuth)
			Dim existing As Bill = Helper.FindOrAdd(Of Bill)(qboContextoAuth, New Bill())
			Dim test As List(Of Bill) = entityQuery.ExecuteIdsQuery("SELECT * FROM Bill where Id='" + existing.Id + "'").ToList() '(Of Bill)()
		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub BillAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Add
			Dim entity As Bill = QBOHelper.CreateBill(qboContextoAuth)

			Dim added As Bill = Helper.AddAsync(Of Bill)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub BillRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			BillAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Bill using FindAll
			Helper.FindAllAsync(Of Bill)(qboContextoAuth, New Bill())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub BillFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Adding
			Dim entity As Bill = QBOHelper.CreateBill(qboContextoAuth)
			'Adding the Bill
			Dim added As Bill = Helper.Add(Of Bill)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Bill)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub BillUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Adding
			Dim entity As Bill = QBOHelper.CreateBill(qboContextoAuth)
			'Adding the Bill
			Dim added As Bill = Helper.Add(Of Bill)(qboContextoAuth, entity)

			'Update the Bill
			Dim updated As Bill = QBOHelper.UpdateBill(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Bill = Helper.UpdateAsync(Of Bill)(qboContextoAuth, updated)

		End Sub


		Public Sub BillSparseUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Adding
			Dim entity As Bill = QBOHelper.CreateBill(qboContextoAuth)
			'Adding the Bill
			Dim added As Bill = Helper.Add(Of Bill)(qboContextoAuth, entity)

			'Update the Bill
			Dim updated As Bill = QBOHelper.UpdateBillSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Call the service
			Dim updatedReturned As Bill = Helper.UpdateAsync(Of Bill)(qboContextoAuth, updated)

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
