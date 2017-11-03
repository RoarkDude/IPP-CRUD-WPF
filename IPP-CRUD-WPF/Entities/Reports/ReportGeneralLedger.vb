
Imports System.Collections.Generic
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.ReportService


	Public Class ReportGeneralLedgerTest
		#Region "reportservice test"
		Public Sub ReportGeneralLedgerTestUsingoAuth(qboContextoAuth As ServiceContext)
			Dim reportService As New ReportService(qboContextoAuth)
			reportService.date_macro = "This Fiscal Year-to-date"
			reportService.accounting_method = "Accrual"
			reportService.summarize_column_by = "Month"
			'Check query parameters section of each report for querying on specific cols
			Dim columndata As New List(Of [String])()
			columndata.Add("tx_date")
			columndata.Add("tx_type")
			'The value odf this col has the txnId
			Dim coldata As String = [String].Join(",", columndata)
			reportService.columns = coldata
			Dim report As Report = reportService.ExecuteReport("GeneralLedger")



		End Sub
		#End Region
	End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
