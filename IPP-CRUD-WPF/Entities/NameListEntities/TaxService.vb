
Imports System.Collections.Generic
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.GlobalTaxService



	Public Class GlobalTaxServiceCRUD
		#Region "Sync Methods"

		#Region "Add Operations"




		Public Sub TaxCodeAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			Dim guid As [String] = Helper.GetGuid()
			Dim taxSvc As New GlobalTaxService(qboContextoAuth)
			Dim taxCodetobeAdded As New TaxService()
			taxCodetobeAdded.TaxCode = "taxC_" + guid

			Dim taxagency As TaxAgency = Helper.FindOrAdd(Of TaxAgency)(qboContextoAuth, New TaxAgency())


			Dim lstTaxRate As New List(Of TaxRateDetails)()
			Dim taxdetail1 As New TaxRateDetails()
			taxdetail1.TaxRateName = "taxR1_" + guid
			taxdetail1.RateValue = 3D
			taxdetail1.RateValueSpecified = True
			taxdetail1.TaxAgencyId = taxagency.Id.ToString()
			taxdetail1.TaxApplicableOn = TaxRateApplicableOnEnum.Sales
			taxdetail1.TaxApplicableOnSpecified = True
			lstTaxRate.Add(taxdetail1)

			Dim taxdetail2 As New TaxRateDetails()
			taxdetail2.TaxRateName = "taxR2_" + guid
			taxdetail2.RateValue = 2D
			taxdetail2.RateValueSpecified = True
			taxdetail2.TaxAgencyId = taxagency.Id.ToString()
			taxdetail2.TaxApplicableOn = TaxRateApplicableOnEnum.Sales
			taxdetail2.TaxApplicableOnSpecified = True
			lstTaxRate.Add(taxdetail2)

			'TaxRateDetails taxdetail3 = new TaxRateDetails();
			'taxdetail3.TaxRateName = "rate298";
			'taxdetail3.TaxRateId = "2";

			'lstTaxRate.Add(taxdetail3);

			taxCodetobeAdded.TaxRateDetails = lstTaxRate.ToArray()

			Dim taxCodeAdded As Intuit.Ipp.Data.TaxService = taxSvc.AddTaxCode(taxCodetobeAdded)

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
