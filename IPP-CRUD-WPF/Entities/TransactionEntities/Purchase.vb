
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class PurchaseCRUD
		#Region "Cash Purchase Methods"

		#Region "Add Operations"


		Public Sub CashPurchaseAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Add
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub CashPurchaseFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CashPurchaseAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Purchase using FindAll
			Dim purchases As List(Of Purchase) = Helper.FindAll(Of Purchase)(qboContextoAuth, New Purchase(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub CashPurchaseFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			Dim found As Purchase = Helper.FindById(Of Purchase)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub CashPurchaseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Change the data of added entity
			Dim changed As Purchase = QBOHelper.UpdatePurchase(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Purchase = Helper.Update(Of Purchase)(qboContextoAuth, changed)
			'Verify the updated Purchase
		End Sub



		Public Sub CashPurchaseSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Change the data of added entity
			Dim changed As Purchase = QBOHelper.SparseUpdatePurchase(qboContextoAuth, added.Id, added.PaymentType, added.SyncToken)
			'Update the returned entity data
			Dim updated As Purchase = Helper.Update(Of Purchase)(qboContextoAuth, changed)
			'Verify the updated Purchase
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub CashPurchaseDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Delete the returned entity
			Try

				Dim deleted As Purchase = Helper.Delete(Of Purchase)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub




		#End Region

		#Region "CDC Operations"


		Public Sub CashPurchaseCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CashPurchaseAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Purchase using FindAll
			Dim cashPurchases As List(Of Purchase) = Helper.CDC(qboContextoAuth, New Purchase(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub PurchaseBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Purchase = Helper.FindOrAdd(qboContextoAuth, New Purchase())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdatePurchase(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Purchase")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Purchase)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub CashPurchaseQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Purchase)(qboContextoAuth)
			Dim existing As Purchase = Helper.FindOrAddPurchase(qboContextoAuth, PaymentTypeEnum.Cash)
			Dim test As List(Of Purchase) = entityQuery.ExecuteIdsQuery("SELECT * FROM Purchase where Id='" + existing.Id + "'").ToList() '(Of Purchase)()

		End Sub

		#End Region

		#End Region

		#Region "Check Purchase Methods"

		#Region "Add Operations"


		Public Sub CheckPurchaseAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Add
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub CheckPurchaseFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CheckPurchaseAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Purchase using FindAll
			Dim purchases As List(Of Purchase) = Helper.FindAll(Of Purchase)(qboContextoAuth, New Purchase(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub CheckPurchaseFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			Dim found As Purchase = Helper.FindById(Of Purchase)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub CheckPurchaseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Change the data of added entity
			Dim changed As Purchase = QBOHelper.UpdatePurchase(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Purchase = Helper.Update(Of Purchase)(qboContextoAuth, changed)
			'Verify the updated Purchase
		End Sub



		Public Sub CheckPurchaseSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Change the data of added entity
			Dim changed As Purchase = QBOHelper.SparseUpdatePurchase(qboContextoAuth, added.Id, added.PaymentType, added.SyncToken)
			'Update the returned entity data
			Dim updated As Purchase = Helper.Update(Of Purchase)(qboContextoAuth, changed)
			'Verify the updated Purchase
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub CheckPurchaseDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Delete the returned entity
			Try

				Dim deleted As Purchase = Helper.Delete(Of Purchase)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub




		#End Region

		#Region "CDC Operations"


		Public Sub CheckPurchaseCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CheckPurchaseAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Purchase using FindAll
			Dim checkPurchases As List(Of Purchase) = Helper.CDC(qboContextoAuth, New Purchase(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Query"

		Public Sub CheckPurchaseQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Purchase)(qboContextoAuth)
			Dim existing As Purchase = Helper.FindOrAddPurchase(qboContextoAuth, PaymentTypeEnum.Check)
			Dim test As List(Of Purchase) = entityQuery.ExecuteIdsQuery("SELECT * FROM Purchase where Id='" + existing.Id + "'").ToList() '(Of Purchase)()

		End Sub

		#End Region

		#End Region

		#Region "CreditCard Purchase Methods"

		#Region "Add Operations"


		Public Sub CreditCardPurchaseAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Add
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)

		End Sub



		Public Sub CheckPurchaseAddDuplicateDocNumberGlobalTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Add
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check)
			purchase.DocNumber = "DUPLICATE"
			'Pass parameter to allow duplicate doc numbers
			qboContextoAuth.Include.Add("allowduplicatedocnum")
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			Dim addedDuplicate As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)


		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub CreditCardPurchaseFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CreditCardPurchaseAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Purchase using FindAll
			Dim purchases As List(Of Purchase) = Helper.FindAll(Of Purchase)(qboContextoAuth, New Purchase(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub CreditCardPurchaseFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			Dim found As Purchase = Helper.FindById(Of Purchase)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub CreditCardPurchaseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Change the data of added entity
			Dim changed As Purchase = QBOHelper.UpdatePurchase(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Purchase = Helper.Update(Of Purchase)(qboContextoAuth, changed)
			'Verify the updated Purchase
		End Sub



		Public Sub CreditCardPurchaseSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Change the data of added entity
			Dim changed As Purchase = QBOHelper.SparseUpdatePurchase(qboContextoAuth, added.Id, added.PaymentType, added.SyncToken)
			'Update the returned entity data
			Dim updated As Purchase = Helper.Update(Of Purchase)(qboContextoAuth, changed)
			'Verify the updated Purchase
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub CreditCardPurchaseDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Purchase for Adding
			Dim purchase As Purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard)
			'Adding the Purchase
			Dim added As Purchase = Helper.Add(Of Purchase)(qboContextoAuth, purchase)
			'Delete the returned entity
			Try

				Dim deleted As Purchase = Helper.Delete(Of Purchase)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try

		End Sub




		#End Region

		#Region "CDC Operations"


		Public Sub CreditCardPurchaseCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CreditCardPurchaseAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Purchase using FindAll
			Dim creditCardPurchases As List(Of Purchase) = Helper.CDC(qboContextoAuth, New Purchase(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Query"

		Public Sub CreditCardPurchaseQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Purchase)(qboContextoAuth)
			Dim existing As Purchase = Helper.FindOrAddPurchase(qboContextoAuth, PaymentTypeEnum.CreditCard)
			Dim test As List(Of Purchase) = entityQuery.ExecuteIdsQuery("SELECT * FROM Purchase where Id='" + existing.Id + "'").ToList() '(Of Purchase)()

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
