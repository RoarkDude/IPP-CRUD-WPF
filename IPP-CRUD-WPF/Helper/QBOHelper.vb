
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data


Public Class QBOHelper
		#Region "Create Helper Methods"

		Friend Shared Function CreateTaxAgency(context As ServiceContext) As TaxAgency
			Dim taxAgency As New TaxAgency()
			taxAgency.DisplayName = "Name" + Helper.GetGuid().Substring(0, 5)

			Return taxAgency
		End Function




		Friend Shared Function CreateInvoice(context As ServiceContext) As Invoice
			'US Invoice
			Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
			Dim taxCode As TaxCode = Helper.FindOrAdd(Of TaxCode)(context, New TaxCode())
			Dim account As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsReceivable, AccountClassificationEnum.Liability)

			Dim invoice As New Invoice()
			invoice.Deposit = New [Decimal](0.0)
			invoice.DepositSpecified = True


        invoice.CustomerRef = New ReferenceType() With {
                .name = customer.DisplayName,
                .Value = customer.Id
            }

        invoice.DueDate = DateTime.UtcNow.[Date]
			invoice.DueDateSpecified = True


			invoice.TotalAmt = New [Decimal](10.0)
			invoice.TotalAmtSpecified = True

			invoice.ApplyTaxAfterDiscount = False
			invoice.ApplyTaxAfterDiscountSpecified = True

			invoice.PrintStatus = PrintStatusEnum.NotSet
			invoice.PrintStatusSpecified = True
			invoice.EmailStatus = EmailStatusEnum.NotSet
			invoice.EmailStatusSpecified = True

			Dim billEmail As New EmailAddress()
			billEmail.Address = "abc@gmail.com"
			billEmail.[Default] = True
			billEmail.DefaultSpecified = True
			billEmail.Tag = "Tag"
			invoice.BillEmail = billEmail

			Dim billEmailcc As New EmailAddress()
			billEmailcc.Address = "def@gmail.com"
			billEmailcc.[Default] = True
			billEmailcc.DefaultSpecified = True
			billEmailcc.Tag = "Tag"
			invoice.BillEmailCc = billEmailcc

			Dim billEmailbcc As New EmailAddress()
			billEmailbcc.Address = "xyz@gmail.com"
			billEmailbcc.[Default] = True
			billEmailbcc.DefaultSpecified = True
			billEmailbcc.Tag = "Tag"
			invoice.BillEmailBcc = billEmailbcc


			invoice.Balance = New [Decimal](10.0)
			invoice.BalanceSpecified = True

			invoice.TxnDate = DateTime.UtcNow.[Date]
			invoice.TxnDateSpecified = True


			Dim lineList As New List(Of Line)()
			Dim line As New Line()
			'line.LineNum = "LineNum";
			line.Description = "Description"
			line.Amount = New [Decimal](100.0)
			line.AmountSpecified = True


			line.DetailType = LineDetailTypeEnum.DescriptionOnly
			line.DetailTypeSpecified = True


			lineList.Add(line)
			invoice.Line = lineList.ToArray()
        invoice.TxnTaxDetail = New TxnTaxDetail() With {
                .TotalTax = Convert.ToDecimal(10),
                .TotalTaxSpecified = True
            }




        Return invoice



        'Global invoice

        'Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
        'TaxCode taxCode = Helper.FindOrAdd<TaxCode>(context, new TaxCode());
        'Account account = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsReceivable, AccountClassificationEnum.Liability);
        'Item item = Helper.FindOrAddItem(context, ItemTypeEnum.Service);

        'Invoice invoice = new Invoice();

        'invoice.AutoDocNumber = true;
        'invoice.AutoDocNumberSpecified = true;

        'invoice.CustomerRef = new ReferenceType()
        '{
        '    name = customer.DisplayName,
        '    Value = customer.Id
        '};

        'invoice.DueDate = DateTime.UtcNow.Date;
        'invoice.DueDateSpecified = true;

        'invoice.TotalAmt = Convert.ToDecimal(20);
        'invoice.TotalAmtSpecified = true;

        'invoice.ApplyTaxAfterDiscount = false;
        'invoice.ApplyTaxAfterDiscountSpecified = true;

        'invoice.PrintStatus = PrintStatusEnum.NotSet;
        'invoice.PrintStatusSpecified = true;
        'invoice.EmailStatus = EmailStatusEnum.NotSet;
        'invoice.EmailStatusSpecified = true;

        'EmailAddress billEmail = new EmailAddress();
        'billEmail.Address = @"abc@gmail.com";
        'billEmail.Default = true;
        'billEmail.DefaultSpecified = true;
        'billEmail.Tag = "Tag";
        'invoice.BillEmail = billEmail;

        'EmailAddress billEmailcc = new EmailAddress();
        'billEmailcc.Address = @"def@gmail.com";
        'billEmailcc.Default = true;
        'billEmailcc.DefaultSpecified = true;
        'billEmailcc.Tag = "Tag";
        'invoice.BillEmailCc = billEmailcc;

        'EmailAddress billEmailbcc = new EmailAddress();
        'billEmailbcc.Address = @"xyz@gmail.com";
        'billEmailbcc.Default = true;
        'billEmailbcc.DefaultSpecified = true;
        'billEmailbcc.Tag = "Tag";
        'invoice.BillEmailBcc = billEmailbcc;


        'invoice.Balance = Convert.ToDecimal(20);
        'invoice.BalanceSpecified = true;
        'invoice.TxnDate = DateTime.UtcNow.Date;
        'invoice.TxnDateSpecified = true;

        'invoice.CurrencyRef = new ReferenceType()
        '{
        '    Value = "GBP" //Currency of txn should be same as Customer's currency
        '};
        'invoice.ExchangeRate = 0.798467m;
        'invoice.ExchangeRateSpecified = true;







        'List<Line> lineList = new List<Line>();
        'Line line = new Line();
        'line.Id = "1";
        'line.LineNum = "1";
        'line.Description = "Priced Product";
        'line.Amount = Convert.ToDecimal(10);
        'line.AmountSpecified = true;
        'line.DetailType = LineDetailTypeEnum.SalesItemLineDetail;
        'line.DetailTypeSpecified = true;




        'line.AnyIntuitObject = new SalesItemLineDetail()
        '{
        '    Qty = 1,
        '    QtySpecified = true,

        '    AnyIntuitObject = Convert.ToDecimal(10),
        '    ItemElementName = ItemChoiceType.UnitPrice,

        '    ItemRef = new ReferenceType()
        '    {
        '        name = item.Name,
        '        Value = item.Id
        '    },
        '    TaxCodeRef = new ReferenceType()
        '    {
        '        name = taxCode.Name,
        '        Value = taxCode.Id //US has TAX or NON. Global needs actual TaxCode Id
        '    }
        '};



        'lineList.Add(line);
        'invoice.Line = lineList.ToArray();

        'invoice.TxnTaxDetail = new TxnTaxDetail()
        '{
        '    TotalTax = Convert.ToDecimal(10),
        '    TotalTaxSpecified = true
        '};


        'invoice.GlobalTaxCalculation = GlobalTaxCalculationEnum.TaxExcluded;
        'invoice.GlobalTaxCalculationSpecified = true;



        'return invoice;
    End Function



    Friend Shared Function UpdateInvoice(context As ServiceContext, entity As Invoice) As Invoice
        'update the properties of entity
        entity.DocNumber = "updated" + Helper.GetGuid().Substring(0, 3)

        Return entity
    End Function


    Friend Shared Function SparseUpdateInvoice(context As ServiceContext, Id As String, syncToken As String) As Invoice
        Dim entity As New Invoice()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.DocNumber = "sparseupdated" + Helper.GetGuid().Substring(0, 3)
        Return entity
    End Function



    Friend Shared Function CreateSalesReceipt(context As ServiceContext) As SalesReceipt
        Dim salesReceipt As New SalesReceipt()

        salesReceipt.TotalAmt = New [Decimal](100.0)
        salesReceipt.TotalAmtSpecified = True

        salesReceipt.ApplyTaxAfterDiscount = False
        salesReceipt.ApplyTaxAfterDiscountSpecified = True

        salesReceipt.PrintStatus = PrintStatusEnum.NeedToPrint
        salesReceipt.PrintStatusSpecified = True
        salesReceipt.EmailStatus = EmailStatusEnum.NotSet
        salesReceipt.EmailStatusSpecified = True

        salesReceipt.Balance = New [Decimal](0.0)
        salesReceipt.BalanceSpecified = True

        Dim account As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Liability)
        salesReceipt.DepositToAccountRef = New ReferenceType() With {
                .name = account.Name,
                .Value = account.Id
            }
        salesReceipt.DocNumber = "1003"
        salesReceipt.TxnDate = DateTime.UtcNow.[Date]
        salesReceipt.TxnDateSpecified = True


        Dim lineList As New List(Of Line)()
        Dim line As New Line()
        line.LineNum = "1"
        line.Description = "Description"
        line.Amount = New [Decimal](100.0)
        line.AmountSpecified = True


        line.DetailType = LineDetailTypeEnum.SalesItemLineDetail
        line.DetailTypeSpecified = True
        Dim item As Item = Helper.FindOrAdd(Of Item)(context, New Item())
        Dim findOrAddResult As TaxCode = Helper.FindOrAdd(Of TaxCode)(context, New TaxCode())
        Dim taxCode As TaxCode = Helper.FindAll(Of TaxCode)(context, New TaxCode())(0)

        line.AnyIntuitObject = New SalesItemLineDetail() With {
                .Qty = 1,
                .QtySpecified = True,
                .ItemRef = New ReferenceType() With {
                    .name = item.Name,
                    .Value = item.Id
                },
                .TaxCodeRef = New ReferenceType() With {
                    .name = taxCode.Name,
                    .Value = taxCode.Id
                }
            }


        lineList.Add(line)
        salesReceipt.Line = lineList.ToArray()

        Return salesReceipt
    End Function



    Friend Shared Function UpdateSalesReceipt(context As ServiceContext, entity As SalesReceipt) As SalesReceipt
        entity.PrintStatus = PrintStatusEnum.NeedToPrint
        entity.PrintStatusSpecified = True
        entity.EmailStatus = EmailStatusEnum.NeedToSend
        entity.EmailStatusSpecified = True
        entity.BillEmail = New EmailAddress() With {
                .Address = "address@email.com"
            }
        Return entity
    End Function


    Friend Shared Function SparseUpdateSalesReceipt(context As ServiceContext, Id As String, syncToken As String) As SalesReceipt
        Dim entity As New SalesReceipt()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.PrintStatus = PrintStatusEnum.PrintComplete
        entity.PrintStatusSpecified = True
        Return entity
    End Function



    Friend Shared Function CreateEstimate(context As ServiceContext) As Estimate
        Dim estimate As New Estimate()
        estimate.ExpirationDate = DateTime.UtcNow.[Date].AddDays(15)
        estimate.ExpirationDateSpecified = True
        estimate.TxnDate = DateTime.UtcNow.[Date]
        estimate.TxnDateSpecified = True

        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
        estimate.CustomerRef = New ReferenceType() With {
                .name = customer.DisplayName,
                .Value = customer.Id
            }

        estimate.TotalAmt = New [Decimal](100.0)
        estimate.TotalAmtSpecified = True

        Dim depositAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        estimate.DepositToAccountRef = New ReferenceType() With {
                .name = depositAccount.Name,
                .Value = depositAccount.Id
            }

        Dim item As Item = Helper.FindOrAdd(Of Item)(context, New Item())

        estimate.TotalAmt = New [Decimal](100.0)
        Dim findOrAddResult As TaxCode = Helper.FindOrAdd(Of TaxCode)(context, New TaxCode())
        Dim taxcode As TaxCode = Helper.FindAll(Of TaxCode)(context, New TaxCode())(0)
        If taxcode.SalesTaxRateList IsNot Nothing Then
            Dim taxRateToFind As New TaxRate()
            taxRateToFind.Id = taxcode.SalesTaxRateList.TaxRateDetail(0).TaxRateRef.Value
            Dim taxRate As TaxRate = Helper.FindById(Of TaxRate)(context, taxRateToFind)
            estimate.TotalAmt += estimate.TotalAmt * (taxRate.RateValue / 100)
        End If
        estimate.TotalAmtSpecified = True

        Dim lineList As New List(Of Line)()
        Dim line As New Line()
        line.LineNum = "1"
        line.Description = "Description"
        line.Amount = New [Decimal](100.0)
        line.AmountSpecified = True


        line.DetailType = LineDetailTypeEnum.SalesItemLineDetail
        line.DetailTypeSpecified = True
        line.AnyIntuitObject = New SalesItemLineDetail() With {
                .ItemRef = New ReferenceType() With {
                    .name = item.Name,
                    .Value = item.Id
                },
                .TaxCodeRef = New ReferenceType() With {
                    .name = taxcode.Name,
                    .Value = taxcode.Id
                }
            }
        lineList.Add(line)
        estimate.Line = lineList.ToArray()

        Return estimate
    End Function



    Friend Shared Function UpdateEstimate(context As ServiceContext, entity As Estimate) As Estimate
        'update the properties of entity
        entity.ExpirationDate = DateTime.UtcNow.[Date].AddDays(15)
        entity.ExpirationDateSpecified = True
        entity.TxnDate = DateTime.UtcNow.[Date]
        entity.TxnDateSpecified = True
        Return entity
    End Function


    Friend Shared Function UpdateExchangeRate(context As ServiceContext, entity As ExchangeRate) As ExchangeRate
        'update the ExchangeRate
        'TargetCurrencyCode defaults to Home Currency if not supplied.
        'Setting exchange rate to anything other than 1 for a case where SourceCurrencyCode = TargetCurrencyCode results in the exchange rate set to 1.
        'Setting an exchange rate for the home currency, that is, where SourceCurrencyCode is set to the home currency results in a validation error.
        entity.SourceCurrencyCode = "INR"
        entity.TargetCurrencyCode = "USD"
        entity.Rate = 4
        entity.RateSpecified = True
        entity.AsOfDate = New DateTime(2015, 8, 14)
        entity.AsOfDateSpecified = True

        Return entity
    End Function


    Friend Shared Function UpdateCompanyCurrency(context As ServiceContext, entity As CompanyCurrency) As CompanyCurrency
        entity.Active = False

        Return entity
    End Function


    Friend Shared Function SparseUpdateEstimate(context As ServiceContext, Id As String, syncToken As String) As Estimate
        Dim entity As New Estimate()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.ExpirationDate = DateTime.UtcNow.[Date].AddDays(15)
        entity.ExpirationDateSpecified = True
        entity.TxnDate = DateTime.UtcNow.[Date]
        entity.TxnDateSpecified = True
        Return entity
    End Function




    Friend Shared Function CreateAccount(context As ServiceContext, accountType As AccountTypeEnum, classification As AccountClassificationEnum) As Account
        Dim account As New Account()

        Dim guid As [String] = Helper.GetGuid()
        account.Name = "Name_" + guid

        account.FullyQualifiedName = account.Name

        account.Classification = classification
        account.ClassificationSpecified = True
        account.AccountType = accountType
        account.AccountTypeSpecified = True


        If accountType <> AccountTypeEnum.Expense AndAlso accountType <> AccountTypeEnum.AccountsPayable AndAlso accountType <> AccountTypeEnum.AccountsReceivable Then
        End If

        account.CurrencyRef = New ReferenceType() With {
                .name = "United States Dollar",
                .Value = "USD"
            }

        Return account
    End Function




    Friend Shared Function UpdateAccount(context As ServiceContext, entity As Account) As Account
        'update the properties of entity
        entity.Name = "Name_" + Helper.GetGuid().Substring(0, 5)
        entity.FullyQualifiedName = entity.Name
        Return entity
    End Function


    Friend Shared Function SparseUpdateAccount(context As ServiceContext, Id As String, syncToken As String) As Account
        Dim entity As New Account()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.Name = "Update Name_" + Helper.GetGuid().Substring(0, 5)
        entity.FullyQualifiedName = entity.Name
        Return entity
    End Function



    Friend Shared Function CreatePurchase(context As ServiceContext, paymentType As PaymentTypeEnum) As Purchase
        Dim purchase As New Purchase()

        Dim account As Account = Nothing

        Select Case paymentType
            Case PaymentTypeEnum.Cash
                account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Expense)
                Exit Select
            Case PaymentTypeEnum.Check
                account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Expense)
                Exit Select
            Case PaymentTypeEnum.CreditCard
                account = Helper.FindOrAddAccount(context, AccountTypeEnum.CreditCard, AccountClassificationEnum.Expense)
                Exit Select
            Case PaymentTypeEnum.Other
                Exit Select
            Case Else
                Exit Select
        End Select

        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())


        purchase.AccountRef = New ReferenceType() With {
                .name = account.Name,
                .Value = account.Id
            }

        purchase.PaymentType = paymentType
        purchase.PaymentTypeSpecified = True

        purchase.EntityRef = New ReferenceType() With {
                .name = customer.DisplayName,
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Customer),
                .Value = customer.Id
            }
        If paymentType = PaymentTypeEnum.CreditCard OrElse paymentType = PaymentTypeEnum.Cash Then
            purchase.Credit = False
            purchase.CreditSpecified = True
        End If

        purchase.TotalAmt = New [Decimal](1000.0)
        purchase.TotalAmtSpecified = True

        If paymentType <> PaymentTypeEnum.CreditCard Then
            purchase.PrintStatus = PrintStatusEnum.NotSet
            purchase.PrintStatusSpecified = True
        End If



        purchase.TxnDate = DateTime.UtcNow.[Date]
        purchase.TxnDateSpecified = True


        Dim lineList As New List(Of Line)()
        Dim line As New Line()
        'line.LineNum = "LineNum";
        line.Description = "Description for Line"
        line.Amount = New [Decimal](1000.0)
        line.AmountSpecified = True


        line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail
        line.DetailTypeSpecified = True
        Dim lineDetail As New AccountBasedExpenseLineDetail()
        Dim lineAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense)
        lineDetail.AccountRef = New ReferenceType() With {
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Account),
                .name = lineAccount.Name,
                .Value = lineAccount.Id
            }
        lineDetail.BillableStatus = BillableStatusEnum.NotBillable
        lineDetail.TaxAmount = New [Decimal](10.0)
        lineDetail.TaxAmountSpecified = True
        line.AnyIntuitObject = lineDetail



        lineList.Add(line)
        purchase.Line = lineList.ToArray()

        Return purchase
    End Function



    Friend Shared Function UpdatePurchase(context As ServiceContext, entity As Purchase) As Purchase
        'update the properties of entity
        Dim line As Line() = entity.Line
        line(0).Amount = New [Decimal](1001.0)

        entity.TotalAmt = New [Decimal](1001.0)
        Return entity
    End Function


    Friend Shared Function SparseUpdatePurchase(context As ServiceContext, Id As String, paymentType As PaymentTypeEnum, syncToken As String) As Purchase
        Dim entity As New Purchase()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.PaymentType = paymentType
        entity.PaymentTypeSpecified = True

        Dim lineList As New List(Of Line)()
        Dim line As New Line()
        line.Description = "Sparse Update Desc"
        line.Amount = New [Decimal](1002.0)
        line.AmountSpecified = True

        line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail
        line.DetailTypeSpecified = True

        Dim lineDetail As New AccountBasedExpenseLineDetail()
        Dim lineAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense)
        lineDetail.AccountRef = New ReferenceType() With {
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Account),
                .name = lineAccount.Name,
                .Value = lineAccount.Id
            }
        lineDetail.BillableStatus = BillableStatusEnum.NotBillable
        lineDetail.TaxAmount = New [Decimal](10.0)
        lineDetail.TaxAmountSpecified = True
        line.AnyIntuitObject = lineDetail

        lineList.Add(line)
        entity.Line = lineList.ToArray()

        entity.TotalAmt = New [Decimal](1002.0)
        entity.TotalAmtSpecified = True
        Return entity
    End Function






    Friend Shared Function CreateBill(context As ServiceContext) As Bill

        Dim vendors As Vendor = Helper.FindOrAdd(Of Vendor)(context, New Vendor())
        Dim account As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsPayable, AccountClassificationEnum.Liability)
        Dim accountExpense As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense)
        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())

        Dim bill As New Bill()

        bill.DueDate = DateTime.UtcNow.[Date]
        bill.DueDateSpecified = True


        bill.VendorRef = New ReferenceType() With {
                .name = vendors.DisplayName,
                .Value = vendors.Id
            }

        bill.APAccountRef = New ReferenceType() With {
                .name = account.Name,
                .Value = account.Id
            }
        bill.TotalAmt = New [Decimal](100.0)
        bill.TotalAmtSpecified = True
        bill.Balance = New [Decimal](100.0)
        bill.BalanceSpecified = True

        bill.TxnDate = DateTime.UtcNow.[Date]
        bill.TxnDateSpecified = True


        Dim lineList As New List(Of Line)()
        Dim line As New Line()
        'line.LineNum = "LineNum";
        line.Description = "Description"
        line.Amount = New [Decimal](100.0)
        line.AmountSpecified = True


        line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail
        line.DetailTypeSpecified = True

        Dim detail As New AccountBasedExpenseLineDetail()
        detail.CustomerRef = New ReferenceType() With {
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Customer),
                .name = customer.DisplayName,
                .Value = customer.Id
            }
        detail.AccountRef = New ReferenceType() With {
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Account),
                .name = accountExpense.Name,
                .Value = accountExpense.Id
            }
        detail.BillableStatus = BillableStatusEnum.NotBillable

        line.AnyIntuitObject = detail


        lineList.Add(line)
        bill.Line = lineList.ToArray()

        Return bill
    End Function



    Friend Shared Function UpdateBill(context As ServiceContext, entity As Bill) As Bill
        'update the properties of entity
        entity.DocNumber = "docNo" + Helper.GetGuid().Substring(0, 5)
        Return entity
    End Function

    Friend Shared Function UpdateBillSparse(context As ServiceContext, Id As String, SyncToken As String) As Bill
        'update the properties of entity
        Dim entity As New Bill()
        entity.Id = Id
        entity.SyncToken = SyncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.DocNumber = "docNo" + Helper.GetGuid().Substring(0, 5)

        Dim vendors As Vendor = Helper.FindOrAdd(Of Vendor)(context, New Vendor())
        entity.VendorRef = New ReferenceType() With {
                .name = vendors.DisplayName,
                .Value = vendors.Id
            }
        Return entity
    End Function



    Friend Shared Function CreateVendorCredit(context As ServiceContext) As VendorCredit
        Dim vendorCredit As New VendorCredit()

        Dim vendor As Vendor = Helper.FindOrAdd(Of Vendor)(context, New Vendor())
        vendorCredit.VendorRef = New ReferenceType() With {
                .name = vendor.DisplayName,
                .Value = vendor.Id
            }
        Dim liabilityAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsPayable, AccountClassificationEnum.Asset)
        vendorCredit.APAccountRef = New ReferenceType() With {
                .name = liabilityAccount.Name,
                .Value = liabilityAccount.Id
            }

        vendorCredit.TotalAmt = New [Decimal](50.0)
        vendorCredit.TotalAmtSpecified = True

        vendorCredit.TxnDate = DateTime.UtcNow.[Date]
        vendorCredit.TxnDateSpecified = True


        Dim lineList As New List(Of Line)()
        Dim line As New Line()

        line.Description = "Description"
        line.Amount = New [Decimal](50.0)
        line.AmountSpecified = True


        line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail
        line.DetailTypeSpecified = True



        Dim expenseAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense)
        line.AnyIntuitObject = New AccountBasedExpenseLineDetail() With {
                .AccountRef = New ReferenceType() With {
                    .name = expenseAccount.Name,
                    .Value = expenseAccount.Id
                }
            }


        lineList.Add(line)
        vendorCredit.Line = lineList.ToArray()

        Return vendorCredit
    End Function



    Friend Shared Function UpdateVendorCredit(context As ServiceContext, entity As VendorCredit) As VendorCredit
        'update the properties of entity
        entity.TxnDate = DateTime.UtcNow.[Date].AddDays(2)
        entity.TxnDateSpecified = True
        entity.PrivateNote = "UpdatedPrivateNote"
        Return entity
    End Function

    Friend Shared Function UpdateVendorCreditSparse(context As ServiceContext, id As String, syncToken As String, vendorRef As ReferenceType) As VendorCredit
        Dim entity As New VendorCredit()
        entity.Id = id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.TxnDate = DateTime.UtcNow.[Date].AddDays(2)
        entity.TxnDateSpecified = True
        entity.PrivateNote = "UpdatedPrivateNote"
        entity.VendorRef = vendorRef
        'Required for sparse update
        Return entity
    End Function



    Friend Shared Function CreateClass(context As ServiceContext) As [Class]
        Dim class1 As New [Class]()
        class1.Name = "ClassName" + Helper.GetGuid().Substring(0, 20)
        class1.SubClass = True
        class1.SubClassSpecified = True

        class1.FullyQualifiedName = class1.Name
        class1.Active = True
        class1.ActiveSpecified = True

        Return class1
    End Function



    Friend Shared Function UpdateClass(context As ServiceContext, entity As [Class]) As [Class]
        entity.Name = "UpdatedName" + Helper.GetGuid().Substring(0, 16)
        entity.FullyQualifiedName = entity.Name
        Return entity
    End Function


    Friend Shared Function SparseUpdateClass(context As ServiceContext, Id As String, syncToken As String) As [Class]
        Dim entity As New [Class]()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.Name = "UpdatedName" + Helper.GetGuid().Substring(0, 16)
        entity.FullyQualifiedName = entity.Name
        Return entity
    End Function

    Friend Shared Function CreatePaymentCheck(context As ServiceContext) As Payment
        Dim payment As New Payment()
        payment.TxnDate = DateTime.UtcNow.[Date]
        payment.TxnDateSpecified = True
        Dim depositAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        payment.DepositToAccountRef = New ReferenceType() With {
                .name = depositAccount.Name,
                .Value = depositAccount.Id
            }
        Dim paymentMethod As PaymentMethod = Helper.FindOrAdd(Of PaymentMethod)(context, New PaymentMethod())
        payment.PaymentMethodRef = New ReferenceType() With {
                .name = paymentMethod.Name,
                .Value = paymentMethod.Id
            }
        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
        payment.CustomerRef = New ReferenceType() With {
                .name = customer.DisplayName,
                .Value = customer.Id
            }

        payment.PaymentType = PaymentTypeEnum.Check
        Dim checkPayment As New CheckPayment()
        checkPayment.AcctNum = "Acctnum" + Helper.GetGuid().Substring(0, 5)
        checkPayment.BankName = "BankName" + Helper.GetGuid().Substring(0, 5)
        checkPayment.CheckNum = "CheckNum" + Helper.GetGuid().Substring(0, 5)
        checkPayment.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5)
        checkPayment.Status = "Status" + Helper.GetGuid().Substring(0, 5)
        payment.AnyIntuitObject = checkPayment

        payment.TotalAmt = New [Decimal](100.0)
        payment.TotalAmtSpecified = True
        payment.UnappliedAmt = New [Decimal](100.0)
        payment.UnappliedAmtSpecified = True
        Return payment
    End Function

    Friend Shared Function CreatePaymentCreditCard(context As ServiceContext) As Payment
        Dim payment As New Payment()
        payment.TxnDate = DateTime.UtcNow.[Date]
        payment.TxnDateSpecified = True
        Dim depositAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        payment.DepositToAccountRef = New ReferenceType() With {
                .name = depositAccount.Name,
                .Value = depositAccount.Id
            }
        Dim paymentMethod As PaymentMethod = Helper.FindOrAdd(Of PaymentMethod)(context, New PaymentMethod())
        payment.PaymentMethodRef = New ReferenceType() With {
                .name = paymentMethod.Name,
                .Value = paymentMethod.Id
            }
        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
        payment.CustomerRef = New ReferenceType() With {
                .name = customer.DisplayName,
                .Value = customer.Id
            }

        payment.PaymentType = PaymentTypeEnum.CreditCard

        Dim creditCardPayment As New CreditCardPayment()
        Dim creditChargeInfo As New CreditChargeInfo()
        creditChargeInfo.BillAddrStreet = "BillAddrStreet" + Helper.GetGuid().Substring(0, 5)
        creditChargeInfo.CcExpiryMonth = 10
        creditChargeInfo.CcExpiryMonthSpecified = True
        creditChargeInfo.CcExpiryYear = DateTime.Today.Year
        creditChargeInfo.CcExpiryYearSpecified = True
        creditChargeInfo.CCTxnMode = CCTxnModeEnum.CardNotPresent
        creditChargeInfo.CCTxnModeSpecified = True
        creditChargeInfo.CCTxnType = CCTxnTypeEnum.Charge
        creditChargeInfo.CCTxnTypeSpecified = True
        creditChargeInfo.CommercialCardCode = "Cardcode" + Helper.GetGuid().Substring(0, 5)
        creditChargeInfo.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5)
        creditChargeInfo.Number = Helper.GetGuid().Substring(0, 5)
        creditChargeInfo.PostalCode = Helper.GetGuid().Substring(0, 5)
        creditCardPayment.CreditChargeInfo = creditChargeInfo

        payment.AnyIntuitObject = creditCardPayment
        payment.TotalAmt = New [Decimal](100.0)
        payment.TotalAmtSpecified = True
        payment.UnappliedAmt = New [Decimal](100.0)
        payment.UnappliedAmtSpecified = True
        Return payment
    End Function

    Friend Shared Function CreatePayment(context As ServiceContext) As Payment
        Dim payment As New Payment()
        payment.TxnDate = DateTime.UtcNow.[Date]
        payment.TxnDateSpecified = True

        Dim ARAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsReceivable, AccountClassificationEnum.Asset)
        payment.ARAccountRef = New ReferenceType() With {
                .name = ARAccount.Name,
                .Value = ARAccount.Id
            }

        Dim depositAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        payment.DepositToAccountRef = New ReferenceType() With {
                .name = depositAccount.Name,
                .Value = depositAccount.Id
            }
        Dim paymentMethod As PaymentMethod = Helper.FindOrAdd(Of PaymentMethod)(context, New PaymentMethod())
        payment.PaymentMethodRef = New ReferenceType() With {
                .name = paymentMethod.Name,
                .Value = paymentMethod.Id
            }
        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
        payment.CustomerRef = New ReferenceType() With {
                .name = customer.DisplayName,
                .Value = customer.Id
            }

        payment.PaymentType = PaymentTypeEnum.Check
        Dim checkPayment As New CheckPayment()
        checkPayment.AcctNum = "Acctnum" + Helper.GetGuid().Substring(0, 5)
        checkPayment.BankName = "BankName" + Helper.GetGuid().Substring(0, 5)
        checkPayment.CheckNum = "CheckNum" + Helper.GetGuid().Substring(0, 5)
        checkPayment.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5)
        checkPayment.Status = "Status" + Helper.GetGuid().Substring(0, 5)
        checkPayment.CheckPaymentEx = New IntuitAnyType()
        payment.AnyIntuitObject = checkPayment

        payment.TotalAmt = New [Decimal](100.0)
        payment.TotalAmtSpecified = True
        payment.UnappliedAmt = New [Decimal](100.0)
        payment.UnappliedAmtSpecified = True
        Return payment
    End Function



    Friend Shared Function UpdatePayment(context As ServiceContext, entity As Payment) As Payment
        'update the properties of entity
        entity.TxnDate = DateTime.UtcNow.[Date].AddDays(10)
        entity.TxnDateSpecified = True
        Return entity
    End Function

    Friend Shared Function SparseUpdatePayment(context As ServiceContext, Id As String, syncToken As String) As Payment
        Dim entity As New Payment()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.PrivateNote = "updated Private Note"
        Return entity
    End Function


    Friend Shared Function CreatePaymentMethod(context As ServiceContext) As PaymentMethod
        Dim paymentMethod As New PaymentMethod()
        paymentMethod.Name = "CreditCard" + Helper.GetGuid().Substring(0, 13)
        paymentMethod.Active = True
        paymentMethod.ActiveSpecified = True
        paymentMethod.Type = "CREDIT_CARD"
        'Need to be replaced by PaymentTypeEnum
        Return paymentMethod
    End Function



    Friend Shared Function UpdatePaymentMethod(context As ServiceContext, entity As PaymentMethod) As PaymentMethod
        entity.Name = "Cash" + Helper.GetGuid().Substring(0, 13)
        entity.Type = "NON_CREDIT_CARD"
        Return entity
    End Function



    Friend Shared Function SparseUpdatePaymentMethod(context As ServiceContext, Id As String, syncToken As String) As PaymentMethod
        Dim entity As New PaymentMethod()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.Name = "Sparse Cash" + Helper.GetGuid().Substring(0, 13)
        entity.Type = "NON_CREDIT_CARD"
        Return entity
    End Function



    Friend Shared Function CreateDepartment(context As ServiceContext) As Department
        Dim department As New Department()
        department.Name = "DeptName" + Helper.GetGuid().Substring(0, 13)
        department.SubDepartment = True
        department.SubDepartmentSpecified = True

        department.FullyQualifiedName = department.Name
        department.Active = True
        department.ActiveSpecified = True

        Return department
    End Function



    Friend Shared Function UpdateDepartment(context As ServiceContext, entity As Department) As Department
        entity.Name = "DeptName" + Helper.GetGuid().Substring(0, 13)
        entity.FullyQualifiedName = entity.Name
        Return entity
    End Function


    Friend Shared Function UpdateDepartmentSparse(context As ServiceContext, Id As String, SyncToken As String) As Department
        Dim entity As New Department()
        entity.Id = Id
        entity.SyncToken = SyncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.Name = "DeptName" + Helper.GetGuid().Substring(0, 13)
        entity.FullyQualifiedName = entity.Name
        Return entity
    End Function


    Friend Shared Function CreateItem(context As ServiceContext) As Item

        Dim item As New Item()


        item.Name = "Name" + Helper.GetGuid().Substring(0, 5)


        item.Description = "Description"
        item.Type = ItemTypeEnum.NonInventory
        item.TypeSpecified = True

        item.Active = True
        item.ActiveSpecified = True


        item.Taxable = False
        item.TaxableSpecified = True

        item.UnitPrice = New [Decimal](100.0)
        item.UnitPriceSpecified = True

        Dim incomeAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Income, AccountClassificationEnum.Revenue)
        item.IncomeAccountRef = New ReferenceType() With {
                .name = incomeAccount.Name,
                .Value = incomeAccount.Id
            }

        item.PurchaseCost = New [Decimal](100.0)
        item.PurchaseCostSpecified = True
        Dim expenseAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense)
        item.ExpenseAccountRef = New ReferenceType() With {
                .name = expenseAccount.Name,
                .Value = expenseAccount.Id
            }

        item.TrackQtyOnHand = False
        item.TrackQtyOnHandSpecified = True


        Return item

    End Function



    Friend Shared Function UpdateItem(context As ServiceContext, entity As Item) As Item
        'update the properties of entity
        entity.Name = "updatedName" + Helper.GetGuid().Substring(0, 5)
        entity.Description = "updatedDescription"
        Return entity
    End Function





    Friend Shared Function SparseUpdateItem(context As ServiceContext, Id As String, syncToken As String) As Item
        Dim entity As New Item()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.Name = "sparseupdatedName" + Helper.GetGuid().Substring(0, 5)
        entity.Description = "sparseupdatedDescription"
        Return entity
    End Function


    Friend Shared Function CreateTerm(context As ServiceContext) As Term
        Dim term As New Term()
        term.Name = "Name" + Helper.GetGuid().Substring(0, 15)
        term.Active = True
        term.ActiveSpecified = True
        term.Type = "STANDARD"
        term.DiscountPercent = New [Decimal](50.0)
        term.DiscountPercentSpecified = True
        term.AnyIntuitObjects = New [Object]() {10}
        term.ItemsElementName = New ItemsChoiceType() {ItemsChoiceType.DueDays}
        Return term
    End Function


    Friend Shared Function UpdateTerm(context As ServiceContext, entity As Term) As Term
        entity.Name = "UpdateName" + Helper.GetGuid().Substring(0, 15)
        entity.Active = True
        entity.ActiveSpecified = True
        Return entity
    End Function


    Friend Shared Function SparseUpdateTerm(context As ServiceContext, Id As String, syncToken As String) As Term
        Dim entity As New Term()
        entity.Id = Id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.Name = "SparseUpdateName" + Helper.GetGuid().Substring(0, 15)
        entity.Active = True
        entity.ActiveSpecified = True
        Return entity
    End Function


    Friend Shared Function CreateBillPaymentCheck(context As ServiceContext) As BillPayment
        Dim billPayment As New BillPayment()
        Dim vendorCredit As VendorCredit = Helper.Add(context, QBOHelper.CreateVendorCredit(context))
        billPayment.PayType = BillPaymentTypeEnum.Check
        billPayment.PayTypeSpecified = True

        billPayment.TotalAmt = vendorCredit.TotalAmt
        billPayment.TotalAmtSpecified = True

        billPayment.TxnDate = DateTime.UtcNow.[Date]
        billPayment.TxnDateSpecified = True

        billPayment.PrivateNote = "PrivateNote"


        Dim vendor As Vendor = Helper.FindOrAdd(Of Vendor)(context, New Vendor())
        billPayment.VendorRef = New ReferenceType() With {
                .name = vendor.DisplayName,
                .type = "Vendor",
                .Value = vendor.Id
            }

        Dim bankAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        Dim billPaymentCheck As New BillPaymentCheck()
        billPaymentCheck.BankAccountRef = New ReferenceType() With {
                .name = bankAccount.Name,
                .Value = bankAccount.Id
            }

        Dim checkPayment As New CheckPayment()
        checkPayment.AcctNum = "AcctNum" + Helper.GetGuid().Substring(0, 5)
        checkPayment.BankName = "BankName" + Helper.GetGuid().Substring(0, 5)
        checkPayment.CheckNum = "CheckNum" + Helper.GetGuid().Substring(0, 5)
        checkPayment.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5)
        checkPayment.Status = "Status" + Helper.GetGuid().Substring(0, 5)
        billPaymentCheck.CheckDetail = checkPayment

        Dim payeeAddr As New PhysicalAddress()
        payeeAddr.Line1 = "Line 1"
        payeeAddr.Line2 = "Line 2"
        payeeAddr.City = "Mountain View"
        payeeAddr.CountrySubDivisionCode = "CA"
        payeeAddr.PostalCode = "94043"
        billPaymentCheck.PayeeAddr = payeeAddr
        billPaymentCheck.PrintStatus = PrintStatusEnum.NeedToPrint
        billPaymentCheck.PrintStatusSpecified = True
        billPayment.AnyIntuitObject = billPaymentCheck

        Dim lineList As New List(Of Line)()

        Dim line1 As New Line()


        Dim bill As Bill = Helper.Add(Of Bill)(context, QBOHelper.CreateBill(context))
        line1.Amount = bill.TotalAmt
        line1.AmountSpecified = True
        Dim LinkedTxnList1 As New List(Of LinkedTxn)()
        Dim linkedTxn1 As New LinkedTxn()
        linkedTxn1.TxnId = bill.Id
        linkedTxn1.TxnType = TxnTypeEnum.Bill.ToString()
        LinkedTxnList1.Add(linkedTxn1)
        line1.LinkedTxn = LinkedTxnList1.ToArray()

        lineList.Add(line1)

        Dim line As New Line()


        line.Amount = vendorCredit.TotalAmt
        line.AmountSpecified = True

        Dim LinkedTxnList As New List(Of LinkedTxn)()
        Dim linkedTxn As New LinkedTxn()
        linkedTxn.TxnId = vendorCredit.Id
        linkedTxn.TxnType = TxnTypeEnum.VendorCredit.ToString()
        LinkedTxnList.Add(linkedTxn)
        line.LinkedTxn = LinkedTxnList.ToArray()

        lineList.Add(line)

        billPayment.Line = lineList.ToArray()

        Return billPayment
    End Function

    Friend Shared Function CreateBillPaymentCreditCard(context As ServiceContext) As BillPayment
        Dim billPayment As New BillPayment()
        Dim vendorCredit As VendorCredit = Helper.Add(context, QBOHelper.CreateVendorCredit(context))
        billPayment.PayType = BillPaymentTypeEnum.Check
        billPayment.PayTypeSpecified = True

        billPayment.TotalAmt = vendorCredit.TotalAmt
        billPayment.TotalAmtSpecified = True

        billPayment.TxnDate = DateTime.UtcNow.[Date]
        billPayment.TxnDateSpecified = True

        billPayment.PrivateNote = "PrivateNote"

        Dim vendor As Vendor = Helper.FindOrAdd(Of Vendor)(context, New Vendor())
        billPayment.VendorRef = New ReferenceType() With {
                .name = vendor.DisplayName,
                .type = "Vendor",
                .Value = vendor.Id
            }

        Dim bankAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.CreditCard, AccountClassificationEnum.Expense)
        Dim billPaymentCreditCard As New BillPaymentCreditCard()
        billPaymentCreditCard.CCAccountRef = New ReferenceType() With {
                .name = bankAccount.Name,
                .Value = bankAccount.Id
            }

        Dim creditCardPayment As New CreditCardPayment()
        creditCardPayment.CreditChargeInfo = New CreditChargeInfo() With {
                .Amount = New [Decimal](10.0),
                .AmountSpecified = True,
                .Number = "124124124",
                .NameOnAcct = bankAccount.Name,
                .CcExpiryMonth = 10,
                .CcExpiryMonthSpecified = True,
                .CcExpiryYear = 2015,
                .CcExpiryYearSpecified = True,
                .BillAddrStreet = "BillAddrStreetba7cca47",
                .PostalCode = "560045",
                .CommercialCardCode = "CardCodeba7cca47",
                .CCTxnMode = CCTxnModeEnum.CardPresent,
                .CCTxnType = CCTxnTypeEnum.Charge
            }

        billPaymentCreditCard.CCDetail = creditCardPayment
        billPayment.AnyIntuitObject = billPaymentCreditCard

        Dim lineList As New List(Of Line)()

        Dim line1 As New Line()

        Dim bill As Bill = Helper.Add(Of Bill)(context, QBOHelper.CreateBill(context))
        line1.Amount = bill.TotalAmt
        line1.AmountSpecified = True
        Dim LinkedTxnList1 As New List(Of LinkedTxn)()
        Dim linkedTxn1 As New LinkedTxn()
        linkedTxn1.TxnId = bill.Id
        linkedTxn1.TxnType = TxnTypeEnum.Bill.ToString()
        LinkedTxnList1.Add(linkedTxn1)
        line1.LinkedTxn = LinkedTxnList1.ToArray()

        lineList.Add(line1)

        Dim line As New Line()


        line.Amount = vendorCredit.TotalAmt
        line.AmountSpecified = True

        Dim LinkedTxnList As New List(Of LinkedTxn)()
        Dim linkedTxn As New LinkedTxn()
        linkedTxn.TxnId = vendorCredit.Id
        linkedTxn.TxnType = TxnTypeEnum.VendorCredit.ToString()
        LinkedTxnList.Add(linkedTxn)
        line.LinkedTxn = LinkedTxnList.ToArray()

        lineList.Add(line)

        billPayment.Line = lineList.ToArray()

        Return billPayment
    End Function

    Friend Shared Function UpdateBillPayment(context As ServiceContext, entity As BillPayment) As BillPayment
        'update the properties of entity
        entity.PrivateNote = "Updated PrivateNote"

        Dim bankAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        Dim billPaymentCheck As New BillPaymentCheck()
        billPaymentCheck.BankAccountRef = New ReferenceType() With {
                .name = bankAccount.Name,
                .Value = bankAccount.Id
            }

        Dim checkPayment As New CheckPayment()
        checkPayment.AcctNum = "AcctNum" + Helper.GetGuid().Substring(0, 5)
        checkPayment.BankName = "BankName" + Helper.GetGuid().Substring(0, 5)
        checkPayment.CheckNum = "CheckNum" + Helper.GetGuid().Substring(0, 5)
        checkPayment.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5)
        checkPayment.Status = "Status" + Helper.GetGuid().Substring(0, 5)
        billPaymentCheck.CheckDetail = checkPayment

        Dim payeeAddr As New PhysicalAddress()
        payeeAddr.Line1 = "Line 1"
        payeeAddr.Line2 = "Line 2"
        payeeAddr.City = "Mountain View"
        payeeAddr.CountrySubDivisionCode = "CA"
        payeeAddr.PostalCode = "94043"
        billPaymentCheck.PayeeAddr = payeeAddr
        billPaymentCheck.PrintStatus = PrintStatusEnum.NeedToPrint
        billPaymentCheck.PrintStatusSpecified = True
        entity.AnyIntuitObject = billPaymentCheck
        Return entity
    End Function

    Friend Shared Function UpdateBillPaymentSparse(context As ServiceContext, id As String, syncToken As String) As BillPayment
        Dim entity As New BillPayment()
        entity.Id = id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.PrivateNote = "Updated PrivateNote"
        Return entity
    End Function

    Friend Shared Function CreateDeposit(context As ServiceContext) As Deposit
        Dim deposit As New Deposit()
        Dim bankAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        deposit.DepositToAccountRef = New ReferenceType() With {
                .name = bankAccount.Name,
                .Value = bankAccount.Id
            }

        deposit.TotalAmt = New [Decimal](100.0)
        deposit.TotalAmtSpecified = True

        deposit.TxnDate = DateTime.UtcNow.[Date]
        deposit.TxnDateSpecified = True

        deposit.ExchangeRate = New [Decimal](1.0)
        deposit.ExchangeRateSpecified = True
        deposit.PrivateNote = "PrivateNote" + Helper.GetGuid().Substring(0, 8)




        Dim lineList As New List(Of Line)()
        Dim line As New Line()
        'line.LineNum = "LineNum";
        line.Description = "Description"
        line.Amount = New [Decimal](100.0)
        line.AmountSpecified = True

        line.DetailType = LineDetailTypeEnum.DepositLineDetail
        line.DetailTypeSpecified = True

        Dim lineDepositLineDetail As New DepositLineDetail()

        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
        'add customer/job detail
        lineDepositLineDetail.Entity = New ReferenceType() With {
                .name = customer.DisplayName,
                .Value = customer.Id
            }

        Dim incomeAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Income, AccountClassificationEnum.Revenue)
        'add account detail
        lineDepositLineDetail.AccountRef = New ReferenceType() With {
                .name = incomeAccount.Name,
                .Value = incomeAccount.Id
            }

        Dim paymentMethod As PaymentMethod = Helper.FindOrAddPaymentMethod(context, PaymentMethodEnum.Cash.ToString())
        'add paymentMethod 

        lineDepositLineDetail.PaymentMethodRef = New ReferenceType() With {
                .name = paymentMethod.Name,
                .Value = paymentMethod.Id
            }

        line.AnyIntuitObject = lineDepositLineDetail
        lineList.Add(line)
        deposit.Line = lineList.ToArray()



        Return deposit
    End Function



    Friend Shared Function UpdateDeposit(context As ServiceContext, entity As Deposit) As Deposit
        'update the properties of entity
        entity.PrivateNote = "upd_Note" + Helper.GetGuid().Substring(0, 8)

        Return entity
    End Function


    Friend Shared Function UpdateDepositSparse(context As ServiceContext, id As String, syncToken As String) As Deposit
        Dim entity As New Deposit()
        entity.Id = id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.PrivateNote = "spa_Note" + Helper.GetGuid().Substring(0, 8)
        Dim bankAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        entity.DepositToAccountRef = New ReferenceType() With {
                .name = bankAccount.Name,
                .Value = bankAccount.Id
            }


        Return entity
    End Function

    Friend Shared Function CreateTransfer(context As ServiceContext) As Transfer
        Dim transfer As New Transfer()
        Dim depositAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        transfer.FromAccountRef = New ReferenceType() With {
                .name = depositAccount.Name,
                .Value = depositAccount.Id
            }
        Dim creditAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.CreditCard, AccountClassificationEnum.Liability)
        transfer.ToAccountRef = New ReferenceType() With {
                .name = creditAccount.Name,
                .Value = creditAccount.Id
            }
        transfer.Amount = New [Decimal](100.0)
        transfer.AmountSpecified = True

        Return transfer
    End Function



    Friend Shared Function UpdateTransfer(context As ServiceContext, entity As Transfer) As Transfer
        'update the properties of entity
        entity.Amount = New [Decimal](200.0)
        entity.AmountSpecified = True

        Return entity
    End Function

    Friend Shared Function UpdateTransferSparse(context As ServiceContext, id As String, syncToken As String) As Transfer
        Dim entity As New Transfer()
        entity.Id = id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.Amount = New [Decimal](200.0)
        entity.AmountSpecified = True

        Return entity
    End Function



    Friend Shared Function CreatePurchaseOrder(context As ServiceContext) As PurchaseOrder
        Dim vendors As Vendor = Helper.FindOrAdd(Of Vendor)(context, New Vendor())
        Dim accountsForDetail As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense)

        Dim purchaseOrder As New PurchaseOrder()



        purchaseOrder.VendorRef = New ReferenceType() With {
                .name = vendors.DisplayName,
                .Value = vendors.Id
            }

        purchaseOrder.TotalAmt = New [Decimal](10.0)
        purchaseOrder.TotalAmtSpecified = True

        purchaseOrder.TxnDate = DateTime.UtcNow.[Date]
        purchaseOrder.TxnDateSpecified = True

        Dim lineList As New List(Of Line)()
        Dim line As New Line()
        line.LineNum = "1"

        line.Amount = New [Decimal](10.0)
        line.AmountSpecified = True


        line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail
        line.DetailTypeSpecified = True
        Dim accountBasedExpenseDetails As New AccountBasedExpenseLineDetail()
        accountBasedExpenseDetails.AccountRef = New ReferenceType() With {
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Account),
                .name = accountsForDetail.Name,
                .Value = accountsForDetail.Id
            }

        line.AnyIntuitObject = accountBasedExpenseDetails


        lineList.Add(line)
        purchaseOrder.Line = lineList.ToArray()

        'purchaseOrder.POStatus = PurchaseOrderStatusEnum.Open;
        'purchaseOrder.POStatusSpecified = true;

        Return purchaseOrder
    End Function



    Friend Shared Function UpdatePurchaseOrder(context As ServiceContext, entity As PurchaseOrder) As PurchaseOrder
        'update the properties of entity
        entity.DocNumber = Helper.GetGuid().Substring(0, 13)
        Return entity
    End Function

    Friend Shared Function UpdatePurchaseOrderSparse(context As ServiceContext, Id As String, SyncToken As String) As PurchaseOrder
        Dim entity As New PurchaseOrder()
        entity.Id = Id
        entity.SyncToken = SyncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.DocNumber = Helper.GetGuid().Substring(0, 13)
        Return entity
    End Function



    Friend Shared Function CreateCreditMemo(context As ServiceContext) As CreditMemo
        Dim creditMemo As New CreditMemo()

        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
        creditMemo.CustomerRef = New ReferenceType() With {
                .name = customer.DisplayName,
                .Value = customer.Id
            }

        creditMemo.TotalAmt = New [Decimal](100.0)
        creditMemo.TotalAmtSpecified = True

        creditMemo.ApplyTaxAfterDiscount = True
        creditMemo.ApplyTaxAfterDiscountSpecified = True

        Dim depositAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        creditMemo.DepositToAccountRef = New ReferenceType() With {
                .name = depositAccount.Name,
                .Value = depositAccount.Id
            }
        creditMemo.DocNumber = "DocNumber" + Helper.GetGuid().Substring(0, 3)


        creditMemo.TxnDate = DateTime.UtcNow.[Date]
        creditMemo.TxnDateSpecified = True


        Dim lineList As New List(Of Line)()
        Dim line1 As New Line()
        line1.LineNum = "1"
        line1.Description = "Description"
        line1.Amount = New [Decimal](100.0)
        line1.AmountSpecified = True


        line1.DetailType = LineDetailTypeEnum.SalesItemLineDetail
        line1.DetailTypeSpecified = True
        Dim item As Item = Helper.FindOrAdd(Of Item)(context, New Item())
        Dim taxcode As TaxCode = Helper.FindOrAdd(Of TaxCode)(context, New TaxCode())
        line1.AnyIntuitObject = New SalesItemLineDetail() With {
                .ItemRef = New ReferenceType() With {
                    .name = item.Name,
                    .Value = item.Id
                },
                .TaxCodeRef = New ReferenceType() With {
                    .name = taxcode.Name,
                    .Value = taxcode.Id
                }
            }


        Dim line2 As New Line()
        line2.Amount = New [Decimal](100.0)
        line2.DetailType = LineDetailTypeEnum.SubTotalLineDetail
        line2.DetailTypeSpecified = True
        lineList.Add(line1)
        lineList.Add(line2)
        creditMemo.Line = lineList.ToArray()

        Return creditMemo
    End Function

    Friend Shared Function UpdateCreditMemo(context As ServiceContext, entity As CreditMemo) As CreditMemo
        'update the properties of entity
        entity.DocNumber = "UpdatedDocNum" + Helper.GetGuid().Substring(0, 3)


        entity.TxnDate = DateTime.UtcNow.[Date].AddDays(2)
        entity.TxnDateSpecified = True
        Return entity
    End Function

    Friend Shared Function UpdateCreditMemoSparse(context As ServiceContext, Id As String, SyncToken As String) As CreditMemo
        'update the properties of entity
        Dim entity As New CreditMemo()
        entity.Id = Id
        entity.SyncToken = SyncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.DocNumber = "UpdatedDocNum" + Helper.GetGuid().Substring(0, 3)


        entity.TxnDate = DateTime.UtcNow.[Date].AddDays(2)
        entity.TxnDateSpecified = True
        Return entity
    End Function

    Friend Shared Function CreateRefundReceipt(context As ServiceContext) As RefundReceipt
        Dim refundReceipt As New RefundReceipt()

        Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
        refundReceipt.CustomerRef = New ReferenceType() With {
                .name = customer.DisplayName,
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Customer),
                .Value = customer.Id
            }

        refundReceipt.ApplyTaxAfterDiscount = True
        refundReceipt.ApplyTaxAfterDiscountSpecified = True

        refundReceipt.PrintStatus = PrintStatusEnum.NotSet
        refundReceipt.PrintStatusSpecified = True

        Dim billEmail As New EmailAddress()
        billEmail.Address = "Address@Intuit.com"
        billEmail.[Default] = True
        billEmail.DefaultSpecified = True
        billEmail.Tag = "Tag"
        refundReceipt.BillEmail = billEmail

        refundReceipt.BalanceSpecified = True

        refundReceipt.PaymentRefNum = "PaymentRefNum"
        refundReceipt.PaymentType = PaymentTypeEnum.CreditCard
        refundReceipt.PaymentTypeSpecified = True

        refundReceipt.DocNumber = "DocNumber"
        refundReceipt.TxnDate = DateTime.UtcNow.[Date]
        refundReceipt.TxnDateSpecified = True

        refundReceipt.PrivateNote = "PrivateNote"

        Dim lineList As New List(Of Line)()
        Dim line As New Line()

        line.Description = "Description12"
        line.Amount = New [Decimal](100.0)
        line.AmountSpecified = True


        line.DetailType = LineDetailTypeEnum.SalesItemLineDetail
        line.DetailTypeSpecified = True
        Dim item As Item = Helper.FindOrAdd(Of Item)(context, New Item())
        Dim taxCode As TaxCode = Helper.FindOrAdd(Of TaxCode)(context, New TaxCode())
        line.AnyIntuitObject = New SalesItemLineDetail() With {
                .ItemRef = New ReferenceType() With {
                    .name = item.Name,
                    .Value = item.Id
                },
                .TaxCodeRef = New ReferenceType() With {
                    .name = taxCode.Name,
                    .Value = taxCode.Id
                }
            }
        Dim line2 As New Line()
        line2.Amount = New [Decimal](100.0)
        line2.DetailType = LineDetailTypeEnum.SubTotalLineDetail
        line2.DetailTypeSpecified = True
        line2.AnyIntuitObject = New SubTotalLineDetail()

        Dim txnTaxDetail As New TxnTaxDetail()

        txnTaxDetail.TxnTaxCodeRef = New ReferenceType() With {
                .name = taxCode.Name,
                .Value = taxCode.Id
            }
        txnTaxDetail.TotalTax = New [Decimal](100.0)
        txnTaxDetail.TotalTaxSpecified = True



        lineList.Add(line)
        refundReceipt.Line = lineList.ToArray()


        Dim account As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Liability)
        refundReceipt.DepositToAccountRef = New ReferenceType() With {
                .name = account.Name,
                .Value = account.Id
            }

        Return refundReceipt
    End Function



    Friend Shared Function UpdateRefundReceipt(context As ServiceContext, entity As RefundReceipt) As RefundReceipt
        entity.PrintStatus = PrintStatusEnum.NeedToPrint
        entity.PrintStatusSpecified = True

        Return entity
    End Function


    Friend Shared Function UpdateRefundReceiptSparse(context As ServiceContext, id As String, syncToken As String) As RefundReceipt
        Dim entity As New RefundReceipt()
        entity.Id = id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.PrintStatus = PrintStatusEnum.NeedToPrint
        entity.PrintStatusSpecified = True

        Return entity
    End Function


    Friend Shared Function CreateCompanyCurrency(context As ServiceContext) As CompanyCurrency
        Dim currency As New CompanyCurrency()

        currency.Active = True
        currency.ActiveSpecified = True
        currency.Code = "AMD"



        Return currency
    End Function








    Friend Shared Function CreateJournalCode(context As ServiceContext, journalCodeType As JournalCodeTypeEnum) As JournalCode
        Dim journalCode As New JournalCode()
        journalCode.Name = "JC" + Helper.GetGuid().Substring(0, 5)

        journalCode.Type = journalCodeType.ToString()

        Return journalCode
    End Function



    Friend Shared Function CreateJournalEntry(context As ServiceContext) As JournalEntry
        Dim journalEntry As New JournalEntry()
        journalEntry.Adjustment = True
        journalEntry.AdjustmentSpecified = True

        journalEntry.DocNumber = "DocNumber" + Helper.GetGuid().Substring(0, 5)
        journalEntry.TxnDate = DateTime.UtcNow.[Date]
        journalEntry.TxnDateSpecified = True


        Dim lineList As New List(Of Line)()

        Dim debitLine As New Line()
        debitLine.Description = "nov portion of rider insurance"
        debitLine.Amount = New [Decimal](100.0)
        debitLine.AmountSpecified = True
        debitLine.DetailType = LineDetailTypeEnum.JournalEntryLineDetail
        debitLine.DetailTypeSpecified = True
        Dim journalEntryLineDetail As New JournalEntryLineDetail()
        journalEntryLineDetail.PostingType = PostingTypeEnum.Debit
        journalEntryLineDetail.PostingTypeSpecified = True
        Dim expenseAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense)
        journalEntryLineDetail.AccountRef = New ReferenceType() With {
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Account),
                .name = expenseAccount.Name,
                .Value = expenseAccount.Id
            }
        debitLine.AnyIntuitObject = journalEntryLineDetail
        lineList.Add(debitLine)

        Dim creditLine As New Line()
        creditLine.Description = "nov portion of rider insurance"
        creditLine.Amount = New [Decimal](100.0)
        creditLine.AmountSpecified = True
        creditLine.DetailType = LineDetailTypeEnum.JournalEntryLineDetail
        creditLine.DetailTypeSpecified = True
        Dim journalEntryLineDetailCredit As New JournalEntryLineDetail()
        journalEntryLineDetailCredit.PostingType = PostingTypeEnum.Credit
        journalEntryLineDetailCredit.PostingTypeSpecified = True
        Dim assetAccount As Account = Helper.FindOrAddAccount(context, AccountTypeEnum.OtherCurrentAsset, AccountClassificationEnum.Asset)
        journalEntryLineDetailCredit.AccountRef = New ReferenceType() With {
                .type = [Enum].GetName(GetType(objectNameEnumType), objectNameEnumType.Account),
                .name = assetAccount.Name,
                .Value = assetAccount.Id
            }
        creditLine.AnyIntuitObject = journalEntryLineDetailCredit
        lineList.Add(creditLine)

        journalEntry.Line = lineList.ToArray()

        Return journalEntry
    End Function


    Friend Shared Function UpdateJournalCode(context As ServiceContext, journalCode As JournalCode) As JournalCode
        'update the properties of JournalCode
        journalCode.Description = "Updated" + Helper.GetGuid().Substring(0, 5)

        Return journalCode
    End Function

    Friend Shared Function UpdateJournalCodeSparse(context As ServiceContext, id As String, syncToken As String) As JournalCode
        Dim entity As New JournalCode()
        entity.Id = id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.Name = "JC_Sparse" + Helper.GetGuid().Substring(0, 5)
        entity.Description = "sparseupdated" + Helper.GetGuid().Substring(0, 5)

        Return entity
    End Function



    Friend Shared Function UpdateJournalEntry(context As ServiceContext, entity As JournalEntry) As JournalEntry
        'update the properties of entity
        entity.DocNumber = "udpated" + Helper.GetGuid().Substring(0, 5)

        Return entity
    End Function


    Friend Shared Function UpdateJournalEntrySparse(context As ServiceContext, id As String, syncToken As String) As JournalEntry
        Dim entity As New JournalEntry()
        entity.Id = id
        entity.SyncToken = syncToken
        entity.sparse = True
        entity.sparseSpecified = True
        entity.DocNumber = "sparseudpated" + Helper.GetGuid().Substring(0, 5)

        Return entity
    End Function




    Friend Shared Function CreateTimeActivity(context As ServiceContext) As TimeActivity
        Dim timeActivity As New TimeActivity()

        timeActivity.TxnDate = DateTime.UtcNow.[Date]
        timeActivity.TxnDateSpecified = True
        timeActivity.NameOf = TimeActivityTypeEnum.Vendor
        timeActivity.NameOfSpecified = True

        Dim vendor As Vendor = Helper.FindOrAdd(context, New Vendor())

        timeActivity.AnyIntuitObject = New ReferenceType() With {
                .name = vendor.DisplayName,
                .Value = vendor.Id
            }
        timeActivity.ItemElementName = ItemChoiceType5.VendorRef

        Dim cust As Customer = Helper.FindOrAdd(context, New Customer())
        timeActivity.CustomerRef = New ReferenceType() With {
                .name = cust.DisplayName,
                .Value = cust.Id
            }

        Dim item As Item = Helper.FindOrAdd(context, New Item())
        timeActivity.ItemRef = New ReferenceType() With {
                .name = item.Name,
                .Value = item.Id
            }

        timeActivity.BillableStatus = BillableStatusEnum.NotBillable
			timeActivity.BillableStatusSpecified = True
			timeActivity.Taxable = False
			timeActivity.TaxableSpecified = True
			timeActivity.HourlyRate = New [Decimal](0.0)
			timeActivity.HourlyRateSpecified = True
			timeActivity.Hours = 10

			timeActivity.HoursSpecified = True
			timeActivity.Minutes = 0

			timeActivity.MinutesSpecified = True

			timeActivity.Description = "Description" + Helper.GetGuid().Substring(0, 5)

			Return timeActivity
		End Function



		Friend Shared Function UpdateTimeActivity(context As ServiceContext, entity As TimeActivity) As TimeActivity
			'update the properties of entity
			entity.Description = "UpdatedDesc" + Helper.GetGuid().Substring(0, 3)
			Return entity
		End Function

		Friend Shared Function UpdateTimeActivitySparse(context As ServiceContext, Id As String, syncToken As String) As TimeActivity
			'update the properties of entity
			Dim entity As New TimeActivity()
			entity.Id = Id
			entity.SyncToken = syncToken
			entity.sparse = True
			entity.sparseSpecified = True
			entity.Description = "UpdatedDesc" + Helper.GetGuid().Substring(0, 3)
			Return entity
		End Function





		Friend Shared Function UpdatePreferences(context As ServiceContext, entity As Preferences) As Preferences
			'update the properties of entity
			Dim salesFormsPrefs As New SalesFormsPrefs()
			salesFormsPrefs.UsingProgressInvoicing = True
			salesFormsPrefs.UsingProgressInvoicingSpecified = True


			salesFormsPrefs.CustomTxnNumbers = False
			salesFormsPrefs.CustomTxnNumbersSpecified = True
			salesFormsPrefs.AllowDeposit = False
			salesFormsPrefs.AllowDepositSpecified = True
			salesFormsPrefs.AllowDiscount = False
			salesFormsPrefs.AllowDiscountSpecified = True
			salesFormsPrefs.AllowEstimates = True
			salesFormsPrefs.AllowEstimatesSpecified = True
			salesFormsPrefs.IPNSupportEnabled = False
			salesFormsPrefs.IPNSupportEnabledSpecified = True

			entity.SalesFormsPrefs = salesFormsPrefs

			'Output only field.  Need to set to null for Update operation.
			entity.OtherPrefs = Nothing

			Return entity
		End Function





		Friend Shared Function CreateAttachable(context As ServiceContext) As Attachable
			Dim attachable As New Attachable()

			attachable.Lat = "25.293112341223"
			attachable.[Long] = "-21.3253249834"
			attachable.PlaceName = "Fake Place"
			attachable.Note = "Attachable note " + Helper.GetGuid().Substring(0, 5)
			

			attachable.Tag = "Attachable tag " + Helper.GetGuid().Substring(0, 5)
			



			Dim customer As Customer = Helper.FindOrAdd(Of Customer)(context, New Customer())
			Dim customerRef As New ReferenceType()
			customerRef.name = customer.DisplayName
			customerRef.Value = customer.Id
			customerRef.type = "Customer"

			Dim vendor As Vendor = Helper.FindOrAdd(Of Vendor)(context, New Vendor())
			Dim vendorRef As New ReferenceType()
			vendorRef.name = vendor.DisplayName
			vendorRef.Value = vendor.Id
			vendorRef.type = "Vendor"

			Dim attachableRef1 As New AttachableRef()
			attachableRef1.EntityRef = customerRef
			Dim attachableRef2 As New AttachableRef()
			attachableRef2.EntityRef = vendorRef

			Dim list As New List(Of AttachableRef)()
			list.Add(attachableRef1)
			list.Add(attachableRef2)

			attachable.AttachableRef = list.ToArray()
			Return attachable
		End Function

		Friend Shared Function CreateAttachableUpload(context As ServiceContext) As Attachable
			Dim attachable As New Attachable()

			attachable.Lat = "25.293112341223"
			attachable.[Long] = "-21.3253249834"
			attachable.PlaceName = "Fake Place"
			attachable.Note = "Attachable note " + Helper.GetGuid().Substring(0, 5)
			attachable.Tag = "Attachable tag " + Helper.GetGuid().Substring(0, 5)

			'For attaching to Invoice or Bill or any Txn entity, Uncomment and replace the Id and type of the Txn in below code
			Dim attachments As AttachableRef() = New AttachableRef(0) {}
			Dim ar As New AttachableRef()
			ar.EntityRef = New ReferenceType()
			ar.EntityRef.type = objectNameEnumType.Invoice.ToString()
			ar.EntityRef.name = objectNameEnumType.Invoice.ToString()
			ar.EntityRef.Value = "3535"
			'Add the Id of your invoice here
			'''/ar.EntityRef.type = objectNameEnumType.Bill.ToString();
			'''/ar.EntityRef.name = objectNameEnumType.Bill.ToString();
			'''/ar.EntityRef.Value = "1484";
			attachments(0) = ar
			attachable.AttachableRef = attachments

			Return attachable
		End Function


		Friend Shared Function UpdateAttachable(context As ServiceContext, entity As Attachable) As Attachable
			'update the properties of entity
			entity.Note = "Attachable note " + Helper.GetGuid().Substring(0, 5)
			

			entity.Tag = "Attachable tag " + Helper.GetGuid().Substring(0, 5)
			


			Return entity
		End Function


		Friend Shared Function SparseUpdateAttachable(context As ServiceContext, Id As String, syncToken As String) As Attachable
			Dim entity As New Attachable()
			entity.Id = Id
			entity.SyncToken = syncToken
			entity.Note = "Sparse Attachable note " + Helper.GetGuid().Substring(0, 5)
			

			entity.Tag = "Sparse Attachable tag " + Helper.GetGuid().Substring(0, 5)
			


			Return entity
		End Function





		Friend Shared Function CreateCustomer(context As ServiceContext) As Customer

			Dim guid As [String] = Helper.GetGuid()
			Dim customer As New Customer()
			customer.Taxable = False
			customer.TaxableSpecified = True
			Dim billAddr As New PhysicalAddress()
			billAddr.Line1 = "Line1"
			billAddr.Line2 = "Line2"
			billAddr.Line3 = "Line3"
			billAddr.Line4 = "Line4"
			billAddr.Line5 = "Line5"
			billAddr.City = "City"
			billAddr.Country = "Country"

			billAddr.CountrySubDivisionCode = "CountrySubDivisionCode"
			billAddr.PostalCode = "PostalCode"

			customer.BillAddr = billAddr
			Dim shipAddr As New PhysicalAddress()
			shipAddr.Line1 = "Line1"
			shipAddr.Line2 = "Line2"
			shipAddr.Line3 = "Line3"
			shipAddr.Line4 = "Line4"
			shipAddr.Line5 = "Line5"
			shipAddr.City = "City"
			shipAddr.Country = "Country"

			shipAddr.CountrySubDivisionCode = "CountrySubDivisionCode"
			shipAddr.PostalCode = "PostalCode"

			customer.ShipAddr = shipAddr

			Dim otherAddrList As New List(Of PhysicalAddress)()
			Dim otherAddr As New PhysicalAddress()
			otherAddr.Line1 = "Line1"
			otherAddr.Line2 = "Line2"
			otherAddr.Line3 = "Line3"
			otherAddr.Line4 = "Line4"
			otherAddr.Line5 = "Line5"
			otherAddr.City = "City"
			otherAddr.Country = "Country"

			otherAddr.CountrySubDivisionCode = "CountrySubDivisionCode"
			otherAddr.PostalCode = "PostalCode"

			otherAddrList.Add(otherAddr)
			customer.OtherAddr = otherAddrList.ToArray()

			customer.Notes = "Notes"
			customer.Job = False
			customer.JobSpecified = True
			customer.BillWithParent = False
			customer.BillWithParentSpecified = True

			customer.Balance = New [Decimal](100.0)
			customer.BalanceSpecified = True


			customer.BalanceWithJobs = New [Decimal](100.0)
			customer.BalanceWithJobsSpecified = True

			customer.PreferredDeliveryMethod = "Print"
			customer.ResaleNum = "ResaleNum"

			customer.Title = "Title"
			customer.GivenName = "GivenName"
			customer.MiddleName = "MiddleName"
			customer.FamilyName = "FamilyName"
			customer.Suffix = "Suffix"
			customer.FullyQualifiedName = "Name_" + guid
			customer.CompanyName = "CompanyName"
			customer.DisplayName = "Name_" + guid
			customer.PrintOnCheckName = "PrintOnCheckName"

			customer.Active = True
			customer.ActiveSpecified = True
			Dim primaryPhone As New TelephoneNumber()

			primaryPhone.FreeFormNumber = "FreeFormNumber"

			customer.PrimaryPhone = primaryPhone
			Dim alternatePhone As New TelephoneNumber()

			alternatePhone.FreeFormNumber = "FreeFormNumber"

			customer.AlternatePhone = alternatePhone
			Dim mobile As New TelephoneNumber()

			mobile.FreeFormNumber = "FreeFormNumber"

			customer.Mobile = mobile
			Dim fax As New TelephoneNumber()

			fax.FreeFormNumber = "FreeFormNumber"

			customer.Fax = fax
			Dim primaryEmailAddr As New EmailAddress()
			primaryEmailAddr.Address = "test@tesing.com"

			customer.PrimaryEmailAddr = primaryEmailAddr
			Dim webAddr As New WebSiteAddress()
			webAddr.URI = "http://uri.com"

			customer.WebAddr = webAddr

			Return customer
		End Function



		Friend Shared Function UpdateCustomer(context As ServiceContext, entity As Customer) As Customer
			'update the properties of entity
			entity.GivenName = "ChangedName"
			Return entity
		End Function



		Friend Shared Function SparseUpdateCustomer(context As ServiceContext, Id As String, syncToken As String) As Customer
			Dim entity As New Customer()
			entity.Id = Id
			entity.SyncToken = syncToken
			entity.sparse = True
			entity.sparseSpecified = True
			entity.MiddleName = "Sparse" + Helper.GetGuid().Substring(0, 5)
			Return entity
		End Function




		Friend Shared Function CreateVendor(context As ServiceContext) As Vendor
			Dim vendor As New Vendor()

			Dim billAddr As New PhysicalAddress()
			billAddr.Line1 = "Line1"
			billAddr.Line2 = "Line2"
			billAddr.Line3 = "Line3"
			billAddr.Line4 = "Line4"
			billAddr.Line5 = "Line5"
			billAddr.City = "City"
			billAddr.Country = "Country"

			billAddr.CountrySubDivisionCode = "CountrySubDivisionCode"
			billAddr.PostalCode = "PostalCode"

			vendor.BillAddr = billAddr

			vendor.TaxIdentifier = "TaxIdentifier"

			vendor.Balance = New [Decimal](100.0)
			vendor.BalanceSpecified = True
			vendor.OpenBalanceDate = DateTime.UtcNow.[Date]
			vendor.OpenBalanceDateSpecified = True

			vendor.AcctNum = "AcctNum"
			vendor.Vendor1099 = True
			vendor.Vendor1099Specified = True

			vendor.Title = "Title"
			vendor.GivenName = "GivenName"
			vendor.MiddleName = "MiddleName"
			vendor.FamilyName = "FamilyName"
			vendor.Suffix = "Suffix"


			vendor.CompanyName = "CompanyName"
			vendor.DisplayName = "DisplayName_" + Helper.GetGuid()
			vendor.PrintOnCheckName = "PrintOnCheckName"

			vendor.Active = True
			vendor.ActiveSpecified = True
			Dim primaryPhone As New TelephoneNumber()

			primaryPhone.FreeFormNumber = "FreeFormNumber"

			vendor.PrimaryPhone = primaryPhone
			Dim alternatePhone As New TelephoneNumber()

			alternatePhone.FreeFormNumber = "FreeFormNumber"

			vendor.AlternatePhone = alternatePhone
			Dim mobile As New TelephoneNumber()

			mobile.FreeFormNumber = "FreeFormNumber"

			vendor.Mobile = mobile
			Dim fax As New TelephoneNumber()

			fax.FreeFormNumber = "FreeFormNumber"

			vendor.Fax = fax
			Dim primaryEmailAddr As New EmailAddress()
			primaryEmailAddr.Address = "Address@add.com"

			vendor.PrimaryEmailAddr = primaryEmailAddr
			Dim webAddr As New WebSiteAddress()
			webAddr.URI = "http://site.com"

			vendor.WebAddr = webAddr

			Return vendor
		End Function




		Friend Shared Function UpdateVendor(context As ServiceContext, entity As Vendor) As Vendor
			entity.Title = "Title updated"
			entity.GivenName = "GivenName updated"
			entity.MiddleName = "MiddleName updated"
			entity.FamilyName = "FamilyName updated"
			entity.Suffix = "Mr."
			Return entity
		End Function





		Friend Shared Function SparseUpdateVendor(context As ServiceContext, id As String, syncToken As String) As Vendor
			Dim entity As New Vendor()
			entity.Id = id
			entity.SyncToken = syncToken
			entity.sparse = True
			entity.sparseSpecified = True
			entity.GivenName = "sparse" + Helper.GetGuid().Substring(0, 5)
			entity.MiddleName = "sparse" + Helper.GetGuid().Substring(0, 5)
			entity.FamilyName = "sparse" + Helper.GetGuid().Substring(0, 5)
			Return entity
		End Function





		Friend Shared Function CreateEmployee(context As ServiceContext) As Employee
			Dim employee As New Employee()
			employee.EmployeeType = EmployeeTypeEnum.Regular.ToString()
			employee.EmployeeNumber = "ENO" + Helper.GetGuid().Substring(0, 6)
			employee.SSN = "111-22-3333"

			employee.BirthDate = DateTime.UtcNow.[Date]
			employee.BirthDateSpecified = True
			employee.Gender = gender.Male


			employee.GenderSpecified = True
			employee.HiredDate = DateTime.UtcNow.[Date]
			employee.HiredDateSpecified = True
			employee.ReleasedDate = DateTime.UtcNow.[Date]
			employee.ReleasedDateSpecified = True
			employee.UseTimeEntry = TimeEntryUsedForPaychecksEnum.UseTimeEntry

			employee.Organization = True
			employee.OrganizationSpecified = True
			employee.Title = "Title"
			employee.GivenName = "GivenName" + Helper.GetGuid().Substring(0, 8)
			employee.MiddleName = "MiddleName" + Helper.GetGuid().Substring(0, 8)
			employee.FamilyName = "FamilyName" + Helper.GetGuid().Substring(0, 8)
			employee.CompanyName = "CompanyName" + Helper.GetGuid().Substring(0, 8)
			employee.DisplayName = "DisplayName" + Helper.GetGuid().Substring(0, 8)
			employee.PrintOnCheckName = "PrintOnCheckName" + Helper.GetGuid().Substring(0, 8)
			

			employee.UserId = "UserId" + Helper.GetGuid().Substring(0, 8)
			

			employee.Active = True
			employee.ActiveSpecified = True

			Return employee
		End Function



		Friend Shared Function UpdateEmployee(context As ServiceContext, entity As Employee) As Employee
			'update the properties of entity
			entity.GivenName = "updated" + Helper.GetGuid().Substring(0, 8)
			entity.MiddleName = "updated" + Helper.GetGuid().Substring(0, 8)
			entity.FamilyName = "updated" + Helper.GetGuid().Substring(0, 8)
			entity.CompanyName = "updated" + Helper.GetGuid().Substring(0, 8)
			Return entity
		End Function


		Friend Shared Function SparseUpdateEmployee(context As ServiceContext, Id As String, syncToken As String) As Employee
			Dim entity As New Employee()
			entity.Id = Id
			entity.SyncToken = syncToken
			entity.sparse = True
			entity.sparseSpecified = True
			entity.GivenName = "sparseupdated" + Helper.GetGuid().Substring(0, 8)
			Return entity
		End Function





		#End Region



	End Class
