Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormEmbarqueCajas
    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        listarsincargar()
        listarcargadas()
    End Sub
#End Region
    Private Sub listarsincargar()
        Dim e As New dEnvioCajas
        Dim lista As New ArrayList
        lista = e.listarsincargar()
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each e In lista
                    DataGridView1(columna, fila).Value = e.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = e.FECHAENVIO
                    columna = columna + 1
                    Dim c As New dCliente
                    c.ID = e.IDPRODUCTOR
                    c = c.buscar
                    If Not c Is Nothing Then
                        DataGridView1(columna, fila).Value = c.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = e.IDCAJA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = e.FRASCOS
                    columna = columna + 1
                    Dim a As New dEmpresaT
                    a.ID = e.IDEMPRESA
                    a = a.buscar
                    If Not a Is Nothing Then
                        DataGridView1(columna, fila).Value = a.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarsincargar2()
        Dim e As New dEnvioCajas
        Dim lista As New ArrayList
        lista = e.listarsincargar2()
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each e In lista
                    DataGridView1(columna, fila).Value = e.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = e.FECHAENVIO
                    columna = columna + 1
                    Dim c As New dCliente
                    c.ID = e.IDPRODUCTOR
                    c = c.buscar
                    If Not c Is Nothing Then
                        DataGridView1(columna, fila).Value = c.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = e.IDCAJA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = e.FRASCOS
                    columna = columna + 1
                    Dim a As New dEmpresaT
                    a.ID = e.IDEMPRESA
                    a = a.buscar
                    If Not a Is Nothing Then
                        DataGridView1(columna, fila).Value = a.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarcargadas()
        Dim e As New dEnvioCajas
        Dim lista As New ArrayList
        lista = e.listarcargadas
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView2.Rows.Add(lista.Count)
                For Each e In lista
                    DataGridView2(columna, fila).Value = e.ID
                    columna = columna + 1
                    Dim c As New dCliente
                    c.ID = e.IDPRODUCTOR
                    c = c.buscar
                    If Not c Is Nothing Then
                        DataGridView2(columna, fila).Value = c.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView2(columna, fila).Value = e.IDCAJA
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = e.FRASCOS
                    columna = columna + 1
                    Dim a As New dEmpresaT
                    a.ID = e.IDEMPRESA
                    a = a.buscar
                    If Not a Is Nothing Then
                        DataGridView2(columna, fila).Value = a.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView2(columna, fila).Value = e.FECHAENVIO
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = e.ENVIO
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Cargada" Then

            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEnvioCajas
            id = row.Cells("Id").Value
            ec.ID = id
            ec = ec.buscar2
            If Not ec Is Nothing Then
                If ec.IDEMPRESA <> 7 And ec.IDEMPRESA <> 13 And ec.IDEMPRESA <> 15 Then
                    Dim v As New FormCompletoEnvio2(id, Usuario)
                    v.ShowDialog()
                End If
                ec.marcarcargada(Usuario)
            End If
            listarsincargar()
            listarcargadas()
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Desmarcar" Then
            If Usuario.ID = 1 Or Usuario.ID = 3 Or Usuario.ID = 5 Or Usuario.ID = 8 Or Usuario.ID = 38 Or Usuario.ID = 39 Then
                Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ec As New dEnvioCajas
                id = row.Cells("Id2").Value
                ec.ID = id
                ec = ec.buscar2
                If Not ec Is Nothing Then
                    ec.desmarcarcargada(Usuario)
                End If
                listarsincargar()
                listarcargadas()
            End If
        End If
    End Sub

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        imprimir()
    End Sub
    Private Sub imprimir()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        '*****************************
        Dim en As New dEnvioCajas
        Dim lista As New ArrayList
        Dim contador As Integer = 0
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        lista = en.listarsincargar
        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 35
        x1hoja.Cells(1, 3).columnwidth = 9
        x1hoja.Cells(1, 4).columnwidth = 8
        x1hoja.Cells(1, 5).columnwidth = 20
        x1hoja.Cells(1, 6).columnwidth = 8
        x1hoja.Cells(fila, columna).Formula = "LISTADO DE CAJAS PARA RETIRAR EN COLAVECO" & " -  " & Now
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "ID"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "CLIENTE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "CAJA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FRASCOS"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "AGENCIA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "CARGADO"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each en In lista
                    x1hoja.Cells(fila, columna).Formula = en.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    Dim c As New dCliente
                    c.ID = en.IDPRODUCTOR
                    c = c.buscar
                    If Not c Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = c.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = en.IDCAJA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = en.FRASCOS
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    Dim et As New dEmpresaT
                    et.ID = en.IDEMPRESA
                    et = et.buscar
                    If Not et Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = et.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                Next
            End If
        End If


        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Private Sub imprimir2()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        '*****************************
        Dim en As New dEnvioCajas
        Dim lista As New ArrayList
        Dim contador As Integer = 0
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        lista = en.listarsincargar2
        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 35
        x1hoja.Cells(1, 3).columnwidth = 9
        x1hoja.Cells(1, 4).columnwidth = 8
        x1hoja.Cells(1, 5).columnwidth = 20
        x1hoja.Cells(1, 6).columnwidth = 8
        x1hoja.Cells(fila, columna).Formula = "LISTADO DE CAJAS PARA ENVIAR" & " -  " & Now
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "ID"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "CLIENTE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "CAJA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FRASCOS"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "AGENCIA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "CARGADO"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each en In lista
                    x1hoja.Cells(fila, columna).Formula = en.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    Dim c As New dCliente
                    c.ID = en.IDPRODUCTOR
                    c = c.buscar
                    If Not c Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = c.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = en.IDCAJA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = en.FRASCOS
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    Dim et As New dEmpresaT
                    et.ID = en.IDEMPRESA
                    et = et.buscar
                    If Not et Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = et.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                Next
            End If
        End If


        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Private Sub ButtonOcultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOcultar.Click
        listarsincargar()
    End Sub

    Private Sub ButtonExcel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel2.Click
        imprimir2()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        listarsincargar2()
    End Sub
End Class