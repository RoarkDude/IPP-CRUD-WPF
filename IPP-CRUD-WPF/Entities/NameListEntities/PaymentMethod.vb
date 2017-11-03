
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class PaymentMethodCRUD

		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub PaymentMethodAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PaymentMethod for Add
			Dim paymentMethod As PaymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth)
			'Adding the PaymentMethod
			Dim added As PaymentMethod = Helper.Add(Of PaymentMethod)(qboContextoAuth, paymentMethod)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub PaymentMethodFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PaymentMethodAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the PaymentMethod using FindAll
			Dim paymentMethods As List(Of PaymentMethod) = Helper.FindAll(Of PaymentMethod)(qboContextoAuth, New PaymentMethod(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub PaymentMethodFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PaymentMethod for Adding
			Dim paymentMethod As PaymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth)
			'Adding the PaymentMethod
			Dim added As PaymentMethod = Helper.Add(Of PaymentMethod)(qboContextoAuth, paymentMethod)
			Dim found As PaymentMethod = Helper.FindById(Of PaymentMethod)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub PaymentMethodUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PaymentMethod for Adding
			Dim paymentMethod As PaymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth)
			'Adding the PaymentMethod
			Dim added As PaymentMethod = Helper.Add(Of PaymentMethod)(qboContextoAuth, paymentMethod)
			'Change the data of added entity
			Dim changed As PaymentMethod = QBOHelper.UpdatePaymentMethod(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As PaymentMethod = Helper.Update(Of PaymentMethod)(qboContextoAuth, changed)
			'Verify the updated PaymentMethod
		End Sub


		Public Sub PaymentMethodSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PaymentMethod for Adding
			Dim paymentMethod As PaymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth)
			'Adding the PaymentMethod
			Dim added As PaymentMethod = Helper.Add(Of PaymentMethod)(qboContextoAuth, paymentMethod)
			'Change the data of added entity
			Dim changed As PaymentMethod = QBOHelper.SparseUpdatePaymentMethod(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As PaymentMethod = Helper.Update(Of PaymentMethod)(qboContextoAuth, changed)
			'Verify the updated PaymentMethod
		End Sub

		#End Region

		#Region "Delete Operations"




		#End Region

		#Region "CDC Operations"


		Public Sub PaymentMethodCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PaymentMethodAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the PaymentMethod using CDC
			Dim entities As List(Of PaymentMethod) = Helper.CDC(qboContextoAuth, New PaymentMethod(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub PaymentMethodBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As PaymentMethod = Helper.FindOrAddPaymentMethod(qboContextoAuth, "CREDIT_CARD")

			batchEntries.Add(OperationEnum.create, QBOHelper.CreatePaymentMethod(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdatePaymentMethod(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from PaymentMethod")

			'  batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of PaymentMethod)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub PaymentMethodQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of PaymentMethod)(qboContextoAuth)
			Dim existing As PaymentMethod = Helper.FindOrAdd(Of PaymentMethod)(qboContextoAuth, New PaymentMethod())
        Dim tx As List(Of PaymentMethod) = entityQuery.ExecuteIdsQuery("SELECT * FROM PaymentMethod where Id='" + existing.Id + "'").ToList '(Of PaymentMethod)()
    End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub PaymentMethodAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PaymentMethod for Add
			Dim entity As PaymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth)

			Dim added As PaymentMethod = Helper.AddAsync(Of PaymentMethod)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub PaymentMethodRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			PaymentMethodAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the PaymentMethod using FindAll
			Helper.FindAllAsync(Of PaymentMethod)(qboContextoAuth, New PaymentMethod())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub PaymentMethodFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PaymentMethod for Adding
			Dim entity As PaymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth)
			'Adding the PaymentMethod
			Dim added As PaymentMethod = Helper.Add(Of PaymentMethod)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of PaymentMethod)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub PaymentMethodUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the PaymentMethod for Adding
			Dim entity As PaymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth)
			'Adding the PaymentMethod
			Dim added As PaymentMethod = Helper.Add(Of PaymentMethod)(qboContextoAuth, entity)

			'Update the PaymentMethod
			Dim updated As PaymentMethod = QBOHelper.UpdatePaymentMethod(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As PaymentMethod = Helper.UpdateAsync(Of PaymentMethod)(qboContextoAuth, updated)

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
