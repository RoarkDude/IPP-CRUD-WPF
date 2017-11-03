
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class JournalEntryCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub JournalEntryAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Add
			Dim journalEntry As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)
			'Adding the JournalEntry
			Dim added As JournalEntry = Helper.Add(Of JournalEntry)(qboContextoAuth, journalEntry)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub JournalEntryFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			JournalEntryAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the JournalEntry using FindAll
			Dim journalEntrys As List(Of JournalEntry) = Helper.FindAll(Of JournalEntry)(qboContextoAuth, New JournalEntry(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub JournalEntryFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Adding
			Dim journalEntry As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)
			'Adding the JournalEntry
			Dim added As JournalEntry = Helper.Add(Of JournalEntry)(qboContextoAuth, journalEntry)
			Dim found As JournalEntry = Helper.FindById(Of JournalEntry)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub JournalEntryUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Adding
			Dim journalEntry As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)
			'Adding the JournalEntry
			Dim added As JournalEntry = Helper.Add(Of JournalEntry)(qboContextoAuth, journalEntry)
			'Change the data of added entity
			Dim changed As JournalEntry = QBOHelper.UpdateJournalEntry(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As JournalEntry = Helper.Update(Of JournalEntry)(qboContextoAuth, changed)
			'Verify the updated JournalEntry
		End Sub


		Public Sub JournalEntrySparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Adding
			Dim journalEntry As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)
			'Adding the JournalEntry
			Dim added As JournalEntry = Helper.Add(Of JournalEntry)(qboContextoAuth, journalEntry)
			'Change the data of added entity
			Dim changed As JournalEntry = QBOHelper.UpdateJournalEntrySparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As JournalEntry = Helper.Update(Of JournalEntry)(qboContextoAuth, changed)
			'Verify the updated JournalEntry
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub JournalEntryDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Adding
			Dim journalEntry As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)
			'Adding the JournalEntry
			Dim added As JournalEntry = Helper.Add(Of JournalEntry)(qboContextoAuth, journalEntry)
			'Delete the returned entity
			Try

				Dim deleted As JournalEntry = Helper.Delete(Of JournalEntry)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub



		#End Region

		#Region "CDC Operations"


		Public Sub JournalEntryCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			JournalEntryAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the JournalEntry using CDC
			Dim entities As List(Of JournalEntry) = Helper.CDC(qboContextoAuth, New JournalEntry(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub JournalEntryBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As JournalEntry = Helper.FindOrAdd(qboContextoAuth, New JournalEntry())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateJournalEntry(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateJournalEntry(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from JournalEntry")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of JournalEntry)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub JournalEntryQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of JournalEntry)(qboContextoAuth)
			Dim existing As JournalEntry = Helper.FindOrAdd(Of JournalEntry)(qboContextoAuth, New JournalEntry())
			Dim je As List(Of JournalEntry) = entityQuery.ExecuteIdsQuery("SELECT * FROM JournalEntry where Id='" + existing.Id + "'").ToList() '(Of JournalEntry)()

		End Sub

		#End Region
		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub JournalEntryAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Add
			Dim entity As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)

			Dim added As JournalEntry = Helper.AddAsync(Of JournalEntry)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub JournalEntryRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			JournalEntryAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the JournalEntry using FindAll
			Helper.FindAllAsync(Of JournalEntry)(qboContextoAuth, New JournalEntry())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub JournalEntryFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Adding
			Dim entity As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)
			'Adding the JournalEntry
			Dim added As JournalEntry = Helper.Add(Of JournalEntry)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of JournalEntry)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub JournalEntryUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Adding
			Dim entity As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)
			'Adding the JournalEntry
			Dim added As JournalEntry = Helper.Add(Of JournalEntry)(qboContextoAuth, entity)

			'Update the JournalEntry
			Dim updated As JournalEntry = QBOHelper.UpdateJournalEntry(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As JournalEntry = Helper.UpdateAsync(Of JournalEntry)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub JournalEntryDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the JournalEntry for Adding
			Dim entity As JournalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth)
			'Adding the JournalEntry
			Dim added As JournalEntry = Helper.Add(Of JournalEntry)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of JournalEntry)(qboContextoAuth, added)
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
