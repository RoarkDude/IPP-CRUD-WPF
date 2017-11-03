
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq



	Public Class TimeActivityCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub TimeActivityAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TimeActivity for Add
			Dim timeActivity As TimeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth)
			'Adding the TimeActivity
			Dim added As TimeActivity = Helper.Add(Of TimeActivity)(qboContextoAuth, timeActivity)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub TimeActivityFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			TimeActivityAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the TimeActivity using FindAll
			Dim timeActivitys As List(Of TimeActivity) = Helper.FindAll(Of TimeActivity)(qboContextoAuth, New TimeActivity(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub TimeActivityFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TimeActivity for Adding
			Dim timeActivity As TimeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth)
			'Adding the TimeActivity
			Dim added As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())
			Dim found As TimeActivity = Helper.FindById(Of TimeActivity)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub TimeActivityUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'
'            //Creating the TimeActivity for Adding
'            TimeActivity timeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth);
'            //Adding the TimeActivity
'            TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, timeActivity);
'            


			Dim added As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())
			'Change the data of added entity
			Dim changed As TimeActivity = QBOHelper.UpdateTimeActivity(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As TimeActivity = Helper.Update(Of TimeActivity)(qboContextoAuth, changed)
			'Verify the updated TimeActivity
		End Sub


		Public Sub TimeActivitySparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'
'            //Creating the TimeActivity for Adding
'            TimeActivity timeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth);
'            //Adding the TimeActivity
'            TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, timeActivity);
'            


			Dim added As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())
			'Change the data of added entity
			Dim changed As TimeActivity = QBOHelper.UpdateTimeActivitySparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As TimeActivity = Helper.Update(Of TimeActivity)(qboContextoAuth, changed)
			'Verify the updated TimeActivity
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub TimeActivityDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TimeActivity for Adding
			'TimeActivity timeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth);
			'Adding the TimeActivity
			'TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, timeActivity);
			Dim added As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())

			'Delete the returned entity
			Try

				Dim deleted As TimeActivity = Helper.Delete(Of TimeActivity)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub




		#End Region



		#Region "Batch"


		Public Sub TimeActivityBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())

			'  batchEntries.Add(OperationEnum.create, QBOHelper.CreateTimeActivity(qboContextoAuth));

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateTimeActivity(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from TimeActivity")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of TimeActivity)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub TimeActivityQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of TimeActivity)(qboContextoAuth)
			Dim existing As TimeActivity = Helper.FindOrAdd(Of TimeActivity)(qboContextoAuth, New TimeActivity())

		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub TimeActivityAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TimeActivity for Add
			Dim entity As TimeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth)

			Dim added As TimeActivity = Helper.AddAsync(Of TimeActivity)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub TimeActivityRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			'TimeActivityAddTestUsingoAuth(ServiceContext qboContextoAuth);

			'Retrieving the TimeActivity using FindAll
			Helper.FindAllAsync(Of TimeActivity)(qboContextoAuth, New TimeActivity())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub TimeActivityFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TimeActivity for Adding
			'TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);
			'Adding the TimeActivity
			'TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, entity);

			Dim added As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())
			'FindById and verify
			Helper.FindByIdAsync(Of TimeActivity)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub TimeActivityUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TimeActivity for Adding
			'TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);
			'Adding the TimeActivity
			'TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, entity);

			Dim added As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())
			'Update the TimeActivity
			Dim updated As TimeActivity = QBOHelper.UpdateTimeActivity(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As TimeActivity = Helper.UpdateAsync(Of TimeActivity)(qboContextoAuth, updated)

		End Sub


		Public Sub TimeActivitySparseUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TimeActivity for Adding
			'TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);
			'Adding the TimeActivity
			'TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, entity);

			Dim added As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())
			'Update the TimeActivity
			Dim updated As TimeActivity = QBOHelper.UpdateTimeActivitySparse(qboContextoAuth, added.Id, added.SyncToken)
			'Call the service
			Dim updatedReturned As TimeActivity = Helper.UpdateAsync(Of TimeActivity)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub TimeActivityDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TimeActivity for Adding
			'TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);
			'Adding the TimeActivity
			'TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, entity);

			Dim added As TimeActivity = Helper.FindOrAdd(qboContextoAuth, New TimeActivity())

			Helper.DeleteAsync(Of TimeActivity)(qboContextoAuth, added)
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
