
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class BillPaymentCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub BillPaymentCheckAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Add
			Dim billPayment As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)
			'Adding the BillPayment
			Dim added As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, billPayment)

		End Sub


		Public Sub BillPaymentCreditCardAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Add
			Dim billPayment As BillPayment = QBOHelper.CreateBillPaymentCreditCard(qboContextoAuth)
			'Adding the BillPayment
			Dim added As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, billPayment)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub BillPaymentFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Adding
			Dim billPayment As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)
			'Adding the BillPayment
			Dim added As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, billPayment)
			Dim found As BillPayment = Helper.FindById(Of BillPayment)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub BillPaymentUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Adding
			Dim billPayment As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)
			'Adding the BillPayment
			Dim added As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, billPayment)
			'Change the data of added entity
			Dim changed As BillPayment = QBOHelper.UpdateBillPayment(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As BillPayment = Helper.Update(Of BillPayment)(qboContextoAuth, changed)
			'Verify the updated BillPayment
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub BillPaymentDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Adding
			Dim billPayment As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)
			'Adding the BillPayment
			Dim added As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, billPayment)
			'Delete the returned entity
			Try

				Dim deleted As BillPayment = Helper.Delete(Of BillPayment)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub

		#End Region

		#Region "Void-Beta"

		Public Sub BillPaymentVoidTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Adding
			Dim billpayment As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)
			'Adding the BillPayment
			Dim added As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, billpayment)
			'Void the returned entity
			Try

				Dim voided As BillPayment = Helper.Void(Of BillPayment)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub
		#End Region

		#Region "CDC Operations"

		'[Ignore]  //IgnoreReason:  Not Supported
		Public Sub BillPaymentCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			BillPaymentCheckAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the BillPayment using CDC
			Dim entities As List(Of BillPayment) = Helper.CDC(qboContextoAuth, New BillPayment(), DateTime.Today.AddDays(-100))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub BillPaymentBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim entity As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)
			Dim existing As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, entity)

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateBillPaymentCheck(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateBillPayment(qboContextoAuth, existing))

			'batchEntries.Add(OperationEnum.query, "select * from BillPayment");

			'batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of BillPayment)(qboContextoAuth, batchEntries)

		End Sub

		#End Region

		#Region "Query"


		Public Sub BillPaymentQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of BillPayment)(qboContextoAuth)
			Dim existing As BillPayment = Helper.FindOrAdd(Of BillPayment)(qboContextoAuth, New BillPayment())
			Dim test As List(Of BillPayment) = entityQuery.ExecuteIdsQuery("SELECT * FROM BillPayment where Id='" + existing.Id + "'").ToList() '(Of BillPayment)()

		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub BillPaymentAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Add
			Dim entity As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)

			Dim added As BillPayment = Helper.AddAsync(Of BillPayment)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"

		'[Ignore] //IgnoreReason:  Not supported
		Public Sub BillPaymentRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			BillPaymentCheckAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the BillPayment using FindAll
			Helper.FindAllAsync(Of BillPayment)(qboContextoAuth, New BillPayment())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub BillPaymentFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Adding
			Dim entity As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)
			'Adding the BillPayment
			Dim added As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of BillPayment)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub BillPaymentUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the BillPayment for Adding
			Dim entity As BillPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth)
			'Adding the BillPayment
			Dim added As BillPayment = Helper.Add(Of BillPayment)(qboContextoAuth, entity)

			'Update the BillPayment
			Dim updated As BillPayment = QBOHelper.UpdateBillPayment(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As BillPayment = Helper.UpdateAsync(Of BillPayment)(qboContextoAuth, updated)

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
