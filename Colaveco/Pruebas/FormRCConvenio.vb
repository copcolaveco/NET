Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Public Class FormRCConvenio
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(fechadesde, "yyyy-MM-dd")
        fechasta = Format(fechahasta, "yyyy-MM-dd")
        Dim contador As Integer = 0

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
        Dim fila = 1
        Dim columna = 1
        x1hoja.Cells(fila, columna).formula = "Período: " & fecdesde & " - " & fechasta
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Productor"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Nombre"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Departamento"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Promedio RC"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        columna = 1


        Dim muestras As Integer = 0
        Dim totalrc As Long = 0
        Dim promediomuestras As Integer = 0
        Dim promediorc As Double = 0
        Dim cc As New dClienteConvenio
        Dim tipo As Integer = 1
        Dim listacc As New ArrayList
        listacc = cc.listar
        If Not listacc Is Nothing Then
            For Each cc In listacc
                Dim sa As New dSolicitudAnalisis
                Dim listasa As New ArrayList
                contador = 0
                muestras = 0
                totalrc = 0
                listasa = sa.listarxtipoxclientexfecha(tipo, cc.CLIENTE, fecdesde, fechasta)
                If Not listasa Is Nothing Then
                    For Each sa In listasa
                        Dim c As New dControl
                        Dim listac As New ArrayList
                        listac = c.listarxficha(sa.ID)
                        If Not listac Is Nothing Then

                            muestras = muestras + listac.Count
                            contador = contador + 1
                            For Each c In listac
                                totalrc = totalrc + c.RC
                            Next
                        End If
                    Next
                    x1hoja.Cells(fila, columna).formula = cc.CLIENTE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 1
                    Dim cli As New dCliente
                    cli.ID = cc.CLIENTE
                    cli = cli.buscar
                    If Not cli Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = cli.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 1

                        Dim d As New dDepartamento
                        d.ID = cli.IDDEPARTAMENTO
                        d = d.buscar
                        If Not d Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = d.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 9
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 9
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        columna = columna + 1
                    End If
                    promediomuestras = muestras / contador
                    x1hoja.Cells(fila, columna).formula = promediomuestras
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    columna = columna + 1
                    promediorc = totalrc / muestras
                    x1hoja.Cells(fila, columna).formula = promediorc
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    columna = 1
                End If

            Next
        End If
        x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls")
        x1app.Visible = True
        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class