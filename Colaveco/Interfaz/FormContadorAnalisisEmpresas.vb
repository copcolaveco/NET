Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections


Public Class FormContadorAnalisisEmpresas

    Dim i2 As Integer

#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarempresas()
    End Sub
#End Region
    Private Sub cargarempresas()
        ComboEmpresas.Items.Add("Seleccione una empresa")
        ComboEmpresas.Items.Add("CALCAR CARMELO")
        ComboEmpresas.Items.Add("CALCAR TARARIRAS")
        ComboEmpresas.Items.Add("CALDEM")
        ComboEmpresas.Items.Add("DULEI")
        ComboEmpresas.Items.Add("ECOLAT")
        ComboEmpresas.Items.Add("GRANJA BRASSETTI")
        ComboEmpresas.Items.Add("INDULACSA CARDONA")
        ComboEmpresas.Items.Add("INDULACSA SALTO")
        ComboEmpresas.Items.Add("LA MAGNOLIA")
        ComboEmpresas.Items.Add("NATURALIA")
        ComboEmpresas.Items.Add("PINEROLO")
    End Sub
    Private Sub ecolat()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\ECOLAT\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\ECOLAT\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\ECOLAT\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If
                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1
                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next
                End If
            End If
        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub calcar_carmelo()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR CARMELO\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR CARMELO\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR CARMELO\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(18, 14).formula) <> "" Then
                                If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                                Else
                                    rc = rc + 1
                                    contrc = contrc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                                Else
                                    rb = rb + 1
                                    contrb = contrb + 1
                                End If
                                If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                                Else
                                    gr = gr + 1
                                    contgr = contgr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                                Else
                                    pr = pr + 1
                                    contpr = contpr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                                Else
                                    lc = lc + 1
                                    contlc = contlc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                                Else
                                    st = st + 1
                                    contst = contst + 1
                                End If
                                If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                                Else
                                    cr = cr + 1
                                    contcr = contcr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                                Else
                                    ur = ur + 1
                                    contur = contur + 1
                                End If
                                If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                                Else
                                    inh = inh + 1
                                    continh = continh + 1
                                End If
                                If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                                Else
                                    esp = esp + 1
                                    contesp = contesp + 1
                                End If
                                If Trim(x1hoja.Cells(i, 13).formula) = "" Or Trim(x1hoja.Cells(i, 13).formula) = "-" Then
                                Else
                                    psi = psi + 1
                                    contpsi = contpsi + 1
                                End If

                            Else


                                If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                                Else
                                    rc = rc + 1
                                    contrc = contrc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                                Else
                                    rb = rb + 1
                                    contrb = contrb + 1
                                End If
                                If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                                Else
                                    gr = gr + 1
                                    contgr = contgr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                                Else
                                    pr = pr + 1
                                    contpr = contpr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                                Else
                                    lc = lc + 1
                                    contlc = contlc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                                Else
                                    st = st + 1
                                    contst = contst + 1
                                End If
                                If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                                Else
                                    cr = cr + 1
                                    contcr = contcr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                                Else
                                    ur = ur + 1
                                    contur = contur + 1
                                End If
                                If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                                Else
                                    inh = inh + 1
                                    continh = continh + 1
                                End If
                                If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                                Else
                                    esp = esp + 1
                                    contesp = contesp + 1
                                End If
                                If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                                Else
                                    psi = psi + 1
                                    contpsi = contpsi + 1
                                End If

                            End If
                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub calcar_tarariras()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR TARARIRAS\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR TARARIRAS\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR TARARIRAS\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(18, 14).formula) <> "" Then
                                If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                                Else
                                    rc = rc + 1
                                    contrc = contrc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                                Else
                                    rb = rb + 1
                                    contrb = contrb + 1
                                End If
                                If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                                Else
                                    gr = gr + 1
                                    contgr = contgr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                                Else
                                    pr = pr + 1
                                    contpr = contpr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                                Else
                                    lc = lc + 1
                                    contlc = contlc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                                Else
                                    st = st + 1
                                    contst = contst + 1
                                End If
                                If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                                Else
                                    cr = cr + 1
                                    contcr = contcr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                                Else
                                    ur = ur + 1
                                    contur = contur + 1
                                End If
                                If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                                Else
                                    inh = inh + 1
                                    continh = continh + 1
                                End If
                                If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                                Else
                                    esp = esp + 1
                                    contesp = contesp + 1
                                End If
                                If Trim(x1hoja.Cells(i, 13).formula) = "" Or Trim(x1hoja.Cells(i, 13).formula) = "-" Then
                                Else
                                    psi = psi + 1
                                    contpsi = contpsi + 1
                                End If

                            Else


                                If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                                Else
                                    rc = rc + 1
                                    contrc = contrc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                                Else
                                    rb = rb + 1
                                    contrb = contrb + 1
                                End If
                                If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                                Else
                                    gr = gr + 1
                                    contgr = contgr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                                Else
                                    pr = pr + 1
                                    contpr = contpr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                                Else
                                    lc = lc + 1
                                    contlc = contlc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                                Else
                                    st = st + 1
                                    contst = contst + 1
                                End If
                                If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                                Else
                                    cr = cr + 1
                                    contcr = contcr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                                Else
                                    ur = ur + 1
                                    contur = contur + 1
                                End If
                                If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                                Else
                                    inh = inh + 1
                                    continh = continh + 1
                                End If
                                If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                                Else
                                    esp = esp + 1
                                    contesp = contesp + 1
                                End If
                                If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                                Else
                                    psi = psi + 1
                                    contpsi = contpsi + 1
                                End If

                            End If
                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub caldem()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALDEM\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALDEM\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALDEM\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then

                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If


                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub dulei()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\DULEI\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\DULEI\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\DULEI\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then

                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If


                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub brassetti()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\GRANJA BRASSETTI\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\GRANJA BRASSETTI\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\GRANJA BRASSETTI\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then

                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If


                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub indulacsac()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CARDONA INDULACSA\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CARDONA INDULACSA\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CARDONA INDULACSA\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then

                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If


                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub indulacsas()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\SALTO INDULACSA\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\SALTO INDULACSA\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\SALTO INDULACSA\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then

                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If


                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub magnolia()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\LA MAGNOLIA\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\LA MAGNOLIA\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\LA MAGNOLIA\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then

                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If


                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub naturalia()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\NATURALIA\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\NATURALIA\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\NATURALIA\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then

                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If


                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub pinerolo()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim timbres As Integer = 0
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\PINEROLO\NET")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(100)
        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\PINEROLO\NET\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()


            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0




            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                'Dim c As New dImpCalidad()
                Dim Arch As String ', CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\PINEROLO\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                'CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try


                ficha = Mid(file.Name, 1, Len(file.Name) - 4)


                'fecha = Trim(x1hoja.Cells(11, 3).value)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)

                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then

                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If


                        Else
                            Exit For
                        End If
                    Next
                    DataGridView1(columna, fila).Value = ficha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = rb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = gr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = st
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = inh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = psi
                    columna = 0
                    fila = fila + 1
                    timbres = timbres + 1

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()

                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()

                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()

                    Next
                End If

            End If

        Next
        columna = 1
        DataGridView1(columna, fila).Value = "Total"
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contrb
        columna = columna + 1
        DataGridView1(columna, fila).Value = contgr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contlc
        columna = columna + 1
        DataGridView1(columna, fila).Value = contst
        columna = columna + 1
        DataGridView1(columna, fila).Value = contcr
        columna = columna + 1
        DataGridView1(columna, fila).Value = contur
        columna = columna + 1
        DataGridView1(columna, fila).Value = continh
        columna = columna + 1
        DataGridView1(columna, fila).Value = contesp
        columna = columna + 1
        DataGridView1(columna, fila).Value = contpsi
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Timbres:"
        columna = columna + 1
        DataGridView1(columna, fila).Value = timbres
    End Sub
    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        DataGridView1.Rows.Clear()
        If ComboEmpresas.Text = "CALCAR CARMELO" Then
            calcar_carmelo()
        ElseIf ComboEmpresas.Text = "CALCAR TARARIRAS" Then
            calcar_tarariras()
        ElseIf ComboEmpresas.Text = "CALDEM" Then
            caldem()
        ElseIf ComboEmpresas.Text = "DULEI" Then
            dulei()
        ElseIf ComboEmpresas.Text = "ECOLAT" Then
            ecolat()
        ElseIf ComboEmpresas.Text = "GRANJA BRASSETTI" Then
            brassetti()
        ElseIf ComboEmpresas.Text = "INDULACSA CARDONA" Then
            indulacsac()
        ElseIf ComboEmpresas.Text = "INDULACSA SALTO" Then
            indulacsas()
        ElseIf ComboEmpresas.Text = "LA MAGNOLIA" Then
            magnolia()
        ElseIf ComboEmpresas.Text = "NATURALIA" Then
            naturalia()
        ElseIf ComboEmpresas.Text = "PINEROLO" Then
            pinerolo()
        End If

    End Sub

    Private Sub ButtonImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
        If ComboEmpresas.Text = "CALCAR CARMELO" Then
            imprimir_calcar_carmelo()
        ElseIf ComboEmpresas.Text = "CALCAR TARARIRAS" Then
            imprimir_calcar_tarariras()
        ElseIf ComboEmpresas.Text = "CALDEM" Then
            imprimir_caldem()
        ElseIf ComboEmpresas.Text = "DULEI" Then
            imprimir_dulei()
        ElseIf ComboEmpresas.Text = "ECOLAT" Then
            imprimir_ecolat()
        ElseIf ComboEmpresas.Text = "GRANJA BRASSETTI" Then
            imprimir_brassetti()
        ElseIf ComboEmpresas.Text = "INDULACSA CARDONA" Then
            imprimir_indulacsac()
        ElseIf ComboEmpresas.Text = "INDULACSA SALTO" Then
            imprimir_indulacsas()
        ElseIf ComboEmpresas.Text = "LA MAGNOLIA" Then
            imprimir_magnolia()
        ElseIf ComboEmpresas.Text = "NATURALIA" Then
            imprimir_naturalia()
        ElseIf ComboEmpresas.Text = "PINEROLO" Then
            imprimir_pinerolo()
        End If

    End Sub
    Private Sub imprimir_ecolat()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\ecolat.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\ECOLAT\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\ECOLAT\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\ECOLAT\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_calcar_carmelo()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\calcar_carmelo.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR CARMELO\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR CARMELO\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR CARMELO\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(18, 14).formula) <> "" Then
                                If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                                Else
                                    rc = rc + 1
                                    contrc = contrc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                                Else
                                    rb = rb + 1
                                    contrb = contrb + 1
                                End If
                                If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                                Else
                                    gr = gr + 1
                                    contgr = contgr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                                Else
                                    pr = pr + 1
                                    contpr = contpr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                                Else
                                    lc = lc + 1
                                    contlc = contlc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                                Else
                                    st = st + 1
                                    contst = contst + 1
                                End If
                                If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                                Else
                                    cr = cr + 1
                                    contcr = contcr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                                Else
                                    ur = ur + 1
                                    contur = contur + 1
                                End If
                                If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                                Else
                                    inh = inh + 1
                                    continh = continh + 1
                                End If
                                If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                                Else
                                    esp = esp + 1
                                    contesp = contesp + 1
                                End If
                                If Trim(x1hoja.Cells(i, 13).formula) = "" Or Trim(x1hoja.Cells(i, 13).formula) = "-" Then
                                Else
                                    psi = psi + 1
                                    contpsi = contpsi + 1
                                End If

                            Else


                                If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                                Else
                                    rc = rc + 1
                                    contrc = contrc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                                Else
                                    rb = rb + 1
                                    contrb = contrb + 1
                                End If
                                If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                                Else
                                    gr = gr + 1
                                    contgr = contgr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                                Else
                                    pr = pr + 1
                                    contpr = contpr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                                Else
                                    lc = lc + 1
                                    contlc = contlc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                                Else
                                    st = st + 1
                                    contst = contst + 1
                                End If
                                If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                                Else
                                    cr = cr + 1
                                    contcr = contcr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                                Else
                                    ur = ur + 1
                                    contur = contur + 1
                                End If
                                If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                                Else
                                    inh = inh + 1
                                    continh = continh + 1
                                End If
                                If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                                Else
                                    esp = esp + 1
                                    contesp = contesp + 1
                                End If
                                If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                                Else
                                    psi = psi + 1
                                    contpsi = contpsi + 1
                                End If

                            End If
                        Else
                            Exit For
                        End If
                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_calcar_tarariras()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\calcar_tarariras.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR TARARIRAS\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR TARARIRAS\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALCAR TARARIRAS\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(18, 14).formula) <> "" Then
                                If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                                Else
                                    rc = rc + 1
                                    contrc = contrc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                                Else
                                    rb = rb + 1
                                    contrb = contrb + 1
                                End If
                                If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                                Else
                                    gr = gr + 1
                                    contgr = contgr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                                Else
                                    pr = pr + 1
                                    contpr = contpr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                                Else
                                    lc = lc + 1
                                    contlc = contlc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                                Else
                                    st = st + 1
                                    contst = contst + 1
                                End If
                                If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                                Else
                                    cr = cr + 1
                                    contcr = contcr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                                Else
                                    ur = ur + 1
                                    contur = contur + 1
                                End If
                                If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                                Else
                                    inh = inh + 1
                                    continh = continh + 1
                                End If
                                If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                                Else
                                    esp = esp + 1
                                    contesp = contesp + 1
                                End If
                                If Trim(x1hoja.Cells(i, 13).formula) = "" Or Trim(x1hoja.Cells(i, 13).formula) = "-" Then
                                Else
                                    psi = psi + 1
                                    contpsi = contpsi + 1
                                End If

                            Else


                                If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                                Else
                                    rc = rc + 1
                                    contrc = contrc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                                Else
                                    rb = rb + 1
                                    contrb = contrb + 1
                                End If
                                If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                                Else
                                    gr = gr + 1
                                    contgr = contgr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                                Else
                                    pr = pr + 1
                                    contpr = contpr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                                Else
                                    lc = lc + 1
                                    contlc = contlc + 1
                                End If
                                If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                                Else
                                    st = st + 1
                                    contst = contst + 1
                                End If
                                If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                                Else
                                    cr = cr + 1
                                    contcr = contcr + 1
                                End If
                                If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                                Else
                                    ur = ur + 1
                                    contur = contur + 1
                                End If
                                If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                                Else
                                    inh = inh + 1
                                    continh = continh + 1
                                End If
                                If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                                Else
                                    esp = esp + 1
                                    contesp = contesp + 1
                                End If
                                If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                                Else
                                    psi = psi + 1
                                    contpsi = contpsi + 1
                                End If

                            End If
                        Else
                            Exit For
                        End If
                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_caldem()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\caldem.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALDEM\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALDEM\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CALDEM\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_dulei()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\dulei.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\DULEI\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\DULEI\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\DULEI\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_brassetti()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\brassetti.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\GRANJA BRASSETTI\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\GRANJA BRASSETTI\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\GRANJA BRASSETTI\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_indulacsac()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\cardona_indulacsa.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CARDONA INDULACSA\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CARDONA INDULACSA\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\CARDONA INDULACSA\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_indulacsas()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\salto_indulacsa.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\SALTO INDULACSA\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\SALTO INDULACSA\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\SALTO INDULACSA\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_magnolia()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\la_magnolia.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\LA MAGNOLIA\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\LA MAGNOLIA\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\LA MAGNOLIA\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_naturalia()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\naturalia.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\NATURALIA\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\NATURALIA\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\NATURALIA\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub imprimir_pinerolo()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim oSW As New StreamWriter("c:\empresa\pinerolo.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""
        Dim timbres As Integer = 0
        Dim folder As New DirectoryInfo("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\PINEROLO\NET")
        'Dim folder As New DirectoryInfo("c:\NET")
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim contca As Integer = 0
        Dim contci As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0
        Dim fechaini As Date = DateIni.Value
        Dim fechafin As Date = DateFin.Value
        Dim fechainicial As Date
        Dim fechafinal As Date
        fechainicial = Mid(fechaini, 1, 10)
        fechafinal = Mid(fechafin, 1, 10)
        For Each file As FileInfo In folder.GetFiles("*.xls")
            nombrearchivo = file.Name
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\PINEROLO\NET\" & file.Name)
            'Dim objReader As New StreamReader("c:\NET\" & file.Name)
            Dim sLine As String = ""
            Dim ficha As String = ""
            Dim fecha As Date
            Dim rc As Integer = 0
            Dim rb As Integer = 0
            Dim gr As Integer = 0
            Dim pr As Integer = 0
            Dim lc As Integer = 0
            Dim st As Integer = 0
            Dim cr As Integer = 0
            Dim ur As Integer = 0
            Dim ca As Integer = 0
            Dim ci As Integer = 0
            Dim inh As Integer = 0
            Dim esp As Integer = 0
            Dim psi As Integer = 0
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim Arch As String
                Arch = "\\192.168.1.10\E\Documentos\SECRETARIA\RESULTADOS INFORMES 2013\LECHE\CALIDAD\PINEROLO\NET\" & file.Name
                'Arch = "c:\NET\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim bandera As Integer = 0
                Try
                    x1hoja.Unprotect(Password:="1582782")
                    x1hoja.Unprotect(Password:="pepo")
                Catch ex As Exception

                End Try
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                fecha = Mid((x1hoja.Cells(11, 3).value), 1, 10)
                If fecha >= fechainicial And fecha <= fechafinal Then
                    For i = 18 To 300
                        If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                            If Trim(x1hoja.Cells(i, 2).formula) = "" Or Trim(x1hoja.Cells(i, 2).formula) = "-" Then
                            Else
                                rc = rc + 1
                                contrc = contrc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 3).formula) = "" Or Trim(x1hoja.Cells(i, 3).formula) = "-" Then
                            Else
                                rb = rb + 1
                                contrb = contrb + 1
                            End If
                            If Trim(x1hoja.Cells(i, 4).formula) = "" Or Trim(x1hoja.Cells(i, 4).formula) = "-" Then
                            Else
                                gr = gr + 1
                                contgr = contgr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 5).formula) = "" Or Trim(x1hoja.Cells(i, 5).formula) = "-" Then
                            Else
                                pr = pr + 1
                                contpr = contpr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 6).formula) = "" Or Trim(x1hoja.Cells(i, 6).formula) = "-" Then
                            Else
                                lc = lc + 1
                                contlc = contlc + 1
                            End If
                            If Trim(x1hoja.Cells(i, 7).formula) = "" Or Trim(x1hoja.Cells(i, 7).formula) = "-" Then
                            Else
                                st = st + 1
                                contst = contst + 1
                            End If
                            If Trim(x1hoja.Cells(i, 8).formula) = "" Or Trim(x1hoja.Cells(i, 8).formula) = "-" Then
                            Else
                                cr = cr + 1
                                contcr = contcr + 1
                            End If
                            If Trim(x1hoja.Cells(i, 9).formula) = "" Or Trim(x1hoja.Cells(i, 9).formula) = "-" Then
                            Else
                                ur = ur + 1
                                contur = contur + 1
                            End If
                            If Trim(x1hoja.Cells(i, 10).formula) = "" Or Trim(x1hoja.Cells(i, 10).formula) = "-" Then
                            Else
                                inh = inh + 1
                                continh = continh + 1
                            End If
                            If Trim(x1hoja.Cells(i, 11).formula) = "" Or Trim(x1hoja.Cells(i, 11).formula) = "-" Then
                            Else
                                esp = esp + 1
                                contesp = contesp + 1
                            End If
                            If Trim(x1hoja.Cells(i, 12).formula) = "" Or Trim(x1hoja.Cells(i, 12).formula) = "-" Then
                            Else
                                psi = psi + 1
                                contpsi = contpsi + 1
                            End If

                        Else
                            Exit For
                        End If

                    Next

                    ' Cierro Excel
                    x1app.DisplayAlerts = False
                    x1libro.Close()
                    x1app = Nothing
                    x1libro = Nothing
                    x1hoja = Nothing
                    objReader.Close()
                    Dim proceso As System.Diagnostics.Process()
                    proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    For Each opro As System.Diagnostics.Process In proceso
                        'antes de iniciar el proceso obtengo la fecha en que inicie el 
                        'proceso para detener todos los procesos que excel que inicio
                        'mi código durante el proceso
                        opro.Kill()
                    Next


                    Linea = Linea & ficha + Chr(9)
                    Linea = Linea & fecha & Chr(9)
                    Linea = Linea & rc & Chr(9)
                    Linea = Linea & rb & Chr(9)
                    Linea = Linea & gr & Chr(9)
                    Linea = Linea & pr & Chr(9)
                    Linea = Linea & lc & Chr(9)
                    Linea = Linea & st & Chr(9)
                    Linea = Linea & cr & Chr(9)
                    Linea = Linea & ur & Chr(9)
                    Linea = Linea & inh & Chr(9)
                    Linea = Linea & esp & Chr(9)
                    Linea = Linea & psi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    timbres = timbres + 1



                End If
            End If
        Next
        Linea = Linea & "Total" + Chr(9) + Chr(9)
        Linea = Linea & Chr(9)
        Linea = Linea & contrc & Chr(9)
        Linea = Linea & contrb & Chr(9)
        Linea = Linea & contgr & Chr(9)
        Linea = Linea & contpr & Chr(9)
        Linea = Linea & contlc & Chr(9)
        Linea = Linea & contst & Chr(9)
        Linea = Linea & contcr & Chr(9)
        Linea = Linea & contur & Chr(9)
        Linea = Linea & continh & Chr(9)
        Linea = Linea & contesp & Chr(9)
        Linea = Linea & contpsi & Chr(9)
        oSW.WriteLine(Linea)
        Linea = ""
        Linea = Linea & "Timbres:" + " " & timbres
        oSW.WriteLine(Linea)
        oSW.Flush()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
       
    End Sub
End Class