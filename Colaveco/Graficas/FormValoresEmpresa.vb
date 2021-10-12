Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormValoresEmpresa
#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region


    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If TextIdProductor.Text <> "" Then
            listarxempresa()
        Else
            listartodos()
        End If

    End Sub

    Private Sub ButtonGraficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub listartodos()
        Dim c As New dCalidad
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = c.listarxfecha(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    DataGridView1(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = c.FICHA
                    columna = columna + 1
                    If c.RC <> -1 Then
                        DataGridView1(columna, fila).Value = c.RC
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.GRASA <> -1 Then
                        DataGridView1(columna, fila).Value = c.GRASA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.PROTEINA <> -1 Then
                        DataGridView1(columna, fila).Value = c.PROTEINA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.LACTOSA <> -1 Then
                        DataGridView1(columna, fila).Value = c.LACTOSA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.ST <> -1 Then
                        DataGridView1(columna, fila).Value = c.ST
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.CRIOSCOPIA <> -1 Then
                        DataGridView1(columna, fila).Value = c.CRIOSCOPIA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.UREA <> -1 Then
                        DataGridView1(columna, fila).Value = c.UREA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.PROTEINAV <> -1 Then
                        DataGridView1(columna, fila).Value = c.PROTEINAV
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.CASEINA <> -1 Then
                        DataGridView1(columna, fila).Value = c.CASEINA
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.DENSIDAD <> -1 Then
                        DataGridView1(columna, fila).Value = c.DENSIDAD
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If c.PH <> -1 Then
                        DataGridView1(columna, fila).Value = c.PH
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarxempresa()
        Dim c As New dCalidad
        Dim lista As New ArrayList
        Dim idempresa As Long = TextIdProductor.Text.Trim

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        DataGridView1.Rows.Clear()
        listasa = sa.listarxfechaxproductor(fecdesde, fechasta, idempresa)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        If Not listasa Is Nothing Then
            If listasa.Count > 0 Then
                Dim idficha As Long = 0
                For Each sa In listasa
                    idficha = sa.ID
                    lista = c.listarxficha(idficha)

                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            DataGridView1.Rows.Add(lista.Count)
                            For Each c In lista
                                DataGridView1(columna, fila).Value = c.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = c.FICHA
                                columna = columna + 1
                                If c.RC <> -1 Then
                                    DataGridView1(columna, fila).Value = c.RC
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.GRASA <> -1 Then
                                    DataGridView1(columna, fila).Value = c.GRASA
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.PROTEINA <> -1 Then
                                    DataGridView1(columna, fila).Value = c.PROTEINA
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.LACTOSA <> -1 Then
                                    DataGridView1(columna, fila).Value = c.LACTOSA
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.ST <> -1 Then
                                    DataGridView1(columna, fila).Value = c.ST
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.CRIOSCOPIA <> -1 Then
                                    DataGridView1(columna, fila).Value = c.CRIOSCOPIA
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.UREA <> -1 Then
                                    DataGridView1(columna, fila).Value = c.UREA
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.PROTEINAV <> -1 Then
                                    DataGridView1(columna, fila).Value = c.PROTEINAV
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.CASEINA <> -1 Then
                                    DataGridView1(columna, fila).Value = c.CASEINA
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.DENSIDAD <> -1 Then
                                    DataGridView1(columna, fila).Value = c.DENSIDAD
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = columna + 1
                                End If
                                If c.PH <> -1 Then
                                    DataGridView1(columna, fila).Value = c.PH
                                    columna = 0
                                    fila = fila + 1
                                Else
                                    DataGridView1(columna, fila).Value = "-"
                                    columna = 0
                                    fila = fila + 1
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ButtonBuscarProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        TextIdProductor.Text = ""
        TextNombreProductor.Text = ""

        Dim v As New FormBuscarEmpresa
        v.ShowDialog()

        If Not v.Cliente Is Nothing Then
            Dim pro As dCliente = v.Cliente
            TextIdProductor.Text = pro.ID
            TextNombreProductor.Text = pro.NOMBRE
        End If

    End Sub

    Private Sub ButtonExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportar.Click
        If TextIdProductor.Text <> "" Then
            excelxempresa()
        Else
            exceltodos()
        End If
    End Sub
    Private Sub exceltodos()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 10

        Dim c As New dCalidad
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = c.listarxfecha(fecdesde, fechasta)
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "LISTADO DE CALIDAD DE LECHE - TODAS LAS EMPRESAS - " & fecdesde & " - " & fechasta
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Ficha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "RC"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Grasa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteína"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Lactosa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Sólidos Tot."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Crioscopía"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Urea"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteína V."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Caseína"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Densidad"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "pH"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = 1
        fila = fila + 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                

                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = c.FICHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    If c.RC <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.RC
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.GRASA <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.GRASA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.PROTEINA <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.PROTEINA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.LACTOSA <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.LACTOSA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.ST <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.ST
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.CRIOSCOPIA <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.CRIOSCOPIA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.UREA <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.UREA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.PROTEINAV <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.PROTEINAV
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.CASEINA <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.CASEINA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.DENSIDAD <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.DENSIDAD
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If c.PH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = c.PH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If
                Next
            End If
        End If

        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub excelxempresa()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 10

        Dim c As New dCalidad
        Dim lista As New ArrayList
        Dim idempresa As Long = TextIdProductor.Text.Trim
        Dim nombreempresa As String = TextNombreProductor.Text
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        listasa = sa.listarxfechaxproductor(fecdesde, fechasta, idempresa)
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "LISTADO DE CALIDAD DE LECHE - " & nombreempresa & " - " & fecdesde & " - " & fechasta
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Ficha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "RC"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Grasa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteína"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Lactosa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Sólidos Tot."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Crioscopía"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Urea"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteína V."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Caseína"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Densidad"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "pH"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = 1
        fila = fila + 1

        If Not listasa Is Nothing Then
            If listasa.Count > 0 Then
                Dim idficha As Long = 0
                For Each sa In listasa
                    idficha = sa.ID
                    lista = c.listarxficha(idficha)
                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            For Each c In lista
                                x1hoja.Cells(fila, columna).formula = c.FICHA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                If c.RC <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.RC
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.GRASA <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.GRASA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.PROTEINA <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.PROTEINA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.LACTOSA <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.LACTOSA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.ST <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.ST
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = ""
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.CRIOSCOPIA <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.CRIOSCOPIA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.UREA <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.UREA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.PROTEINAV <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.PROTEINAV
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.CASEINA <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.CASEINA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.DENSIDAD <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.DENSIDAD
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = columna + 1
                                End If
                                If c.PH <> -1 Then
                                    x1hoja.Cells(fila, columna).formula = c.PH
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = 1
                                    fila = fila + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                    columna = 1
                                    fila = fila + 1
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class