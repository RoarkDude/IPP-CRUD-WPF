
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class VendorCRUD

		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub VendorAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Vendor for Add
			Dim vendor As Vendor = QBOHelper.CreateVendor(qboContextoAuth)
			'Adding the Vendor
			Dim added As Vendor = Helper.Add(Of Vendor)(qboContextoAuth, vendor)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub VendorFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			VendorAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Vendor using FindAll
			Dim vendors As List(Of Vendor) = Helper.FindAll(Of Vendor)(qboContextoAuth, New Vendor(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub VendorFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Vendor for Adding
			Dim vendor As Vendor = QBOHelper.CreateVendor(qboContextoAuth)
			'Adding the Vendor
			Dim added As Vendor = Helper.Add(Of Vendor)(qboContextoAuth, vendor)
			Dim found As Vendor = Helper.FindById(Of Vendor)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub VendorUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Vendor for Adding
			Dim vendor As Vendor = QBOHelper.CreateVendor(qboContextoAuth)
			'Adding the Vendor
			Dim added As Vendor = Helper.Add(Of Vendor)(qboContextoAuth, vendor)
			'Change the data of added entity
			Dim changed As Vendor = QBOHelper.UpdateVendor(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Vendor = Helper.Update(Of Vendor)(qboContextoAuth, changed)
			'Verify the updated Vendor
		End Sub


		Public Sub VendorSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Vendor for Adding
			Dim vendor As Vendor = QBOHelper.CreateVendor(qboContextoAuth)
			'Adding the Vendor
			Dim added As Vendor = Helper.Add(Of Vendor)(qboContextoAuth, vendor)
			'Change the data of added entity
			Dim changed As Vendor = QBOHelper.SparseUpdateVendor(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Vendor = Helper.Update(Of Vendor)(qboContextoAuth, changed)
			'Verify the updated Vendor
		End Sub

		#End Region





		#Region "Delete Operations"



		#End Region

		#Region "CDC Operations"


		Public Sub VendorCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			VendorAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Vendor using FindAll
			Dim vendors As List(Of Vendor) = Helper.CDC(qboContextoAuth, New Vendor(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub VendorBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Vendor = Helper.FindOrAdd(qboContextoAuth, New Vendor())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateVendor(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateVendor(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Vendor")

			'   batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Vendor)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub VendorQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Vendor)(qboContextoAuth)
			Dim existing As Vendor = Helper.FindOrAdd(Of Vendor)(qboContextoAuth, New Vendor())
        Dim ve As List(Of Vendor) = entityQuery.ExecuteIdsQuery("SELECT * FROM Vendor where Id='" + existing.Id + "'").ToList() '(Of Vendor)()

    End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub VendorAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Vendor for Add
			Dim entity As Vendor = QBOHelper.CreateVendor(qboContextoAuth)

			Dim added As Vendor = Helper.AddAsync(Of Vendor)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub VendorRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			VendorAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Vendor using FindAll
			Helper.FindAllAsync(Of Vendor)(qboContextoAuth, New Vendor())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub VendorFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Vendor for Adding
			Dim entity As Vendor = QBOHelper.CreateVendor(qboContextoAuth)
			'Adding the Vendor
			Dim added As Vendor = Helper.Add(Of Vendor)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Vendor)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub VendorUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Vendor for Adding
			Dim entity As Vendor = QBOHelper.CreateVendor(qboContextoAuth)
			'Adding the Vendor
			Dim added As Vendor = Helper.Add(Of Vendor)(qboContextoAuth, entity)

			'Update the Vendor
			Dim updated As Vendor = QBOHelper.UpdateVendor(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Vendor = Helper.UpdateAsync(Of Vendor)(qboContextoAuth, updated)

		End Sub

		#End Region







		#Region "Delete Operation"

		#End Region

		#End Region
	End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
