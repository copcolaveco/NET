Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormClientesPorEmpresa

    Private Sub ButtonAgregarEmpresa_Click(sender As Object, e As EventArgs) Handles ButtonAgregarEmpresa.Click
        Dim v As New FormBuscarEmpresa
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim pro As dCliente = v.Cliente
            TextIdEmpresa.Text = pro.ID
            TextNombreEmpresa.Text = pro.NOMBRE

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        listar()
    End Sub
    Private Sub listar()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(0.5) '(1)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(0.5) '(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(0.5) '(1)
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 1
        x1hoja.Cells(fila, columna).formula = "Ficha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Cliente"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Matricula"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Informe"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim listaclientes As New ArrayList
        Dim p As New dProductorEmpresa
        Dim idempresa As Integer = TextIdEmpresa.Text
        listaclientes = p.listarxempresa(idempresa)
        If Not listaclientes Is Nothing Then
            For Each p In listaclientes
                Dim sa As New dSolicitudAnalisis
                Dim listaanalisis As New ArrayList
                listaanalisis = sa.listarxfechaxproductor(fecdesde, fechasta, p.IDPRODUCTOR)
                If Not listaanalisis Is Nothing Then
                    For Each sa In listaanalisis
                        x1hoja.Cells(fila, columna).formula = sa.ID
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        Dim c As New dCliente
                        c.ID = sa.IDPRODUCTOR
                        c = c.buscar
                        x1hoja.Cells(fila, columna).formula = c.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = p.MATRICULA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        Dim t As New dTipoInforme
                        t.ID = sa.IDTIPOINFORME
                        t = t.buscar
                        x1hoja.Cells(fila, columna).formula = t.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = sa.NMUESTRAS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1
                    Next
                End If
            Next
            '***********************************************************
            'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
            'PROTEGE LA HOJA DE EXCEL
            x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
            'GUARDA EL ARCHIVO DE EXCEL
            'x1hoja.SaveAs("\\ROBOT\PREINFORMES\CALIDAD\" & nroficha & ".xls")
            x1app.Visible = True
            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
        End If
    End Sub
End Class