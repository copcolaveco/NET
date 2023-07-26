Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormInformeMuestrasDescartadas
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarlista()
    End Sub

#End Region
    Private Sub cargarlista()
        Dim dm As New dDescarteMuestras
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        lista = dm.listarporfecha(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each dm In lista
                    DataGridView1(columna, fila).Value = dm.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = dm.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = dm.FICHA
                    columna = columna + 1
                    Dim p As New dCliente
                    p.ID = dm.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim m As New dMuestras
                    m.ID = dm.IDMUESTRA
                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridView1(columna, fila).Value = m.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = dm.CANTIDAD
                    columna = columna + 1
                    Dim ti As New dTipoInforme
                    ti.ID = dm.IDTIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        DataGridView1(columna, fila).Value = ti.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim md As New dMotivoDescarte
                    md.ID = dm.IDMOTIVODESCARTE
                    md = md.buscar
                    If Not md Is Nothing Then
                        DataGridView1(columna, fila).Value = md.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = dm.VALOR
                    columna = columna + 1
                    Dim infret As New dInformacionRetorno
                    infret.ID = dm.IDINFORETORNO
                    infret = infret.buscar
                    If Not infret Is Nothing Then
                        DataGridView1(columna, fila).Value = infret.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim a As New dAutorizacion
                    a.ID = dm.IDAUTORIZACION
                    a = a.buscar
                    If Not a Is Nothing Then
                        DataGridView1(columna, fila).Value = a.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = dm.OBSERVACIONES
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        cargarlista()
    End Sub

    Private Sub ButtonExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportar.Click
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        Dim dm As New dDescarteMuestras
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        lista = dm.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 1
                Dim columna As Integer = 1

                x1hoja.Cells(1, 1).columnwidth = 10
                x1hoja.Cells(1, 2).columnwidth = 10
                x1hoja.Cells(1, 3).columnwidth = 25
                x1hoja.Cells(1, 4).columnwidth = 10
                x1hoja.Cells(1, 5).columnwidth = 8
                x1hoja.Cells(1, 6).columnwidth = 15
                x1hoja.Cells(1, 7).columnwidth = 25
                x1hoja.Cells(1, 8).columnwidth = 8
                x1hoja.Cells(1, 9).columnwidth = 20
                x1hoja.Cells(1, 10).columnwidth = 15
                x1hoja.Cells(1, 11).columnwidth = 25


                x1hoja.Cells(fila, columna).formula = "Fecha"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Ficha"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Productor"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Muestra"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Cantidad"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Tipo informe"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Motivo descarte"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Valor"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Información retorno"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Autorización"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Observaciones"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = 1
                fila = fila + 1

                For Each dm In lista

                    x1hoja.Cells(fila, columna).formula = dm.FECHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = dm.FICHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1
                    Dim p As New dCliente
                    p.ID = dm.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If
                    Dim m As New dMuestras
                    m.ID = dm.IDMUESTRA
                    m = m.buscar
                    If Not m Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = m.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).formula = dm.CANTIDAD
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1
                    Dim ti As New dTipoInforme
                    ti.ID = dm.IDTIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = ti.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If
                    Dim md As New dMotivoDescarte
                    md.ID = dm.IDMOTIVODESCARTE
                    md = md.buscar
                    If Not md Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = md.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).formula = dm.VALOR
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1
                    Dim infret As New dInformacionRetorno
                    infret.ID = dm.IDINFORETORNO
                    infret = infret.buscar
                    If Not infret Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = infret.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If
                    Dim a As New dAutorizacion
                    a.ID = dm.IDAUTORIZACION
                    a = a.buscar
                    If Not a Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = a.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).formula = dm.OBSERVACIONES
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = 1
                    fila = fila + 1
                Next
            End If
        End If

        x1app.Visible = True
        'x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class