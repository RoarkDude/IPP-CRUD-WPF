
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class PreferencesCRUD
		#Region "Sync Methods"


		#Region "FindAll Operations"


		Public Sub PreferencesFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)

			'Retrieving the Preferences using FindAll
			Dim preferences As List(Of Preferences) = Helper.FindAll(Of Preferences)(qboContextoAuth, New Preferences(), 1, 500)

		End Sub

		#End Region



		#Region "Update Operations"


		Public Sub PreferencesUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)

			Dim foundall As List(Of Preferences) = Helper.FindAll(Of Preferences)(qboContextoAuth, New Preferences())



			For Each found As Preferences In foundall
				Dim changed As Preferences = QBOHelper.UpdatePreferences(qboContextoAuth, found)
				'Update the returned entity data
					'Verify the updated Preferences
				Dim updated As Preferences = Helper.Update(Of Preferences)(qboContextoAuth, changed)
			Next

		End Sub



		#End Region



		#Region "Query"


		Public Sub PreferencesQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Preferences)(qboContextoAuth)
			Dim pref As List(Of Preferences) = entityQuery.ExecuteIdsQuery("SELECT * FROM Preferences").ToList() '(Of Preferences)()

		End Sub

		#End Region

		#End Region


		#Region "ASync Methods"



		#Region "FindAll Operation"


		Public Sub PreferencesRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)


			'Retrieving the Preferences using FindAll
			Helper.FindAllAsync(Of Preferences)(qboContextoAuth, New Preferences())
		End Sub

		#End Region



		#Region "Update Operation"


		Public Sub PreferencesUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)

			'Change the data of added entity
			Dim foundall As List(Of Preferences) = Helper.FindAll(Of Preferences)(qboContextoAuth, New Preferences())



			For Each found As Preferences In foundall
				Dim changed As Preferences = QBOHelper.UpdatePreferences(qboContextoAuth, found)
				'Update the returned entity data
					'Verify the updated Preferences
				Dim updated As Preferences = Helper.UpdateAsync(Of Preferences)(qboContextoAuth, changed)
			Next
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
