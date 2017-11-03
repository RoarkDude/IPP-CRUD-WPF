
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class PaymentCRUD
		#Region "Sync Methods"

		#Region "Link Payment to Invoice"
		'Link a Payment to Invoice

		'''/payment add
		'Payment p1 = new Payment();
		'p1.TxnDate = DateTime.Now.Date;
		'                    p1.TxnDateSpecified = true;

		'                    //p1.Line = new Line[1];
		'                    //p1.Line[0] = new Line();
		'                    //p1.Line[0].Amount = 20.00M;
		'                    //p1.Line[0].AmountSpecified = true;

		'                    //p1.Line[0].LinkedTxn = new LinkedTxn[1];
		'                    //p1.Line[0].LinkedTxn[0] = new LinkedTxn();
		'                    //p1.Line[0].LinkedTxn[0].TxnId = "10";
		'                    //p1.Line[0].LinkedTxn[0].TxnType = "Invoice";// or creditmemo


		'                    List<Line> lineList1 = new List<Line>();
		'Line paymentLine = new Line();
		'paymentLine.Amount = 20.00M;
		'                    paymentLine.AmountSpecified = true;
		'                    List<LinkedTxn> linkedTxnList = new List<LinkedTxn>();
		'LinkedTxn linkedtxn = new LinkedTxn();
		'linkedtxn.TxnId = "24";
		'                    linkedtxn.TxnType = "Invoice";
		'                    linkedTxnList.Add( linkedtxn);
		'                    paymentLine.LinkedTxn = linkedTxnList.ToArray();
		'                    lineList1.Add(paymentLine);                        
		'                    p1.Line = lineList1.ToArray();


		'                    p1.CustomerRef = new ReferenceType() { Value = "1" };
		'p1.DepositToAccountRef = new ReferenceType() { Value = "4" };
		'p1.PaymentRefNum = "Cash#01";

		'                    p1.TotalAmt = 20.00M;
		'                    p1.TotalAmtSpecified = true;

		'                    var result = commonServiceQBO.Add<Payment>(p1);
		#End Region

		#Region "Add Operations"


		Public Sub PaymentAddTestUsingCheck(qboContextoAuth As ServiceContext)
			'Creating the Payment for Add
			Dim payment As Payment = QBOHelper.CreatePaymentCheck(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, payment)

		End Sub


		Public Sub PaymentAddTestUsingCreditCard(qboContextoAuth As ServiceContext)
			'Creating the Payment for Add
			Dim payment As Payment = QBOHelper.CreatePaymentCreditCard(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, payment)

		End Sub


		Public Sub PaymentAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Add
			Dim payment As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, payment)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub PaymentFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PaymentAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Payment using FindAll
			Dim payments As List(Of Payment) = Helper.FindAll(Of Payment)(qboContextoAuth, New Payment(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub PaymentFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Adding
			Dim payment As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, payment)
			Dim found As Payment = Helper.FindById(Of Payment)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub PaymentUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Adding
			Dim payment As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, payment)
			'Change the data of added entity
			Dim changed As Payment = QBOHelper.UpdatePayment(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Payment = Helper.Update(Of Payment)(qboContextoAuth, changed)
			'Verify the updated Payment
		End Sub


		Public Sub PaymentSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Adding
			Dim payment As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, payment)
			'Change the data of added entity
			Dim changed As Payment = QBOHelper.SparseUpdatePayment(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Payment = Helper.Update(Of Payment)(qboContextoAuth, changed)
			'Verify the updated Payment
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub PaymentDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Adding
			Dim payment As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, payment)
			'Delete the returned entity
			Try

				Dim deleted As Payment = Helper.Delete(Of Payment)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub




		#End Region

		#Region "Void operation"

		Public Sub PaymentVoidTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Adding
			Dim payment As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, payment)
			'Void the returned entity
			Try

				Dim voided As Payment = Helper.Void(Of Payment)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub

		#End Region


		#Region "CDC Operations"


		Public Sub PaymentCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PaymentAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Payment using CDC
			Dim entities As List(Of Payment) = Helper.CDC(qboContextoAuth, New Payment(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub PaymentBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Payment = Helper.FindOrAdd(qboContextoAuth, New Payment())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreatePayment(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdatePayment(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Payment")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Payment)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub PaymentQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Payment)(qboContextoAuth)
			Dim existing As Payment = Helper.FindOrAdd(Of Payment)(qboContextoAuth, New Payment())
			Dim test As List(Of Payment) = entityQuery.ExecuteIdsQuery("SELECT * FROM Payment where Id='" + existing.Id + "'").ToList() '(Of Payment)()
		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub PaymentAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Add
			Dim entity As Payment = QBOHelper.CreatePayment(qboContextoAuth)

			Dim added As Payment = Helper.AddAsync(Of Payment)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub PaymentRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PaymentAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Payment using FindAll
			Helper.FindAllAsync(Of Payment)(qboContextoAuth, New Payment())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub PaymentFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Adding
			Dim entity As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Payment)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub PaymentUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Adding
			Dim entity As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, entity)

			'Update the Payment
			Dim updated As Payment = QBOHelper.UpdatePayment(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Payment = Helper.UpdateAsync(Of Payment)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub PaymentDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Payment for Adding
			Dim entity As Payment = QBOHelper.CreatePayment(qboContextoAuth)
			'Adding the Payment
			Dim added As Payment = Helper.Add(Of Payment)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of Payment)(qboContextoAuth, added)
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
