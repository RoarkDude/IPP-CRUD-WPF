
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.Exception
Imports Intuit.Ipp.DataService
Imports System.Collections.ObjectModel
Imports System.Linq


	'This entity is supported only for France
	Public Class JournalCodeCRUD

		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub AddExpensesJournalCodeTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Add
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses)

			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)


		End Sub



		Public Sub AddSalesJournalCodeTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Add
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Sales)

			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)

		End Sub



		Public Sub AddBankJournalCodeTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Add
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Bank)

			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)

		End Sub







		Public Sub AddWagesJournalCodeTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Add
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Wages)

			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)

		End Sub



		Public Sub AddCashJournalCodeTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Add
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Cash)

			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)

		End Sub




		Public Sub AddOthersJournalCodeTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Add
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Others)

			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)

		End Sub


		#End Region

		#Region "FindAll Operations"


		Public Sub JournalCodeFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			AddExpensesJournalCodeTestUsingoAuth(qboContextoAuth)

			'Retrieving the JournalCode using FindAll
			Dim journalCodes As List(Of JournalCode) = Helper.FindAll(Of JournalCode)(qboContextoAuth, New JournalCode(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub JournalCodeFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Adding
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses)
			'Adding the journalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)
			Dim found As JournalCode = Helper.FindById(Of JournalCode)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"
		'check

		Public Sub JournalCodeUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Adding
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses)
			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)
			'Change the data of added entity
			Dim changed As JournalCode = QBOHelper.UpdateJournalCode(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As JournalCode = Helper.Update(Of JournalCode)(qboContextoAuth, changed)
			'Verify the updated JournalCode
		End Sub



		Public Sub JournalCodeSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Adding
			Dim journalCode As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses)
			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, journalCode)
			'Change the data of added entity
			Dim changed As JournalCode = QBOHelper.UpdateJournalCodeSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As JournalCode = Helper.Update(Of JournalCode)(qboContextoAuth, changed)
			'Verify the updated JournalCode
		End Sub
		'check
		#End Region






		#Region "Batch"


		Public Sub JournalCodeBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As JournalCode = Helper.FindOrAdd(qboContextoAuth, New JournalCode())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateJournalCode(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from JournalCode")



			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of JournalCode)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub JournalCodeQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of JournalCode)(qboContextoAuth)
			Dim existing As JournalCode = Helper.FindOrAdd(Of JournalCode)(qboContextoAuth, New JournalCode())
        Dim jc As List(Of JournalCode) = entityQuery.ExecuteIdsQuery("SELECT * FROM JournalCode where Id='" + existing.Id + "'").ToList '(Of JournalCode)()

    End Sub

		#End Region


		#End Region


		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub JournalCodeAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Add
			Dim entity As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses)

			Dim added As JournalCode = Helper.AddAsync(Of JournalCode)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub JournalCodeRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			JournalCodeAddAsyncTestsUsingoAuth(qboContextoAuth)

			'Retrieving the JournalCode using FindAll
			Helper.FindAllAsync(Of JournalCode)(qboContextoAuth, New JournalCode())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub JournalCodeFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Adding
			Dim entity As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses)
			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of JournalCode)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub JournalCodeUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalCode for Adding
			Dim entity As JournalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses)
			'Adding the JournalCode
			Dim added As JournalCode = Helper.Add(Of JournalCode)(qboContextoAuth, entity)

			'Update the JournalCode
			Dim updated As JournalCode = QBOHelper.UpdateJournalCode(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As JournalCode = Helper.UpdateAsync(Of JournalCode)(qboContextoAuth, updated)

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
